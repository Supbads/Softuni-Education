using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_2.Customer
{
    public class Customer : ICloneable
    {
        # region fields
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private readonly string PermanentAddress;
        private string mobilePhone;
        private string email;
        private IList<Payment> payments;
        private CustomerType customerType;
        # endregion

        # region constructor
        public Customer(string firstName, string middleName, string lastName, string id, string permanentAddress, string mobilePhone, string email, IList<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }
        # endregion

        # region properties
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public IList<Payment> Payments
        {
            get { return payments; }
            set { payments = value; }
        }

        public CustomerType CustomerType
        {
            get { return customerType; }
            set { customerType = value; }
        }
        # endregion

        # region methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Customer: {0} {1} {2}", firstName, middleName, lastName).AppendLine();
            sb.Append("ID: " + id).AppendLine();
            sb.Append("Permanent adress: " + PermanentAddress).AppendLine();
            sb.Append("Mobile phone: " + mobilePhone).AppendLine();
            sb.Append("Email: " + email).AppendLine();
            sb.Append("Customer type: " + customerType).AppendLine();
            sb.Append("Payments: ");
            foreach (Payment payment in payments)
            {
                sb.AppendFormat("Product: {0} costs:{1} ", payment.ProductName, payment.Price);
            }
            sb.AppendLine();
            
            return sb.ToString();
        }

        public object Clone()
        {
            List<Payment> clonedPayments = payments.Select(payment => new Payment(payment.ProductName, payment.Price)).ToList();

            var clonedCustomer = new Customer(firstName, middleName, lastName, id, PermanentAddress, mobilePhone, email,
                clonedPayments, customerType);
            return clonedCustomer;
        }

        public int CompareTo(Customer other)
        {
            if (this.FirstName != other.FirstName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            return this.Id.CompareTo(other.Id);
        }

        protected bool Equals(Customer other)
        {
            return string.Equals(FirstName, other.FirstName) && string.Equals(MiddleName, other.MiddleName) && string.Equals(LastName, other.LastName) && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Customer)obj);
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return Equals(customer1, customer2);
        }
        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !Equals(customer1, customer2);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^
                this.MiddleName.GetHashCode() ^
                this.LastName.GetHashCode() ^
                this.Id.GetHashCode() ^
                this.PermanentAddress.GetHashCode() ^
                this.MobilePhone.GetHashCode() ^
                this.Email.GetHashCode() ^
                this.Payments.GetHashCode() ^
                this.CustomerType.GetHashCode();
        }
        # endregion
    }
}
