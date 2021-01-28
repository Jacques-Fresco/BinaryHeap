using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<int> startItems = new List<int>();

            for(int i = 0; i < 100; i++)
            {
                startItems.Add(rnd.Next(-1000, 1000));
            }

            Model.Heap heap = new Model.Heap(startItems);
            
            foreach(int value in heap)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();

            /*Model.Heap heap = new Model.Heap();
            heap.Add(20);
            heap.Add(11);
            heap.Add(17);
            heap.Add(7);
            heap.Add(4);
            heap.Add(13);
            heap.Add(15);
            heap.Add(14);

            while(heap.Count > 0)
            {
                Console.WriteLine(heap.GetMax());
            }

            Console.ReadLine();*/
        }
    }
}
