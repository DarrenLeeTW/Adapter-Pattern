using System;
// 這個範例展示了如何利用適配器模式 (Adapter Pattern)
// 讓原本不相容的介面能夠一起工作。


namespace Adapter_Pattern
{
    /// <summary>
    /// 定義插座必須實作的供電方法
    /// </summary>
    public interface ISocket
    {
        void PowerSupply(int holes);
    }

    /// <summary>
    /// 三孔插座的具體實作
    /// </summary>
    public class ThreeHoleSocket : ISocket
    {
        public void PowerSupply(int holes)
        {
            Console.WriteLine($"3個孔插座正在供電，插頭孔數：{holes}個");
        }
    }

    /// <summary>
    /// 表示兩孔插頭
    /// </summary>
    public class TwoHolePlug
    {
        public int Holes { get; set; }
    }

    /// <summary>
    /// 將兩孔插頭轉接成三孔插座可用的適配器
    /// </summary>
    public class Adapter : TwoHolePlug, ISocket
    {
        public void PowerSupply(int holes)
        {
            Holes = holes;
            Console.WriteLine($"2個孔插頭通過配適器與3個孔插座協同工作，插頭孔數：{Holes}個");
        }
    }

    /// <summary>
    /// 程式進入點
    /// </summary>
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


