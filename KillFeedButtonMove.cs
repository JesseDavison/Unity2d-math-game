using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillFeedButtonMove : MonoBehaviour
{
    public Vector3 startingPosition;
    public Vector3 finalPosition;
    public float finalPositionYValue;
    public float speed = 1000;
    public bool readyToMove = false;

    public GameObject precedingNeighbor;

    public bool receivedGreenLight;

    //public RectTransform rectTrans;

    //string name;

    // Start is called before the first frame update
    void Start()
    {
        //name = gameObject.name;
        //rectTrans = GetComponent<RectTransform>();

        transform.localPosition = new Vector3(0, 0, 0);
        startingPosition = transform.localPosition;
        gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (readyToMove && receivedGreenLight)
        {
            transform.localPosition += Vector3.down * speed * Time.deltaTime;
        }
        if (transform.localPosition.y < -31) {
            SendGreenLight();
        }
        if ((transform.localPosition.y <= finalPosition.y))
        {
            readyToMove = false;
            transform.localPosition = finalPosition;
        }
    }
    public void StartMotion() {
        finalPosition = transform.localPosition + new Vector3(0, finalPositionYValue, 0);
        //Debug.Log("current position according to self: " + transform.localPosition.ToString());
        readyToMove = true;
    }

    public void ResetPosition() {
        transform.localPosition = startingPosition;
        receivedGreenLight = false;
    }

    public void SendGreenLight() {
        precedingNeighbor.gameObject.GetComponent<KillFeedButtonMove>().receivedGreenLight = true;
    }
    



    private void FixedUpdate()
    {


    }
}
