using System;
using UnityEngine;
using System.Collections;

public class AiPaddle : MonoBehaviour
{
    public float Speed = 30;   

    private GameObject ball;
    private Rigidbody2D ballBody;

	// Use this for initialization
	void Start () {
	    ball = GameObject.Find("Ball");
	    ballBody = ball.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (ballBody.velocity.x > 0) return;

        var diff = ball.transform.position.y - transform.position.y;
	    if (Math.Abs(diff) < GetComponent<SpriteRenderer>().bounds.size.y/2) return;
	    GetComponent<Rigidbody2D>().velocity = new Vector2(0,(diff < 0 ? -1 : 1)*Speed);

	}
}
