using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 1;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            --health;
            if (health <= 0)
            {
                Destroy(gameObject);
                GameManager.player.Score += 10;
            }
        }
    }
}
