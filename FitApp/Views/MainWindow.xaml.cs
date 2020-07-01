using DevExpress.Mvvm;
using FitApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using LiveCharts;
using LiveCharts.Wpf;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm.Native;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Microsoft.Win32;
using DevExpress.Mvvm.POCO;

namespace FitApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
