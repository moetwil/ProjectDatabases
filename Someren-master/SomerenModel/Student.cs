using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    { 
        public string FirstName { get; set; }
        public int StudentId { get; set; } // StudentNumber, e.g. 474791
        public DateTime BirthDate { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoomId { get; set; }
    }
}
