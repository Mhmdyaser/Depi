using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Bank
    {
        public string Name { get; set; }
        public string BranchCode { get; set; }

        public Bank(string name, string branchCode)
        {
            Name = name;
            BranchCode = branchCode;
        }

        public virtual void DisplayBank()
        {
            Console.WriteLine($"Bank Name   = {Name}");
            Console.WriteLine($"Branch Code = {BranchCode}");
        }
    }

}
