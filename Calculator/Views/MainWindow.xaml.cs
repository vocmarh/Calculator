using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float ICelsius, IFahrenheit, IKelvin;
        private char IOperetor;
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in SimpleButtonsGroup.Children) //Для каждой кнопки в группе Клик=Значение контента Кнопки
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }
        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            if (tbOut.Text == "0")
            {
                tbOut.Text = "";
            }
            try
            {
                string textButton = ((Button)e.OriginalSource).Content.ToString();
                if (textButton == "CE") //очищает текстбокс и ставит 0
                {
                    tbOut.Clear();
                    tbOut.Text = "0";
                }
                else if (textButton == "←") //удаляет 1 символ в текстбоксе
                {
                    tbOut.Text = tbOut.Text.Remove(tbOut.Text.Length - 1);
                    if (tbOut.Text == "") //если сисмволов не осталось, ставит 0
                    {
                        tbOut.Text = "0";
                    }
                }
                else if (textButton == "=") //считает введеный пример в текстбоксе, заменяет , на . т.к при делении с остатком по умолчанию выводится запятая и потом ничего не считает
                {
                    tbOut.Text = new DataTable().Compute(tbOut.Text, null).ToString().Replace(",", ".");

                }
                else tbOut.Text += textButton;
            }
            catch (Exception ex) //выведет сообщение если ошибка
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Арифметические кнопки
        private void btn_Pi(object sender, RoutedEventArgs e) //Вывод Пи
        {
            tbOut.Text += "3.14159";
        }
        private void Exp(object sender, RoutedEventArgs e) //Вычисление экспоненты
        {
            double i = Double.Parse(tbOut.Text);
            tbOut.Text = Math.Round(Math.Exp(i), 4).ToString();
        }
        private void Sqrt(object sender, RoutedEventArgs e) //Вычисление корня
        {
            double i = double.Parse(tbOut.Text);
            tbOut.Text = Math.Round(Math.Sqrt(i), 4).ToString();
        }
        private void Pow(object sender, RoutedEventArgs e) //В степень 2
        {
            double i = Double.Parse(tbOut.Text);
            tbOut.Text = Math.Round(Math.Pow(i, 2), 4).ToString();
        }
        private void Sin(object sender, RoutedEventArgs e) //Вычиление синуса в радианах
        {
            double i = Double.Parse(tbOut.Text);

            tbOut.Text = Math.Round(Math.Sin(i), 4).ToString();
        }
        private void Cos(object sender, RoutedEventArgs e) //Вычиление косинуса в радианах
        {
            double i = Double.Parse(tbOut.Text);
            tbOut.Text = Math.Round(Math.Cos(i), 4).ToString();
        }
        private void tan(object sender, RoutedEventArgs e) //Вычисление тангенса в радианах
        {
            double i = Double.Parse(tbOut.Text);
            tbOut.Text = Math.Round(Math.Tan(i), 4).ToString();
        }
        private void tanh(object sender, RoutedEventArgs e) //Вычисление котангенса в радианах
        {
            double i = Double.Parse(tbOut.Text);
            tbOut.Text = Math.Round(Math.Tanh(i), 4).ToString();
        }
        private void Factorial(object sender, RoutedEventArgs e) //Вычисление факториала по аналогу последнего задания в 1-ой Теме.
        {
            double k = Double.Parse(tbOut.Text);
            int result = 1;
            for (int i = 1; i <= k; i++)
            {
                result *= i;
            }
            tbOut.Text = result.ToString();
        }
        private void PlusMinus(object sender, RoutedEventArgs e) //Меняем знак
        {
            double i = double.Parse(tbOut.Text);
            tbOut.Text = (i * (-1)).ToString();
        }
        //МЕНЮ
        private void MenuItem_Click(object sender, RoutedEventArgs e) //Выход из приложения
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //Стандартное окно 
        {
            this.Width = 430;
            tbOut.Width = 380;
            tbOut.MaxLength = 13;
            border.Width = 400;
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e) //Конвертер Температуры
        {
            this.Width = 1070;
            tbOut.Width = 582;
            tbOut.MaxLength = 20;
            border.Width = 600;
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e) //Програмное окно
        {
            this.Width = 640;
            tbOut.Width = 582;
            tbOut.MaxLength = 20;
            border.Width = 600;
        }
        private void Button_Click(object sender, RoutedEventArgs e) //конвертирует значение
        {
            switch (IOperetor)
            {
                case 'C':
                    ICelsius = float.Parse(tboxTemp.Text);
                    lbl.Content = (9 * ICelsius / 5 + 32).ToString().Replace(",", ".");
                    break;
                case 'F':
                    IFahrenheit = float.Parse(tboxTemp.Text);
                    lbl.Content = (((IFahrenheit - 32) * 5) / 9).ToString().Replace(",", ".");
                    break;
                case 'K':
                    IKelvin = float.Parse(tboxTemp.Text);
                    lbl.Content = ((((9 * IKelvin) / 5) + 32) + 273.15).ToString().Replace(",", ".");
                    break;
                default:
                    break;
            }
        }
        private void CelToFah(object sender, RoutedEventArgs e) //Радиокнопка
        {
            IOperetor = 'C';
        }
        private void FahToCel(object sender, RoutedEventArgs e) //Радиокнопка
        {
            IOperetor = 'F';
        }
        private void Kelvin(object sender, RoutedEventArgs e) //Радиокнопка
        {
            IOperetor = 'K';
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) //Резет радикнопок и удаление текста 
        {
            tboxTemp.Clear();
            lbl.Content = "";
            rbCelToFah.IsChecked = false;
            rbFahToCel.IsChecked = false;
            rbKelvin.IsChecked = false;
        }
    }
}
