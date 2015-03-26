using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

    private int score1;
    private int score2;
    private GameObject lastPaddleHit;

    public void WallHit(GameObject wall, GameObject hitter)
    {
        if (hitter.name.ToLower().Contains("paddle")) return;
        if (wall.tag == "Horizontal")
        {
            if (lastPaddleHit.name.ToLower().Contains("right")) score1++;
            else score2++;
        }
        else
        {
            if (wall.name.ToLower().Contains("right")) score2++;
            else score1++;
        }

        Debug.Log(score2 +" --- " + score1);
        Application.LoadLevel(Application.loadedLevel);
    }

    private void Awake()
    {
        //Singleton stuff
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        //InitGame();
    }
}
