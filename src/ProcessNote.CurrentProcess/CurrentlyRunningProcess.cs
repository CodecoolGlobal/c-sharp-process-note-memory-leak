using ProcessNote;

namespace ProcessNote.CurrentProcess
{
    public class CurrentllyRunningProcess
    {
        public string name { get; set; }
        public string cpuUsage { get; set; }
        public string memoryUsage { get; set; }
        public string startTime { get; set; }
        public string runTime { get; set; }
        public string note ;

        public CurrentllyRunningProcess(string name, string cpuUsage, string memoryUsage, string startTime, string runTime)
        {
            this.name = name;
            this.cpuUsage = cpuUsage;
            this.memoryUsage = memoryUsage;
            this.startTime = startTime;
            this.runTime = runTime;
        }

        public void addNote(string aNote)
        {
            this.note += aNote;
        }
    }
}
