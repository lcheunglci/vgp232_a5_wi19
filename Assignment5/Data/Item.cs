namespace Assignment5.Data
{
    public class Item
    {
        public string Name { get; set; }
        public int UnlockRequirement { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }

        public void Print()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("UnlockRequirement: {0}", UnlockRequirement);
            Console.WriteLine("Description: {0}", Description);
            Console.WriteLine("Effect: {0}", Effect);
            Console.WriteLine("\n");
        }
    }
}
