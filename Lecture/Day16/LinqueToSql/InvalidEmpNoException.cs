using System;
using System.Runtime.Serialization;

namespace LinqueToSql
{
    [Serializable]
    internal class InvalidEmpNoException : ApplicationException
    {
        public InvalidEmpNoException(string Message) : base(Message) { }
    }
   
}