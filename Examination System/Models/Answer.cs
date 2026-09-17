using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Answer(int Id, string Text)
        {
            this.Id = Id;

            this.Text = Text;
        }
    }
}
