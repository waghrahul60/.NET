using System;
using System.Runtime.Serialization;

namespace LinqueToSql
{
    [Serializable]
    internal class InvalidBasicException : ApplicationException
    {
            public InvalidBasicException(string Message) : base(Message) { }
       
    }
}