using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public class ChooseOneQuestion : Question
    {
        //kk


        public ChooseOneQuestion(
        string header,
        string body,
        int marks,
        AnswerList answers)
        : base(header, body, marks, answers)
        {
            if (answers.Count < 2)
                throw new ArgumentException("Choose One question needs at least two answers.");

            if (answers.Count(a => a.IsCorrect) != 1)
                throw new ArgumentException("Choose One question must have exactly one correct answer.");
        }

        public override string GetQuestionType() => "Choose One";

        public override void ShowQuestion()
        {
            Console.WriteLine($"{Header} ({Marks} marks)");
            Console.WriteLine(Body);
            foreach (var answer in Answers)
                Console.WriteLine(answer);
        }

        public override object Clone()
            => new ChooseOneQuestion(
                Header,
                Body,
                Marks,
                Answers.CloneList());

    }
}
