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
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            uint selectedNumber = 0;

            if (sender == zeroButton)
                selectedNumber = 0;
            if (sender == oneButton)
                selectedNumber = 1;
            if (sender == twoButton)
                selectedNumber = 2;
            if (sender == threeButton)
                selectedNumber = 3;
            if (sender == fourButton)
                selectedNumber = 4;
            if (sender == fiveButton)
                selectedNumber = 5;
            if (sender == sixButton)
                selectedNumber = 6;
            if (sender == sevenButton)
                selectedNumber = 7;
            if (sender == eightButton)
                selectedNumber = 8;
            if (sender == nineButton)
                selectedNumber = 9;

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedNumber}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedNumber}";
            }
        }
    
    }
       
}
