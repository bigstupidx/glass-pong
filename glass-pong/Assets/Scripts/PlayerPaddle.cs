using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {
    public float Speed = 30;   
	
	// Update is called once per frame
    void FixedUpdate()
    {
        var v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * Speed;
	}
}
