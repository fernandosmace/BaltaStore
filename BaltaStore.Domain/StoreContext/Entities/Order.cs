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
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
        }

        public void AddItem(OrderItem item)
        {
            //Valida o Item
            //Adiciona ao Pedido
            _items.Add(item);
        }

        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        public void Ship()
        {
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }

                count++;
            }

            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}
