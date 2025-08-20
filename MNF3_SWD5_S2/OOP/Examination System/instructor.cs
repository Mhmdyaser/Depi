using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class instructor
    {
        private int _id;
        private string _name;
        private string _specialization;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Invalid Name");
                }
                _name = value;
            }
        }

        public string Specialization
        {
            get { return _specialization; }
            set
            {
                _specialization = value;
            }
        }

        public instructor(int id, string name, string specialization)
        {
            _id = id;
            Name = name;
            Specialization = specialization;
        }
    }
}
