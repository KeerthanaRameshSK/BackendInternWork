using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DAL.Models;
using EntityLayer;



namespace DAL
{
    public class LoginDataService : IUser
    {
        private Airline_OARSContext db;
        public LoginDataService(Airline_OARSContext db)
        {
            this.db = db;
        }
        public UserModel GetValidUser(UserModel user)
        {

            UserModel udet = new UserModel();

            try
            {
                var validuser = db.Usercredentials.Where(c => c.Username == user.Username
                && c.Password == user.Password).SingleOrDefault();
                if (validuser != null)
                {
                    udet.Username = validuser.Username;
                    udet.Password = validuser.Password;
                    udet.Role = validuser.Role;
                    return udet;
                }
                else
                {
                    throw new Exception("Invalid EmailId or Password");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public SignupModel SignUp(SignupModel NewUsr)
        {
            Usercredential NewRec = new Usercredential();

            NewRec.Username = NewUsr.Username;
            NewRec.Password = NewUsr.Password;
            NewRec.Role = NewUsr.Role;
            NewRec.FirstName = NewUsr.FirstName;
            NewRec.LastName = NewUsr.LastName;
            NewRec.Email = NewUsr.Email;
            NewRec.MobileNo = NewUsr.MobileNo;


            try
            {
                if (NewUsr.Password == NewUsr.ConfirmPassword)
                {
                    db.Usercredentials.Add(NewRec);
                    int status = db.SaveChanges();

                    if (status > 0)
                    {
                        return NewUsr;
                    }
                    else
                    {
                        throw new Exception("Insertion failed");
                    }
                }
                else
                {
                    throw new Exception("Password and Confirm Password must be same");
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    throw new Exception(e.InnerException.Message);
                }
                throw new Exception(e.Message);
            }
        }
    }
}
