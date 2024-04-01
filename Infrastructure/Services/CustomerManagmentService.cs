using Dapper;
using Domain.Enums;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CustomerManagmentService(DapperContext context) : ICustomerManagmentService
{
    public async Task<List<CustomerManagment>> GetCustomerManagment()
    {
        var sql = "select * from CustomerManagment";
        var result = await context.Connection().QueryAsync<CustomerManagment>(sql);
        return result.ToList();
    }
    public async Task<string> AddCustomerManagment(CustomerForAdding customerManagment)
    {
        var result = "Customer added successfuly";
        try
        {
            var sql = "insert into CustomerManagment (Name,Email,PhoneNumber,Address,Gender) values(@Name,@Email,@PhoneNumber,@Address,@Gender::Gender)";
            var response = await context.Connection().ExecuteAsync(sql,
              new
              {
                  Name = customerManagment.Name,
                  Email = customerManagment.Email,
                  PhoneNumber = customerManagment.PhoneNumber,
                  Address = customerManagment.Address,
                  Gender = customerManagment.Gender.ToString()
              });


        }
        catch (Exception ex)
        {

            result = ex.Message;
        }
        return result;


    }
    public async Task<string> UpdateCustomerManagment(CustomerManagment customerManagment)
    {
        var result = "Customer updated successfuly";
        try

        {
            var sql = @"update CustomerManagment set Name = @Name,Email = @Email, 
        PhoneNumber = @PhoneNumber,Address = @Address,Gender=@Gender :: Gender
        where CustomerManagmentId = @CustomerManagmentId";
            await context.Connection().ExecuteAsync(sql, new
            {
                Name = customerManagment.Name,
                Email = customerManagment.Email,
                PhoneNumber = customerManagment.PhoneNumber,
                Address = customerManagment.Address,
                Gender = customerManagment.Gender.ToString()
            });

        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        return result;
    }
    public async Task<string> DeleteCustomerManagment(int id)
    {
        var result = "Customer Deleted Successfuly";
        try
        {
            var sql = "delete from CustomerManagment where CustomerManagmentId = @id";
            await context.Connection().ExecuteAsync(sql, new { CustomerManagmentId = id });

        }
        catch (Exception ex)
        {
           result=ex.Message;
        }
        return result;
    }


    public async Task<List<CustomerManagment>> GetCustomersByGender(Gender gender)
    {
        try
        {
            var sql = "select * from CustomerManagment where CustomerManagment.Gender = @Gender:: Gender";
            var result = await context.Connection().QueryAsync<CustomerManagment>(sql, new
            {
                Gender = gender.ToString()
            });
            return result.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }


    public async Task<List<CustomerManagment>> GetCustomerManagmentsByAddress(string address)
    {
        try
        {
            var sql = "select * from CustomerManagment where Address ilike '@address' order by CustomerManagmentId";
            var result = await context.Connection().QueryAsync<CustomerManagment>(sql, new { Address = $"%{address}%" });
            return result.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<CustomerAccounts> GetCustomerAccounts(int customerManagmentId)
    {
        try
        {
            var sql = @"select * from CustomerManagment where CustomerManagmentId=@customerManagmentId;
                  select * from AccountManagment where CustomerManagmentId=@customerManagmentId";

            var customerAccounts = new CustomerAccounts();

            using (var multiple = await context.Connection().QueryMultipleAsync(sql, new { CustomerManagmentId = customerManagmentId }))
            {
                customerAccounts.Customer = await multiple.ReadFirstAsync<CustomerManagment>();
                var list = await multiple.ReadAsync<AccountManagment>();
                customerAccounts.Accounts = list.ToList();
            }
            return customerAccounts;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}

