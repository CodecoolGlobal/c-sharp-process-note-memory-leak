using System.Collections.Generic;
using ProcessNote.CurrentProcess;


namespace ProcessNote.Collector
{
  
    public class ProcessAggregator
    {
        private List<CurrentllyRunningProcess> processes;

        public ProcessAggregator()
        {
            processes = new List<CurrentllyRunningProcess>();
        }

        public void addNewProcess(CurrentllyRunningProcess process)
        {
            processes.Add(process);
        }

        public List<CurrentllyRunningProcess> getProcesses()
        {
            return processes;
        }

        public void EmptyContainer()
        {
            processes = new List<CurrentllyRunningProcess>();
        }
    }
}
