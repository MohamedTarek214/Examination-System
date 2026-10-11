using Examination_System.Data;
using Examination_System.Models;
using Examination_System.Service;

namespace Examination_System
{
    //kk
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Examination System =====");
            Console.WriteLine();

            var subject = SampleData.CreateSubject();

            var questions = SampleData.CreateQuestionList("Data/QuestionList.log");

            var practiceExam = new PracticeExam(
                id: 1,
                name: "C# Practice Exam",
                timeInMinutes: 30,
                numberOfQuestions: questions.Count,
                subject: subject,
                questions: questions);

            var finalExam = new FinalExam(
                id: 2,
                name: "C# Final Exam",
                timeInMinutes: 60,
                numberOfQuestions: questions.Count,
                subject: subject,
                questions: questions);

            var students = new List<Student>
            {
                new Student(1, "Ahmed"),
                new Student(2, "Mohamed"),
                new Student(3, "Omar")
            };

            var notificationService = new ExamNotificationService(students);
            notificationService.Subscribe(practiceExam);
            notificationService.Subscribe(finalExam);

            Console.WriteLine("Choose Exam Type:");
            Console.WriteLine("1. Practice Exam");
            Console.WriteLine("2. Final Exam");
            Console.Write("Your choice: ");

            var choice = Console.ReadLine();

            Exam selectedExam = choice == "1" ? practiceExam : finalExam;

            Console.WriteLine();
            Console.WriteLine($"Selected: {selectedExam.Name}");

            selectedExam.Start();

            Console.WriteLine();
            Console.WriteLine("Enter your answers.");
            Console.WriteLine("For Choose One / True-False enter one answer ID.");
            Console.WriteLine("For Choose All enter answer IDs separated by comma.");
            Console.WriteLine();

            foreach (var question in selectedExam.QuestionAnswers.Keys)
            {
                Console.Write($"Answer for '{question.Header}': ");
                var input = Console.ReadLine() ?? string.Empty;

                var ids = input
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.TryParse(x.Trim(), out var id) ? id : -1)
                    .Where(id => id > 0)
                    .ToArray();

                try
                {
                    selectedExam.SubmitAnswer(question, ids);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid answer: {ex.Message}");
                    Console.WriteLine("This question will be considered unanswered.");
                }
            }

            selectedExam.Finish();

            Console.WriteLine();
            Console.WriteLine("========== EXAM FINISHED ==========");
            Console.WriteLine($"Score: {selectedExam.CalculateScore()}");

            if (selectedExam is PracticeExam practice)
            {
                practice.ShowCorrectAnswers();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
