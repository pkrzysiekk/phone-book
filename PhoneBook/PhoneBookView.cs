using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PhoneBook.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public static class PhoneBookView
    {
        public static void ShowContacts(ICollection<Contact> contacts)
        {
            var table = new Spectre.Console.Table();
            table.AddColumns("[Teal]Name[/]", "[Teal]Email[/]", "[Teal]Phone Number[/]");
            foreach (Contact contact in contacts)
            {
                table.AddRow(contact.Name, contact.email, contact.PhoneNumber);
            }
            AnsiConsole.Write(table);
        }
    }
}