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



}
