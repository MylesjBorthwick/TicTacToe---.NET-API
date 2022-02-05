using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TicTacToe.Exceptions;

namespace TicTacToeApi.TicTacToe.Entities
{ 
    public record Board : Constants {
        
        public char[] BoardRep { get; set;}

        public int MoveCount {get; set;}

        public Board(){

            BoardRep = new char[9] 
            {Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty};

            MoveCount = 0;

        }

        public void UpdateBoard(int position, char symbol){

            if(BoardRep[position] == Empty){
                BoardRep[position] = symbol;
                MoveCount++;
            }
            else{
                throw new InvalidMoveException("Choose an Empty Space");
            }

            
        }

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
            else if (hor1.SequenceEqual(YWin) | hor2.SequenceEqual(YWin) | hor3.SequenceEqual(YWin) 
            | vert1.SequenceEqual(YWin) | vert2.SequenceEqual(YWin) | vert3.SequenceEqual(YWin)
            | diag1.SequenceEqual(YWin) | diag2.SequenceEqual(YWin)){
                return 2;
            }

            else if(!BoardRep.Contains(Empty)){
                return 3;
            }


            return 0;
        
        }

    }
}

