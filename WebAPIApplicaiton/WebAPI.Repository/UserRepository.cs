using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class UserRepository
    {
        private WebAPIDBEntities db;

        public ResponseModel GetUserList()
        {
            db = new WebAPIDBEntities();
            db.Database.CommandTimeout = 1800;

            ResponseModel response = new ResponseModel
            {
                status = false,
                message = string.Empty,
            };

            try
            {
                List<UserModel> userList = db.tbl_Users.Where(x => x.IsAdmin == false).Select(u => new UserModel
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    Email = u.Email,
                    FullAddress = u.Address + " ," + u.CityName + " ," + u.StateName + " ," + u.CountryName,
                    IsActive = (bool)u.IsActive
                }).ToList();

                response.status = true;
                response.message = "Success.";
                response.data = userList;

            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Fail.";
            }

            return response;
        }

        public ResponseModel AddUser(UserModel userData)
        {
            db = new WebAPIDBEntities();
            db.Database.CommandTimeout = 1800;

            ResponseModel response = new ResponseModel
            {
                status = false,
                message = string.Empty,
            };

            try
            {
                tbl_Users user = new tbl_Users
                {
                    UserId = Guid.NewGuid(),
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Email = userData.Email,
                    Password = userData.Password,
                    PhoneNumber = userData.PhoneNumber,
                    Address = userData.Address,
                    CityId = userData.CityId,
                    CityName = userData.CityName,
                    StateId = userData.StateId,
                    StateName = userData.StateName,
                    CountryId = userData.CountryId,
                    CountryName = userData.CountryName,
                    IsActive = true,
                    IsAdmin = userData.IsAdmin,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                db.tbl_Users.Add(user);
                db.SaveChanges();

                response.status = true;
                response.message = "Success.";

            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Fail.";
            }

            return response;
        }

        public ResponseModel UpdateUserStatus(UserModel userData)
        {
            db = new WebAPIDBEntities();
            db.Database.CommandTimeout = 1800;

            ResponseModel response = new ResponseModel
            {
                status = false,
                message = string.Empty,
            };

            try
            {
                tbl_Users user = db.tbl_Users.Where(x => x.UserId == userData.UserId).FirstOrDefault();

                if (user != null)
                {
                    user.IsActive = userData.IsActive;
                    db.SaveChanges();

                    response.status = true;
                    response.message = "Success.";
                }
                else
                {
                    response.status = false;
                    response.message = "User data not found.";
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = "Fail.";
            }

            return response;
        }

        public tbl_Users GetUserByCredentials(string email, string password)
        {
            db = new WebAPIDBEntities();
            db.Database.CommandTimeout = 1800;

            tbl_Users user = null;
            try
            {
                user = db.tbl_Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public bool CheckUserExist(string email)
        {
            db = new WebAPIDBEntities();
            db.Database.CommandTimeout = 1800;

            bool isExist = false;
            try
            {
                tbl_Users user = db.tbl_Users.Where(x => x.Email == email).FirstOrDefault();
                if (user != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isExist;
        }

        public List<tbl_CityMaster> GetCityList()
        {
            db = new WebAPIDBEntities();
            db.Database.CommandTimeout = 1800;

            List<tbl_CityMaster> lst = new List<tbl_CityMaster>();
            try
            {
                lst = db.tbl_CityMaster.Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public List<tbl_StateMaster> GetStateList()
        {
            db = new WebAPIDBEntities();
            db.Database.CommandTimeout = 1800;

            List<tbl_StateMaster> lst = new List<tbl_StateMaster>();
            try
            {
                lst = db.tbl_StateMaster.Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }

        public List<tbl_Country> GetCountryList()
        {
            db = new WebAPIDBEntities();
            db.Database.CommandTimeout = 1800;

            List<tbl_Country> lst = new List<tbl_Country>();
            try
            {
                lst = db.tbl_Country.Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lst;
        }
    }
}
