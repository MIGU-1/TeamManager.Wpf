using CdManager.Model;
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
using TeamManager.Core;

namespace TeamManager.Wpf
{
    /// <summary>
    /// Interaction logic for AddAndEditWindow.xaml
    /// </summary>
    public partial class AddAndEditWindow : Window
    {
        private Member _member;

        public AddAndEditWindow(Member selectedMember)
        {
            InitializeComponent();
            Loaded += AddAndEditWindow_Loaded;
            _member = selectedMember;
        }

        private void AddAndEditWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnCancel.Click += BtnCancel_Click;
            btnSave.Click += BtnSave_Click;

            if(_member == null)
            {
                DataContext = new Member();
            }
            else
            {
                DataContext = _member;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(_member == null)
            {
                Repository.GetInstance().AddMember(DataContext as Member);
            }

            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
