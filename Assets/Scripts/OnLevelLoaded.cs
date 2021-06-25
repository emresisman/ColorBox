using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelLoaded : MonoBehaviour
{
    private bool result = true;
    private GameObject[] ColorBoxes;
    private Levels levelSO, nextLevelSO;
    private GameObject ColorBox, ColorText;
    private int colorCount;

#region Encapsulate
    public bool Result { get => result; set => result = value; }
    public Levels LevelSO { get => levelSO; }
#endregion

#region Singleton
    private static OnLevelLoaded _instance;
    public static OnLevelLoaded Instance { get => _instance; }
    void Awake()
    {
        _instance=this;
    }
#endregion

    void Start()
    {
        levelSO = (Levels)Resources.Load("Levels/" + SceneManagement.currentLevel);
        if(SceneManagement.currentLevel<10) nextLevelSO = (Levels)Resources.Load("Levels/" + (SceneManagement.currentLevel + 1).ToString());
        colorCount = levelSO.colorCount;
        ColorBox = (GameObject)Instantiate(Resources.Load("ColorBoxes/ColorBox" + colorCount.ToString()), Vector3.zero, Quaternion.identity);
        SetColorBoxValues(ColorBox);
    }

    void SetColorBoxValues(GameObject colorBox)
    {
        ColorBoxes = colorBox.GetComponent<ColorBoxList>().colorBox;
        for (int i = 0; i < ColorBoxes.Length; i++)
        {
            ColorBox _cb =ColorBoxes[i].GetComponent<ColorBox>();
            _cb.BoxColor = levelSO.color[i];
            _cb.RequiredBallCount = levelSO.requiredColorCount[i];
            _cb.TotalBallCount =levelSO.totalColorCount[i];
        }
    }

    public void SetColorTextValues(Color clr, int count)
    {
        for (int i = 0; i < ColorBoxes.Length; i++)
        {
            ColorBox _cb =ColorBoxes[i].GetComponent<ColorBox>();
            if(_cb.BoxColor==clr) _cb.SetColorBoxText(count);
        }
    }

    public void CheckColorBoxFullWithColor()
    {
        for(int i=0;i<ColorBoxes.Length; i++)
        {
            Result&=ColorBoxes[i].GetComponent<ColorBox>().IsColorCompleted;
            if(result && SceneManagement.currentLevel<10) 
            {
                nextLevelSO.unlocked=true;
            }
            levelSO.unlocked=true;
            SceneManagement.LoadScene("Start");
        }
    }

    public void ChangeBackGroundColor(Color clr)
    {
        GetComponent<SpriteRenderer>().color=clr;
    }
}