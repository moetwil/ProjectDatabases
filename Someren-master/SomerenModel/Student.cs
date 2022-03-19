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
        public string LastName { get; set; }

        // calculated property that returns the full name of the student 
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public int StudentId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Class { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoomId { get; set; }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
