namespace AngleSharp.Demos.DeveloperWeek.Samples
{
    using AngleSharp.Services;
    using System;

    sealed class SharedCookieService : ICookieService
    {
        String _cookie;

        public String this[String origin]
        {
            get { return _cookie; }
            set { _cookie = value; }
        }
    }
}
