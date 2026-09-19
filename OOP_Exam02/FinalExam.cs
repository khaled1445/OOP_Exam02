using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam02
{
    internal class FinalExam : Exam
    {
        
        public FinalExam(TimeSpan examDuration, int numberOfQuestions, Question[] questions) : base(examDuration, numberOfQuestions, questions)
        {

        }
        public override void ShowExam()
        {
            int studentAnswer = 0;
            double totalMark = 0;
            double grade = 0;
            Console.WriteLine("============= Final Exam =============");
            Console.WriteLine($"============= {QuestionsList.Length} =============");

            foreach (Question question in QuestionsList) 
            {
                question.ShowQuestion();
                
                totalMark += question.Mark;
                
                do
                {
                    Console.Write("Enter your answer: ");

                } while (!int.TryParse(Console.ReadLine(), out studentAnswer) || studentAnswer < 1 || studentAnswer > question.AnswerList.Length);
                
                Answer selectedAnswer = question.AnswerList[studentAnswer - 1];
                
                if (question.CorrectAnswer != null && selectedAnswer.AnswerID == question.CorrectAnswer.AnswerID) 
                {
                    grade += question.Mark;
                }

                Console.WriteLine("================================");
            }

            Console.WriteLine("============= Result =============\n");
            Console.WriteLine($"Grade: {grade}/{totalMark}");
        }
    }
}
