using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    
    public class Subject : ICloneable, IComparable<Subject>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Hours { get; set; }

        public Subject(int id, string name, string code, int hours)
        {
            Id = id;
            Name = name;
            Code = code;
            Hours = hours;
        }

        public int CompareTo(Subject? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }

        public object Clone() => new Subject(Id, Name, Code, Hours);

        public override string ToString()
            => $"{Code} - {Name} ({Hours} hours)";

        public override bool Equals(object? obj)
            => obj is Subject other && Id == other.Id && Code == other.Code;

        public override int GetHashCode() => HashCode.Combine(Id, Code);
    }

}
