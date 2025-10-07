using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UIElement _selectedElement;
        private bool _isDragging = false;
        private Point _dragStartPoint;
        private Point _elementStartPoint;

        public MainWindow()
        {
            InitializeComponent();

            // Пример выбора элемента по клику
            MyEllipse.MouseLeftButtonDown += Element_MouseLeftButtonDown;
            MyButton.MouseLeftButtonDown += Element_MouseLeftButtonDown;
            MyTextBox.MouseLeftButtonDown += Element_MouseLeftButtonDown;

            MyEllipse.MouseMove += Element_MouseMove;
            MyButton.MouseMove += Element_MouseMove;
            MyTextBox.MouseMove += Element_MouseMove;

            MyEllipse.MouseLeftButtonUp += Element_MouseLeftButtonUp;
            MyButton.MouseLeftButtonUp += Element_MouseLeftButtonUp;
            MyTextBox.MouseLeftButtonUp += Element_MouseLeftButtonUp;

            _selectedElement = MyEllipse; // По умолчанию выбран Ellipse
        }

        private void Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _selectedElement = sender as UIElement;
            _isDragging = true;
            _dragStartPoint = e.GetPosition(MainCanvas);

            if (_selectedElement is FrameworkElement fe)
            {
                _elementStartPoint = new Point(Canvas.GetLeft(fe), Canvas.GetTop(fe));
            }
            _selectedElement.CaptureMouse();
        }

        private void Element_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && _selectedElement is FrameworkElement fe)
            {
                Point currentPoint = e.GetPosition(MainCanvas);
                double offsetX = currentPoint.X - _dragStartPoint.X;
                double offsetY = currentPoint.Y - _dragStartPoint.Y;

                Canvas.SetLeft(fe, _elementStartPoint.X + offsetX);
                Canvas.SetTop(fe, _elementStartPoint.Y + offsetY);

                // Отслеживание координат в реальном времени
                Point local = new Point(fe.ActualWidth / 2, fe.ActualHeight / 2);
                Point global = fe.TransformToAncestor(this).Transform(local);
                this.Title = $"Локальные: {local}, Глобальные: {global}";
            }
        }

        private void Element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            if (_selectedElement != null)
                _selectedElement.ReleaseMouseCapture();
        }

        private Point ConvertLocalToGlobal(UIElement element, Point localPoint)
        {
            return element.TransformToAncestor(this).Transform(localPoint);
        }

        private Point ConvertGlobalToLocal(UIElement element, Point globalPoint)
        {
            return this.TransformToDescendant(element).Transform(globalPoint);
        }

        private void ShowCoordinates_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedElement == null)
            {
                MessageBox.Show("Сначала выберите элемент.");
                return;
            }

            // Для Ellipse — центр, для остальных — центр прямоугольника
            double x = (_selectedElement as FrameworkElement)?.ActualWidth / 2 ?? 0;
            double y = (_selectedElement as FrameworkElement)?.ActualHeight / 2 ?? 0;
            Point localPoint = new Point(x, y);
            Point globalPoint = ConvertLocalToGlobal(_selectedElement, localPoint);

            MessageBox.Show(
                $"Выбран: {_selectedElement.GetType().Name}\n" +
                $"Локальные координаты: {localPoint}\n" +
                $"Глобальные координаты: {globalPoint}");
        }
    }
}