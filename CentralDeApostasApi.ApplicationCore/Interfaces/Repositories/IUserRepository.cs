using CentralDeApostasApi.ApplicationCore.Entity;
using CentralDeApostasApi.ApplicationCore.Model;
using CentralDeApostasApi.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeApostasApi.ApplicationCore.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        UserEntity GetById(int id);
        UserEntity GetByLogin(string username);
        UserEntity GetByEmail(string email);
        UserEntity GetByCell(long cell);
        bool Delete(UserEntity user);
        UserEntity ContainsEmail(string email);
        UserEntity ContainsLogin(string username);
        UserEntity ContainsCell(long cell);
        int Save(UserEntity user = null);
    }
}
