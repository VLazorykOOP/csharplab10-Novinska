namespace FacultyLife
{
    public class Student
    {
        public string Name { get; private set; }

        public Student(string name)
        {
            Name = name;
        }

        public void OnLecture(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} is attending a lecture.");
        }

        public void OnExam(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} is taking an exam.");
        }
    }
}
