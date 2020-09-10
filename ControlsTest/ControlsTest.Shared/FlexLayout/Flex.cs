﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See the LICENSE file in the project root
// for the license information.
// 
// Author(s):
//  - Laurent Sansonetti (native Xamarin flex https://github.com/xamarin/flex)
//  - Stephane Delcroix (.NET port)
//
using Bc3.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Bc3.Flex
{
    #region Enums
    /// <summary>
    /// Values for <see cref="P:Bc3.Flex.Item.AlignContent" />.
    /// </summary>
    enum AlignContent
	{
		/// <summary>
		/// Whether an item's should be stretched out.
		/// </summary>
		Stretch = 1,
		/// <summary>
		/// Whether an item should be packed around the center.
		/// </summary>
		Center = 2,
		/// <summary>
		/// Whether an item should be packed at the start.
		/// </summary>
		Start = 3,
		/// <summary>
		/// Whether an item should be packed at the end.
		/// </summary>
		End = 4,
		/// <summary>
		/// Whether items should be distributed evenly, the first item being at the start and the last item being at the end.
		/// </summary>
		SpaceBetween = 5,
		/// <summary>
		/// Whether items should be distributed evenly, the first and last items having a half-size space.
		/// </summary>
		SpaceAround = 6,
		/// <summary>
		/// Whether items should be distributed evenly, all items having equal space around them.
		/// </summary>
		SpaceEvenly = 7,
	}

	/// <summary>
	/// Values for <see cref="P:Bc3.Flex.Item.AlignItems" />.
	/// </summary>
	enum AlignItems
	{
		/// <summary>
		/// Whether an item's should be stretched out.
		/// </summary>
		Stretch = 1,
		/// <summary>
		/// Whether an item should be packed around the center.
		/// </summary>
		Center = 2,
		/// <summary>
		/// Whether an item should be packed at the start.
		/// </summary>
		Start = 3,
		/// <summary>
		/// Whether an item should be packed at the end.
		/// </summary>
		End = 4,
		//Baseline = 8,
	}

	/// <summary>
	/// Values for <see cref="P:Bc3.Flex.Item.AlignSelf" />.
	/// </summary>
	enum AlignSelf
	{
		/// <summary>
		/// Whether an item should be packed according to the alignment value of its parent.
		/// </summary>
		Auto = 0,
		/// <summary>
		/// Whether an item's should be stretched out.
		/// </summary>
		Stretch = 1,
		/// <summary>
		/// Whether an item should be packed around the center.
		/// </summary>
		Center = 2,
		/// <summary>
		/// Whether an item should be packed at the start.
		/// </summary>
		Start = 3,
		/// <summary>
		/// Whether an item should be packed at the end.
		/// </summary>
		End = 4,
	}

	/// <summary>
	/// Values for <see cref="P:Bc3.Flex.Item.Direction" />.
	/// </summary>
	enum Direction
	{
		/// <summary>
		/// Whether items should be stacked horizontally.
		/// </summary>
		Row = 0,
		/// <summary>
		/// Like Row but in reverse order.
		/// </summary>
		RowReverse = 1,
		/// <summary>
		/// Whether items should be stacked vertically.
		/// </summary>
		Column = 2,
		/// <summary>
		/// Like Column but in reverse order.
		/// </summary>
		ColumnReverse = 3,
	}

	/// <summary>
	/// Values for <see cref="P:Bc3.Flex.Item.Justify" />.
	/// </summary>
	enum Justify
	{
		/// <summary>
		/// Whether an item should be packed around the center.
		/// </summary>
		Center = 2,
		/// <summary>
		/// Whether an item should be packed at the start.
		/// </summary>
		Start = 3,
		/// <summary>
		/// Whether an item should be packed at the end.
		/// </summary>
		End = 4,
		/// <summary>
		/// Whether items should be distributed evenly, the first item being at the start and the last item being at the end.
		/// </summary>
		SpaceBetween = 5,
		/// <summary>
		/// Whether items should be distributed evenly, the first and last items having a half-size space.
		/// </summary>
		SpaceAround = 6,
		/// <summary>
		/// Whether items should be distributed evenly, all items having equal space around them.
		/// </summary>
		SpaceEvenly = 7,
	}

	/// <summary>
	/// Values for <see cref="P:Bc3.Flex.Item.Position" />.
	/// </summary>
	enum Position
	{
		/// <summary>
		/// Whether the item's frame will be determined by the flex rules of the layout system.
		/// </summary>
		Relative = 0,
		/// <summary>
		/// Whether the item's frame will be determined by fixed position values (<see cref="P:Bc3.Flex.Item.Left" />, <see cref="P:Bc3.Flex.Item.Right" />, <see cref="P:Bc3.Flex.Item.Top" /> and <see cref="P:Bc3.Flex.Item.Bottom" />).
		/// </summary>
		Absolute = 1,
	}

	/// <summary>
	/// Values for <see cref="P:XamBc3arin.Flex.Item.Wrap" />.
	/// </summary>
	enum Wrap
	{
		/// <summary>
		/// Whether items are laid out in a single line.
		/// </summary>
		NoWrap = 0,
		/// <summary>
		/// Whether items are laid out in multiple lines if needed.
		/// </summary>
		Wrap = 1,
		/// <summary>
		/// Like Wrap but in reverse order.
		/// </summary>
		WrapReverse = 2,
	}
    #endregion

    #region structs
    /// <summary>
    /// Value for <see cref="P:Bc3.Flex.Item.Basis" />.
    /// </summary>
    struct Basis
	{
		readonly bool _isRelative;
		readonly bool _isLength;
		readonly double _length;
		/// <summary>
		/// Auto basis.
		/// </summary>
		public static Basis Auto = new Basis();
		/// <summary>
		/// Whether the basis length is relative to parent's size.
		/// </summary>
		public bool IsRelative => _isRelative;
		/// <summary>
		/// Whether the basis is auto.
		/// </summary>
		public bool IsAuto => !_isLength && !_isRelative;
		/// <summary>
		/// Gets the length.
		/// </summary>
		/// <value>The length.</value>
		public double Length => _length;
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Bc3.Flex.Basis"/> struct.
		/// </summary>
		/// <param name="length">Length.</param>
		/// <param name="isRelative">If set to <c>true</c> if relative.</param>
		public Basis(double length, bool isRelative = false)
		{
			_length = length;
			_isLength = !isRelative;
			_isRelative = isRelative;
		}

        public override string ToString()
        {
			if (IsAuto)
				return "auto";
			var result = Length.ToString();
			if (IsRelative)
				result += "," + "relative";
			return result;
        }

		public static Basis Parse(string value)
        {
			var flexBasis = FlexBasis.Parse(value);
			return flexBasis;
		}

        public static implicit operator Basis(FlexBasis v)
        {
			if (v.IsAuto)
				return Auto;
			return new Basis(v.Length, v.IsRelative);
        }

		public static implicit operator Basis(string v)
			=> Parse(v);
    }
    #endregion



    /// <summary>
    /// An item with flexbox properties. Items can also contain other items and be enumerated.
    /// </summary>
    class Item : IEnumerable<Item>
	{
        #region Properties
        /// <summary>
        /// Gets the frame (x, y, w, h).
        /// </summary>
        /// <value>The frame.</value>
        public double[] Frame { get; } = new double[4];

		/// <summary>The parent item.</summary>
		/// <value>The parent item, or null if the item is a root item.</value>
		public Item Parent { get; private set; }
		IList<Item> Children { get; set; }
		bool ShouldOrderChildren { get; set; }

		///<summary>This property defines how the layout engine will distribute space between and around child items that have been laid out on multiple lines. This property is ignored if the root item does not have its <see cref="P:Bc3.Flex.Item.Wrap" /> property set to Wrap or WrapReverse.</summary>
		///<remarks>The default value for this property is Stretch.</remarks>
		/// <value>The content of the align.</value>
		public AlignContent AlignContent { get; set; } = AlignContent.Stretch;

		/// <summary>This property defines how the layout engine will distribute space between and around child items along the cross-axis.</summary>
		/// <value>The align items.</value>
		/// <remarks>The default value for this property is Stretch.</remarks>
		public AlignItems AlignItems { get; set; } = AlignItems.Stretch;

		/// <summary>This property defines how the layout engine will distribute space between and around child items for a specific child along the cross-axis. If this property is set to Auto on a child item, the parent's value for <see cref="P:Bc3.Flex.Item.AlignItems" /> will be used instead.</summary>
		/// <value>The align self.</value>
		public AlignSelf AlignSelf { get; set; } = AlignSelf.Auto;

		/// <summary>This property defines the initial main-axis dimension of the item. If <see cref="P:Bc3.Flex.Item.Direction" /> is row-based (horizontal), it will be used instead of <see cref="P:Bc3.Flex.Item.Width" />, and if it's column-based (vertical), it will be used instead of <see cref="P:Bc3.Flex.Item.Height" />.</summary>
		/// <value>The basis.</value>
		/// <remarks>The default value for this property is Auto.</remarks>
		public Basis Basis { get; set; } = Basis.Auto;

		/// <summary>This property defines the bottom edge absolute position of the item. It also defines the item's height if <see cref="P:Bc3.Flex.Item.Top" /> is also set and if <see cref="P:Bc3.Flex.Item.Height" /> isn't set. It is ignored if <see cref="P:Bc3.Flex.Item.Position" /> isn't set to Absolute.</summary>
		/// <value>The value for the property.</value>
		/// <remarks>The default value for this property is NaN.</remarks>
		public double Bottom { get; set; } = double.NaN;

		/// <summary>This property defines the direction and main-axis of child items. If set to Column (or ColumnReverse), the main-axis will be the y-axis and items will be stacked vertically. If set to Row (or RowReverse), the main-axis will be the x-axis and items will be stacked horizontally.</summary>
		/// <value>Any value part of the<see cref="T:Bc3.Flex.Direction" /> enumeration.</value>
		/// <remarks>The default value for this property is Column.</remarks>
		public Direction Direction { get; set; } = Direction.Column;

		/// <summary>This property defines the grow factor of the item; the amount of available space it should use on the main-axis. If this property is set to 0, the item will not grow.</summary>
		/// <value>The item grow factor.</value>
		/// <remarks>The default value for this property is 0 (does not take any available space).</remarks>
		public double Grow { get; set; } = 0f;

		/// <summary>This property defines the height size dimension of the item.</summary>
		/// <value>The height size dimension.</value>
		/// <remarks>The default value for this property is NaN.</remarks>
		public double Height { get; set; } = double.NaN;

		public bool IsVisible { get; set; } = true;

		/// <summary>This property defines how the layout engine will distribute space between and around child items along the main-axis.</summary>
		/// <value>Any value part of the<see cref="T:Bc3.Flex.Align" /> enumeration, with the exception of Stretch and Auto.</value>
		/// <remarks>The default value for this property is Start.</remarks>
		public Justify JustifyContent { get; set; } = Justify.Start;

		/// <summary>This property defines the left edge absolute position of the item.It also defines the item's width if <see cref="P:Bc3.Flex.Item.Right" /> is also set and if <see cref="P:Bc3.Flex.Item.Width" /> isn't set.It is ignored if <see cref = "P:Bc3.Flex.Item.Position" /> isn't set to Absolute.</summary>
		/// <value>The value for the property.</value>
		/// <remarks>The default value for this property is NaN.</remarks>
		public double Left { get; set; } = double.NaN;

		/// <summary>This property defines the margin space required on the bottom edge of the item.</summary>
		/// <value>The top edge margin space (negative values are allowed).</value>
		/// <remarks>The default value for this property is 0.</remarks>
		public double MarginBottom { get; set; } = 0f;

		/// <summary>This property defines the margin space required on the left edge of the item.</summary>
		/// <value>The top edge margin space (negative values are allowed).</value>
		/// <remarks>The default value for this property is 0.</remarks>
		public double MarginLeft { get; set; } = 0f;

		/// <summary>This property defines the margin space required on the right edge of the item.</summary>
		/// <value>The top edge margin space (negative values are allowed).</value>
		/// <remarks>The default value for this property is 0.</remarks>
		public double MarginRight { get; set; } = 0f;

		/// <summary>This property defines the margin space required on the top edge of the item.</summary>
		/// <value>The top edge margin space (negative values are allowed).</value>
		/// <remarks>The default value for this property is 0.</remarks>
		public double MarginTop { get; set; } = 0f;

		int order;

		/// <summary>This property specifies whether this item should be laid out before or after other items in the container.Items are laid out based on the ascending value of this property.Items that have the same value for this property will be laid out in the order they were inserted.</summary>
		/// <value>The item order (can be a negative, 0, or positive value).</value>
		/// <remarks>The default value for this property is 0.</remarks>
		public int Order
		{
			get => order;
			set
			{
				if ((order = value) != 0 && Parent != null)
					Parent.ShouldOrderChildren = true;
			}
		}

		/// <summary>This property defines the height of the item's bottom edge padding space that should be used when laying out child items.</summary>
		/// <value>The bottom edge padding space.Negative values are not allowed.</value>
		public double PaddingBottom { get; set; } = 0f;

		/// <summary>This property defines the height of the item's left edge padding space that should be used when laying out child items.</summary>
		/// <value>The bottom edge padding space.Negative values are not allowed.</value>
		public double PaddingLeft { get; set; } = 0f;

		/// <summary>This property defines the height of the item's right edge padding space that should be used when laying out child items.</summary>
		/// <value>The bottom edge padding space.Negative values are not allowed.</value>
		public double PaddingRight { get; set; } = 0f;

		/// <summary>This property defines the height of the item's top edge padding space that should be used when laying out child items.</summary>
		/// <value>The bottom edge padding space.Negative values are not allowed.</value>
		public double PaddingTop { get; set; } = 0f;

		/// <summary>This property defines whether the item should be positioned by the flexbox rules of the layout engine(Relative) or have an absolute fixed position (Absolute). If this property is set to Absolute, the<see cref="P:Bc3.Flex.Item.Left" />, <see cref = "P:Bc3.Flex.Item.Right" />, <see cref = "P:Bc3.Flex.Item.Top" /> and <see cref= "P:Bc3.Flex.Item.Bottom" /> properties will then be used to determine the item's fixed position in its container.</summary>
		/// <value>Any value part of the<see cref="T:Bc3.Flex.Position" /> enumeration.</value>
		/// <remarks>The default value for this property is Relative</remarks>
		public Position Position { get; set; } = Position.Relative;

		/// <summary>This property defines the right edge absolute position of the item.It also defines the item's width if <see cref="P:Bc3.Flex.Item.Left" /> is also set and if <see cref="P:Bc3.Flex.Item.Width" /> isn't set.It is ignored if <see cref = "P:Bc3.Flex.Item.Position" /> isn't set to Absolute.</summary>
		/// <value>The value for the property.</value>
		/// <remarks>The default value for this property is NaN.</remarks>
		public double Right { get; set; } = double.NaN;

		/// <summary>This property defines the shrink factor of the item.In case the child items overflow the main-axis of the container, this factor will be used to determine how individual items should shrink so that all items can fill inside the container.If this property is set to 0, the item will not shrink.</summary>
		/// <value>The item shrink factor.</value>
		/// <remarks>The default value for this property is 1 (all items will shrink equally).</remarks>
		public double Shrink { get; set; } = 1f;

		/// <summary>This property defines the top edge absolute position of the item. It also defines the item's height if <see cref="P:Bc3.Flex.Item.Bottom" /> is also set and if <see cref="P:Bc3.Flex.Item.Height" /> isn't set. It is ignored if <see cref="P:Bc3.Flex.Item.Position" /> isn't set to Absolute.</summary>
		/// <value>The value for the property.</value>
		/// <remarks>The default value for this property is NaN.</remarks>
		public double Top { get; set; } = double.NaN;

		/// <summary>This property defines the width size dimension of the item.</summary>
		/// <value>The width size dimension.</value>
		/// <remarks>The default value for this property is NaN.</remarks>
		public double Width { get; set; } = double.NaN;

		/// <summary>This property defines whether child items should be laid out in a single line(NoWrap) or multiple lines(Wrap or WrapReverse). If this property is set to Wrap or WrapReverse, <see cref = "P:Bc3.Flex.Item.AlignContent" /> can then be used to specify how the lines should be distributed.</summary>
		/// <value>Any value part of the<see cref="T:Bc3.Flex.Wrap" /> enumeration.</value>
		/// <remarks>The default value for this property is NoWrap.</remarks>
		public Wrap Wrap { get; set; } = Wrap.NoWrap;
        #endregion


        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Bc3.Flex.Item"/> class.
        /// </summary>
        public Item()
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Bc3.Flex.Item"/> class.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public Item(double width, double height)
		{
			Width = width;
			Height = height;
		}
        #endregion


        #region IList
        public void Add(Item child)
		{
			ValidateChild(child);
			(Children ?? (Children = new List<Item>())).Add(child);
			child.Parent = this;
			ShouldOrderChildren |= child.Order != 0;
		}

		public void InsertAt(int index, Item child)
		{
			ValidateChild(child);
			(Children ?? (Children = new List<Item>())).Insert(index, child);
			child.Parent = this;
			ShouldOrderChildren |= child.Order != 0;
		}

		public Item RemoveAt(uint index)
		{
			var child = Children[(int)index];
			child.Parent = null;
			Children.RemoveAt((int)index);
			return child;
		}

		public int Count =>
			(Children?.Count ?? 0);

		public Item ItemAt(int index) =>
			Children?[index];

		public Item this[int index]
		{
			get => ItemAt(index);
		}
        #endregion


        #region Layout

        public Item Root
		{
			get
			{
				var root = this;
				while (root.Parent != null)
					root = root.Parent;
				return root;
			}
		}

		public void Layout()
		{
			if (Parent != null)
				throw new InvalidOperationException("Layout() must be called on a root item (that hasn't been added to another item)");
			if (Double.IsNaN(Width) || Double.IsNaN(Height))
				throw new InvalidOperationException("Layout() must be called on an item that has proper values for the Width and Height properties");
			if (SelfSizing != null)
				throw new InvalidOperationException("Layout() cannot be called on an item that has the SelfSizing property set");
            //System.Diagnostics.Debug.WriteLine(Global.DebugIndent(1) + GetType() + ".Layout layout_item(this) ENTER");
			layout_item(this, Width, Height);
			//System.Diagnostics.Debug.WriteLine(Global.DebugIndent(-1) + GetType() + ".Layout layout_item(this) EXIT");
		}

		public delegate void SelfSizingDelegate(Item item, ref double width, ref double height);

		public SelfSizingDelegate SelfSizing { get; set; }

		IEnumerator IEnumerable.GetEnumerator() =>
			((IEnumerable<Item>)this).GetEnumerator();

		IEnumerator<Item> IEnumerable<Item>.GetEnumerator() =>
			(Children ?? System.Linq.Enumerable.Empty<Item>()).GetEnumerator();

		void ValidateChild(Item child)
		{
			if (this == child)
				throw new ArgumentException("cannot add item into self");
			if (child.Parent != null)
				throw new ArgumentException("child already has a parent");
		}

		static void layout_item(Item item, double width, double height)
		{

			if (item.Children == null || item.Children.Count == 0)
				return;

			System.Diagnostics.Debug.WriteLine(Global.DebugIndent(1) + "Flex.layoutItem(item, " + width + ", " + height + ") item.Count=["+item.Count+"] ENTER");

			var layout = new flex_layout();
			layout.init(item, width, height);
			layout.reset();

			int last_layout_child = 0;
			int relative_children_count = 0;

			System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + "pos_i:" + layout.frame_pos_i + "  pos2_i:" + layout.frame_pos2_i + "  size_i:" + layout.frame_size_i + "  size2_i:" + layout.frame_size2_i);

			for (int i = 0; i < item.Count; i++)
			{
				System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + "=============================== i=[" + i + "] ENTER");
				var child = layout.child_at(item, i);
				if (!child.IsVisible) continue;

				// Items with an absolute position have their frames determined
				// directly and are skipped during layout.
				if (child.Position == Position.Absolute)
				{
					child.Frame[2] = absolute_size(child.Width, child.Left, child.Right, width);
					child.Frame[3] = absolute_size(child.Height, child.Top, child.Bottom, height);
					child.Frame[0] = absolute_pos(child.Left, child.Right, child.Frame[2], width);
					child.Frame[1] = absolute_pos(child.Top, child.Bottom, child.Frame[3], height);


                    System.Diagnostics.Debug.WriteLine(Global.DebugIndent(1) + $"Flex.layoutItem layout_item(child) ENTER - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");
					// Now that the item has a frame, we can layout its children.
					layout_item(child, child.Frame[2], child.Frame[3]);
					System.Diagnostics.Debug.WriteLine(Global.DebugIndent(-1) + "Flex.layoutItem layout_item(child) EXIT");
					continue;
				}

				// Initialize frame.
				child.Frame[0] = 0;
				child.Frame[1] = 0;
				child.Frame[2] = child.Width + child.MarginThickness(false);
				child.Frame[3] = child.Height + child.MarginThickness(true);
				System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem    A - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");

				// Main axis size defaults to 0.
				if (double.IsNaN(child.Frame[layout.frame_size_i]))
				{
					child.Frame[layout.frame_size_i] = 0;
					System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem    B - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");
				}

				// Cross axis size defaults to the parent's size (or line size in wrap
				// mode, which is calculated later on).
				if (double.IsNaN(child.Frame[layout.frame_size2_i]))
				{
					if (layout.wrap)
						layout.need_lines = true;
					else
					{
						child.Frame[layout.frame_size2_i] = (layout.vertical ? width : height) - child.MarginThickness(!layout.vertical);
						System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem    C - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");
					}
				}

				// Call the self_sizing callback if provided. Only non-NAN values
				// are taken into account. If the item's cross-axis align property
				// is set to stretch, ignore the value returned by the callback.
				if (child.SelfSizing != null)
				{
					double[] size = { child.Frame[2], child.Frame[3] };

                    System.Diagnostics.Debug.WriteLine(Global.DebugIndent(1) + $"Flex.LayoutItem child.SelfSizing ENTER FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}] index: " + i);
					child.SelfSizing(child, ref size[0], ref size[1]);
					System.Diagnostics.Debug.WriteLine(Global.DebugIndent(-1) + $"Flex.LayoutItem child.SelfSizing EXIT FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}] size[{size[0]}, {size[1]}] index: " + i);

					for (int j = 0; j < 2; j++)
					{
						int size_off = j + 2;
						System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + "Flex.LayoutItem size_off[" + size_off + "] layout.frame_size2_i[" + layout.frame_size2_i + "]     PARENT[" + item.AlignItems + "]     CHILD[" + child.AlignSelf + "]   child_align:["+ child_align(child, item) + "]");
						if (size_off == layout.frame_size2_i && child_align(child, item) == AlignItems.Stretch)
						{
							//child.Frame[size_off] = double.NaN;
							continue;
						}
						double val = size[j];
						if (!double.IsNaN(val))
						{
							child.Frame[size_off] = val;
							System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem    D - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");
						}
					}
				}

				// Honor the `basis' property which overrides the main-axis size.
				if (!child.Basis.IsAuto)
				{
					if (child.Basis.Length < 0) throw new Exception("basis should >=0");
					if (child.Basis.IsRelative && child.Basis.Length > 1) throw new Exception("relative basis should be <=1");
					double basis = child.Basis.Length;
					if (child.Basis.IsRelative)
						basis *= (layout.vertical ? height : width);
					child.Frame[layout.frame_size_i] = basis - child.MarginThickness(layout.vertical);
					System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem    E - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");
				}

				double child_size = child.Frame[layout.frame_size_i];
				System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem child_size:{child_size}  layout.flex_dim:{layout.flex_dim}");
				if (layout.wrap)
				{
					System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem layout.wrap");
					if (layout.flex_dim < child_size)
					{
						System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem layout.flex_dim < child_size");
						// Not enough space for this child on this line, layout the
						// remaining items and move it to a new line.
						layout_items(item, last_layout_child, i, relative_children_count, ref layout);

						layout.reset();
						last_layout_child = i;
						relative_children_count = 0;
					}

					double child_size2 = child.Frame[layout.frame_size2_i];
					System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem child_size2: {child_size2}");
					if (!double.IsNaN(child_size2) && child_size2 + child.MarginThickness(!layout.vertical) > layout.line_dim)
					{
						layout.line_dim = child_size2 + child.MarginThickness(!layout.vertical);
						System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem layout.line_dim: {layout.line_dim}");
					}
				}

				if (child.Grow < 0
					|| child.Shrink < 0)
					throw new Exception("shrink and grow should be >= 0");

				layout.flex_grows += child.Grow;
				layout.flex_shrinks += child.Shrink;

				layout.flex_dim -= child_size + child.MarginThickness(layout.vertical);

				relative_children_count++;

				if (child_size > 0 && child.Grow > 0)
				{
					layout.extra_flex_dim += child_size;
				}
			}

			// Layout remaining items in wrap mode, or everything otherwise.
			layout_items(item, last_layout_child, item.Count, relative_children_count, ref layout);

			// In wrap mode we may need to tweak the position of each line according to
			// the align_content property as well as the cross-axis size of items that
			// haven't been set yet.
			if (layout.need_lines && (layout.lines?.Length ?? 0) > 0)
			{
				double pos = 0;
				double spacing = 0;
				double flex_dim = layout.align_dim - layout.lines_sizes;

				if (flex_dim > 0)
				{
					layout_align(item.AlignContent, flex_dim, (uint)(layout.lines?.Length ?? 0), ref pos, ref spacing);
					System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem pos:{pos}    spacing:{spacing}");
				}

				double old_pos = 0;
				if (layout.reverse2)
				{
					pos = layout.align_dim - pos;
					old_pos = layout.align_dim;
				}

				for (uint i = 0; i < (layout.lines?.Length ?? 0); i++)
				{

					flex_layout.flex_layout_line line = layout.lines[i];

					if (layout.reverse2)
					{
						pos -= line.size;
						pos -= spacing;
						old_pos -= line.size;
					}

					// Re-position the children of this line, honoring any child
					// alignment previously set within the line.
					for (int j = line.child_begin; j < line.child_end; j++)
					{
						Item child = layout.child_at(item, j);
						if (child.Position == Position.Absolute)
						{
							// Should not be re-positioned.
							continue;
						}
						if (double.IsNaN(child.Frame[layout.frame_size2_i])) // || (child.Frame[layout.frame_size2_i] == 0 && child.Frame[layout.frame_size_i] > 0))
						{
							// If the child's cross axis size hasn't been set it, it
							// defaults to the line size.
							child.Frame[layout.frame_size2_i] = line.size
								+ (item.AlignContent == AlignContent.Stretch
								   ? spacing : 0);
							System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem  spacing:{spacing}   F - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");
						}
						child.Frame[layout.frame_pos2_i] = pos + (child.Frame[layout.frame_pos2_i] - old_pos);
						System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItem    G - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");
					}

					if (!layout.reverse2)
					{
						pos += line.size;
						pos += spacing;
						old_pos += line.size;
					}
				}
			}

			layout.cleanup();

			System.Diagnostics.Debug.WriteLine(Global.DebugIndent(-1) + "Flex.layoutItem(item, " + width + ", " + height + ") item.Count=[" + item.Count + "] EXIT");

		}

		double MarginThickness(bool vertical) =>
			vertical ? MarginTop + MarginBottom : MarginLeft + MarginRight;

		static void layout_align(Justify align, double flex_dim, int children_count, ref double pos_p, ref double spacing_p)
		{
			if (flex_dim < 0)
				throw new ArgumentException();
			pos_p = 0;
			spacing_p = 0;

			switch (align)
			{
				case Justify.Start:
					return;
				case Justify.End:
					pos_p = flex_dim;
					return;
				case Justify.Center:
					pos_p = flex_dim / 2;
					return;
				case Justify.SpaceBetween:
					if (children_count > 0)
						spacing_p = flex_dim / (children_count - 1);
					return;
				case Justify.SpaceAround:
					if (children_count > 0)
					{
						spacing_p = flex_dim / children_count;
						pos_p = spacing_p / 2;
					}
					return;
				case Justify.SpaceEvenly:
					if (children_count > 0)
					{
						spacing_p = flex_dim / (children_count + 1);
						pos_p = spacing_p;
					}
					return;
				default:
					throw new ArgumentException();
			}
		}

		static void layout_align(AlignContent align, double flex_dim, uint children_count, ref double pos_p, ref double spacing_p)
		{
			if (flex_dim < 0)
				throw new ArgumentException();
			pos_p = 0;
			spacing_p = 0;

			switch (align)
			{
				case AlignContent.Start:
					return;
				case AlignContent.End:
					pos_p = flex_dim;
					return;
				case AlignContent.Center:
					pos_p = flex_dim / 2;
					return;
				case AlignContent.SpaceBetween:
					if (children_count > 0)
						spacing_p = flex_dim / (children_count - 1);
					return;
				case AlignContent.SpaceAround:
					if (children_count > 0)
					{
						spacing_p = flex_dim / children_count;
						pos_p = spacing_p / 2;
					}
					return;
				case AlignContent.SpaceEvenly:
					if (children_count > 0)
					{
						spacing_p = flex_dim / (children_count + 1);
						pos_p = spacing_p;
					}
					return;
				case AlignContent.Stretch:
					spacing_p = flex_dim / children_count;
					return;
				default:
					throw new ArgumentException();
			}
		}

		static void layout_items(Item item, int child_begin, int child_end, int children_count, ref flex_layout layout)
		{

			if (children_count > (child_end - child_begin))
				throw new ArgumentException();
			if (children_count <= 0)
				return;

			System.Diagnostics.Debug.WriteLine(Global.DebugIndent(+1) + "Flex.layout_items(item, " + child_begin + ", " + child_end + ", "+children_count+") item.Count=[" + item.Count + "] ENTER");


			if (layout.flex_dim > 0 && layout.extra_flex_dim > 0)
			{
				// If the container has a positive flexible space, let's add to it
				// the sizes of all flexible children.
				layout.flex_dim += layout.extra_flex_dim;
			}

			// Determine the main axis initial position and optional spacing.
			double pos = 0;
			double spacing = 0;
			if (layout.flex_grows == 0 && layout.flex_dim > 0)
			{
				layout_align(item.JustifyContent, layout.flex_dim, children_count, ref pos, ref spacing);
			}

			if (layout.reverse)
				pos = layout.size_dim - pos;


			if (layout.reverse)
			{
				pos -= layout.vertical ? item.PaddingBottom : item.PaddingRight;
			}
			else
			{
				pos += layout.vertical ? item.PaddingTop : item.PaddingLeft;
			}
			if (layout.wrap && layout.reverse2)
			{
				layout.pos2 -= layout.line_dim;
			}

			for (int i = child_begin; i < child_end; i++)
			{
				System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + "Flex.layout_items i=["+i+"]");

				Item child = layout.child_at(item, i);
				if (!child.IsVisible) continue;
				if (child.Position == Position.Absolute)
				{
					// Already positioned.
					continue;
				}

				// Grow or shrink the main axis item size if needed.
				double flex_size = 0;
				if (layout.flex_dim > 0)
				{
					if (child.Grow != 0)
					{
						child.Frame[layout.frame_size_i] = 0; // Ignore previous size when growing.
						flex_size = (layout.flex_dim / layout.flex_grows) * child.Grow;
					}
				}
				else if (layout.flex_dim < 0)
				{
					if (child.Shrink != 0)
					{
						flex_size = (layout.flex_dim / layout.flex_shrinks) * child.Shrink;
					}
				}
				child.Frame[layout.frame_size_i] += flex_size;
				System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + "Flex.layout_items  **1**   i=["+i+"] child.Frame=[" + string.Join(",", child.Frame) + "]");

				// Set the cross axis position (and stretch the cross axis size if
				// needed).
				double align_size = child.Frame[layout.frame_size2_i];
				double align_pos = layout.pos2 + 0;
				System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"Flex.layoutItems  **2**   align_size:{align_size}  align_pos:{align_pos}");
				switch (child_align(child, item))
				{
					case AlignItems.End:
						align_pos += layout.line_dim - align_size - (layout.vertical ? child.MarginRight : child.MarginBottom);
						break;

					case AlignItems.Center:
						align_pos += (layout.line_dim / 2) - (align_size / 2)
							+ ((layout.vertical ? child.MarginLeft : child.MarginTop)
							   - (layout.vertical ? child.MarginRight : child.MarginBottom));
						break;

					case AlignItems.Stretch:
						if (align_size == 0)
						{
							System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"   Flex.layoutItems   **AlignItems.Stretch + align_size == 0**  layout.frame_size2_i:{layout.frame_size2_i}   layout.line_dim:{layout.line_dim}  layout.vertical:{layout.vertical}  child.MarginLeft:{child.MarginLeft}");
							child.Frame[layout.frame_size2_i] = layout.line_dim
								- ((layout.vertical ? child.MarginLeft : child.MarginTop)
								   + (layout.vertical ? child.MarginRight : child.MarginBottom));
							System.Diagnostics.Debug.WriteLine(Global.DebugIndent() + $"   Flex.layoutItems   **AlignItems.Stretch + align_size == 0**   - FRAME[{child.Frame[0]}, {child.Frame[1]}, {child.Frame[2]},{child.Frame[3]}]");
						}
						align_pos += (layout.vertical ? child.MarginLeft : child.MarginTop);
						break;
					case AlignItems.Start:
						align_pos += (layout.vertical ? child.MarginLeft : child.MarginTop);
						break;

					default:
						throw new Exception();
				}
				child.Frame[layout.frame_pos2_i] = align_pos;
				System.Diagnostics.Debug.WriteLine(Global.DebugIndent(0) + "Flex.layout_items  **3**   i=[" + i + "] child.Frame=[" + string.Join(",", child.Frame) + "]");

				// Set the main axis position.
				if (layout.reverse)
				{
					pos -= (layout.vertical ? child.MarginBottom : child.MarginRight);
					pos -= child.Frame[layout.frame_size_i];
					child.Frame[layout.frame_pos_i] = pos;
					pos -= spacing;
					pos -= (layout.vertical ? child.MarginTop : child.MarginLeft);
				}
				else
				{
					pos += (layout.vertical ? child.MarginTop : child.MarginLeft);
					child.Frame[layout.frame_pos_i] = pos;
					pos += child.Frame[layout.frame_size_i];
					pos += spacing;
					pos += (layout.vertical ? child.MarginBottom : child.MarginRight);
				}
				System.Diagnostics.Debug.WriteLine(Global.DebugIndent(0) + "Flex.layout_items  **4** i=[" + i + "] child.Frame=[" + string.Join(",",child.Frame) + "]");

				//System.Diagnostics.Debug.WriteLine(Global.DebugIndent(1) + "Flex.layoutItem layout_items() ENTER");
				// Now that the item has a frame, we can layout its children.
				layout_item(child, child.Frame[2], child.Frame[3]);
				//System.Diagnostics.Debug.WriteLine(Global.DebugIndent(-1) + "Flex.layoutItem layout_items() EXIT");
			}

			if (layout.wrap && !layout.reverse2)
			{
				layout.pos2 += layout.line_dim;
			}

			if (layout.need_lines)
			{
				Array.Resize(ref layout.lines, (layout.lines?.Length ?? 0) + 1);

				ref flex_layout.flex_layout_line line = ref layout.lines[layout.lines.Length - 1];

				line.child_begin = child_begin;
				line.child_end = child_end;
				line.size = layout.line_dim;

				layout.lines_sizes += line.size;
			}
			System.Diagnostics.Debug.WriteLine(Global.DebugIndent(-1) + "Flex.layout_items(item, " + child_begin + ", " + child_end + ", " + children_count + ") item.Count=[" + item.Count + "] EXIT");
		}

		static double absolute_size(double val, double pos1, double pos2, double dim) =>
			!double.IsNaN(val) ? val : (!double.IsNaN(pos1) && !double.IsNaN(pos2) ? dim - pos2 - pos1 : 0);

		static double absolute_pos(double pos1, double pos2, double size, double dim) =>
			!double.IsNaN(pos1) ? pos1 : (!double.IsNaN(pos2) ? dim - size - pos2 : 0);

		static AlignItems child_align(Item child, Item parent) =>
			child.AlignSelf == AlignSelf.Auto ? parent.AlignItems : (AlignItems)child.AlignSelf;

		struct flex_layout
		{
			// Set during init.
			public bool wrap;
			public bool reverse;                // whether main axis is reversed
			public bool reverse2;               // whether cross axis is reversed (wrap only)
			public bool vertical;
			public double size_dim;              // main axis parent size
			public double align_dim;             // cross axis parent size
			public uint frame_pos_i;            // main axis position
			public uint frame_pos2_i;           // cross axis position
			public uint frame_size_i;           // main axis size
			public uint frame_size2_i;          // cross axis size
			int[] ordered_indices;

			// Set for each line layout.
			public double line_dim;              // the cross axis size
			public double flex_dim;              // the flexible part of the main axis size
			public double extra_flex_dim;        // sizes of flexible items
			public double flex_grows;
			public double flex_shrinks;
			public double pos2;                  // cross axis position

			// Calculated layout lines - only tracked when needed:
			//   - if the root's align_content property isn't set to FLEX_ALIGN_START
			//   - or if any child item doesn't have a cross-axis size set
			public bool need_lines;
			public struct flex_layout_line
			{
				public int child_begin;
				public int child_end;
				public double size;
			};

			public flex_layout_line[] lines;
			public double lines_sizes;

			//LAYOUT_RESET
			public void reset()
			{
				line_dim = wrap ? 0 : align_dim;
				flex_dim = size_dim;
				extra_flex_dim = 0;
				flex_grows = 0;
				flex_shrinks = 0;
			}

			//layout_init
			public void init(Item item, double width, double height)
			{
				if (item.PaddingLeft < 0
					|| item.PaddingRight < 0
					|| item.PaddingTop < 0
					|| item.PaddingBottom < 0)
					throw new ArgumentException();

				width = Math.Max(0, width - item.PaddingLeft + item.PaddingRight);
				height = Math.Max(0, height - item.PaddingTop + item.PaddingBottom);

				reverse = item.Direction == Direction.RowReverse || item.Direction == Direction.ColumnReverse;
				vertical = true;
				switch (item.Direction)
				{
					case Direction.Row:
					case Direction.RowReverse:
						vertical = false;
						size_dim = width;
						align_dim = height;
						frame_pos_i = 0;
						frame_pos2_i = 1;
						frame_size_i = 2;
						frame_size2_i = 3;
						break;
					case Direction.Column:
					case Direction.ColumnReverse:
						size_dim = height;
						align_dim = width;
						frame_pos_i = 1;
						frame_pos2_i = 0;
						frame_size_i = 3;
						frame_size2_i = 2;
						break;
				}

				ordered_indices = null;
				if (item.ShouldOrderChildren && item.Count > 0)
				{
					var indices = new int[item.Count];
					// Creating a list of item indices sorted using the children's `order'
					// attribute values. We are using a simple insertion sort as we need
					// stability (insertion order must be preserved) and cross-platform
					// support. We should eventually switch to merge sort (or something
					// else) if the number of items becomes significant enough.
					for (int i = 0; i < item.Count; i++)
					{
						indices[i] = i;
						for (int j = i; j > 0; j--)
						{
							int prev = indices[j - 1];
							int curr = indices[j];
							if (item.Children[prev].Order <= item.Children[curr].Order)
							{
								break;
							}
							indices[j - 1] = curr;
							indices[j] = prev;
						}
					}
					ordered_indices = indices;
				}

				flex_dim = 0;
				flex_grows = 0;
				flex_shrinks = 0;

				reverse2 = false;
				wrap = item.Wrap != Wrap.NoWrap;
				if (wrap)
				{
					if (item.Wrap == Wrap.WrapReverse)
					{
						reverse2 = true;
						pos2 = align_dim;
					}
				}
				else
				{
					pos2 = vertical ? item.PaddingLeft : item.PaddingTop;
				}

				need_lines = wrap && item.AlignContent != AlignContent.Start;
				lines = null;
				lines_sizes = 0;
			}

			public Item child_at(Item item, int i) =>
				item.Children[(ordered_indices?[i] ?? i)];

			public void cleanup()
			{
				ordered_indices = null;
				lines = null;
			}
		}

        #endregion
    }
}