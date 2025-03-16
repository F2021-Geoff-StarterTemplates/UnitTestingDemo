using System.Windows;
using System.Windows.Controls;

namespace UnitTestingDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            double num1 = Convert.ToDouble(FirstNumberTextBox.Text);
            double num2 = Convert.ToDouble(SecondNumberTextBox.Text);
            double result = 0;
            string operation = (OperationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (operation == "+") { result = Add(num1, num2); }
            else if (operation == "-") { result = Subtract(num1, num2); }
            else if (operation == "*") { result = Multiply(num1, num2); }
            else if (operation == "/") { result = Divide(num1, num2); }
            else { throw new InvalidOperationException("Invalid operation selected."); }

            ResultLabel.Content = result.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Calculation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        FirstNumberTextBox.Text = string.Empty;
        SecondNumberTextBox.Text = string.Empty;
        OperationComboBox.SelectedIndex = -1;
        ResultLabel.Content = string.Empty;
    }

    private double Add(double num1, double num2) => num1 + num2;
    private double Subtract(double num1, double num2) => num1 - num2;
    private double Multiply(double num1, double num2) => num1 * num2;
    private double Divide(double num1, double num2) => num1 / num2;

}