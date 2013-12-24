using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Typesafe.Mailgun;

namespace HotelEden.Utils
{
    public class Emailer
    {
        private SmtpClient smtpClient;
        private List<string> StringsToAdd;


        public Emailer()
        {
            this.smtpClient = new SmtpClient();
            this.smtpClient.Host = "smtp.mailgun.org";
            this.smtpClient.Credentials = new NetworkCredential { UserName = "postmaster@app11597.mailgun.org", Password = "7nj0pp00nu78", Domain = "app11597.mailgun.org" };
            this.smtpClient.UseDefaultCredentials = false;
            this.smtpClient.Port = 587;
            this.StringsToAdd = new List<string>();
        }


        public void SetListOfStrings(List<string> list)
        {
            this.StringsToAdd = list;
        }


        public void AddString(string s)
        {
            this.StringsToAdd.Add(s);
        }


        public void SendEmail()
        {
            var client = new MailgunClient("app11597.mailgun.org", "key-4iy0ndobwhtrtu82rum2xb-xeyf71ye1");


            MailMessage email = new MailMessage();
            email.IsBodyHtml = true;
            email.From = new MailAddress("hostaleleden@app11597.mailgun.org");
            email.To.Add("gabosom@gmail.com");
            email.Subject = "Reservation test";
            email.Body = "<h1>Scheduling report</h1>";


            email.Body += "<ul>";
            foreach (string s in this.StringsToAdd)
                email.Body += "<li>" + s + "</li>";
            email.Body += "</ul>";




            client.SendMail(email);
            Console.WriteLine("Email done: ");
            //WebClient webClient = new WebClient();
            //string parameters = "";
            //Dictionary<string, string> emailValues = new Dictionary<string, string>();
            //emailValues.Add("from", "postmaster@app1073.mailgun.org");
            //emailValues.Add("to", "gabosom@gmail.com");
            //emailValues.Add("subject", "Scheduling");
            //emailValues.Add("html", "This is awesome");


            //foreach (KeyValuePair<string, string> kvp in emailValues)
            //    parameters += kvp.Key + "=" + kvp.Value + "&";


            //parameters = parameters.Substring(0, parameters.Length - 1);
            //Console.WriteLine(parameters);


            //webClient.UploadStringCompleted += new UploadStringCompletedEventHandler(
            //    (s, eventArgs) =>
            //    {
            //        //TODO: whatever needs to happen here
            //        Console.WriteLine("Email done: " + eventArgs.Result);
            //    });


            //webClient.UseDefaultCredentials = false;
            //webClient.Credentials = new NetworkCredential("api", "key-10bhh1qyq096-bqt5p8ihhn-nxtqqmg8");
            //webClient.UploadStringAsync(new Uri("https://api.mailgun.net/v2/app1073.mailgun.org/messages"), parameters);


            //webClient.UploadStringAsync(new Uri("https://api:key-10bhh1qyq096-bqt5p8ihhn-nxtqqmg8@api.mailgun.net/v2/app1073.mailgun.org/messages"), parameters);





            //smtpClient.Send(email);
        }
    }

}