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

        public bool EndState {get; set;}

        public DateTimeOffset CreatedDate { get; set; }

        
        public Game(string p1Name, string p2Name){
            
            GameId = Guid.NewGuid();
            Player1 = new Player(p1Name, X);
            Player2 = new Player(p2Name, Y);
            GameBoard = new Board();
            CreatedDate = DateTimeOffset.UtcNow;
            GameState = "Started";
            EndState = false;
        }

         public int MakeMove(Player player, int coordinate){

            if(player.Equals(Player1) & this.GameBoard.MoveCount == 0){
                int emptyCheck = GameBoard.UpdateBoard(coordinate, player.Symbol);
                GameState = "Waiting for next move";
                return emptyCheck;
            }

            else if (player.Equals(Player1) & this.GameBoard.MoveCount %2 == 0){
                int emptyCheck = GameBoard.UpdateBoard(coordinate, player.Symbol);
                CheckForWin();
                return emptyCheck;
            }

            else if (player.Equals(Player2) & this.GameBoard.MoveCount % 2 != 0){
                int emptyCheck = GameBoard.UpdateBoard(coordinate, player.Symbol);
                CheckForWin();
                return emptyCheck;
            }

            else{
                return 0;
            }
            
        }
        
        public void CheckForWin(){

            int stateReply = GameBoard.CheckWinner();

            string p1Name = Player1.Name;
            string p2Name = Player2.Name;

            if(stateReply == 1){
                GameState =  p1Name + " Wins!";
                EndState = true;    
            }

            else if(stateReply == 2){
                GameState =  p2Name + " Wins!";
                EndState = true; 
            }

            else if(stateReply == 3){
                GameState = "Tie!";
                EndState = true;
            }

            else{
                GameState = "Waiting for next move";
            }


        }


    }
}