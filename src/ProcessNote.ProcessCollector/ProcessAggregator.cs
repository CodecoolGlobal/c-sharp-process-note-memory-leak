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

                try
                {
                    processes.Add(createProcessInstance(acturalProcess));
                }
                catch (System.ArgumentNullException e)
                {
                    Console.Write(e.ToString());
                }

                
               
	        }

        }

        public CurrentllyRunningProcess createProcessInstance(Process process)
        {   
            try
            {

                var _name = process.ProcessName.ToString();
                var _cpuUsage = "CPU: " + process.TotalProcessorTime.ToString();
                var _memoryUsage = "Memory: " + process.PrivateMemorySize64.ToString();
                var _runtime = "Run time: "+ (DateTime.Now - process.StartTime).ToString();
                var _startTime = "Start Time: " + process.StartTime.ToString();
                return new CurrentllyRunningProcess(_name, _cpuUsage, _memoryUsage, _startTime, _runtime);

            }
            catch(Exception e)  
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }
    }
}
