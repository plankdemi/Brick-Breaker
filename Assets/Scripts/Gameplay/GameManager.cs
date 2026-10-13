using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI lives;

    public static Player player { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void awake()
    {
        player = new Player(3);
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
}
