﻿using System.Security.Claims;

namespace LogiTrack.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUsername(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Name);
        }
        public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Email);
        }
    }
}
