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

        float Rcolor = PlayerPrefs.GetFloat("Rcolor");
        float Gcolor = PlayerPrefs.GetFloat("Gcolor");
        float Bcolor = PlayerPrefs.GetFloat("Bcolor");
        int tutorialActiveStatus = PlayerPrefs.GetInt("TutorialsActivated");


        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat("Rcolor", Rcolor);
        PlayerPrefs.SetFloat("Gcolor", Gcolor);
        PlayerPrefs.SetFloat("Bcolor", Bcolor);
        PlayerPrefs.SetInt("TutorialsActivated", tutorialActiveStatus);



        GameManager.instance.numberOfLevelsCompleted = 0;
        GameManager.instance.allLevelsAreCompleted = false;

        GameManager.instance.UpdateLevelCompletionInfo();
        GameManager.instance.SetALLLevelsAsNotCompleted();
        //reload the main menu UI if necessary????
        GameManager.instance.Awake();
    }

}
