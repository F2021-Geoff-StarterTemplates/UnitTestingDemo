using System.Windows;
using System.Windows.Controls;

namespace UnitTestingDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()     //Default constructor
    {
        InitializeComponent();
    }

    #region "Button click event methods"
    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            int num1 = Convert.ToInt32(FirstNumberTextBox.Text);
            int num2 = Convert.ToInt32(SecondNumberTextBox.Text);
            int result = 0;
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

    private void CalculateTieredButton_Click(object sender, RoutedEventArgs e)
    {
        string userInput = DataAmountTextBox.Text;
        TierResultLabel.Content = CalculateTiered(userInput);
    }
    #endregion

    #region "Calculation methods"
    public int Add(int num1, int num2) => num1 + num2;
    public int Subtract(int num1, int num2) => num1 - num2;
    public int Multiply(int num1, int num2) => num1 * num2;
    public int Divide(int num1, int num2)
    {
        try { 
            return num1 / num2;
        }
        catch (DivideByZeroException) { 
            throw new DivideByZeroException("Cannot divide by zero."); }
    }

    public int CalculateTiered(string dataAmount)
    {
        try
        {
            int dataAmountInt = Convert.ToInt32(dataAmount);
            if (dataAmountInt < 0)
            {
                throw new InvalidOperationException("Data amount cannot be negative.");
            }
            else if (dataAmountInt <= 100)
            {
                return 10;
            }
            else if (dataAmountInt > 100 && dataAmountInt <= 200)
            {
                return 20;
            }
            else if (dataAmountInt > 200 && dataAmountInt <= 300)
            {
                return 30;
            }
            else
            {
                return 40;
            }
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException("Negative data amount");
        }
        catch (FormatException ex)
        {
            throw new FormatException("Not a valid number");
        }
        catch (OverflowException ex)
        {
            throw new OverflowException("Number too large");
        }
        catch (Exception ex)
        {
            throw new Exception("General error");
        }
    }
    #endregion
}