using System;
using TicTacToeApi.TicTacToe.Dtos;
using TicTacToeApi.TicTacToe.Entities;

public static class Extensions
{
    /// <summary>
    /// Creates a sub array based on an input array and input indices
    /// </summary>
    /// <param name="array">Input Array</param>
    /// <param name="index1">First index</param>
    /// <param name="index2">Second index</param>
    /// <param name="index3">Third Index</param>
    /// <typeparam name="T">Flexible Type</typeparam>
    /// <returns>Sub array of length 3 populated with values from the input array
    /// at the given indices</returns>
    public static T[] SubArray<T>(this T[] array, int index1, int index2, int index3)
    {
        T[] arrCopy = new T[9];
        Array.Copy(array, arrCopy, 9);

        T[] result = new T[3] {arrCopy[index1], arrCopy[index2], arrCopy[index3]};

        return result;
    }

    /// <summary>
    /// Changes input Game object into a Game DTO
    /// </summary>
    /// <param name="game">Inout Game object</param>
    /// <returns>DTO of the input object</returns>
    public static GameDto asGameDto(this Game game)
    {
            return new GameDto
            {
                GameId = game.GameId,
                Player1 = game.Player1.asPlayerDto(),
                Player2 = game.Player2.asPlayerDto(),
                GameBoardRep = game.GameBoard.BoardRep
            };
    }

    public static CreatedGameDto asCreatedDto(this Game game)
    {
        return new CreatedGameDto
        {
            GameId = game.GameId,
            Player1Id = game.Player1.PlayerId,
            Player2Id = game.Player2.PlayerId
        };
    }

    public static PlayerDto asPlayerDto(this Player player)
    {
        return new PlayerDto
        {
            PlayerId = player.PlayerId,
            Symbol = player.Symbol,
            Name = player.Name
        };
    }


}