using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
       
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }

        protected Question(string header, string body, int marks, AnswerList answers)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = answers;
        }

        public abstract string GetQuestionType();
        public abstract void ShowQuestion();

        public int CompareTo(Question? other)
        {
            if (other is null) return 1;
            return string.Compare(Header, other.Header, StringComparison.Ordinal);
        }

        public abstract object Clone();

        public override string ToString()
            => $"{GetQuestionType()} | {Header} | {Body} | Marks: {Marks}";

        public override bool Equals(object? obj)
            => obj is Question other &&
               Header == other.Header &&
               Body == other.Body &&
               Marks == other.Marks;

        public override int GetHashCode()
            => HashCode.Combine(Header, Body, Marks);
    }

       
        
}
