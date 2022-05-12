using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScene : MonoBehaviour
{
    private Button thisButton;

    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(GoToMainMenu);
        
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
