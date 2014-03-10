using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.WootzJs;
using System.Web;
using WootzJs.Models;
using WootzJs.Mvc.Routes;
using WootzJs.Mvc.Views;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc
{
    public class MvcApplication
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Scheme { get; set; }
        public GlobalStyle GlobalStyle { get; private set; }

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

            OnStarting(() =>
            {
                Open(path + (!string.IsNullOrEmpty(Browser.Window.Location.Search) ? "?" + Browser.Window.Location.Search : ""), false);
                OnStarted();
            });
        }

        /// <summary>
        /// This occurs immediately before opening the initial page.
        /// </summary>
        protected virtual void OnStarting(Action continuation)
        {
            continuation();
        }

        protected virtual void OnStarted()
        {
            InitializeGlobalStyle();
        }

        protected virtual void InitializeGlobalStyle()
        {
            var style = Browser.Document.CreateElement("style");
            style.AppendChild(Browser.Document.CreateTextNode(""));  // Webkit hack
            Browser.Document.Head.AppendChild(style);
            var styleSheet = style.As<JsObject>()["sheet"].As<StyleSheet>();
            
            // Reset the styles to a clean base
/*
            styleSheet.InsertRule("html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, b, u, i, center, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td, article, aside, canvas, details, embed, figure, figcaption, footer, header, hgroup, menu, nav, output, ruby, section, summary, time, mark, audio, video { margin: 0; padding: 0; border: 0; font-size: 100%; font: inherit; }", 0);
            styleSheet.InsertRule("strong, b { font-weight: bold; }", 0);
            styleSheet.InsertRule("* { box-sizing: border-box; -moz-box-sizing: border-box; -webkit-box-sizing: border-box; }", 0);
            styleSheet.InsertRule("article, aside, details, figcaption, figure, footer, header, hgroup, menu, nav, section { display: block; }", 0);
            styleSheet.InsertRule("html, body { height: 100%; }", 0);
            styleSheet.InsertRule("ol, ul { list-style: none; }", 0);
            styleSheet.InsertRule("blockquote, q { quotes: none; }", 0);
            styleSheet.InsertRule("blockquote:before, blockquote:after, q:before, q:after { content: ''; content: none; }", 0);
            styleSheet.InsertRule("table { border-collapse: separate; border-spacing: 0; }", 0);
*/

            GlobalStyle = new GlobalStyle(styleSheet);
        }

        private void OnPopState(PopStateEvent evt)
        {
            // If state is null then it means it's firing on first load, which we never care about
            var path = (string)evt.State;
            if (path != null && path != currentPath)
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
                var sections = view.Sections;
                layout.LoadSections(sections);
            }

            OnOpen(url);
        }

        protected virtual void OnOpen(string url)
        {
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

        public virtual ViewContext CreateViewContext(Controller controller)
        {
            return new ViewContext { ControllerContext = controller.ControllerContext };
        }

        internal void NotifyOnValidatedControl(Control control, Validation[] validations)
        {
            OnValidatedControl(control, validations);
        }

        protected virtual void OnValidatedControl(Control control, Validation[] validations)
        {
        }

        internal void NotifyBindModel(Controller controller, Model model)
        {
            OnBindModel(controller, model);
        }

        protected virtual void OnBindModel(Controller controller, Model model)
        {
//            model.ControllerContext = controller.ControllerContext;
        }
    }
}