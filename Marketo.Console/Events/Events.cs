namespace Marketo.Console.Events
{
    public class Events
    {
        static void Main()
        {
            var pub = new Publisher();

            var sub1 = new Subscriber("sub1", pub);
            var sub2 = new Subscriber("sub2", pub);

            // Call the method that raise the event
            pub.DoSomething();

            // Keep the console window open
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadLine();
        }
    }
}
