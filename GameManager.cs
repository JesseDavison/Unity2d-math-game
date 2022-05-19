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
    int highestLevelNumberThatExists = 23;        // on a scale of level 0 up thru level X, see Levels.cs for actual level contents
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

    //public bool tutorialsActivated = true;
    public GameObject Level1Tutorial;
    public GameObject Level2Tutorial;
    public TextMeshProUGUI FlashingTextForTutorial;
    public Button tutorialOnButton;
    public Button tutorialOffButton;

    public GameObject settingsUI;




    public void Awake()
    {
        instance = this;
        repOfLevels = GameObject.Find("Level Creator").GetComponent<Levels>();
        currentLevelNumber = -1;

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
            // turn off the Level1 or Level2 tutorial
            Level1Tutorial.SetActive(false);
            Level2Tutorial.SetActive(false);
            
            if (currentLevelNumber == 1 && PlayerPrefs.GetInt("TutorialsActivated") == 1) {
                restartLevelButton.GetComponent<ColorFluxButton>().StopColorFlux();
                FlashingTextForTutorial.GetComponent<ColorFluxText>().StopColorFlux();
            }

            UpdateLevelCompletionInfo();
            




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
