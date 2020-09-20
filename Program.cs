 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProtectedUniqueList15092020
{
    class Program
    {
        static MyProtectedUniqueList<string> myProtectedUniqueList = new MyProtectedUniqueList<string>("gali");

        static void Add(string word)
        {
            try
            {
                myProtectedUniqueList.Add(word);
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }



        }

        static void Remove(string word)
        {
            try
            {
                myProtectedUniqueList.Remove(word);
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void RemoveAt(int ind)
        {
            try
            {
                myProtectedUniqueList.RemoveAt(ind);
            }

            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Clear(string word)
        {
            try
            {
                myProtectedUniqueList.Clear(word);
            }

            catch (AccessViolationException e)
            {
                Console.WriteLine(e.Message);
            }



        }

        static void Sort(string word)
        {
            try
            {
                myProtectedUniqueList.Sort(word);
            }

            catch (AccessViolationException e)
            {
                Console.WriteLine(e.Message);
            }



        }
        static void Main(string[] args)
        {
            Add(null);

          
            Add("danny");
            Add("tool");
            Add("cookie");
            Add("cookie");
            Add("remove");
            Add("remove");

            Remove("remove");
            Remove("remove");
            RemoveAt(-9);
            RemoveAt(60);
            Clear("poli");
            Sort("dana");
            Sort("gali");

            Console.WriteLine(myProtectedUniqueList.ToString());

            Console.ReadLine();
        }
    }
}
