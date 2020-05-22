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
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selectedItem = "";
        OrderList order = new OrderList();

        public MainWindow()
        {
            InitializeComponent();
            SetInterfaceFor(selectedItem);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)selectItemComboBox.SelectedItem;
            selectedItem = typeItem.Content.ToString();
            SetInterfaceFor(selectedItem);
        }

        public void SetInterfaceFor(string selectedItem)
        {
            itemNameTxtField.Text = "";
            customTxtField.Text = "";

            switch (selectedItem)
            {
                case "Tires":
                    customLbl.Content = "Tire Diameter:";
                    customLbl.Visibility = Visibility.Visible;
                    customTxtField.Visibility = Visibility.Visible;
                    modelLbl.Visibility = Visibility.Visible;
                    modelTxtField.Text = "";
                    modelTxtField.Visibility = Visibility.Visible;
                    shippingCheckBox.Visibility = Visibility.Hidden;
                    shippingCheckBox.IsChecked = false;
                    break;
                case "Windshield Wipers":
                    customLbl.Content = "Wipers length:";
                    customLbl.Visibility = Visibility.Visible;
                    customTxtField.Visibility = Visibility.Visible;
                    modelLbl.Visibility = Visibility.Hidden;
                    modelTxtField.Visibility = Visibility.Hidden;
                    shippingCheckBox.Visibility = Visibility.Visible;
                    shippingCheckBox.IsChecked = false;
                    break;
                case "Batteries":
                    customLbl.Content = "Batteries Voltage:";
                    customLbl.Visibility = Visibility.Visible;
                    customTxtField.Visibility = Visibility.Visible;
                    modelLbl.Visibility = Visibility.Hidden;
                    modelTxtField.Visibility = Visibility.Hidden;
                    shippingCheckBox.Visibility = Visibility.Visible;
                    shippingCheckBox.IsChecked = false;
                    break;
                case "":
                    customLbl.Content = "";
                    customLbl.Visibility = Visibility.Hidden;
                    customTxtField.Visibility = Visibility.Hidden;
                    modelLbl.Visibility = Visibility.Hidden;
                    modelTxtField.Visibility = Visibility.Hidden;
                    shippingCheckBox.Visibility = Visibility.Hidden;
                    break;
                default:
                    MessageBox.Show("Something is very wrong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void AddItemToOrder()
        {
            bool aux;
            switch (selectedItem)
            {
                case "Tires":
                    order.Add(new Tire(itemNameTxtField.Text, modelTxtField.Text, Int32.Parse(customTxtField.Text)));
                    break;
                case "Windshield Wipers":
                    aux = shippingCheckBox.IsChecked.HasValue ? shippingCheckBox.IsChecked.Value : false;
                    order.Add(new WindShieldWiper(itemNameTxtField.Text, Int32.Parse(customTxtField.Text), aux));
                    break;
                case "Batteries":
                    aux = shippingCheckBox.IsChecked.HasValue ? shippingCheckBox.IsChecked.Value : false;
                    order.Add(new Battery(itemNameTxtField.Text, Int32.Parse(customTxtField.Text), aux));
                    break;
                default:
                    MessageBox.Show("Something is very wrong", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            UpdateOrderHistory();
            UpdateTotalPrice();
        }

        public void UpdateOrderHistory()
        {
            orderHistoryTxtBlock.Text = "";
            for (int i = 0; i < order.Count; i++)
            {
                string item = order[i].GetType().ToString().Substring(13);
                string itemName = order[i].Name;
                int count = 1 + i;
                orderHistoryTxtBlock.Text = orderHistoryTxtBlock.Text + count + " - " + itemName + " (" + item + ")" + "\r\n";
            }
        }

        public void UpdateTotalPrice()
        {
            int totalPrice = 0;
            for (int i = 0; i < order.Count; i++)
            {
                totalPrice = totalPrice + order[i].Cost + order[i].ShipItem();
            }
            totalLabel.Content = "$" + totalPrice + ",00";
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem != "Tires")
            {
                if ((itemNameTxtField.Text != "") && (customTxtField.Text != ""))
                {
                    AddItemToOrder();
                    MessageBox.Show("Item added to order", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Fill necessary information", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                if ((itemNameTxtField.Text != "") && (customTxtField.Text != "") && (modelTxtField.Text != ""))
                {
                    AddItemToOrder();
                    MessageBox.Show("Item added to order", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Fill necessary information", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }


        }

        private void LinQ_Button_Click(object sender, RoutedEventArgs e)
        {
            linqSearchTxtBlock.Text = "";
            int tireCount = CountItemId(1);
            int batteryCount = CountItemId(2);
            int wiperCount = CountItemId(3);

            int maxOcurrency = Math.Max(tireCount, Math.Max(batteryCount, wiperCount));

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    if (maxOcurrency == tireCount)
                    {
                        linqSearchTxtBlock.Text = linqSearchTxtBlock.Text + "Tire: " + tireCount + " sold." + "\r\n";
                    }
                }
                else if (i == 1)
                {
                    if (maxOcurrency == batteryCount)
                    {
                        linqSearchTxtBlock.Text = linqSearchTxtBlock.Text + "Battery: " + batteryCount + " sold." + "\r\n";
                    }
                }
                else
                {
                    if (maxOcurrency == wiperCount)
                    {
                        linqSearchTxtBlock.Text = linqSearchTxtBlock.Text + "WindShield Wiper: " + wiperCount + " sold." + "\r\n";
                    }
                }
            }
            MessageBox.Show("Query executed", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        //couldnt find a better query to do the whole thing in once :(
        public int CountItemId(int id)
        {
            var query = from item in order where item.Id == id select item;
            return query.Count();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OrderList));
            TextWriter writer = new StreamWriter("orderHistory.xml");
            serializer.Serialize(writer, order);
            writer.Close();
            MessageBox.Show("Order Saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OrderList));
            TextReader reader = new StreamReader("orderHistory.xml");
            order = (OrderList)serializer.Deserialize(reader);
            reader.Close();

            UpdateOrderHistory();
            UpdateTotalPrice();
            MessageBox.Show("Order Loaded!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}
