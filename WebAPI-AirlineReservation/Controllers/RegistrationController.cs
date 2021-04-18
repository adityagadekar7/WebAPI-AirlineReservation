using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; //need to install first
using System.IO;
using WebAPI_AirlineReservation.Models;  // for database
using System.Web.Http.Cors; //for enabling cors
using System.Text;
using System.Net.Mail;
using System.Runtime;

namespace WebAPI_AirlineReservation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Registration")]
    public class RegistrationController : ApiController
    {
        AirlineDBEntities db = new AirlineDBEntities();
        //Login
        [Route("api/Registration/Login/{UserId}/{pwd}")]
        [HttpGet]
        public string Get(int UserId, string pwd)
        {
            string result = "";
            try
            {
                pwd = Convert.ToBase64String
                   (System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(pwd)));
                var data = db.User_Registration.Where(x => x.User_Id == UserId && x.Password == pwd);
                if (data.Count() == 0)
                    result = "Invalid Credentials";
                else
                    result = "Login Successful";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        [Route("api/Registration/register")]
        [HttpPost]
        public bool Post([FromBody] User_Registration ur)
        {
            try
            {
                ur.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(ur.Password)));
                db.User_Registration.Add(ur);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
        [Route("api/Registration/CheckEmail/{email}")]
        [HttpGet]
        public string Get(string email)
        {
            string result = "";
            try
            {
                var data = db.User_Registration.Where(x => x.EmailID == email).FirstOrDefault();
                if (data != null)
                {
                    result = "success";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        [Route("api/Registration/VerifyLinkEmail")]
        [HttpPost]
        public string post([FromBody] User_Registration stud)
        {
            string result = "";
            try
            {
                var data = db.User_Registration.Where(x => x.EmailID == stud.EmailID).FirstOrDefault();
                if (data == null)
                    return result;
                string OTP = GeneratePassword();
                data.ActivationCode = Guid.NewGuid();
                data.OTP = OTP;
                db.Entry(data).State = System.Data.EntityState.Modified;
                var res = db.SaveChanges();
                if (res > 0)
                {
                    ForgetPasswordEmailToUser(data.EmailID, data.ActivationCode.ToString(), data.OTP);
                    result = "success";
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GeneratePassword()                //Generates OTP for ForgotPassword
        {
            string OTPLength = "4";
            string OTP = string.Empty;

            string Chars = string.Empty;
            Chars = "1,2,3,4,5,6,7,8,9,0";

            char[] seplitChar = { ',' };
            string[] arr = Chars.Split(seplitChar);
            string NewOTP = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(OTPLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                NewOTP += temp;
                OTP = NewOTP;
            }
            return OTP;
        }

        public void ForgetPasswordEmailToUser(string emailid, string activationCode, string OTP)
        {

            var GenarateUserVerificationLink = "//localhost:4200/resetpassword/";

            /*
            var GenarateUserVerificationLink= "//localhost:4200/PassRest/" + activationCode;
            string current_url = System.Web.HttpContext.Current.Request.Url.ToString();
            var link = System.Web.HttpContext.Current.Request.Url.ToString().Replace(current_url,GenarateUserVerificationLink);*/

            var link = GenarateUserVerificationLink;

            var fromMail = new MailAddress("projteam23@gmail.com", "santhoshsanta"); //enter your mail id
            var fromEmailpassword = "8940754107"; // Set your email password
            var toEmail = new MailAddress(emailid);

            var smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Password reset code";
            Message.Body = "< br /> Please click on the below link for password change " + "<br/><a href=" + link + ">" + link + "</a>" +
              "<br/> OTP for password change : " + OTP;
            Message.IsBodyHtml = true;

            smtp.Send(Message);
        }

        [Route("api/Registration/SetNewPassword")]
        [HttpPost]
        public bool Put([FromBody] User_Registration stud)
        {
            bool result = false;
            try
            {
                string otp = stud.OTP; ;
                string NewPass = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(stud.Password)));

                var res = db.sp_UpdatePassword(otp, NewPass);
                if (res > 0)
                {
                    result = true;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


    }

}
