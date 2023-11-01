using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static MongoDB.Driver.WriteConcern;

namespace RebarProject.Models
{
    public class Order
    {
        public static Account account = new Account();


        [BsonElement("shakesList")]
        public List<ShakeForOrder> shakesList { get; set; }

        [BsonElement("shakesListAmount")]
        public int amount { get; set; }

        [BsonElement("id")]
        public string id { get; set; }=Guid.NewGuid().ToString();

        [BsonElement("customerName")]
        public string customerName { get; set; }

        [BsonElement("orderTimeCreate")]
        public DateTime orderTimeCreate { get; set; }

        [BsonElement("orderTimeReady")]
        public DateTime orderTimeReady { get; set; }

        [BsonElement("salePercent")]
        public List<Sale> salePercent { get; set; }



        public Order(List<ShakeForOrder> shakes, string name)
        {
            id = Guid.NewGuid().ToString();
            shakesList = shakes;
            customerName = name;
            orderTimeCreate = DateTime.Now;
            orderTimeReady = orderTimeCreate;
            amount = 0;
            foreach (ShakeForOrder s in shakesList)
            {
                amount += s.price;
            }

        }
        public Order(List<ShakeForOrder> shakes, string name, List<Sale> sale)
        {
            id = Guid.NewGuid().ToString();
            shakesList = shakes;
            customerName = name;
            orderTimeCreate = DateTime.Now;
            orderTimeReady = orderTimeCreate;
            salePercent = sale;
            amount = 0;
            foreach (ShakeForOrder s in shakesList)
            {
                amount += s.price;
            }
            foreach (Sale s in salePercent)
            {
                amount *= (100 - s.percent) / 100;
            }
        }

        public static Order CreateOrder()
        {
            Console.WriteLine("Enter name for the order:");
            string customerName = Console.ReadLine();
            List<ShakeForOrder> shakesList = new List<ShakeForOrder>();
            int count = 1;
            string shakeName;
            do
            {
                Console.WriteLine("Enter shake name for the order, press 0 to finish:");
                shakeName = Console.ReadLine();
                if (shakeName == "0")
                    break;
                if (!Menu.menu.Exists(m => m.name == shakeName))
                {
                    Console.WriteLine("The name of the shake does not exist in the menu, please enter a valid name");
                    continue;
                }

                Console.WriteLine("Enter shake size for the order (l, m, s):");
                String size = Console.ReadLine();
                if (!(size == "l" || size == "m" || size == "s"))
                {
                    Console.WriteLine("size incorrect, please enter again:");
                    size = Console.ReadLine();
                }
                ShakeForOrder s = new ShakeForOrder(shakeName, size);
                shakesList.Add(s);
            } while (count <= 10 || shakeName != "0");
            Order order = new Order(shakesList, customerName);

            account.AddOrder(order);

            return order;
        }

        public void closingCheckout(string password)
        {
            if (password != account.password)
            {
                Console.WriteLine("The password incorrect");
                return;
            }
            int count = 0;
            int amount = 0;
            foreach(Order o in account.ordersList)
            {
                if (o.orderTimeCreate == DateTime.Today)
                {
                    count++;
                    amount += o.amount;
                }
            }
            Console.WriteLine($"Number of orders made today: {count} ");
            Console.WriteLine($"Amount of orders made today: {amount} ");

        }

    }
}
