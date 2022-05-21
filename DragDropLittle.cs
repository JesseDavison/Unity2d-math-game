using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragDropLittle : MonoBehaviour
{
    public GameManager gameManager;

    public float valueOfThisThing;
    public bool isThisAnExtraCircle = false;
    public bool isThisExtraBeingUsed = false;

    private float radius;

    public Vector3 originalPosition;

    private Camera cam;
    public Vector3 dragOffset;
    private float defaultZposition = 1;
    private float zPositionWhileMoving = 0;

    public Vector3 targetMagnet1;
    public Vector3 targetMagnet2;
    public bool targetMagnetDiscovered = false;

    public GameObject encounteredObject;
    public GameObject objectMagnetizedTo;

    //private Vector3 circleOnCirclePushDirection;

    public int usingWhichMagnet;

    Vector2 screenBounds;       // this one works best i think, https://forum.unity.com/threads/trying-to-clamp-player-to-stay-on-screen.634264/

    //public GameObject whatThisTransformsInto;

    public Color goalColor;

    private const float DOUBLE_CLICK_TIME = 0.2f;
    private float lastClickTime;


    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    private void Awake()
    {
        cam = Camera.main;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // as soon as this object exists, set its TMPro text to be valueOfThisThing .... now we don't have to manually set it every time
        gameObject.transform.GetChild(0).GetComponent<TextMeshPro>().text = valueOfThisThing.ToString();
        radius = gameObject.GetComponent<CircleCollider2D>().bounds.size.x / 2;
        defaultZposition = transform.position.z;
        originalPosition = transform.position;

    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePosition();
        //gameObject.transform.SetParent(null);

        // if the circle is already sitting on a magnet, then mark that magnet as NOT occupied
        if (usingWhichMagnet == 1)
        {
            encounteredObject = objectMagnetizedTo;
            //objectMagnetizedTo.GetComponent<MathOperators>().magnet1occupied = false;
            objectMagnetizedTo.GetComponent<MathOperators>().magnet1occupied = false;
            //encounteredObject.GetComponent<ColorFlux>().PossiblyStartColorFlux();
            objectMagnetizedTo.GetComponent<MathOperators>().firstNumber = null;
            objectMagnetizedTo.GetComponent<MathOperators>().firstNumberValue = -1;
        }
        else if (usingWhichMagnet == 2)
        {
            encounteredObject = objectMagnetizedTo;
            objectMagnetizedTo.GetComponent<MathOperators>().magnet2occupied = false;
            //encounteredObject.GetComponent<ColorFlux>().PossiblyStartColorFlux();
            objectMagnetizedTo.GetComponent<MathOperators>().secondNumber = null;
            objectMagnetizedTo.GetComponent<MathOperators>().secondNumberValue = -1;
        }
        usingWhichMagnet = 0;
        objectMagnetizedTo = null;
    }
    
    Vector3 GetMousePosition()
    {
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = zPositionWhileMoving;
        return mousePosition;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;       // https://www.youtube.com/watch?v=9pKXXNgCgq8

            if (timeSinceLastClick <= DOUBLE_CLICK_TIME)
            {
                // do double click actions here
                GameObject[] goals = GameObject.FindGameObjectsWithTag("goal");
                foreach (GameObject goal in goals)
                {
                    if (goal.GetComponent<Goal>().goalNumber == valueOfThisThing && goal.GetComponent<Goal>().goalFulfilled == false)
                    {
                        //transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, Time.deltaTime * 2);

                        // destroy the circle and change the color of the goal to reflect the fact that it's been fulfilled
                        goal.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.1f, 0.1f, 1f);
                        // also, make this goal unable to interact with anything
                        goal.GetComponent<Goal>().goalFulfilled = true;
                        //GameManager.instance.AddPoints(1);
                        //Destroy(gameObject);
                        gameObject.SetActive(false);
                        GameManager.instance.backButton.SetActive(true);
                        GameManager.instance.ReduceScore(1);
                        GameManager.instance.ContributeToKillFeed("goal", goal.GetComponent<Goal>().goalNumber, 0, 0);
                        gameManager.checkIfLevelIsOver();
                        GameManager.instance.TakeSnapshot();



                        break;
                    }
                }
            }
            else
            {
                // do normal click actions here
            }
            lastClickTime = Time.time;
        }
    }

    public GameObject GrabExtraCircle() {
        List<GameObject> listOfExtraCircles = GameManager.instance.GetComponent<GameManager>().repOfLevels.GetComponent<Levels>().extraCirclesList;
        GameObject extraCircleToUse = new GameObject();
        GameObject parent = GameObject.FindWithTag("garbage");
        extraCircleToUse.transform.SetParent(parent.transform);
        for (int i = 0; i < 30; i++)
        {
            if (listOfExtraCircles[i].GetComponent<DragDropLittle>().isThisExtraBeingUsed == false)
            {
                extraCircleToUse = listOfExtraCircles[i];
                listOfExtraCircles[i].GetComponent<DragDropLittle>().isThisExtraBeingUsed = true;
                break;
            }
        }
        extraCircleToUse.gameObject.SetActive(true);

        return extraCircleToUse;
    }


    private void OnMouseUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, defaultZposition);

        if (encounteredObject != null && encounteredObject.gameObject.CompareTag("big"))
        {
            if (encounteredObject.GetComponent<MathOperators>().magnet1occupied == false)
            {
                Vector3 tempVector3 = encounteredObject.GetComponent<MathOperators>().selfMagnet1;
                tempVector3.z = defaultZposition;
                transform.position = tempVector3;
                encounteredObject.GetComponent<MathOperators>().magnet1occupied = true;
                //encounteredObject.GetComponent<ColorFlux>().PossiblyStartColorFlux();
                usingWhichMagnet = 1;
                objectMagnetizedTo = encounteredObject;
                // now, set the circle's number value into the Big object
                encounteredObject.GetComponent<MathOperators>().firstNumber = gameObject;
                encounteredObject.GetComponent<MathOperators>().firstNumberValue = valueOfThisThing;
                encounteredObject.GetComponent<SpriteRenderer>().color = new Color(0.6274f, 0.6274f, 0.6274f, 1);
                encounteredObject.GetComponent<MathOperators>().CompleteMath();
                //GameManager.instance.TakeSnapshot();
            }
            else if (encounteredObject.GetComponent<MathOperators>().magnet2occupied == false)
            {
                Vector3 tempVector3 = encounteredObject.GetComponent<MathOperators>().selfMagnet2;
                tempVector3.z = defaultZposition;
                transform.position = tempVector3;
                encounteredObject.GetComponent<MathOperators>().magnet2occupied = true;
                //encounteredObject.GetComponent<ColorFlux>().PossiblyStartColorFlux();
                usingWhichMagnet = 2;
                objectMagnetizedTo = encounteredObject;
                encounteredObject.GetComponent<MathOperators>().secondNumber = gameObject;
                encounteredObject.GetComponent<MathOperators>().secondNumberValue = valueOfThisThing;
                encounteredObject.GetComponent<SpriteRenderer>().color = new Color(0.6274f, 0.6274f, 0.6274f, 1);
                encounteredObject.GetComponent<MathOperators>().CompleteMath();
                //GameManager.instance.TakeSnapshot();
            }
            else
            {
                transform.position = originalPosition;
            }
        }
        else if (encounteredObject != null && encounteredObject.gameObject.CompareTag("breaker"))
        {
            var spawnPoint1 = encounteredObject.GetComponent<MathOperators>().spawnPoint1;
            spawnPoint1.z = defaultZposition;
            var spawnPoint2 = encounteredObject.GetComponent<MathOperators>().spawnPoint2;
            spawnPoint2.z = defaultZposition;
            var spawnPoint3 = encounteredObject.GetComponent<MathOperators>().spawnPoint3;
            spawnPoint3.z = defaultZposition;
            var spawnPoint4 = encounteredObject.GetComponent<MathOperators>().spawnPoint4;
            spawnPoint4.z = defaultZposition;
            var spawnPoint5 = encounteredObject.GetComponent<MathOperators>().spawnPoint5;
            spawnPoint5.z = defaultZposition;

            int splitAmount = encounteredObject.GetComponent<MathOperators>().splitHowManyWays;

            // destroy the original objects
            //Destroy(encounteredObject.gameObject);
            encounteredObject.gameObject.SetActive(false);
            //Destroy(gameObject);        // destroy original number

            if (splitAmount == 2)
            {
                var newNum = valueOfThisThing / 2.0f;

                GameObject extraCircle1 = GrabExtraCircle();
                extraCircle1.transform.position = spawnPoint1;
                extraCircle1.GetComponent<DragDropLittle>().originalPosition = spawnPoint1;

                GameObject extraCircle2 = GrabExtraCircle();
                extraCircle2.transform.position = spawnPoint2;
                extraCircle2.GetComponent<DragDropLittle>().originalPosition = spawnPoint2;

                extraCircle1.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle2.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                //newNum1.GetComponent<DragDropLittle>().encounteredObject = null;
                if (newNum % 1 == 0)
                {
                    extraCircle1.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle2.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                }
                else
                {
                    extraCircle1.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle2.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                }
            }
            else if (splitAmount == 3)
            {
                var newNum = valueOfThisThing / 3.0f;

                GameObject extraCircle1 = GrabExtraCircle();
                extraCircle1.transform.position = spawnPoint1;
                extraCircle1.GetComponent<DragDropLittle>().originalPosition = spawnPoint1;

                GameObject extraCircle2 = GrabExtraCircle();
                extraCircle2.transform.position = spawnPoint2;
                extraCircle2.GetComponent<DragDropLittle>().originalPosition = spawnPoint2;

                GameObject extraCircle3 = GrabExtraCircle();
                extraCircle3.transform.position = spawnPoint3;
                extraCircle3.GetComponent<DragDropLittle>().originalPosition = spawnPoint3;

                extraCircle1.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle2.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle3.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                if (newNum % 1 == 0)
                {
                    extraCircle1.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle2.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle3.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                }
                else
                {
                    extraCircle1.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle2.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle3.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                }
            }
            else if (splitAmount == 4)
            {
                var newNum = valueOfThisThing / 4.0f;

                GameObject extraCircle1 = GrabExtraCircle();
                extraCircle1.transform.position = spawnPoint1;
                extraCircle1.GetComponent<DragDropLittle>().originalPosition = spawnPoint1;

                GameObject extraCircle2 = GrabExtraCircle();
                extraCircle2.transform.position = spawnPoint2;
                extraCircle2.GetComponent<DragDropLittle>().originalPosition = spawnPoint2;

                GameObject extraCircle3 = GrabExtraCircle();
                extraCircle3.transform.position = spawnPoint3;
                extraCircle3.GetComponent<DragDropLittle>().originalPosition = spawnPoint3;

                GameObject extraCircle4 = GrabExtraCircle();
                extraCircle4.transform.position = spawnPoint4;
                extraCircle4.GetComponent<DragDropLittle>().originalPosition = spawnPoint4;

                extraCircle1.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle2.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle3.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle4.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                if (newNum % 1 == 0)
                {
                    extraCircle1.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle2.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle3.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle4.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                }
                else
                {
                    extraCircle1.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle2.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle3.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle4.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                }
            }
            else if (splitAmount == 5)
            {
                var newNum = valueOfThisThing / 5.0f;

                GameObject extraCircle1 = GrabExtraCircle();
                extraCircle1.transform.position = spawnPoint1;
                extraCircle1.GetComponent<DragDropLittle>().originalPosition = spawnPoint1;

                GameObject extraCircle2 = GrabExtraCircle();
                extraCircle2.transform.position = spawnPoint2;
                extraCircle2.GetComponent<DragDropLittle>().originalPosition = spawnPoint2;

                GameObject extraCircle3 = GrabExtraCircle();
                extraCircle3.transform.position = spawnPoint3;
                extraCircle3.GetComponent<DragDropLittle>().originalPosition = spawnPoint3;

                GameObject extraCircle4 = GrabExtraCircle();
                extraCircle4.transform.position = spawnPoint4;
                extraCircle4.GetComponent<DragDropLittle>().originalPosition = spawnPoint4;

                GameObject extraCircle5 = GrabExtraCircle();
                extraCircle5.transform.position = spawnPoint5;
                extraCircle5.GetComponent<DragDropLittle>().originalPosition = spawnPoint5;

                extraCircle1.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle2.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle3.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle4.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                extraCircle5.GetComponent<DragDropLittle>().valueOfThisThing = newNum;
                if (newNum % 1 == 0)
                {
                    extraCircle1.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle2.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle3.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle4.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                    extraCircle5.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F0");
                }
                else
                {
                    extraCircle1.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle2.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle3.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle4.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                    extraCircle5.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = newNum.ToString("F2");
                }
            }


            //// destroy the original objects
            ////Destroy(encounteredObject.gameObject);
            //encounteredObject.gameObject.SetActive(false);
            ////Destroy(gameObject);        // destroy original number
            //gameObject.SetActive(false);
            gameObject.SetActive(false);
            GameManager.instance.ContributeToKillFeed("split", splitAmount, valueOfThisThing, 0);
            GameManager.instance.TakeSnapshot();
            GameManager.instance.ReduceScore(1);
            GameManager.instance.backButton.SetActive(true);

        }
        else if (encounteredObject != null && encounteredObject.gameObject.CompareTag("goal"))
        {
            var goalNumber = encounteredObject.GetComponent<Goal>().goalNumber;
            if (valueOfThisThing == goalNumber && encounteredObject.GetComponent<Goal>().goalFulfilled == false)
            {
                encounteredObject.GetComponent<Goal>().MarkGoalAsFulfilled();                
                gameObject.SetActive(false);
                GameManager.instance.ContributeToKillFeed("goal", goalNumber, 0, 0);
                GameManager.instance.TakeSnapshot();
                GameManager.instance.ReduceScore(1);
                //GameManager.instance.backButton.SetActive(true);
            }
            else if (encounteredObject.GetComponent<Goal>().goalFulfilled == true)
            {
                // bump the circle up, to just above the goal
                Vector3 tempVector3 = encounteredObject.transform.position;
                tempVector3.z = defaultZposition;
                transform.position = tempVector3 + Vector3.up * 1.2f;
            }
            else
            {
                // bump the circle up, to just above the goal
                Vector3 tempVector3 = encounteredObject.transform.position;
                tempVector3.z = defaultZposition;
                transform.position = tempVector3 + Vector3.up * 1.2f;
            }

            // check if the level is over
            gameManager.checkIfLevelIsOver();
        }
        else
        {
            transform.position = originalPosition;
        }
    }

    void OnMouseDrag()
    {
        //Vector3 viewPos = cam.WorldToViewportPoint(transform.position);     // https://answers.unity.com/questions/799656/how-to-keep-an-object-within-the-camera-view.html
        //viewPos.x = Mathf.Clamp01(viewPos.x);
        //viewPos.y = Mathf.Clamp01(viewPos.y);
        //transform.position = cam.ViewportToWorldPoint(viewPos);

        //transform.position = Vector3.MoveTowards(transform.position, GetMousePosition() + dragOffset, dragSpeed * Time.deltaTime);


        //screenPos = cam.WorldToScreenPoint(transform.position);  // https://forum.unity.com/threads/help-stopping-player-from-moving-off-screen.86147/


        transform.position = GetMousePosition() + dragOffset;
        //transform.position = new Vector3(transform.position.x, transform.position.y, defaultZposition);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -screenBounds.x + radius, screenBounds.x - radius),
            Mathf.Clamp(transform.position.y, -screenBounds.y + radius, screenBounds.y - radius),
            defaultZposition);

        //gameObject.transform.SetParent(null);

        if (usingWhichMagnet == 1)
        {
            objectMagnetizedTo.GetComponent<MathOperators>().magnet1occupied = false;
        }
        else if (usingWhichMagnet == 2)
        {
            objectMagnetizedTo.GetComponent<MathOperators>().magnet2occupied = false;
        }
        usingWhichMagnet = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {           //  https://stackoverflow.com/questions/39940020/are-there-alternatives-to-collision-detection-in-unity3d
        //Debug.Log("We HIT HIT HIT something: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("little") && collision.gameObject.GetComponent<DragDropLittle>().targetMagnetDiscovered == false)
        {
            //encounteredObject = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("big"))
        {
            targetMagnetDiscovered = true;
            targetMagnet1 = collision.gameObject.GetComponent<MathOperators>().selfMagnet1;
            targetMagnet2 = collision.gameObject.GetComponent<MathOperators>().selfMagnet2;

            encounteredObject = collision.gameObject;
            if (collision.GetComponent<MathOperators>().magnet1occupied == false || collision.GetComponent<MathOperators>().magnet2occupied == false)
            {
                collision.GetComponent<SpriteRenderer>().color = new Color(0.35f, 0.35f, 0.35f, 1);
            }


        }
        else if (collision.gameObject.CompareTag("breaker"))
        {
            encounteredObject = collision.gameObject;
            collision.GetComponent<SpriteRenderer>().color = new Color(0.35f, 0.35f, 0.35f, 1);
        }
        else if (collision.gameObject.CompareTag("goal") && collision.GetComponent<Goal>().goalFulfilled == false)
        {
            encounteredObject = collision.gameObject;
            // change the color of the goal slightly...     as of May 4 2022 it starts at 0.6961, 0.7140, 0.9905, 1
            // first, save the current color
            goalColor = encounteredObject.GetComponent<SpriteRenderer>().color;
            encounteredObject.GetComponent<SpriteRenderer>().color = new Color(0.35f, 0, 0, 1);

        }
        else if (collision.gameObject.CompareTag("goal") && collision.GetComponent<Goal>().goalFulfilled == true)
        {
            encounteredObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("WE LEFT LEFT LEFT");
        if (collision.gameObject.CompareTag("big"))
        {
            targetMagnetDiscovered = false;
            targetMagnet1 = Vector3.zero;
            targetMagnet2 = Vector3.zero;

            collision.GetComponent<SpriteRenderer>().color = new Color(0.6274f, 0.6274f, 0.6274f, 1);
            encounteredObject = null;
        }
        else if (collision.gameObject.CompareTag("breaker"))
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.6274f, 0.6274f, 0.6274f, 1);
            encounteredObject = null;
        }
        else if (collision.gameObject.CompareTag("goal") && collision.GetComponent<Goal>().goalFulfilled == false)
        {
            collision.GetComponent<SpriteRenderer>().color = goalColor;
            encounteredObject = null;
        } 
        else if (collision.gameObject.CompareTag("little")) 
        { 

        }
        //gameObject.transform.SetParent(null);
        //encounteredObject = null;

    }

    public void ResetCircle() {
        //originalPosition = Vector3.zero;
        targetMagnetDiscovered = false;
        encounteredObject = null;
        objectMagnetizedTo = null;
        usingWhichMagnet = 0;
        if (isThisAnExtraCircle) {
            isThisExtraBeingUsed = false;
        }
}


}
