using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeApi.TicTacToe.Entities;

namespace TicTacToeApi.TicTacToe.Repositories
{

    public class InMemGameRepsoitory : IGamesRepository
    {
        private readonly List<Game> games = new()
        {
            new Game("Myles", "Tyler"),
            new Game("Susan", "Riley")
        };


        public IEnumerable<Game> GetGames()
        {
            return games;
        }

        public Game GetGame(Guid gameId)
        {
            var game = games.Where(game => game.GameId == gameId).SingleOrDefault();
            return game;
        }

        public void CreateGame(Game game)
        {
            games.Add(game);
        }

        public void UpdateGame(Game game)
        {
           var index = games.FindIndex(existingGame => existingGame.GameId == game.GameId);
           games[index] = game;
        }

        public void DeleteGame(Guid gameId)
        {
            var index = games.FindIndex(existingGame => existingGame.GameId == gameId);
            games.RemoveAt(index);
        }

        public Game GetGameFromPlayer(Guid playerId)
        {
            var game = games.FirstOrDefault(game => game.Player1.PlayerId == playerId | 
                                            game.Player2.PlayerId == playerId);
            return game;
        }

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