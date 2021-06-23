using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeApostasApi.ApplicationCore.Entities.ManagementSystem
{
    public enum CentralDeApostasExceptionType
    {
        UnexpectedError = 666,

        LoginRequired = 1,
        SenhaRequired = 2,
        UserNotExists = 3,
        UserNotValidActiveryDirectory = 4,
        ActiveDirectoryNotAvaiable = 5,
        EmailRequired = 6        
    }
}
