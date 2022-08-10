namespace Delegates
{
    internal delegate void Notify(string messege);
    internal delegate void Action(string messege, int number);
    internal delegate bool Checker(string product);
    internal delegate bool ProductChecker(Product product);


    public partial class Program
    {
        //private static Notify? _notify;

        static void Main(string[] args)
        {
            var cart = new ProductsCart(messege => Console.WriteLine(messege));

            cart.Add(new Product("Cheese", 100));
            cart.Add(new Product("Bread", 120));
            cart.Add(new Product("Milk", 700));

            var product1 = cart.Find(x => x.Name == "Bread");
            var product2 = cart.Find(x => x.Price > 500);

            Console.WriteLine(product1?.Name);

            Console.WriteLine(product2?.Name);

            List<Product> products = new List<Product>
            {
                new Product("Cheese", 100),
                new Product("Bread", 120),
                new Product("Milk", 700)
            };

            product1 = products.Find(x => x.Name == "Bread");
            product2 = products.Find(x => x.Price > 500);

            Console.WriteLine(product1?.Name);
            Console.WriteLine(product2?.Name);

            product1 = products.FirstOrDefault(x => x.Name == "Bread");
            product2 = products.FirstOrDefault(x => x.Price > 500);

            Console.WriteLine(product1?.Name);
            Console.WriteLine(product2?.Name);
        }

        private static void CartWithLambda()
        {
            var cart = new Cart();
            cart.Add("Cheese");
            cart.Add("Bread");
            cart.Add("Milk");

            var product = cart.Find(x => x == "Bread");
            Console.WriteLine(product);
        }

        private static void Closure()
        {
            var date = DateTime.Now;

            Notify notifyError = delegate (string messege)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(date + ": " + messege);
                Console.ResetColor();
            };

            notifyError += messege =>
            {
                Console.WriteLine(date + ": " + messege);
            };

            var catr = new Cart(notifyError);

            catr.Add(" ");
        }

        private static void LambdaExpressions2()
        {
            var catr = new Cart();
            catr.SetNotifier(messege => Console.WriteLine(messege));
            catr.Add(" ");
        }

        private static void LambdaExpressions()
        {
            Notify notifyError = messege =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(messege);
                Console.ResetColor();
            };

            notifyError("Error messege");
        }

        private static void AnnonimousDelegate()
        {
            Notify notifyError = delegate (string messege)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(messege);
                Console.ResetColor();
            };

            Action action = delegate (string a, int b)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(a + b);
                Console.ResetColor();
            };

            action("Number: ", 10);

            notifyError("TestDelegates error message");
            TestDelegatUsage();
        }

        private static void TestDelegatUsage()
        {
            Notify notify = PrintErrorMessege;
            notify += PrintFileMessege;
            notify += delegate (string messege)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(messege);
                Console.ResetColor();
            };

            var cart = new Cart(notify);
            cart.Add("Cheese");
            cart.Add("Cheese");
            cart.Add(null);
            cart.Add("");
            cart.Add(" ");
            cart.Add("Bread");
            cart.Add("Bread");
            cart.Add("CocaCola");

            Console.WriteLine(cart.GetProducts());
        }

        private static void TestDelegates()
        {
            Notify notify = PrintMessege;
            notify.Invoke("Hello");

            Console.WriteLine();

            notify = PrintMessege;
            notify += PrintErrorMessege;
            notify = notify + notify;

            var invicationList = notify?.GetInvocationList();
        }

        private static void PrintMessege(string messege) => Console.WriteLine(messege);

        private static void PrintErrorMessege(string messege)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messege);
            Console.ResetColor();
        }

        private static void PrintFileMessege(string messege)
        {
            File.AppendAllLines("test.log", new[] { messege });
        }
    }
}