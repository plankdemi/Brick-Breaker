public class Player
{
    public static int Lives { get; set; }
    public static int Score { get; set; }
    public static float desiredVelocity { get; } = 10f;

    public Player(int lives)
    {
        Lives = lives;
        Score = 0;
    }


}
