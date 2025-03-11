using PhoneBook.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook.Helpers
{
    public class UserChoice
    {
        public Contact GetUser()
        {
            string name;
            string email;
            string phoneNumber;
            string phonePatternRegex = @"^(\+?\d{1,3})?\s?\d{3}(\s?\d{3}){2}$";

            name = AnsiConsole.Prompt(new TextPrompt<string>("Enter Name: "));
            email = AnsiConsole.Prompt(new TextPrompt<string>("Enter Email: ")
            .Validate(email => email.Contains("@") && email.Contains("."))
                );
            phoneNumber = AnsiConsole.Prompt(new TextPrompt<string>("Enter Phone Number (eg. +48 333 333 333)")
                .Validate(number => Regex.IsMatch(number, phonePatternRegex))
                );
            Contact newContact = new() { Name = name, email = email, PhoneNumber = phoneNumber };
            return newContact;
        }

        public Contact GetUserSelection(ICollection<Contact> contacts)
        {
            var choice = AnsiConsole.Prompt(new SelectionPrompt<Contact>()
                .Title("[Blue]Select a contact to update[/]")
                .PageSize(10)
                .AddChoices(contacts)
                .UseConverter(x => $"{x.Name}| {x.email}| {x.PhoneNumber}")
                );
            return choice;
        }
    }
}