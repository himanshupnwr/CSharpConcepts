using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedMembersDemo
{
    class ExpressionMembers
    {
        private String name;

        //C# 6.0 introduced expression-bodied members in read only properties

        public string formalName => $"Mr. {name}";
        /*public ExpressionMembers(string name)
        {
            this.name = name;
        }*/

        // C# 7.0 introduced expression-bodied constructors (only work with 0 or 1  argument)
        public ExpressionMembers(string name) => this.name = name;

        //Expression-bodied finalizers added in C# 7 (not needed for this class but added to show syntax)
        ~ExpressionMembers() => Console.Error.WriteLine("C# finalized was called!");

        //C# 6.0 introduced expression-bodied members

        public override string ToString() => $"Hello, {name}";

        //Expression-bodied get / set accessor for C# 7.0

        public string Name
        {
            get => name;
            set => this.name = value ?? "Default label";
        }

        static void Main(string[] args)
        {
            ExpressionMembers exp = new ExpressionMembers("John");
            System.Console.WriteLine(exp.ToString());
            System.Console.WriteLine(exp.formalName);

            //use the set method to change the firstname
            exp.Name = "Tim";
            System.Console.WriteLine(exp.ToString());
        }
    }
}
