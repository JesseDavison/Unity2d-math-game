using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{                                                   // https://www.youtube.com/watch?v=rjFgThTjLso, Swiping Pages in Unity
    private Vector3 panelLocation;
    public float percentThreshold = 0.1f;
    public float easing = 0.3f;     // how long in seconds we want our panel to ease into the location
    public int totalPages = 1;
    private int currentPage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData data) {
        //Debug.Log(data.pressPosition - data.position);
        float difference = data.pressPosition.y - data.position.y;
        transform.position = panelLocation - new Vector3(0, difference, 0);
    }
    public void OnEndDrag(PointerEventData data) {
        //panelLocation = transform.position;
        float percentage = (data.pressPosition.y - data.position.y) / Screen.height;
        if (Mathf.Abs(percentage) >= percentThreshold) {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages) {
                Debug.Log("did it swipe up?");
                currentPage++;
                newLocation += new Vector3(0, -Screen.height, 0);
            } else if (percentage < 0 && currentPage > 1) {
                Debug.Log("did it swipe DOWN???");
                currentPage--;
                newLocation += new Vector3(0, Screen.height, 0);
            }
            //transform.position = newLocation;
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        } else {
            //transform.position = panelLocation;  
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds) {
        float t = 0f;
        while(t <= 1.0f) {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
            yield return null; // we want our function to wait for the next frame before continuing
        }
    }



}
