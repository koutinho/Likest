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

namespace LikestUtilityControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class RateControl : UserControl
    {
        public RateControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(Brush), typeof(RateControl));

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(RateControl));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(RateControl), new FrameworkPropertyMetadata(ValueChangedCallback));

        public Brush BorderColor
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set
            {
                SetValue(DescriptionProperty, value);
            }
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RateControl control = d as RateControl;

            if ((double)e.OldValue == 0)
                return;

            if ((double)e.NewValue > (double)e.OldValue)
            {
                control.topLine.Fill = new SolidColorBrush(Colors.Green);
                control.bottomLine.Fill = control.BorderColor;
            }
            else if ((double)e.NewValue < (double)e.OldValue)
            {
                control.bottomLine.Fill = new SolidColorBrush(Colors.Red);
                control.topLine.Fill = control.BorderColor;
            }
            else
            {
                control.topLine.Fill = control.BorderColor;
                control.bottomLine.Fill = control.BorderColor;
            }
        }
    }
}
