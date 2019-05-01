using System;
using System.Windows;
using System.Windows.Controls;
using ProcessNote.CurrentProcess;
using ProcessNote.Collector;

namespace ProcessNote.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProcessAggregator processes = new ProcessAggregator();
        int tempCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
            ///GenerateProcesses(15);
            ///DataGridXML.IsReadOnly = true;
            ///VisualizeProcesses();
        }


        public void VisualizeProcesses()
        {
            foreach (CurrentllyRunningProcess process in processes.getProcesses())
            {
                DataGridXML.Items.Add(process);
            }

        }

        private void DataGridXML_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                ProcessDetailsXML.Items.Clear();

                CurrentllyRunningProcess process = (CurrentllyRunningProcess)DataGridXML.SelectedItem;
                ProcessDetailsXML.Items.Add(process.name + "\n" + process.memoryUsage + "\n" + process.startTime + "\n" + process.runTime + "\n");
            }
            catch (System.NullReferenceException exception)
            {
                Console.WriteLine(exception.ToString());
            }


        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessDetailsXML.Items.Clear();
            processes.EmptyContainer();
            DataGridXML.Items.Clear();
            GenerateProcesses(10);
            VisualizeProcesses();

       
        }

        public void GenerateProcesses(int j)
        {
            for (int i = 0; i < j; i++)
            {
                string tempToString = tempCounter.ToString();
                processes.addNewProcess(new CurrentllyRunningProcess("Process " + tempCounter, "100", "80", "10:40", "1:50"));
                tempCounter++;
            }
        }

        private void DataGridXML_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateProcesses(15);
            DataGridXML.IsReadOnly = true;
            VisualizeProcesses();
        }
    }
}
