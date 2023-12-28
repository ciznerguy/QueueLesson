using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLesson
{

    internal class Program
    {

        public static int CountQueue(Queue<int> myQueue)
        {
            int count = 0;
            Queue<int> temp = new Queue<int>();
            while (!myQueue.IsEmpty())
            {
                count++;
                temp.Insert(myQueue.Remove());


            }
            while (!temp.IsEmpty())
            {
                myQueue.Insert(temp.Remove());
            }
            return count;
        }

        public static int SumQueue(Queue<int> myQueue)
        {
            int sum = 0;
            Queue<int> temp = new Queue<int>();
            while (!myQueue.IsEmpty())
            {
                sum += myQueue.Head();
                temp.Insert(myQueue.Remove());


            }
            while (!temp.IsEmpty())
            {
                myQueue.Insert(temp.Remove());
            }
            return sum;

        }

        public static Queue<int> CloneQueue(Queue<int> myQueue)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            while (!myQueue.IsEmpty())
            {
                temp2.Insert(myQueue.Head());
                temp.Insert(myQueue.Remove());

            }
            while (!temp.IsEmpty())
            {
                myQueue.Insert(temp.Remove());
            }
            return temp2;

        }

        public static int SumQueue2(Queue<int> myQueue)
        {
            Queue<int> temp = CloneQueue(myQueue);
            int sum = 0;
            while (!temp.IsEmpty())
            {
                sum += temp.Remove();

            }
            return sum;
        }

        public static bool IsArrangedQueue(Queue<int> myQueue)


        {
            Queue<int> temp = CloneQueue(myQueue);
            //מניחים שתור ריק או תור עם איבר אחד הוא בסדר עולה
            if (CountQueue(temp) < 2)
            {
                return true;
            }
            int num = temp.Remove();

            while (CountQueue(temp) > 1)
            {
                if (num > temp.Head())
                {
                    return false;
                }
                num = temp.Remove();
                Console.WriteLine(CountQueue(temp));


            }
            return true;
        }

        public static int ReturnLastFromQueue(Queue<int> myQueue)
        {
            if (myQueue.IsEmpty())
            {
                Console.WriteLine("The queue is empty. Returning default value for int.");
                return -1;
            }

            // Create a temporary queue to store elements
            Queue<int> tempQueue = new Queue<int>();

            // Dequeue elements from the original queue and enqueue them into the temporary queue
            int element = 0;
            while (!myQueue.IsEmpty())
            {
                element = myQueue.Remove();
                if (!myQueue.IsEmpty()) // Skip the last element
                {
                    tempQueue.Insert(element);
                }
            }

            // Dequeue elements from the temporary queue and enqueue them back to the original queue
            while (!tempQueue.IsEmpty())
            {

                myQueue.Insert(tempQueue.Remove());
            }

            // Return the last element
            return element;
        }

        public static int SumOfQueue(Queue<int> myQueue)
        {
            int sum = 0;
            Queue<int> temp = CloneQueue2(myQueue);
            while (!temp.IsEmpty())
            {
                sum += temp.Remove();
            }



            return sum;
        }

        public static Queue<int> CloneQueue2(Queue<int> myQueue)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> temp1 = new Queue<int>();
            while (!myQueue.IsEmpty())
            {
                temp.Insert(myQueue.Head());
                temp1.Insert(myQueue.Remove());
            }
            while (!temp1.IsEmpty())
            {
                myQueue.Insert(temp1.Remove());
            }
            return temp;
        }


        public static bool IsArranged2(Queue<int> myQueue)
        {
            if (myQueue.IsEmpty() || CountQueue(myQueue) < 2)
            {
                //אני מניח שתור ריק הוא בסדר עולה
                return true;
            }
            Queue<int> temp = CloneQueue2(myQueue);
            while (CountQueue(temp) > 1)
            {
                if (temp.Remove() > temp.Head())
                {
                    return false;
                }
            }
            return true;

        }

        public static Queue<int> Revrese(Queue<int> myQueue)
        {
            Queue<int> queueToReturn = new Queue<int>();
            while (!myQueue.IsEmpty())
            {
                queueToReturn.Insert(ReturnLastFromQueue(myQueue));
            }
            return queueToReturn;
        }

        public static int CountQ(Queue<int> myQueue)
        {
            int count = 0;
            Queue<int> tempQueue = CloneQ(myQueue);

            while (!tempQueue.IsEmpty())
            {
                tempQueue.Remove();
                count++;
            }
            return count;
        }

        public static Queue<int> CloneQ(Queue<int> myQueue)
        {
            Queue<int> temp1 = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();

            while (!myQueue.IsEmpty())
            {
                temp1.Insert(myQueue.Head());
                temp2.Insert(myQueue.Remove());
            }
            while (!temp1.IsEmpty())
            {
                myQueue.Insert(temp1.Remove());
            }

            return temp2;
        }

        public static int SumQ(Queue<int> myQueue)
        {
            int sum = 0;
            Queue<int> temp = CloneQ(myQueue);
            while (!temp.IsEmpty())
            {
                sum += temp.Remove();
            }
            return sum;
        }

        public static bool IsInQueue(Queue<int> myQueue, int num)
        {
            Queue<int> temp = CloneQ(myQueue);
            while (!temp.IsEmpty())
            {
                if (num == temp.Remove())
                {
                    return true;
                }
            }
            return false;
        }

        public static int ReturnFromQueue(Queue<int> myQueue, int index)
        {
            if (myQueue.IsEmpty())
            {
                return -1;
            }
            if (CountQ(myQueue) < index)
            {
                return -1;
            }
            int current = 1;
            int numToReturn = 0;
            Queue<int> temp = new Queue<int>();
            while (!myQueue.IsEmpty())
            {
                if (current != index)
                {
                    temp.Insert(myQueue.Remove());

                }
                else
                {
                    numToReturn = myQueue.Remove();
                }
                current++;

            }
            while (!temp.IsEmpty())
            {
                myQueue.Insert(temp.Remove());
            }
            return numToReturn;
        }

        public static void PrintQueue(Queue<int> myQueue)
        {
            Queue<int> temp = CloneQ(myQueue);
            Console.Write("Head  >>  ");
            while (!temp.IsEmpty())
            {
                Console.Write($"{temp.Remove()},");
            }
            Console.WriteLine();
        }

        public static Queue<int> MergeQueues(Queue<int> qOne, Queue<int> qTwo)
        {
            // create copies for queues
            Queue<int> queueToReturn = new Queue<int>();

            while (!qOne.IsEmpty() && !qTwo.IsEmpty())
            {
                if (qOne.Head() > qTwo.Head())
                {
                    queueToReturn.Insert(qTwo.Remove());
                }
                else
                {
                    queueToReturn.Insert(qOne.Remove());
                }
            }
            while (!qOne.IsEmpty())
            {
                queueToReturn.Insert(qOne.Remove());
            }
            while (!qTwo.IsEmpty())
            {
                queueToReturn.Insert(qTwo.Remove());
            }
            return queueToReturn;

        }

        static void Main(string[] args)
        {
            Queue<int> myQueue = new Queue<int>();
            myQueue.Insert(6);
            myQueue.Insert(10);
            myQueue.Insert(15);
            myQueue.Insert(26);
            myQueue.Insert(58);

            Queue<int> myQueueTwo = new Queue<int>();
            myQueueTwo.Insert(5);
            myQueueTwo.Insert(10);
            myQueueTwo.Insert(18);
            myQueueTwo.Insert(29);
            myQueueTwo.Insert(55);
            myQueueTwo.Insert(100);
            myQueueTwo.Insert(642);

            Console.WriteLine(ReturnFromQueue(myQueueTwo, 3));



            //CloneQ(myQueue);
            Queue<int> myQueue2 = CloneQ(myQueue);
            //Console.WriteLine(myQueue2);
            //Console.WriteLine(CountQ(myQueue));
            Console.WriteLine($"the sum is: {SumQ(myQueue)}");
            Console.WriteLine(IsInQueue(myQueue, 58));
   
        }
    }


}
