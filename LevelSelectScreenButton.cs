using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectScreenButton : MonoBehaviour
{
    private Button thisButton;


    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(StartSpecificLevel);
    }

    public void StartSpecificLevel() {
        int levelToStart = int.Parse(gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        //Debug.Log("level to start: " + levelToStart);
        GameManager.instance.LoadSpecificLevel(levelToStart - 1);
    }

    public void ChangeLevelSelectButtonColorToCompleted() {
        //gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color(.95f, .1f, .1f, 1);      // dark red
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color(.3f, .3f, .3f, 1);      // dark grey
    }
    public void ChangeLevelSelectButtonColorToNOTCompleted() {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
    }



}
