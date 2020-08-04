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

namespace EsportManager
{
    /// <summary>
    /// Interakční logika pro WaitingDialog.xaml
    /// </summary>
    public partial class WaitingDialog : Window
    {
        public WaitingDialog(string desc)
        {
            InitializeComponent();
            ChangeDescription(desc);
        }

        public void ChangeDescription(string desc)
        {
            Description.Content = desc;
        }
    }
}
