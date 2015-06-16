namespace AngleSharp.Demos.DeveloperWeek.Samples
{
    using AngleSharp.Dom.Html;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class WebsiteAccessor
    {
        readonly IBrowsingContext _context;

        WebsiteAccessor(IBrowsingContext context)
        {
            _context = context;
        }

        public static async Task<WebsiteAccessor> CreateAsync(string baseUrl)
        {
            var url = Url.Create(baseUrl);

            if (url.IsInvalid)
                throw new ArgumentException("The provided parameter does not form a valid URL.", nameof(baseUrl));

            var config = Configuration.Default
                .WithDefaultLoader()
                .With(new SharedCookieService());
            var context = BrowsingContext.New(config);
            await context.OpenAsync(url);
            return new WebsiteAccessor(context);
        }

        public string CurrentSource
        {
            get { return _context.Active.ToHtml(); }
        }

        public string CurrentUrl
        {
            get { return _context.Active.Url; }
        }

        public async Task NavigateToLink(string selector)
        {
            var document = _context.Active;
            var link = document.QuerySelector<IHtmlAnchorElement>(selector);
            await (link?.Navigate() ?? (Task)Task.FromResult(false));
        }

        public async Task SubmitForm(IDictionary<String, String> fields)
        {
            var document = _context.Active;
            var form = document.Forms.FirstOrDefault();
            var elements = form?.Elements ?? Enumerable.Empty<IHtmlElement>();

            foreach (var element in elements.OfType<IHtmlInputElement>())
            {
                var value = default(String);

                if (fields.TryGetValue(element.Name ?? String.Empty, out value))
                    element.Value = value;
            }

            await form.Submit();
        }
    }
}
