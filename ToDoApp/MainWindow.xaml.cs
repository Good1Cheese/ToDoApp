using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToDoApp
{
    public partial class MainWindow : Window
    {
        private TextBox _selectedTaskTextBox;

        public TextBox SelectedTextBox { get; set; }

        public ObservableCollection<Task> Tasks { get; } = new();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = Tasks;
        }
        
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Panel.SetZIndex(SearchTermTextBox, 1);
            SearchTermTextBox.RaiseEvent(e);
        }


        private void TaskAdded(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTermTextBox.Text)) { return; }

            Tasks.Add(new Task(SearchTermTextBox.Text));
            SearchTermTextBox.Text = string.Empty;

            Panel.SetZIndex(SearchTermTextBox, 0);
            Keyboard.ClearFocus();
        }

        private void TaskRemoved(object sender, RoutedEventArgs e) => Tasks.Remove(FindTask(sender));

        private void TaskUpdated(object sender, RoutedEventArgs e)
        {
            var task = Tasks.FirstOrDefault(t => t.Title == SelectedTextBox.Text);
            task.Title = _selectedTaskTextBox.Text;
            Keyboard.ClearFocus();
        }

        private void TaskSelected(object sender, MouseEventArgs e)
        {
            _selectedTaskTextBox = (sender as TextBox);
            SelectedTextBox = _selectedTaskTextBox;
        }

        private Task FindTask(object task)
        {
            string taskTitle = (string)(task as Button).Tag;

            return Tasks.FirstOrDefault(t => t.Title == taskTitle);
        }
    }
}
