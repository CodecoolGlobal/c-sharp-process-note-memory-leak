using System.Collections.Generic;
using ProcessNote.CurrentProcess;
using System.Diagnostics;
using System;


namespace ProcessNote.Collector
{
  
    public class ProcessAggregator
    {
        private List<CurrentlyRunningProcess> processes;

        public ProcessAggregator()
        {
            processes = new List<CurrentlyRunningProcess>();
        }

        public void addNewProcess(CurrentlyRunningProcess process)
        {
            processes.Add(process);
        }

        public List<CurrentlyRunningProcess> getProcesses()
        {
            return processes;
        }

        public void EmptyContainer()
        {
            processes = new List<CurrentlyRunningProcess>();
        }

        /*----------------------------*/

        public void getAllRunningProcess()
        {
            var _allProcess = Process.GetProcesses();
            try
            {
                processes = CreateProcessInstance();
            }
            catch (System.ArgumentNullException e)
            {
                Console.Write(e.ToString());
            }
        }

        public List<CurrentlyRunningProcess> CreateProcessInstance()
        {
            List<CurrentlyRunningProcess> ListOfProcesses = new List<CurrentlyRunningProcess>();
            try
            {
                Process[] AllProcesses = Process.GetProcesses();
                List<string> AllCpuUsages = GetCPUUsage(AllProcesses);
                for (int i = 0; i < AllCpuUsages.Count; i++)
                {
                    var name = AllProcesses[i].ProcessName.ToString();
                    var cpuUsage = AllCpuUsages[i];
                    var memoryUsage = Math.Round(AllProcesses[i].PrivateMemorySize64 * (1 * (Math.Pow(10.0, -6))), 2).ToString() + " MB";
                    var runTime = (DateTime.Now - AllProcesses[i].StartTime).ToString();
                    var startTime = AllProcesses[i].StartTime.ToString();
                    CurrentlyRunningProcess temporarympProcess = new CurrentlyRunningProcess(name, cpuUsage, memoryUsage, runTime, startTime);
                    ListOfProcesses.Add(temporarympProcess);
                }
                return ListOfProcesses;
            }
            catch(Exception e)  
            {
                Console.WriteLine(e.ToString());
                return ListOfProcesses;
            }
        }

        public List<string> GetCPUUsage(Process[] processes)
        {
            var counters = new List<PerformanceCounter>();
            List<string> results = new List<string>();
            string result = "";

            foreach (Process process in processes)
            {
                var counter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                counter.NextValue();
                counters.Add(counter);
            }
            int i = 0;
            System.Threading.Thread.Sleep(1000);

            foreach (var counter in counters)
            {
                result = Math.Round(counter.NextValue(), 1) + " %";
                ++i;
                results.Add(result);
            }
            return results;
        }
    }
}
