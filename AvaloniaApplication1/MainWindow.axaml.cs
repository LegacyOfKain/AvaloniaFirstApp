using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            var textBox = this.FindControl<TextBox>("MyTextBox");
            if (textBox != null)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    // Show an alert if something was entered
                    await MessageBoxManager.GetMessageBoxStandard(
                        new MessageBoxStandardParams
                        {
                            ContentTitle = "Success",
                            ContentMessage = $"You entered: {textBox.Text}",
                            ButtonDefinitions = ButtonEnum.Ok,
                            Icon = MsBox.Avalonia.Enums.Icon.Success,
                            WindowStartupLocation = WindowStartupLocation.CenterScreen
                        }).ShowWindowDialogAsync(this); // Use ShowDialog to specify the owner
                }
                else
                {
                    // Show an error alert if the text box is blank
                    await MessageBoxManager.GetMessageBoxStandard(
                        new MessageBoxStandardParams
                        {
                            ContentTitle = "Error",
                            ContentMessage = "The text box is blank. Please enter some text.",
                            ButtonDefinitions = ButtonEnum.Ok,
                            Icon = MsBox.Avalonia.Enums.Icon.Error,
                            WindowStartupLocation = WindowStartupLocation.CenterScreen
                        }).ShowWindowDialogAsync(this); // Use ShowDialog to specify the owner
                }
            }
        }
    }
}