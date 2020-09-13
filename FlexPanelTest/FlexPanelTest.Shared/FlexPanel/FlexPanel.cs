using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Bc3.Forms
{
    public partial class FlexPanel : Panel
    {
        #region Properties

#if __ANDROID__ || __WASM__ || __IOS__
#else
        #region Padding Property
        public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(
            nameof(Padding),
            typeof(Thickness),
            typeof(FlexPanel),
            new PropertyMetadata(new Thickness(0), new PropertyChangedCallback((d,e) => ((FlexPanel)d).OnPaddingChanged(e)))
        );
        protected virtual void OnPaddingChanged(DependencyPropertyChangedEventArgs e)
        {
            InvalidateMeasure();
        }
        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => this.SetNewValue(PaddingProperty, value);
        }
        #endregion Padding Property
#endif


        #region Direction Property
        public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register(
            nameof(Direction),
            typeof(FlexDirection),
            typeof(FlexPanel),
            new PropertyMetadata(FlexDirection.Row, new PropertyChangedCallback((d,e) => ((FlexPanel)d).OnDirectionChanged(e)))
        );
        protected virtual void OnDirectionChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.Direction = (FlexDirection)e.NewValue;
                InvalidateMeasure();
            }
        }
        public FlexDirection Direction
        {
            get => (FlexDirection)GetValue(DirectionProperty);
            set => this.SetNewValue(DirectionProperty, value);
        }
#endregion Direction Property


#region JustifyContent Property
        public static readonly DependencyProperty JustifyContentProperty = DependencyProperty.Register(
            nameof(JustifyContent),
            typeof(FlexJustify),
            typeof(FlexPanel),
            new PropertyMetadata(FlexJustify.Start, new PropertyChangedCallback((d,e) => ((FlexPanel)d).OnJustifyContentChanged(e)))
        );
        protected virtual void OnJustifyContentChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.JustifyContent = (FlexJustify)e.NewValue;
                InvalidateMeasure();
            }
        }
        public FlexJustify JustifyContent
        {
            get => (FlexJustify)GetValue(JustifyContentProperty);
            set => this.SetNewValue(JustifyContentProperty, value);
        }
#endregion JustifyContent Property


#region AlignContent Property
        public static readonly DependencyProperty AlignContentProperty = DependencyProperty.Register(
            nameof(AlignContent),
            typeof(FlexAlignContent),
            typeof(FlexPanel),
            new PropertyMetadata(FlexAlignContent.Stretch, new PropertyChangedCallback((d,e) => ((FlexPanel)d).OnAlignContentChanged(e)))
        );
        protected virtual void OnAlignContentChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.AlignContent = (FlexAlignContent)e.NewValue;
                InvalidateMeasure();
            }
        }
        public FlexAlignContent AlignContent
        {
            get => (FlexAlignContent)GetValue(AlignContentProperty);
            set => this.SetNewValue(AlignContentProperty, value);
        }
#endregion AlignContent Property


#region AlignItems Property
        public static readonly DependencyProperty AlignItemsProperty = DependencyProperty.Register(
            nameof(AlignItems),
            typeof(FlexAlignItems),
            typeof(FlexPanel),
            new PropertyMetadata(FlexAlignItems.Stretch, new PropertyChangedCallback((d,e) => ((FlexPanel)d).OnAlignItemsChanged(e)))
        );
        protected virtual void OnAlignItemsChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.AlignItems = (FlexAlignItems)e.NewValue;
                InvalidateMeasure();
            }
        }
        public FlexAlignItems AlignItems
        {
            get => (FlexAlignItems)GetValue(AlignItemsProperty);
            set => this.SetNewValue(AlignItemsProperty, value);
        }
#endregion AlignItems Property


#region Position Property
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register(
            nameof(Position),
            typeof(FlexPosition),
            typeof(FlexPanel),
            new PropertyMetadata(FlexPosition.Relative, new PropertyChangedCallback((d,e) => ((FlexPanel)d).OnPositionChanged(e)))
        );
        protected virtual void OnPositionChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.Position = (FlexPosition)e.NewValue;
                InvalidateMeasure();
            }
        }
        public FlexPosition Position
        {
            get => (FlexPosition)GetValue(PositionProperty);
            set => this.SetNewValue(PositionProperty, value);
        }
#endregion Position Property


#region Wrap Property
        public static readonly DependencyProperty WrapProperty = DependencyProperty.Register(
            nameof(Wrap),
            typeof(FlexWrap),
            typeof(FlexPanel),
            new PropertyMetadata(FlexWrap.NoWrap, new PropertyChangedCallback((d,e) => ((FlexPanel)d).OnWrapChanged(e)))
        );
        protected virtual void OnWrapChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_root != null)
            {
                _root.Wrap = (FlexWrap)e.NewValue;
                InvalidateMeasure();
            }
        }
        public FlexWrap Wrap
        {
            get => (FlexWrap)GetValue(WrapProperty);
            set => this.SetNewValue(WrapProperty, value);
        }
#endregion Wrap Property


#region FlexItem Property
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
#endregion FlexItem Property


#region Order Property
        public static readonly DependencyProperty OrderProperty = DependencyProperty.RegisterAttached(
            "Order",
            typeof(int),
            typeof(FlexPanel),
            new PropertyMetadata(default(int), OnOrderChanged)
        );
        static void OnOrderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                item.Order = (int) e.NewValue;
                InternalInvalidateArrange(element);
            }
        }
        public static int GetOrder(UIElement element)
            => (int)element.GetValue(OrderProperty);
        public static void SetOrder(UIElement element, int value)
            => element.SetNewValue(OrderProperty, value);
#endregion Order Property


#region Grow Property
        public static readonly DependencyProperty GrowProperty = DependencyProperty.RegisterAttached(
            "Grow",
            typeof(double),
            typeof(FlexPanel),
            new PropertyMetadata(default(double), OnGrowChanged)
        );
        static void OnGrowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                item.Grow = (double)e.NewValue;
                InternalInvalidateArrange(element);
            }
        }
        public static double GetGrow(UIElement element)
            => (double)element.GetValue(GrowProperty);
        public static void SetGrow(UIElement element, double value)
            => element.SetNewValue(GrowProperty, value);
#endregion Grow Property


#region Shrink Property
        public static readonly DependencyProperty ShrinkProperty = DependencyProperty.RegisterAttached(
            "Shrink",
            typeof(double),
            typeof(FlexPanel),
            new PropertyMetadata(1.0, OnShrinkChanged)
        );
        static void OnShrinkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                item.Shrink = (double)e.NewValue;
                InternalInvalidateArrange(element);
            }
        }
        public static double GetShrink(UIElement element)
            => (double)element.GetValue(ShrinkProperty);
        public static void SetShrink(UIElement element, double value)
            => element.SetNewValue(ShrinkProperty, value);
#endregion Shrink Property


#region AlignSelf Property
        public static readonly DependencyProperty AlignSelfProperty = DependencyProperty.RegisterAttached(
            "AlignSelf",
            typeof(FlexAlignSelf),
            typeof(FlexPanel),
            new PropertyMetadata(FlexAlignSelf.Auto, OnAlignSelfChanged)
        );
        static void OnAlignSelfChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && GetFlexItem(element) is FlexItem item)
            {
                item.AlignSelf = (FlexAlignSelf)e.NewValue;
                InternalInvalidateArrange(element);
            }
        }
        public static FlexAlignSelf GetAlignSelf(UIElement element)
            => (FlexAlignSelf)element.GetValue(AlignSelfProperty);
        public static void SetAlignSelf(UIElement element, FlexAlignSelf value)
            => element.SetNewValue(AlignSelfProperty, value);
#endregion AlignSelf Property


#region Basis Property
        public static readonly DependencyProperty BasisProperty = DependencyProperty.RegisterAttached(
            "Basis",
            typeof(string),
            typeof(FlexPanel),
            new PropertyMetadata("auto", OnBasisChanged)
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
        public static string GetBasis(UIElement element)
        {
            if (element?.GetValue(BasisProperty) is string value)
                return value;
             return "auto";
        }
        public static void SetBasis(UIElement element, string value)
            =>element?.SetNewValue(BasisProperty, value);
        

        static FlexBasis InternalGetFlexBasis(UIElement element)
        {
            if (element.GetValue(BasisProperty) is string value)
                return FlexBasis.Parse(value);
            return FlexBasis.Auto;
        }
        public static void SetBasis(UIElement element, FlexBasis value)
            =>SetBasis(element, value.ToString());
#endregion Basis Property

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
        #endregion


        #region Fields
        FlexItem _root; 
#endregion


#region Construction
        public FlexPanel()
        {
            InitLayoutProperties(_root = new FlexItem());
        }
#endregion


#region Children Handlers
        void InitLayoutProperties(FlexItem item)
        {
            item.AlignContent = (FlexAlignContent)GetValue(AlignContentProperty);
            item.AlignItems = (FlexAlignItems)GetValue(AlignItemsProperty);
            item.Direction = (FlexDirection)GetValue(DirectionProperty);
            item.JustifyContent = (FlexJustify)GetValue(JustifyContentProperty);
            item.Wrap = (FlexWrap)GetValue(WrapProperty);
        }

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
            item.Order = GetOrder(view);//  (int)view.GetValue(OrderProperty);
            item.Grow = GetGrow(view); // (double)view.GetValue(GrowProperty);
            item.Shrink = GetShrink(view); // (double)view.GetValue(ShrinkProperty);
            item.Basis = GetBasis(view); //((FlexBasis)view.GetValue(BasisProperty)).ToFlexBasis();
            item.AlignSelf = (FlexAlignSelf)GetAlignSelf(view); // (AlignSelf)(FlexAlignSelf)view.GetValue(AlignSelfProperty);

            var margin = (Thickness)view.GetValue(MarginProperty);
            item.MarginLeft = (double)margin.Left;
            item.MarginTop = (double)margin.Top;
            item.MarginRight = (double)margin.Right;
            item.MarginBottom = (double)margin.Bottom;

            //var width = (double)view.GetValue(WidthProperty);
            var width = view.Width;
            item.Width = width <= 0 ? double.NaN : (double)width;
            //var height = (double)view.GetValue(HeightProperty);
            var height = view.Height;
            item.Height = height <= 0 ? double.NaN : (double)height;

            item.IsVisible = Visibility.Visible == (Visibility)view.GetValue(VisibilityProperty);
            if (view is FlexPanel flexPanel)
            {
                //var (pleft, ptop, pright, pbottom) = (Thickness)flexPanel.GetValue(PaddingProperty);
                item.PaddingLeft = (double)flexPanel.Padding.Left;
                item.PaddingTop = (double)flexPanel.Padding.Top;
                item.PaddingRight = (double)flexPanel.Padding.Right;
                item.PaddingBottom = (double)flexPanel.Padding.Bottom;
            }

        }
#endregion


#region Layout Handlers
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
                    //frame = frame.Offset(x, y); //flex doesn't support offset on _root
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

            //All of this is a HACK as X.Flex doesn't supports measuring
            //if (!double.IsPositiveInfinity(widthConstraint) && !double.IsPositiveInfinity(heightConstraint))
            //    return new Size(widthConstraint, heightConstraint);

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
#endregion


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
