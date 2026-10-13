using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{

    Rigidbody2D paddleRb;
    Rigidbody2D ballRb;
    BallController ballController;
    public GameObject Ball;


    [Header("Input Actions")]
    public InputActionReference moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        paddleRb = GetComponent<Rigidbody2D>();
        ballRb = Ball.GetComponent<Rigidbody2D>();
        ballController = Ball.GetComponent<BallController>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        paddleRb.AddForce(new Vector2(input.x, 0f) * Time.deltaTime * 1000);

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

            ballController.toggleSticky();

            ballRb.AddForce(Vector2.up);
            ballRb.linearVelocityY = GameManager.player.desiredVelocity;
            ballRb = null;
            ballController = null;
        }
    }
}
