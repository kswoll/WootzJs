using System;

namespace WootzJs.Mvc.Mvc.Views.Css
{
    public enum CssCursor
    {
        Alias,
        AllScroll,
        Auto,
        Cell,
        ContextMenu,
        ColResize,
        Copy,
        Crosshair,
        Default,
        EResize,
        EWResize,
        Help,
        Move,
        NResize,
        NeResize,
        NeswResize,
        NsResize,
        NwResize,
        NwseResize,
        NoDrop,
        None,
        NotAllowed,
        Pointer,
        Progress,
        RowResize,
        SResize,
        SeResize,
        SwResize,
        Text,
        Url,
        VerticalText,
        WResize,
        Wait,
        ZoomIn,
        ZoomOut,
        Inherit
    }

    public static class CssCursors
    {
        public static string GetName(this CssCursor cursor)
        {
            switch (cursor)
            {
                case CssCursor.Alias: return "alias";
                case CssCursor.Auto: return "auto";
                case CssCursor.Inherit: return "inherit";
                case CssCursor.AllScroll: return "all-scroll";
                case CssCursor.Cell: return "cell";
                case CssCursor.ColResize: return "col-resize";
                case CssCursor.ContextMenu: return "context-menu";
                case CssCursor.Copy: return "copy";
                case CssCursor.Crosshair: return "crosshair";
                case CssCursor.Default: return "default";
                case CssCursor.EResize: return "e-resize";
                case CssCursor.EWResize: return "ew-resize";
                case CssCursor.Help: return "help";
                case CssCursor.Move: return "move";
                case CssCursor.NResize: return "n-resize";
                case CssCursor.NeResize: return "ne-resize";
                case CssCursor.NeswResize: return "nesw-resize";
                case CssCursor.NoDrop: return "no-drop";
                case CssCursor.None: return "none";
                case CssCursor.NotAllowed: return "not-allowed";
                case CssCursor.NsResize: return "ns-resize";
                case CssCursor.NwResize: return "nw-resize";
                case CssCursor.NwseResize: return "nwse-resize";
                case CssCursor.Pointer: return "pointer";
                case CssCursor.Progress: return "progress";
                case CssCursor.RowResize: return "row-resize";
                case CssCursor.SResize: return "s-resize";
                case CssCursor.SeResize: return "se-resize";
                case CssCursor.SwResize: return "sw-resize";
                case CssCursor.Text: return "text";
                case CssCursor.Url: return "URL";
                case CssCursor.VerticalText: return "vertical-text";
                case CssCursor.WResize: return "w-resize";
                case CssCursor.Wait: return "wait";
                case CssCursor.ZoomIn: return "zoom-in";
                default: throw new Exception("Unknown enum type: " + cursor);
            }
        }

        public static CssCursor Parse(string s)
        {
            switch (s)
            {
                case "alias":
                    return CssCursor.Alias;
                case "auto":
                    return CssCursor.Auto;
                case "inherit":
                    return CssCursor.Inherit;
                case "all-scroll":
                    return CssCursor.AllScroll;
                case "cell":
                    return CssCursor.Cell;
                case "col-resize":
                    return CssCursor.ColResize;
                case "context-menu":
                    return CssCursor.ContextMenu;
                case "copy":
                    return CssCursor.Copy;
                case "crosshair":
                    return CssCursor.Crosshair;
                case "default":
                    return CssCursor.Default;
                case "e-resize":
                    return CssCursor.EResize;
                case "ew-resize":
                    return CssCursor.EWResize;
                case "help":
                    return CssCursor.Help;
                case "move":
                    return CssCursor.Move;
                case "n-resize":
                    return CssCursor.NResize;
                case "ne-resize":
                    return CssCursor.NeResize;
                case "nesw-resize":
                    return CssCursor.NeswResize;
                case "no-drop":
                    return CssCursor.NoDrop;
                case "none":
                    return CssCursor.None;
                case "not-allowed":
                    return CssCursor.NotAllowed;
                case "ns-resize":
                    return CssCursor.NsResize;
                case "nw-resize":
                    return CssCursor.NwResize;
                case "nwse-resize":
                    return CssCursor.NwseResize;
                case "pointer":
                    return CssCursor.Pointer;
                case "progress":
                    return CssCursor.Progress;
                case "row-resize":
                    return CssCursor.RowResize;
                case "s-resize":
                    return CssCursor.SResize;
                case "se-resize":
                    return CssCursor.SeResize;
                case "sw-resize":
                    return CssCursor.SwResize;
                case "text":
                    return CssCursor.Text;
                case "URL":
                    return CssCursor.Url;
                case "vertical-text":
                    return CssCursor.VerticalText;
                case "w-resize":
                    return CssCursor.WResize;
                case "wait":
                    return CssCursor.Wait;
                case "zoom-in":
                    return CssCursor.ZoomIn;
                default: throw new Exception("Unknown enum type: " + s);
            }
        }
    }
}