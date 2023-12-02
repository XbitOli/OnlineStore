using System;
using System.Collections.Generic;

namespace OnlineStore
{
    public class Cart : IShowable
    {
        private readonly Warehouse _warehouse;
        private Dictionary<Good, int> _cartGoods = new Dictionary<Good, int>() { };
        public Cart(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException("Argument is null", nameof(warehouse));
            
            _warehouse = warehouse;
        }

        public void Add(Good good, int amount)
        {
            if (good == null)
                throw new ArgumentNullException("Argument is null", nameof(good));
            
            if (_warehouse.IsAvailable(good, amount))
            {
                string goodInfo = $"Товар {good} ({amount}) шт.: Добавлен в корзину";
                
                _cartGoods.Add(good, amount);
                
                ShowMessage(goodInfo);
            }
            else
            {
                ShowMessage($"Невозможно добавить {good} ({amount}) шт.: Отсутствует в таком количестве на складе");
            }
        }

        public Order CreateOrder()
        {
            if (_cartGoods.Count <= 0)
            {
                throw new InvalidOperationException("Cart must be more than 0");
            }
            
            return new Order(PaySuccess);
        }

        public void Show()
        {
            string cartHeader = new String('-', 10) + "КОРЗИНА" + new String('-', 10);
            string cartFooter = new String('-', cartHeader.Length);

            ShowMessage(cartHeader);

            if (_cartGoods.Count <= 0)
            {
                ShowMessage("В корзине нет товаров");
            }
            else
            {
                foreach (var good in _cartGoods)
                {
                    string goodInfo = $"Товар {good} Количество {good.Value} шт.";
                    
                    ShowMessage(goodInfo);
                }
            }
            
            ShowMessage(cartFooter);
        }

        private void PaySuccess()
        {
            foreach (var cartGood in _cartGoods)
            {
                _warehouse.Remove(cartGood.Key, cartGood.Value);
            }
            
            _cartGoods.Clear();
        }
        
        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}