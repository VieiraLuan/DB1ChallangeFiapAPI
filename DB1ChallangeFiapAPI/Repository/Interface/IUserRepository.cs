﻿using DB1ChallangeFiapAPI.Model;

namespace DB1ChallangeFiapAPI.Repository.Interface
{
    public interface IUserRepository
    {


        public Task<int> CreateUserAsync(User user);

    }
}
