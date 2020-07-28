using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BankAccountWeek2
{
    class Customer
    {

        private static int _idNumber = 1;
        private string _firstName;
        private string _lastName;
        private string _email;

        public string Id
        { get; set; }

        public string Password { get; set; }

        public Customer()
        {
           
            this.Id = _idNumber.ToString();
            _idNumber++;
        }

        

        public string FirstName
        {
            get { return this._firstName;}
            set
           {
                if (String.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentNullException(nameof(_firstName), "FirstName cannot be empty");
                }
                this._firstName = value;
            }
        }

        public string LastName
        {
            get { return this._lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentNullException(nameof(_lastName), "LastName cannot be empty");
                }
                this._lastName = value;
            }
        }

        public string Email
        {
            get { return this._email; }
            set
            {
                if (String.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentNullException(nameof(_email), "Email cannot be empty");
                }
                this._email = value;
            }
        }

        public string FullName()
        {
            return ($"{FirstName} {LastName}");
        }

    }
}
