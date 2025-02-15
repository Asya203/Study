using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace labs3
{
    public class ShortClient
    {
        private int id;
        private string lastName;
        private string firstName;
        private string phone;
        private string passport;

        public ShortClient(int id, string firstName, string lastName, string phone, string passport)
        {
            ValidateString(firstName, "имя", 20);
            ValidateString(lastName, "фамилия", 20);
            ValidatePhone(phone);
            ValidatePassport(passport);
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.phone = phone;
            this.passport = passport;
        }

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


        public virtual string toMyString()
        {
            return "Client {" + "\n" +
                    "   id= " + id + "\n" +
                    "   Firstname = " + firstName + "\n" +
                    "   Lastname = " + lastName + "\n" +
                    "   Phone = " + phone + "\n" +
                    "   Passport = " + passport + "\n" + "}";

        }

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

        public ShortClient(string json)
        {
            var clientData = JsonSerializer.Deserialize<ShortClient>(json);

            if (clientData != null)
            {
                id = clientData.id;
                firstName = clientData.firstName;
                lastName = clientData.lastName;
                phone = clientData.phone;
                passport = clientData.passport;
            }
        }
    }
}
