using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeacherId { get; set; }
        public int RoomId { get; set; }  // LecturerNumber, e.g. 47198

        public Teacher(int teacherId, string firstName, string lastName, int roomId)
        {
            this.TeacherId = teacherId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoomId = roomId;
        }


    }
}
