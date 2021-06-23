using CentralDeApostasApi.ApplicationCore.Entity;
using CentralDeApostasApi.ApplicationCore.Model;
using CentralDeApostasApi.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeApostasApi.ApplicationCore.Interfaces.Service
{
    public interface IUserService
    {
        UserModel InsertRegister(UserEntity userEntity);
        UserModel GetById(int id);
        UserModel GetByLogin(string login);
        UserModel GetByEmail(string email);
        UserModel GetByCell(long cell);
        UserModel UpdateUser(UserEntity user);
        UserModel Delete(int id);
    }
}
