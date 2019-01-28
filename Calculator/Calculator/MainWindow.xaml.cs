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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /*
     * Name: John Norris
     * Class: CIT 195
     * Date: 01/28/2018
     * Professor: John Velis
     * 
     */

    public partial class MainWindow : Window
    {
        private enum Units { feet, meters };

        Units _units;

        public MainWindow()
        {
            InitializeComponent();
            UpdateUnits();
        }

        private void InitializeWindow()
        {
            tbx_length.Focus();
            UpdateUnits();
        }


        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double volume = 0;
            string shape = ComboBox_shape.SelectionBoxItem as string;
            double shapeMulti = 1;
            
 
            if (ValidInputs(out string userFeedback))
            {
                volume = Convert.ToDouble(tbx_height.Text) *
                        Convert.ToDouble(tbx_length.Text) *
                        Convert.ToDouble(tbx_width.Text);
            switch (shape)
            {
                case "Rectangular Prisim":
                    shapeMulti = 1;
                    break;
                case "Pyramidal Prisim":
                    shapeMulti = 1.0 / 3.0;
                    break;
                default:
                    shapeMulti = 1;
                    break;

            }
            volume =  volume * shapeMulti;
            tbx_volume.Text = String.Format($"{volume}", volume);
            }
            else
            {
                MessageBox.Show(userFeedback);
            }

        }


        private void Radio(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
              UpdateUnits();
            }

        }
        private bool ValidInputs(out string userFeedback)
        {
            userFeedback = "";
            bool validInputs = true;

            if (!double.TryParse(tbx_length.Text, out double tempLength))
            {
                validInputs = false;
                userFeedback += "Please enter a real number for length." + Environment.NewLine;
            }
            if (!double.TryParse(tbx_length.Text, out double tempHeight))
            {
                validInputs = false;
                userFeedback += "Please enter a real number for height." + Environment.NewLine;
            }
            if (!double.TryParse(tbx_length.Text, out double tempWidth))
            {
                validInputs = false;
                userFeedback += "Please enter a real number for height." + Environment.NewLine;
            }

            return validInputs;
        }
        private void UpdateUnits()
        {


            if ((bool)freedom_units.IsChecked)
            {
                _units = Units.feet;
            }
            else if ((bool)boring_units.IsChecked)
            {
                _units = Units.meters;
            }

            lbl_length.Content = "Length (" + _units + ")";
            lbl_height.Content = "Height (" + _units + ")";
            lbl_width.Content = "Width (" + _units + ")";
            lbl_volume.Content = "Volume (Cubic " + _units + ")";
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void ComboBox_shape_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
