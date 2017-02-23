using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path=@"F:\\retail.dat";
           // string path = null;
            if (path == null)
            {
                Console.WriteLine("enter the path ");
                path = Console.ReadLine();
            }
           // string[] lines = System.IO.File.ReadAllLines(path);
            string[] lines = System.IO.File.ReadAllLines(path);
            int x = Convert.ToInt32(lines[0]);
            //int Num_subset = Convert.ToInt32(lines[1]);
            int Num_subset = lines.Length - 2;
            LinkedList<int> s=createInitialSet(x,-1);

            

            LinkedList<LinkedList<int>> subsets = new LinkedList<LinkedList<int>>();
            Console.Write("\n \n  sub sets \n ");
            int i =0;
            while (i < Num_subset)
            {
                LinkedList<int> temp = new LinkedList<int>();
                temp = createInitialSet(lines[i+2],i);
                
                subsets.AddLast(temp);
                i++;
            }

            call_subsetcover(s, subsets, Num_subset);

        }

        private static void call_subsetcover(LinkedList<int> s, LinkedList<LinkedList<int>> subsets, int Num_subset)
        {
            int i = 0;
            LinkedList<LinkedList<int>> subsets_inter = new LinkedList<LinkedList<int>>();
            while (i < Num_subset)
            {
                subsets_inter=subsets.i
            }
        }

        private static LinkedList<int> createInitialSet(string p, int q)
        {
           // int i = p.Length;
            LinkedList<int> set = new LinkedList<int>();
            string ss=p.Replace("  "," ");
            string[] st = ss.Split(' ');
            int i = 0;
            while(i<st.Length-1){
                set.AddLast(Convert.ToInt32(st[i]));
                i++;
            }
           // while()


            //int p = null;
            displayList(set, q);
            return set;
        }

        private static LinkedList<int> createInitialSet(int x,int q)
        {
            int i = 0;
            LinkedList<int> set = new LinkedList<int>();
                while(i<=(x)){
                    set.AddLast(i);
                    i++;
                }
                //int p = null;
                displayList(set,q);
                return set;
        }

        private static  void displayList(LinkedList<int> set,int i_)
        {
            if (i_ == -1) 
            Console.Write("\n Initial Set ={ ");
            else
            Console.Write("\n S"+Convert.ToString(i_)+ " ={ ");
            int i= 0;
            //while (i <= (set.Count()+1))
            //{
            //   // Console.Write(" {0} ,",set.);
            //}

            foreach(var it in set){

                Console.Write(" {0} ,",it);
            }
            Console.Write(" }");
            }
     }

    
}
