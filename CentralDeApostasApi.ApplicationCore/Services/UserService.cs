using CentralDeApostasApi.ApplicationCore.Entities.Enum;
using CentralDeApostasApi.ApplicationCore.Entity;
using CentralDeApostasApi.ApplicationCore.Interfaces.Service;
using CentralDeApostasApi.ApplicationCore.Services.Common;
using CentralDeApostasApi.ApplicationCore.Model;
using System;
using CentralDeApostasApi.ApplicationCore.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using CentralDeApostasApi.Infrastructure.Configuration;
using CentralDeApostasApi.ApplicationCore.Models;
using CentralDeApostasApi.ApplicationCore.Entities.ManagementSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeApostasApi.ApplicationCore.Services
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
        private IConfiguration _config;
        private readonly IUserRepository _repository;
        public UserService(IConfiguration Configuration, IUserRepository repository) : base(repository)
        {
            this._config = Configuration;
            this._repository = repository;
        }

        #region "Methods"

        #region "Public Methods"

        #region "InsertRegister Method"
        public UserModel InsertRegister(UserEntity userEntity)
        {
            UserModel userModel = new UserModel();
            try
            {
                if (this.ValidateDataUser(userModel, userEntity))
                {
                    this.InsertCreateEntity(userEntity);
                    if (this._repository.Save(userEntity) == 1)
                    {
                        this.ReturnInsertOrUpdate(userModel, userEntity);
                        return userModel;
                    }
                    else
                    {
                        userModel.message = CentralDeApostasConstants.UNEXPECTED_ERROR;
                        return userModel;
                    }
                }

                return userModel;
            }
            catch (Exception ex)
            {
                userModel.message = CentralDeApostasConstants.GENERAL_ERROR;
                userModel.log = ex.ToString();
                return userModel;
            }
        }
        #endregion

        #region "Gets Methods"

        #region "GetById Method"
        public UserModel GetById(int id)
        {
            UserModel userModel = new UserModel();
            UserEntity userEntity = this._repository.GetById(id);

            if (userEntity != null)
            {
                this.ReturnGet(userModel, userEntity);
                return userModel;
            }

            userModel.message = CentralDeApostasConstants.USER_NOM_EXISTENT;
            return userModel;
        }
        #endregion

        #region "GetByLogin Method"
        public UserModel GetByLogin(string login)
        {
            UserModel userModel = new UserModel();
            UserEntity userEntity = this._repository.GetByLogin(login);

            if (userEntity != null)
            {
                this.ReturnGet(userModel, userEntity);
                return userModel;
            }

            userModel.message = CentralDeApostasConstants.USER_NOM_EXISTENT;
            return userModel;
        }
        #endregion

        #region "GetByEmail Method"
        public UserModel GetByEmail(string email)
        {
            UserModel userModel = new UserModel();
            UserEntity userEntity = this._repository.GetByEmail(email);

            if (userEntity != null)
            {
                this.ReturnGet(userModel, userEntity);
                return userModel;
            }

            userModel.message = CentralDeApostasConstants.USER_NOM_EXISTENT;
            return userModel;
        }
        #endregion

        #region "GetByCell Method"
        public UserModel GetByCell(long cell)
        {
            UserModel userModel = new UserModel();
            UserEntity userEntity = this._repository.GetByCell(cell);

            if (userEntity != null)
            {
                this.ReturnGet(userModel, userEntity);
                return userModel;
            }

            userModel.message = CentralDeApostasConstants.USER_NOM_EXISTENT;
            return userModel;
        }
        #endregion

        #endregion

        #region "UpdateUser Method"
        public UserModel UpdateUser(UserEntity userEntity)
        {
            UserModel userModel = new UserModel();
            try
            {
                if (this.ValidateDataUser(userModel, userEntity))
                {
                    this.UpdateCreateEntity(userEntity);
                    if (this._repository.Save() == 1)
                    {
                        this.ReturnInsertOrUpdate(userModel, userEntity);
                        return userModel;
                    }
                    else
                    {
                        userModel.message = CentralDeApostasConstants.UNEXPECTED_ERROR;
                        return userModel;
                    }
                }

                return userModel;
            }
            catch (Exception ex)
            {
                userModel.message = CentralDeApostasConstants.GENERAL_ERROR;
                userModel.log = ex.ToString();
                return userModel;
            }
        }
        #endregion

        #region "Delete Method"
        public UserModel Delete(int id)
        {
            UserModel userModel = new UserModel();

            try
            {
                UserEntity userEntity = this._repository.GetById(id);
                if (this.ValidDeleteUser(userModel, userEntity))
                {
                    if (this._repository.Delete(userEntity))
                    {
                        userModel.message = CentralDeApostasConstants.DELETE_SUCCESS;
                    }
                    else
                    {
                        userModel.message = CentralDeApostasConstants.UNEXPECTED_ERROR;
                    }
                }

                return userModel;
            }
            catch (Exception ex)
            {
                userModel.message = CentralDeApostasConstants.GENERAL_ERROR;
                userModel.log = ex.ToString();
            }

            return userModel;
        }
        #endregion

        #endregion

        #region "Private Methods"

        #region "UpdateCreateEntity Method"
        private void UpdateCreateEntity(UserEntity user)
        {
            UserEntity userEntity = this._repository.GetById(user.id);

            if (userEntity != null)
            {
                userEntity.id = user.id;
                userEntity.active = user.active;
                userEntity.fullname = user.fullname;
                userEntity.username = user.username;
                userEntity.password = user.password;
                userEntity.email = user.email;
                userEntity.cell = user.cell;
                userEntity.password.MD5Cryptography();
                userEntity.changeDate = (DateTime.Now).ToString();
            }
            else
            {
                UserModel userModel = new UserModel();
                userModel.message = CentralDeApostasConstants.USER_NOM_EXISTENT;
            }
        }
        #endregion

        #region "InsertCreateEntity Method"
        private void InsertCreateEntity(UserEntity userEntity)
        {
            UserEntity user = new UserEntity();

            user = userEntity;
            user.active = ActiveEnum.True;
            user.password = userEntity.password.MD5Cryptography();
            user.guid = Guid.NewGuid();
            user.registrationDate = (DateTime.Now).ToString();
            user.changeDate = user.registrationDate;
        }
        #endregion

        #region "ReturnInsertOrUpdate Method"
        private void ReturnInsertOrUpdate(UserModel userModel, UserEntity userEntity)
        {
            userModel.id = userEntity.id;
            userModel.active = userEntity.active;
            userModel.fullname = userEntity.fullname;
            userModel.login = userEntity.username;
            userModel.email = userEntity.email;
            userModel.cell = userEntity.cell;
            userModel.changeDate = userEntity.changeDate;
            userModel.message = CentralDeApostasConstants.SAVE_SUCCESS;
        }
        #endregion

        #region "ReturnGet Method"
        public void ReturnGet(UserModel userModel, UserEntity userEntity)
        {
            userModel.id = userEntity.id;
            userModel.active = userEntity.active;
            userModel.fullname = userEntity.fullname;
            userModel.login = userEntity.username;
            userModel.email = userEntity.email;
            userModel.cell = userEntity.cell;
            userModel.registrationDate = userEntity.registrationDate;
            userModel.changeDate = userEntity.changeDate;
            userModel.message = CentralDeApostasConstants.SUCCESS;
        }
        #endregion

        #region "Validation Methods"

        #region "ValidEmail Method"
        private bool ValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".com");
        }
        #endregion

        #region "ValidCell Method"
        private bool ValidCell(long cell)
        {
            string telephone = Convert.ToString(cell);
            bool isValid = telephone.Length == 11 ? true : false;

            return isValid;
        }
        #endregion

        #region "ContainsEmail Method"
        public bool ContainsEmail(string email)
        {
            var containsEmail = this._repository.ContainsEmail(email);
            return containsEmail == null ? true : false;
        }
        #endregion

        #region "ContainsLogin Method"
        public bool ContainsLogin(string login)
        {
            var containsLogin = this._repository.ContainsLogin(login);
            return containsLogin == null ? true : false;
        }
        #endregion

        #region "ContainsCell Method"
        public bool ContainsCell(long cell)
        {
            var containsCell = this._repository.ContainsCell(cell);
            return containsCell == null ? true : false;
        }
        #endregion

        #region "ValidateDataUser Method"
        public bool ValidateDataUser(UserModel userModel, UserEntity userEntity)
        {
            bool isValid = this.ValidCell(userEntity.cell) ? true : this.Valid(userModel, CentralDeApostasConstants.INVALID_CELL);

            if (isValid)
            {
                isValid = this.ValidEmail(userEntity.email) ? true : this.Valid(userModel, CentralDeApostasConstants.INVALID_EMAIL);
            }
            if (isValid)
            {
                isValid = userEntity.id != 0 ? true :
                    !this.ContainsEmail(userEntity.email) && !this.ContainsLogin(userEntity.username) && !this.ContainsCell(userEntity.cell) ?
                    this.Valid(userModel, CentralDeApostasConstants.USER_ALREADY_REGISTERED) : true;
            }
            if (isValid)
            {
                isValid = this.ContainsEmail(userEntity.email) ? true : this.Valid(userModel, CentralDeApostasConstants.EMAIL_ALREADY_REGISTERED);
            }
            if (isValid)
            {
                isValid = this.ContainsLogin(userEntity.username) ? true : this.Valid(userModel, CentralDeApostasConstants.LOGIN_ALREADY_REGISTERED);
            }
            if (isValid)
            {
                isValid = this.ContainsCell(userEntity.cell) ? true : this.Valid(userModel, CentralDeApostasConstants.TELEPHONE_ALREADY_REGISTERED);
            }

            return isValid;
        }
        #endregion

        #region "Valid Method"
        private bool Valid(UserModel userModel, string message)
        {
            userModel.message = message;
            return false;
        }
        #endregion

        #region "ValidDeleteUser"
        private bool ValidDeleteUser(UserModel userModel, UserEntity userEntity)
        {
            if (userEntity != null)
            {
                return true;
            }

            userModel.message = CentralDeApostasConstants.USER_NOM_EXISTENT;
            return false;
        }

        #endregion

        #endregion

        #endregion

        #endregion
    }
}