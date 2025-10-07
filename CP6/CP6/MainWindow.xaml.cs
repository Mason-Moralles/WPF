using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CP6
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }
        private User selectedUser;
        public User SelectedUser
        {
            get => selectedUser;
            set { selectedUser = value; OnPropertyChanged(nameof(SelectedUser)); }
        }

        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<User>
            {
                new User { Name = "Гоша", Email = "Zapevalovg@yandex.ru", Age = 19 },
                new User { Name = "Mason", Email = "mason@gmail.com", Age = 25 }
            };
            SelectedUser = Users[0];
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}