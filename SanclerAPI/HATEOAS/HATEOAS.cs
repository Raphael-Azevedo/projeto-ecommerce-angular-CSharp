using System.Collections.Generic;

namespace SanclerAPI.HATEOAS
{
    public class HATEOAS
    {
        private string url;
        private string protocol = "https://";
        private List<Link> actions = new List<Link>();

        public HATEOAS(string url)
        {
            this.url = url;
        }

        public HATEOAS(string url, string protocol)
        {
            this.url = url;
            this.protocol = protocol;
        }

        public void AddAction (string rel, string method)
        {
            actions.Add(new Link(this.protocol + this.url, rel, method));
        }

        public Link[] GetActions(string sufix)
        {
            Link[] links = new Link[actions.Count];

            for (int i = 0; i < links.Length; i++)
            {
                links[i] = new Link(actions[i].href, actions[i].rel, actions[i].method);
            }

            foreach (var link in links)
            {
                link.href = link.href + "/" + sufix;
            }

            return links;
        }
    }
}