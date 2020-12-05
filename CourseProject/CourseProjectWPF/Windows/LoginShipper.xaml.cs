﻿using System;
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
using System.Windows.Shapes;
using CourseProjectWPF.ViewModels;

namespace CourseProjectWPF.Windows
{
    /// <summary>
    /// Interaction logic for LoginShipper.xaml
    /// </summary>
    public partial class LoginShipper : Window
    {
        private readonly LoginShipperModel _loginViewModel;
        public LoginShipper(LoginShipperModel vm)
        {
            _loginViewModel = vm;
            DataContext = _loginViewModel;

            InitializeComponent();
        }

        //public LoginShipper()
        //{
            
        //}

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = false;
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (_loginViewModel.Login())
            {
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Error");
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
