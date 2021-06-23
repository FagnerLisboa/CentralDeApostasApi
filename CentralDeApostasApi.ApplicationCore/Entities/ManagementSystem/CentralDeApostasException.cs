using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeApostasApi.ApplicationCore.Entities.ManagementSystem
{
    public class CentralDeApostasException : Exception
    {
        public IList<string> Messagens { get; private set; }
        public string Title { get; private set; }

        public CentralDeApostasExceptionType ExceptionType { get; private set; }

        public CentralDeApostasException(string message) : base(message) { }

        public CentralDeApostasException(CentralDeApostasExceptionType type)
        {
            this.ExceptionType = type;
        }

        public CentralDeApostasException(CentralDeApostasExceptionType type, string message, string title) : base(message)
        {
            this.ExceptionType = type;
            this.Title = title;
        }

        public CentralDeApostasException(CentralDeApostasExceptionType type, string message, string title, Exception innerException) : base(message, innerException)
        {
            this.ExceptionType = type;
            this.Title = title;
        }

        public CentralDeApostasException(CentralDeApostasExceptionType type, IList<string> messagens, string title)
        {
            this.ExceptionType = type;
            this.Messagens = messagens;
            this.Title = title;
        }
    }
}
