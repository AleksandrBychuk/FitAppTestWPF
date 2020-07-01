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

namespace FitApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public List<Person> Persons { get; set; }
        public List<PersonResult> PersonResults { get; set; }
        //public PersonResult SelectedPerson { get; set; }
        private PersonResult selectedPerson { get; set; }
        public PersonResult SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                foreach (var t in PersonResults)
                    if (t.MaxSteps - (t.MaxSteps / 100 * 20) <= selectedPerson.AvgSteps || t.MinSteps - (t.MinSteps / 100 * 20) <= selectedPerson.AvgSteps)
                        value = null;
            }
        }

        //private bool selectedTwentyPercent { get; set; }
        //public bool SelectedTwentyPercent
        //{
        //    get => selectedTwentyPercent;
        //    set
        //    {
        //        foreach (var t in PersonResults)
        //        {
        //            if (t.MaxSteps - (t.MaxSteps / 100 * 20) <= SelectedPerson.AvgSteps)
        //                value = true;
        //        }
        //        value = false;
        //    }
        //}

        private DelegateCommand exportCommand;
        public DelegateCommand ExportCommand
        {
            get
            {
                return exportCommand ??
                  (exportCommand = new DelegateCommand(obj =>
                  {
                      PersonResult personResult = obj as PersonResult;
                      if (personResult != null)
                      {
                          string json = JsonConvert.SerializeObject(personResult);
                          SaveFileDialog saveFileDialog = new SaveFileDialog();
                          saveFileDialog.Filter = "Text file (*.json)|*.json";
                          if (saveFileDialog.ShowDialog() == true)
                          {
                              File.WriteAllText(saveFileDialog.FileName, json);
                              MessageBox.Show("Данные пользователя успешно экспортированы!");
                          }
                      }
                  },
                 (obj) => SelectedPerson != null));
            }
        }

        public MainViewModel()
        {
            List<Person> list = new List<Person>();
            string[] files = new string[]
            {
               Path.GetDirectoryName("{0}")+"Data/day1.json",
                Path.GetDirectoryName("{0}")+"Data/day2.json",
                Path.GetDirectoryName("{0}")+"Data/day3.json",
                Path.GetDirectoryName("{0}")+"Data/day4.json",
                Path.GetDirectoryName("{0}")+"Data/day5.json",
                Path.GetDirectoryName("{0}")+"Data/day6.json",
                Path.GetDirectoryName("{0}")+"Data/day7.json",
                Path.GetDirectoryName("{0}")+"Data/day8.json",
                Path.GetDirectoryName("{0}")+"Data/day9.json",
                Path.GetDirectoryName("{0}")+"Data/day10.json",
                Path.GetDirectoryName("{0}")+"Data/day11.json",
                Path.GetDirectoryName("{0}")+"Data/day12.json",
                Path.GetDirectoryName("{0}")+"Data/day13.json",
                Path.GetDirectoryName("{0}")+"Data/day14.json",
                Path.GetDirectoryName("{0}")+"Data/day15.json",
                Path.GetDirectoryName("{0}")+"Data/day16.json",
                Path.GetDirectoryName("{0}")+"Data/day17.json",
                Path.GetDirectoryName("{0}")+"Data/day18.json",
                Path.GetDirectoryName("{0}")+"Data/day19.json",
                Path.GetDirectoryName("{0}")+"Data/day20.json",
                Path.GetDirectoryName("{0}")+"Data/day21.json",
                Path.GetDirectoryName("{0}")+"Data/day22.json",
                Path.GetDirectoryName("{0}")+"Data/day23.json",
                Path.GetDirectoryName("{0}")+"Data/day24.json",
                Path.GetDirectoryName("{0}")+"Data/day25.json",
                Path.GetDirectoryName("{0}")+"Data/day26.json",
                Path.GetDirectoryName("{0}")+"Data/day27.json",
                Path.GetDirectoryName("{0}")+"Data/day28.json",
                Path.GetDirectoryName("{0}")+"Data/day29.json",
                Path.GetDirectoryName("{0}") + "Data/day30.json"
            };
            foreach (string file in files)
            {
                list.AddRange(JsonConvert.DeserializeObject<Person[]>(File.ReadAllText(file)));
            }
            var l = list.GroupBy(p => p.User).Select(g => new { Name = g.Key, Persons = g.Select(p => p) });
            List<PersonResult> list2 = new List<PersonResult>();
            foreach (var t in l)
            {
                List<int> list3 = new List<int>();
                List<int> list4 = new List<int>();
                List<string> list5 = new List<string>();
                int sum = 0, count = 0;
                foreach (var g in t.Persons) 
                {
                    sum += g.Steps;
                    count++;
                    list3.Add(g.Steps);
                    list4.Add(g.Rank);
                    list5.Add(g.Status);
                }
                list2.Add(new PersonResult() { Name = t.Name, AvgSteps = sum / count, MaxSteps = list3.Max(), MinSteps = list3.Min(), AllSteps = list3.ToArray(), AllRanks = list4.ToArray(), AllStatus = list5.ToArray() });
            }
            PersonResults = list2;
        }
    }
}