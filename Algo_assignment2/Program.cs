using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_assignment2
{
   public class items
    {
       public int setNum;
        public  int count;
        public  List<int> itemSet;
        public bool flag;
        public int order;
        public items(int c, List<int> its,int s)
        {
            count = c;
            itemSet = its;
            itemSet.Sort();
            flag = false;
            setNum = s;
            order = 0;
        }
       public void setselected(bool f,int o){
           flag=f;
           order = o;

       }

    }
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
            List<int> s=createInitialSet(x,-1);

            

            List<List<int>> subsets = new List<List<int>>();
            Console.Write("\n \n  sub sets \n ");
            int i =0;
            while (i < Num_subset)
            {
                List<int> temp = new List<int>();
                temp = createInitialSet(lines[i+2],i);
                temp.Sort();
                subsets.Add(temp);
                i++;
            }

            call_subsetcover(s, subsets, Num_subset);

        }

        private static void call_subsetcover(List<int> s, List<List<int>> subsets, int Num_subset)
        {
            int i = 1;
            int setnum=0;
            List<int> set= s;
            List<int> setSelected = new List<int>();
            List<items> subsets_inter = new List<items>();
            foreach (List<int> items in subsets)
            {

                items it = new items(set.Intersect(items).ToList().Count(), set.Intersect(items).ToList(), setnum);
                subsets_inter.Add(it);
                setnum++;

            }

            while (set.Count() != 0)
            {
               // var temp = subsets_inter.Max(t=>t.count);
                var maxObject = subsets_inter.OrderByDescending(item => item.count).Where(itm=>itm.flag!=true).First();
                maxObject.setselected(true,i);
                i++;

                foreach (var it in maxObject.itemSet)
                {
                    set.Remove(it);
                }
               


            }

            int xxx = subsets_inter.RemoveAll(ite=>ite.order==0);

            subsets_inter.OrderBy(ite=>ite.order);
            foreach (var itt in subsets_inter)
            {
                Console.WriteLine("\n set no :{0}  order : {1} ",itt.setNum,itt.order );
            }

        }

        private static List<int> createInitialSet(string p, int q)
        {
           // int i = p.Length;
            List<int> set = new List<int>();
            string ss=p.Replace("  "," ");
            string[] st = ss.Split(' ');
            int i = 0;
            while(i<st.Length-1){
                set.Add(Convert.ToInt32(st[i]));
                i++;
            }
           // while()


            //int p = null;
            displayList(set, q);
            return set;
        }

        private static List<int> createInitialSet(int x,int q)
        {
            int i = 0;
            List<int> set = new List<int>();
                while(i<=(x)){
                    set.Add(i);
                    i++;
                }
                //int p = null;
                displayList(set,q);
                return set;
        }

        private static  void displayList(List<int> set,int i_)
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
