using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public GameObject LevelSelectLoader;            // this is the panel for the level select screen

    //public TextMeshProUGUI currentScoreText;
    //public int highestLevelCompleted = 0;
    public int currentLevelNumber = -1; // increments to 0 when you start at level 0
    
    public int recommendedNextLevel;
    // PlayerPrefs "recommendedNextLevel"


    public int numberOfLevelsCompleted = 0;
    public TextMeshProUGUI numberOfLevelsCompletedText;

    public TextMeshProUGUI currentLevelText;


    //public int nextIncompleteLevel;
    // **************************************************************************************************************************************
    int highestLevelNumberThatExists = 24;        // on a scale of level 0 up thru level X, see Levels.cs for actual level contents
    // **************************************************************************************************************************************
    public bool allLevelsAreCompleted = false;

    public TextMeshProUGUI playLevelX;

    public int scoreAtStartOfLevel = 0;
    public int currentScore = 0;
    //int topScore = 0;


    public GameObject menuUI;
    public GameObject goalsParent;
    public GameObject circlesParent;
    public GameObject extraCirclesParent;
    public GameObject bigsParent;
    public GameObject inGameUI;
    public GameObject levelSelectUI;
    public GameObject levelSelectContentPanel;

    //public GameObject InstantiatedCirclesParent;

    public int numberOfGoals;
    public bool levelIsDone = false;
    public GameObject nextLevelButton;          // do this later
    public GameObject restartLevelButton;
    public GameObject backButton;

    public Levels repOfLevels;

    public GameObject showHintButton;
    public GameObject hintText;
    public GameObject LevelUIMainMenuButton;

    //public bool tutorialsActivated = true;
    public GameObject Level1Tutorial;
    public GameObject Level2Tutorial;
    public TextMeshProUGUI FlashingTextForTutorial;
    public Button tutorialOnButton;
    public Button tutorialOffButton;

    public GameObject settingsUI;

    public string mostRecentKillFeedString;
    public GameObject KillFeedBackground;
    public TextMeshProUGUI KillFeed;

    public TextMeshProUGUI thisLevelScoreText;
    public GameObject LevelScore;
    public TextMeshProUGUI MainMenuTotalScore;
    public TextMeshProUGUI MainMenuAverageScore;
    public TextMeshProUGUI AllTimeHighScore;



    public void Awake()
    {
        instance = this;
        repOfLevels = GameObject.Find("Level Creator").GetComponent<Levels>();
        currentLevelNumber = -1;
        UpdateMainMenuScoreStuff();

        // count up the number of levels completed
        CountNumberOfLevelsCompleted();
        if (allLevelsAreCompleted)
        {
            numberOfLevelsCompletedText.text = "All " + (highestLevelNumberThatExists + 1) + " Levels are Solved";
        }
        else
        {
            numberOfLevelsCompletedText.text = numberOfLevelsCompleted + " of " + (highestLevelNumberThatExists + 1) + " levels completed";
        }

        // identify the lowest level not yet completed
        IdentifyLowestUnsolvedLevel();
        if (allLevelsAreCompleted)
        {
            playLevelX.text = "Your training is now complete";
        }
        else
        {
            playLevelX.text = "Play Level " + (recommendedNextLevel + 1);
        }

        menuUI.SetActive(true);
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(true);
        circlesParent.SetActive(false);
        extraCirclesParent.SetActive(false);
        //repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(false);
        goalsParent.SetActive(false);
        inGameUI.SetActive(false);
        levelSelectUI.SetActive(false);
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        settingsUI.SetActive(false);


        if (PlayerPrefs.HasKey("TutorialsActivated")) {
            if (PlayerPrefs.GetInt("TutorialsActivated") == 0) {
                tutorialOnButton.GetComponent<Button>().interactable = true;
                tutorialOffButton.GetComponent<Button>().interactable = false;
            } else if (PlayerPrefs.GetInt("TutorialsActivated") == 1) {
                tutorialOnButton.GetComponent<Button>().interactable = false;
                tutorialOffButton.GetComponent<Button>().interactable = true;
            }
        }




    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        repOfLevels = GameObject.Find("Level Creator").GetComponent<Levels>();
        currentLevelNumber = -1;
        UpdateMainMenuScoreStuff();

        // count up the number of levels completed
        CountNumberOfLevelsCompleted();
        if (allLevelsAreCompleted) {
            numberOfLevelsCompletedText.text = "All " + (highestLevelNumberThatExists + 1) + " Levels are Solved";
        } else {
            numberOfLevelsCompletedText.text = numberOfLevelsCompleted + " of " + (highestLevelNumberThatExists + 1) + " levels completed";
        }

        // identify the lowest level not yet completed
        IdentifyLowestUnsolvedLevel();
        if (allLevelsAreCompleted) {
            playLevelX.text = "Your training is now complete";
        } else {
            playLevelX.text = "Play Level " + (recommendedNextLevel + 1);
        }

        menuUI.SetActive(true);
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(true);
        circlesParent.SetActive(false);
        extraCirclesParent.SetActive(false);
        //repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(false);
        goalsParent.SetActive(false);
        inGameUI.SetActive(false);
        levelSelectUI.SetActive(false);
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        settingsUI.SetActive(false);


        if (PlayerPrefs.HasKey("TutorialsActivated"))
        {
            if (PlayerPrefs.GetInt("TutorialsActivated") == 0)
            {
                tutorialOnButton.GetComponent<Button>().interactable = true;
                tutorialOffButton.GetComponent<Button>().interactable = false;
            }
            else if (PlayerPrefs.GetInt("TutorialsActivated") == 1)
            {
                tutorialOnButton.GetComponent<Button>().interactable = false;
                tutorialOffButton.GetComponent<Button>().interactable = true;
            }
        }

    }


    public int ReturnHighestLevelNumberThatExists() {
        return highestLevelNumberThatExists;
    }

    public void SetHighestLevelNumberThatExists(int highest) {
        highestLevelNumberThatExists = highest;
    }

    public void IdentifyLowestUnsolvedLevel() {
        for (int i = 0; i <= highestLevelNumberThatExists; i++)
        {
            var tempString = (i).ToString() + "_Completed";
            var completedInt = PlayerPrefs.GetInt(tempString, 0);
            if (completedInt != 1)
            {
                recommendedNextLevel = i;
                break;
            }
        }
    }

    public void CountNumberOfLevelsCompleted() {
        numberOfLevelsCompleted = 0;
        for (int i = 0; i < highestLevelNumberThatExists + 1; i++)
        {
            var tempString = (i).ToString() + "_Completed";
            var completedInt = PlayerPrefs.GetInt(tempString, 0);
            if (completedInt == 1)
            {
                numberOfLevelsCompleted += 1;
            }
        }
        if (numberOfLevelsCompleted == highestLevelNumberThatExists + 1) {
            // all levels are complete
            allLevelsAreCompleted = true;
        }
    }


    public void checkIfLevelIsOver() {
        GameObject[] goals = GameObject.FindGameObjectsWithTag("goal");
        numberOfGoals = goals.Length;
        var fulfilledGoalsFound = 0;
        var goalsAreDone = false;
        foreach (GameObject goal in goals)
        {
            if (goal.GetComponent<Goal>().goalFulfilled == true)
            {
                fulfilledGoalsFound += 1;
            }
        }
        if (fulfilledGoalsFound >= numberOfGoals) {
            goalsAreDone = true;
            //Debug.Log("we found that " + numberOfGoals + " goals have been fulfilled");
            //nextLevelButton.gameObject.SetActive(true);
        }

        // check that all Circles and Bigs are no longer active
        GameObject[] circles = GameObject.FindGameObjectsWithTag("little");
        var numberOfCircles = circles.Length;
        var numberOfActiveCircles = 0;
        foreach (GameObject circle in circles) { 
            if (circle.activeSelf) {
                numberOfActiveCircles += 1;
            }
        }
        if (numberOfActiveCircles == 0) {
            //Debug.Log("we found that all " + circles.Length + " circles are no longer active");
        }

        GameObject[] bigs = GameObject.FindGameObjectsWithTag("big");
        var numberOfBigs = circles.Length;
        var numberOfActiveBigs = 0;
        foreach (GameObject big in bigs)
        {
            if (big.activeSelf)
            {
                numberOfActiveBigs += 1;
            }
        }
        if (numberOfActiveBigs == 0)
        {
            //Debug.Log("we found that all " + bigs.Length + " bigs are no longer active");
        }

        if (numberOfActiveCircles == 0 && numberOfActiveBigs == 0 && goalsAreDone == true) {
            // make the Next Level button appear
            nextLevelButton.SetActive(true);
            // turn on the "Perfect Score!" text if the score is perfect
            if (GetLevelScore(currentLevelNumber) == 100) {
                nextLevelButton.transform.GetChild(1).gameObject.SetActive(true);
            }


            restartLevelButton.SetActive(false);
            backButton.SetActive(false);
            
            var tempString = currentLevelNumber.ToString() + "_Completed";
            // "3_Completed"
            PlayerPrefs.SetInt(tempString, 1);      // 0 means not completed, 1 means completed
                                                    //Debug.Log("ok: " + tempString + " ... ");

            // turn off the hint
            hintText.SetActive(false);
            // turn off the "show hint" button
            showHintButton.SetActive(false);
            LevelUIMainMenuButton.SetActive(false);
            // turn off the Level1 or Level2 tutorial
            Level1Tutorial.SetActive(false);
            Level2Tutorial.SetActive(false);
            
            if (currentLevelNumber == 1 && PlayerPrefs.GetInt("TutorialsActivated") == 1) {
                //restartLevelButton.GetComponent<ColorFluxButton>().StopColorFlux();
                //FlashingTextForTutorial.GetComponent<ColorFluxText>().StopColorFlux();
            }

            SetLevelAsCompleted();
            UpdateLevelCompletionInfo();
            UpdateKillFeed("  ");
            KillFeedBackground.SetActive(false);
            ResetHistory();
            




        }
    }


    public void LoadSpecificLevel(int level) {
        menuUI.SetActive(false);
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(true);
        //ensure that the level components are active
        goalsParent.SetActive(true);
        circlesParent.SetActive(true);
        extraCirclesParent.SetActive(true);
        //repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(true);
        inGameUI.SetActive(true);
        levelSelectUI.SetActive(false);

        //highestLevelCompletedText.text = PlayerPrefs.GetInt("highestLevelCompleted", 0).ToString() + " of 100 levels completed";
        //playLevelX.text = "Play Level " + (PlayerPrefs.GetInt("highestLevelCompleted", 0) + 1).ToString();
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        repOfLevels.GoToLevel(level);
    }


    public void GoToLevelSelect() {
        menuUI.SetActive(false);
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(false);
        //ensure that the level components are active
        goalsParent.SetActive(false);
        circlesParent.SetActive(false);
        extraCirclesParent.SetActive(false);
        //repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(false);
        inGameUI.SetActive(false);
        levelSelectUI.SetActive(true);
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        settingsUI.SetActive(false);

        // need to reload all the icons, because things may have changed
        //LevelSelectLoader.GetComponent<LevelSelector2>().ReloadIcons();                              //**********************************************
    }

    public void GoToSettingsStuff() {

        menuUI.SetActive(false);
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(false);
        //ensure that the level components are active
        goalsParent.SetActive(false);
        circlesParent.SetActive(false);
        extraCirclesParent.SetActive(false);
        //repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(false);
        inGameUI.SetActive(false);
        levelSelectUI.SetActive(false);
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        settingsUI.SetActive(true);

    }

    public void GoToMainMenu() {
        menuUI.SetActive(true);
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(false);
        //ensure that the level components are active
        goalsParent.SetActive(false);
        circlesParent.SetActive(false);
        extraCirclesParent.SetActive(false);
        //repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(false);
        inGameUI.SetActive(false);
        levelSelectUI.SetActive(false);
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        settingsUI.SetActive(false);
        UpdateMainMenuScoreStuff();
    }

    public void TutorialsActivate() {           
        //tutorialsActivated = true;
        PlayerPrefs.SetInt("TutorialsActivated", 1);
        // set the "interactable" status of the TUTORIALS ON button (in the settings menu) to NOT INTERACTABLE, even after a Scene reload
        //PlayerPrefs.SetInt("TutorialsOnButton", 0);
        //PlayerPrefs.SetInt("TutorialsOffButton", 1);
    }
    public void TutorialsDeactivate() {
        //tutorialsActivated = false;
        PlayerPrefs.SetInt("TutorialsActivated", 0);
        //PlayerPrefs.SetInt("TutorialsOnButton", 1);
        //PlayerPrefs.SetInt("TutorialsOffButton", 0);

    }

    public void UpdateLevelCompletionInfo() {
        CountNumberOfLevelsCompleted();
        if (allLevelsAreCompleted)
        {
            numberOfLevelsCompletedText.text = "All " + (highestLevelNumberThatExists + 1) + " Levels are Solved";
        }
        else
        {
            numberOfLevelsCompletedText.text = numberOfLevelsCompleted + " of " + (highestLevelNumberThatExists + 1) + " levels completed";
        }

        // identify the lowest level not yet completed
        IdentifyLowestUnsolvedLevel();
        if (allLevelsAreCompleted)
        {
            playLevelX.text = "Your training is now complete";
        }
        else
        {
            playLevelX.text = "Play Level " + (recommendedNextLevel + 1);
        }

        levelSelectContentPanel.GetComponent<LevelSelector2>().ReloadIconColors();
    }

    public void ContributeToKillFeed(string whichMath, float firstNum, float secondNum, float result) {
        
        string NumToString(float num) {
            string toReturn = "";
            var marginOfError = 0.001f;
            if ((num - Mathf.Floor(num)) < marginOfError) {
                toReturn = Mathf.Floor(num).ToString("F0");
            } else if ((Mathf.Ceil(num) - num) < marginOfError) {
                toReturn = Mathf.Ceil(num).ToString("F0");
            } else if (num % 1 == 0) {
                toReturn = num.ToString("F0");
            } else {
                toReturn = num.ToString("F2");
            }
            return toReturn;
        }
        
        switch (whichMath) {
            case "addition":
                mostRecentKillFeedString = NumToString(firstNum) + " + " + NumToString(secondNum) + " = " + NumToString(result); break;
            case "subtraction":
                mostRecentKillFeedString = NumToString(firstNum) + " - " + NumToString(secondNum) + " = " + NumToString(result); break;
            case "multiplication":
                mostRecentKillFeedString = NumToString(firstNum) + " * " + NumToString(secondNum) + " = " + NumToString(result); break;
            case "division":
                mostRecentKillFeedString = NumToString(firstNum) + " / " + NumToString(secondNum) + " = " + NumToString(result); break;
            case "exponent2":
                mostRecentKillFeedString = NumToString(firstNum) + " ^ 2 = " + NumToString(result); break;
            case "exponent3":
                mostRecentKillFeedString = NumToString(firstNum) + " ^ 3 = " + NumToString(result); break;
            case "exponent4":
                mostRecentKillFeedString = NumToString(firstNum) + " ^ 4 = " + NumToString(result); break;
            case "squareRoot":
                mostRecentKillFeedString = NumToString(firstNum) + " ^(1/2) = " + NumToString(result); break;
            case "cubeRoot":
                mostRecentKillFeedString = NumToString(firstNum) + " ^(1/3) = " + NumToString(result); break;
            case "split":
                if (firstNum == 2) {
                    mostRecentKillFeedString = NumToString(secondNum) + " split into 2x " + NumToString((float)(secondNum / 2.0));
                } else if (firstNum == 3) {
                    mostRecentKillFeedString = NumToString(secondNum) + " split into 3x " + NumToString((float)(secondNum / 3.0));
                } else if (firstNum == 4) {
                    mostRecentKillFeedString = NumToString(secondNum) + " split into 4x " + NumToString((float)(secondNum / 4.0));
                } else if (firstNum == 5) {
                    mostRecentKillFeedString = NumToString(secondNum) + " split into 5x " + NumToString((float)(secondNum / 5.0));
                } break;
        }
        UpdateKillFeed("");
    }
    public void UpdateKillFeed(string theText) {
        if (theText == "") {
            ToggleKillFeedActive(true);
            KillFeed.text = mostRecentKillFeedString;
        } else {
            ToggleKillFeedActive(false);
            mostRecentKillFeedString = theText;
            KillFeed.text = theText;
        }
    }
    public void ToggleKillFeedActive(bool boolie) {
        KillFeedBackground.SetActive(boolie);
    }
    public void ShowAllOfKillFeedHistory() { 

    }






    //public IEnumerator DelayLoad()
    //{
    //    Debug.Log("Started coroutine at " + Time.time);
    //    yield return new WaitForSecondsRealtime(0.0001f);
    //    Debug.Log("finished at " + Time.time);
    //    repOfLevels.CreateLevel(1);
    //    Debug.Log("after createLevel(1)");
    //}

    //public void AddPoints(int points) {
    //    currentScore += points;
    //    currentScoreText.text = "Score: " + currentScore.ToString();
    //    if (currentScore > topScore) {
    //        PlayerPrefs.SetInt("topScore", currentScore);
    //    }


    //}


    // example:
    //      Level_0_Completed

    public void SetLevelAsCompleted() {
        string temp = "Level_";
        temp = temp + currentLevelNumber.ToString() + "_Completed";
        PlayerPrefs.SetInt(temp, 1);
    }
    public void SetLevelAsNOTCompleted(int levelNum) {
        string temp = "Level_";
        temp = temp + levelNum.ToString() + "_Completed";
        PlayerPrefs.SetInt(temp, 0);
    }
    public void SetALLLevelsAsNotCompleted() {
        for (int i = 0; i <= highestLevelNumberThatExists; i++)
        {
            SetLevelAsNOTCompleted(i);
        }
    }
    public bool CheckIfLevelIsCompleted(int levelNum) {
        string temp = "Level_";
        temp = temp + levelNum.ToString() + "_Completed";
        //Debug.Log("the string in CheckIfLevelIsCompleted: " + temp);
        if (PlayerPrefs.GetInt(temp) == 1) {
            return true;
        } else {
            return false;
        }
    }
    public int GetLevelScore(int levelNum) {
        string temp = "Level_";
        temp = temp + levelNum.ToString() + "_Score";
        int toReturn = PlayerPrefs.GetInt(temp);
        return toReturn;
    }
    public void SetLevelScore(int newScore) {
        string temp = "Level_";
        temp = temp + currentLevelNumber.ToString() + "_Score";
        PlayerPrefs.SetInt(temp, newScore);
        UpdateScoreDisplay();
        UpdateMainMenuScoreStuff();
    }
    public void UpdateScoreDisplay() {
        thisLevelScoreText.text = "points: " + GetLevelScore(currentLevelNumber).ToString();
    }
    public void UpdateScoreToCompleted() {
        thisLevelScoreText.text = "Final: " + GetLevelScore(currentLevelNumber).ToString();
    }
    public void HideScoreDisplay() {
        LevelScore.SetActive(false);
    }
    public void ShowScoreDisplay() {
        LevelScore.SetActive(true);
    }
    public void ReduceScore(int points) {
        if (CheckIfLevelIsCompleted(currentLevelNumber)) {
            // if the level has been completed previously, then do nothing here
        }
        else {
            SetLevelScore(GetLevelScore(currentLevelNumber) - points);
        }
    }

    public void MarkLevelAsNotPreviouslyAttempted() {
        string temp1 = "Level_" + currentLevelNumber.ToString() + "_PreviouslyAttempted";
        PlayerPrefs.SetInt(temp1, 0);
    }
    public void MarkLevelAsPreviouslyAttempted() {
        // this method will be attached to the Main Menu button in the Level UI, from within the Unity interface
        string temp1 = "Level_" + currentLevelNumber.ToString() + "_PreviouslyAttempted";
        string temp2 = "Level_" + currentLevelNumber.ToString() + "_PreviousAttemptScore";

        PlayerPrefs.SetInt(temp1, 1);
        PlayerPrefs.SetInt(temp2, GetLevelScore(currentLevelNumber));
    }
    public bool TestWhetherLevelPreviouslyAttempted() {
        // this method will be loaded when....
        string temp1 = "Level_" + currentLevelNumber.ToString() + "_PreviouslyAttempted";
        if (PlayerPrefs.GetInt(temp1) == 1) {
            return true;
        } else {
            return false;
        }
    }
    public int GetScoreFromPreviousAttempt() {
        string temp2 = "Level_" + currentLevelNumber.ToString() + "_PreviousAttemptScore";
        return PlayerPrefs.GetInt(temp2);
    }




    public void UpdateTotalScore() {
        int runningTotal = 0;
        for (int i = 0; i <= highestLevelNumberThatExists; i++) {
            if (CheckIfLevelIsCompleted(i)) {
                runningTotal += GetLevelScore(i);
            }
        }
        MainMenuTotalScore.text = "Total Points                           " + runningTotal.ToString();
    }
    public void UpdateAverageScorePerLevel() {
        int runningTotal = 0;
        for (int i = 0; i <= highestLevelNumberThatExists; i++) {
            if (CheckIfLevelIsCompleted(i)) {
                runningTotal += GetLevelScore(i);
            }
        }
        int levelsCompleted = 0;
        for (int i = 0; i <= highestLevelNumberThatExists; i++) { 
            if (CheckIfLevelIsCompleted(i)) {
                levelsCompleted += 1;
            }
        }
        float avg = 0.0f;
        if (levelsCompleted != 0) {
            avg = (float)((runningTotal * 1.1) / (levelsCompleted * 1.1));
        }
        if (avg == 100) {
            MainMenuAverageScore.text = "Average Points per Level:   " + avg.ToString("F0");
        } else {
            MainMenuAverageScore.text = "Average Points per Level:  " + avg.ToString("F2");
        }

        // now we update the HIGHEST AVERAGE SCORE PER LEVEL, OF ALL TIME
        //      first set it to the default if the game hasn't been completed yet
        if (PlayerPrefs.GetFloat("HighestAllTimeAverageScorePerLevel", 0) > 0) {
            AllTimeHighScore.text = "Game Completion All-Time High Score:         " + PlayerPrefs.GetFloat("HighestAllTimeAverageScorePerLevel").ToString("F3");
            //AllTimeHighScore.text = PlayerPrefs.GetString("HighScoreString");
        } else {
            AllTimeHighScore.text = "Beat all levels to set a new high score!";
        }
        //      now we test to see if we beat the high score
        if (levelsCompleted == highestLevelNumberThatExists + 1) {
            // set the PlayerPrefs highest all-time score thing (that we'll prevent from being deleted in the script for the Reset Progress button)
            float currentHighest = PlayerPrefs.GetFloat("HighestAllTimeAverageScorePerLevel", 0);
            if (avg > currentHighest) {
                PlayerPrefs.SetFloat("HighestAllTimeAverageScorePerLevel", avg);
                //PlayerPrefs.SetString("HighScoreString", "Game Completion All-Time High Score:         " + avg.ToString("F3"));
                // now we update the text on the Main Menu screen
                AllTimeHighScore.text = "Game Completion All-Time High Score:         " + avg.ToString("F3");

            }
        }

        

    }
    public void UpdateMainMenuScoreStuff() {
        //UpdateTotalScore();       // don't care about total score, only about avg score per level
        UpdateAverageScorePerLevel();
    }






















































    public int pointInHistory = -1;
    ArrayList History = new ArrayList();
    public int historyLength = 0;


    public void TakeSnapshot() {
        // store the current state of all circles, instantiated circles, bigs, goals
        // stuff it all into an arraylist, History, where History[0] is the first snapshot, History[1] is the second snapshot, etc.

        // History[0][0] is circles
        //                          History[0][0][0] is the first circle, History[0][0][9] is the 10th circle,  History[0][0][9][0] is the circle's value
        //                                                                                                      History[0][0][9][1] is the circle's activeOrNot
        //                                                                                                      History[0][0][9][2] is the circle's position
        // History[0][1] is instantiated circles
        // History[0][2] is Bigs
        // History[0][3] is Goals

        ArrayList thisSnapshot = new ArrayList();

        ArrayList circleInfo = new ArrayList();
        circleInfo = repOfLevels.GetAllCircleInfo();
        thisSnapshot.Add(circleInfo);       // this will be History[0][0]

        ArrayList extraCircleInfo = new ArrayList();
        extraCircleInfo = repOfLevels.GetAllExtraCircleInfo();
        thisSnapshot.Add(extraCircleInfo);

        ArrayList bigsInfo = new ArrayList();
        bigsInfo = repOfLevels.GetALLBigsInfo();
        thisSnapshot.Add(bigsInfo);

        ArrayList goalsInfo = new ArrayList();
        goalsInfo = repOfLevels.GetALLGoalsInfo();
        thisSnapshot.Add(goalsInfo);                            // History[4][3][1][3] is the second [1] goal's position [3] at pointInHistory 4

        thisSnapshot.Add(mostRecentKillFeedString);

        // after everything is gathered:
        pointInHistory++;   // use this as an index for retrieving from History
        History.Add(thisSnapshot);
        historyLength = History.Count;
    }

    public void GoBackOneStep() {
        
        if (pointInHistory >= 1) {
            GoBackToSnapshot(pointInHistory - 1);
            pointInHistory -= 1;
        }
        repOfLevels.EmptyGarbage();

        // if we're back at the beginning of the level, make the BACK button disappear (because we don't need it)
        if (historyLength <= 1) {
            // turn off the BACK button
            backButton.SetActive(false);
        }

    }


    public void GoBackToSnapshot(int timestamp) {
        ArrayList ToLoad = new ArrayList();
        ToLoad = (ArrayList)History[timestamp];
        History.RemoveAt(History.Count - 1);        // this is not robust because what if we choose a much earlier timestamp... but it doesn't matter for now
        historyLength = History.Count;

        ArrayList Circles = new ArrayList();
        ArrayList ExtraCircles = new ArrayList();
        ArrayList Bigs = new ArrayList();
        ArrayList Goals = new ArrayList();

        Circles = (ArrayList)ToLoad[0];
        ExtraCircles = (ArrayList)ToLoad[1];
        Bigs = (ArrayList)ToLoad[2];
        Goals = (ArrayList)ToLoad[3];
        mostRecentKillFeedString = (string)ToLoad[4];
        UpdateKillFeed("");


        for (int i = 0; i < 10; i++) {
            repOfLevels.RestoreCircle((ArrayList)Circles[i], i);
        }
        for (int i = 0; i < 30; i++) {
            repOfLevels.RestoreExtraCircle((ArrayList)ExtraCircles[i], i);
        }
        for (int i = 0; i < 6; i++) {
            repOfLevels.RestoreBig((ArrayList)Bigs[i], i);
        }
        for (int i = 0; i < 5; i++) {
            repOfLevels.RestoreGoal((ArrayList)Goals[i], i);
        }
    }


    public void ResetHistory()
    {
        pointInHistory = -1;
        History = null;
        History = new ArrayList();
    }




}
