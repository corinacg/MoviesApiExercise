using System;

namespace Movies.Services
{
    public class InvalidInputException : System.Exception
    {
         public InvalidInputException() :base()
        {
        }

    public InvalidInputException(string message)
        : base(message)
        {
        }

    public InvalidInputException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
