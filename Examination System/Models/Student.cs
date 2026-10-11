using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public class Student : ICloneable, IComparable<Student>
    {
        //kk
        public int Id { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(Student? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }

        public object Clone() => new Student(Id, Name);

        public override string ToString() => $"{Id} - {Name}";

        public override bool Equals(object? obj)
            => obj is Student other && Id == other.Id;

        public override int GetHashCode() => Id.GetHashCode();
    }

}
