using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Library
{
    public class ViewModel
    {
        public ObservableCollection<Model.Library> libraries = new ObservableCollection<Model.Library>();
        
        public ViewModel()
        {
            XmlDocument doc = new XmlDocument();
            //doc.Load(@"D:\libraries.xml");
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream s = assembly.GetManifestResourceStream(@"Library.Resources.libraries.xml");
            doc.Load(s);
            XmlNodeList list=doc.GetElementsByTagName("Library");
            
            for (int i = 0; i <list.Count ; i++)
            {
                XmlNode nodeLibrary =list[i];
                Model.Library library = new Model.Library();
                library.id = int.Parse(nodeLibrary["id"].InnerText);
                library.name = nodeLibrary["name"].InnerText;
                library.address = nodeLibrary["address"].InnerText;
                library.tell = int.Parse(nodeLibrary["tell"].InnerText);
                library.webSite = nodeLibrary["webSite"].InnerText;
                string type = nodeLibrary["type"].InnerText;
                library.type = library.ConvertToLibraryType(type);
                XmlNode nodeShelves = nodeLibrary.LastChild;
                List<Model.Shelf> listShelves = new List<Model.Shelf>();
                for (int j = 0; j < nodeShelves.ChildNodes.Count; j++)
                {
                    XmlNode nodeShelf = nodeShelves.ChildNodes[j];
                    Model.Shelf shelf = new Model.Shelf();
                    shelf.id = int.Parse(nodeShelf["id"].InnerText);
                    shelf.name = nodeShelf["name"].InnerText;
                    shelf.bookCount = int.Parse(nodeShelf["bookCount"].InnerText);
                    shelf.idLibrary = int.Parse(nodeShelf["idLibrary"].InnerText);
                    XmlNode nodeBooks=nodeShelf.LastChild;
                    List<Model.Book> listBooks = new List<Model.Book>();
                    for (int k = 0; k < nodeBooks.ChildNodes.Count; k++)
                    {
                        XmlNode nodeBook = nodeBooks.ChildNodes[k];
                        Model.Book book = new Model.Book();
                        book.id = int.Parse(nodeBook["id"].InnerText);
                        book.name = nodeBook["name"].InnerText;
                        book.author = nodeBook["author"].InnerText;
                        book.publisher = nodeBook["publisher"].InnerText;
                        book.idShelf = int.Parse(nodeBook["idShelf"].InnerText);
                        string genre = nodeBook["genre"].InnerText;
                        book.genre = book.ConvertToBookGenre(genre);
                        listBooks.Add(book);
                    }
                    shelf.books = listBooks;
                    listShelves.Add(shelf);
                }
                library.shelves = listShelves;
                this.libraries.Add(library);
                    
            }
               
        }
        


    }
}
