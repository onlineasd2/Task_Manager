using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
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
using System.Numerics;
using System.Collections.Generic;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;
using System.Text.RegularExpressions;
using System.ComponentModel;

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

            // Настройки файла БД ENTITY FRAMEWORK
            var options = new DbContextOptionsBuilder<ContextTask>()
                .UseSqlite("Filename=../../../STask.db")
                .Options;

            using var db = new ContextTask(options);

            // Подключение к базе данных
            db.Database.EnsureCreated();

            // Вывод в таблицу данных из БД
            TaskListXML.ItemsSource = db.STasks.ToList();

            GroupByXML.ItemsSource = new string[] { "None", "Date", "Priority", "Deadline" };

            // Сохранине изменений в БД
            //db.SaveChanges();

        }

        public void GroupList()
        {
            TaskListXML.Items.GroupDescriptions.Clear();
            var property = GroupByXML.SelectedItem as string;

            if (property == "None")
            {
                return;
            }
            TaskListXML.Items.GroupDescriptions.Add(new PropertyGroupDescription(property));

        }

        // Тестовые данные
        public List<STask> CreateFakeData()
        {
            List<STask> sTasks = new List<STask>()
            {
                new STask()
                {
                    Title = "ASD",
                    Date = "07.05.2024",
                    Priority = "Высокий",
                    Deadline = "15.05.2024"
                },
                new STask()
                {
                    Title = "DDD",
                    Date = "04.05.2024",
                    Priority = "Средний",
                    Deadline = "10.05.2024"
                },
            };

            return sTasks;
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
        // Групировка при изменнеии ComboBox
        protected void ChangeGroupBy(object sender, SelectionChangedEventArgs e)
        {
            GroupList();
        }
        
    }
}