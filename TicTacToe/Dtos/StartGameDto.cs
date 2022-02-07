using System;
using System.ComponentModel.DataAnnotations;
using TicTacToeApi.TicTacToe.Entities;
/// <summary>
/// Input DTO for starting a game
/// </summary>
namespace TicTacToeApi.TicTacToe.Dtos
{ 
    public record StartGameDto{

        [Required]
        [StringLength(10, ErrorMessage = "Name should not exceed 10 characters")]
        public string Player1Name { get; init;}

        [Required]
        [StringLength(10, ErrorMessage = "Name should not exceed 10 characters")]
        public string Player2Name { get; set;}


    }
}