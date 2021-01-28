using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap.Model
{
    // Левый потомок: 2*i+1
    // Правый потомок: 2*i+2
    // Предок: (i-1)/2

    // когда мы сортируем снизу вверх, то рассматривается сам элемент(дочерний элемент) и родительский элемент
    // когда мы сортируем сверху вниз, то рассматривается сам элемент(родительский элемент) и дочерние элементы
    class Heap : IEnumerable
    {
        public List<int> items = new List<int>();
        public int Count => items.Count;
        public int? Peek() // посмотреть первый элемент (без извлечения)
        {
            if (Count > 0)
            {
                return items[0];
            }
            else return default(int);
        }
        public Heap() { }
        public Heap(List<int> items) 
        {
            this.items.AddRange(items);
            for(int i = Count; i >= 0; i--)
            {
                Sort(i);
            }
        }
        public void Add(int item) // поставить элемент в очередь
        {
            items.Add(item);

            int currentIndex = Count - 1; // индекс текущего (добавленного) элемента
            int parentIndex = GetParentIndex(currentIndex); // индекс родителя текущего элемента
            
            while(currentIndex > 0 && items[parentIndex] < items[currentIndex])
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }
        public int GetMax() // извлечь первый элемент
        {
            int result = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);
            Sort(0);
            return result;
        }

        private void Sort(int currentIndex)
        {
            int maxIndex = currentIndex;
            int leftIndex;
            int rightIndex;

            while (currentIndex < Count) // не может быть больше кол.во элементов в самом дереве
            {
                leftIndex = 2 * currentIndex + 1;
                rightIndex = 2 * currentIndex + 2;

                if (leftIndex < Count && items[leftIndex] > items[maxIndex])
                {
                    maxIndex = leftIndex; // записываем больший в maxIndex
                }

                if (rightIndex < Count && items[rightIndex] > items[maxIndex])
                {
                    maxIndex = rightIndex; // больший из трех элементов (root, left, right)
                }

                if(maxIndex == currentIndex)
                {
                    break;
                }

                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            int temp = items[currentIndex];
            items[currentIndex] = items[parentIndex];
            items[parentIndex] = temp;
        }

        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        public IEnumerator GetEnumerator()
        {
            while(Count > 0)
            {
                yield return GetMax();
            }
        }
    }
}
