using System.Collections.Generic;
using ProcessNote.CurrentProcess;
using System.Diagnostics;
using System;


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

        /*----------------------------*/

        public void getAllRunningProcess()
        {
            var _allProcess = Process.GetProcesses();

            foreach (var acturalProcess in _allProcess)
	        {
                processes.Add(createProcessInstance(acturalProcess));

	        }

        }

        public CurrentllyRunningProcess createProcessInstance(Process process)
        {   
            try
            {
                string aRuntime = (DateTime.Now - process.StartTime).ToString();
                return new CurrentllyRunningProcess(name:process.ProcessName.ToString(), cpuUsage: process.TotalProcessorTime.ToString(),
                memoryUsage:process.PrivateMemorySize64.ToString(), startTime:process.StartTime.ToString(), runTime: aRuntime);
            }
            catch(Exception e)  
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }
    }
}
