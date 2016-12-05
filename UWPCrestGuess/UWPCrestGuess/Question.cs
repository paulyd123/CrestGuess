using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPCrestGuess.Model
{
    class Question
    {
        public int ID { get; set; }
        public String Image { get; set; }
        public String AnswerA { get; set; }
        public String AnswerB { get; set; }
        public String AnswerC { get; set; }
        public String AnswerD { get; set; }
        public String CorrectAnswer { get; set; }
    }
}
