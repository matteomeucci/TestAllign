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
using System.Transactions;

namespace TestAllign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<PNRect> pnRectList = new List<PNRect>();
        private List<TRect> tRectList = new List<TRect>();
        private List<TPRect> tpRectList = new List<TPRect>();
        private List<PRect> pRectList = new List<PRect>();
        private List<SDLine> sdLineList = new List<SDLine>();
        private APSWDatabaseEntities apsw;
        public List<SDLine> SDLineList
        {
            get { return sdLineList; }
            set { sdLineList = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            SelectedSummary.pnList = new List<string>();
            SelectedSummary.tList = new List<string>();
            SelectedSummary.tpList = new List<string>();
            SelectedSummary.pList = new List<string>();
            DrawElements();
        }

        private void DrawElements()
        {
            try
            {
                apsw = new APSWDatabaseEntities();

                int top = 10;
                int left = 10;
                foreach (PartNumbers pn in apsw.PartNumbers)
                {

                    PNRect pnRect = new PNRect(pn, this);
                    Canvas.SetLeft(pnRect, left);
                    Canvas.SetTop(pnRect, top);
                    MainCanvas.Children.Add(pnRect);
                    top += 70;
                    pnRectList.Add(pnRect);
                }

                top = 10;
                left = 450;
                foreach (Tests t in apsw.Tests)
                {
                    TRect tRect = new TRect(t, this);
                    Canvas.SetLeft(tRect, left);
                    Canvas.SetTop(tRect, top);
                    MainCanvas.Children.Add(tRect);
                    top += 70;
                    tRectList.Add(tRect);
                }

                top = 10;
                left = 900;
                foreach (TestPhases tp in apsw.TestPhases)
                {
                    TPRect tpRect = new TPRect(tp, this);
                    Canvas.SetLeft(tpRect, left);
                    Canvas.SetTop(tpRect, top);
                    MainCanvas.Children.Add(tpRect);
                    top += 70;
                    tpRectList.Add(tpRect);
                }

                top = 10;
                left = 1350;
                foreach (Phases p in apsw.Phases.OrderBy(x => x.Name))
                {
                    PRect pRect = new PRect(p, this);
                    Canvas.SetLeft(pRect, left);
                    Canvas.SetTop(pRect, top);
                    MainCanvas.Children.Add(pRect);
                    top += 70;
                    pRectList.Add(pRect);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (PartNumbers pn in apsw.PartNumbers.Include("PNTests.Tests"))
            {
                var pnRect = pnRectList.Where(x => x.PartNumebr.ID == pn.ID).FirstOrDefault();
                foreach (PNTests pnt in pn.PNTests)
                {
                    var tRect = tRectList.Where(x => x.Test.ID == pnt.Test).FirstOrDefault();
                    SDLine sdl = new SDLine(pnRect, tRect);
                    pnRect.SDLineOut.Add(sdl);
                    tRect.SDLineIn.Add(sdl);
                    sdLineList.Add(sdl);
                    MainCanvas.Children.Add(sdl);
                }
            }

            foreach (Tests t in apsw.Tests.Include("TestCompositions.TestPhases"))
            {
                var tRect = tRectList.Where(x => x.Test.ID == t.ID).FirstOrDefault();
                foreach (TestCompositions tc in t.TestCompositions)
                {
                    var tpRect = tpRectList.Where(x => x.TestPhase.ID == tc.TestPhase).FirstOrDefault();
                    SDLine sdl = new SDLine(tRect, tpRect);
                    tRect.SDLineOut.Add(sdl);
                    tpRect.SDLineIn.Add(sdl);
                    sdLineList.Add(sdl);
                    MainCanvas.Children.Add(sdl);
                }
            }

            foreach (TestPhases tp in apsw.TestPhases.Include("Phases"))
            {
                var tpRect = tpRectList.Where(x => x.TestPhase.ID == tp.ID).FirstOrDefault();
                var pRect = pRectList.Where(x => x.Phase.ID == tp.Phases.ID).FirstOrDefault();
                SDLine sdl = new SDLine(tpRect, pRect);
                tpRect.SDLineOut.Add(sdl);
                pRect.SDLineIn.Add(sdl);
                sdLineList.Add(sdl);
                MainCanvas.Children.Add(sdl);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SelectedSummary ss = new SelectedSummary();
            ss.Show();
        }
    }
}
