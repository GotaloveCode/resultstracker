﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ResultsTracker
{
    internal static class FrameworkElementExtender
    {
        internal static Page GetParentPage(this FrameworkElement element)
        {
            DependencyObject walk = element;
            while (walk != null)
            {
                if (walk is Page)
                    return (Page)walk;

                if (walk is FrameworkElement)
                    walk = ((FrameworkElement)walk).Parent;
                else
                    break;
            }

            // nothing...
            return null;
        }

    }
}
