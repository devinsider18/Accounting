using FluentAvalonia.UI.Controls;
using System;

namespace Calculus
{
    public static class Nav
    {
        public static Frame? MainFrame { get; set; }
        public static void Go(Type pageType)
        {
            MainFrame.Navigate(pageType);
        }
    }
}