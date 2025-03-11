﻿using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Models;

public class PhoneContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public string DbPath { get; private set; }

    public PhoneContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}phonebook.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}