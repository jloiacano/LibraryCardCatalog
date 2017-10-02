using System;
using System.Runtime.Serialization;

namespace LibraryCardCatalog
{
    [Serializable()]
    public class Book : ISerializable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }

        public Book() { }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public Book(string title, string author, string isbn, string publisher)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Publisher = publisher;
        }

        public override string ToString()
        {
            // could use some tab formatting maybe or something to line up columns better?
            if (this.ISBN == "" && this.Publisher == "")
            {
                return string.Format("{0} by {1}", Title, Author);
            }
            else if (this.ISBN == "")
            {
                return string.Format("{0} by {1}; Copywrite: {2}", Title, Author, Publisher);
            }
            else if (this.Publisher == "")
            {
                return string.Format("{0} by {1}; ISBN: {2}", Title, Author, ISBN);
            }
            else
            {
            return string.Format("{0} by {1}; Copywrite: {2}; ISBN: {3}", Title, Author, Publisher, ISBN);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Author", Author);
            info.AddValue("ISBN", ISBN);
            info.AddValue("Publisher", Publisher);
        }

        public Book(SerializationInfo info, StreamingContext context)
        {
            Title = (string)info.GetValue("Title", typeof(string));
            Author = (string)info.GetValue("Author", typeof(string));
            ISBN = (string)info.GetValue("ISBN", typeof(string));
            Publisher = (string)info.GetValue("Publisher", typeof(string));
        }
    }
}

