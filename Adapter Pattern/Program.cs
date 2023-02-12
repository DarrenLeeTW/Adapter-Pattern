using System;

namespace Adapter_Pattern
{
    public interface ISocket
    {
        void PowerSupply(int holes);
    }

    public class ThreeHoleSocket : ISocket
    {
        public void PowerSupply(int holes)
        {
            Console.WriteLine($"3個孔插座正在供電，插頭孔數：{holes}個");
        }
    }

    public class TwoHolePlug
    {
        public int Holes { get; set; }
    }

    public class Adapter : TwoHolePlug, ISocket
    {
        public void PowerSupply(int holes)
        {
            Holes = holes;
            Console.WriteLine($"2個孔插頭通過配適器與3個孔插座協同工作，插頭孔數：{Holes}個");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISocket socket = new ThreeHoleSocket();
            socket.PowerSupply(3);

            TwoHolePlug plug = new TwoHolePlug();
            plug.Holes = 2;

            ISocket adapter = new Adapter();
            adapter.PowerSupply(plug.Holes);

            Console.ReadKey();
        }
    }
}


