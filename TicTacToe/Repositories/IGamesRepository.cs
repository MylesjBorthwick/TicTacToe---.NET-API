using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToeApi.TicTacToe.Entities;

namespace TicTacToeApi.TicTacToe.Repositories
{
    
    public interface IGamesRepository
    {
        Game GetGame(Guid gameId);
        IEnumerable<Game> GetGames();
        void CreateGame(Game game);

        void UpdateGame(Game game);

        void DeleteGame(Guid gameId);

    }   

}