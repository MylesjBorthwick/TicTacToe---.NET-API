using System;
using TicTacToe.Exceptions;

namespace TicTacToeApi.TicTacToe.Entities
{ 
    public record Game : Constants{
        
        public Guid GameId { get; init;}

        public Player Player1 { get; set;}

        public Player Player2 {get; set;}

        public Board GameBoard {get; init;}

        public string GameState {get; set;}

        public DateTimeOffset CreatedDate { get; set; }

        
        public Game(string p1Name, string p2Name){
            
            GameId = Guid.NewGuid();
            Player1 = new Player(p1Name, X);
            Player2 = new Player(p2Name, Y);
            GameBoard = new Board();
            CreatedDate = DateTimeOffset.UtcNow;
            GameState = "Playing";
        }


    }
}