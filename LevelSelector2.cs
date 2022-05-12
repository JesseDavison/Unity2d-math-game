using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector2 : MonoBehaviour
{                                                           // https://www.youtube.com/watch?v=tCr_i5CVv_w, Unity - Creating a Level Select Screen in C#    
    public GameObject levelHolder;      // the panel
    public GameObject levelIcon;
    public GameObject thisCanvas;
    public int numberOfLevels = 99;
    public Vector2 iconSpacing;
    private Rect panelDimensions;
    private Rect iconDimensions;
    //private int amountPerPage;
    private int currentLevelCount;

    // Start is called before the first frame update
    void Start()
    {
        numberOfLevels = GameManager.instance.highestLevelNumberThatExists;
        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
        int maxInARow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int maxInACol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        //amountPerPage = maxInARow * maxInACol;
        //Debug.Log("number of levels: " + numberOfLevels);
        //int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        //Debug.Log("amount per page: " + amountPerPage);
        LoadPanel();
        //Debug.Log("total pages: " + totalPages);
    }

    void LoadPanel()
    {
        //Debug.Log("number of panels: " + numberOfPanels); 

        //GameObject panel = Instantiate(levelHolder) as GameObject;

        //PageSwiper swiper = levelHolder.AddComponent<PageSwiper>();                   // ********************************************************************
        //swiper.totalPages = numberOfPanels;

        //panel.transform.SetParent(thisCanvas.transform, false);
        //panel.transform.SetParent(levelHolder.transform);
        //panel.name = "Panel Page-" + i;
        //panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);        // for swiping sideways
        //panel.GetComponent<RectTransform>().localPosition = new Vector2(0, panelDimensions.height * (1 - i));        // for swiping vertical
        SetupGrid(levelHolder);
        // if the value of i equals the same value as numberOfPanels (which would mean it's on our last page) then use (numberOfLevels - currentLevelCount), 
        //      otherwise, use amountPerPage

        LoadIcons(numberOfLevels, levelHolder);
        

    }

    void SetupGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;      // makes our icons centered inside our panel
        grid.spacing = iconSpacing;
    }

    public void ReloadIconColors() {

        // cycle thru the children of levelHolder
        int numChildren = levelHolder.transform.childCount;
        for (int i = 0; i < numChildren; i++) {
            Transform child = gameObject.transform.GetChild(i);
            var tempString = (i - 1).ToString() + "_Completed";
            // "3_Completed"
            var completedInt = PlayerPrefs.GetInt(tempString, 0);

            ColorBlock colors = child.gameObject.GetComponent<Button>().colors;
            if (completedInt == 1)
            {
                Debug.Log("this level is completed: " + tempString);
                //icon.gameObject.GetComponent<Button>().interactable = false;
                // if it IS COMPLETED, then change color to 0.35, 1, 1
                colors.normalColor = new Color(0.35f, 1, 1, 1);
            }
            else
            {
                colors.normalColor = new Color(0, 0, 0, 1);
            }
        }
    }


    void LoadIcons(int numberOfIcons, GameObject parentObject)
    {
        for (int i = 1; i <= numberOfIcons; i++)
        {
            currentLevelCount++;
            GameObject icon = Instantiate(levelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Level " + i;
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText(currentLevelCount.ToString());

            var tempString = (i-1).ToString() + "_Completed";
            // "3_Completed"
            var completedInt = PlayerPrefs.GetInt(tempString, 0);

            ColorBlock colorBlock = new ColorBlock();
            colorBlock.normalColor = new Color(0, 1, 0, 1);

            if (completedInt == 1) {
                //Debug.Log("this level is completed: " + tempString);
                //icon.gameObject.GetComponent<Button>().interactable = false;
                // if it IS COMPLETED, then change color to 0.35, 1, 1
                //icon.GetComponent<Button>().colors = colorBlock;
                icon.GetComponentInChildren<TextMeshProUGUI>().color = new Color(.95f, .1f, .1f, 1);
            } else {
                //colors.normalColor = new Color(0, 0, 0, 1);
            }



        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
