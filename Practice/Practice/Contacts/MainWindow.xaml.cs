using Contacts.Classes;
using SQLite;
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

namespace Contacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contactList;

        public MainWindow()
        {
            InitializeComponent();

            readDatabase();
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();

            newContactWindow.ShowDialog();

            readDatabase();
        }

        private void readDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contactList = connection.Table<Contact>().ToList();
            }

            if(contactList != null)
            {
#if false

                contactsListView.Items.Clear();
                foreach (var contact in contactList)
                {
                    contactsListView.Items.Add(new ListViewItem()
                    {
                        Content = contact
                    });
                }
#else
                contactsListView.ItemsSource = contactList;
#endif

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            //var filteredList = contactList.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            var filteredListLinq = (from c in contactList
                                    where c.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                                    orderby c.Email
                                    select c).ToList();

            //contactsListView.ItemsSource = filteredList;

            contactsListView.ItemsSource = filteredListLinq;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if(selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();
            }

            readDatabase();

        }
    }
}
