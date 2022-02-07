using System;
using TicTacToeApi.TicTacToe.Entities;
/// <summary>
/// Dto representing response object after game creation
/// </summary>
namespace TicTacToeApi.TicTacToe.Dtos
{ 
    public record CreatedGameDto{

        public CreatedGameDto(){
            
        }

        public Guid GameId { get; init;}

        public Guid Player1Id { get; set;}

        public Guid Player2Id {get; set;}


    }
}