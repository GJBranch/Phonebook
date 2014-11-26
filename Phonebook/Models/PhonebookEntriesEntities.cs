using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Phonebook.Models
{
    public class PhonebookEntriesEntities : DbContext
    {
        public DbSet<PhonebookModel> Phonebook { get; set; }
    }
}