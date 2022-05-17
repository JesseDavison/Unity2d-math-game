using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScene : MonoBehaviour
{
    private Button thisButton;

    public Button tutorialOnButton;
    public Button tutorialOffButton;

    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(GoToMainMenu);


        //tutorialOnButton = GameObject.FindGameObjectWithTag("tutorialOnButton");
        //tutorialOffButton = GameObject.FindGameObjectWithTag("tutorialOffButton");

    }

    public void GoToMainMenu() {

        //int tutorialOn = PlayerPrefs.GetInt("TutorialsOnButton");
        //int tutorialOff = PlayerPrefs.GetInt("TutorialsOffButton");
        //int tutorialsActivatedOrNot = PlayerPrefs.GetInt("TutorialsActivated");
        //Debug.Log("tutorialsActivatedOrNot: " + tutorialsActivatedOrNot);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        int tutorialsActivatedOrNot = PlayerPrefs.GetInt("TutorialsActivated");
        Debug.Log("tutorialsActivatedOrNot: " + tutorialsActivatedOrNot);


        if (tutorialsActivatedOrNot == 1) {
            // equals 1 means that the tutorials ARE ACTIVATED, thus we want the ON button to NOT be interactable
            Debug.Log("it equals 1");
            
            
            tutorialOnButton.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("TutorialsOnButton", 0);

            tutorialOffButton.GetComponent<Button>().interactable = true;
            PlayerPrefs.SetInt("TutorialsOffButton", 1);

        } else if (tutorialsActivatedOrNot == 0) {
            Debug.Log("it equals 0");
            tutorialOnButton.GetComponent<Button>().interactable = true;
            PlayerPrefs.SetInt("TutorialsOnButton", 1);

            tutorialOffButton.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("TutorialsOffButton", 0);
        }

    }
}
