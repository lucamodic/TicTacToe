using NUnit.Framework;

[TestFixture]
public class TicTacToeTests
{
    [Test]
    public void TestGamePlay()
    {
        Player player1 = new Player(PlayerType.X);
        Player player2 = new Player(PlayerType.O);
        Game game = new Game(player1, player2);

        NUnit.Framework.Assert.AreEqual(PlayerType.X, game.CurrentPlayer);
        Assert.IsFalse(game.Board.HasWinner());
        Assert.IsFalse(game.Board.IsFull());

        game.MakeMove(0, 0);
        Assert.AreEqual(PlayerType.O, game.CurrentPlayer);
        game.MakeMove(0, 1);
        Assert.AreEqual(PlayerType.X, game.CurrentPlayer);
        game.MakeMove(1, 1);
        Assert.AreEqual(PlayerType.O, game.CurrentPlayer);
        game.MakeMove(0, 2);
        Assert.AreEqual(PlayerType.X, game.CurrentPlayer);
        game.MakeMove(2, 2);

        Assert.IsTrue(game.Board.HasWinner());
        Assert.AreEqual(PlayerType.X, game.Board.GetCell(0, 0));
        Assert.AreEqual(PlayerType.X, game.Board.GetCell(1, 1));
        Assert.AreEqual(PlayerType.X, game.Board.GetCell(2, 2));

        game.Restart();
        Assert.AreEqual(PlayerType.X, game.CurrentPlayer);
        Assert.IsFalse(game.Board.HasWinner());
        Assert.IsFalse(game.Board.IsFull());
    }

    [Test]
    public void TestInvalidMoves()
    {
        Player player1 = new Player(PlayerType.X);
        Player player2 = new Player(PlayerType.O);
        Game game = new Game(player1, player2);

        Assert.Throws<InvalidOperationException>(() => game.MakeMove(-1, 0));
        Assert.Throws<InvalidOperationException>(() => game.MakeMove(0, 3));

        game.MakeMove(0, 0);
        Assert.Throws<InvalidOperationException>(() => game.MakeMove(0, 0));
    }
}
