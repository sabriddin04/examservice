using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class AccountManagmentService : IAccountManagmentService
{
    private readonly DapperContext context;
    public AccountManagmentService(DapperContext context)
    {
        this.context = context;
    }


    public async Task<List<AccountManagment>> GetAccountManagments()
    {
        try
        {
            var sql = "select * from AccountManagment";
            var result = await context.Connection().QueryAsync<AccountManagment>(sql);
            return result.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<string> AddAccountManagment(AccountManagment accountManagment)
    {
        var result = "Account Added successfuly";
        try
        {
            var sql = "insert into AccountManagment (AccountNumber,Balance,CustomerManagmentId,AccountType) values (@AccountNumber,@Balance,@CustomerManagmentId,@AccountType::AccountTypes)";
            await context.Connection().ExecuteAsync(sql, new
            {
                AccountNumber = accountManagment.AccountNumber,

                AccountType = accountManagment.AccountType.ToString(),

                Balance = accountManagment.Balance,

                CustomerManagmentId = accountManagment.CustomerManagmentId

            });

        }
        catch (Exception ex)
        {
            result = (ex.Message);

        }
        return result;
    }
    public async Task<string> UpdateAccountManagments(AccountManagment accountManagment)
    {
        try
        {
            var sql = @"update AccountManagment set AccountNumber = @AccountNumber,
                    Balance = @Balance,CustomerManagmentId = @CustomerManagmentId,AccountType = @AccountType::AccountTypes
                    where AccountManagmentId = @AccountManagmentId";
            await context.Connection().ExecuteAsync(sql, new
            {
                AccountNumber = accountManagment.AccountNumber,

                AccountType = accountManagment.AccountType.ToString(),

                Balance = accountManagment.Balance,

                CustomerManagmentId = accountManagment.CustomerManagmentId

            });

            return "AccountManagment Updated Successfuly";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    public async Task<string> DeleteAccountManagments(int id)
    {
        var a = "AccountManagment deleted successfuly";
        try
        {
            var sql = "delete from AccountManagment where AccountManagmentId = @AccountManagmentId";
            await context.Connection().ExecuteAsync(sql, new { Id = id });
            return "AccountManagment deleted successfuly";
        }
        catch (Exception ex)
        {
            a = ex.Message;
        }
        return a;
    }


}

