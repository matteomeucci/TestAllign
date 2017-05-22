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
    /// Interaction logic for SNRect.xaml
    /// </summary>
    public partial class PNRect : UserControl
    {
        private PartNumbers _partNumebr;
        private List<SDLine> _sdLineOut;
        private MainWindow mainWindow;
        public PartNumbers PartNumebr
        {
            get { return _partNumebr; }
            set { _partNumebr = value; }
        }
        public List<SDLine> SDLineOut
        {
            get { return _sdLineOut; }
            set { _sdLineOut = value; }
        }

        public PNRect()
        {
            InitializeComponent();
        }
        public PNRect(PartNumbers pn, MainWindow MainWindow) : this()
        {
            mainWindow = MainWindow;
            _sdLineOut = new List<SDLine>();
            PartNumebr = pn;
            pnName.Text = PartNumebr.Name;
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
            if (!SelectedSummary.pnList.Contains(PartNumebr.Name))
                SelectedSummary.pnList.Add(PartNumebr.Name);
            foreach (SDLine sdl in SDLineOut)
            {
                sdl.selectAll();
            }
        }
        public void selectExitPath()
        {
            if (!SelectedSummary.pnList.Contains(PartNumebr.Name))
                SelectedSummary.pnList.Add(PartNumebr.Name);
        }
    }
}
