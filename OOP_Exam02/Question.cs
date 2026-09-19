using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam02
{
    internal abstract class Question :IComparable , ICloneable
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer CorrectAnswer { get; private set; }

        public Question (string header, string body, double mark, Answer[] answerList, Answer correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswer = correctAnswer;
        }

        public abstract void ShowQuestion();
        public override string ToString()
        {
            return $"Header: {Header}\nBody: {Body}\nMark: {Mark}";
        }

        public abstract object Clone();
        public int CompareTo(object? obj)
        {
            if (obj is Question other)
            {
                return Mark.CompareTo(other.Mark);
            }

            return 1;
        }
        
        
    }
}
