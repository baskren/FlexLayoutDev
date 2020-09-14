// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See the LICENSE file in the project root
// for the license information.
// 
// Author(s):
//  - Laurent Sansonetti (native Xamarin flex https://github.com/xamarin/flex)
//  - Stephane Delcroix (.NET port)
//  - Ben Askren (UWP/Uno port)
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls
{
    /// <summary>
    /// FlexPanel is a panel based on the CSS Flexible Box Layout Module, commonly known as flex layout or flex-box, 
    /// so called because it includes many flexible options to arrange children within the layout.  It can arrange 
    /// its children horizontally and vertically in a stack, with options to reverse the order of items as well as 
    /// align and justify content and individual items. More importantly, FlexPanel is capable of wrapping its children 
    /// if there are too many to fit in a single row or column, and also has many options for orientation, alignment, 
    /// and adapting to various screen sizes.
    /// </summary>
    public partial class FlexPanel : Panel
    {
        /// <summary>
        /// Dependency Property for the FlexPanel.AlignContent property
        /// </summary>
        public static readonly DependencyProperty AlignContentProperty = DependencyProperty.Register(
            nameof(AlignContent),
            typeof(FlexAlignContent),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.AlignContentDefault, new PropertyChangedCallback((d, e) => ((FlexPanel)d).OnAlignContentChanged(e)))
        );

        void OnAlignContentChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.AlignContent = (FlexAlignContent)e.NewValue;
                InvalidateMeasure();
            }
        }

        ///<summary>
        ///This property defines how the FlexPanel will distribute space between and around child elements that have been 
        ///laid out on multiple lines. This property is ignored if the root item does not have its 
        ///<see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.Wrap" /> property set to Wrap or WrapReverse.
        ///</summary>
        ///<remarks>The default value for this property is Stretch.</remarks>
        public FlexAlignContent AlignContent
        {
            get => (FlexAlignContent)GetValue(AlignContentProperty);
            set => this.SetNewValue(AlignContentProperty, value);
        }


        /// <summary>
        /// Dependency Property for the FlexPanel.AlignItems property
        /// </summary>
        public static readonly DependencyProperty AlignItemsProperty = DependencyProperty.Register(
            nameof(AlignItems),
            typeof(FlexAlignItems),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.AlignItemsDefault, new PropertyChangedCallback((d, e) => ((FlexPanel)d).OnAlignItemsChanged(e)))
        );

        void OnAlignItemsChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.AlignItems = (FlexAlignItems)e.NewValue;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// This property defines how the FlexPanel will distribute space between and around child elements along the 
        /// cross-axis.
        /// </summary>
        /// <remarks>The default value for this property is Stretch.</remarks>
        public FlexAlignItems AlignItems
        {
            get => (FlexAlignItems)GetValue(AlignItemsProperty);
            set => this.SetNewValue(AlignItemsProperty, value);
        }


        /// <summary>
        /// DependencyProperty for the FlexPanel.Direction property
        /// </summary>
        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
            nameof(Direction),
            typeof(FlexDirection),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.DirectionDefault, new PropertyChangedCallback((d, e) => ((FlexPanel)d).OnDirectionChanged(e)))
        );

        void OnDirectionChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.Direction = (FlexDirection)e.NewValue;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// This property defines the direction and main-axis of child elements. If set to Column (or ColumnReverse), 
        /// the main-axis will be the y-axis and items will be stacked vertically. If set to Row (or RowReverse), 
        /// the main-axis will be the x-axis and items will be stacked horizontally.
        /// </summary>
        /// <remarks>The default value for this property is Column.</remarks>
        public FlexDirection Direction
        {
            get => (FlexDirection)GetValue(DirectionProperty);
            set => this.SetNewValue(DirectionProperty, value);
        }


        /// <summary>
        /// Dependency Property for the FlexPanel.JustifyContent property
        /// </summary>
        public static readonly DependencyProperty JustifyContentProperty = DependencyProperty.Register(
            nameof(JustifyContent),
            typeof(FlexJustify),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.JustifyContentDefault, new PropertyChangedCallback((d, e) => ((FlexPanel)d).OnJustifyContentChanged(e)))
        );

        void OnJustifyContentChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.JustifyContent = (FlexJustify)e.NewValue;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// This property defines how the FlexPanel will distribute space between and around child items 
        /// along the main-axis.
        /// </summary>
        /// <remarks>The default value for this property is Start.</remarks>
        public FlexJustify JustifyContent
        {
            get => (FlexJustify)GetValue(JustifyContentProperty);
            set => this.SetNewValue(JustifyContentProperty, value);
        }


        /// <summary>
        /// The Dependency Property for the FlexPanel.Wrap property
        /// </summary>
        public static readonly DependencyProperty WrapProperty = DependencyProperty.Register(
            nameof(Wrap),
            typeof(FlexWrap),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.WrapDefault, new PropertyChangedCallback((d, e) => ((FlexPanel)d).OnWrapChanged(e)))
        );

        void OnWrapChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.Wrap = (FlexWrap)e.NewValue;
                InvalidateMeasure();
            }
        }

        /// <summary>
        /// This property defines whether child elements should be laid out in a single line(NoWrap) 
        /// or multiple lines(Wrap or WrapReverse). If this property is set to Wrap or WrapReverse, 
        /// <see cref = "P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.AlignContent" /> can then be 
        /// used to specify how the lines should be distributed.
        /// </summary>
        /// <remarks>The default value for this property is NoWrap.</remarks>
        public FlexWrap Wrap
        {
            get => (FlexWrap)GetValue(WrapProperty);
            set => this.SetNewValue(WrapProperty, value);
        }


        /// <summary>
        /// The Attached Dependency Property for the FlexLayout.Order attached property
        /// </summary>
        public static readonly DependencyProperty OrderProperty = DependencyProperty.RegisterAttached(
            "Order",
            typeof(int),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.OrderDefault, OnOrderChanged)
        );

        static void OnOrderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                item.Order = (int) e.NewValue;
                InternalInvalidateArrange(element);
            }
        }

        /// <summary>
        /// This attached property specifies whether this UIElement should be laid out before or after other items 
        /// in the FlexPanel.  Items are laid out based on the ascending value of this property. Items that 
        /// have the same value for this property will be laid out in the order they were inserted.
        /// </summary>
        /// <value>The item order (can be a negative, 0, or positive value).</value>
        /// <remarks>The default value for this property is 0.</remarks>
        public static int GetOrder(UIElement element)
            => (int)element.GetValue(OrderProperty);

        /// <summary>
        /// This attached property specifies whether this UIElement should be laid out before or after other items 
        /// in the FlexPanel.  Items are laid out based on the ascending value of this property. Items that 
        /// have the same value for this property will be laid out in the order they were inserted.
        /// </summary>
        /// <value>The item order (can be a negative, 0, or positive value).</value>
        /// <remarks>The default value for this property is 0.</remarks>
        public static void SetOrder(UIElement element, int value)
            => element.SetNewValue(OrderProperty, value);


        /// <summary>
        /// The Attached Dependency Property for the FlexLayout.Grow attached property
        /// </summary>
        public static readonly DependencyProperty GrowProperty = DependencyProperty.RegisterAttached(
            "Grow",
            typeof(double),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.GrowDefault, OnGrowChanged)
        );

        static void OnGrowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                item.Grow = (double)e.NewValue;
                InternalInvalidateArrange(element);
            }
        }

        /// <summary>
        /// This attached property defines the grow factor of the UIElement; the amount of available space it 
        /// should use on the main-axis. If this property is set to 0, the item will not grow.
        /// </summary>
        /// <value>The item grow factor.</value>
        /// <remarks>The default value for this property is 0 (does not take any available space).</remarks>
        public static double GetGrow(UIElement element)
            => (double)element.GetValue(GrowProperty);

        /// <summary>
        /// This attached property defines the grow factor of the UIElement; the amount of available space it 
        /// should use on the main-axis. If this property is set to 0, the item will not grow.
        /// </summary>
        /// <value>The item grow factor.</value>
        /// <remarks>The default value for this property is 0 (does not take any available space).</remarks>
        public static void SetGrow(UIElement element, double value)
            => element.SetNewValue(GrowProperty, value);


        /// <summary>
        /// The Attached Dependency Property for the FlexLayout.Shrink attached property;
        /// </summary>
        public static readonly DependencyProperty ShrinkProperty = DependencyProperty.RegisterAttached(
            "Shrink",
            typeof(double),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.ShrinkDefault, OnShrinkChanged)
        );

        static void OnShrinkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                item.Shrink = (double)e.NewValue;
                InternalInvalidateArrange(element);
            }
        }

        /// <summary>
        /// This attached property defines the shrink factor of the UIElement.  In case the child items overflow 
        /// the main-axis of the container, this factor will be used to determine how individual items 
        /// should shrink so that all items can fill inside the container.If this property is set to 0, 
        /// the item will not shrink.
        /// </summary>
        /// <value>The item shrink factor.</value>
        /// <remarks>The default value for this property is 1 (all items will shrink equally).</remarks>
        public static double GetShrink(UIElement element)
            => (double)element.GetValue(ShrinkProperty);

        /// <summary>
        /// This attached property defines the shrink factor of the UIElement.  In case the child items overflow 
        /// the main-axis of the container, this factor will be used to determine how individual items 
        /// should shrink so that all items can fill inside the container.If this property is set to 0, 
        /// the item will not shrink.
        /// </summary>
        /// <value>The item shrink factor.</value>
        /// <remarks>The default value for this property is 1 (all items will shrink equally).</remarks>
        public static void SetShrink(UIElement element, double value)
            => element.SetNewValue(ShrinkProperty, value);


        /// <summary>
        /// The Attached Dependency Property for the FlexPanel.AlignSelf attached property
        /// </summary>
        public static readonly DependencyProperty AlignSelfProperty = DependencyProperty.RegisterAttached(
            "AlignSelf",
            typeof(FlexAlignSelf),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.AlignSelfDefault, OnAlignSelfChanged)
        );

        static void OnAlignSelfChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                item.AlignSelf = (FlexAlignSelf)e.NewValue;
                InternalInvalidateArrange(element);
            }
        }

        /// <summary>
        /// This attached property defines how the FlexPanel will distribute space between and around child 
        /// element for a specific element along the cross-axis. If this property is set to FlexAlignSelf.Auto 
        /// on a child element, the parent's value for <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.AlignItems" /> 
        /// will be used instead.
        /// </summary>
        /// <remarks>The default value for this property FlexAlignSelf.Auto.</remarks>
        public static FlexAlignSelf GetAlignSelf(UIElement element)
            => (FlexAlignSelf)element.GetValue(AlignSelfProperty);

        /// <summary>
        /// This attached property defines how the FlexPanel will distribute space between and around child 
        /// element for a specific element along the cross-axis. If this property is set to FlexAlignSelf.Auto 
        /// on a child element, the parent's value for <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.AlignItems" /> 
        /// will be used instead.
        /// </summary>
        /// <remarks>The default value for this property FlexAlignSelf.Auto.</remarks>
        public static void SetAlignSelf(UIElement element, FlexAlignSelf value)
            => element.SetNewValue(AlignSelfProperty, value);


        /// <summary>
        /// The Attached Dependency Property for the FlexLayout.Basis attached property
        /// </summary>
        public static readonly DependencyProperty BasisProperty = DependencyProperty.RegisterAttached(
            "Basis",
            typeof(string),
            typeof(FlexPanel),
            new PropertyMetadata(FlexItem.BasisDefault.ToString(), OnBasisChanged)
        );

        static void OnBasisChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                if (e.NewValue is string value)
                    item.Basis = FlexBasis.Parse(value);
                else
                    item.Basis = FlexBasis.Auto;
                InternalInvalidateArrange(element);
            }
        }

        /// <summary>
        /// This property defines the initial main-axis dimension of the UIElement in the FlexLayout or if that value
        /// calculated by FlexPanel (FlexBasis.Auto).  If FlexBasis.IsRelative is false, then this child element's 
        /// main-axis dimension will the FlexBasis.Length, in pixels.  Any remaining space will be portioned among all the child 
        /// elements with a FlexBasis.IsRelstive set to true.
        /// </summary>
        /// <remarks>The default value for this property is Auto.</remarks>
        public static string GetBasis(UIElement element)
        {
            if (element?.GetValue(BasisProperty) is string value)
                return value;
             return "auto";
        }

        /// <summary>
        /// This property defines the initial main-axis dimension of the UIElement in the FlexLayout or if that value
        /// calculated by FlexPanel (FlexBasis.Auto).  If FlexBasis.IsRelative is false, then this child element's 
        /// main-axis dimension will the FlexBasis.Length, in pixels.  Any remaining space will be portioned among all the child 
        /// elements with a FlexBasis.IsRelstive set to true.
        /// </summary>
        /// <remarks>The default value for this property is Auto.</remarks>
        public static void SetBasis(UIElement element, string value)
            =>element?.SetNewValue(BasisProperty, value);
        

        static FlexBasis InternalGetFlexBasis(UIElement element)
        {
            if (element.GetValue(BasisProperty) is string value)
                return FlexBasis.Parse(value);
            return FlexBasis.Auto;
        }

        /// <summary>
        /// This property defines the initial main-axis dimension of the UIElement in the FlexLayout or if that value
        /// calculated by FlexPanel (FlexBasis.Auto).  If FlexBasis.IsRelative is false, then this child element will be 
        /// main-axis dimension will the FlexBasis.Length.  Any remaining space will be portioned among all the child 
        /// elements with a FlexBasis.IsRelstive set to true.
        /// </summary>
        /// <remarks>The default value for this property is Auto.</remarks>
        public static void SetBasis(UIElement element, FlexBasis value)
            =>SetBasis(element, value.ToString());



        static readonly DependencyProperty FlexItemProperty = DependencyProperty.RegisterAttached(
            "FlexItem",
            typeof(object),
            typeof(FlexPanel),
            new PropertyMetadata(null)
        );

        static FlexItem GetFlexItem(UIElement element)
        {
            if (element is null)
                return null;
            if (element is FlexPanel flexPanel)
                return flexPanel._root;
            FlexItem item = null;
            try
            {
                item = (FlexItem)element.GetValue(FlexItemProperty);
            }
            catch (Exception) { }

            if (item is null)
            {
                item = new FlexItem();
                element.SetValue(FlexItemProperty, item);
            }
            return item;
        }

        static void SetFlexItem(UIElement element, FlexItem value)
        {
            element.SetNewValue(FlexItemProperty, value);
            UpdateItemProperties(element, value);
        }

        static void InternalInvalidateArrange(UIElement element)
        {
            if (element is FlexPanel)
                element.InvalidateArrange();
            else if (element is FrameworkElement frameworkElement && frameworkElement.Parent is FlexPanel flexPanel)
                flexPanel.InvalidateArrange();
        }

        static void UpdateItemProperties(UIElement view, FlexItem item)
        {

            item.IsVisible = view.Visibility == Visibility.Visible;
            
            if (view is FrameworkElement element)
            {
                item.MarginLeft = (double)element.Margin.Left;
                item.MarginTop = (double)element.Margin.Top;
                item.MarginRight = (double)element.Margin.Right;
                item.MarginBottom = (double)element.Margin.Bottom;
            }

            if (view is Control control)
                item.SetPadding(control.Padding);
            else if (view is Border border)
                item.SetPadding(border.Padding);
            else if (view is TextBlock textBlock)
                item.SetPadding(textBlock.Padding);
#if __ANDROID__ || __WASM__
#else
            else if (view is RichTextBlock richTextBlock)
                item.SetPadding(richTextBlock.Padding);
#endif
        }


        readonly FlexItem _root = new FlexItem(); 


        FlexItem AddChild(FrameworkElement view)
        {
            if (_root == null)
                return null;

            view.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            var item = (view as FlexPanel)?._root ?? new FlexItem();
            InitItemProperties(view, item);
            if (!(view is FlexPanel))
            { 
                //inner layouts don't get measured
                item.SelfSizing = (FlexItem it, ref double w, ref double h) => {

                    UpdateItemProperties(view, item);                    

                    if (view.DesiredSize.Width > 0 && view.DesiredSize.Height > 0)
                    {
                        w = (double)view.DesiredSize.Width;
                        h = (double)view.DesiredSize.Height;
                        return;
                    }

                    var sizeConstraints = item.GetConstraints();
                    sizeConstraints.Width = (_measuring && sizeConstraints.Width == 0) ? double.PositiveInfinity : sizeConstraints.Width;
                    sizeConstraints.Height = (_measuring && sizeConstraints.Height == 0) ? double.PositiveInfinity : sizeConstraints.Height;
                    view.Measure(sizeConstraints);
                    w = (double)view.DesiredSize.Width;
                    h = (double)view.DesiredSize.Height;
                };
            }

            _root.InsertAt(Children.IndexOf(view), item);
            SetFlexItem(view, item);

            return item;
        }

        void InitItemProperties(FrameworkElement view, FlexItem item)
        {
            item.Order = GetOrder(view);
            item.Grow = GetGrow(view);
            item.Shrink = GetShrink(view);
            item.Basis = GetBasis(view);
            item.AlignSelf = GetAlignSelf(view);

            var margin = (Thickness)view.GetValue(MarginProperty);
            item.MarginLeft = (double)margin.Left;
            item.MarginTop = (double)margin.Top;
            item.MarginRight = (double)margin.Right;
            item.MarginBottom = (double)margin.Bottom;

            var width = view.Width;
            item.Width = width <= 0 ? double.NaN : (double)width;

            var height = view.Height;
            item.Height = height <= 0 ? double.NaN : (double)height;

            item.IsVisible = Visibility.Visible == (Visibility)view.GetValue(VisibilityProperty);
        }



        protected override Size ArrangeOverride(Size finalSize)
        {
            var width = finalSize.Width;
            var height = finalSize.Height;

            Layout(width, height);

            foreach (var child in Children)
            {
                if (GetFlexItem(child) is FlexItem item)
                {
                    var frame = item.GetFrame();
                    if (double.IsNaN(frame.X)
                        || double.IsNaN(frame.Y)
                        || double.IsNaN(frame.Width)
                        || double.IsNaN(frame.Height))
                        throw new Exception("something is deeply wrong");
                    child.Arrange(frame);
                }
            }
            return finalSize;
        }

        bool _measuring;
        protected override Size MeasureOverride(Size availableSize)
        {
            var widthConstraint = availableSize.Width;
            var heightConstraint = availableSize.Height;

            if (_root == null)
                return new Size(widthConstraint, heightConstraint);

            _measuring = true;
            //1. Keep track of missing layout items
            var deleteCandidates = _root.ToList();

            //2. Set Shrink to 0, set align-self to start (to avoid stretching)
            //   Set Image.Aspect to Fill to get the value we expect in measuring
            foreach (var child in Children)
            {
                if (GetFlexItem(child) is FlexItem item && item.Parent != null)
                    deleteCandidates.Remove(item);
                else if (child is FrameworkElement frameworkElement)
                    item = AddChild(frameworkElement);
                else
                    continue;
                item.Shrink = 0;
                item.AlignSelf = FlexAlignSelf.Start;
            }

            //3. Remove missing layout items
            foreach (var item in deleteCandidates)
                _root.Remove(item);


            Layout(widthConstraint, heightConstraint);

            //4. look at the children location
            if (double.IsPositiveInfinity(widthConstraint))
            {
                widthConstraint = 0;
                foreach (var item in _root)
                    widthConstraint = Math.Max(widthConstraint, item.Frame[0] + item.Frame[2] + item.MarginRight);
            }
            if (double.IsPositiveInfinity(heightConstraint))
            {
                heightConstraint = 0;
                foreach (var item in _root)
                    heightConstraint = Math.Max(heightConstraint, item.Frame[1] + item.Frame[3] + item.MarginBottom);
            }

            //5. reset Shrink, algin-self, and image.aspect
            foreach (var child in Children)
            {
                if (GetFlexItem(child) is FlexItem item)
                {
                    item.Shrink = (double)child.GetValue(ShrinkProperty);
                    item.AlignSelf = (FlexAlignSelf)child.GetValue(AlignSelfProperty);
                }
            }
            _measuring = false;

            var result = new Size(widthConstraint, heightConstraint);
            return result;
        }

        void Layout(double width, double height)
        {
            if (_root.Parent != null)   //Layout is only computed at root level
                return;
            _root.Width = !double.IsPositiveInfinity((width)) ? (double)width : 0;
            _root.Height = !double.IsPositiveInfinity((height)) ? (double)height : 0;
            _root.Layout();
        }


    }

    static class FlexItemExtensions
    {
        public static int IndexOf(this FlexItem parent, FlexItem child)
        {
            var index = -1;
            foreach (var it in parent)
            {
                index++;
                if (it == child)
                    return index;
            }
            return -1;
        }

        public static void Remove(this FlexItem parent, FlexItem child)
        {
            var index = parent.IndexOf(child);
            if (index < 0)
                return;
            parent.RemoveAt((uint)index);
        }

        public static Rect GetFrame(this FlexItem item)
        {
            return new Rect(item.Frame[0], item.Frame[1], Math.Max(item.Frame[2],0), Math.Max(item.Frame[3],0));
        }

        public static Size GetConstraints(this FlexItem item)
        {
            var widthConstraint = -1d;
            var heightConstraint = -1d;
            var parent = item.Parent;
            do
            {
                if (parent == null)
                    break;
                if (widthConstraint < 0 && !double.IsNaN(parent.Width))
                    widthConstraint = (double)parent.Width;
                if (heightConstraint < 0 && !double.IsNaN(parent.Height))
                    heightConstraint = (double)parent.Height;
                parent = parent.Parent;
            } while (widthConstraint < 0 || heightConstraint < 0);
            return new Size(widthConstraint, heightConstraint);
        }

        public static void SetPadding(this FlexItem item, Thickness padding)
        {
            item.PaddingLeft = (double)padding.Left;
            item.PaddingTop = (double)padding.Top;
            item.PaddingRight = (double)padding.Right;
            item.PaddingBottom = (double)padding.Bottom;
        }
    }

    static class DependencyObjectExtensions
    {
        public static void SetNewValue(this DependencyObject obj, DependencyProperty dp, object value)
        {
            if (obj is null)
                return;
            var currentValue = obj.GetValue(dp);
            if ((currentValue is null && !(value is null)) || !currentValue.Equals(value))
                obj.SetValue(dp, value);
        }
    }

}
