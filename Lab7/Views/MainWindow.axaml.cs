using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using Lab7.Models;
using Lab7.ViewModels;

namespace Lab7.Views
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

            this.FindControl<MenuItem>("Open").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.OpenFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<MenuItem>("Save").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Search File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? filePath = await taskPath;

                if (filePath != null)
                {
                    var context = this.DataContext as MainWindowViewModel;
                    context.SaveFile(string.Join(@"\", filePath));
                }
            };

            this.FindControl<DataGrid>("MyDataGrid").CellEditEnded += delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                context.BuildActualMarks();
            };

            this.FindControl<MenuItem>("AboutBtn").Click += async delegate
            {
                var svf = new AboutWindow();

                await svf.ShowDialog((Window)this.VisualRoot);
            };

        }

    }
}
