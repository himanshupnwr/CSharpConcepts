using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IEnumerable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void DemoIEnumerable()
        {
            Member[] peopleArray = new Member[3]
            {
                new Member("Cody", "Blackwell"),
                new Member("Raj", "Chawanda"),
                new Member("Harriet", "Lipsey")
            };

            Members peopleList = new Members(peopleArray);
            foreach(Member p in peopleList)
            {
                Console.WriteLine(p.CompanyAffiliation + "" + p.CV_Infpo);
            }


        }
    }

    internal class Members : IEnumerable
    {
        private Member[] members;
        public Members(Member[] marray)
        {
            this.members = new Member[marray.Length];
            Array.Copy(marray, members, marray.Length);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {

        }
        
    }

    internal class Member 
    {

    }
}
