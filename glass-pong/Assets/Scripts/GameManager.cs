using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public float DelayTime = 2.5f;
    private int score1;
    private int score2;
    private GameObject lastPaddleHit;
    private GameObject ball;
    private Text go;
    private Text leftScore;
    private Text rightScore;

    public void WallHit(GameObject wall, GameObject hitter)
    {
        if (hitter.name.ToLower().Contains("paddle")) return;
        if (wall.tag.Contains("Horizontal"))
        {
            if (lastPaddleHit.name.ToLower().Contains("right")) score2++;
            else score1++;
        }
        else
        {
            if (wall.name.ToLower().Contains("right")) score2++;
            else score1++;
        }

        
        Application.LoadLevel(Application.loadedLevel);
    }


    public void PaddleHit(GameObject paddle)
    {
        lastPaddleHit = paddle;
    }

    private void Awake()
    {
        //Singleton stuff
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);             
    }

    void Start()
    {
        FindComponents();
        go.text = "Go";
        Invoke("StartGame", DelayTime);

    }

    private void FindComponents()
    {
        ball = GameObject.Find("Ball");
        go = GameObject.Find("Go").GetComponent<Text>();
        leftScore = GameObject.Find("LeftScore").GetComponent<Text>();
        rightScore = GameObject.Find("RightScore").GetComponent<Text>();
    }


    //This is called each time a scene is loaded.
    void OnLevelWasLoaded(int index)
    {
        FindComponents();
        leftScore.text = score2.ToString();
        rightScore.text = score1.ToString();
        Invoke("StartGame", DelayTime);

    }

    void StartGame()
    {
        go.text = rightScore.text = GameObject.Find("LeftScore").GetComponent<Text>().text = "";
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.right * ball.GetComponent<Ball>().speed;
    }


}
