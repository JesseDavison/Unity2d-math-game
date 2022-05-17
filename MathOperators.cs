using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathOperators : MonoBehaviour
{
    public Vector3 selfMagnet1;
    public Vector3 selfMagnet2;
    //public Vector3 selfMagnet1offset;
    //public Vector3 selfMagnet2offset;

    public bool magnet1occupied = false;
    public bool magnet2occupied = false;

    //public GameObject encounteredObject;

    public GameObject whatThisTransformsInto;      // set this in the terminal 

    public string whatMathDoesThisThingDo = "addition";     // set this in the Levels.cs script
    private float result;

    public GameObject firstNumber;
    public GameObject secondNumber;
    //public GameObject thirdNumber;
    //public GameObject fourthNumber;
    //public GameObject fifthNumber;

    public float firstNumberValue;
    public float secondNumberValue;
    //public float thirdNumberValue;
    //public float fourthNumberValue;
    //public float fifthNumberValue;

    public int splitHowManyWays;

    public Vector3 spawnPoint1;
    public Vector3 spawnPoint2;
    public Vector3 spawnPoint3;
    public Vector3 spawnPoint4;
    public Vector3 spawnPoint5;


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CompleteMath();
        }
    }

    public void ResetBig() {
        magnet1occupied = false;
        magnet2occupied = false;
        gameObject.GetComponent<ColorFlux>().PossiblyStartColorFlux();
        firstNumber = null;
        secondNumber = null;
    }

    public void CompleteMath() {
        if (magnet1occupied && magnet2occupied)
        {
            Vector3 tempVector3 = transform.position;
            tempVector3.z = 1;
            var newNum = Instantiate(whatThisTransformsInto, tempVector3, whatThisTransformsInto.transform.rotation);
            newNum.transform.SetParent(GameObject.FindGameObjectWithTag("InstantiatedCirclesParent").transform);
            switch (whatMathDoesThisThingDo)
            {
                case "addition":
                    result = firstNumberValue + secondNumberValue; break;
                case "subtraction":
                    result = firstNumberValue - secondNumberValue; break;
                case "multiplication":
                    result = firstNumberValue * secondNumberValue; break;
                case "division":
                    result = firstNumberValue / secondNumberValue; break;
                case "exponent2":
                    result = Mathf.Pow(firstNumberValue, 2); break;
                case "exponent3":
                    result = Mathf.Pow(firstNumberValue, 3); break;
                case "exponent4":
                    result = Mathf.Pow(firstNumberValue, 4); break;
                case "squareRoot":
                    result = Mathf.Pow(firstNumberValue, 0.5f); break;
                case "cubeRoot":
                    result = Mathf.Pow(firstNumberValue, 0.3333333333333333333f); break;
                case "split2":
                    result = firstNumberValue / 2; break;
                case "split3":
                    result = firstNumberValue / 3; break;
                case "split4":
                    result = firstNumberValue / 4; break;
                case "split5":
                    result = firstNumberValue / 5; break;
            }

            // if it's an integer, don't have 2 decimal places... otherwise, do have 2 decimal places
            var marginOfError = 0.001f;
            if ((result - Mathf.Floor(result)) < marginOfError)
            {
                // we want the Floor value
                //Debug.Log("We want the FLOOR value");
                newNum.GetComponent<DragDropLittle>().valueOfThisThing = Mathf.Floor(result);
                newNum.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = Mathf.Floor(result).ToString("F0");
            }
            else if ((Mathf.Ceil(result) - result) < marginOfError)
            {
                // we want the Ceiling value
                //Debug.Log("We want the CEILING value");
                newNum.GetComponent<DragDropLittle>().valueOfThisThing = Mathf.Ceil(result);
                newNum.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = Mathf.Ceil(result).ToString("F0");
            }
            else if (result % 1 == 0)
            {
                newNum.GetComponent<DragDropLittle>().valueOfThisThing = result;
                newNum.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = result.ToString("F0");
            }
            else
            {
                newNum.GetComponent<DragDropLittle>().valueOfThisThing = result;
                newNum.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = result.ToString("F2");
            }

            //// destroy child object
            //for (var i = gameObject.transform.childCount - 1; i >= 0; i--)          // https://forum.unity.com/threads/how-to-destroy-children-of-a-gameobject.759638/
            //{
            //    Object.Destroy(gameObject.transform.GetChild(i).gameObject);
            //}
            firstNumber.SetActive(false);
            if (secondNumber != null)
            {
                secondNumber.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }


}
