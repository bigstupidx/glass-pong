using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public AudioClip PaddleHitSound;
    public AudioClip GlassHitSound;
    public AudioClip GlassBreakSound;
    public AudioClip WinSound;
    public AudioClip FailSound;
    private int score1;
    private int score2;
    private GameObject lastPaddleHit;
    private GameObject ball;
    private Text go;
    private Text leftScore;
    private Text rightScore;
    private bool waitingForInput;

    public void WallHit(GameObject wall, GameObject hitter)
    {
        if (hitter.name.ToLower().Contains("paddle")) return;
        if (wall.tag.Contains("Horizontal"))
        {
            if (lastPaddleHit.name.ToLower().Contains("right"))
            {
                score2++;
                SoundManager.Instance.PlaySingle(FailSound);
            }
            else
            {
                score1++;
                SoundManager.Instance.PlaySingle(WinSound);
            }
        }
        else
        {
            if (wall.name.ToLower().Contains("right"))
            {
                score2++;
                SoundManager.Instance.PlaySingle(FailSound);
            }
            else
            {
                score1++;
                SoundManager.Instance.PlaySingle(WinSound);
            }
        }

        
        Application.LoadLevel(Application.loadedLevel);
    }


    public void PaddleHit(GameObject paddle)
    {
        lastPaddleHit = paddle;
        SoundManager.Instance.PlaySingle(PaddleHitSound);
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
        go.text = "Press ↑ or ↓ to Start!";
        waitingForInput = true;

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
        waitingForInput = true;

    }

    void StartGame()
    {
        go.text = rightScore.text = GameObject.Find("LeftScore").GetComponent<Text>().text = "";
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.right * ball.GetComponent<Ball>().speed;
    }


    public void GlassHit()
    {
        SoundManager.Instance.PlaySingle(GlassHitSound);

    }

    public void GlassBreak()
    {
        SoundManager.Instance.PlaySingle(GlassBreakSound);
    }

    void Update()
    {
        if (!waitingForInput) return;
       
        var v = Input.GetAxisRaw("Vertical");
        if (v != 0)
        {
            StartGame();
            waitingForInput = false;
        }
    }
}
