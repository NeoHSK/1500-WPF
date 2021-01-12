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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += acButtom_Click;
            negativeButton.Click += negativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber %= 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void acButtom_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }
        
        private void negativeButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void sevenButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "7";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}7";
            }
        }
    
    }
       
}
