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
    /// <summary>
    /// 
    /// </summary>
    public partial class Loadscreen : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public Loadscreen()
        {
            InitializeComponent();
            ProgressAnimation();
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

