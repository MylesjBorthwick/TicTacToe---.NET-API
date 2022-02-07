using System;
using System.ComponentModel.DataAnnotations;
using TicTacToeApi.TicTacToe.Entities;
/// <summary>
/// Dto for receiving move request input
/// </summary>
namespace TicTacToeApi.TicTacToe.Dtos
{ 
    public record MoveDto{

        [Required]
        public Guid PlayerId {get; set;}
        
        [Required]
        [Range(0,8, ErrorMessage = "Coordinate must be between 0 and 8") ]
        public int Coordinate {get; set;}


    }
}