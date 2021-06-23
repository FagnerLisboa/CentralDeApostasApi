using CentralDeApostasApi.ApplicationCore.Entities.Enum;
using CentralDeApostasApi.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeApostasApi.ApplicationCore.Models
{
    public class ValidatePropertiesModel
    {
        public bool isEmail { get; set; }
        public bool isLogin { get; set; }
        public bool isCell { get; set; }

    }
}
