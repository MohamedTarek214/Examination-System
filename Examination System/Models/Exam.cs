using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        //kk

        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeInMinutes { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject Subject { get; set; }
        public ExamMode Mode { get; private set; }

        
        public Dictionary<Question, AnswerList> QuestionAnswers { get; }

        public Dictionary<Question, AnswerList> StudentAnswers { get; }

        public event EventHandler<ExamStartingEventArgs>? ExamStarted;

        protected Exam(
            int id,
            string name,
            int timeInMinutes,
            int numberOfQuestions,
            Subject subject,
            IEnumerable<Question> questions)
        {
            if (timeInMinutes <= 0)
                throw new ArgumentException("Exam time must be greater than zero.");

            if (numberOfQuestions <= 0)
                throw new ArgumentException("Number of questions must be greater than zero.");

            var questionList = questions.ToList();

            if (questionList.Count != numberOfQuestions)
                throw new ArgumentException("NumberOfQuestions must match the supplied questions.");

            Id = id;
            Name = name;
            TimeInMinutes = timeInMinutes;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
            Mode = ExamMode.Queued;

            QuestionAnswers = new Dictionary<Question, AnswerList>();
            StudentAnswers = new Dictionary<Question, AnswerList>();

            foreach (var question in questionList)
                QuestionAnswers.Add(question, question.Answers);
        }

        public void Start()
        {
            if (Mode == ExamMode.Finished)
                throw new InvalidOperationException("A finished exam cannot be started again.");

            Mode = ExamMode.Starting;
            OnExamStarted();
            ShowExam();
        }

        protected virtual void OnExamStarted()
            => ExamStarted?.Invoke(this, new ExamStartingEventArgs(this));

        public void Finish()
        {
            Mode = ExamMode.Finished;
        }

        public void SubmitAnswer(Question question, params int[] answerIds)
        {
            if (Mode != ExamMode.Starting)
                throw new InvalidOperationException("Answers can only be submitted while the exam is starting.");

            if (!QuestionAnswers.ContainsKey(question))
                throw new ArgumentException("This question does not belong to the exam.");

            var selected = question.Answers
                .Where(a => answerIds.Contains(a.Id))
                .Select(a => (Answer)a.Clone())
                .ToList();

            if (selected.Count != answerIds.Distinct().Count())
                throw new ArgumentException("One or more answer IDs are invalid.");

            StudentAnswers[question] = new AnswerList(selected);
        }

        public double CalculateScore()
        {
            double score = 0;

            foreach (var pair in QuestionAnswers)
            {
                if (!StudentAnswers.TryGetValue(pair.Key, out var studentAnswer))
                    continue;

                var correctIds = pair.Value
                    .Where(a => a.IsCorrect)
                    .Select(a => a.Id)
                    .OrderBy(id => id);

                var studentIds = studentAnswer
                    .Select(a => a.Id)
                    .OrderBy(id => id);

                if (correctIds.SequenceEqual(studentIds))
                    score += pair.Key.Marks;
            }

            return score;
        }

        public abstract void ShowExam();

        public int CompareTo(Exam? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }

        public abstract object Clone();

        public override string ToString()
            => $"{Name} | {Subject} | Time: {TimeInMinutes} min | Questions: {NumberOfQuestions} | Mode: {Mode}";

        public override bool Equals(object? obj)
            => obj is Exam other && Id == other.Id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}
