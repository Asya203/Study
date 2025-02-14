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

namespace labs3
{
    public class Client
    {
        private int id;
        private string lastName;
        private string firstName;
        private string middleName;
        private string phone;
        private string email;
        private string birthday;
        private string passport;
        private string comment;

        public Client(int id, string firstName, string lastName, string middleName, string phone, string email, string birthday, string passport, string comment)
        {
            ValidateString(firstName, "имя", 20);
            ValidateString(lastName, "фамилия", 20);
            ValidatePhone(phone);
            ValidatePassport(passport);
            ValidateString(middleName, "отчество", 20);
            ValidateString(comment, "комментарий", 500);
            ValidateDate(birthday);
            if (!IsValidEmail(email)) throw new ArgumentException("Email заполнен не корректно");
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.phone = phone;
            this.passport = passport;
            this.middleName = middleName;
            this.comment = comment;
            this.birthday = birthday;
            this.email = email;
        }

        public string GetEmail() => email;
        public string GetBirthday() => birthday;
        public string GetMiddleName() => middleName;
        public string GetComment() => comment;
        public string GetLastName() => lastName;
        public string GetFirstName() => firstName;
        public string GetPhone() => phone;
        public string GetPassport() => passport;
        public int getId() { return id; }


        public void SetLastName(string lName) { ValidateString(lName, "фамилия", 20); this.lastName = lName; }
        public void SetFirstName(string fName) { ValidateString(fName, "имя", 20); this.firstName = fName; }
        public void SetId(int newID) { if (isValidID(newID)) this.id = newID; }
        public void SetPhone(string newPhone) { ValidatePhone(newPhone); this.phone = newPhone; }
        public void SetPassport(string newPassport) { ValidatePassport(newPassport); this.passport = newPassport; }
        public void SetCommentl(string NewComment) { ValidateString(NewComment, "комментарий", 30); this.comment = NewComment; }
        public void SetMiddleName(string NewMiddlename) { ValidateString(NewMiddlename, "отчество", 100); this.middleName = NewMiddlename; }
        public void SetBirthday(string newBirthday) { ValidateDate(newBirthday); ; this.birthday = newBirthday; }
        public void SetEmail(string newEmail) { if (!IsValidEmail(email)) throw new ArgumentException("Email заполнен не корректно"); this.email = newEmail; }


        private static void ValidatePassport(string passport)
        {
            if (string.IsNullOrEmpty(passport)) throw new ArgumentException("Поле с паспортными данными не заполнено");
            if (passport.Length != 10) throw new ArgumentException("Поле с паспортными данными заполнено не корректно");
            for (int i = 0; i < passport.Length; i++)
            {
                char ch = passport[i];
                if (!isvalidNumber(ch)) throw new ArgumentException("Поле с паспортными данными заполнено не корректно");

            }
        }

        public static void ValidateString(String str, string name, int len)
        {
            if (!isValidCount(str, len)) throw new ArgumentException("В поле " + name + " превышено количество допустимых символов");
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + name + " заполнено не корректно");

            }

        }
        private static bool isValidCharacter(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') ||
                   (ch >= 'a' && ch <= 'z') ||
                   (ch >= 'А' && ch <= 'Я') ||
                   (ch >= 'а' && ch <= 'я') ||
                   (ch == 'ё' || ch == 'Ё') ||
                   (ch == ' ');
        }

        private static bool isValidCount(string str, int len) { if (str.Length > len) return false; return true; }

        private static void ValidatePhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) throw new ArgumentException("Поле с телефонными данными не заполнено");
            if (phone.Length != 11) throw new ArgumentException("Поле с телефонными данными заполнено не корректно");
            for (int i = 0; i < phone.Length; i++)
            {
                char ch = phone[i];
                if (!isvalidNumber(ch)) throw new ArgumentException("Поле с телефонными данными заполнено не корректно");

            }

        }

        public static bool isvalidNumber(char ch)
        {
            return (ch >= '0' && ch <= '9');
        }

        private bool isValidID(int id)
        {
            if (id >= 0)
            {
                return (true);
            }
            else
            {
                throw new ArgumentException("id не корректен");
            }
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
        public Client(string json)
        {
            var clientData = JsonConvert.DeserializeObject<Client>(json);

            if (clientData != null)
            {
                id = clientData.id;
                firstName = clientData.firstName;
                lastName = clientData.lastName;
                phone = clientData.phone;
                passport = clientData.passport;
                email = clientData.email;
                birthday = clientData.birthday;
                middleName = clientData.middleName;
                comment = clientData.comment;
            }
        }

        public string toJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            Client client = this;
            string jsonString = JsonConvert.SerializeObject(client, Formatting.Indented);
            return jsonString;
        }


        public int GetHashCode()
        {
            return GetPassport().GetHashCode();
        }

    }

}
