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

            while (true)
            {
                var choice = AnsiConsole.Prompt(new SelectionPrompt<MenuChoices>()
                    .Title("[Blue]Main menup[/]")
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
                        break;

                    case MenuChoices.UpdateContact:
                        break;

                    case MenuChoices.DeleteContact:
                        break;

                    case MenuChoices.Exit:
                        AnsiConsole.MarkupLine("[red]Goodbye![/]");
                        return;
                }
            }
        }
    }
}