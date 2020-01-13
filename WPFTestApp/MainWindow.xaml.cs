using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPFTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow MV;

        public MainWindow()
        {
            MV = this;
            InitializeComponent();
        }

        private void NewSize(object sender, SizeChangedEventArgs e)
        {

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            double[] r = Items.Calculate_Width();
            Thread t = new Thread(() => Items.AddItems(r[0], r[1], (int)r[2]), 0);
            t.Start();
        }
    }

    public static class Items
    {
        enum Col_Definitions
        {
            Five = 5, Ten = 10, Fifteen = 15, Twenty = 20
        }

        enum Row_Definitions
        {
            One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eaght = 8, Nine = 9, Ten = 10
        }

        private static int Number_OfItems { get { return MainWindow.MV.Numeric_UpDown.Value ?? 0; } }

        private static double Window_Width { get { return MainWindow.MV.ActualWidth; } }

        public static double[] Calculate_Width()
        {
            double t_width = default;
            foreach (ColumnDefinition cd in MainWindow.MV.MyGrid.ColumnDefinitions)
            {
                t_width += cd.ActualWidth;
            }
            Console.WriteLine($"Total Definition Width is @ { t_width }, while Window Width is @ { Window_Width }");

            /* Do calculation here before returning */
            return new double[] { Window_Width, t_width, (double)Col_Definitions.Five, (double)Row_Definitions.Three };
        }

        public static void AddItems(double C_def, double R_def, int Num_Of_Items)
        {
            /* C_def, R_def will be passed in after being returned from the calculation_width method */
            /* Here you add your additional definitions and extend your template etc */
        }
    }
}
