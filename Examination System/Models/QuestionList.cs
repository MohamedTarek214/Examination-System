using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public class QuestionList<T> : List<T> where T : Question
    {
        //kk
        private readonly string _fileName;

        public QuestionList(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("A log file name is required.", nameof(fileName));

            _fileName = fileName;
        }

        // List<T>.Add is not virtual, so it cannot be overridden.
        // We hide it with new, preserve normal Add behavior by calling base.Add,
        // then log the question to this list's own file.
        public new void Add(T question)
        {
            ArgumentNullException.ThrowIfNull(question);

            base.Add(question);
            LogQuestion(question);
        }

        private void LogQuestion(T question)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(_fileName))!);

            using StreamWriter writer = new StreamWriter(_fileName, append: true);
            writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]");
            writer.WriteLine(question);
            writer.WriteLine(new string('-', 60));
        }
    }

}
