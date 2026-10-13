using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{



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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bounds"))
        {
            Debug.Log("triggered");
            --GameManager.player.Lives;

            if (GameManager.player.Lives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {


                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
                sticky = true;
                transform.position = new Vector3(paddle.transform.position.x, paddle.transform.position.y + paddleOffset, paddle.transform.position.z);
            }


        }
    }
}
