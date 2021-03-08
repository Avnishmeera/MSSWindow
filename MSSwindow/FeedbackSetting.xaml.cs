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

namespace MSSwindow
{
    /// <summary>
    /// Interaction logic for FeedbackSetting.xaml
    /// </summary>
    public partial class FeedbackSetting : UserControl
    {
        public FeedbackSetting()
        {
            InitializeComponent();
        }

        public string DisplayedImage
        {
            get { return @"C:\Users\AZ\Desktop\MSS\MSS_21102018\03082017\MSSwindow\MSSwindow\Image\star.png"; }
        }
    }
}
