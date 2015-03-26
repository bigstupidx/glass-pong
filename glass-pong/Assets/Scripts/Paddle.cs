using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
    public float speed = 30;   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        var v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
	}
}
