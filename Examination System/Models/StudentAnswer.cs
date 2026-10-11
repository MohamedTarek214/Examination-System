using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    //kk
    public class StudentAnswer
    {
        public Question Question { get; }
        public AnswerList SelectedAnswers { get; }

        public StudentAnswer(Question question, AnswerList selectedAnswers)
        {
            Question = question;
            SelectedAnswers = selectedAnswers;
        }

        public bool IsCorrect()
        {
            var correctIds = Question.Answers
                .Where(a => a.IsCorrect)
                .Select(a => a.Id)
                .OrderBy(id => id)
                .ToList();

            var selectedIds = SelectedAnswers
                .Select(a => a.Id)
                .Distinct()
                .OrderBy(id => id)
                .ToList();

            return correctIds.SequenceEqual(selectedIds);
        }
    }

}
