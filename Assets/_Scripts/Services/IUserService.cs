﻿using _Scripts.Core;

namespace _Scripts.Services
{
    public interface IUserService
    {
        public void SetUserData(Result user, string key);
        public Result AccessUserData(string key);
    }
}