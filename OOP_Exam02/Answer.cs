using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam02
{
    internal class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public Answer(int answerID, string answerText)
        {
            AnswerID = answerID;
            AnswerText = answerText;
        }
        public object Clone()
        {
            return new Answer(AnswerID, AnswerText);
        }


        public override string ToString()
        {
            return $"Answer ID: {AnswerID}, Answer Text: {AnswerText}";
        }

    }
}
