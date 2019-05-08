using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GehirnJogging
{
    /// <summary>
    /// Interaktionslogik für Loadingpage.xaml
    /// </summary>
    public partial class Loadingpage : Page
    {
        /// <summary>
        /// 
        /// </summary>
        public Loadingpage()
        {
            InitializeComponent();
            Start.GetNavigationService().Navigated += OnNavigated;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            ProgressAnimation();
            Start.NavigateTo("worldpage");
            Start.resetPage("loadingpage");
        }

        private async void ProgressAnimation()
        {
            Progressbar.Value = 0;
            do
            {
                Progressbar.Value = Progressbar.Value + 1;
                await Task.Delay(10);
            } while (Progressbar.Value > 100);
        }

    }
}
