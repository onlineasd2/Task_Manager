using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace Task_Manager
{
    /// <summary>
    /// Interaction logic for TaskAdd.xaml
    /// </summary>
    public partial class TaskAdd : Window
    {
        public TaskAdd()
        {
            InitializeComponent();
            // Закидываем в Combobox данные
            string[] priorityTask = { "high", "medium", "low" };

            priorityXML.ItemsSource = priorityTask;
            priorityXML.SelectedItem = priorityTask[0]; // Ставим первый элемент чтобы не было null в combobox
        }

        private void btnExit(object sender, MouseEventArgs e)
        {
            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void AddTask_btn(object sender, RoutedEventArgs e)
        {           
            
            // Настройки файла БД ENTITY FRAMEWORK
            var options = new DbContextOptionsBuilder<ContextTask>()
                .UseSqlite("Filename=../../../STask.db")
                .Options;

            using var db = new ContextTask(options);


            // Создаем задание
            // Получаем из TextBox строку
            string taskTitle = TextBox_Task.Text;

            // Получаем текущую дату, когда создается задание
            string date = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();

            // Ставим приоритет
            string priorityTask = priorityXML.SelectedItem.ToString();

            // Ставим дедлайн
            var deadLineTemp = deadlineXML.SelectedDate;
            string deadLine = deadLineTemp.Value.Day.ToString() + "." + deadLineTemp.Value.Month.ToString() + "." + deadLineTemp.Value.Year.ToString();

            // Создаем поля для экспорта в БД
            var task = new STask()
            {
                Title = taskTitle,
                Date = date,
                Priority = priorityTask,
                Deadline = deadLine
            };

            // Добавление в БД задание
            db.STasks.Add(task);

            // Сохранине изменений в БД
            db.SaveChanges();

        }
    }
}
