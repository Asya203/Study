using System;
using labs3;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.Graph.Models.Security;
using Microsoft.Graph.Models;

namespace labs3
{
    public class Client : ShortClient
    {
        public string middleName;
        public string comment;
        public string email;
        public string birthday;

        public Client(int id, string firstName, string lastName, string middleName, string phone, string email, string birthday, string passport, string comment) : base(id, firstName, lastName, phone, passport)
        {
            ValidateFields(middleName, comment, email, birthday);
            this.middleName = middleName;
            this.comment = comment;
            this.birthday = birthday;
            this.email = email;
        }
        private static void ValidateFields(string middleName, string comment, string email, string birthday)
        {
            ValidateString(middleName, "отчество", 20);
            ValidateString(comment, "комментарий", 100);
            ValidateDate(birthday);
            if (!IsValidEmail(email)) throw new ArgumentException("Email заполнен не корректно");
        }

        public static void ValidateDate(string date)
        {
            DateOnly dDate;
            if (!DateOnly.TryParse(date, out dDate)) throw new ArgumentException("Дата заполнена не корректно");
        }
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public string GetEmail() => email;
        public string GetBirthday() => birthday;
        public string GetMiddleName() => middleName;
        public string GetComment() => comment;

        public void SetCommentl(string NewComment) { ValidateString(NewComment, "комментарий", 100); this.comment = NewComment; }
        public void SetMiddleName(string NewMiddlename) { ValidateString(NewMiddlename, "отчество", 20); this.middleName = NewMiddlename; }
        public void SetBirthday(string newBirthday) { ValidateDate(newBirthday); ; this.birthday = newBirthday; }
        public void SetEmail(string newEmail) { if (!IsValidEmail(email)) throw new ArgumentException("Email заполнен не корректно"); this.email = newEmail; }

        public bool ClientEquals(object obj)
        {
            if (obj is ShortClient othershClient)
            {
                return this.GetPassport() == othershClient.GetPassport();
            }
            else return false;

        }

        public override int GetHashCode()
        {
            return GetPassport().GetHashCode();
        }

        public Client(string json) : base(json)
        {
            var clientData = JsonConvert.DeserializeObject<Client>(json);

            if (clientData != null)
            {
                email = clientData.email;
                birthday = clientData.birthday;
                middleName = clientData.middleName;
                comment = clientData.comment;
            }
        }

        public override string toMyString()
        {

            return "Client {" + "\n" +
                    "   id = " + id + "\n" +
                    "   Firstname = " + firstName + "\n" +
                    "   Lastname = " + lastName + "\n" +
                    "   MiddleName = " + middleName + "\n" +
                    "   Phone = " + phone + "\n" +
                    "   Email = " + email + "\n" +
                    "   Birthday = " + birthday + "\n" +
                    "   Passport = " + passport + "\n" +
                    '}';
        }

        public string toJson()
        {

            var options = new JsonSerializerOptions { WriteIndented = true };
            Client client = this;
            string jsonString = JsonConvert.SerializeObject(client, Formatting.Indented);
            return jsonString;
        }
        public string shortInfo()
        {
            return "Client {" + "\n" +
                    "\"id\": \"" + getId() + "\",\n" +
                    "\"firstName\": \"" + GetFirstName() + "\",\n" +
                    "\"lastName\": \"" + GetLastName() + "\",\n" + "}";

        }

        public string shortInfoNew()
        {
            return base.toMyString();

        }
    }
}
