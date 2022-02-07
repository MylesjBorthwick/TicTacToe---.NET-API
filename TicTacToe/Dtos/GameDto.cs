using System;
using TicTacToeApi.TicTacToe.Entities;
/// <summary>
/// Game Dto used for representing game entity responses
/// </summary>
namespace TicTacToeApi.TicTacToe.Dtos
{ 
    public record GameDto : Constants{

        public GameDto(){
            
        }

        public Guid GameId { get; init;}

        public PlayerDto Player1 { get; set;}

        public PlayerDto Player2 {get; set;}

        public char[] GameBoardRep {get; init;}

    }
}