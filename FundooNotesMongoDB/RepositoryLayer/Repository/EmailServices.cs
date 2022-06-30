﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Repository
{
    public class EmailServices
    {
        public static void SendMail(string email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("shaluade67@gmail.com", "lwpmbhgmrwtemnsq");
                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(email);
                msgObj.From = new MailAddress("shaluade67@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = $"www.fundoonotes.com/reset-password/{token}";
                client.Send(msgObj);
            }
        }
    }
}
