using System;
using TicTacToe.Exceptions;
using TicTacToeApi.TicTacToe.Entities;

namespace TicTacToeApi.TicTacToe.Dtos
{ 
    public record MoveResponseDto{

        public char[] BoardState {get; set;}

        public string MoveMessage{get; set;}


    }
}