﻿namespace WebApp.Common.Application
{
    public class ApplicationSettings
    {
        public ApplicationSettings() => Secret = default!;

        public string Secret { get; private set; }
    }
}
