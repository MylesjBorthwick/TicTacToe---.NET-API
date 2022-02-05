using System;

namespace TicTacToeApi.TicTacToe.Entities
{ 
    public record Player{


        public Player(string name, char symbol){
            Name = name;
            Symbol = symbol;
            PlayerId = Guid.NewGuid();
            
        }
        
        public Guid PlayerId { get; init;}

        public char Symbol {get; set;}

        public string Name { get; set;}


    }
}
