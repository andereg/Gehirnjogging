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
using System.Windows.Shapes;

namespace GehirnJogging
{
    public partial class Loadscreen : Window
    {
        public Loadscreen()
        {
            InitializeComponent();
            ProgressAnimation();
            Worldmap map = new Worldmap();
            this.Close();
            map.Show();
        }

        private async void ProgressAnimation()
        {
            do
            {
                Progress.Value++;
                await Task.Delay(10);
            } while (Progress.Value < 100);
        }

    }
}

