using System;

namespace OnlineStore
{
    public class Order
    {
        public string Paylink { get; private set; }

        public Order(Action onPaySucced)
        {
            Random random = new Random();
            onPaySucced.Invoke();
            Paylink = "www.something-order.com/" + random.Next(9999999);
        }
    }
}