using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI lives;

    public static Player player { get; private set; }
    public BallController ball;
    public GameObject[] obstacles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = new Player(3);
        obstacles = GameObject.FindGameObjectsWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        UpdateUi();
    }

    private void UpdateUi()
    {
        score.text = "SCORE: " + player.Score;
        lives.text = "LIVES: " + player.Lives;
    }


    private void OnEnable()
    {
        ball.BallLost += HandleBallLost;
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle != null)
            {
                obstacle.GetComponent<ObstacleController>().BrickDestroyed += HandleBrickDestroyed;
            }

        }
    }
    private void OnDisable()
    {
        ball.BallLost -= HandleBallLost;
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle != null)
            {
                obstacle.GetComponent<ObstacleController>().BrickDestroyed -= HandleBrickDestroyed;
            }


        }
    }
    private void HandleBallLost()
    {
        --player.Lives;

        if (player.Lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    private void HandleBrickDestroyed()
    {
        player.Score += 10;
    }
}
