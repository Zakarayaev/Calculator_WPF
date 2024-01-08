using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement element in mainGridRoot.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }
            //int valueInMaiinTextBlock = 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string _string = (string)((Button)e.OriginalSource).Content;


            if (mainTextLabel.Text == "0")
            {
                mainTextLabel.Text = _string;
            }
            else if (_string == "AC")
            {
                mainTextLabel.Text = "0";
            }
            else if (_string == "C")
            {
                string currentText = mainTextLabel.Text;

                if (currentText.Length > 0)
                {
                    // Удаление последнего символа
                    currentText = currentText.Substring(0, currentText.Length - 1);

                    // Обновление текста в mainTextLabel
                    mainTextLabel.Text = currentText;
                }
            }
            else if (_string == "=")
            {
                 string equalsValue = new DataTable().Compute(mainTextLabel.Text, null).ToString();
                mainTextLabel.Text = equalsValue;
            }
            else
            {
                mainTextLabel.Text += _string;
            }
        }
    }
}
