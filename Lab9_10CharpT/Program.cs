using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FacultyLife
{
    // Власні класи винятків
    public class CustomFileReadException : Exception
    {
        public CustomFileReadException(string message) : base(message) { }
    }

    public class CustomQueueOperationException : Exception
    {
        public CustomQueueOperationException(string message) : base(message) { }
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Оберіть завдання:");
                Console.WriteLine("1. Обробка файлу: друк слів на голосну та приголосну букву");
                Console.WriteLine("2. Моделювання подій на факультеті");
                Console.WriteLine("0. Вихід");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Введено некоректний варіант. Будь ласка, виберіть знову.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введено некоректний варіант. Будь ласка, виберіть знову.");
                        break;
                }
            }
        }

        static void Task1()
        {
            string filePath = "C:\\Users\\pc\\Desktop\\csharplab9-Novinska\\Lab9_10CharpT\\t2.txt";

            Queue vowelQueue = new Queue();
            Queue consonantQueue = new Queue();

            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] words = line.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        if (word.Length == 0) continue;

                        if (Array.Exists(vowels, v => v == word[0]))
                        {
                            vowelQueue.Enqueue(word);
                        }
                        else
                        {
                            consonantQueue.Enqueue(word);
                        }
                    }
                }

                Console.WriteLine("Слова, що починаються на голосну букву:");
                while (vowelQueue.Count > 0)
                {
                    Console.Write(vowelQueue.Dequeue() + " ");
                }

                Console.WriteLine();

                Console.WriteLine("Слова, що починаються на приголосну букву:");
                while (consonantQueue.Count > 0)
                {
                    Console.Write(consonantQueue.Dequeue() + " ");
                }

                Console.WriteLine();
            }
            catch (ArrayTypeMismatchException e)
            {
                Console.WriteLine("Помилка типу масиву: " + e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Помилка ділення на нуль: " + e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Індекс вийшов за межі: " + e.Message);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Невірне приведення типу: " + e.Message);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine("Недостатньо пам'яті: " + e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Переповнення: " + e.Message);
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine("Переповнення стека: " + e.Message);
            }
            catch (IOException e)
            {
                throw new CustomFileReadException("Помилка при читанні файлу: " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                throw new CustomQueueOperationException("Помилка при операції з чергою: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Невідома помилка: " + e.Message);
            }
        }

        static void Task2()
        {
            Faculty faculty = new Faculty("Computer Science");

            Student student1 = new Student("Alice");
            Student student2 = new Student("Bob");

            Professor professor1 = new Professor("Dr. Smith");
            Professor professor2 = new Professor("Dr. Johnson");

            faculty.AddStudent(student1);
            faculty.AddStudent(student2);

            faculty.AddProfessor(professor1);
            faculty.AddProfessor(professor2);

            FacultyEventManager eventManager = new FacultyEventManager();

            eventManager.RegisterStudentForLecture(student1);
            eventManager.RegisterStudentForLecture(student2);

            eventManager.RegisterProfessorForLecture(professor1);

            eventManager.RegisterStudentForExam(student1);
            eventManager.RegisterStudentForExam(student2);

            eventManager.RegisterProfessorForExam(professor2);

            eventManager.TriggerLecture();
            eventManager.TriggerExam();
        }
    }
}
