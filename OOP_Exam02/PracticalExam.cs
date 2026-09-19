using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam02
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(TimeSpan examDuration, int numberOfQuestions, Question[] questions) : base(examDuration, numberOfQuestions, questions)
        {
        }
        public override void ShowExam()
        {
            int studentAnsewer = 0;

            Console.WriteLine("============= Practical Exam =============");

            foreach (Question question in QuestionsList)
            {
                question.ShowQuestion();

                do
                {
                    Console.WriteLine("Enter your answer: ");
                }
                while (!int.TryParse(Console.ReadLine(), out studentAnsewer) || studentAnsewer < 1 || studentAnsewer > question.AnswerList.Length);



                Console.WriteLine("================================");
            }

            Console.WriteLine("============= The right answers =============\n");
            
            foreach (Question question in QuestionsList)
            {
                Console.WriteLine($"Question: {question.Body} \n Correct Answer: {question.CorrectAnswer.AnswerText}");

            }
        }
    }
}
