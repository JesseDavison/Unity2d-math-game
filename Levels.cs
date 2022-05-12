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

    public GameObject InstantiatedCirclesParent;

    public List<string> difficultyLevels;

    public int highestLevelNumber = 3;

    int numberOfCircles;
    int numberOfBigs;
    int numberOfGoals;

    static int circleZvalue = 1;
    static int bigZvalue = 19;
    static int goalZvalue = 20;

    static float circle_TopRowY = 3.7f;
    static float circle_BotRowY = 2.4f;

    static float _5CirclesSpacingX = 1.2f;

    static float _4CirclesMidOffset = 0.7f;
    static float _4CirclesSpacingX = 1.4f;

    static float _3CirclesSpacingX = 1.5f;

    static float _2CirclesMidOffset = 0.8f;

    static float _3BigsOffset = 2.2f;
    static float big_TopRowY = 0;
    static float big_BotRowY = -2.5f;


    static Vector3 magnetOffset = new Vector3(0, 0.7f, 0);

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

    public void setBigsInPlace(int numberOfBigs) { 
        switch (numberOfBigs) {
            case 1:
                big1.transform.position = new Vector3(0, big_TopRowY, bigZvalue);
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
                big1.transform.position = new Vector3(-1.5f, big_TopRowY, bigZvalue);
                big2.transform.position = new Vector3(1.5f, big_TopRowY, bigZvalue);
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
                big1.transform.position = new Vector3(0, big_TopRowY, bigZvalue);
                big2.transform.position = new Vector3(_3BigsOffset * -1, big_BotRowY, bigZvalue);
                big3.transform.position = new Vector3(_3BigsOffset * 1, big_BotRowY, bigZvalue);
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
                big1.transform.position = new Vector3(-1.5f, big_TopRowY, bigZvalue);
                big2.transform.position = new Vector3(1.5f, big_TopRowY, bigZvalue);
                big3.transform.position = new Vector3(-1.5f, big_BotRowY, bigZvalue);
                big4.transform.position = new Vector3(1.5f, big_BotRowY, bigZvalue);
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
                big1.transform.position = new Vector3(_3BigsOffset * -1, big_TopRowY, bigZvalue);
                big2.transform.position = new Vector3(_3BigsOffset * 0, big_TopRowY, bigZvalue);
                big3.transform.position = new Vector3(_3BigsOffset * 1, big_TopRowY, bigZvalue);
                big4.transform.position = new Vector3(-1.5f, big_BotRowY, bigZvalue);
                big5.transform.position = new Vector3(1.5f, big_BotRowY, bigZvalue);
                big6.transform.position = new Vector3(0, 0, bigZvalue);
                big1.SetActive(true);
                big2.SetActive(true);
                big3.SetActive(true);
                big4.SetActive(true);
                big5.SetActive(true);
                big6.SetActive(false);
                break;
            case 6:
                big1.transform.position = new Vector3(_3BigsOffset * -1, big_TopRowY, bigZvalue);
                big2.transform.position = new Vector3(_3BigsOffset * 0, big_TopRowY, bigZvalue);
                big3.transform.position = new Vector3(_3BigsOffset * 1, big_TopRowY, bigZvalue);
                big4.transform.position = new Vector3(_3BigsOffset * -1, big_BotRowY, bigZvalue);
                big5.transform.position = new Vector3(_3BigsOffset * 0, big_BotRowY, bigZvalue);
                big6.transform.position = new Vector3(_3BigsOffset * 1, big_BotRowY, bigZvalue);
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

        bigScript.whatMathDoesThisThingDo = operation;
        //if (operation == "nullBaby") {
        //    Debug.Log("we caught a null baby");
        //}
        if (operation == "addition") {
            bigText.text = "+";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = false;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "subtraction") {
            bigText.text = "-";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = false;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "multiplication") {
            bigText.text = "*";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = false;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "division") {
            bigText.text = "/";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = false;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "exponent2") {
            bigText.text = "^2";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "exponent3") {
            bigText.text = "^3";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "exponent4") {
            bigText.text = "^4";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "squareRoot") {
            bigText.text = "^(1/2)";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "cubeRoot") {
            bigText.text = "^(1/3)";
            bigGameObject.tag = "big";
            bigScript.selfMagnet1 = bigGameObject.transform.position + magnetOffset;
            bigScript.selfMagnet2 = bigGameObject.transform.position - magnetOffset;
            bigScript.magnet1occupied = false;
            bigScript.magnet2occupied = true;
            bigScript.spawnPoint1 = bigGameObject.transform.position;
        } else if (operation == "split2") {
            bigText.text = "split 2";
            bigGameObject.tag = "breaker";
            bigScript.splitHowManyWays = 2;
            bigScript.spawnPoint1 = bigGameObject.transform.position + new Vector3(-0.5f, 0, 1);
            bigScript.spawnPoint2 = bigGameObject.transform.position + new Vector3(0.5f, 0, 1);
        } else if (operation == "split3") {
            bigText.text = "split 3";
            bigGameObject.tag = "breaker";
            bigScript.splitHowManyWays = 3;
            bigScript.spawnPoint1 = bigGameObject.transform.position + new Vector3(0, 0.5f, 1);
            bigScript.spawnPoint2 = bigGameObject.transform.position + new Vector3(-0.5f, -0.4f, 1);
            bigScript.spawnPoint3 = bigGameObject.transform.position + new Vector3(0.5f, -0.4f, 1);
        } else if (operation == "split4") {
            bigText.text = "split 4";
            bigGameObject.tag = "breaker";
            bigScript.splitHowManyWays = 4;
            bigScript.spawnPoint1 = bigGameObject.transform.position + new Vector3(-0.5f, 0.5f, 1);
            bigScript.spawnPoint2 = bigGameObject.transform.position + new Vector3(0.5f, 0.5f, 1);
            bigScript.spawnPoint3 = bigGameObject.transform.position + new Vector3(-0.5f, -0.5f, 1);
            bigScript.spawnPoint4 = bigGameObject.transform.position + new Vector3(0.5f, -0.5f, 1);
        } else if (operation == "split5") {
            bigText.text = "split 5";
            bigGameObject.tag = "breaker";
            bigScript.splitHowManyWays = 5;
            bigScript.spawnPoint1 = bigGameObject.transform.position + new Vector3(-0.5f, 0.9f, 1);
            bigScript.spawnPoint2 = bigGameObject.transform.position + new Vector3(0.5f, 0.9f, 1);
            bigScript.spawnPoint3 = bigGameObject.transform.position;
            bigScript.spawnPoint4 = bigGameObject.transform.position + new Vector3(-0.5f, -0.9f, 1);
            bigScript.spawnPoint5 = bigGameObject.transform.position + new Vector3(0.5f, -0.9f, 1);
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

    public void GoToLevel(int level) {
        DeleteInstantiatedCircles();
        ResetNormalCirclesAndBigs();
        GameManager.instance.scoreAtStartOfLevel = GameManager.instance.currentScore;
        GameManager.instance.currentLevelText.text = "Level " + (level + 1).ToString();
        GameManager.instance.currentLevelNumber = level;
        CreateLevel(level);
    }

    public void RestartLevel() {
        var currentLevel = managerOfTheGame.currentLevelNumber;
        DeleteInstantiatedCircles();
        ResetNormalCirclesAndBigs();
        GameManager.instance.currentScore = GameManager.instance.scoreAtStartOfLevel;
        //GameManager.instance.AddPoints(0);
        CreateLevel(currentLevel);
    }

    public void CreateLevel(int levelNumber) {
        //Debug.Log("started CreateLevel fuction");
        var levelInfo = new ArrayList();
        // grab the level info from LevelDefinitions, then parse it and start the level
        levelInfo = LevelDefinitions(levelNumber);
        List<int> circles = new List<int>();
        List<string> bigs = new List<string>();
        List<int> goals = new List<int>();
        circles = (List<int>)levelInfo[0];
        bigs = (List<string>)levelInfo[1];
        goals = (List<int>)levelInfo[2];

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
    }

    public void DeleteInstantiatedCircles() {
        for (var i = InstantiatedCirclesParent.gameObject.transform.childCount - 1; i >= 0; i--)          // https://forum.unity.com/threads/how-to-destroy-children-of-a-gameobject.759638/
        {
            Object.Destroy(InstantiatedCirclesParent.gameObject.transform.GetChild(i).gameObject);
        }
    }

    public void ResetNormalCirclesAndBigs() { 
        for (int i = 0; i < 10; i++) {
            circlesList[i].GetComponent<DragDropLittle>().ResetCircle();
        }
        for (int i = 0; i < 6; i++) {
            bigsList[i].GetComponent<MathOperators>().ResetBig();
        }
    }


    public ArrayList LevelDefinitions(int levelNumber) {        // https://answers.unity.com/questions/524128/c-adding-multiple-elements-to-a-list-on-one-line.html
        List<int> circles = new List<int>();
        List<string> bigs = new List<string>();
        List<int> goals = new List<int>();

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


        switch (levelNumber) {
            case 0:
                AddToCirclesList(7);
                AddToBigsList("exponent2");
                AddToGoalsList(49); break;
            case 1:
                AddToCirclesList(6, 2);
                AddToBigsList("division", "split3");
                AddToGoalsList(1, 1, 1); break;
            case 2:
                AddToCirclesList(6, 5, 4, 3);
                AddToBigsList("exponent2", "exponent2", "exponent2", "exponent2");
                AddToGoalsList(36, 25, 16, 9); break;
            case 3:
                AddToCirclesList(10, 10, 2, 2, 2);
                AddToBigsList("addition", "division", "addition", "squareRoot");
                AddToGoalsList(2, 10); break;
            case 4:
                AddToCirclesList(64, 7, 7, 14, 2);
                AddToBigsList("cubeRoot", "division", "split2");
                AddToGoalsList(7, 2, 7, 2, 7); break;
            case 5:
                AddToCirclesList(9, 13);
                AddToBigsList("squareRoot", "split3", "addition", "division", "addition");
                AddToGoalsList(7); break;

            //case X:
            //    AddToCirclesList();
            //    AddToBigsList();
            //    AddToGoalsList(); break;


            default:
                // ran out of levels, so go back to the last level that exists

                break;
            // don't forget to change highestLevelNumberThatExists in the GameManager file
        }


        ArrayList toReturn = new ArrayList();
        toReturn.Add(circles);
        toReturn.Add(bigs);
        toReturn.Add(goals);
        toReturn.Add(levelNumber);

        return toReturn;
    }


}
