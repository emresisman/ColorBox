using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void BallHandler(float f);

public class PlayerController : MonoBehaviour
{

#region Singleton

    public static PlayerController Instance;

    public void Awake(){
        Instance=this;
    }

#endregion

    public event BallHandler BallPassTheStick;
    public Slider leftSlider, rightSlider;
    private float angle;

    void FixedUpdate()
    {
        this.transform.rotation=Quaternion.Euler(0f,0f,angle);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {       
        if(col.tag=="Ball")
            BallPassTheStick?.Invoke(angle);           
    }

    public void OnSliderValueChange()
    {
        angle= (rightSlider.value*40)-(leftSlider.value*40);
    }
}