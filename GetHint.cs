using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHint : MonoBehaviour
{

    private Button thisButton;

    public GameObject HintText;
    // FYI, the text of the hint is set in Levels.cs, in assignTextToHints()

    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ToggleHintActive);
    }

    public void ToggleHintActive() {
        if (HintText.activeSelf == true) {
            HintText.SetActive(false);
        } else {
            HintText.SetActive(true);
        }

    }

    public void ShowHint() {
        HintText.SetActive(true);
    }


    public void HideHint() {
        HintText.SetActive(false);
    }



}
