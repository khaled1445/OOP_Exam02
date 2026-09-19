using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exam02
{
    internal class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject()
        {
            SubjectID = 0;
            SubjectName = string.Empty;
            SubjectExam = null;
        }
        public Subject(int subjectID, string subjectName)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            SubjectExam = null;
        }

        public void createExam()
        {
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");

            int examType;

            do
            {
                Console.Write("Choose Exam Type: ");

            } while (!int.TryParse(Console.ReadLine(), out examType) || examType < 1 || examType > 2);

            int examDuration;

            do
            {
                Console.Write("Enter Exam Duration in Minutes: ");

            } while (!int.TryParse(Console.ReadLine(), out examDuration) || examDuration <= 0);

            int numberOfQuestions;
            do
            {
                Console.Write("Enter Number Of Questions: ");

            } while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0);

            Question[] questions = new Question[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"========== Question {i + 1} ==========");

                if (examType == 1)
                {
                    // Final
                    Console.WriteLine();
                    Console.WriteLine("Choose Question Type:");
                    Console.WriteLine("1. True / False");
                    Console.WriteLine("2. MCQ");

                    int questionType;

                    do
                    {
                        Console.Write("Question Type: ");

                    } while (!int.TryParse(Console.ReadLine(), out questionType) || questionType < 1 || questionType > 2);

                    questions[i] = CreateQuestion(questionType);
                }
                else
                {
                    // Practical = MCQ only
                    questions[i] = CreateQuestion(2);
                }
            }

            // convert duration in minutes to TimeSpan required by Exam constructors
            TimeSpan examTime = TimeSpan.FromMinutes(examDuration);

            if (examType == 1)
            {
                SubjectExam = new FinalExam(examTime, numberOfQuestions, questions);
            }
            else
            {
                SubjectExam = new PracticalExam(examTime, numberOfQuestions, questions);
            }
        }

        private Question CreateQuestion(int questionType)
        {
            Console.Write("Enter Question Header: ");
            string header = Console.ReadLine() ?? "";

            Console.Write("Enter Question Body: ");
            string body = Console.ReadLine() ?? "";

            int mark;

            do
            {
                Console.Write("Enter Question Mark: ");

            } while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

            if (questionType == 1)
            {
                // True / False

                Answer[] answers =
                {
                    new Answer(1, "True"),
                    new Answer(2, "False")
                };

                Console.WriteLine();
                Console.WriteLine("Choose Right Answer:");
                Console.WriteLine("1. True");
                Console.WriteLine("2. False");

                int rightAnswer;

                do
                {
                    Console.Write("Right Answer: ");

                } while (!int.TryParse(Console.ReadLine(), out rightAnswer) || rightAnswer < 1 || rightAnswer > 2);

                return new TrueOrFalseQuestion(header, body, mark, answers[rightAnswer - 1]);
            }
            else
            {
                // MCQ

                int numberOfAnswers;

                do
                {
                    Console.Write("Enter Number Of Answers: ");

                } while (!int.TryParse(Console.ReadLine(), out numberOfAnswers) || numberOfAnswers < 2);

                Answer[] answers = new Answer[numberOfAnswers];

                for (int i = 0; i < numberOfAnswers; i++)
                {
                    Console.Write($"Enter Answer {i + 1}: ");

                    string answerText = Console.ReadLine() ?? "";

                    answers[i] = new Answer(i + 1, answerText);
                }

                Console.WriteLine();
                Console.WriteLine("Choose Right Answer:");

                for (int i = 0; i < answers.Length; i++)
                {
                    Console.WriteLine(answers[i]);
                }

                int rightAnswer;

                do
                {
                    Console.Write("Right Answer: ");

                } while (!int.TryParse(Console.ReadLine(), out rightAnswer) || rightAnswer < 1 || rightAnswer > answers.Length);

                return new MCQQuestion(header, body, mark, answers, answers[rightAnswer - 1]);
            }
        }

    }
}
