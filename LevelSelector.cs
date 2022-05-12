using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{                                                           // https://www.youtube.com/watch?v=tCr_i5CVv_w, Unity - Creating a Level Select Screen in C#
    public GameObject levelHolder;      // the panel
    public GameObject levelIcon;
    public GameObject thisCanvas;
    public int numberOfLevels = 99;
    public Vector2 iconSpacing;
    private Rect panelDimensions;
    private Rect iconDimensions;
    private int amountPerPage;
    private int currentLevelCount;

    // Start is called before the first frame update
    void Start()
    {
        //numberOfLevels = GameManager.instance.highestLevelNumberThatExists;
        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
        int maxInARow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int maxInACol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        amountPerPage = maxInARow * maxInACol;
        //Debug.Log("number of levels: " + numberOfLevels);
        int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        //Debug.Log("amount per page: " + amountPerPage);
        LoadPanels(totalPages);
        //Debug.Log("total pages: " + totalPages);
    }

    void LoadPanels(int numberOfPanels) {
        //Debug.Log("number of panels: " + numberOfPanels); 

        GameObject panelClone = Instantiate(levelHolder) as GameObject;
        PageSwiper swiper = levelHolder.AddComponent<PageSwiper>();                   // ********************************************************************
        swiper.totalPages = numberOfPanels;

        for (int i = 1; i <= numberOfPanels; i++) {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Panel Page-" + i;
            //panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);        // for swiping sideways
            panel.GetComponent<RectTransform>().localPosition = new Vector2(0, panelDimensions.height * (1 - i));        // for swiping vertical
            SetupGrid(panel);
            // if the value of i equals the same value as numberOfPanels (which would mean it's on our last page) then use (numberOfLevels - currentLevelCount), 
            //      otherwise, use amountPerPage
            int numberOfIcons = i == numberOfPanels ? numberOfLevels - currentLevelCount : amountPerPage;

            LoadIcons(numberOfIcons, panel); 
        }
        Destroy(panelClone);
    }

    void SetupGrid(GameObject panel) {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;      // makes our icons centered inside our panel
        grid.spacing = iconSpacing;
    }

    void LoadIcons(int numberOfIcons, GameObject parentObject) { 
        for (int i = 1; i <= numberOfIcons; i++) {
            currentLevelCount++;
            GameObject icon = Instantiate(levelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Level " + i;
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText(currentLevelCount.ToString());
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
