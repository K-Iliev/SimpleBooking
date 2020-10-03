﻿using System;
using System.Security.Claims;
using Application.Common;
using Microsoft.AspNetCore.Http;

namespace Web.Services
{
    public class AspNetUserContextAdapter : IUserContext
    {
        public AspNetUserContextAdapter(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
