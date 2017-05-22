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
    /// Interaction logic for PRect.xaml
    /// </summary>
    public partial class PRect : UserControl
    {

        private Phases _phases;
        private List<SDLine> _sdLineIn;
        private MainWindow mainWindow;
        public Phases Phase
        {
            get { return _phases; }
            set { _phases = value; }
        }
        public List<SDLine> SDLineIn
        {
            get { return _sdLineIn; }
            set { _sdLineIn = value; }
        }

        public PRect()
        {
            InitializeComponent();
        }

        public PRect(Phases p, MainWindow MainWindow) : this()
        {
            mainWindow = MainWindow;
            _sdLineIn = new List<SDLine>();
            Phase = p;
            pName.Text = Phase.Name;
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
            if (!SelectedSummary.pList.Contains(Phase.Name))
                SelectedSummary.pList.Add(Phase.Name);
            foreach (SDLine sdl in SDLineIn)
            {
                sdl.selectAllIn();
            }
        }
        public void selectInputPath()
        {
            if (!SelectedSummary.pList.Contains(Phase.Name))
                SelectedSummary.pList.Add(Phase.Name);
        }
    }
}
