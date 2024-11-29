﻿using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IHomeService
    {
        Task<IdentityUser?> GetUserByEmailAsync(string email);
    }
}