using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Library.Model
{
    public enum BookGenre
    {
        Fiction = 0,
        Boigraphy = 1,
        Poetry = 2,
        Reference = 3,
        Science = 4
    }
    public class Book
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
        private string Author;
        public string author
        {
            get { return Author; }
            set
            {
                Author = value;
                this.NotifyPropertyChanged();
            }
        }
        private string Publisher;
        public string publisher
        {
            get { return Publisher;}
            set 
            {
                Publisher = value;
                this.NotifyPropertyChanged();
            }
        }
        private BookGenre Genre;
        public BookGenre genre
        {
            get { return Genre;}
            set 
            {
                Genre = value;
                this.NotifyPropertyChanged();
            }
        }
        public int idShelf;

        public BookGenre ConvertToBookGenre(string bookGenre)
        {
            if (bookGenre == "Fiction")
                return BookGenre.Fiction;
            else if (bookGenre == "Boigraphy")
                return BookGenre.Boigraphy;
            else if (bookGenre == "Poetry")
                return BookGenre.Poetry;
            else if (bookGenre == "Reference")
                return BookGenre.Reference;
            else
                return BookGenre.Science;

        }
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
