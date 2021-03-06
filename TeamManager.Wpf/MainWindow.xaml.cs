﻿using CdManager.Model;
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
using TeamManager.Core;

namespace TeamManager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Member> _members;
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repository = Repository.GetInstance();
            _members = repository.GetAllMembers();
            listBoxMembers.ItemsSource = _members;

            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Member member = listBoxMembers.SelectedItem as Member;

            if (member == null)
            {
                MessageBox.Show("Member auswählen");
                return;
            }

            Repository.GetInstance().DeleteMember(member);
            RefreshList();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Member member = listBoxMembers.SelectedItem as Member;

            if(member == null)
            {
                MessageBox.Show("Member auswählen");
                return;
            }

            AddAndEditWindow addAndEditWindow = new AddAndEditWindow(member);
            addAndEditWindow.ShowDialog();
            RefreshList();
        }
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            AddAndEditWindow addAndEditWindow = new AddAndEditWindow(null);
            addAndEditWindow.ShowDialog();
            RefreshList();
        }
        private void RefreshList()
        {
            Repository repository = Repository.GetInstance();
            _members = repository.GetAllMembers();
            listBoxMembers.ItemsSource = _members;
        }
    }
}
