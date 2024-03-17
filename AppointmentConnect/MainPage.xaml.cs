using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Controls;

namespace AppointmentConnect
{
    public partial class MainPage : ContentPage
    {
        DatePicker datePicker;
        TimePicker timePicker;
        Entry studentNameEntry;
        Picker professorPicker;

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

            studentNameEntry = new Entry
            {
                Placeholder = "Enter Student Name",
                FontSize = 20 // Set font size for the entry
            };

            professorPicker = new Picker
            {
                Title = "Select Professor",
                FontSize = 20 // Set font size for the picker
            };
            professorPicker.Items.Add("Professor A");
            professorPicker.Items.Add("Professor B");
            professorPicker.Items.Add("Professor C");
            professorPicker.Items.Add("Professor D");

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
                    studentNameEntry,
                    professorPicker,
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
            string selectedProfessor = professorPicker.SelectedItem?.ToString() ?? "No Professor Selected";
            DisplayAlert("Appointment Scheduled", $"Student Name: {studentNameEntry.Text}\nProfessor: {selectedProfessor}\nDate: {selectedDate:D}\nTime: {selectedTime}", "OK");
        }
    }
}
