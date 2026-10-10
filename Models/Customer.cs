namespace Assessment2Task2.Models
{
    public class Customer
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }

        public Customer(int customerNo, string customerName)
        {
            CustomerNo = customerNo;
            CustomerName = customerName;
        }
    }
}