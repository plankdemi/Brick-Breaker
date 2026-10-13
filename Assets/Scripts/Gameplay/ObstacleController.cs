using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private int health;
    public event Action BrickDestroyed;
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
                BrickDestroyed?.Invoke();

            }
        }
    }
}
