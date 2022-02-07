using System.Linq;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Board object stores information about the game state. Board is represented as a 1d character array.
///This record initializes the board, updates board and checks for win conditions in the array.
/// </summary>
namespace TicTacToeApi.TicTacToe.Entities
{ 
    public record Board : Constants {
        
        //Array representation of game board
        public char[] BoardRep { get; set;}

        //Counter for performed moves
        public int MoveCount {get; set;}
        
        //Flag for identifying occupied spaces
        public bool IsEmpty{get; set;}

        //Constructs board and populates with '?' characters
        public Board(){

            BoardRep = new char[9] 
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty};

            MoveCount = 0;

        }

        /// <summary>
        /// Updates board with input symbol at corresponding location in array
        /// </summary>
        /// <param name="position">Index in array</param>
        /// <param name="symbol">Character value for update</param>
        public void UpdateBoard(int position, char symbol){

            if(BoardRep[position] == Empty){
                IsEmpty = true;
                BoardRep[position] = symbol;
                MoveCount++;
            }
            else{
                //Position is occupied by non empty character
                IsEmpty = false;
            }

            
        }
        /// <summary>
        /// Checks board state againts win conditions defined in Constants 
        /// </summary>
        /// <returns>Integer representing player1 win, player2 win, tie or continue</returns>
        public int CheckWinner(){
            
            //Collect Horizontal board conditions
            char[] hor1 = BoardRep.SubArray(HorWin1[0], HorWin1[1], HorWin1[2]);
            char[] hor2 = BoardRep.SubArray(HorWin2[0], HorWin2[1], HorWin2[2]);
            char[] hor3 = BoardRep.SubArray(HorWin3[0], HorWin3[1], HorWin3[2]);

            //Collect Vertical board conditions
            char[] vert1 = BoardRep.SubArray(VertWin1[0], VertWin1[1], VertWin1[2]);
            char[] vert2 = BoardRep.SubArray(VertWin2[0], VertWin2[1], VertWin2[2]);
            char[] vert3 = BoardRep.SubArray(VertWin1[0], VertWin1[1], VertWin1[2]);

            //Collect Horizontal board conditions
            char[] diag1 = BoardRep.SubArray(DiagWin1[0], DiagWin1[1], DiagWin1[2]);
            char[] diag2 = BoardRep.SubArray(DiagWin2[0], DiagWin2[1], DiagWin2[2]);

            //Check Win conditions for X
            if(hor1.SequenceEqual(XWin)| hor2.SequenceEqual(XWin) | hor3.SequenceEqual(XWin)
            | vert1.SequenceEqual(XWin) | vert2.SequenceEqual(XWin) | vert3.SequenceEqual(XWin)
            | diag1.SequenceEqual(XWin) | diag2.SequenceEqual(XWin)){
                return 1;
            }

            //Check Win conditions for y
            else if (hor1.SequenceEqual(OWin) | hor2.SequenceEqual(OWin) | hor3.SequenceEqual(OWin) 
            | vert1.SequenceEqual(OWin) | vert2.SequenceEqual(OWin) | vert3.SequenceEqual(OWin)
            | diag1.SequenceEqual(OWin) | diag2.SequenceEqual(OWin)){
                return 2;
            }

            else if(!BoardRep.Contains(Empty)){
                //Tie Game
                return 3;
            }

            //Continue Game
            return 0;
        
        }

    }
}

