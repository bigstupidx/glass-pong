using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject GameManagerObject;
    public GameObject SoundManagerObject;

    void Awake()
    {
        if (GameManager.Instance == null)
        {
            Instantiate(GameManagerObject);
        }

        if (SoundManager.Instance == null)
        {

            Instantiate(SoundManagerObject);
        }
    }
}
