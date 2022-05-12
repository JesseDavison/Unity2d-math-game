using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenu : MonoBehaviour
{
    private Button thisButton;
    
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ChangeSceneToMenu);
    }


    public void ChangeSceneToMenu() {
        SceneManager.LoadScene("Main Menu");
    }

}
