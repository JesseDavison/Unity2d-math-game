using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragDropBig : MonoBehaviour
{
    //private Camera cam;
    //private Vector3 dragOffset;
    //private float defaultZposition = 1;
    //private int dragSpeed = 55;

    //private float halfXsize;
    //private float halfYsize;

    public Vector3 selfMagnet1;
    public Vector3 selfMagnet2;
    public Vector3 selfMagnet1offset;
    public Vector3 selfMagnet2offset;

    public bool magnet1occupied = false;
    public bool magnet2occupied = false;

    public GameObject encounteredObject;

    //private Vector3 boxOnBoxPushDirection;
    //public SpriteRenderer spriteRenderer;
    //public Sprite oldSprite;
    //public Sprite newSprite;
    public bool calculationCompleted = false;

    //Vector2 screenBounds;

    public GameObject whatThisTransformsInto;      // set this in the terminal 

    public string whatMathDoesThisThingDo = "addition";     // set this in the terminal?
    private float result;

    public GameObject firstNumber;
    public GameObject secondNumber;
    
    public float firstNumberValue;
    public float secondNumberValue;


    private void Awake()
    {
        //cam = Camera.main;
        selfMagnet1 = transform.localPosition + selfMagnet1offset;
        selfMagnet2 = transform.localPosition + selfMagnet2offset;
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //halfXsize = gameObject.GetComponent<BoxCollider2D>().bounds.size.x / 2;
        //halfYsize = gameObject.GetComponent<BoxCollider2D>().bounds.size.y / 2;

        //defaultZposition = transform.position.z;
    }

    //private void OnMouseDown()
    //{
    //    dragOffset = transform.position - GetMousePosition();
    //    gameObject.transform.SetParent(null);
    //}

    //Vector3 GetMousePosition()
    //{
    //    var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    //    mousePosition.z = defaultZposition;
    //    return mousePosition;
    //}

    //void OnMouseDrag()
    //{
    //    //Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
    //    //transform.position = Vector3.MoveTowards(transform.position, GetMousePosition() + dragOffset, dragSpeed * Time.deltaTime);
    //    transform.position = GetMousePosition() + dragOffset;
    //    transform.position = new Vector3(
    //        Mathf.Clamp(transform.position.x, -screenBounds.x + halfXsize, screenBounds.x - halfXsize),
    //        Mathf.Clamp(transform.position.y, -screenBounds.y + halfYsize, screenBounds.y - halfYsize),
    //        defaultZposition);

    //    selfMagnet1 = transform.position + selfMagnet1offset;
    //    selfMagnet2 = transform.position + selfMagnet2offset;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {           //  https://stackoverflow.com/questions/39940020/are-there-alternatives-to-collision-detection-in-unity3d
        //Debug.Log("We HIT HIT HIT something: " + collision.gameObject.name);
        encounteredObject = collision.gameObject;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("WE LEFT LEFT LEFT");
        encounteredObject = null;
    }

    private void OnMouseOver()
    {
        //// if the number of children is 1, then the magnets are NOT occupied
        //if (gameObject.transform.childCount == 2 && magnet1occupied) {
        //    magnet2occupied = false;
        //} else if (gameObject.transform.childCount == 2 && magnet2occupied) {
        //    magnet1occupied = false;
        //} else if (gameObject.transform.childCount == 1) {
        //    magnet1occupied = false;
        //    magnet2occupied = false;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            if (magnet1occupied && magnet2occupied && calculationCompleted == false)
            {
                // "activate" the addition and turn the whole thing into a new number circle
                //oldSprite = spriteRenderer.sprite;
                //spriteRenderer.sprite = newSprite;
                calculationCompleted = true;
                // note: the 0th child of the "big" object is the object that has the TMPro component, so we skip it below
                //float numberFirst = transform.GetChild(1).GetComponent<DragDropLittle>().valueOfThisThing;    //  https://forum.unity.com/threads/how-to-get-access-to-the-variables-of-the-child.311351/
                //float numberSecond = transform.GetChild(2).GetComponent<DragDropLittle>().valueOfThisThing;

                // DESTROY all 3 objects and create a new circle object with the new number
                Vector3 tempVector3 = transform.position;
                tempVector3.z = 1;
                var newNum = Instantiate(whatThisTransformsInto, tempVector3, whatThisTransformsInto.transform.rotation);

                switch (whatMathDoesThisThingDo) {
                    case "addition":
                        result = firstNumberValue + secondNumberValue; break;
                    case "subtraction":
                        result = firstNumberValue - secondNumberValue; break;
                    case "multiplication":
                        result = firstNumberValue * secondNumberValue; break;
                    case "division":
                        result = firstNumberValue / secondNumberValue; break;
                    case "exponent":
                        result = Mathf.Pow(firstNumberValue, secondNumberValue); break;
                    case "inverseExponent":
                        result = Mathf.Pow(firstNumberValue, (1 / secondNumberValue)); break;
                }

                // if it's an integer, don't have 2 decimal places... otherwise, do have 2 decimal places
                if (result % 1 == 0) {
                    newNum.GetComponent<DragDropLittle>().valueOfThisThing = result;
                    newNum.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = result.ToString("F0");
                } else {
                    newNum.GetComponent<DragDropLittle>().valueOfThisThing = result;
                    newNum.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = result.ToString("F2");
                }

                // destroy child object
                for (var i = gameObject.transform.childCount - 1; i >= 0; i--)          // https://forum.unity.com/threads/how-to-destroy-children-of-a-gameobject.759638/
                {
                    Object.Destroy(gameObject.transform.GetChild(i).gameObject);
                }
                // destroy firstNumber & secondNumber
                Destroy(firstNumber);
                Destroy(secondNumber);
                
                // destroy original object
                Destroy(gameObject);


            }
            else if (calculationCompleted == true)
            {
                // *********** change it back???
                //spriteRenderer.sprite = oldSprite;
                //calculationCompleted = false;
            }
        }
    }

    //private void OnMouseUp()
    //{
    //    if (encounteredObject != null && encounteredObject.gameObject.CompareTag("big")) {
    //        // if trying to place one box on top of another box, when mouse is released, bump the moved box to the side
    //        boxOnBoxPushDirection = (transform.position - encounteredObject.gameObject.transform.position).normalized;
    //        transform.position = encounteredObject.gameObject.transform.position + (boxOnBoxPushDirection * 2);


    //    }
    //}










}
