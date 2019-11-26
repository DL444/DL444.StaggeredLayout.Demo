using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DL444.StaggeredLayout.Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            for (int i = 0; i < 200; i++)
            {
                ViewModels.Add(GetRandomViewModel());
            }
        }

        private ObservableCollection<ViewModel> ViewModels { get; } = new ObservableCollection<ViewModel>();
        private ViewModel GetRandomViewModel()
        {
            int height = random.Next(8, 32) * 16;
            int uri = random.Next(0, imageUris.Length);
            return new ViewModel() { Height = height, Image = new BitmapImage(new Uri(imageUris[uri])) };
        }

        private Random random = new Random((int)DateTime.Now.Ticks);
        private string[] imageUris = new string[]
        {
            "ms-appx:///Assets/0.jpg",
            "ms-appx:///Assets/1.jpg",
            "ms-appx:///Assets/2.jpg",
            "ms-appx:///Assets/3.jpg",
            "ms-appx:///Assets/4.jpg",
            "ms-appx:///Assets/5.jpg",
            "ms-appx:///Assets/6.jpg",
        };
    }
}
