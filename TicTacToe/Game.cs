public interface IGame
{
    PlayerType CurrentPlayer { get; }
    PlayerType MakeMove(int row, int col);
    void Restart();
}

public class Game : IGame
{
    private Board _board;
    private Player _currentPlayer;
    private Player[] _players;

    public Game(Player player1, Player player2)
    {
        _board = new Board();
        _players = new[] { player1, player2 };
        _currentPlayer = _players[0];
    }

    public PlayerType CurrentPlayer => _currentPlayer.Type;

    public PlayerType MakeMove(int row, int col)
    {
        if (_board.GetCell(row, col) != PlayerType.None)
        {
            throw new InvalidOperationException("Cell is already taken");
        }

        _board.SetCell(row, col, _currentPlayer.Type);

        if (_board.HasWinner())
        {
            return _currentPlayer.Type;
        }

        if (_board.IsFull())
        {
            return PlayerType.None;
        }

        _currentPlayer = _currentPlayer == _players[0] ? _players[1] : _players[0];

        return PlayerType.None;
    }

    public void Restart()
    {
        _board.ClearBoard();
        _currentPlayer = _players[0];
    }
}
