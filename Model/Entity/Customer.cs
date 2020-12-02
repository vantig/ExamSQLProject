namespace ExamProject.Model.Entity
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Money { get; set; }
        private string _cardNumber;
        private string _bankAccountNumber;

        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                value = value.Trim(' ');
                if (value.Length == 16)
                {
                    _cardNumber = value;
                }
            }
        }
        public string BankAccountNumber
        {
            get => _bankAccountNumber;
            set
            {
                value = value.Trim(' ');
                if (value.Length == 20)
                {
                    _bankAccountNumber = value;
                }
            }
        }
        public Customer()
        {
        }

        public Customer(string firstName, string lastName, string address, string cardNumber, string bankAccountNumber,int money)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            CardNumber = cardNumber;
            BankAccountNumber = bankAccountNumber;
            Money = money;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Address : {Address}, Card Number :{CardNumber}, Bank Account Number :{BankAccountNumber}, Money :{Money}";
        }
    }
}
