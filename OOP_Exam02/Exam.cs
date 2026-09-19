using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam02
{
    internal abstract class Exam
    {
        public TimeSpan ExamDuration { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] QuestionsList { get; set; }

        protected Exam(TimeSpan examDuration, int numberOfQuestions, Question[] questions)
        {
            ExamDuration = examDuration;
            NumberOfQuestions = numberOfQuestions;
            QuestionsList = questions;
        }
        public abstract void ShowExam();

        public override string ToString()
        {
            return $"Exam Duration: {ExamDuration}\nNumber of Questions: {NumberOfQuestions}";
        }

    }
}
