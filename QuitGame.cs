using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    private Button thisButton;
    
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(QuitTheGame);
    }

    public void QuitTheGame() {
        //Debug.Log("quit the game");
        Application.Quit();
    }

}
