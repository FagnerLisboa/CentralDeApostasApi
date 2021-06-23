using CentralDeApostasApi.ApplicationCore.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeApostasApi.ApplicationCore.Models
{
    public class BaseModel
    {
        public long id { get; set; }
        public ActiveEnum active { get; set; }
        public string registrationDate { get; set; }
        public string changeDate { get; set; }
        public string message { get; set; }
        public string log { get; set; }
        public bool authorized { get; set; }
    }
}
