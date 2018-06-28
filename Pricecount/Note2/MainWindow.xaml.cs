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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Note2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 創建格子List
        List<Grid> grids = new List<Grid>();

        private void addTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DateTime dt = DateTime.Now;

            // 產生然後放進去 + 日期
            Grid price = new Grid();
            price.w = this;
            price.Date.Text = dt.Month + "/" + dt.Day;
            TaskList.Children.Add(price);
            grids.Add(price);
        }

        public void Update()
        {
            // 更新加總
            float ans = 0;
            foreach(Grid g in grids)
            {
                int m = 0;
                Int32.TryParse(g.Price.Text, out m);
                ans += Convert.ToInt32(m);
            }
            Ans.Text = ans.ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // 儲存成文字格式
            List<string> datas = new List<string>();
            
            foreach (Grid g in grids)
            {
                string s = "";
                
                s += g.Date.Text + " " + g.Name.Text + " " + g.Price.Text;
                
                datas.Add(s);
            }

            File.WriteAllLines(@"D:\data.txt", datas);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 如果有就讀進來
            if (File.Exists(@"D:\data.txt"))
            {
                string[] datas = File.ReadAllLines(@"D:\data.txt");

                foreach (string s in datas)
                {
                    string[] parts = s.Split(' ');
                    
                    Grid g = new Grid();
                    
                    g.Date.Text = parts[0];
                    g.Name.Text = parts[1];
                    g.Price.Text = parts[2];
                    g.w = this;
                    
                    TaskList.Children.Add(g);
                    grids.Add(g);
                }
            }

            // 重新更新
            Update();
        }

        public void Destory(Grid g)
        {
            // 摧毀格子
            grids.Remove(g);
            TaskList.Children.Remove(g);
            Update();
        }
    }

}
