using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public class CoinAcceptor
    {
        private List<decimal> _acceptedCoins;
        private decimal _total;

        public List<decimal> AcceptedCoins => _acceptedCoins;
        public decimal Total => _total;

        public event EventHandler<decimal> CoinInserted;

        public void Setup(decimal coin)
        {
            if (AcceptedCoins == null)
            {
                _acceptedCoins = new List<decimal>();
            }
            _acceptedCoins.Add(coin);
        }

        public void Insert(decimal v)
        {
            _total += v;
            CoinInserted?.Invoke(this, v);
        }

        public decimal Empty()
        {
            var total = _total;
            _total = 0;
            return total;
        }
    }
}
