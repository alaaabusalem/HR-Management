﻿using Domain.Models.Auth;

namespace Api._Helpers
{
    public interface IJwt
    {

      string  GenerateJwtToken(User user, TimeSpan expiresIn);
    }
}
