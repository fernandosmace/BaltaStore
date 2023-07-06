using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();
        private readonly IList<Address> _addresses;

        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public void AddAddress(Address address)
        {
            //Validar Endereço

            //Adicionar Endereço
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
