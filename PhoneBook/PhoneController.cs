using PhoneBook.Models;
using Spectre.Console;

namespace PhoneBook
{
    public class PhoneController
    {
        private PhoneContext _context;

        public PhoneController()
        {
            _context = new PhoneContext();
        }

        public ICollection<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var contact = _context.Contacts.Find(id);
            try
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine(ex.Message);
            }
        }

        public void Update(int id, Contact updatedContact)
        {
            var contact = _context.Contacts.Find(id);
            try
            {
                contact.Name = updatedContact.Name;
                contact.email = updatedContact.email;
                contact.PhoneNumber = updatedContact.PhoneNumber;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine(ex.Message);
            }
        }
    }
}