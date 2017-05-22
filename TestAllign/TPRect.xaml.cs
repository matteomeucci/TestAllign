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
    /// Interaction logic for TPRect.xaml
    /// </summary>
    public partial class TPRect : UserControl
    {
        private TestPhases _testPhases;
        private List<SDLine> _sdLineOut;
        private List<SDLine> _sdLineIn;
        private MainWindow mainWindow;
        public TestPhases TestPhase
        {
            get { return _testPhases; }
            set { _testPhases = value; }
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
        public TPRect()
        {
            InitializeComponent();
        }

        public TPRect(TestPhases tp, MainWindow MainWindow) : this()
        {
            mainWindow = MainWindow;
            _sdLineOut = new List<SDLine>();
            _sdLineIn = new List<SDLine>();
            TestPhase = tp;
            tpName.Text = TestPhase.Name;
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
            if (!SelectedSummary.tpList.Contains(TestPhase.Name))
                SelectedSummary.tpList.Add(TestPhase.Name);
            foreach (SDLine sdl in SDLineOut)
            {
                sdl.selectAll();
            }
        }
        public void selectInputPath()
        {
            if (!SelectedSummary.tpList.Contains(TestPhase.Name))
                SelectedSummary.tpList.Add(TestPhase.Name);
            foreach (SDLine sdl in SDLineIn)
            {
                sdl.selectAllIn();
            }
        }
    }
}
