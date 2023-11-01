using RebarProject.Models;
using MongoDB.Driver;

namespace RebarProject.Services
{
    public class OrderService  : IOrderService
    {
        private readonly IMongoCollection<Order> _order;

        public OrderService(IOrderStoreDatabaseSetting setting, IMongoClient mongoClient )
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _order = database.GetCollection<Order>(setting.OrderCollectionName);
        }   
        public Order Create(Order order)
        {
            _order.InsertOne(order);
            return order;
        }
        public List<Order> Get()
        {
            return _order.Find(order => true).ToList();
        }
        public Order Get(string id)
        {
            return _order.Find(order => order.id==id).FirstOrDefault();
        }
        public void Remove(string id)
        {
            _order.DeleteOne(order => order.id==id);
        }
        public void Update(string id, Order order)
        {
            _order.ReplaceOne(order => order.id == id, order);
        }
    }
}
