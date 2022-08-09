namespace Delegates
{
    delegate void Notify(string messege);

    public partial class Program
    {
        //private static Notify? _notify;

        static void Main(string[] args)
        {
            Notify notify = PrintErrorMessege;
            notify += PrintFileMessege;

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
            File.AppendAllLines("test.log", new[] {messege});
        }
    }
}