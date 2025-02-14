using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs3
{
    internal class Client
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


        public void SetLastName(string lName) { this.lastName = lName; }
        public void SetFirstName(string fName) { this.firstName = fName; }
        public void SetId(int newID) { this.id = newID; }
        public void SetPhone(string newPhone) { this.phone = newPhone; }
        public void SetPassport(string newPassport) { this.passport = newPassport; }
        public void SetCommentl(string NewComment) { this.comment = NewComment; }
        public void SetMiddleName(string NewMiddlename) { this.middleName = NewMiddlename; }
        public void SetBirthday(string newBirthday) { this.birthday = newBirthday; }
        public void SetEmail(string newEmail) { this.email = newEmail; }

        public int GetHashCode()
        {
            return GetPassport().GetHashCode();
        }

    }

}
