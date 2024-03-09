using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Controls;

namespace AppointmentConnect
{
    public partial class MainPage : ContentPage
    {
        DatePicker datePicker;
        TimePicker timePicker;

        public MainPage()
        {
            // Set the background color to light green
            BackgroundColor = Color.FromRgba(144, 238, 144, 255); // Light Green

            datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 24 // Increase font size for the date picker
            };

            timePicker = new TimePicker
            {
                Format = "T",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 24 // Increase font size for the time picker
            };

            Button dateButton = new Button
            {
                Text = "Choose Date",
                BackgroundColor = Color.FromRgba(76, 175, 80, 255), // Green button color
                TextColor = Color.FromRgba(0, 0, 0, 255), // White text color
                Command = new Command(() => HandleDateButtonClicked())
            };

            Button timeButton = new Button
            {
                Text = "Choose Time",
                BackgroundColor = Color.FromRgba(76, 175, 80, 255), // Green button color
                TextColor = Color.FromRgba(0, 0, 0, 255), // White text color
                Command = new Command(() => HandleTimeButtonClicked())
            };

            Button scheduleButton = new Button
            {
                Text = "Schedule an Appointment",
                BackgroundColor = Color.FromRgba(76, 175, 80, 255), // Green button color
                TextColor = Color.FromRgba(0, 0, 0, 255), // White text color
                Command = new Command(() => HandleAppointmentButtonClicked(datePicker.Date, timePicker.Time))
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center, // Center content vertically
                Padding = new Thickness(20), // Add some padding
                Children =
                {
                    new Label
                    {
                        Text = "Welcome to Appointment Connect!",
                        FontSize = 36, // Increase font size for the title
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center, // Center label vertically
                        Margin = new Thickness(0, 20), // Add top margin
                        TextColor = Color.FromRgba(0, 0, 0, 255) // Set text color to black
                    },
                    datePicker,
                    timePicker,
                    dateButton,
                    timeButton,
                    scheduleButton
                }
            };
        }

        void HandleDateButtonClicked()
        {
            // Show DatePicker dialog
            datePicker.Focus();
        }

        void HandleTimeButtonClicked()
        {
            // Show TimePicker dialog
            // Setting the time directly instead of using Focus()
            timePicker.Time = DateTime.Now.TimeOfDay;
        }

        void HandleAppointmentButtonClicked(DateTime selectedDate, TimeSpan selectedTime)
        {
            // You can use the selectedDate and selectedTime to perform actions, such as saving the appointment.
            // For now, let's display a simple alert.
            DisplayAlert("Appointment Scheduled", $"Date: {selectedDate:D}\nTime: {selectedTime}", "OK");
        }
    }
}
