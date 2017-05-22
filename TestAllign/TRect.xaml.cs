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
using Database;

namespace TestAllign
{
    /// <summary>
    /// Interaction logic for TRect.xaml
    /// </summary>
    public partial class TRect : UserControl
    {
        private Tests _tests;
        private List<SDLine> _sdLineOut;
        private List<SDLine> _sdLineIn;
        private MainWindow mainWindow;
        public Tests Test
        {
            get { return _tests; }
            set { _tests = value; }
        }
        public List<SDLine> SDLineOut
        {
            get { return _sdLineOut; }
            set { _sdLineOut = value; }
        }
        public List<SDLine> SDLineIn
        {
            get { return _sdLineIn; }
            set { _sdLineIn = value; }
        }

        public TRect()
        {
            InitializeComponent();
        }

        public TRect(Tests t, MainWindow MainWindow) : this()
        {
            mainWindow = MainWindow;
            _sdLineOut = new List<SDLine>();
            _sdLineIn = new List<SDLine>();
            Test = t;
            tName.Text = Test.Name;
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedSummary.pnList.Clear();
            SelectedSummary.tList.Clear();
            SelectedSummary.tpList.Clear();
            SelectedSummary.pList.Clear();
            foreach (SDLine sdl in mainWindow.SDLineList)
            {
                sdl.unSelectAll();
            }
            selectExitPath();
        }
        public void selectExitPath()
        {
            if(!SelectedSummary.tList.Contains(Test.Name))
                SelectedSummary.tList.Add(Test.Name);
            foreach (SDLine sdl in SDLineOut)
            {
                sdl.selectAll();
            }
        }
        public void selectInputPath()
        {
            if (!SelectedSummary.tList.Contains(Test.Name))
                SelectedSummary.tList.Add(Test.Name);
            foreach (SDLine sdl in SDLineIn)
            {
                sdl.selectAllIn();
            }
        }
    }
}
