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
        double lastNumber, result;
        SelectedOperator selectedOperator;


        public MainWindow()
        {
            InitializeComponent();

    //Creating Event handlers for the buttons
            acButton.Click += AcButton_Click;
            positiveAndNegativeButton.Click += PositiveAndNegativeButton_Click;
            percentButton.Click += PercentButton_Click;
            equalSignButton.Click += EqualSignButton_Click;  
            
        }

        private void EqualSignButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = 0;
            

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {

                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber/100;
                resultLabel.Content = lastNumber.ToString();

            }
        }

        private void PositiveAndNegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

       
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                
                resultLabel.Content = "0";
            }

            if (sender == multiplicationButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == additionButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractionButton)
                selectedOperator = SelectedOperator.Subtraction;
        }


        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int pressedNumber = 0;

            if (sender == numberOneButton)
                pressedNumber = 1;
            if (sender == numberTwoButton)
                pressedNumber = 2;
            if (sender == numberThreeButton)
                pressedNumber = 3;
            if (sender == numberFourButton)
                pressedNumber = 4;
            if (sender == numberFiveButton)
                pressedNumber = 5;
            if (sender == numberSixButton)
                pressedNumber = 6;
            if (sender == numberSevenButton)
                pressedNumber = 7;
            if (sender == numberEightButton)
                pressedNumber = 8;
            if (sender == numberNineButton)
                pressedNumber = 9;
                       

            if (resultLabel.Content.ToString() == "0") {

                resultLabel.Content = $"{pressedNumber}";

            }
            else {
                resultLabel.Content = $"{resultLabel.Content}{pressedNumber}";
                    }
           
        }

        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        private void DecimalPointButton_Click(object sender, RoutedEventArgs e)
        {

            if (resultLabel.Content.ToString().Contains("."))
            {
                //Don't do anything
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }


        }

        public class SimpleMath
        {
            public static double Add(double number1, double number2)
            {
                return number1 + number2; 
            }

            public static double Subtract(double number1, double number2)
            {

                return number1 - number2;
            }

            public static double Multiply(double number1, double number2)
            {

                return number1 * number2;                
            }

            public static double Divide(double number1, double number2)
            {

                return number1 / number2;               
            }
        }
    }
}
