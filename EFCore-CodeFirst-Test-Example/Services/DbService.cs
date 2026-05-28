using EFCore_CodeFirst_Test_Example.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst_Test_Example.Services;

public class DbService(DatabaseContext ctx) : IDbService
{
    // [KOLOKWIUM]: Tutaj zaimplementujesz metody z interfejsu używając obiektu ctx
}