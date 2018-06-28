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

namespace Note2
{
    /// <summary>
    /// Grid.xaml 的互動邏輯
    /// </summary>
    public partial class Grid : UserControl
    {
        public MainWindow w;
        public Grid()
        {
            InitializeComponent();
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (w != null)
            {
                w.Update();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(w != null)
            {
                w.Destory(this);
            }
        }
    }
}
