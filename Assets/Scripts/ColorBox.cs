using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBox : MonoBehaviour
{
    private bool isColorCompleted = false;
    private Color boxColor;
    public Text ballCounter, totalBallCounter;
    public Image textImage;
    private int ballCount, requiredBallCount, totalBallCount;

#region Encapsulate
    public bool IsColorCompleted { get => isColorCompleted; }
    public Color BoxColor { get => boxColor; set => boxColor = value; }
    public int BallCount { set => ballCount = value; }
    public int RequiredBallCount { set => requiredBallCount = value; }
    public int TotalBallCount { get => totalBallCount; set => totalBallCount = value; }
    #endregion

    void Start()
    {
        BallCount=0;
        ballCounter.text = ballCount + " / " + requiredBallCount;
        totalBallCounter.text= TotalBallCount.ToString();
        textImage.color=boxColor;
        GetComponent<SpriteRenderer>().color = BoxColor;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Ball")
        {
            if(col.GetComponent<BallController>().BallColor==BoxColor && ballCount!=requiredBallCount)
            ballCounter.text=++ballCount + " / " + requiredBallCount;
            if(!isColorCompleted) CheckColorCompleted();
        }
    }

    void CheckColorCompleted()
    {
        if (ballCount == requiredBallCount)
        {
            isColorCompleted = true;
            ColorController.Instance.CompletedColorBox(BoxColor);
            textImage.color=Color.white;
            textImage.sprite=Resources.Load<Sprite>("Sprites/Tick");
        } 
    }

    public void SetColorBoxText(int value)
    {
        totalBallCount=value;
        totalBallCounter.text=totalBallCount.ToString();
    }
}
