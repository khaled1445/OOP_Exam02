using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam02
{
    internal class MCQQuestion : Question
    {
        public int NumberOfChoices { get; set; }
        public MCQQuestion(string Header, string Body, double Mark, Answer[] answerList, Answer correctAnswer) : base(Header, Body, Mark, answerList, correctAnswer)
        {
            NumberOfChoices = answerList.Length;
        }

        public override void ShowQuestion()
        {
            Console.WriteLine(this.ToString());
            foreach (Answer answer in AnswerList) 
            {
                Console.WriteLine($"    {answer}");
            }
        }

        public override object Clone()
        {
            Answer[] clonedAnswers = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
            {
                clonedAnswers[i] = (Answer)AnswerList[i].Clone();
            }
            Answer clonedRightAnswer = (Answer)CorrectAnswer.Clone();

            return new MCQQuestion(Header, Body, Mark, clonedAnswers, clonedRightAnswer);
        }
    }
}
