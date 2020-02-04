﻿using System.Threading.Tasks;

namespace PeTelecome.Modules.UserAccess.Application.Contracts
{
    public interface IUserAccessModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
        Task ExecuteCommandAsync(ICommand command);
        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}