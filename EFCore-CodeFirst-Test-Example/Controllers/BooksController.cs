//using EFCore_CodeFirst_Test_Example.DTOs;
using EFCore_CodeFirst_Test_Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_CodeFirst_Test_Example.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IDbService service) : ControllerBase
{

}