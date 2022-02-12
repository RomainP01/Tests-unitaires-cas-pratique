using System;

namespace EasyBank
{
    public class BankAccount
    {
        private int _id;
        private String _firstName;
        private String _lastName;
        private Double _balance;

        public BankAccount(int id, string firstName, string lastName, double balance)
        {
            this._id = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this._balance = balance;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        
        public double Balance
        {
            get => _balance;
            set => _balance = value;
        }
    }
}