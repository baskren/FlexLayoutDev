using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ControlsTest
{
    partial class CustomPanel : Panel
    {
        #region TextBlock Property
        public static readonly DependencyProperty TextBlockProperty = DependencyProperty.RegisterAttached(
            "TextBlock",
            typeof(TextBlock),
            typeof(CustomPanel),
            new PropertyMetadata(null)
        );
        public static TextBlock GetTextBlock(FrameworkElement element)
            => (TextBlock)element.GetValue(TextBlockProperty);
        #endregion TextBlock Property


        #region FlexItem Property
        public static readonly DependencyProperty FlexItemProperty = DependencyProperty.RegisterAttached(
            "FlexItemInternal",
            typeof(System.Collections.IList),
            typeof(CustomPanel),
            new PropertyMetadata(null)
        );
        public static Item GetFlexItem(DependencyObject element)
        //             => (FlexItem)element.GetValue(FlexItemProperty);
        {
            //if (element.ReadLocalValue(FlexItemProperty) == DependencyProperty.UnsetValue)
            //    return null;

            var value = element.GetValue(FlexItemProperty);
            if (value is null)
            {
                var newItem = new Item();
                SetFlexItem(element, newItem);
                return newItem;
            }
            return (Item)value;

        }
        public static void SetFlexItem(DependencyObject element, Item value)
            => element.SetValue(FlexItemProperty, value);
        #endregion FlexItem Property


        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (var child in Children)
            {
                if (child.Visibility != Visibility.Collapsed && ( child.DesiredSize.Width < 1 || child.DesiredSize.Height < 1))
                    child.Measure(availableSize);
            }
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 0;
            double y = 0;

            foreach (var child in Children)
            {
                child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
                x += child.DesiredSize.Width;
            }
            return base.ArrangeOverride(finalSize);
        }
    }
}
