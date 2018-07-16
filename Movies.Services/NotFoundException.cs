using System;

namespace Movies.Services
{
    public class NotFoundException : System.Exception
    {
         public NotFoundException() :base()
        {
        }

    public NotFoundException(string message)
        : base(message)
        {
        }

    public NotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
