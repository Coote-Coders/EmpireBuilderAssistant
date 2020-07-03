using EmpireBuilderAssistant.Model;
using EmpireBuilderAssistant.View;
using EmpireBuilderAssistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace EmpireBuilderAssistant
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ActionList actionList;
        ObservableCollection<Card> cards;
        bool displayDestinationsOnly;

        public MainWindow()
        {
            // Display pickups location on map
            displayDestinationsOnly = false;

            InitializeComponent();
            this.Loaded += MapPage_Loaded;

            // Center window
            Left = (System.Windows.SystemParameters.WorkArea.Width - Width) / 2;
            Top = (System.Windows.SystemParameters.WorkArea.Height - Height) / 2;

            // Create cards
            cards = new ObservableCollection<Card> {new Card("Card 1", Colors.Red),
                                                    new Card("Card 2", Colors.Green),
                                                    new Card("Card 3", Colors.Blue)};

            // Create action list
            actionList = new ActionList();

            // Set binding
            ActionListBox.DataContext = actionList;
            CardItems.ItemsSource = cards;
        }

        private void MapPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Draw the icons for each conract in the card section
            try
            {
                foreach (var card in CardItems.Items)
                {
                    Card cardObj = card as Card;

                    ContentPresenter cp = (ContentPresenter)CardItems.ItemContainerGenerator.ContainerFromItem(card);
                    Canvas route1Icon = cp.ContentTemplate.FindName("RouteIcon1", cp) as Canvas;
                    DrawIcon.DrawCardIcon(route1Icon, cardObj.Contracts[0].IconColor, cardObj.Contracts[0].IconShape);

                    Canvas route2Icon = cp.ContentTemplate.FindName("RouteIcon2", cp) as Canvas;
                    DrawIcon.DrawCardIcon(route2Icon, cardObj.Contracts[1].IconColor, cardObj.Contracts[1].IconShape);

                    Canvas route3Icon = cp.ContentTemplate.FindName("RouteIcon3", cp) as Canvas;
                    DrawIcon.DrawCardIcon(route3Icon, cardObj.Contracts[2].IconColor, cardObj.Contracts[2].IconShape);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            // Open card edit box as app has just started
            OpenCardEditDiagBox();
        }

        private void OpenCardEditDiagBox()
        {
            CardSelectionWindow modalWindow = new CardSelectionWindow(cards);
            modalWindow.ShowDialog();
        }

        private void ReDraw()
        {
            // Clear the canvas
            mapCanvas.Children.Clear();

            // Loop through all cards
            foreach (Card card in cards)
            {
                // Skip card is not enabled
                if (card.IsCardVisible == false)
                {
                    continue;
                }

                // Loop though each contract
                foreach (Contract contract in card.Contracts)
                {
                    // Skip if contract is not enabled
                    if (contract.IsContractVisible == false)
                    {
                        continue;
                    }

                    // Skip items that are not valid
                    if (contract.Destintion == null || contract.SelectedPickup == null || contract.SelectedPickup.PickupCity == null)
                    {
                        continue;
                    }

                    // Display the destination icon
                    DrawIcon.DrawMapIcon(mapCanvas, contract.IconColor, contract.IconShape, true, contract.Destintion.PosX, contract.Destintion.PosY);

                    if (displayDestinationsOnly)
                    {
                        // Skip drawing pickup icons
                        continue;
                    }

                    // Display pickup cities
                    if (contract.SelectedPickup.PickupCity.PosX == 0 && contract.SelectedPickup.PickupCity.PosY == 0)
                    {
                        // Draw all options
                        foreach (PickupInfo pickupInfo in contract.PickupList)
                        {
                            // Skip the "All City" entry
                            if (pickupInfo.PickupCity.PosX == 0 && pickupInfo.PickupCity.PosY == 0)
                            {
                                continue;
                            }
                            DrawIcon.DrawMapIcon(mapCanvas, contract.IconColor, contract.IconShape, false, pickupInfo.PickupCity.PosX, pickupInfo.PickupCity.PosY);
                        }
                    }
                    else
                    {
                        // Draw the selected one
                        DrawIcon.DrawMapIcon(mapCanvas, contract.IconColor, contract.IconShape, false, contract.SelectedPickup.PickupCity.PosX, contract.SelectedPickup.PickupCity.PosY);
                    }
                }
            }
        }

        private void MapCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ReDraw();
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            // Clear the wet ink
            mapInkCanvas.Strokes.Clear();
        }

        private void Button_Click_EditCard(object sender, RoutedEventArgs e)
        {
            OpenCardEditDiagBox();
            ReDraw();
        }

        private void Button_Click_Debug(object sender, RoutedEventArgs e)
        {
#if DEBUG
            Debugger.Break();
#endif
        }

        private void Button_Click_Copy(object sender, RoutedEventArgs e)
        {
            // Change all current wet ink to green
            foreach (var stroke in mapInkCanvas.Strokes)
            {
                stroke.DrawingAttributes.Color = Colors.Green;
            }

            // Copy all wet ink strokes to dry ink canvas
            var Stokes = mapInkCanvas.Strokes;
            mapInkCanvasStatic.Strokes.Add(Stokes);

            // Clear wet ink
            mapInkCanvas.Strokes.Clear();
        }

        private void Button_Click_Clear_Static(object sender, RoutedEventArgs e)
        {
            // Clear the dry ink
            mapInkCanvasStatic.Strokes.Clear();
        }

        private void SelectionChanged_RedrawOverlay(object sender, SelectionChangedEventArgs e)
        {
            ReDraw();
        }

        private void CheckBox_Click_RedrawOverlay(object sender, RoutedEventArgs e)
        {
            ReDraw();
        }

        private void Button_Click_ListDel(object sender, RoutedEventArgs e)
        {
            // Remove current action
            if (ActionListBox.SelectedItems.Count > 0)
            {
                PlayerAction selected = ActionListBox.SelectedItem as PlayerAction;
                actionList.Actions.Remove(selected);
            }
        }

        private void Button_Click_ListDown(object sender, RoutedEventArgs e)
        {
            // Move current action down
            if (ActionListBox.SelectedItems.Count > 0)
            {
                PlayerAction selected = ActionListBox.SelectedItem as PlayerAction;
                int indx = ActionListBox.Items.IndexOf(selected);
                int totl = ActionListBox.Items.Count;

                if (indx == totl - 1)
                {
                    // If the item is last in the listbox, move it all the way to the top
                    actionList.Actions.Remove(selected);
                    actionList.Actions.Insert(0, selected);
                    ActionListBox.SelectedIndex = 0;
                }
                else
                {
                    // To move the selected item downwards in the listbox
                    actionList.Actions.Remove(selected);
                    actionList.Actions.Insert(indx + 1, selected);
                    ActionListBox.SelectedIndex = indx + 1;
                }
            }
        }

        private void Button_Click_ListUp(object sender, RoutedEventArgs e)
        {
            // Move current item up
            if (ActionListBox.SelectedItems.Count > 0)
            {
                PlayerAction selected = ActionListBox.SelectedItem as PlayerAction;
                int indx = ActionListBox.Items.IndexOf(selected);
                int totl = ActionListBox.Items.Count;

                if (indx == 0)
                {
                    // If the item is right at the top, throw it right down to the bottom
                    actionList.Actions.Remove(selected);
                    actionList.Actions.Insert(totl - 1, selected);
                    ActionListBox.SelectedIndex = totl - 1;
                }
                else
                {
                    // To move the selected item upwards in the listbox
                    actionList.Actions.Remove(selected);
                    actionList.Actions.Insert(indx - 1, selected);
                    ActionListBox.SelectedIndex = indx - 1;
                }
            }
        }

        private void Button_Click_ListClearAll(object sender, RoutedEventArgs e)
        {
            // Clear the selection, this may help get round an issue where the list does not work when user somehow selects
            // multiple lines
            ActionListBox.SelectedIndex = 0;

            // Ask user if he really want to clear
            MessageBoxResult result = MessageBox.Show("You you want to clear the list?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                actionList.Actions.Clear();
            }
        }

        private void Button_Click_Contract1Add(object sender, RoutedEventArgs e)
        {
            // An 'Add' buttons for card 1 was clicked
            Button senderButton = sender as Button;
            Card card = senderButton.DataContext as Card;
            if (card != null)
            {
                actionList.AddContractActions(card.Contracts[0]);
            }
        }

        private void Button_Click_Contract2Add(object sender, RoutedEventArgs e)
        {
            // An 'Add' buttons for card 2 was clicked
            Button senderButton = sender as Button;
            Card card = senderButton.DataContext as Card;
            if (card != null)
            {
                actionList.AddContractActions(card.Contracts[1]);
            }
        }

        private void Button_Click_Contract3Add(object sender, RoutedEventArgs e)
        {
            // An 'Add' buttons for card 3 was clicked
            Button senderButton = sender as Button;
            Card card = senderButton.DataContext as Card;
            if (card != null)
            {
                actionList.AddContractActions(card.Contracts[2]);
            }
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            // Draw the contract icons for this action item
            Canvas senderCanvas = sender as Canvas;
            PlayerAction action = senderCanvas.DataContext as PlayerAction;
            if (action != null)
            {
                DrawIcon.DrawCardIcon(senderCanvas, action.ActionColor, action.ActionShape);
            }
        }

        private void DestionationOnly_Click(object sender, RoutedEventArgs e)
        {
            // Check if we want to show destination only
            displayDestinationsOnly = DestionationOnly.IsChecked == true;
            ReDraw();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Show the about box
            AboutBox modalWindow = new AboutBox();
            modalWindow.ShowDialog();
        }
    }
}
