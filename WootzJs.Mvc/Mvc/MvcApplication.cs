using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.WootzJs;
using System.Web;
using WootzJs.Mvc.Mvc.Routes;
using WootzJs.Mvc.Mvc.Views;
using WootzJs.Web;

namespace WootzJs.Mvc.Mvc
{
    public class MvcApplication
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Scheme { get; set; }

        public IControllerFactory ControllerFactory { get; protected set; }
        public IDependencyResolver DependencyResolver { get; protected set; }

        private RouteTree routeTree;
        private View view;
        private HtmlControl html = new HtmlControl(Browser.Document.GetElementByTagName("html"));
        private HtmlControl body = new HtmlControl(Browser.Document.GetElementByTagName("body"));
        private string initialPath = Browser.Window.Location.PathName;
        private string currentPath;

        public MvcApplication()
        {
            DependencyResolver = new ReflectionDependencyResolver();
        }

        public HtmlControl Html
        {
            get { return html; }
        }

        public HtmlControl Body
        {
            get { return body; }
        }

        public void Start(Assembly assembly)
        {
            Host = Browser.Window.Location.Host;
            Port = Browser.Window.Location.Port;
            Scheme = Browser.Window.Location.Protocol;

            Browser.Window.AddEventListener("popstate", evt => OnPopState(evt.As<PopStateEvent>()));

            var path = Browser.Window.Location.PathName;
            Console.WriteLine(path);

            ControllerFactory = new DefaultControllerFactory(DependencyResolver);

            var routeGenerator = new RouteGenerator();
            routeTree = routeGenerator.GenerateRoutes(assembly);

            Open(path + (!string.IsNullOrEmpty(Browser.Window.Location.Search) ? "?" + Browser.Window.Location.Search : ""), false);

            OnStarted();
        }

        protected virtual void OnStarted()
        {
        }

        private void OnPopState(PopStateEvent evt)
        {
            // If state is null then it means it's firing on first load, which we never care about
            var path = (string)evt.State ?? initialPath;
            if (path != currentPath)
                Open(path, false);
        }

        public void Open(string url)
        {
            Open(url, true);
        }

        public void Open(string url, bool pushState)
        {
            var parts = url.Split('?');
            var path = parts[0];
            var queryString = url.Length > 1 ? parts[1] : null;
            currentPath = path;
            var view = Execute(path, queryString);

            if (pushState)
                Browser.Window.History.PushState(url, view.Title, url);
            Browser.Document.Title = view.Title;

            if (this.view is Layout && view.LayoutType != null)
            {
                var layout = (Layout)this.view;
                var container = layout.FindLayout(view.LayoutType);
                container.AddView(view);
            }
            else
            {
                if (this.view != null)
                    body.Remove(this.view.Content);

                var rootView = view.GetRootView();
                body.Add(rootView.Content);
                this.view = rootView;
            }

            if (this.view is Layout)
            {
                var layout = (Layout)this.view;
                foreach (var section in view.Sections)
                {
                    layout.LoadSection(section.Key, section.Value);
                }
            }
        }

        private NavigationContext CreateNavigationContext(string path, string queryString)
        {
            // Create http context
            var queryStringDictionary = new Dictionary<string, string>();
            if (queryString != null)
            {
                var parts = queryString.Split(new[] { '&' });
                foreach (var part in parts)
                {
                    var pair = part.Split(new[] { '=' });
                    var key = HttpUtility.UrlDecode(pair[0]);
                    var value = HttpUtility.UrlDecode(pair[1]);
                    queryStringDictionary[key] = value;
                }
            }
            var routeData = routeTree.Apply(path, "GET");
            var request = new NavigationRequest
            {
                Path = path,
                QueryString = queryStringDictionary,
                RouteData = routeData
            };
            var response = new NavigationResponse();

            var navigationContext = new NavigationContext
            {
                Request = request,
                Response = response
            };

            return navigationContext;
        }

        protected View Execute(string path, string queryString)
        {
            var context = CreateNavigationContext(path, queryString);
            var controller = ControllerFactory.CreateController(context);
            controller.Execute(this, context);
            return context.Response.View;
        }
    }
}