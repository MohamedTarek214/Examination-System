using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//kk
namespace Examination_System.Models
{
    public class FinalExam : Exam
    {
        public FinalExam(
            int id,
            string name,
            int timeInMinutes,
            int numberOfQuestions,
            Subject subject,
            IEnumerable<Question> questions)
            : base(id, name, timeInMinutes, numberOfQuestions, subject, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine();
            Console.WriteLine("========== FINAL EXAM ==========");
            Console.WriteLine(this);
            Console.WriteLine();

            foreach (var question in QuestionAnswers.Keys)
            {
                question.ShowQuestion();
                Console.WriteLine();
            }
        }

        public override object Clone()
            => new FinalExam(
                Id,
                Name,
                TimeInMinutes,
                NumberOfQuestions,
                (Subject)Subject.Clone(),
                QuestionAnswers.Keys.Select(q => (Question)q.Clone()).ToList());
    }
}
