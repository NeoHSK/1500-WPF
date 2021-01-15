using Contacts.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Contacts
{
    /// <summary>
    /// ContactDetailsWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact mSelectedContact;
        public ContactDetailsWindow(Contact selectedContact)
        {
            InitializeComponent();
            mSelectedContact = selectedContact;
            nameTextBox.Text = mSelectedContact.Name;
            emailTextBox.Text = mSelectedContact.Email;
            phoneTextBox.Text = mSelectedContact.Phone;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            mSelectedContact.Name = nameTextBox.Text;
            mSelectedContact.Phone = phoneTextBox.Text;
            mSelectedContact.Email = emailTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(mSelectedContact);
            }

            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(mSelectedContact);
            }

            Close();
        }
    }
}
