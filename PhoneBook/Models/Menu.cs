using PhoneBook.Helpers;
using Spectre.Console;

namespace PhoneBook.Models
{
    public class Menu
    {
        private PhoneController _dbController;
        private UserChoice _userChoice;

        public Menu()
        {
            _dbController = new PhoneController();
            _userChoice = new UserChoice();
        }

        public void Show()
        {
            Contact contact = new Contact();
            ICollection<Contact> contacts = new List<Contact>();

            while (true)
            {
                var choice = AnsiConsole.Prompt(new SelectionPrompt<MenuChoices>()
                    .Title("[Blue]Main menu[/]")
                    .AddChoices(Enum.GetValues<MenuChoices>())
                    .UseConverter(x => x switch
                    {
                        MenuChoices.AddContact => "[green]Add Contact[/]",
                        MenuChoices.ViewContacts => "[green]View Contacts[/]",
                        MenuChoices.UpdateContact => "[green]Update Contact[/]",
                        MenuChoices.DeleteContact => "[green]Delete Contact[/]",
                        MenuChoices.Exit => "[red]Exit[/]",
                        _ => throw new NotImplementedException()
                    }
                    )

                    );

                switch (choice)
                {
                    case MenuChoices.AddContact:
                        contact = _userChoice.GetUser();
                        _dbController.Add(contact);
                        AnsiConsole.MarkupLine("[green]Contact added successfully![/]");
                        break;

                    case MenuChoices.ViewContacts:
                        contacts = _dbController.GetAll();
                        if (contacts.Count == 0)
                        {
                            AnsiConsole.MarkupLine("[red]No contacts found![/]");
                            break;
                        }
                        PhoneBookView.ShowContacts(contacts);
                        break;

                    case MenuChoices.UpdateContact:
                        contacts = _dbController.GetAll();
                        if (contacts.Count == 0)
                        {
                            AnsiConsole.MarkupLine("[red]No contacts found![/]");
                            break;
                        }
                        contact = _userChoice.GetUserSelection(contacts);
                        var contactToUpdate = _userChoice.GetUser();
                        _dbController.Update(contact.Id, contactToUpdate);
                        AnsiConsole.MarkupLine("[green]Contact updated successfully![/]");
                        break;

                    case MenuChoices.DeleteContact:
                        contacts = _dbController.GetAll();
                        if (contacts.Count == 0)
                        {
                            AnsiConsole.MarkupLine("[red]No contacts found![/]");
                            break;
                        }
                        contact = _userChoice.GetUserSelection(contacts);
                        _dbController.Remove(contact.Id);
                        AnsiConsole.MarkupLine("[green]Contact deleted successfully![/]");

                        break;

                    case MenuChoices.Exit:
                        AnsiConsole.MarkupLine("[red]Goodbye![/]");
                        return;
                }
            }
        }
    }
}