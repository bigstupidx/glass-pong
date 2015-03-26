using UnityEngine;
using System.Collections;

public class Glass : MonoBehaviour
{

    public Sprite BrokenWallSprite;
    private bool hitOnce;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (hitOnce)
        {
            Destroy(gameObject);
            return;
        }

        hitOnce = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = BrokenWallSprite;
    }
}
