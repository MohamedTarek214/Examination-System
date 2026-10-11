using Examination_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Data
{
    
    public static class SampleData
    {
        public static Subject CreateSubject()
            => new Subject(1, "C# Programming", "CSHARP101", 3);

        public static QuestionList<Question> CreateQuestionList(string fileName)
        {
            var questions = new QuestionList<Question>(fileName);

            questions.Add(
                new TrueFalseQuestion(
                    "Question 1",
                    "C# is an object-oriented programming language.",
                    5,
                    true));

            questions.Add(
                new ChooseOneQuestion(
                    "Question 2",
                    "Which keyword creates an object in C#?",
                    5,
                    new AnswerList
                    {
                    new Answer(1, "new", true),
                    new Answer(2, "class"),
                    new Answer(3, "object"),
                    new Answer(4, "create")
                    }));

            questions.Add(
                new ChooseAllQuestion(
                    "Question 3",
                    "Which of the following are C# value types?",
                    10,
                    new AnswerList
                    {
                    new Answer(1, "int", true),
                    new Answer(2, "double", true),
                    new Answer(3, "string"),
                    new Answer(4, "bool", true)
                    }));

            return questions;
        }
    }
}
