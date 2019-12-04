using System;

namespace Model
{
    public class Rack
    {
        private Product _product;
        private int _maxCount;
        private int _count;

        public Rack(int maxCount)
        {
            _maxCount = maxCount;
        }

        public Product Product
        {
            get
            {
                return _product;
            }
        }
        public int MaxCount
        {
            get
            {
                return _maxCount;
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Stock(Product product, int count)
        {
            if((product.Name!=_product?.Name || product.Price != _product?.Price) && _count!=0)
            {
                throw new InvalidOperationException("You cannot add another product to the rack that has another product in stock.");
            }
            if (_count + count > _maxCount)
            {
                throw new InvalidOperationException("You cannot add products to the rack that are more than the maximum allowed.");
            }
            if (count < 1)
            {
                throw new InvalidOperationException("You actually have to put something in the rack if you want sales");
            }
            _product = product;
            _count += count;
        }

        public int Empty()
        {
            var count = _count;
            _count = 0;
            return count;
        }
    }
}
