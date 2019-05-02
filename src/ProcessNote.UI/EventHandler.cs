using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessNote.CurrentProcess;
using ProcessNote.Collector;
using System.Windows.Controls;

namespace ProcessNote.UI
{
    class EventHandler
    {
        private ProcessAggregator processes = new ProcessAggregator();
        private void VisualizeProcesses(DataGrid DataGridXML)
        {
            foreach (CurrentllyRunningProcess process in processes.getProcesses())
            {
                DataGridXML.Items.Add(process);
            }

        }

        public void ShowProcessDetails(ListBox ProcessDetailsXML, TextBox ProcessNote, DataGrid DataGridXML)
        {
            try
            {
                ProcessDetailsXML.Items.Clear();
                ProcessNote.Text = String.Empty;
                CurrentllyRunningProcess process = (CurrentllyRunningProcess)DataGridXML.SelectedItem;
                ProcessDetailsXML.Items.Add(process.name + "\n" + process.cpuUsage + "\n" + process.memoryUsage + "\n" + process.startTime + "\n" + process.runTime + "\n");
                ProcessNote.Text = process.note;
            }
            catch (System.NullReferenceException exception)
            {
                Console.WriteLine(exception.ToString());
            }

        }

        public void PopulateTableOnLoad(DataGrid DataGridXML)
        {
            processes.getAllRunningProcess();
            DataGridXML.IsReadOnly = true;
            VisualizeProcesses(DataGridXML);
        }

        public void SearchOnWeb(DataGrid DataGridXML)
        {
            CurrentllyRunningProcess process = (CurrentllyRunningProcess)DataGridXML.SelectedItem;
            try
            {
                string searchQuery = process.name;
                System.Diagnostics.Process.Start("https://www.google.com/search?q=" + Uri.EscapeDataString(searchQuery));
            }
            catch (System.NullReferenceException exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }

        public void SaveComment(DataGrid DataGridXML, TextBox ProcessNote)
        {
            CurrentllyRunningProcess process = (CurrentllyRunningProcess)DataGridXML.SelectedItem;
            string note = ProcessNote.Text;
            process.addNote(note);
        }

        public void RefreshOnDoubleClick(DataGrid DataGridXML, TextBox ProcessNote, ListBox ProcessDetailsXML)
        {
            CurrentllyRunningProcess process = (CurrentllyRunningProcess)DataGridXML.SelectedItem;
            ProcessDetailsXML.Items.Clear();
            processes.EmptyContainer();
            DataGridXML.Items.Clear();
            processes.getAllRunningProcess();
            VisualizeProcesses(DataGridXML);
            try
            {
                ProcessDetailsXML.Items.Add(process.name + "\n" + process.cpuUsage + "\n" + process.memoryUsage + "\n" + process.startTime + "\n" + process.runTime + "\n");
            }
            catch (System.NullReferenceException c)
            {
                Console.WriteLine(c.ToString());
            }
        }

    }

}
