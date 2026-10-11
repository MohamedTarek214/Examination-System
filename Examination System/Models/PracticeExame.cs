using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public class PracticeExam : Exam
    {
        public PracticeExam(
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
            Console.WriteLine("========== PRACTICE EXAM ==========");
            Console.WriteLine(this);
            Console.WriteLine();

            foreach (var question in QuestionAnswers.Keys)
            {
                question.ShowQuestion();
                Console.WriteLine();
            }
        }

        public void ShowCorrectAnswers()
        {
            Console.WriteLine();
            Console.WriteLine("========== CORRECT ANSWERS ==========");

            foreach (var question in QuestionAnswers.Keys)
            {
                var correct = question.Answers
                    .Where(a => a.IsCorrect)
                    .Select(a => a.ToString());

                Console.WriteLine($"{question.Body}");
                Console.WriteLine($"Correct: {string.Join(", ", correct)}");
            }
        }

        public override object Clone()
            => new PracticeExam(
                Id,
                Name,
                TimeInMinutes,
                NumberOfQuestions,
                (Subject)Subject.Clone(),
                QuestionAnswers.Keys.Select(q => (Question)q.Clone()).ToList());
    }
}
