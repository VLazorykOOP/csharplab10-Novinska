namespace FacultyLife
{
    public class FacultyEventManager
    {
        public Event LectureEvent { get; private set; }
        public Event ExamEvent { get; private set; }

        public FacultyEventManager()
        {
            LectureEvent = new Event("Lecture");
            ExamEvent = new Event("Exam");
        }

        public void RegisterStudentForLecture(Student student)
        {
            LectureEvent.Occurred += student.OnLecture;
        }

        public void RegisterStudentForExam(Student student)
        {
            ExamEvent.Occurred += student.OnExam;
        }

        public void RegisterProfessorForLecture(Professor professor)
        {
            LectureEvent.Occurred += professor.OnLecture;
        }

        public void RegisterProfessorForExam(Professor professor)
        {
            ExamEvent.Occurred += professor.OnExam;
        }

        public void TriggerLecture()
        {
            Console.WriteLine("Triggering lecture event...");
            LectureEvent.TriggerEvent();
        }

        public void TriggerExam()
        {
            Console.WriteLine("Triggering exam event...");
            ExamEvent.TriggerEvent();
        }
    }
}
