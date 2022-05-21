using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Levels : MonoBehaviour
{
    public GameManager managerOfTheGame;
    
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;
    public GameObject circle4;
    public GameObject circle5;
    public GameObject circle6;
    public GameObject circle7;
    public GameObject circle8;
    public GameObject circle9;
    public GameObject circle10;
    public List<GameObject> circlesList;  // circles are added in Start()

    public GameObject extraCircle1;
    public GameObject extraCircle2;
    public GameObject extraCircle3;
    public GameObject extraCircle4;
    public GameObject extraCircle5;
    public GameObject extraCircle6;
    public GameObject extraCircle7;
    public GameObject extraCircle8;
    public GameObject extraCircle9;
    public GameObject extraCircle10;
    public GameObject extraCircle11;
    public GameObject extraCircle12;
    public GameObject extraCircle13;
    public GameObject extraCircle14;
    public GameObject extraCircle15;
    public GameObject extraCircle16;
    public GameObject extraCircle17;
    public GameObject extraCircle18;
    public GameObject extraCircle19;
    public GameObject extraCircle20;
    public GameObject extraCircle21;
    public GameObject extraCircle22;
    public GameObject extraCircle23;
    public GameObject extraCircle24;
    public GameObject extraCircle25;
    public GameObject extraCircle26;
    public GameObject extraCircle27;
    public GameObject extraCircle28;
    public GameObject extraCircle29;
    public GameObject extraCircle30;
    public List<GameObject> extraCirclesList;



    public GameObject big1;
    public GameObject big2;
    public GameObject big3;
    public GameObject big4;
    public GameObject big5;
    public GameObject big6;
    public List<GameObject> bigsList;


    public GameObject goal1;
    public GameObject goal2;
    public GameObject goal3;
    public GameObject goal4;
    public GameObject goal5;
    public List<GameObject> goalsList;

    public GameObject showHintButton;
    public GameObject hint1;
    public List<GameObject> hintsList;
    public GameObject LevelUIMainMenuButton;
    public GameObject BackButton;

    //public GameObject InstantiatedCirclesParent;

    public GameObject Level1Tutorial;
    public GameObject Level2Tutorial;
    public GameObject RestartLevelButton;
    public TextMeshProUGUI FlashingTextForTutorial;

    public List<string> difficultyLevels;

    public int highestLevelNumber = 3;

    int numberOfCircles;
    int numberOfBigs;
    int numberOfGoals;
    int numberOfHints;

    static int circleZvalue = 1;
    static int bigZvalue = 19;
    static int goalZvalue = 20;

    static float circle_TopRowY = 4.3f;
    static float circle_BotRowY = 3.1f;

    static float _5CirclesSpacingX = 1.2f;

    static float _4CirclesMidOffset = 0.7f;
    static float _4CirclesSpacingX = 1.4f;

    static float _3CirclesSpacingX = 1.5f;

    static float _2CirclesMidOffset = 0.8f;

    static float big_RowY1 = 1.2f;
    static float big_RowY2 = 0.075f;
    static float big_RowY3 = -1.05f;
    static float big_RowY4 = -2.175f;
    static float big_RowY5 = -3.3f;

    static float big_ColX1 = -1.5f;
    static float big_ColX3 = 1.5f;


    //static Vector3 magnetOffset = new Vector3(0, 0.7f, 0);
    static Vector3 big_LeftRightMagnetOffset = new Vector3(0.6f, 0, 0);
    static Vector3 big_ExponentOffset = new Vector3(-0.1f, -0.1f, 0);
    static Vector3 big_RootOffset = new Vector3(0.05f, -0.1f, 0);

    private void Start()
    {
        managerOfTheGame = GameObject.Find("Game Manager").GetComponent<GameManager>();

        circlesList.Add(circle1);
        circlesList.Add(circle2);
        circlesList.Add(circle3);
        circlesList.Add(circle4);
        circlesList.Add(circle5);
        circlesList.Add(circle6);
        circlesList.Add(circle7);
        circlesList.Add(circle8);
        circlesList.Add(circle9);
        circlesList.Add(circle10);
        extraCirclesList.Add(extraCircle1);
        extraCirclesList.Add(extraCircle2);
        extraCirclesList.Add(extraCircle3);
        extraCirclesList.Add(extraCircle4);
        extraCirclesList.Add(extraCircle5);
        extraCirclesList.Add(extraCircle6);
        extraCirclesList.Add(extraCircle7);
        extraCirclesList.Add(extraCircle8);
        extraCirclesList.Add(extraCircle9);
        extraCirclesList.Add(extraCircle10);
        extraCirclesList.Add(extraCircle11);
        extraCirclesList.Add(extraCircle12);
        extraCirclesList.Add(extraCircle13);
        extraCirclesList.Add(extraCircle14);
        extraCirclesList.Add(extraCircle15);
        extraCirclesList.Add(extraCircle16);
        extraCirclesList.Add(extraCircle17);
        extraCirclesList.Add(extraCircle18);
        extraCirclesList.Add(extraCircle19);
        extraCirclesList.Add(extraCircle20);
        extraCirclesList.Add(extraCircle21);
        extraCirclesList.Add(extraCircle22);
        extraCirclesList.Add(extraCircle23);
        extraCirclesList.Add(extraCircle24);
        extraCirclesList.Add(extraCircle25);
        extraCirclesList.Add(extraCircle26);
        extraCirclesList.Add(extraCircle27);
        extraCirclesList.Add(extraCircle28);
        extraCirclesList.Add(extraCircle29);
        extraCirclesList.Add(extraCircle30);
        bigsList.Add(big1);
        bigsList.Add(big2);
        bigsList.Add(big3);
        bigsList.Add(big4);
        bigsList.Add(big5);
        bigsList.Add(big6);
        goalsList.Add(goal1);
        goalsList.Add(goal2);
        goalsList.Add(goal3);
        goalsList.Add(goal4);
        goalsList.Add(goal5);
        hintsList.Add(hint1);
        difficultyLevels.Add("easy");
        difficultyLevels.Add("medium");
        difficultyLevels.Add("hard");
        difficultyLevels.Add("expert");
    }

    public void setCirclesInPlace(int numberOfCircles) { 
        switch (numberOfCircles) {
            case 1:
                circle1.transform.position = new Vector3(0, circle_BotRowY, circleZvalue);
                circle2.transform.position = new Vector3(0, 0, circleZvalue);
                circle3.transform.position = new Vector3(0, 0, circleZvalue);
                circle4.transform.position = new Vector3(0, 0, circleZvalue);
                circle5.transform.position = new Vector3(0, 0, circleZvalue);
                circle6.transform.position = new Vector3(0, 0, circleZvalue);
                circle7.transform.position = new Vector3(0, 0, circleZvalue);
                circle8.transform.position = new Vector3(0, 0, circleZvalue);
                circle9.transform.position = new Vector3(0, 0, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(false);
                circle3.SetActive(false);
                circle4.SetActive(false);
                circle5.SetActive(false);
                circle6.SetActive(false);
                circle7.SetActive(false);
                circle8.SetActive(false);
                circle9.SetActive(false);
                circle10.SetActive(false);
                break;
            case 2:
                circle1.transform.position = new Vector3(_2CirclesMidOffset * -1, circle_BotRowY, circleZvalue);
                circle2.transform.position = new Vector3(_2CirclesMidOffset * 1, circle_BotRowY, circleZvalue);
                circle3.transform.position = new Vector3(0, 0, circleZvalue);
                circle4.transform.position = new Vector3(0, 0, circleZvalue);
                circle5.transform.position = new Vector3(0, 0, circleZvalue);
                circle6.transform.position = new Vector3(0, 0, circleZvalue);
                circle7.transform.position = new Vector3(0, 0, circleZvalue);
                circle8.transform.position = new Vector3(0, 0, circleZvalue);
                circle9.transform.position = new Vector3(0, 0, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(false);
                circle4.SetActive(false);
                circle5.SetActive(false);
                circle6.SetActive(false);
                circle7.SetActive(false);
                circle8.SetActive(false);
                circle9.SetActive(false);
                circle10.SetActive(false);
                break;
            case 3:
                circle1.transform.position = new Vector3(_3CirclesSpacingX * -1, circle_BotRowY, circleZvalue);
                circle2.transform.position = new Vector3(0, circle_BotRowY, circleZvalue);
                circle3.transform.position = new Vector3(_3CirclesSpacingX * 1, circle_BotRowY, circleZvalue);
                circle4.transform.position = new Vector3(0, 0, circleZvalue);
                circle5.transform.position = new Vector3(0, 0, circleZvalue);
                circle6.transform.position = new Vector3(0, 0, circleZvalue);
                circle7.transform.position = new Vector3(0, 0, circleZvalue);
                circle8.transform.position = new Vector3(0, 0, circleZvalue);
                circle9.transform.position = new Vector3(0, 0, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(false);
                circle5.SetActive(false);
                circle6.SetActive(false);
                circle7.SetActive(false);
                circle8.SetActive(false);
                circle9.SetActive(false);
                circle10.SetActive(false);
                break;
            case 4:
                circle1.transform.position = new Vector3(_2CirclesMidOffset * -1, circle_TopRowY, circleZvalue);
                circle2.transform.position = new Vector3(_2CirclesMidOffset * 1, circle_TopRowY, circleZvalue);
                circle3.transform.position = new Vector3(_2CirclesMidOffset * -1, circle_BotRowY, circleZvalue);
                circle4.transform.position = new Vector3(_2CirclesMidOffset * 1, circle_BotRowY, circleZvalue);
                circle5.transform.position = new Vector3(0, 0, circleZvalue);
                circle6.transform.position = new Vector3(0, 0, circleZvalue);
                circle7.transform.position = new Vector3(0, 0, circleZvalue);
                circle8.transform.position = new Vector3(0, 0, circleZvalue);
                circle9.transform.position = new Vector3(0, 0, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(true);
                circle5.SetActive(false);
                circle6.SetActive(false);
                circle7.SetActive(false);
                circle8.SetActive(false);
                circle9.SetActive(false);
                circle10.SetActive(false);
                break;
            case 5:
                circle1.transform.position = new Vector3(_3CirclesSpacingX * -1, circle_TopRowY, circleZvalue);
                circle2.transform.position = new Vector3(_3CirclesSpacingX * 0, circle_TopRowY, circleZvalue);
                circle3.transform.position = new Vector3(_3CirclesSpacingX * 1, circle_TopRowY, circleZvalue);
                circle4.transform.position = new Vector3(_2CirclesMidOffset * -1, circle_BotRowY, circleZvalue);
                circle5.transform.position = new Vector3(_2CirclesMidOffset * 1, circle_BotRowY, circleZvalue);
                circle6.transform.position = new Vector3(0, 0, circleZvalue);
                circle7.transform.position = new Vector3(0, 0, circleZvalue);
                circle8.transform.position = new Vector3(0, 0, circleZvalue);
                circle9.transform.position = new Vector3(0, 0, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(true);
                circle5.SetActive(true);
                circle6.SetActive(false);
                circle7.SetActive(false);
                circle8.SetActive(false);
                circle9.SetActive(false);
                circle10.SetActive(false);
                break;
            case 6:
                circle1.transform.position = new Vector3(_3CirclesSpacingX * -1, circle_TopRowY, circleZvalue);
                circle2.transform.position = new Vector3(_3CirclesSpacingX * 0, circle_TopRowY, circleZvalue);
                circle3.transform.position = new Vector3(_3CirclesSpacingX * 1, circle_TopRowY, circleZvalue);
                circle4.transform.position = new Vector3(_3CirclesSpacingX * -1, circle_BotRowY, circleZvalue);
                circle5.transform.position = new Vector3(_3CirclesSpacingX * 0, circle_BotRowY, circleZvalue);
                circle6.transform.position = new Vector3(_3CirclesSpacingX * 1, circle_BotRowY, circleZvalue);
                circle7.transform.position = new Vector3(0, 0, circleZvalue);
                circle8.transform.position = new Vector3(0, 0, circleZvalue);
                circle9.transform.position = new Vector3(0, 0, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(true);
                circle5.SetActive(true);
                circle6.SetActive(true);
                circle7.SetActive(false);
                circle8.SetActive(false);
                circle9.SetActive(false);
                circle10.SetActive(false);
                break;
            case 7:
                circle1.transform.position = new Vector3(_4CirclesMidOffset * -1 + _4CirclesSpacingX * -1, circle_TopRowY, circleZvalue);
                circle2.transform.position = new Vector3(_4CirclesMidOffset * -1 + _4CirclesSpacingX * 0, circle_TopRowY, circleZvalue);
                circle3.transform.position = new Vector3(_4CirclesMidOffset * 1 + _4CirclesSpacingX * 0, circle_TopRowY, circleZvalue);
                circle4.transform.position = new Vector3(_4CirclesMidOffset * 1 + _4CirclesSpacingX * 1, circle_TopRowY, circleZvalue);
                circle5.transform.position = new Vector3(_3CirclesSpacingX * -1, circle_BotRowY, circleZvalue);
                circle6.transform.position = new Vector3(_3CirclesSpacingX * 0, circle_BotRowY, circleZvalue);
                circle7.transform.position = new Vector3(_3CirclesSpacingX * 1, circle_BotRowY, circleZvalue);
                circle8.transform.position = new Vector3(0, 0, circleZvalue);
                circle9.transform.position = new Vector3(0, 0, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(true);
                circle5.SetActive(true);
                circle6.SetActive(true);
                circle7.SetActive(true);
                circle8.SetActive(false);
                circle9.SetActive(false);
                circle10.SetActive(false);
                break;
            case 8:
                circle1.transform.position = new Vector3(_4CirclesMidOffset * -1 + _4CirclesSpacingX * -1, circle_TopRowY, circleZvalue);
                circle2.transform.position = new Vector3(_4CirclesMidOffset * -1 + _4CirclesSpacingX * 0, circle_TopRowY, circleZvalue);
                circle3.transform.position = new Vector3(_4CirclesMidOffset * 1 + _4CirclesSpacingX * 0, circle_TopRowY, circleZvalue);
                circle4.transform.position = new Vector3(_4CirclesMidOffset * 1 + _4CirclesSpacingX * 1, circle_TopRowY, circleZvalue);
                circle5.transform.position = new Vector3(_4CirclesMidOffset * -1 + _4CirclesSpacingX * -1, circle_BotRowY, circleZvalue);
                circle6.transform.position = new Vector3(_4CirclesMidOffset * -1 + _4CirclesSpacingX * 0, circle_BotRowY, circleZvalue);
                circle7.transform.position = new Vector3(_4CirclesMidOffset * 1 + _4CirclesSpacingX * 0, circle_BotRowY, circleZvalue);
                circle8.transform.position = new Vector3(_4CirclesMidOffset * 1 + _4CirclesSpacingX * 1, circle_BotRowY, circleZvalue);
                circle9.transform.position = new Vector3(0, 0, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(true);
                circle5.SetActive(true);
                circle6.SetActive(true);
                circle7.SetActive(true);
                circle8.SetActive(true);
                circle9.SetActive(false);
                circle10.SetActive(false);
                break;
            case 9:
                circle1.transform.position = new Vector3(_5CirclesSpacingX * -2, circle_TopRowY, circleZvalue);
                circle2.transform.position = new Vector3(_5CirclesSpacingX * -1, circle_TopRowY, circleZvalue);
                circle3.transform.position = new Vector3(_5CirclesSpacingX * 0, circle_TopRowY, circleZvalue);
                circle4.transform.position = new Vector3(_5CirclesSpacingX * 1, circle_TopRowY, circleZvalue);
                circle5.transform.position = new Vector3(_5CirclesSpacingX * 2, circle_TopRowY, circleZvalue);
                circle6.transform.position = new Vector3(_4CirclesMidOffset * -1 + _4CirclesSpacingX * -1, circle_BotRowY, circleZvalue);
                circle7.transform.position = new Vector3(_4CirclesMidOffset * -1 + _4CirclesSpacingX * 0, circle_BotRowY, circleZvalue);
                circle8.transform.position = new Vector3(_4CirclesMidOffset * 1 + _4CirclesSpacingX * 0, circle_BotRowY, circleZvalue);
                circle9.transform.position = new Vector3(_4CirclesMidOffset * 1 + _4CirclesSpacingX * 1, circle_BotRowY, circleZvalue);
                circle10.transform.position = new Vector3(0, 0, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(true);
                circle5.SetActive(true);
                circle6.SetActive(true);
                circle7.SetActive(true);
                circle8.SetActive(true);
                circle9.SetActive(true);
                circle10.SetActive(false);
                break;
            case 10:
                circle1.transform.position = new Vector3(_5CirclesSpacingX * -2, circle_TopRowY, circleZvalue);
                circle2.transform.position = new Vector3(_5CirclesSpacingX * -1, circle_TopRowY, circleZvalue);
                circle3.transform.position = new Vector3(_5CirclesSpacingX * 0, circle_TopRowY, circleZvalue);
                circle4.transform.position = new Vector3(_5CirclesSpacingX * 1, circle_TopRowY, circleZvalue);
                circle5.transform.position = new Vector3(_5CirclesSpacingX * 2, circle_TopRowY, circleZvalue);
                circle6.transform.position = new Vector3(_5CirclesSpacingX * -2, circle_BotRowY, circleZvalue);
                circle7.transform.position = new Vector3(_5CirclesSpacingX * -1, circle_BotRowY, circleZvalue);
                circle8.transform.position = new Vector3(_5CirclesSpacingX * 0, circle_BotRowY, circleZvalue);
                circle9.transform.position = new Vector3(_5CirclesSpacingX * 1, circle_BotRowY, circleZvalue);
                circle10.transform.position = new Vector3(_5CirclesSpacingX * 2, circle_BotRowY, circleZvalue);
                circle1.GetComponent<DragDropLittle>().originalPosition = circle1.transform.position;
                circle2.GetComponent<DragDropLittle>().originalPosition = circle2.transform.position;
                circle3.GetComponent<DragDropLittle>().originalPosition = circle3.transform.position;
                circle4.GetComponent<DragDropLittle>().originalPosition = circle4.transform.position;
                circle5.GetComponent<DragDropLittle>().originalPosition = circle5.transform.position;
                circle6.GetComponent<DragDropLittle>().originalPosition = circle6.transform.position;
                circle7.GetComponent<DragDropLittle>().originalPosition = circle7.transform.position;
                circle8.GetComponent<DragDropLittle>().originalPosition = circle8.transform.position;
                circle9.GetComponent<DragDropLittle>().originalPosition = circle9.transform.position;
                circle10.GetComponent<DragDropLittle>().originalPosition = circle10.transform.position;
                circle1.SetActive(true);
                circle2.SetActive(true);
                circle3.SetActive(true);
                circle4.SetActive(true);
                circle5.SetActive(true);
                circle6.SetActive(true);
                circle7.SetActive(true);
                circle8.SetActive(true);
                circle9.SetActive(true);
                circle10.SetActive(true);
                break;
        }
    }

    public void assignValuesToCircles(GameObject circleGameObject, int circleValue) {
        //Debug.Log("trying to assign value");
        if (circleValue == 0) {
            //Debug.Log("um, that value is ZERO, dude");
        } else {
            circleGameObject.GetComponent<DragDropLittle>().valueOfThisThing = circleValue;
            circleGameObject.transform.GetChild(0).GetComponent<TextMeshPro>().text = circleValue.ToString();
        }

    }

    public void ResetExtraCircles() { 
        for (int i = 0; i < 30; i++) {
            extraCirclesList[i].GetComponent<DragDropLittle>().ResetCircle();
            extraCirclesList[i].gameObject.SetActive(false);
        }
    }
    public void EmptyGarbage() {
        GameObject parent = GameObject.FindWithTag("garbage");
        foreach (Transform child in parent.transform) {
            Destroy(child.gameObject);
        }
    }




    public void setBigsInPlace(int numberOfBigs) { 
        switch (numberOfBigs) {
            case 1:
                big1.transform.position = new Vector3(0, big_RowY3, bigZvalue);
                big2.transform.position = new Vector3(0, 0, bigZvalue);
                big3.transform.position = new Vector3(0, 0, bigZvalue);
                big4.transform.position = new Vector3(0, 0, bigZvalue);
                big5.transform.position = new Vector3(0, 0, bigZvalue);
                big6.transform.position = new Vector3(0, 0, bigZvalue);
                big1.SetActive(true);
                big2.SetActive(false);
                big3.SetActive(false);
                big4.SetActive(false);
                big5.SetActive(false);
                big6.SetActive(false);
                break;
            case 2:
                big1.transform.position = new Vector3(0, big_RowY2, bigZvalue);
                big2.transform.position = new Vector3(0, big_RowY4, bigZvalue);
                big3.transform.position = new Vector3(0, 0, bigZvalue);
                big4.transform.position = new Vector3(0, 0, bigZvalue);
                big5.transform.position = new Vector3(0, 0, bigZvalue);
                big6.transform.position = new Vector3(0, 0, bigZvalue);
                big1.SetActive(true);
                big2.SetActive(true);
                big3.SetActive(false);
                big4.SetActive(false);
                big5.SetActive(false);
                big6.SetActive(false);
                break;
            case 3:
                big1.transform.position = new Vector3(0, big_RowY2, bigZvalue);
                big2.transform.position = new Vector3(big_ColX1, big_RowY4, bigZvalue);
                big3.transform.position = new Vector3(big_ColX3, big_RowY4, bigZvalue);
                big4.transform.position = new Vector3(0, 0, bigZvalue);
                big5.transform.position = new Vector3(0, 0, bigZvalue);
                big6.transform.position = new Vector3(0, 0, bigZvalue);
                big1.SetActive(true);
                big2.SetActive(true);
                big3.SetActive(true);
                big4.SetActive(false);
                big5.SetActive(false);
                big6.SetActive(false);
                break;
            case 4:
                big1.transform.position = new Vector3(big_ColX1, big_RowY2, bigZvalue);
                big2.transform.position = new Vector3(big_ColX3, big_RowY2, bigZvalue);
                big3.transform.position = new Vector3(big_ColX1, big_RowY4, bigZvalue);
                big4.transform.position = new Vector3(big_ColX3, big_RowY4, bigZvalue);
                big5.transform.position = new Vector3(0, 0, bigZvalue);
                big6.transform.position = new Vector3(0, 0, bigZvalue);
                big1.SetActive(true);
                big2.SetActive(true);
                big3.SetActive(true);
                big4.SetActive(true);
                big5.SetActive(false);
                big6.SetActive(false);
                break;
            case 5:
                big1.transform.position = new Vector3(0, big_RowY1, bigZvalue);
                big2.transform.position = new Vector3(big_ColX1, big_RowY3, bigZvalue);
                big3.transform.position = new Vector3(big_ColX3, big_RowY3, bigZvalue);
                big4.transform.position = new Vector3(big_ColX1, big_RowY5, bigZvalue);
                big5.transform.position = new Vector3(big_ColX3, big_RowY5, bigZvalue);
                big6.transform.position = new Vector3(0, 0, bigZvalue);
                big1.SetActive(true);
                big2.SetActive(true);
                big3.SetActive(true);
                big4.SetActive(true);
                big5.SetActive(true);
                big6.SetActive(false);
                break;
            case 6:
                big1.transform.position = new Vector3(big_ColX1, big_RowY1, bigZvalue);
                big2.transform.position = new Vector3(big_ColX3, big_RowY1, bigZvalue);
                big3.transform.position = new Vector3(big_ColX1, big_RowY3, bigZvalue);
                big4.transform.position = new Vector3(big_ColX3, big_RowY3, bigZvalue);
                big5.transform.position = new Vector3(big_ColX1, big_RowY5, bigZvalue);
                big6.transform.position = new Vector3(big_ColX3, big_RowY5, bigZvalue);
                big1.SetActive(true);
                big2.SetActive(true);
                big3.SetActive(true);
                big4.SetActive(true);
                big5.SetActive(true);
                big6.SetActive(true);
                break;
        }
    }

    public void assignOperatorsToBigs(GameObject bigGameObject, string operation) {
        var bigScript = bigGameObject.GetComponent<MathOperators>();
        var bigText = bigGameObject.transform.GetChild(0).GetComponent<TextMeshPro>();

        bigGameObject.transform.Find("squareRootImage").gameObject.SetActive(false);
        bigGameObject.transform.Find("CubeRoot3").gameObject.SetActive(false);
        bigGameObject.transform.Find("exponent2").gameObject.SetActive(false);
        bigGameObject.transform.Find("exponent3").gameObject.SetActive(false);
        bigGameObject.transform.Find("exponent4").gameObject.SetActive(false);

        bigScript.whatMathDoesThisThingDo = operation;
        //if (operation == "nullBaby") {
        //    Debug.Log("we caught a null baby");
        //}
        if (operation == "addition") {
            bigText.text = "+";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position - big_LeftRightMagnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position + big_LeftRightMagnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = false;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "subtraction") {
            bigText.text = "-";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position - big_LeftRightMagnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position + big_LeftRightMagnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = false;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "multiplication") {
            bigText.text = "*";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position - big_LeftRightMagnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position + big_LeftRightMagnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = false;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "division") {
            bigText.text = "/";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position - big_LeftRightMagnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position + big_LeftRightMagnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = false;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "exponent2") {
            bigText.text = "";
            bigGameObject.transform.Find("exponent2").gameObject.SetActive(true);
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + big_ExponentOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "exponent3") {
            bigText.text = "";
            bigGameObject.transform.Find("exponent3").gameObject.SetActive(true);
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + big_ExponentOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "exponent4") {
            bigText.text = "";
            bigGameObject.transform.Find("exponent4").gameObject.SetActive(true);
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + big_ExponentOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "squareRoot") {
            bigText.text = "";
            bigGameObject.transform.Find("squareRootImage").gameObject.SetActive(true);
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + big_RootOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "cubeRoot") {
            bigText.text = "";
            bigGameObject.transform.Find("squareRootImage").gameObject.SetActive(true);
            bigGameObject.transform.Find("CubeRoot3").gameObject.SetActive(true);
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + big_RootOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "split2") {
            bigText.text = "split 2";
            bigGameObject.tag = "breaker";
            bigScript.splitHowManyWays = 2;
            bigScript.spawnPoint1 = bigGameObject.transform.position + new Vector3(-0.51f, 0, 1);
            bigScript.spawnPoint2 = bigGameObject.transform.position + new Vector3(0.51f, 0, 1);
        } else if (operation == "split3") {
            bigText.text = "split 3";
            bigGameObject.tag = "breaker";
            bigScript.splitHowManyWays = 3;
            bigScript.spawnPoint1 = bigGameObject.transform.position + new Vector3(0, 0.5f, 1);
            bigScript.spawnPoint2 = bigGameObject.transform.position + new Vector3(-0.51f, -0.4f, 1);
            bigScript.spawnPoint3 = bigGameObject.transform.position + new Vector3(0.51f, -0.4f, 1);
        } else if (operation == "split4") {
            bigText.text = "split 4";
            bigGameObject.tag = "breaker";
            bigScript.splitHowManyWays = 4;
            bigScript.spawnPoint1 = bigGameObject.transform.position + new Vector3(-0.51f, 0.51f, 1);
            bigScript.spawnPoint2 = bigGameObject.transform.position + new Vector3(0.51f, 0.51f, 1);
            bigScript.spawnPoint3 = bigGameObject.transform.position + new Vector3(-0.51f, -0.51f, 1);
            bigScript.spawnPoint4 = bigGameObject.transform.position + new Vector3(0.51f, -0.51f, 1);
        } else if (operation == "split5") {
            bigText.text = "split 5";
            bigGameObject.tag = "breaker";
            bigScript.splitHowManyWays = 5;
            var xOffset = 0.87f;
            var yOffset = 0.51f;
            bigScript.spawnPoint1 = bigGameObject.transform.position + new Vector3(-xOffset, yOffset, 1);
            bigScript.spawnPoint2 = bigGameObject.transform.position + new Vector3(xOffset, yOffset, 1);
            bigScript.spawnPoint3 = bigGameObject.transform.position;
            bigScript.spawnPoint4 = bigGameObject.transform.position + new Vector3(-xOffset, -yOffset, 1);
            bigScript.spawnPoint5 = bigGameObject.transform.position + new Vector3(xOffset, -yOffset, 1);
        }




    }

    public void setGoalsInPlace(int numberOfGoals) { 
        switch (numberOfGoals) {
            case 1:
                goal1.transform.position = new Vector3(0, -5.3f, goalZvalue);
                goal2.transform.position = new Vector3(0, 0, goalZvalue);
                goal3.transform.position = new Vector3(0, 0, goalZvalue);
                goal4.transform.position = new Vector3(0, 0, goalZvalue);
                goal5.transform.position = new Vector3(0, 0, goalZvalue);
                //goal1.SetActive(true);
                //goal2.SetActive(false);
                //goal3.SetActive(false);
                //goal4.SetActive(false);
                //goal5.SetActive(false);
                for (int i = 0; i < 1; i++) {
                    goalsList[i].SetActive(true);
                    goalsList[i].GetComponent<Goal>().goalFulfilled = false;
                    goalsList[i].GetComponent<Goal>().SetToOriginalColor();
                }
                for (int i = 1; i < 5; i++) {
                    goalsList[i].SetActive(false);
                }

                //goal1.GetComponent<Goal>().goalFulfilled = false;
                //goal2.GetComponent<Goal>().goalFulfilled = false;
                //goal3.GetComponent<Goal>().goalFulfilled = false;
                //goal4.GetComponent<Goal>().goalFulfilled = false;
                //goal5.GetComponent<Goal>().goalFulfilled = false;
                //goal1.GetComponent<Goal>().SetToOriginalColor();
                break;
            case 2:
                goal1.transform.position = new Vector3(-1.3f, -5.3f, goalZvalue);
                goal2.transform.position = new Vector3(1.3f, -5.3f, goalZvalue);
                goal3.transform.position = new Vector3(0, 0, goalZvalue);
                goal4.transform.position = new Vector3(0, 0, goalZvalue);
                goal5.transform.position = new Vector3(0, 0, goalZvalue);
                for (int i = 0; i < 2; i++)
                {
                    goalsList[i].SetActive(true);
                    goalsList[i].GetComponent<Goal>().goalFulfilled = false;
                    goalsList[i].GetComponent<Goal>().SetToOriginalColor();
                }
                for (int i = 2; i < 5; i++)
                {
                    goalsList[i].SetActive(false);
                }

                //goal1.SetActive(true);
                //goal2.SetActive(true);
                //goal3.SetActive(false);
                //goal4.SetActive(false);
                //goal5.SetActive(false);
                //goal1.GetComponent<Goal>().goalFulfilled = false;
                //goal2.GetComponent<Goal>().goalFulfilled = false;
                //goal3.GetComponent<Goal>().goalFulfilled = false;
                //goal4.GetComponent<Goal>().goalFulfilled = false;
                //goal5.GetComponent<Goal>().goalFulfilled = false;
                break;
            case 3:
                goal1.transform.position = new Vector3(-1.9f, -5.3f, goalZvalue);
                goal2.transform.position = new Vector3(0, -5.3f, goalZvalue);
                goal3.transform.position = new Vector3(1.9f, -5.3f, goalZvalue);
                goal4.transform.position = new Vector3(0, 0, goalZvalue);
                goal5.transform.position = new Vector3(0, 0, goalZvalue);
                for (int i = 0; i < 3; i++)
                {
                    goalsList[i].SetActive(true);
                    goalsList[i].GetComponent<Goal>().goalFulfilled = false;
                    goalsList[i].GetComponent<Goal>().SetToOriginalColor();
                }
                for (int i = 3; i < 5; i++)
                {
                    goalsList[i].SetActive(false);
                }
                //goal1.SetActive(true);
                //goal2.SetActive(true);
                //goal3.SetActive(true);
                //goal4.SetActive(false);
                //goal5.SetActive(false);
                //goal1.GetComponent<Goal>().goalFulfilled = false;
                //goal2.GetComponent<Goal>().goalFulfilled = false;
                //goal3.GetComponent<Goal>().goalFulfilled = false;
                //goal4.GetComponent<Goal>().goalFulfilled = false;
                //goal5.GetComponent<Goal>().goalFulfilled = false;
                break;
            case 4:
                goal1.transform.position = new Vector3(-2.1f, -5.3f, goalZvalue);
                goal2.transform.position = new Vector3(-0.7f, -5.3f, goalZvalue);
                goal3.transform.position = new Vector3(0.7f, -5.3f, goalZvalue);
                goal4.transform.position = new Vector3(2.1f, -5.3f, goalZvalue);
                goal5.transform.position = new Vector3(0, 0, goalZvalue);
                for (int i = 0; i < 4; i++)
                {
                    goalsList[i].SetActive(true);
                    goalsList[i].GetComponent<Goal>().goalFulfilled = false;
                    goalsList[i].GetComponent<Goal>().SetToOriginalColor();
                }
                for (int i = 4; i < 5; i++)
                {
                    goalsList[i].SetActive(false);
                }
                //goal1.SetActive(true);
                //goal2.SetActive(true);
                //goal3.SetActive(true);
                //goal4.SetActive(true);
                //goal5.SetActive(false);
                //goal1.GetComponent<Goal>().goalFulfilled = false;
                //goal2.GetComponent<Goal>().goalFulfilled = false;
                //goal3.GetComponent<Goal>().goalFulfilled = false;
                //goal4.GetComponent<Goal>().goalFulfilled = false;
                //goal5.GetComponent<Goal>().goalFulfilled = false;
                break;
            case 5:
                goal1.transform.position = new Vector3(-2.6f, -5.3f, goalZvalue);
                goal2.transform.position = new Vector3(-1.3f, -5.3f, goalZvalue);
                goal3.transform.position = new Vector3(0, -5.3f, goalZvalue);
                goal4.transform.position = new Vector3(1.3f, -5.3f, goalZvalue);
                goal5.transform.position = new Vector3(2.6f, -5.3f, goalZvalue);
                for (int i = 0; i < 5; i++)
                {
                    goalsList[i].SetActive(true);
                    goalsList[i].GetComponent<Goal>().goalFulfilled = false;
                    goalsList[i].GetComponent<Goal>().SetToOriginalColor();
                }
                //for (int i = 1; i < 5; i++)
                //{
                //    goalsList[i].SetActive(false);
                //}
                //goal1.SetActive(true);
                //goal2.SetActive(true);
                //goal3.SetActive(true);
                //goal4.SetActive(true);
                //goal5.SetActive(true);
                //goal1.GetComponent<Goal>().goalFulfilled = false;
                //goal2.GetComponent<Goal>().goalFulfilled = false;
                //goal3.GetComponent<Goal>().goalFulfilled = false;
                //goal4.GetComponent<Goal>().goalFulfilled = false;
                //goal5.GetComponent<Goal>().goalFulfilled = false;
                break;
        }
    }

    public void assignValuesToGoals(GameObject goalGameObject, int goalValue)
    {
        //Debug.Log("trying to assign value");
        if (goalValue == 0)
        {
            //Debug.Log("um, that value is ZERO, dude");
        }
        else
        {
            goalGameObject.GetComponent<Goal>().goalNumber = goalValue;
            goalGameObject.transform.GetChild(0).GetComponent<TextMeshPro>().text = goalValue.ToString();
        }

    }

    public void setHintsInPlace(int numberOfHints) { 
        // it's already in place in Unity
    }

    public void assignTextToHints(GameObject hintGameObject, string text) {
        //var hintText = hintGameObject.transform.GetChild(0).GetComponent<TextMeshPro>();
        //hintText.text = text;
        //hintGameObject.SetActive(true);

        hint1.transform.GetChild(0).GetComponent<TextMeshPro>().text = text;
        //hint1.SetActive(true);

    }

    public void GoToLevel(int level) {
        GameManager.instance.ResetHistory();
        //DeleteInstantiatedCircles();
        ResetExtraCircles();
        ResetNormalCirclesAndBigs();
        GameManager.instance.scoreAtStartOfLevel = GameManager.instance.currentScore;
        GameManager.instance.currentLevelText.text = "Level " + (level + 1).ToString();
        GameManager.instance.currentLevelNumber = level;
        CreateLevel(level, true, false);
        EmptyGarbage();
    }

    public void RestartLevel() {
        GameManager.instance.ResetHistory();
        var currentLevel = managerOfTheGame.currentLevelNumber;
        //DeleteInstantiatedCircles();
        ResetExtraCircles();
        ResetNormalCirclesAndBigs();
        GameManager.instance.currentScore = GameManager.instance.scoreAtStartOfLevel;
        //GameManager.instance.AddPoints(0);
        //GameManager.instance.ReduceScore(2);
        CreateLevel(currentLevel, true, true);
        EmptyGarbage();
    }

    public void CreateLevel(int levelNumber, bool ifRandomThenTrue, bool isThisARestart) {
        //Debug.Log("started CreateLevel fuction");
        var levelInfo = new ArrayList();
        // grab the level info from LevelDefinitions, then parse it and start the level
        levelInfo = LevelDefinitions(levelNumber, ifRandomThenTrue);
        List<int> circles = new List<int>();
        List<string> bigs = new List<string>();
        List<int> goals = new List<int>();
        List<string> hints = new List<string>();
        int movesAllowance = 0;
        circles = (List<int>)levelInfo[0];
        bigs = (List<string>)levelInfo[1];
        goals = (List<int>)levelInfo[2];
        hints = (List<string>)levelInfo[3];
        movesAllowance = (int)levelInfo[4];
        GameManager.instance.UpdateKillFeed("  ");

        //check if the points for this level are finalized
        //      if they are, then display the score, e.g., "final: 99"
        //      if not, then display the default score, e.g., "points: 107" where 107 comes from 100 + the allowance (movesAllowance)

        if (isThisARestart == false)
        {
            //Debug.Log("this is NOT a restart");
            bool levelDone = GameManager.instance.CheckIfLevelIsCompleted(levelNumber);
            if (levelDone)
            {
                GameManager.instance.UpdateScoreToCompleted();
            }
            else
            {
                GameManager.instance.SetLevelScore((int)(100 + movesAllowance));
            }
            GameManager.instance.ShowScoreDisplay();
        } else if (isThisARestart == true) {
            //Debug.Log("this is a restart");
        }
       
        if (GameManager.instance.TestWhetherLevelPreviouslyAttempted())
        {
            //Debug.Log("this WAS previously attempted");
            if (GameManager.instance.CheckIfLevelIsCompleted(levelNumber)) { 
                // do nothing because, it WAS previously attempted, but IS COMPLETE, so we don't change the score
            } else {
                // otherwise, we know: it WAS previously attempted, but it is NOT COMPLETED
                GameManager.instance.SetLevelScore(GameManager.instance.GetScoreFromPreviousAttempt());
                GameManager.instance.MarkLevelAsNotPreviouslyAttempted();
            }

        }





        numberOfCircles = circles.Count;
        //Debug.Log("numberOfCircles: " + numberOfCircles);
        setCirclesInPlace(numberOfCircles);
        for (int i = 0; i < numberOfCircles; i++) {
            assignValuesToCircles(circlesList[i], circles[i]);
            //    try {
            //        assignValuesToCircles(circlesList[i], circles[i]);
            //    } catch (System.ArgumentOutOfRangeException) {
            //        assignValuesToCircles(circlesList[i], 0);
            //    }
        }

        numberOfBigs = bigs.Count;
        //Debug.Log("numberOfBigs: " + numberOfBigs.ToString());
        setBigsInPlace(numberOfBigs);
        for (int i = 0; i < numberOfBigs; i++) {
            assignOperatorsToBigs(bigsList[i], bigs[i]);
            //try {
            //    assignOperatorsToBigs(bigsList[i], bigs[i]);
            //} catch (System.ArgumentOutOfRangeException) {
            //    assignOperatorsToBigs(bigsList[i], "nullBaby");
            //}
        }

        numberOfGoals = goals.Count;
        setGoalsInPlace(numberOfGoals);
        for (int i = 0; i < numberOfGoals; i++) {
            assignValuesToGoals(goalsList[i], goals[i]);
            //goalsList[i].gameObject.GetComponent<Goal>().SetToOriginalColor();
        }

        numberOfHints = hints.Count;
        setHintsInPlace(numberOfHints);
        for (int i = 0; i < numberOfHints; i++) {
            assignTextToHints(hintsList[i], hints[i]);
        }
        showHintButton.SetActive(true);
        LevelUIMainMenuButton.SetActive(true);
        BackButton.SetActive(false);

        if (PlayerPrefs.GetInt("TutorialsActivated") == 1) {
            if (levelNumber == 0) {
                Level1Tutorial.SetActive(true);
            } else if (levelNumber == 1) {
                Level2Tutorial.SetActive(true);
                // turn on flashing red Restart Level button
                //RestartLevelButton.GetComponent<ColorFluxButton>().StartColorFlux();
                //FlashingTextForTutorial.GetComponent<ColorFluxText>().StartColorFlux();
            }
        }
        //GameManager.instance.UpdateKillFeed("  ");
        GameManager.instance.TakeSnapshot();

    }

    public void DeactivateTutorialAfterLevelEnd() {
        Level1Tutorial.SetActive(false);
        Level2Tutorial.SetActive(false);
    }



    public void ResetNormalCirclesAndBigs() { 
        for (int i = 0; i < 10; i++) {
            circlesList[i].GetComponent<DragDropLittle>().ResetCircle();
        }
        for (int i = 0; i < 6; i++) {
            bigsList[i].GetComponent<MathOperators>().ResetBig();
            //bigsList[i].GetComponent<ColorFlux>().PossiblyStartColorFlux();
        }
    }


    public ArrayList LevelDefinitions(int levelNumber, bool ifRandomThenTrue) {        // https://answers.unity.com/questions/524128/c-adding-multiple-elements-to-a-list-on-one-line.html
        List<int> circles = new List<int>();
        List<string> bigs = new List<string>();
        List<int> goals = new List<int>();
        List<string> hints = new List<string>();
        int numberMoves = 0;

        void AddToCirclesList(params int[] list) {
            for (int i = 0; i < list.Length; i++) {
                circles.Add(list[i]);
            }
        }
        void AddToBigsList(params string[] list) {
            for (int i = 0; i < list.Length; i++) {
                bigs.Add(list[i]);
            }
        }
        void AddToGoalsList(params int[] list) { 
            for (int i = 0; i < list.Length; i++) {
                goals.Add(list[i]);
            }
        }
        void AddHints(params string[] list) {
            for (int i = 0; i < list.Length; i++) {
                hints.Add(list[i]);
            }
        }
        void AddNumberOfMoves(int numberOfMoves) {
            numberMoves = numberOfMoves;
        }
        void RandomizeIntList(List<int> sourceList, List<int> destinationList) {
            int lengthOfSource = sourceList.Count;
            int randomNumber = Random.Range(0, lengthOfSource);
            destinationList.Add(sourceList[randomNumber]);
            sourceList.RemoveAt(randomNumber);
            if (sourceList.Count > 0) {
                RandomizeIntList(sourceList, destinationList);
            }
        }
        void RandomizeStringList(List<string> sourceList, List<string> destinationList) {
            int lengthOfSource = sourceList.Count;
            int randomNumber = Random.Range(0, lengthOfSource);
            destinationList.Add(sourceList[randomNumber]);
            sourceList.RemoveAt(randomNumber);
            if (sourceList.Count > 0) {
                RandomizeStringList(sourceList, destinationList);
            }
        }



        switch (levelNumber) {
            case 0:
                AddToCirclesList(7);
                AddToBigsList("exponent2");
                AddToGoalsList(49);
                AddHints("HINT: 7 squared = 7 * 7");
                AddNumberOfMoves(2); break;
            case 1:
                AddToCirclesList(6, 2, 3);
                AddToBigsList("division", "division");
                AddToGoalsList(1);
                AddHints("HINT: start with 6");
                AddNumberOfMoves(3); break;
            case 2:
                AddToCirclesList(5, 3);
                AddToBigsList("addition", "cubeRoot");
                AddToGoalsList(2);
                AddHints("HINT: plus first");
                AddNumberOfMoves(3); break;
            case 3:
                AddToCirclesList(9, 3, 4);
                AddToBigsList("multiplication", "subtraction");
                AddToGoalsList(23);
                AddHints("HINT: 27 - 4 = 23");
                AddNumberOfMoves(3); break;
            case 4:
                AddToCirclesList(6, 5, 4);
                AddToBigsList("exponent2", "exponent2", "exponent2");
                AddToGoalsList(36, 25, 16);
                AddHints("HINT: drink more water");
                AddNumberOfMoves(6); break;
            case 5:
                AddToCirclesList(4, 6, 5);
                AddToBigsList("exponent4", "squareRoot", "subtraction", "division");
                AddToGoalsList(2);
                AddHints("HINT: get a 10");
                AddNumberOfMoves(5); break;
            case 6:
                AddToCirclesList(10, 10, 8, 2, 8);
                AddToBigsList("addition", "division", "addition", "squareRoot");
                AddToGoalsList(4, 10);
                AddHints("HINT: the tens are redundant");
                AddNumberOfMoves(6); break;
            case 7:
                AddToCirclesList(64, 14, 2, 2);
                AddToBigsList("cubeRoot", "division", "division");
                AddToGoalsList(2, 7);
                AddHints("HINT: denominator twos");
                AddNumberOfMoves(5); break;
            case 8:
                AddToCirclesList(9, 13);
                AddToBigsList("squareRoot", "split3", "addition", "division", "addition");
                AddToGoalsList(7);
                AddHints("HINT: everyone has a plus");
                AddNumberOfMoves(6); break;
            case 9:
                AddToCirclesList(1, 3, 6, 21);
                AddToBigsList("split3", "multiplication", "multiplication", "multiplication", "addition", "multiplication");
                AddToGoalsList(21);
                AddHints("HINT: Find one-third of 21");
                AddNumberOfMoves(7); break;
            case 10:
                AddToCirclesList(5, 10, 2, 1);
                AddToBigsList("subtraction", "division", "multiplication");
                AddToGoalsList(24);
                AddHints("HINT: multiply first");
                AddNumberOfMoves(4); break;
            case 11:
                AddToCirclesList(9, 4, 3, 3, 4);
                AddToBigsList("multiplication", "addition", "division", "addition");
                AddToGoalsList(17);
                AddHints("HINT: 39");
                AddNumberOfMoves(5); break;
            case 12:
                AddToCirclesList(19, 15, 3, 5);
                AddToBigsList("multiplication", "division", "division");
                AddToGoalsList(19);
                AddHints("HINT: it's just 19");
                AddNumberOfMoves(4); break;
            case 13:
                AddToCirclesList(17, 1);
                AddToBigsList("subtraction", "split4", "division", "addition");
                AddToGoalsList(1, 8);
                AddHints("HINT: try for four fours");
                AddNumberOfMoves(6); break;
            case 14:
                AddToCirclesList(30);
                AddToBigsList("split5", "division", "subtraction", "addition", "multiplication");
                AddToGoalsList(60);
                AddHints("HINT: 6 - 1");
                AddNumberOfMoves(6); break;
            case 15:
                AddToCirclesList(21);
                AddToBigsList("split3", "multiplication", "addition", "split4", "division");
                AddToGoalsList(14, 1, 14);
                AddHints("HINT: 56");
                AddNumberOfMoves(8); break;
            case 16:
                AddToCirclesList(1, 3);
                AddToBigsList("exponent4", "addition", "split2");
                AddToGoalsList(41, 41);
                AddHints("HINT: 81");
                AddNumberOfMoves(5); break;
            case 17:
                AddToCirclesList(2, 1);
                AddToBigsList("squareRoot", "exponent4", "addition", "exponent2");
                AddToGoalsList(25);
                AddHints("HINT: exponentiate first");
                AddNumberOfMoves(5); break;
            case 18:
                AddToCirclesList(14, 4);
                AddToBigsList("split2", "division", "split2", "division", "subtraction");
                AddToGoalsList(1);
                AddHints("HINT: split the 4");
                AddNumberOfMoves(6); break;
            case 19:
                AddToCirclesList(8, 5, 6, 4);
                AddToBigsList("addition", "multiplication", "split2", "subtraction", "division");
                AddToGoalsList(17);
                AddHints("HINT: 55 - 4");
                AddNumberOfMoves(6); break;
            case 20:
                AddToCirclesList(20, 7, 1, 6);
                AddToBigsList("exponent2", "split2", "addition", "addition", "subtraction", "division");
                AddToGoalsList(1);
                AddHints("HINT: 17 is the key");
                AddNumberOfMoves(7); break;
            case 21:
                AddToCirclesList(11, 4, 1, 16);
                AddToBigsList("exponent2", "squareRoot", "subtraction", "multiplication", "split5", "addition");
                AddToGoalsList(1, 2, 1, 2, 1);
                AddHints("HINT: multiply, subtract, then split5");
                AddNumberOfMoves(11); break;
            case 22:
                AddToCirclesList(64, 4, 27, 8);
                AddToBigsList("division", "cubeRoot", "multiplication", "addition");
                AddToGoalsList(40);
                AddHints("HINT: save addition for last");
                AddNumberOfMoves(5); break;
            case 23:
                AddToCirclesList(9, 15, 1, 5);
                AddToBigsList("subtraction", "subtraction", "split2", "addition", "multiplication");
                AddToGoalsList(9);
                AddHints("HINT: try going negative");
                AddNumberOfMoves(6); break;
            case 24:
                AddToCirclesList(216, 36, 6);
                AddToBigsList("cubeRoot", "addition", "split2", "addition", "cubeRoot");
                AddToGoalsList(3, 21);
                AddHints("HINT: split 42");
                AddNumberOfMoves(7); break;
            case 25:
                AddToCirclesList(49, 7, 4);
                AddToBigsList("subtraction", "division", "split2", "exponent2", "addition", "squareRoot");
                AddToGoalsList(5);
                AddHints("HINT: impossible");
                AddNumberOfMoves(7); break;
            case 26:
                AddToCirclesList(9, 4, 12, 13);
                AddToBigsList("split3", "subtraction", "multiplication", "multiplication", "multiplication", "addition");
                AddToGoalsList(3);
                AddHints("HINT: impossible");
                AddNumberOfMoves(7); break;

            //case X:
            //    AddToCirclesList();
            //    AddToBigsList();
            //    AddToGoalsList();
            //    AddHints("HINT: impossible");
            //    AddNumberOfMoves(); break;
            default:
                break;
            // don't forget to change highestLevelNumberThatExists in the GameManager file
        }

        ArrayList toReturn = new ArrayList();
        if (ifRandomThenTrue == true) {
            List<int> randomizedCircles = new List<int>();
            RandomizeIntList(circles, randomizedCircles);
            toReturn.Add(randomizedCircles);

            List<string> randomizedBigs = new List<string>();
            RandomizeStringList(bigs, randomizedBigs);
            toReturn.Add(randomizedBigs);
            toReturn.Add(goals);
            toReturn.Add(hints);
        } else {
            toReturn.Add(circles);
            toReturn.Add(bigs);
            toReturn.Add(goals);
            toReturn.Add(hints);
        }
        toReturn.Add(numberMoves);

        return toReturn;
    }


















    public ArrayList GetCircleInfo(int circleNumber) {
        ArrayList info = new ArrayList();

        float value = circlesList[circleNumber].GetComponent<DragDropLittle>().valueOfThisThing;
        bool activeOrNot = circlesList[circleNumber].gameObject.activeSelf;
        Vector3 position = circlesList[circleNumber].transform.position;
        Vector3 originalPosition = circlesList[circleNumber].GetComponent<DragDropLittle>().originalPosition;
        int usingWhichMagnet = circlesList[circleNumber].GetComponent<DragDropLittle>().usingWhichMagnet;
        GameObject objectMagnetizedTo = circlesList[circleNumber].GetComponent<DragDropLittle>().objectMagnetizedTo;

        info.Add(value);
        info.Add(activeOrNot);
        info.Add(position);
        info.Add(originalPosition);
        info.Add(usingWhichMagnet);
        info.Add(objectMagnetizedTo);

        return info;
    }
    public ArrayList GetAllCircleInfo() {
        ArrayList allCircleInfo = new ArrayList();

        for (int i = 0; i < 10; i++) {
            ArrayList oneSingleCircle = new ArrayList();
            oneSingleCircle = GetCircleInfo(i);
            allCircleInfo.Add(oneSingleCircle);
        }
        return allCircleInfo;
    }
    public ArrayList GetExtraCircleInfo(int circleNumber) {
        ArrayList info = new ArrayList();

        float value = extraCirclesList[circleNumber].GetComponent<DragDropLittle>().valueOfThisThing;
        bool activeOrNot = extraCirclesList[circleNumber].gameObject.activeSelf;
        Vector3 position = extraCirclesList[circleNumber].transform.position;
        bool beingUsed = extraCirclesList[circleNumber].GetComponent<DragDropLittle>().isThisExtraBeingUsed;
        Vector3 originalPosition = extraCirclesList[circleNumber].GetComponent<DragDropLittle>().originalPosition;
        int usingWhichMagnet = extraCirclesList[circleNumber].GetComponent<DragDropLittle>().usingWhichMagnet;
        GameObject objectMagnetizedTo = extraCirclesList[circleNumber].GetComponent<DragDropLittle>().objectMagnetizedTo;

        info.Add(value);
        info.Add(activeOrNot);
        info.Add(position);
        info.Add(beingUsed);
        info.Add(originalPosition);
        info.Add(usingWhichMagnet);
        info.Add(objectMagnetizedTo);

        return info;
    }
    public ArrayList GetAllExtraCircleInfo() {
        ArrayList allExtraCircleInfo = new ArrayList();
        for (int i= 0; i < 30; i++) {
            ArrayList oneSingleCircle = new ArrayList();
            oneSingleCircle = GetExtraCircleInfo(i);
            allExtraCircleInfo.Add(oneSingleCircle);
        }
        return allExtraCircleInfo;
    }
    public ArrayList GetBigsInfo(int bigsNumber) {
        ArrayList info = new ArrayList();

        string whatMath = bigsList[bigsNumber].GetComponent<MathOperators>().whatMathDoesThisThingDo;
        bool activeOrNot = bigsList[bigsNumber].gameObject.activeSelf;
        Vector3 position = bigsList[bigsNumber].transform.position;
        bool magnet1occupied = bigsList[bigsNumber].GetComponent<MathOperators>().magnet1occupied;
        bool magnet2occupied = bigsList[bigsNumber].GetComponent<MathOperators>().magnet2occupied;
        float firstNumberValue = bigsList[bigsNumber].GetComponent<MathOperators>().firstNumberValue;
        float secondNumberValue = bigsList[bigsNumber].GetComponent<MathOperators>().secondNumberValue;

        info.Add(whatMath);
        info.Add(activeOrNot);
        info.Add(position);
        info.Add(magnet1occupied);
        info.Add(magnet2occupied);
        info.Add(firstNumberValue);
        info.Add(secondNumberValue);

        return info;
    }
    public ArrayList GetALLBigsInfo() {
        ArrayList allBigsInfo = new ArrayList();

        for (int i = 0; i < 6; i++) {
            ArrayList oneSingleBig = new ArrayList();
            oneSingleBig = GetBigsInfo(i);
            allBigsInfo.Add(oneSingleBig);
        }
        return allBigsInfo;
    }
    public ArrayList GetGoalInfo(int goalNumber) {
        ArrayList info = new ArrayList();

        int goalValue = goalsList[goalNumber].GetComponent<Goal>().goalNumber;
        bool goalFulfilled = goalsList[goalNumber].GetComponent<Goal>().goalFulfilled;
        bool activeOrNot = goalsList[goalNumber].gameObject.activeSelf;
        Vector3 position = goalsList[goalNumber].transform.position;
        Color goalColor = goalsList[goalNumber].GetComponent<SpriteRenderer>().color;

        info.Add(goalValue);
        info.Add(goalFulfilled);
        info.Add(activeOrNot);
        info.Add(position);
        info.Add(goalColor);

        return info;
    }
    public ArrayList GetALLGoalsInfo() {
        ArrayList allGoalsInfo = new ArrayList();

        for (int i = 0; i < 5; i++)
        {
            ArrayList oneSingleGoal = new ArrayList();
            oneSingleGoal = GetGoalInfo(i);
            allGoalsInfo.Add(oneSingleGoal);
        }
        return allGoalsInfo;
    }


    public void RestoreCircle(ArrayList info, int index) {
        float value = (float)info[0];
        bool activeOrNot = (bool)info[1];
        Vector3 position = (Vector3)info[2];
        Vector3 originalPosition = (Vector3)info[3];
        int usingWhichMagnet = (int)info[4];
        GameObject objectMagnetizedTo = (GameObject)info[5];

        circlesList[index].GetComponent<DragDropLittle>().valueOfThisThing = value;
        // have to update the TextMeshPro text, too?
        circlesList[index].gameObject.SetActive(activeOrNot);
        circlesList[index].transform.position = position;
        circlesList[index].GetComponent<DragDropLittle>().originalPosition = originalPosition;
        circlesList[index].GetComponent<DragDropLittle>().usingWhichMagnet = usingWhichMagnet;
        circlesList[index].GetComponent<DragDropLittle>().objectMagnetizedTo = objectMagnetizedTo;
    }
    public void RestoreExtraCircle(ArrayList info, int index) {
        float value = (float)info[0];
        bool activeOrNot = (bool)info[1];
        Vector3 position = (Vector3)info[2];
        bool beingUsed = (bool)info[3];
        Vector3 originalPosition = (Vector3)info[4];
        int usingWhichMagnet = (int)info[5];
        GameObject objectMagnetizedTo = (GameObject)info[6];


        extraCirclesList[index].GetComponent<DragDropLittle>().valueOfThisThing = value;
        extraCirclesList[index].gameObject.SetActive(activeOrNot);
        extraCirclesList[index].transform.position = position;
        extraCirclesList[index].GetComponent<DragDropLittle>().isThisExtraBeingUsed = beingUsed;
        extraCirclesList[index].GetComponent<DragDropLittle>().originalPosition = originalPosition;
        extraCirclesList[index].GetComponent<DragDropLittle>().usingWhichMagnet = usingWhichMagnet;
        extraCirclesList[index].GetComponent<DragDropLittle>().objectMagnetizedTo = objectMagnetizedTo;
    }
    public void RestoreBig(ArrayList info, int index) {
        string whatMath = (string)info[0];
        bool activeOrNot = (bool)info[1];
        Vector3 position = (Vector3)info[2];
        bool magnet1occupied = (bool)info[3];
        bool magnet2occupied = (bool)info[4];
        float firstNumberValue = (float)info[5];
        float secondNumberValue = (float)info[6];

        bigsList[index].GetComponent<MathOperators>().whatMathDoesThisThingDo = whatMath;
        bigsList[index].gameObject.SetActive(activeOrNot);
        bigsList[index].transform.position = position;
        bigsList[index].GetComponent<MathOperators>().magnet1occupied = magnet1occupied;
        bigsList[index].GetComponent<MathOperators>().magnet2occupied = magnet2occupied;
        bigsList[index].GetComponent<MathOperators>().firstNumberValue = firstNumberValue;
        bigsList[index].GetComponent<MathOperators>().secondNumberValue = secondNumberValue;
    }
    public void RestoreGoal(ArrayList info, int index) {
        int goalValue = (int)info[0];
        bool goalFulfilled = (bool)info[1];
        bool activeOrNot = (bool)info[2];
        Vector3 position = (Vector3)info[3];
        Color goalColor = (Color)info[4];

        goalsList[index].GetComponent<Goal>().goalNumber = goalValue;
        goalsList[index].GetComponent<Goal>().goalFulfilled = goalFulfilled;
        goalsList[index].gameObject.SetActive(activeOrNot);
        goalsList[index].transform.position = position;
        goalsList[index].GetComponent<SpriteRenderer>().color = goalColor;
    }


}
