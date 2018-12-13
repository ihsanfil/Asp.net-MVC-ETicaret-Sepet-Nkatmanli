﻿namespace Northwind.MvcWebUI.Models
{
    public class PageingInfo
    {
        public int ItemsPerpage { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentCategory { get; internal set; }
    }
}