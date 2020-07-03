using EmpireBuilderAssistant.Model;
using EmpireBuilderAssistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace EmpireBuilderAssistant.View
{
    /// <summary>
    /// Interaction logic for CardSelectionWindow.xaml
    /// </summary>
    public partial class CardSelectionWindow : Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        ObservableCollection<Card> cards;

        public CardSelectionWindow(ObservableCollection<Card> paramCards)
        {
            cards = paramCards;
            InitializeComponent();
            this.Loaded += MapPage_Loaded;

            // Center window
            Left = (System.Windows.SystemParameters.WorkArea.Width - Width) /2;
            Top = (System.Windows.SystemParameters.WorkArea.Height - Height) / 2;

            // Set this window as apps current window to get correct alt-tab behaviour
            this.Owner = App.Current.MainWindow;

            // Setup binding to cards passed in
            CardItems.ItemsSource = cards;
        }

        private void MapPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Remove system icons from window frame
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Only allow numbers in the value box
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Used for debug on
        private void Button_Click_Random(object sender, RoutedEventArgs e)
        {
            foreach (Card card in cards)
            {
                card.MakeRandomContracts();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Re-calc any contracts that were changed
            foreach (Card card in cards)
            {
                card.RecalcContracts();
            }
            
            // Close this window
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Some aspect of the contract has changed so force re-calc of the card
            ComboBox senderComboBox = sender as ComboBox;
            Card card = senderComboBox.DataContext as Card;
            card.NeedRecalc = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Some aspect of the contract has changed so force re-calc of the card
            TextBox senderTextBox = sender as TextBox;
            Card card = senderTextBox.DataContext as Card;
            card.NeedRecalc = true;
        }
    }
}
