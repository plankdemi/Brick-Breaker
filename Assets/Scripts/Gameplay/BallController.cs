using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{

    public TextMeshProUGUI score;
    public TextMeshProUGUI lives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool sticky;
    public GameObject paddle;
    private float paddleOffset = 0.5f;

    Rigidbody2D rb;

    void Start()
    {
        sticky = true;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocityY < 0f)
        {
            rb.linearVelocityY = -Player.desiredVelocity;
        }
        else if (rb.linearVelocityY > 0f)
        {
            rb.linearVelocityY = Player.desiredVelocity;

        }


        if (sticky)
        {
            transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + paddleOffset, paddle.transform.position.z);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Player.Score += 10;
            score.text = "SCORE: " + Player.Score;

        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bounds"))
        {
            Debug.Log("triggered");

            if (Player.Lives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Player.Lives -= 1;
                lives.text = "LIVES: " + Player.Lives;
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
                sticky = true;
                transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + paddleOffset, paddle.transform.position.z);
            }


        }
    }
}
