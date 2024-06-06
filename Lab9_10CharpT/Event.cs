namespace FacultyLife
{
    public class Event
    {
        public string Title { get; private set; }

        public Event(string title)
        {
            Title = title;
        }

        public event EventHandler<EventArgs> Occurred;

        public void TriggerEvent()
        {
            Occurred?.Invoke(this, EventArgs.Empty);
        }
    }
}
