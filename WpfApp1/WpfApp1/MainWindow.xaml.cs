using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public ReactiveCommand ShowWindow2 { get; } = new();

        public MainWindow()
        {
            ShowWindow2.Subscribe(_ =>
            {
                var window2 = new Window2();
                window2.Show();
            })
                .AddTo(Disposable);

            InitializeComponent();
        }

        protected override void OnMenuButtonClicked()
        {
            if (Menu.Visibility == Visibility.Collapsed)
            {
                Menu.Visibility = Visibility.Visible;
                MenuContent.Visibility = Visibility.Visible;
            }
            else
            {
                MenuContent.Visibility = Visibility.Collapsed;
                Menu.Visibility = Visibility.Collapsed;
            }
        }

        private void Menu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MenuContent.Visibility = Visibility.Collapsed;
            Menu.Visibility = Visibility.Collapsed;
        }
    }
}