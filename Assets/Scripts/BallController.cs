using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Color _ballColor;
    private Rigidbody2D _rb;
    public Transform ballSpawnPoint;
    public Color BallColor { get => _ballColor; }

    void Start()
    {   
        _rb=this.GetComponent<Rigidbody2D>();
        StartCoroutine("Countdown");
        RespawnBallWithColor(ColorController.Instance.GetNewColor());
        PlayerController.Instance.BallPassTheStick+=GoToDirection;
    }

    public void GoToDirection(float angle)
    {
        _rb.AddForce(Vector2.right*angle*17);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorBox")
        {
            RespawnBallWithColor(ColorController.Instance.GetNewColor());
        }
    }

    public void RespawnBallWithColor(Color clr)
    {
        this.transform.position = ballSpawnPoint.position;
        _rb.velocity = Vector3.zero;
        this.GetComponent<Renderer>().material.color=clr;
        _ballColor=clr;
    }

    private IEnumerator Countdown() 
    {
        _rb.gravityScale=0;
        while(true) 
        {
            yield return new WaitForSeconds(2);
            _rb.gravityScale=1;       
        }
    }
}
