using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CP8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Storyboard ellipseStoryboard;

        public MainWindow()
        {
            InitializeComponent();

            // Задание 2: Анимация Rectangle при запуске
            Loaded += (s, e) =>
            {
                // Перемещение
                var moveAnim = new DoubleAnimation
                {
                    From = 0,
                    To = 400,
                    Duration = new Duration(TimeSpan.FromSeconds(3)),
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever
                };
                AnimatedRect.BeginAnimation(Canvas.LeftProperty, moveAnim);

                // Пульсация
                var pulseAnim = new DoubleAnimation
                {
                    From = 60,
                    To = 100,
                    Duration = new Duration(TimeSpan.FromSeconds(0.8)),
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever
                };
                AnimatedRect.BeginAnimation(WidthProperty, pulseAnim);
                AnimatedRect.BeginAnimation(HeightProperty, pulseAnim);
            };

            // Задание 6: Выпадающее меню
            MenuToggle.Checked += (s, e) => ShowMenu();
            MenuToggle.Unchecked += (s, e) => HideMenu();
        }

        // Задание 1: DoubleAnimation для кнопки
        private void AnimatedButton_Click(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation
            {
                From = AnimatedButton.Width,
                To = AnimatedButton.Width == 150 ? 300 : 150,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            AnimatedButton.BeginAnimation(WidthProperty, anim);
        }

        // Задание 4: Программная анимация Ellipse
        private void StartEllipseAnimation_Click(object sender, RoutedEventArgs e)
        {
            ellipseStoryboard = new Storyboard();

            var xAnim = new DoubleAnimationUsingKeyFrames();
            xAnim.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
            xAnim.KeyFrames.Add(new LinearDoubleKeyFrame(200, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1))));
            xAnim.KeyFrames.Add(new LinearDoubleKeyFrame(400, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2))));
            xAnim.KeyFrames.Add(new LinearDoubleKeyFrame(300, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))));
            Storyboard.SetTarget(xAnim, MovingEllipse);
            Storyboard.SetTargetProperty(xAnim, new PropertyPath("(Canvas.Left)"));

            var yAnim = new DoubleAnimationUsingKeyFrames();
            yAnim.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
            yAnim.KeyFrames.Add(new LinearDoubleKeyFrame(80, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1))));
            yAnim.KeyFrames.Add(new LinearDoubleKeyFrame(40, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2))));
            yAnim.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))));
            Storyboard.SetTarget(yAnim, MovingEllipse);
            Storyboard.SetTargetProperty(yAnim, new PropertyPath("(Canvas.Top)"));

            ellipseStoryboard.Children.Add(xAnim);
            ellipseStoryboard.Children.Add(yAnim);
            ellipseStoryboard.RepeatBehavior = RepeatBehavior.Forever;
            ellipseStoryboard.Begin();
        }

        private void PauseEllipseAnimation_Click(object sender, RoutedEventArgs e)
        {
            ellipseStoryboard?.Pause();
        }

        private void ResumeEllipseAnimation_Click(object sender, RoutedEventArgs e)
        {
            ellipseStoryboard?.Resume();
        }

        // Задание 6: Анимация выпадающего меню
        private void ShowMenu()
        {
            var sb = new Storyboard();
            var heightAnim = new DoubleAnimation(0, 60, TimeSpan.FromMilliseconds(300));
            var opacityAnim = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));
            Storyboard.SetTarget(heightAnim, DropDownMenu);
            Storyboard.SetTargetProperty(heightAnim, new PropertyPath("Height"));
            Storyboard.SetTarget(opacityAnim, DropDownMenu);
            Storyboard.SetTargetProperty(opacityAnim, new PropertyPath("Opacity"));
            sb.Children.Add(heightAnim);
            sb.Children.Add(opacityAnim);
            sb.Begin();
        }
        private void HideMenu()
        {
            var sb = new Storyboard();
            var heightAnim = new DoubleAnimation(DropDownMenu.ActualHeight, 0, TimeSpan.FromMilliseconds(300));
            var opacityAnim = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(300));
            Storyboard.SetTarget(heightAnim, DropDownMenu);
            Storyboard.SetTargetProperty(heightAnim, new PropertyPath("Height"));
            Storyboard.SetTarget(opacityAnim, DropDownMenu);
            Storyboard.SetTargetProperty(opacityAnim, new PropertyPath("Opacity"));
            sb.Children.Add(heightAnim);
            sb.Children.Add(opacityAnim);
            sb.Begin();
        }
    }
}