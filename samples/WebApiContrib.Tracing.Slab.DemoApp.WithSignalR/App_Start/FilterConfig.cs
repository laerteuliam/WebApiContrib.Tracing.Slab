﻿using System.Web;
using System.Web.Mvc;

namespace WebApiContrib.Tracing.Slab.DemoApp.WithSignalR
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}