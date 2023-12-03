using System;

namespace OnlineStore
{
    public class Shop
    {
        private Warehouse _warehouse;
        private Cart _cart;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse ?? throw new ArgumentNullException("Argument is null", nameof(warehouse));
            _cart = new Cart(_warehouse);
        }

        public Cart Cart()
        {
            return _cart;
        }
    }
}