using MailKit.Security;
using MimeKit;
using ScurityApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScurityApp.BLL.Helpers
{
    public class EmailHelper
    {
        private static int Asigning = 1;
        private static int Changing = 2;
        private static int Deleting = 3;

        public static async Task SendEmailForEmailAsync(Employee employee, WorkSchedule workSchedule, int action)
        {
            string fromEmail = "wazowskijmike@gmail.com";
            string password = "cmos amuu dtys ynxp";
            string messege = "";

            if (action == Asigning)
            {
                //Asigning
                messege = $"The Employee: {employee.Name} {employee.Surname}\nEmail: {employee.Email}\nHas been asigned for the shift . \nDate: {workSchedule.Day}/{workSchedule.StartTime}\nPlace: {workSchedule.SecurityObject}";
            }
            else if(action == Changing)
            {
                //Changing
                messege = $"The Employee: {employee.Name} {employee.Surname}\nEmail: {employee.Email}\nThe shift was changed. \nDate: {workSchedule.Day}/{workSchedule.StartTime}\nPlace: {workSchedule.SecurityObject}";
            }
            else
            {
                //Deleting
                messege = $"The Employee: {employee.Name} {employee.Surname}\nEmail: {employee.Email}\nThis shift was deleted \nDate: {workSchedule.Day}/{workSchedule.StartTime}\nPlace: {workSchedule.SecurityObject}";
            }


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("FitnessApp", fromEmail));
            message.To.Add(new MailboxAddress("Recipient", employee.Email));
            message.Subject = "Email Verefication";
            message.Body = new TextPart("plain")
            {
                Text = messege
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(fromEmail, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
