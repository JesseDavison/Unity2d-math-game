using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{

    private Button thisParticularButton;

    public Levels repOfLevels;


    // Start is called before the first frame update
    void Start()
    {
        thisParticularButton = GetComponent<Button>();
        thisParticularButton.onClick.AddListener(RestartTheLevel);
        repOfLevels = GameObject.Find("Level Creator").GetComponent<Levels>();
    }

    
    public void RestartTheLevel() {
        repOfLevels.RestartLevel();
    }


}
