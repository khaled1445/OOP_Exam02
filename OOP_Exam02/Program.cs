
namespace OOP_Exam02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(34, "C# Programming");

            Console.WriteLine("================================");
            Console.WriteLine("   Welcme to Your EXAMINATION Gate");
            Console.WriteLine("================================");

            Console.WriteLine();

            Console.WriteLine($"Subject ID: {subject.SubjectID}");
            Console.WriteLine($"Subject Name: {subject.SubjectName}");

            Console.WriteLine();

            subject.createExam();

            Console.WriteLine();
            Console.WriteLine("Press any key to start the exam...");

            Console.ReadKey();

            if (subject.SubjectExam != null)
            {
                subject.SubjectExam.ShowExam();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");

            Console.ReadKey();

        }
    }
}
