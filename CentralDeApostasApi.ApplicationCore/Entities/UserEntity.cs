using CentralDeApostasApi.ApplicationCore.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CentralDeApostasApi.ApplicationCore.Entity
{
    [Table("user")]
    public class UserEntity
    {
        [Key]
        public int id { get; set; }
        public ActiveEnum active { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public long cell { get; set; }
        public Guid guid { get; set; }
        public string registrationDate { get; set; }
        public string changeDate { get; set; }
    }
}
