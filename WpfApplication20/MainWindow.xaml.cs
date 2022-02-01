using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading.Tasks;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in klava.Children) //Цикл прохождения по всем кнопкам елемента юниформгрид.
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {


            try
            {
                string textButton = ((Button)e.OriginalSource).Content.ToString(); // ввод значения кнопки
                if (textButton == "C") //удаление всего текста
                {
                    otvet.Text = "";
                }
                else if (textButton == "√x") // выщитавает корень квадратный с округлением до 9 знаков
                {
                    otvet.Text = otvet.Text = Math.Round(Math.Sqrt(Convert.ToDouble(otvet.Text)), 9).ToString();

                }
                else if (textButton == "1/x") //выщитывает дробь 1 разделить на введенное число с округлением до 9 знаков
                {
                    otvet.Text = Math.Round(1 / Convert.ToDouble(otvet.Text),9).ToString();


                }
                else if (textButton == "x²") //выщитывает квадрат числа с округлением до 9 знаков
                {
                    otvet.Text = Math.Round(Math.Pow(Convert.ToDouble(otvet.Text), 2),9).ToString();


                }
                else if (textButton == "=") // выводит ответ на выражение
                {
                    
                    otvet.Text = new DataTable().Compute(otvet.Text, null).ToString(); //метод вычисления выражения на экране
                    otvet.Text = Math.Round(Convert.ToDouble(otvet.Text), 9).ToString(); //Округление ответа
                    if (otvet.Text == "бесконечность") otvet.Text = " ÷ на 0"; //Деление на ноль
                    
                    
                }
                else otvet.Text += textButton; //добавление => цифры

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // выводит сообщения об исключение из правил
            }

        }
    }

}
