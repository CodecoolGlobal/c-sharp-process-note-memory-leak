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
                ProcessNote.Text = String.Empty;
                CurrentllyRunningProcess process = (CurrentllyRunningProcess)DataGridXML.SelectedItem;
                ProcessDetailsXML.Items.Add(process.name + "\n" +  process.cpuUsage+ "\n" + process.memoryUsage + "\n" + process.startTime + "\n" + process.runTime + "\n");
                ProcessNote.Text = process.note;
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
            processes.getAllRunningProcess();
           // GenerateProcesses(10);
            VisualizeProcesses();

       
        }
        private void DataGridXML_Loaded(object sender, RoutedEventArgs e)
        {
            processes.getAllRunningProcess();
            DataGridXML.IsReadOnly = true;
            VisualizeProcesses();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            CurrentllyRunningProcess process = (CurrentllyRunningProcess)DataGridXML.SelectedItem;

            try
            {
                string searchQuery = process.name;
                System.Diagnostics.Process.Start("https://www.google.com/search?q=" + Uri.EscapeDataString(searchQuery));

            } catch (System.NullReferenceException exception)
            {
                Console.WriteLine(exception.ToString());
            }


        }

        /// <summary>
        /// BELOW METHOD IS USED FOR MOCKING!
        /// </summary>
        /// <param name="j"></param>

        public void GenerateProcesses(int j)
        {
            for (int i = 0; i < j; i++)
            {
                string tempToString = tempCounter.ToString();
                processes.addNewProcess(new CurrentllyRunningProcess("Process " + tempCounter, "100", "80", "10:40", "1:50"));
                tempCounter++;
            }
        }


        /*Eventhandler for Save Comment button*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            CurrentllyRunningProcess process = (CurrentllyRunningProcess)DataGridXML.SelectedItem;
            string note = ProcessNote.Text;
            process.addNote(note);

        }
    }
}
