using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Закрыть приложение
        // Сделать условие вы точно хотите выйти из программы ?
        private void btnExit(object sender, MouseEventArgs e)
        {
            Close();
        }

        // Добавить Задачу
        private void addTask(object sender, MouseEventArgs e)
        {
            TaskAdd taskAdd = new TaskAdd();
            taskAdd.Show();
        }

        // Открыть калькулятор
        private void callCalc(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        // Открыть статистику
        private void openStat(object sender, MouseEventArgs e)
        {

        }

        // Перетаскивание окна
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
    }
}