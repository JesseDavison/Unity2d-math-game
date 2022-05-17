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
    int highestLevelNumberThatExists = 21;        // on a scale of level 0 up thru level X, see Levels.cs for actual level contents
    // **************************************************************************************************************************************
    public bool allLevelsAreCompleted = false;

    public TextMeshProUGUI playLevelX;

    public int scoreAtStartOfLevel = 0;
    public int currentScore = 0;
    //int topScore = 0;


    public GameObject menuUI;
    public GameObject goalsParent;
    public GameObject circlesParent;
    public GameObject bigsParent;
    public GameObject inGameUI;
    public GameObject levelSelectUI;

    public GameObject InstantiatedCirclesParent;

    public int numberOfGoals;
    public bool levelIsDone = false;
    public GameObject nextLevelButton;          // do this later
    public GameObject restartLevelButton;

    public Levels repOfLevels;

    public GameObject showHintButton;
    public GameObject hintText;

    public bool tutorialsActivated = true;
    public GameObject Level1Tutorial;
    public GameObject Level2Tutorial;
    public TextMeshProUGUI FlashingTextForTutorial;

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
        repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(false);
        goalsParent.SetActive(false);
        inGameUI.SetActive(false);
        levelSelectUI.SetActive(false);
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        settingsUI.SetActive(false);
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
        repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(false);
        goalsParent.SetActive(false);
        inGameUI.SetActive(false);
        levelSelectUI.SetActive(false);
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        settingsUI.SetActive(false);

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
            
            if (currentLevelNumber == 1 && tutorialsActivated == true) {
                restartLevelButton.GetComponent<ColorFluxButton>().StopColorFlux();
                FlashingTextForTutorial.GetComponent<ColorFluxText>().StopColorFlux();
            }
            




        }
    }


    public void LoadSpecificLevel(int level) {
        menuUI.SetActive(false);
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(true);
        //ensure that the level components are active
        goalsParent.SetActive(true);
        circlesParent.SetActive(true);
        repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
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
        repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
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
        repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
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
        repOfLevels.GetComponent<Levels>().DeleteInstantiatedCircles();
        bigsParent.SetActive(false);
        inGameUI.SetActive(false);
        levelSelectUI.SetActive(false);
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
        settingsUI.SetActive(false);
    }

    public void TutorialsActivate() {
        tutorialsActivated = true;
    }
    public void TutorialsDeactive() {
        tutorialsActivated = false;
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



}
