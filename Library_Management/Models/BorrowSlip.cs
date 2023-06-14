﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.Models
{
    internal class BorrowSlip
    {
        public int stt { get; set; }
        public string slipCode { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string email;
        public string borrowDate { get; set; }
        public string returnDate { get; set; }
        public string amount;
        public List<Book> chosenBooks;

        public BorrowSlip()
        {
            slipCode = "";
            code = "";
            name = "";
            email = "";
            borrowDate = "";
            returnDate = "";
            amount = "";
            chosenBooks = new List<Book>();
        }
        public BorrowSlip(string slipCode, string code, string name, string borrowDate, string returnDate, string amount, List<Book> selectedBooks)
        {
            this.slipCode = slipCode;
            this.code = code;
            this.name = name;
            this.borrowDate = borrowDate;
            this.returnDate = returnDate;
            this.amount = amount;
            chosenBooks = new List<Book>();

            foreach (Book book in selectedBooks)
            {
                Book copy = new Book(book);
                chosenBooks.Add(copy);
            }
        }
    }
}
