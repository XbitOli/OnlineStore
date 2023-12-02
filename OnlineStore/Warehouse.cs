using System;
using System.Collections.Generic;

namespace OnlineStore
{
    public class Warehouse : IShowable 
    {
        private Dictionary<Good, int> _goods = new Dictionary<Good, int>() { };
        
        public Warehouse()
        { }

        public void Delive(Good good, int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Argument less than zero", nameof(amount));

            if (good == null)
                throw new ArgumentNullException("Argument is null", nameof(good));

            if (_goods.ContainsKey(good))
                _goods[good] += amount;
            else
                _goods.Add(good, amount);

            ShowMessage($"Товар [{good}] {amount} шт. доставлен");
        }

        public bool IsAvailable(Good good, int amount)
        {
            if (!_goods.ContainsKey(good))
            {
                ShowMessage("Такого товара нет не складе");
                return false;
            }

            if (amount == 0)
            {
                ShowMessage("Количество покупаемых предметов должно быть больше 0");
                return false;
            }

            if (_goods[good] <= amount)
            {
                return false;
            }

            return true;
        }

        public void Remove(Good good, int amount)
        {
            _goods[good] -= amount;
        }
        
        public void Show()
        {
            string warehouseHeader = new String('-', 10) + "СКЛАД: " + new String('-', 10);
            string warehouseFooter = new String('-',  warehouseHeader.Length);
            
            ShowMessage(warehouseHeader);
            if (_goods.Count <= 0)
            {
                ShowMessage("Нет товаров на складе");
            }
            else
            {
                foreach (var good in _goods)
                {
                    string goodInfo =$"Товар {good} Количество:{ good.Value }";
                    ShowMessage(goodInfo);
                }
            }
            ShowMessage(warehouseFooter);
        }

        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}