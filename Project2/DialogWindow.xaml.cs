using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project2
{
	public partial class DialogWindow : Window
	{

		public Book ObjectBook;

		public DialogWindow()
		{
			InitializeComponent();
		}

		private void Confirm_Click(object sender, RoutedEventArgs e)
		{
			ObjectBook = new Book();

			if (true)
			{
				ObjectBook.Author = AuthorData.Text;
				ObjectBook.Title = TitleData.Text;
				ObjectBook.Year = int.Parse(YearData.Text);

				DialogResult = true;
				this.Close();
			}
		}

        private void Injection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemSemicolon)
            {
                e.Handled = true;
            }
        }

        public static bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i) && i >= -2500 && i <= 2500;
        }

        private void YearData_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			this.Close();
		}
	}
}
