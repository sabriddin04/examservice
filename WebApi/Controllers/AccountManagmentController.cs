namespace WebApi.Controllers;
using System.Net;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructure.Interfaces;
using Domain.Enums;

[Controller]
[Route("[controller]")]
public class AccountManagmentController
{
 private readonly IAccountManagmentService accountManagmentService;


    public AccountManagmentController(IAccountManagmentService service)
    {
        accountManagmentService = service;
    }

    [HttpDelete("delete-accountManagmentService")]

    public async Task<string> DeleteAccountManagment(int accountManagmentId)
    {
       return await accountManagmentService.DeleteAccountManagments(accountManagmentId);
      
    }
    [HttpGet("Get-accountManagmentServices")]
    public async Task<List<AccountManagment>> GetAccountManagment()
    {
        return await accountManagmentService.GetAccountManagments();
    }
    [HttpPost("add-accountManagmentService")]
    public async Task AddAccountManagment(AccountManagment accountManagment)
    {
        await accountManagmentService.AddAccountManagment(accountManagment);
    }

    [HttpPut("Update-Customer")]

    public async Task<string> UpdateAccountManagment(AccountManagment accountManagment)
    {
       return await accountManagmentService.UpdateAccountManagments(accountManagment);
        
    }
}



