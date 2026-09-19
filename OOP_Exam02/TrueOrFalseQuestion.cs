using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam02
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string header, string body, double mark, Answer correctAnswer) : base(header, body, mark, new Answer[] { new Answer(1, "True"),new Answer(2, "False")}, correctAnswer)
        {

        }

        public override void ShowQuestion()
        {
            Console.WriteLine(this.ToString());
            foreach (Answer answer in AnswerList)
            {
                Console.WriteLine($"{answer}");
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

            return new TrueOrFalseQuestion(Header, Body, Mark, clonedRightAnswer);
        }

    }
}

    