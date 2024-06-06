namespace FacultyLife
{
    public class Professor
    {
        public string Name { get; private set; }

        public Professor(string name)
        {
            Name = name;
        }

        public void OnLecture(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} is giving a lecture.");
        }

        public void OnExam(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} is supervising an exam.");
        }
    }
}
