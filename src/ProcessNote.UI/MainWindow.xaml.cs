using System;
using System.Windows;
using System.Windows.Controls;
using ProcessNote.CurrentProcess;
using ProcessNote.Collector;

namespace ProcessNote.UI
{
    
    public partial class MainWindow : Window
    {
        
        private EventHandler eventHandler = new EventHandler();

        public MainWindow()
        {
            InitializeComponent();   
        }

        private void DataGridXML_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            eventHandler.ShowProcessDetails(ProcessDetailsXML, ProcessNote, DataGridXML);
        }

        private void DataGridXML_Loaded(object sender, RoutedEventArgs e)
        {
            eventHandler.PopulateTableOnLoad(DataGridXML);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            eventHandler.SearchOnWeb(DataGridXML);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            eventHandler.SaveComment(DataGridXML, ProcessNote);
        }

        private void DataGridXML_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            eventHandler.RefreshOnDoubleClick(DataGridXML, ProcessNote, ProcessDetailsXML);
        }
    }
}
