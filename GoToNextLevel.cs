using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToNextLevel : MonoBehaviour
{
    //public GameManager managerOfTheGame;

    public Levels repOfLevels;
    
    private Button thisParticularButton;

    private void Start()
    {
        //managerOfTheGame = GameObject.Find("Game Manager").GetComponent<GameManager>();
        thisParticularButton = GetComponent<Button>();
        thisParticularButton.onClick.AddListener(LoadLevel);
        repOfLevels = GameObject.Find("Level Creator").GetComponent<Levels>();
    }

    public void LoadLevel()
    {
        GameManager.instance.CountNumberOfLevelsCompleted();
        if (GameManager.instance.allLevelsAreCompleted == true) {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManager.instance.GoToMainMenu();
        } else {
            GameManager.instance.IdentifyLowestUnsolvedLevel();
            int lowestUnsolvedLevel = GameManager.instance.recommendedNextLevel;
            GameManager.instance.LoadSpecificLevel(lowestUnsolvedLevel);
        }
        

    }


    //private void OnMouseOver() {
    //    if (Input.GetMouseButtonDown(0)) {
    //        LoadLevel();
    //    }
    //}


}
