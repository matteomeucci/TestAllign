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

namespace TestAllign
{
    /// <summary>
    /// Interaction logic for SDLine.xaml
    /// </summary>
    public partial class SDLine : UserControl
    {
        private UserControl _sourceRect;
        private UserControl _destRect;
        public UserControl SourceRect
        {
            get { return _sourceRect; }
            set { _sourceRect = value; }
        }
        public UserControl DestRect
        {
            get { return _destRect; }
            set { _destRect = value; }
        }
        public SDLine()
        {
            InitializeComponent();
        }
        public SDLine(UserControl sourceRect, UserControl destRect) : this()
        {
            SourceRect = sourceRect;
            DestRect = destRect;
            sdLine.Stroke = new SolidColorBrush(Colors.Black);
            sdLine.StrokeThickness = 1.0;
            sdLine.X1 = Canvas.GetLeft(sourceRect) + sourceRect.ActualWidth;
            sdLine.X2 = Canvas.GetLeft(destRect);
            sdLine.Y1 = Canvas.GetTop(sourceRect) + sourceRect.ActualHeight / 2;
            sdLine.Y2 = Canvas.GetTop(destRect) + destRect.ActualHeight / 2;
        }
        public void selectAll()
        {
            sdLine.Stroke = new SolidColorBrush(Colors.Red);
            if (DestRect.GetType() == typeof(TRect))
            {
                ((TRect)DestRect).selectExitPath();
            }
            else if (DestRect.GetType() == typeof(TPRect))
            {
                ((TPRect)DestRect).selectExitPath();
            }
            else if (DestRect.GetType() == typeof(PRect))
            {
                ((PRect)DestRect).selectInputPath();
            }
        }
        public void selectAllIn()
        {
            sdLine.Stroke = new SolidColorBrush(Colors.Red);
            if (SourceRect.GetType() == typeof(TRect))
            {
                ((TRect)SourceRect).selectInputPath();
            }
            else if (SourceRect.GetType() == typeof(TPRect))
            {
                ((TPRect)SourceRect).selectInputPath();
            }
            else if (SourceRect.GetType() == typeof(PNRect))
            {
                ((PNRect)SourceRect).selectExitPath();
            }
        }
        public void unSelectAll()
        {
            sdLine.Stroke = new SolidColorBrush(Colors.LightGray);
        }
    }
}
