using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{

    Rigidbody2D paddleRb;
    Rigidbody2D ballRb;
    BallController ballController;
    public GameObject Ball;
    private Player player;



    [Header("Input Actions")]
    public InputActionReference moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = new Player(3);

    }
    void Awake()
    {
        paddleRb = GetComponent<Rigidbody2D>();
        ballRb = Ball.GetComponent<Rigidbody2D>();
        ballController = Ball.GetComponent<BallController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        paddleRb.AddForce(new Vector2(input.x, 0f));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            ballController = collision.gameObject.GetComponent<BallController>();
            if (ballController.sticky)
            {
                ballRb = ballController.GetComponent<Rigidbody2D>();
                ballRb.linearVelocity = Vector2.zero;
                ballRb.angularVelocity = 0f;
            }

        }
    }

    private void OnLaunch()
    {

        if (Ball.GetComponent<BallController>().sticky)
        {
            ballRb = Ball.GetComponent<Rigidbody2D>();
            ballController = Ball.GetComponent<BallController>();
        }



        if (ballRb && ballController)
        {

            ballController.sticky = false;

            ballRb.AddForce(Vector2.up);
            ballRb.linearVelocityY = GameManager.player.desiredVelocity;
            ballRb = null;
            ballController = null;
        }
    }
}
