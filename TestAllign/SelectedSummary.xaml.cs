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

namespace TestAllign
{
    /// <summary>
    /// Interaction logic for SelectedSummary.xaml
    /// </summary>
    public partial class SelectedSummary : Window
    {
        public static List<string> pnList;
        public static List<string> tList;
        public static List<string> tpList;
        public static List<string> pList;
        public SelectedSummary()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in pnList)
            {
                txtPartNumber.Text = txtPartNumber.Text + s + "\n";
            }
            foreach (string s in tList)
            {
                txtTest.Text = txtTest.Text + s + "\n";
            }
            foreach (string s in tpList)
            {
                txtTestPhase.Text = txtTestPhase.Text + s + "\n";
            }
            foreach (string s in pList)
            {
                txtPhase.Text = txtPhase.Text + s + "\n";
            }
        }
    }
}
