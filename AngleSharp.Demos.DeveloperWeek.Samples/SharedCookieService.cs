namespace AngleSharp.Demos.DeveloperWeek.Samples
{
    using AngleSharp.Services;
    using System;

    sealed class SharedCookieService : ICookieProvider
    {
        private String _cookie;

        public String GetCookie(String origin)
        {
            return _cookie;
        }

        public void SetCookie(String origin, String value)
        {
            _cookie = value;
        }
    }
}
