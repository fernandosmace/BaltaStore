using BaltaStore.Domain.StoreContext.Enums;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order
    {
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        private readonly IList<OrderItem> _items = new List<OrderItem>();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();
        private readonly IList<Delivery> _deliveries = new List<Delivery>();

        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
        }

        public void AddItem(OrderItem item)
        {
            //Valida o Item
            //Adiciona ao Pedido
            _items.Add(item);
        }

        public void AddDelivery(Delivery delivery)
        {
            //Valida o Delivery
            //Adiciona ao Pedido
            _deliveries.Add(delivery);
        }

        public void Place()
        {

        }
    }
}
