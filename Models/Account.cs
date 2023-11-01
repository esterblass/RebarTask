namespace RebarProject.Models
{
    public class Account
    {
        public List<Order> ordersList { get; set; }
        public int amount { get; set; }

        public string password = "1234567";

        public Account()
        {
            ordersList = new List<Order>();
            amount = 0;
            foreach (Order o in ordersList)
            {
                amount += o.amount;
            }

        }
        public void AddOrder(Order order)
        {
            ordersList.Add(order);
            amount += order.amount;
        }

    }
}
