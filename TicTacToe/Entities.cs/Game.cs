using System;
/// <summary>
/// This entity represents the TicTacToeGame.
/// Game information is store including id, associated player and board as
/// well as state information. Methods control game moves and win conditions.
/// </summary>
namespace TicTacToeApi.TicTacToe.Entities
{ 
    public record Game : Constants{
        
        public Guid GameId { get; init;}

        public Player Player1 { get; set;}

        public Player Player2 {get; set;}

        public Board GameBoard {get; init;}

        //Current state of the game represented as a string
        public string GameState {get; set;}

        //Flag for determining if game is complete
        public bool EndState {get; set;}

        public DateTimeOffset CreatedDate { get; set; }

        
        public Game(string p1Name, string p2Name){
            
            GameId = Guid.NewGuid();
            Player1 = new Player(p1Name, X);
            Player2 = new Player(p2Name, O);
            GameBoard = new Board();
            CreatedDate = DateTimeOffset.UtcNow;
            GameState = "Started";
            EndState = false;
        }

         public int MakeMove(Player player, int coordinate){

            if(player.Equals(Player1) & GameBoard.MoveCount == 0){
                GameBoard.UpdateBoard(coordinate, player.Symbol);
                GameState = "Waiting for next move";
                return 1;
            }

            else if (player.Equals(Player1) & GameBoard.MoveCount %2 == 0){
                GameBoard.UpdateBoard(coordinate, player.Symbol);
                CheckForWin();
                return 1;
            }

            else if (player.Equals(Player2) & GameBoard.MoveCount % 2 != 0){
                GameBoard.UpdateBoard(coordinate, player.Symbol);
                CheckForWin();
                return 1;
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