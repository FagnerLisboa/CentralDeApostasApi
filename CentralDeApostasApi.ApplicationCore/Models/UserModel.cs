using CentralDeApostasApi.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeApostasApi.ApplicationCore.Model
{
    public class UserModel : BaseModel
    {
        public string fullname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public long cell { get; set; }
    }
}
