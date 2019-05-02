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
using System.Windows.Shapes;

namespace Project2
{
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public Book ObjectBook;

        public bool Mode;

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            ObjectBook = new Book();
            if(Mode)
            {
                ObjectBook.Author = AuthorData.Text;
                ObjectBook.Title = TitleData.Text;
                ObjectBook.Year = int.Parse(YearData.Text);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
