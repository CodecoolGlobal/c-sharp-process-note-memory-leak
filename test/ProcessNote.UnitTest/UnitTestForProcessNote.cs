using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessNote.Collector;
using ProcessNote.CurrentProcess;

namespace ProcessNote.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        ProcessAggregator processAggregator;

        [TestInitialize]
        public void InitTest()
        {
            processAggregator = new ProcessAggregator();
        }

        [TestMethod]
        public void GenerateFor_NoParam_ReturnAsList()
        {
            var currentlyRunningProcesses = new List<CurrentlyRunningProcess>();
            Assert.IsTrue(currentlyRunningProcesses.GetType().Equals(processAggregator.CreateProcessInstance().GetType()));
        }

        [TestMethod]
        public void CheckProcessesListSize()
        {
            var listOfRunningProcesses =  processAggregator.getProcesses();
            Process[] AllProcesses = Process.GetProcesses();
            Assert.IsFalse(listOfRunningProcesses.Count.Equals(AllProcesses.Length));
        }

        [TestMethod]
        public void AddNewProcess()
        {
            processAggregator.getAllRunningProcess();
            var SizeOfList = processAggregator.getProcesses().Count;
            processAggregator.addNewProcess(new CurrentlyRunningProcess("Test", "Test", "Test", "Test", "Test"));
            var processAggregatorSize = processAggregator.getProcesses().Count;
            Assert.AreNotEqual(SizeOfList, processAggregatorSize);
        }
    }
}
