using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Library.Model
{
    public enum LibraryType
    {
        PublicType,
        SpecialType
    }
    public class Library:INotifyPropertyChanged
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
        private string Address;
        public string address
        {
            get { return Address; }
            set 
            {
                Address = value;
                this.NotifyPropertyChanged();
            }
        }
        private int Tell;
        public int tell
        {
            get { return Tell; }
            set 
            {
                Tell = value;
                this.NotifyPropertyChanged();
            }
        }
        private string WebSite;
        public string webSite
        {
            get { return WebSite; }
            set 
            {
                WebSite = value;
                this.NotifyPropertyChanged();
            }
        }
        private LibraryType Type;
        public LibraryType type
        {
            get { return Type; }
            set 
            {
                Type = value;
                this.NotifyPropertyChanged();
            }
        }
        public List<Shelf> shelves = new List<Shelf>();

        public LibraryType ConvertToLibraryType(string type)
        {
            if (type == "PublicType")
                return LibraryType.PublicType;
            else
                return LibraryType.SpecialType;
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
