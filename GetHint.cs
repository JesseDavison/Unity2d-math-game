using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHint : MonoBehaviour
{

    private Button thisButton;

    public GameObject HintText;
    // FYI, the text of the hint is set in Levels.cs, in assignTextToHints()

    public Color normalColor;

    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ToggleHintActive);
        normalColor = thisButton.GetComponent<Image>().color;
    }

    public void ToggleHintActive() {
        if (HintText.activeSelf == true) {
            HintText.SetActive(false);
            // normal original color
            thisButton.GetComponent<Image>().color = normalColor;
        } else {
            HintText.SetActive(true);
            thisButton.GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f, 1);
        }
    }

    public void ShowHint() {
        HintText.SetActive(true);
    }


    public void HideHint() {
        HintText.SetActive(false);
    }



}
