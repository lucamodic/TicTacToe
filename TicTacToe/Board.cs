public class Board
{
    private PlayerType[,] _cells;

    public Board()
    {
        _cells = new PlayerType[3, 3];
    }

    public PlayerType GetCell(int row, int col)
    {
        return _cells[row, col];
    }

    public void SetCell(int row, int col, PlayerType player)
    {
        _cells[row, col] = player;
    }

    public void ClearBoard()
    {
        _cells = new PlayerType[3, 3];
    }

    public bool IsFull()
    {
        foreach (var cell in _cells)
        {
            if (cell == PlayerType.None)
            {
                return false;
            }
        }
        return true;
    }

    public bool HasWinner()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (_cells[i, 0] != PlayerType.None && _cells[i, 0] == _cells[i, 1] && _cells[i, 1] == _cells[i, 2])
            {
                return true;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (_cells[0, i] != PlayerType.None && _cells[0, i] == _cells[1, i] && _cells[1, i] == _cells[2, i])
            {
                return true;
            }
        }

        // Check diagonals
        if (_cells[0, 0] != PlayerType.None && _cells[0, 0] == _cells[1, 1] && _cells[1, 1] == _cells[2, 2])
        {
            return true;
        }
        if (_cells[0, 2] != PlayerType.None && _cells[0, 2] == _cells[1, 1] && _cells[1, 1] == _cells[2, 0])
        {
            return true;
        }

        return false;
    }
}
