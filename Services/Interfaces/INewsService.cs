﻿namespace FreeTimeSpenderWeb.Services.Interfaces
{
    public interface INewsService
    {
        Task<string> GetNewsAsync(string apiKey);
    }
}