using System;
using TicTacToeApi.TicTacToe.Entities;
/// <summary>
/// Response dto for displaying result from inputting a move
/// </summary>
namespace TicTacToeApi.TicTacToe.Dtos
{ 
    public record MoveResponseDto{

        public char[] BoardState {get; set;}

        public string MoveMessage{get; set;}


    }
}