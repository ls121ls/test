using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class entry
    {
        public int EntryId { get; set; }
        public string id;
        public string title;
        public string summary;
        public string published;
        public string updated;

        public Author author;

        public link link;
        public string diggs;
        public string views;

        public string comments;


        public string blogapp;
        public string avatar;
        public string postcount;
    }
}
