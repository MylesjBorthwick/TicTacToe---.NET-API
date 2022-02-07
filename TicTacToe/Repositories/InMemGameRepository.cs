using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeApi.TicTacToe.Entities;

/// <summary>
/// In memory repository for tic tac toe service
/// </summary>
namespace TicTacToeApi.TicTacToe.Repositories
{

    public class InMemGameRepository : IGamesRepository
    {
        private readonly List<Game> games = new()
        {
            new Game("Myles", "Walt")
        };

        /// <summary>
        /// Fetches gamelist from repository by id
        /// </summary>
        /// <returns>list of games</returns>
        public IEnumerable<Game> GetGames()
        {
            return games;
        }

        /// <summary>
        /// Returns specific game from gaes list
        /// </summary>
        /// <param name="gameId">GameID</param>
        /// <returns>Game object</returns>
        public Game GetGame(Guid gameId)
        {
            var game = games.Where(game => game.GameId == gameId).SingleOrDefault();
            return game;
        }

        /// <summary>
        /// Adds game to gamelist
        /// </summary>
        /// <param name="game">Game to add</param>
        public void CreateGame(Game game)
        {
            games.Add(game);
        }

        /// <summary>
        /// Updates game in list
        /// </summary>
        /// <param name="game">Game to be updated</param>
        public void UpdateGame(Game game)
        {
           var index = games.FindIndex(existingGame => existingGame.GameId == game.GameId);
           games[index] = game;
        }

        /// <summary>
        /// Removes game from list
        /// </summary>
        /// <param name="gameId">Game's id</param>
        public void DeleteGame(Guid gameId)
        {
            var index = games.FindIndex(existingGame => existingGame.GameId == gameId);
            games.RemoveAt(index);
        }

        /// <summary>
        /// Helper method to get game by contained playerid
        /// </summary>
        /// <param name="playerId">Id of player</param>
        /// <returns>Game containing specified player</returns>
        public Game GetGameFromPlayer(Guid playerId)
        {
            var game = games.FirstOrDefault(game => game.Player1.PlayerId == playerId | 
                                            game.Player2.PlayerId == playerId);
            return game;
        }

        /// <summary>
        /// Helper method to access player entity from game list
        /// </summary>
        /// <param name="gameId">Game id</param>
        /// <param name="playerId">Desired player</param>
        /// <returns></returns>
        public Player GetPlayer(Guid gameId, Guid playerId){
            
            var game = games.Where(game=> game.GameId == gameId).SingleOrDefault();
            
            if(game.Player1.PlayerId == playerId){
                return game.Player1;
            }

            else if(game.Player2.PlayerId == playerId){
                return game.Player2;
            }

            return null;

        }
    }
    


}