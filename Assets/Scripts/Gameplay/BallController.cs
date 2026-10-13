using System;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public event Action BallLost;

    public bool sticky { get; private set; }
    public GameObject paddle;
    private float paddleOffset = 0.5f;

    Rigidbody2D rb;

    void Start()
    {
        sticky = true;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.linearVelocityY < 0f)
        {
            rb.linearVelocityY = -GameManager.player.desiredVelocity;
        }
        else if (rb.linearVelocityY > 0f)
        {
            rb.linearVelocityY = GameManager.player.desiredVelocity;

        }


        if (sticky)
        {
            transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + paddleOffset, paddle.transform.position.z);
        }

    }

    public void toggleSticky()
    {
        sticky = !sticky;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bounds"))
        {

            BallLost?.Invoke();
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            sticky = true;
            transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + paddleOffset, paddle.transform.position.z);

        }
    }
}
