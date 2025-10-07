using System.ComponentModel;

namespace CP6
{
    public class User : INotifyPropertyChanged
    {
        private string name;
        private string email;
        private int age;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        public int Age
        {
            get => age;
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}