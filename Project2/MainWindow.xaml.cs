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
		}
		public MainWindow()
        {
            InitializeComponent();
			DataContext = this;
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
			AddABook("marcin", "jest mistrzem WPFa", 2019);
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
