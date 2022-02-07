using System;
/// <summary>
/// Entity representing player with custom contructor.
/// </summary>
namespace TicTacToeApi.TicTacToe.Entities
{ 
    public record PlayerDto{
        
        public Guid PlayerId { get; init;}

        public char Symbol {get; set;}

        public string Name { get; set;}

    }
}
