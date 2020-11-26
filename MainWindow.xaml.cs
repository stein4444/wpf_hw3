using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfCw2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        ObservableCollection<ContactBook> contactBooks = new ObservableCollection<ContactBook>();
        List<string> country = new List<string>();
        public bool isDelete = false;
        public MainWindow()
        {
            InitializeComponent();
            country = new List<string>()
            {
                "IRan",
                "Ukraine",
                "Poland",
                "Dubai",
            };
            Country.Items.Clear();
            Country.ItemsSource = country;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addContact();
            ClearData();
        }
        private void addContact()
        {
            int index = Country.SelectedIndex;
            string value = country[index];
            if (!String.IsNullOrEmpty(Name.Text) &&
                !String.IsNullOrEmpty(Surname.Text) &&
                !String.IsNullOrEmpty(Phone.Text) &&
                !String.IsNullOrEmpty(value))
            {
                Contacts.ItemsSource = contactBooks;
                Contacts.DisplayMemberPath = nameof(ContactBook.ShortCOntact);
                contactBooks.Add(new ContactBook() { Name = this.Name.Text, Surname = this.Surname.Text, Number = this.Phone.Text, Coutry = value });
            }
            else
                MessageBox.Show("Please fill all lines correct");
        }

        private void ClearData()
        {
            Name.Clear();
            Surname.Clear();
            Phone.Clear();
            Country.SelectedItem = null;
        }

        private void Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setData();
        }
        private void setData()
        {
            int index = Contacts.SelectedIndex;
            if(isDelete == false)
            {
                Name.Text = contactBooks[index].Name;
                Surname.Text = contactBooks[index].Surname;
                Phone.Text = contactBooks[index].Number;
                Country.SelectedItem = contactBooks[index].Coutry;
            }

           
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isDelete = true;
            ClearData();
            contactBooks.RemoveAt(Contacts.SelectedIndex);
            if(Contacts.SelectedItem != null)
                contactBooks.Remove(Contacts.SelectedItem as ContactBook);
            isDelete = false;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
    }

}
