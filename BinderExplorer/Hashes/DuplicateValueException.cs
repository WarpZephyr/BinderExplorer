using System;

namespace HashLib
{
    /// <summary>
    /// Reports when a value is already contained within a dictionary.
    /// </summary>
    public class DuplicateValueException : Exception
    {
        public DuplicateValueException() { }
        public DuplicateValueException(string message) : base(message) { }
        public DuplicateValueException(string message, Exception inner) : base(message, inner) { }
    }
}
