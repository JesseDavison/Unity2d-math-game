using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetProgress : MonoBehaviour
{
    private Button thisButton;


    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ResetAllProgress);
    }

    public void ResetAllProgress() {
        PlayerPrefs.DeleteAll();
        GameManager.instance.numberOfLevelsCompleted = 0;
        GameManager.instance.allLevelsAreCompleted = false;
        //reload the main menu UI if necessary????
        GameManager.instance.Awake();
    }

}
