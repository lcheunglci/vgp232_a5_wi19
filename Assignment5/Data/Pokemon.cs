namespace Assignment5.Data
{
    public class Pokemon
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxCP { get; set; }



        public void Print()
        {
            Console.WriteLine("Index: {0}", Index);
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Type1: {0}", Type1);
            Console.WriteLine("Type2: {0}", Type2);
            Console.WriteLine("HP: {0}", HP);
            Console.WriteLine("Attack: {0}", Attack);
            Console.WriteLine("Defense: {0}", Defense);
            Console.WriteLine("MaxCP: {0}", MaxCP);
            Console.Write("\n");


        }
    }

}
