using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu_ViewAllLevels_Button : MonoBehaviour
{
    private Button thisButton;
    
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(GoToLevelSelectScreen);
    }

    public void GoToLevelSelectScreen() {
        GameManager.instance.GoToLevelSelect();
    }



}
