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
using System.ComponentModel;

namespace Project2
{
    public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private ObservableCollection<Book> _Lib = new ObservableCollection<Book>();
		public ObservableCollection<Book> Lib
		{
			get
			{
				Notify(nameof(_Lib));
				return _Lib;
			}
            private set { }
        }

        private ObservableCollection<int> _YearCombo = new ObservableCollection<int>();
        public ObservableCollection<int> YearCombo
        {
            get
            {
                Notify(nameof(_YearCombo));
                return _YearCombo;
            }
            private set { _YearCombo = value; }
        }
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            CSVLoad(@"C:\Users\Filip Kwiatkowski\Desktop\EGUI\EGUI_Library_WPF-master\BooksDatabase.csv");
        }

		public void AddABook(string A, string B, int C)
		{
			Lib.Add(new Book { ID = 0, Author = A, Title = B, Year = C });
		}

		public event PropertyChangedEventHandler PropertyChanged;

		void Notify(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private void AddBook_Click(object sender, RoutedEventArgs e)
		{
            DialogWindow AddWindow = new DialogWindow();
            AddWindow.Mode = true;
            AddWindow.Confirm.Content = "Add";
            AddWindow.Title = "Add a new book";
            AddWindow.Show();
            
		}

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (TableLib.SelectedItem != null)
            {
                DialogWindow EditWindow = new DialogWindow();
                Book ToBeEdited = (Book)TableLib.SelectedItem;
                EditWindow.Mode = false;
                EditWindow.Confirm.Content = "Save";
                EditWindow.Title = "Edit selected book";
                EditWindow.AuthorData.Text = ToBeEdited.Author;
                EditWindow.TitleData.Text = ToBeEdited.Title;
                EditWindow.YearData.Text =  ToBeEdited.Year.ToString();
                EditWindow.Show();
            }
        }

        private void DelteBook_Click(object sender, RoutedEventArgs e)
        {
            var SelectedBook = TableLib.SelectedItem;
            if (SelectedBook != null)
            {
                Lib.Remove((Book)SelectedBook);
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            author.Text = String.Empty;
            title.Text = String.Empty;
            year.SelectedIndex = -1;
            TableLib.ItemsSource = Lib;
        }      

        private void CSVLoad(string path)
        {
            using (var ReadStream = new StreamReader(path))
            {
                while(!ReadStream.EndOfStream)
                {
                    var Split = ReadStream.ReadLine().Split(';');
                    var NewBook = new Book()
                    {
                        ID = 0,
                        Author = Split[0],
                        Title = Split[1],
                        Year = int.Parse(Split[2])
                    };
                    Lib.Add(NewBook);
                    YearCombo.Add(int.Parse(Split[2]));
                }
                ReadStream.Close();
            }
            YearComboHandle();
        }

        private void YearComboHandle()
        {
            YearCombo = new ObservableCollection<int>(YearCombo.Distinct());
            YearCombo = new ObservableCollection<int>(YearCombo.OrderBy(i => -i));
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Book> FilteredLib = new ObservableCollection<Book>();
            FilteredLib.Clear();
            foreach (Book ObjectBook in Lib)
            {
                Book CurrBook = ObjectBook;
                if (year.SelectedIndex == -1)
                {
                    if (CurrBook.Author.Contains(author.Text) && CurrBook.Title.Contains(title.Text))
                    {
                        FilteredLib.Add(ObjectBook);
                    }
                }
                else
                {
                    if (CurrBook.Author.Contains(author.Text) && CurrBook.Title.Contains(title.Text) && CurrBook.Year.Equals(year.SelectedValue))
                    {
                        FilteredLib.Add(ObjectBook);
                    }
                }
            }
            TableLib.ItemsSource = FilteredLib;
        }
	}
	public struct Book
	{
		public int ID { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
	}
}
