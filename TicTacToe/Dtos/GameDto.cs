using System;
using TicTacToe.Exceptions;
using TicTacToeApi.TicTacToe.Entities;

namespace TicTacToeApi.TicTacToe.Dtos
{ 
    public record GameDto : Constants{

        public GameDto(){
            
        }

        public Guid GameId { get; init;}

        public Player Player1 { get; set;}

        public Player Player2 {get; set;}

        public Board GameBoard {get; init;}

        public string GameState {get; set;}

        public DateTimeOffset CreatedDate { get; set; }


    }
}