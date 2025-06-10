using System.Data;
using ExampleTest2.Data;
using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
}