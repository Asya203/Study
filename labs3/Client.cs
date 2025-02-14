using labs3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            ValidatePhone(phone);
            ValidatePassport(passport);
            for (int i = 0; i < firstName.Length; i++)
            {
                char ch = firstName[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + firstName + " заполнено не корректно");

            }
            for (int i = 0; i < lastName.Length; i++)
            {
                char ch = lastName[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + lastName + " заполнено не корректно");

            }
            for (int i = 0; i < middleName.Length; i++)
            {
                char ch = middleName[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + middleName + " заполнено не корректно");

            }
            for (int i = 0; i < comment.Length; i++)
            {
                char ch = comment[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + comment + " заполнено не корректно");

            }
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


        public void SetLastName(string lName)
        {
            for (int i = 0; i < lName.Length; i++)
            {
                char ch = lName[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + lName + " заполнено не корректно");

            }
            this.lastName = lName;
        }
        public void SetFirstName(string fName)
        {
            for (int i = 0; i < fName.Length; i++)
            {
                char ch = fName[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + fName + " заполнено не корректно");

            }
            this.firstName = fName;
        }
        public void SetId(int newID) { if (isValidID(newID)) this.id = newID; }
        public void SetPhone(string newPhone) { ValidatePhone(newPhone); this.phone = newPhone; }
        public void SetPassport(string newPassport) { ValidatePassport(newPassport); this.passport = newPassport; }
        public void SetCommentl(string NewComment)
        {
            for (int i = 0; i < NewComment.Length; i++)
            {
                char ch = NewComment[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + NewComment + " заполнено не корректно");

            }
            this.comment = NewComment;
        }
        public void SetMiddleName(string NewMiddlename)
        {
            for (int i = 0; i < NewMiddlename.Length; i++)
            {
                char ch = NewMiddlename[i];
                if (!isValidCharacter(ch)) throw new ArgumentException("Поле " + NewMiddlename + " заполнено не корректно");

            }
            this.middleName = NewMiddlename;
        }
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


        public int GetHashCode()
        {
            return GetPassport().GetHashCode();
        }

    }

}
