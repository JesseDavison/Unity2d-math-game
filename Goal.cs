using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{

    public int goalNumber = 7;

    public bool goalFulfilled = false;

    //private Camera cam;
    //Vector2 screenBounds;
    
    public Color originalColor;


    private void Awake()
    {
        //cam = Camera.main;
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // as soon as this object exists, set its TMPro text to be valueOfThisThing .... now we don't have to manually set it every time
        gameObject.transform.GetChild(0).GetComponent<TextMeshPro>().text = goalNumber.ToString();

        originalColor = gameObject.GetComponent<SpriteRenderer>().color;

    }

    public void SetToOriginalColor() {
        gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }




    }
