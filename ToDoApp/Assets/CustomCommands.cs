using System.Windows.Input;

namespace ToDoApp
{
    public class CustomCommands
    {
        public static RoutedCommand TaskAdded { get; set; } = new RoutedCommand();
        public static RoutedCommand TaskUpdated { get; set; } = new RoutedCommand();

        static CustomCommands()
        {
            TaskAdded = new RoutedCommand("TaskAdded", typeof(MainWindow));
            TaskUpdated = new RoutedCommand("TaskUpdated", typeof(MainWindow));
        }

    }
}
