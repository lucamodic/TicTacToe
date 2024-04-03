public enum PlayerType
{
    None,
    X,
    O
}

public class Player
{
    public PlayerType Type { get; }

    public Player(PlayerType type)
    {
        Type = type;
    }
}
