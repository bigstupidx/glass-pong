using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.Instance.WallHit(gameObject, col.gameObject);
        
    }
}
