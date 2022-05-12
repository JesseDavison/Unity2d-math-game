using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlux : MonoBehaviour
{                                               // https://www.youtube.com/watch?v=C_f2ChrcSSM, Color Lerp in Unity, Best practice
    SpriteRenderer rendy;

    public Color startColor;
    public Color fluxColor;
    //public Color currentColor;

    [SerializeField] float lerpTime;

    Color[] myColors = new Color[2];
    int colorIndex = 1;
    float t = 0f;

    public bool readyToChange = false;

    //public float blendValue = 0;

    //public bool blendValueGoingDown = true;

    // Start is called before the first frame update
    void Awake()
    {
        lerpTime = 9;
        rendy = gameObject.GetComponent<SpriteRenderer>();
        //startColor = rendy.material.color;
        //readyToChange = false;
        startColor = new Color(0.6274f, 0.6274f, 0.6274f, 1);
        //startColor = rendy.color;         // if one of the Bigs is disabled in the Unity interface this won't work, so we call Awake() at beginning of PossiblyStartColorFlux()
        fluxColor = new Color(0.9f, 0.2f, 0.2f, 1);
        myColors[0] = startColor;
        myColors[1] = fluxColor;

    }

    // Update is called once per frame
    void Update(){
        if (readyToChange == true)
        {
            rendy.color = Color.Lerp(rendy.color, myColors[colorIndex], lerpTime * Time.deltaTime);

            t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
            if (t > 0.9f)
            {
                t = 0f;
                colorIndex++;
                colorIndex = (colorIndex >= myColors.Length) ? 0 : colorIndex;
            }
        }
    }



    public void PossiblyStartColorFlux() {
        //Debug.Log("entered PossiblyStartColorFlux function");
        //rendy = gameObject.GetComponent<SpriteRenderer>();
        //Awake();

        if (gameObject.GetComponent<MathOperators>().magnet1occupied == true && gameObject.GetComponent<MathOperators>().magnet2occupied == true) {
            readyToChange = true;

        } else {
            readyToChange = false;
            //rendy.material.color = startColor;
            //rendy.color = startColor;
            gameObject.GetComponent<SpriteRenderer>().color = startColor;
            t = 0;
            colorIndex = 1;
            //gameObject.GetComponent<Renderer>().material.color = startColor;

        }
    }

}
