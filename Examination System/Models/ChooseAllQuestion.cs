using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public class ChooseAllQuestion : Question
    {
        //kk

        public ChooseAllQuestion(
        string header,
        string body,
        int marks,
        AnswerList answers)
        : base(header, body, marks, answers)
        {
            if (answers.Count < 2)
                throw new ArgumentException("Choose All question needs at least two answers.");

            if (answers.All(a => !a.IsCorrect))
                throw new ArgumentException("Choose All question must have at least one correct answer.");
        }

        public override string GetQuestionType() => "Choose All";

        public override void ShowQuestion()
        {
            Console.WriteLine($"{Header} ({Marks} marks)");
            Console.WriteLine(Body);
            foreach (var answer in Answers)
                Console.WriteLine(answer);
        }

        public override object Clone()
            => new ChooseAllQuestion(
                Header,
                Body,
                Marks,
                Answers.CloneList());

    }
}
