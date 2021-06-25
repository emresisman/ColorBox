using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{

    private int[] totalBallCount;
    private Color[] ballColor;
    private OnLevelLoaded OLL;
    private List<Color> colorList = new List<Color>();

#region Singleton
    private static ColorController _instance;

    public static ColorController Instance { get => _instance; }

    void Awake(){
        _instance=this;
    }

#endregion

    void Start()
    {
        OLL=this.gameObject.GetComponent<OnLevelLoaded>();
        totalBallCount=OLL.LevelSO.totalColorCount;
        ballColor=OLL.LevelSO.color;
        for(int i=0; i<ballColor.Length;i++)
        {
            for(int j=0;j<totalBallCount[i];j++)
            {
                colorList.Add(ballColor[i]);
            }
        }
    }

    public Color GetNewColor()
    {
        if(colorList.Count!=0)
        {
            int rng=Random.Range(0,colorList.Count-1);
            Color color = colorList[rng];            
            colorList.RemoveAt(rng);
            OLL.ChangeBackGroundColor(color);
            OLL.SetColorTextValues(color,GetRemainingColorCount(color));
            return color;
        }
        else
        {
            OLL.CheckColorBoxFullWithColor();
            return Color.black;          
        }
    }

    public void CompletedColorBox(Color clr)
    {
        colorList.RemoveAll(t=> t==clr);
        //OLL.SetColorTextValues(clr,GetRemainingColorCount(clr));
    }

    private int GetRemainingColorCount(Color color)
    {
        int count=0;
        foreach(Color clr in colorList)
        {
            if(clr==color) count++;
        }
        return count;
    }
}
