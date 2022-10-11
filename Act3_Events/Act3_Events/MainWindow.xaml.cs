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

namespace Act3_Events
{
    public partial class MainWindow : Window{
        public MainWindow()
        {
            InitializeComponent();

            Btn_1.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            Btn_Calc.MouseEnter += new MouseEventHandler(SurvolBtn);
            Btn_Calc.MouseLeave += new MouseEventHandler(AfterSurvolBtn);

        }

        private bool EstEntier(string textEnter)
        {
            return int.TryParse(textEnter, out int number);
        }

        private void VerifTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "," && !EstEntier(e.Text) && e.Text != "-")
            {
                e.Handled = true;
            }
            else
            {
                if (e.Text == "," || e.Text == "-")
                {
                    if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
        }

        private void SurvolBtn(object sender, MouseEventArgs e)
        {
            Btn_v.Visibility = Visibility.Visible;
            Btn_v.Background = Brushes.Blue;
        }

        private void AfterSurvolBtn(object sender, MouseEventArgs e)
        {
            Btn_v.Visibility = Visibility.Hidden;
            Btn_v.Background = Brushes.Transparent;
        }

        private void ClickCalc(object sender, RoutedEventArgs e)
        {
            
            string result;
            int textbox1 = Convert.ToInt32(Btn_1.Text);
            int textbox2 = Convert.ToInt32(Btn_2.Text);
            int textbox3 = Convert.ToInt32(Btn_3.Text);
            Projet mesOutils = new Projet();
            mesOutils.ResoudreTrinome(textbox1, textbox2, textbox3, out result);

            Affichage secondPage = new Affichage();
            secondPage.TextResult.Text = secondPage.TextResult.Text + " " + result;
            this.Visibility = Visibility.Hidden;
            secondPage.Show();

        }

       
    }
}
