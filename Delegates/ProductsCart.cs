namespace Delegates
{
    public partial class Program
    {
        internal class ProductsCart
        {
            private List<Product> _products;
            private Notify _notify;

            public ProductsCart(Notify notify) : this()
            {
                _notify = notify;
            }

            public ProductsCart()
            {
                _products = new List<Product>();
            }

            public void Add(Product newProduct)
            {
                if (newProduct == null)
                {
                    _notify?.Invoke("product cannot be null!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(newProduct.Name))
                {
                    _notify?.Invoke("product cannot be null or whitespase!");
                    return;
                }

                if (IsProductExists(newProduct))
                {
                    _notify?.Invoke($">{newProduct}< is on the list!");
                    return;
                }

                _products.Add(newProduct);
            }

            internal Product? Find(ProductChecker checker)
            {
                foreach (var product in _products)
                {
                    if (checker(product))
                    {
                        return product;
                    }
                }

                return null;
            }

            private bool IsProductExists(Product newProduct)
            {
                foreach (var product in _products)
                {
                    if (newProduct.Name == product.Name)
                    {
                        return true;
                    }
                }

                return false;
            }

            internal string GetProducts()
            {
                return string.Join("\n", _products);
            }

            internal void SetNotifier(Notify notify)
            {
                _notify = notify;
            }
        }
    }
}