using System;
using System.Runtime.Serialization;

namespace LinqueToSql
{
    [Serializable]
    internal class InvalidNameException : ApplicationException
    {
        public InvalidNameException(string Message) : base(Message) { }
    }
}