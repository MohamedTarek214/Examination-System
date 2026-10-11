using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    //kk
    public class ExamStartingEventArgs : EventArgs
    {
        public Exam Exam { get; }

        public ExamStartingEventArgs(Exam exam)
        {
            Exam = exam;
        }
    }
}
