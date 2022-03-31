using ReactiveUI;
using System.Reactive;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7.Models;
using System.IO;

namespace Lab7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        Middle middle = new Middle();

        public ObservableCollection<Student> Items { get; set; }
        public List<Student> I { get; set; }
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Student>(BuildAllStudents());
            BuildActualMarks();
        }

        public void BuildActualMarks()
        {
            MiddleMath = 0;
            MiddleVisualPrograming = 0;
            MiddleOOP = 0;
            MiddlePhysicalCulture = 0;
            MiddleMiddleMark = 0;
            for (int i=0;i<Items.Count;i++)
            {
                MiddleMath += Items[i].visualMath;
                MiddleVisualPrograming += Items[i].visualPrograming;
                MiddleOOP += Items[i].visualOOP;
                MiddlePhysicalCulture += Items[i].visualPhysicalCulture;
                Items[i].visualMiddleMark = 0;
                Items[i].visualMiddleMark += Items[i].visualMath;
                Items[i].visualMiddleMark += Items[i].visualPrograming;
                Items[i].visualMiddleMark += Items[i].visualOOP;
                Items[i].visualMiddleMark += Items[i].visualPhysicalCulture;
                Items[i].visualMiddleMark /= 4;
                MiddleMiddleMark += Items[i].visualMiddleMark;
            }
            MiddleMath /= Items.Count;
            MiddleVisualPrograming /= Items.Count;
            MiddleOOP /= Items.Count;
            MiddlePhysicalCulture /= Items.Count;
            MiddleMiddleMark /= Items.Count;
        }

        public double MiddleMath
        {
            get => middle.math; 
            set
            {
                this.RaiseAndSetIfChanged(ref middle.math, value);
            }
        }
        public double MiddleVisualPrograming
        {
            get => middle.visualPrograming;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.visualPrograming, value);
            }
        }
        public double MiddleOOP
        {
            get => middle.oop;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.oop, value);
            }
        }
        public double MiddlePhysicalCulture
        {
            get => middle.physicalCulture;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.physicalCulture, value);
            }
        }
        public double MiddleMiddleMark
        {
            get => middle.middleMark;
            set
            {
                this.RaiseAndSetIfChanged(ref middle.middleMark, value);
            }
        }

        public void SaveFile(string path)
        {
            ProcessingFile.WriteFile(path, Items);
        }

        public void OpenFile(string path)
        {
            I = ProcessingFile.ReadFile(path);
            for(int i = 0; i < Items.Count; i++)
                Items[i] = I[i];

            BuildActualMarks();
        }
        private Student[] BuildAllStudents()
        {
            return new Student[]
            {
                new Student("Андреев", 1, 1,1,2,2),
                new Student("Алексеев", 1, 1,2,2,2),
                new Student("Михайлов", 1, 1,0,2,2),
                new Student("Степанов", 1, 1,0,2,2),
                new Student("Яковлев", 1, 1,0,2,2),
                new Student("Петров", 1, 1,0,2,2),
                new Student("Александров", 1, 1,1,2,2),
                new Student("Григорьев", 1, 1,0,2,2),
                new Student("Лебедев", 1, 1,0,2,2),
                new Student("Воробьев", 1, 1,0,2,2),
                new Student("Киселев", 1, 1,0,2,2),
                new Student("Гусев", 1, 1,0,2,2),
                new Student("Поялков", 1, 1,1,2,2),
            };
        }
    }
}
