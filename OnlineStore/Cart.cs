using System;
using System.Collections.Generic;

namespace OnlineStore
{
    public class Cart : IShowable
    {
        private readonly IItemTakeable _storage;
        private readonly Dictionary<Good, int> _cartGoods = new Dictionary<Good, int>();
        public Cart(IItemTakeable warehouse)
        {
            _storage = warehouse ?? throw new ArgumentNullException("Argument is null", nameof(warehouse));
        }

        public void Add(Good good, int amount)
        {
            if (good == null)
                throw new ArgumentNullException("Argument is null", nameof(good));
            
            if (_storage.IsAvailable(good, amount) == false)
            {
                string errorMessage =
                    $"Невозможно добавить {good} ({amount}) шт.: Отсутствует в таком количестве на складе";
                
                ShowMessage(errorMessage);
            }
            else
            {
                string goodInfo = $"Товар {good} ({amount}) шт.: Добавлен в корзину";
                
                _cartGoods.Add(good, amount);
                
                ShowMessage(goodInfo);
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
                _storage.Remove(cartGood.Key, cartGood.Value);
            }
            
            _cartGoods.Clear();
        }
        
        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}