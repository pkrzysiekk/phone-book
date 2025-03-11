using Spectre.Console;

namespace PhoneBook.Models;

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