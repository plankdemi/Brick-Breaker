public class Player
{
    public int Lives { get; set; }
    public int Score { get; set; }
    public float desiredVelocity { get; } = 10f;

    public Player(int lives)
    {
        Lives = lives;
        Score = 0;
    }


}
