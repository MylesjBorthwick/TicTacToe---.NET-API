using System;
using TicTacToe.Exceptions;
using TicTacToeApi.TicTacToe.Entities;

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