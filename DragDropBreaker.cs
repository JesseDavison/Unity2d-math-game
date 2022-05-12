using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragDropBreaker : MonoBehaviour
{
    //private Camera cam;
    //private Vector3 dragOffset;
    private float defaultZposition = 1;

    //private float halfXsize;
    //private float halfYsize;

    public int splitHowManyWays = 2;

    public Vector3 spawnPoint1;
    public Vector3 spawnPoint2;
    public Vector3 spawnPoint3;
    public Vector3 spawnPoint4;
    public Vector3 spawnPoint5;
    public Vector3 spawnPoint1Offset;
    public Vector3 spawnPoint2Offset;
    public Vector3 spawnPoint3Offset;
    public Vector3 spawnPoint4Offset;
    public Vector3 spawnPoint5Offset;

    //public bool magnet1occupied = false;
    //public bool magnet2occupied = false;

    public GameObject encounteredObject;

    //private Vector3 boxOnBoxPushDirection;
    //public SpriteRenderer spriteRenderer;
    //public Sprite oldSprite;
    //public Sprite newSprite;
    //public bool calculationCompleted = false;

    //Vector2 screenBounds;

    public GameObject whatThisTransformsInto;      // set this in the terminal 

    //public string whatMathDoesThisThingDo = "addition";     // set this in the terminal?
    //private float result;


    private void Awake()
    {
        //cam = Camera.main;
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //halfXsize = gameObject.GetComponent<BoxCollider2D>().bounds.size.x / 2;
        //halfYsize = gameObject.GetComponent<BoxCollider2D>().bounds.size.y / 2;

        spawnPoint1 = transform.localPosition + spawnPoint1Offset;
        spawnPoint2 = transform.localPosition + spawnPoint2Offset;
        spawnPoint3 = transform.localPosition + spawnPoint3Offset;
        spawnPoint4 = transform.localPosition + spawnPoint4Offset;
        spawnPoint5 = transform.localPosition + spawnPoint5Offset;

        defaultZposition = transform.position.z;
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

    //    spawnPoint1 = transform.localPosition + spawnPoint1Offset;
    //    spawnPoint2 = transform.localPosition + spawnPoint2Offset;
    //    spawnPoint3 = transform.localPosition + spawnPoint3Offset;
    //    spawnPoint4 = transform.localPosition + spawnPoint4Offset;

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

    //private void OnMouseOver()
    //{
    //}

    //private void OnMouseUp()
    //{
    //    if (encounteredObject != null && encounteredObject.gameObject.CompareTag("big"))
    //    {
    //        // if trying to place one box on top of another box, when mouse is released, bump the moved box to the side
    //        boxOnBoxPushDirection = (transform.position - encounteredObject.gameObject.transform.position).normalized;
    //        transform.position = encounteredObject.gameObject.transform.position + (boxOnBoxPushDirection * 2);


    //    }
    //}










}
