using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    internal class Book
    {
        public int numerical { get; set; }
        public string code { get; set; }
        public string nameBook { get; set; }
        public string category { get; set; }
        public string author { get; set; }

        public string specCode;

        public Book()
        {
            code = "";
            nameBook = "";
            category = "";
            author = "";
            specCode = "";
        }

        public Book(Book book)
        {
            code = book.code;
            nameBook = book.nameBook;
            category = book.category;
            author = book.author;
            specCode = book.specCode;
        }

        public Book(int num, string code, string name, string catagory, string author, string specCode)
        {
            this.numerical = num;
            this.code = code;
            this.nameBook = name;
            this.category = catagory;
            this.author = author;
            this.specCode = specCode;
        }
    }
}
