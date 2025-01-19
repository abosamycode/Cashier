using CashierDataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(AuthDto authDto);
        Task<string> LoginAsync(AuthDto authDto);
    }
}
