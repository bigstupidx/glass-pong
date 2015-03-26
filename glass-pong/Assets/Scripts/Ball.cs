using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed = 30;

    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the left Racket?
        if (col.gameObject.name == "PaddleLeft")
        {
            HitPaddle(col, -1);
        }

        // Hit the right Racket?
        if (col.gameObject.name == "PaddleRight")
        {
            HitPaddle(col, 1);
        }
    }

    private void HitPaddle(Collision2D col, int direction)
    {
        // Calculate hit Factor
        var y = hitFactor(transform.position,
            col.transform.position,
            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        var dir = new Vector2(direction, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir*speed;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
