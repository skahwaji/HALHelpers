using System.Collections.Generic;


namespace HALHelpers.ResourceLinks
{
    public record ResourceHref(string Href);
    public record ResourceTemplated(string Href, bool Templated);
    public record ResourceCuries(string Name, string Href, bool Templated);

    public interface IResourceLinksExtension 
    {
        IDictionary<string, object> _links { get; set; }
    }

    public interface IResourceEembeddedExtension 
    {
        List<object> _embedded { get; set; }
    }

    public interface IResourceCuriesExtension
    {
        List<object> curies { get; set; }
    }

    public static class ResourceLinks
    {
        public static void AddLink(this IResourceLinksExtension record, string type, string routeUrl, bool templated = false)
        {
            record._links ??= new Dictionary<string, object>();
            if(!templated)
                record._links[type] = new ResourceHref(routeUrl);
            else
                record._links[type] = new ResourceTemplated(routeUrl, templated);
        }

        public static void AddObjectLink(this IResourceLinksExtension record, string type, object obj)
        {
            record._links ??= new Dictionary<string, object>();
            record._links[type] = obj;
        }

        public static void AddEmbedded(this IResourceEembeddedExtension record, object obj)
        {
            record._embedded ??= new List<object>();
            record._embedded.Add(obj);
        }
    }
}
