using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Enums;
namespace WebApi.Controllers;


[Controller]
[Route("[controller]")]
public class CustomerController(ICustomerManagmentService customerService) : ControllerBase
{

    [HttpDelete("delete-CustomerManagment")]

    public async Task<string> DeleteCustomerManagment(int id)
    {
       return await customerService.DeleteCustomerManagment(id);
       

    }


    [HttpGet("GEt-CustomerManagment")]


    public async Task<List<CustomerManagment>> GetCustomerManagment()
    {
        return await customerService.GetCustomerManagment();

    }


    [HttpPost("add-CustomerManagment")]

    public async Task<string> AddCustomerManagment(CustomerForAdding customerManagment)
    {

        return await customerService.AddCustomerManagment(customerManagment);


    }

    [HttpPut("Update-CustomerManagment")]

    public async Task<string> UpdateCustomerManagment(CustomerManagment customer)
    {
        return await customerService.UpdateCustomerManagment(customer);

    }

    [HttpGet("Get-CustomerManagment-By-gender")]

    public async Task<List<CustomerManagment>> GetCustomersByGender(Gender gender)
    {
        return await customerService.GetCustomersByGender(gender);
    }
    [HttpGet("Get-CustomerManagment-By-Address")]
    public async Task<List<CustomerManagment>> GetCustomerManagmentsByAddress(string address)
    {
        return await customerService.GetCustomerManagmentsByAddress(address);
    }

    [HttpGet("Get-CustomerManagment-with-Accounts-by-id")]

    public async Task<CustomerAccounts> GetCustomerAccounts(int id)
    {
        return await customerService.GetCustomerAccounts(id);
    }
}

