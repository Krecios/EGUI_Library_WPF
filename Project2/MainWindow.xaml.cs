using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Project2
{

    public partial class Library : Window
    {
        public class Book
        {
            public int ID { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }
            public int Year { get; set; }
        }

        public Library()
        {
            DataContext = this;
        }

        private ObservableCollection<Book> _Lib = new ObservableCollection<Book>();
        public ObservableCollection<Book> Lib
        {
            get
            {
                return _Lib;
            }

            /*set
            {
                _Lib = value;
                OnPropertyChanged("Lib");
            }*/
        }
        
        public void AddABook(string A, string B, int C)
        {
            Lib.Add(new Book { ID = 0, Author = A, Title = B, Year = C });
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Library test = new Library();
            test.AddABook("A","B",10);
        }
    }
}
