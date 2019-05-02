using ProcessNote;

namespace ProcessNote.CurrentProcess
{
    public class CurrentlyRunningProcess
    {
        public string name { get; set; }
        public string cpuUsage { get; set; }
        public string memoryUsage { get; set; }
        public string startTime { get; set; }
        public string runTime { get; set; }
        public string note ;

        public CurrentlyRunningProcess(string name, string cpuUsage, string memoryUsage, string startTime, string runTime)
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

        public override string ToString()
        {
            return string.Format("Process name: {0}\nMemory usage: {1}\nCPU usage: {2}\nRunning time: {3}\nStart time: {4}", name, memoryUsage, cpuUsage, runTime, startTime);
        }
    }
}
