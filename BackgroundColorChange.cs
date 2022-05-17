using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorChange : MonoBehaviour
{
    Button thisButton;

    Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ChangeBackground);

    }


    private void ChangeBackground() {
        // get the color of the button
        newColor = thisButton.image.color;

        // set the background to that color
        GameObject cammy = GameObject.FindGameObjectWithTag("MainCamera");
        cammy.GetComponent<CameraAdjust>().ChangeBackground(newColor);

        float Rcolor = newColor.r;
        float Gcolor = newColor.g;
        float Bcolor = newColor.b;
        PlayerPrefs.SetFloat("Rcolor", Rcolor);
        PlayerPrefs.SetFloat("Gcolor", Gcolor);
        PlayerPrefs.SetFloat("Bcolor", Bcolor);

    }




}
