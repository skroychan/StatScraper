﻿using skroy.Scraper.Configurations;

namespace skroy.Scraper.Services.Base;

public abstract class Service<T> where T : Configuration, new()
{
    protected readonly T Configuration;


    public Service()
    {
        Configuration = new T();
    }
}
