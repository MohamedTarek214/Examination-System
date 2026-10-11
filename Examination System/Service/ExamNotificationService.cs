using Examination_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Service
{
    //kk
    public delegate void ExamStartedHandler(object? sender, ExamStartingEventArgs e);

    public class ExamNotificationService
    {
        private readonly List<Student> _students;

        public ExamNotificationService(IEnumerable<Student> students)
        {
            _students = students.ToList();
        }

        public void Subscribe(Exam exam)
        {
            exam.ExamStarted += NotifyStudents;
        }

        private void NotifyStudents(object? sender, ExamStartingEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("----- Exam Starting Notification -----");

            foreach (var student in _students)
            {
                Console.WriteLine(
                    $"Notification to {student.Name}: " +
                    $"the exam '{e.Exam.Name}' for {e.Exam.Subject.Name} is starting now.");
            }

            Console.WriteLine("--------------------------------------");
        }
    }

}
