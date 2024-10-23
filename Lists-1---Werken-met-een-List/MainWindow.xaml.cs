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

using Microsoft.VisualBasic;

namespace Lists_1___Werken_met_een_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _firstNames = new string[] { "Wouter", "Paul", "Andreas", "Niels", "Kathleen", "Paul", "Silvia", "Patricia" };
        private List<string> _firstNamesList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FillFromArray()
        {
            _firstNamesList.Clear();
            _firstNamesList.AddRange(_firstNames);
        }

        private void FillListBox()
        {
            namesListBox.Items.Clear();
            foreach (string firstName in _firstNamesList)
                namesListBox.Items.Add(firstName);
        }

        private void addListButton_Click(object sender, RoutedEventArgs e)
        {
            FillFromArray();
            FillListBox();
        }

        private void insertListButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = "Aleandro";
            _firstNamesList.Add(firstName);
            namesListBox.Items.Add(firstName);
        }

        private void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            string searchedFirstName = Interaction.InputBox("Geef de voornaam in die je wil verwijderen",
                "Voornaam ingeven");

            int index = _firstNamesList.IndexOf(searchedFirstName);
            if (index == -1)
                return;

            _firstNamesList.RemoveAt(index);
            namesListBox.Items.RemoveAt(index);
        }

        private void sortListButton_Click(object sender, RoutedEventArgs e)
        {
            _firstNamesList.Sort();
            FillListBox();
        }

        private void toArrayButton_Click(object sender, RoutedEventArgs e)
        {
            string[] firstNamesArray = _firstNamesList.ToArray();
            StringBuilder builder = new StringBuilder();
            foreach (string firstName in firstNamesArray)
                builder.AppendLine(firstName);
            resultTextBox.Text = builder.ToString();
        }

        private void findItemButton_Click(object sender, RoutedEventArgs e)
        {
            string searchedFirstName = Interaction.InputBox("Geef de voornaam in die je wil zoeken",
                "Voornaam zoeken", _firstNamesList[0]);

            int index = _firstNamesList.FindIndex(firstname => firstname.Equals(searchedFirstName));
            resultTextBox.Text = index.ToString();
        }
    }
}
