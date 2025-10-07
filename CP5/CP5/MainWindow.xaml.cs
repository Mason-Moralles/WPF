using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CP5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly User user = new User();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = user;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (!user.HasErrors)
            {
                MessageBox.Show("Данные успешно отправлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                // Здесь может быть логика отправки данных
            }
            else
            {
                MessageBox.Show("Проверьте правильность заполнения формы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}