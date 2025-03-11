using PhoneBook.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public static class Menu
    {
        public static void Show()
        {
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
            }
        }
    }
}