using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public static int QueueInIndex(Queue<int> myQueue, int index)
        {
            Queue<int> temp = new Queue<int>();
            int currentIndex = 1;
            int ValueToReturn = 0;
            while(!myQueue.IsEmpty())
            {
                if(currentIndex == index)
                {
                    ValueToReturn = myQueue.Remove();
                }
                else
                {
                    temp.Insert(myQueue.Remove());
                }
                currentIndex++;
            }
            while (!temp.IsEmpty())
            {
                myQueue.Insert(temp.Remove());
            }
            return ValueToReturn;
        }

        public static Queue<int> MergeSortedQueue(Queue<int> queue1, Queue<int> queue2)
        {
            Queue<int> tempQueue1 = CloneQueue(queue1);
            Queue<int> tempQueue2 = CloneQueue(queue2);
            Queue<int> queueToReturn = new Queue<int>();
            while (!tempQueue1.IsEmpty() && !tempQueue2.IsEmpty())
            {
                if (tempQueue1.Head() < tempQueue2.Head())
                {
                    queueToReturn.Insert(tempQueue1.Remove());
                }
                else
                {
                    queueToReturn.Insert(tempQueue2.Remove());
                }
            }
            while (!tempQueue1.IsEmpty())
            {
                queueToReturn.Insert(tempQueue1.Remove());
            }
            while (!tempQueue2.IsEmpty())
            {
                queueToReturn.Insert(tempQueue2.Remove());
            }
            return queueToReturn;
        }
        
        public static void InsertSortedQueue(Queue<int> myQueue, int x)
        {
            bool isInserted = false;
            Queue<int> temp = new Queue<int>();
            if (myQueue.IsEmpty())
            {
                myQueue.Insert(x);
            }
            else
            {
                while (!myQueue.IsEmpty())
                {
                    if (x <= myQueue.Head() && isInserted == false)
                    {
                        temp.Insert(x);
                        isInserted = true;
                    }
                    else
                    {
                        temp.Insert(myQueue.Remove());
                    }
                }
                while (!temp.IsEmpty())
                {
                    myQueue.Insert(temp.Remove());
                }
                if(isInserted == false)
                {
                    myQueue.Insert(x);
                }
            }
        }
        /*
         * נתונה המחלקה CovidTest , המייצגת אדם שנבדק בדיקת קורונה, ולה 4 תכונות:
• name — שם הנבדק מטיפוס מחרוזת
• id — מספר זהות מטיפוס מחרוזת
• cityCode — קוד של עיר המגורים, מטיפוס שלם )לדוגמה: 1030 בעבור אשדוד, 23 בעבור עכו(
• sick — משתנה מטיפוס בוליאני, המקבל true אם הנבדק חולה, אחרת הוא מקבל false

הנח שיש פעולות get ו־ set בשפת Java ופעולות Get ו־ Set בשפת #C בעבור תכונות המחלקה.

כתוב פעולה חיצונית mostSick בשפת Java או MostSick בשפת #C המקבלת תור — q שאינו ריק מטיפוס CovidTest .
הפעולה תחזיר את הקוד של העיר שבה כמות החולים היא הגדולה ביותר.

הערות: – מיקום הנבדקים בתור אינו לפי סדר כלשהו.
           – כל נבדק מופיע רק פעם אחת בתור.
           – הקוד של העיר אינו קשור לגודל התור (לדוגמה: ייתכן שמספר האיברים בתור הוא 1000 וקיים קוד עיר שמספרו 5000).
           – אין צורך לשמור על התור.
הנח שיש רק עיר אחת שבה כמות החולים היא הגדולה ביותר.
        */
        public static int MostSick(Queue<CovidTest> q)
        {
            int maxSick = 0;
            int maxCityCode = 0;
            int num;
        
            while (!q.IsEmpty())
            {
               
                int code = q.Head().GetCityCode();
                num = NumOfSickInCity (q, code);
                if (num > maxSick)
                {
                    maxSick = num;
                    maxCityCode = code;
                }              
                           
            }
            
            return maxCityCode;
        }

        public static int NumOfSickInCity(Queue<CovidTest> q, int cityCode)
        {
            int count = 0;
         
            Queue<CovidTest> temp = new Queue<CovidTest>();
            while (!q.IsEmpty())
            {
                if (q.Head().GetCityCode() == cityCode)
                {
                    if(q.Remove().GetIsSick())
                    {
                        count++;
                    }
                    
                }
                else
                {
                    temp.Insert(q.Remove());
                   
                }
               
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return count;
        }

        public static bool IsIdentical(Queue<int> q1, Queue<int> q2)
        {
            if (CountQ(q1) != CountQ(q2))
            {
                return false;
            }
            Queue<int> temp1 = CloneQ(q1);
            Queue<int> temp2 = CloneQ(q2);

            while (!temp1.IsEmpty())
            {
                if (temp1.Remove() != temp2.Remove())
                {
                    return false;
                }
            }
            return true;

        }

        public static bool IsSimilar(Queue<int> q1, Queue<int> q2)
        {
            if (CountQ(q1) != CountQ(q2))
            {
                return false;
            }
            Queue<int> temp1 = CloneQ(q1);
            Queue<int> temp2 = CloneQ(q2);

            for (int i = 0; i < CountQ(q1)-1; i++)
            {
                if (IsIdentical(temp1, temp2))
                {
                    return true;
                }
                temp1.Insert(temp1.Remove());
            }
            return false;

        }

        public static bool IsSumExists(Queue<int> q1, int num)
        {
            Queue<int> temp = CloneQ(q1);

            while (!temp.IsEmpty())
            {
                int current = temp.Remove();
                int lookFor = num - current;
                if (IsInQueue(temp, lookFor))
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
           

            CovidTest test1 = new CovidTest("Name1", "ID1", 123,true );
            CovidTest test2 = new CovidTest("Name2", "ID2", 123, true);
            CovidTest test3 = new CovidTest("Name3", "ID3", 423, true);
            CovidTest test4 = new CovidTest("Name4", "ID4", 123, false);
            CovidTest test5 = new CovidTest("Name5", "ID5", 333, true);
            CovidTest test6 = new CovidTest("Name6", "ID6", 123, false);
          

            
            Queue<CovidTest> covidQueue = new Queue<CovidTest>();

            covidQueue.Insert(test1);
            covidQueue.Insert(test2);
            covidQueue.Insert(test3);
            covidQueue.Insert(test4);
            covidQueue.Insert(test5);
            covidQueue.Insert(test6);
            
            Console.WriteLine(MostSick(covidQueue));



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

            Console.WriteLine(myQueue);

            ////CloneQ(myQueue);
            //Queue<int> myQueue2 = CloneQ(myQueue);
            ////Console.WriteLine(myQueue2);
            ////Console.WriteLine(CountQ(myQueue));
            //Console.WriteLine($"the sum is: {SumQ(myQueue)}");
            //Console.WriteLine(IsInQueue(myQueue, 58));
   
        }
    }


}
