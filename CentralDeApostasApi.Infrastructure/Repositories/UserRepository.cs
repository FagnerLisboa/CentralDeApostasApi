using CentralDeApostasApi.ApplicationCore.Entity;
using CentralDeApostasApi.ApplicationCore.Interfaces.Repository;
using CentralDeApostasApi.ApplicationCore.Model;
using CentralDeApostasApi.ApplicationCore.Models;
using CentralDeApostasApi.Infrastructure.Context;
using CentralDeApostasApi.Infrastructure.Repositories.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralDeApostasApi.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private IConfiguration _config;
        public UserRepository(PostgreSqlContext context, IConfiguration Configuration) : base(context)
        {
            this._config = Configuration;
        }

        public int Save(UserEntity user = null)
        {
            if (user != null && user.id == 0)
            {
                context.Users.Add(user);
            }

            return context.SaveChanges();
        }

        public UserEntity GetById(int id)
        {
            return context.Users.Where(w => w.id == id).FirstOrDefault();
        }

        public UserEntity GetByLogin(string username)
        {
            return context.Users.Where(w => w.username == username).FirstOrDefault();
        }

        public UserEntity GetByEmail(string email)
        {
            return context.Users.Where(w => w.email == email).FirstOrDefault();
        }

        public UserEntity GetByCell(long cell)
        {
            return context.Users.Where(w => w.cell == cell).FirstOrDefault();
        }

        public bool Delete(UserEntity user)
        {
            var result = context.Users.Remove(user);
            this.Save();

            return result != null ? true : false;
        }

        public UserEntity ContainsEmail(string email)
        {
            return context.Users.Where(w => w.email == email).FirstOrDefault();            
        }

        public UserEntity ContainsLogin(string login)
        {
            return context.Users.Where(w => w.username == login).FirstOrDefault();
        }

        public UserEntity ContainsCell(long cell)
        {
            return context.Users.Where(w => w.cell == cell).FirstOrDefault();
        }
    }
}
