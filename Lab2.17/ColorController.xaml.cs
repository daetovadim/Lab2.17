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

namespace Lab2._17
{
    /// <summary>
    /// Interaction logic for ColorController.xaml
    /// </summary>
    public partial class ColorController : UserControl
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                nameof(Color),
                typeof(Color),
                typeof(ColorController),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
                nameof(Red),
                typeof(byte),
                typeof(ColorController),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register(
                nameof(Green),
                typeof(byte),
                typeof(ColorController),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register(
                nameof(Blue),
                typeof(byte),
                typeof(ColorController),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
        
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }
        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }
        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorController colorController = (ColorController)sender;
            colorController.Red = newColor.R;
            colorController.Green = newColor.G;
            colorController.Blue = newColor.B;
        }
        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorController colorController = (ColorController)sender;
            Color color = colorController.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorController.Color = color;
        }

        public ColorController()
        {
            InitializeComponent();
        }
    }
}
