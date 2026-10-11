using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(
            string header,
            string body,
            int marks,
            bool correctAnswer)
            : base(
                header,
                body,
                marks,
                new AnswerList
                {
                new Answer(1, "True", correctAnswer),
                new Answer(2, "False", !correctAnswer)
                })
        {
        }

        public override string GetQuestionType() => "True / False";

        public override void ShowQuestion()
        {
            Console.WriteLine($"{Header} ({Marks} marks)");
            Console.WriteLine(Body);
            foreach (var answer in Answers)
                Console.WriteLine(answer);
        }

        public override object Clone()
            => new TrueFalseQuestion(
                Header,
                Body,
                Marks,
                Answers.First(a => a.IsCorrect).Id == 1);
    }

}
