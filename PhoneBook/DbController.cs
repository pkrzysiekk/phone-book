using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class DbController
    {
        private PhoneContext _context;

        public DbController()
        {
            _context = new PhoneContext();
        }
    }
}