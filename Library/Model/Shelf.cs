using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Library.Model
{
    public class Shelf:INotifyPropertyChanged
    {
        public int id;
        private string Name;
        public string name
        {
            get { return Name; }
            set
            {
                Name = value;
                this.NotifyPropertyChanged();
            }
        }
        public int idLibrary;
        private int BookCount;
        public int bookCount
        {
            get { return BookCount; }
            set
            {
                BookCount = value;
                this.NotifyPropertyChanged();
            }
        }
        public List<Book> books = new List<Book>();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
