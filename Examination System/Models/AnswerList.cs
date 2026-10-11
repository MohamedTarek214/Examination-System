using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Models
{
    public class AnswerList : List<Answer>, ICloneable
    {
       

        public AnswerList() { }

        public AnswerList(IEnumerable<Answer> answers) : base(answers) { }

        public AnswerList CloneList()
            => new AnswerList(this.Select(a => (Answer)a.Clone()));

        public object Clone() => CloneList();

        public override string ToString()
            => string.Join(Environment.NewLine, this.Select(a => a.ToString()));
    }
}
