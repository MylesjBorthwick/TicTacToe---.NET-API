using System;

namespace TicTacToe.Exceptions
{
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message)
            : base(message)
        {
        }
    }
}