using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public class Answer : ICloneable, IComparable<Answer>
    {
        //kk
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(int id, string text, bool isCorrect = false)
        {
            Id = id;
            Text = text;
            IsCorrect = isCorrect;
        }

        public int CompareTo(Answer? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }

        public object Clone() => new Answer(Id, Text, IsCorrect);

        public override string ToString() => $"{Id}. {Text}";

        public override bool Equals(object? obj)
            => obj is Answer other && Id == other.Id && Text == other.Text;

        public override int GetHashCode() => HashCode.Combine(Id, Text);
    }
}
