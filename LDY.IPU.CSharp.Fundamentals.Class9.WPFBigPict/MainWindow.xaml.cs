using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LDY.IPU.CSharp.Fundamentals.Class9.WPFBigPict {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            Debug.WriteLine("-------------------------------------");

            Debug.WriteLine($"===> sender.GetType().FullName {sender.GetType().FullName}");

            Debug.WriteLine($"===> ((TextBox)sender).Text = {((TextBox)sender).Text}");
            Debug.WriteLine($"===> ((TextBox)e.OriginalSource).Text = {((TextBox)e.OriginalSource).Text}");

            Debug.WriteLine("===> NameTextBox_TextChanged");
        }

        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            Debug.WriteLine("-------------------------------------");

            Debug.WriteLine($"===> sender.GetType().FullName {sender.GetType().FullName}");

            Debug.WriteLine($"===> ((TextBox)sender).Text = {((TextBox)sender).Text}");
            Debug.WriteLine($"===> ((TextBox)e.OriginalSource).Text = {((TextBox)e.OriginalSource).Text}");

            Debug.WriteLine("===> AddressTextBox_TextChanged");
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string inputInfo = 
                $"Name = {this.NameTextBox.Text}, " +
                $"Address = {this.AddressTextBox.Text}," +
                $"Password = {this.PasswordBox.Password}";
            Debug.WriteLine("===> " + inputInfo);
        }
    }
}
