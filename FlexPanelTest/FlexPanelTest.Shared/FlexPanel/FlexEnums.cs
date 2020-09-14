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
using System.ComponentModel;
using System.Globalization;

namespace Microsoft.Toolkit.Uwp.UI.Controls
{
    [TypeConverter(typeof(FlexJustifyTypeConverter))]
	/// <summary>
	/// Values for <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.Justify" />.
	/// </summary>
	public enum FlexJustify
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
	/// String to FlexJustify TypeConverter
	/// </summary>
	public class FlexJustifyTypeConverter : TypeConverter
	{
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
			if (sourceType == typeof(string))
				return true; 
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
			if (value is string stringValue)
			{
				if (Enum.TryParse(stringValue, true, out FlexJustify justify))
					return justify;
				if (stringValue.Equals("flex-start", StringComparison.OrdinalIgnoreCase))
					return FlexJustify.Start;
				if (stringValue.Equals("flex-end", StringComparison.OrdinalIgnoreCase))
					return FlexJustify.End;
				if (stringValue.Equals("space-between", StringComparison.OrdinalIgnoreCase))
					return FlexJustify.SpaceBetween;
				if (stringValue.Equals("space-around", StringComparison.OrdinalIgnoreCase))
					return FlexJustify.SpaceAround;
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FlexJustify)));
		}
	}



    /// <summary>
	/// Not implemented at this time
    /// Values for <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.Position" />.
    /// </summary>
    enum FlexPosition
	{
		/// <summary>
		/// Whether the elements's frame will be determined by the flex rules of the layout system.
		/// </summary>
		Relative = 0,
		/// <summary>
		/// Whether the elements's frame will be determined by fixed position values (<see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.Left" />, <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.Right" />, <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.Top" /> and <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.Bottom" />).
		/// </summary>
		Absolute = 1,
	}

	[TypeConverter(typeof(FlexDirectionTypeConverter))]
	/// <summary>
	/// Values for <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.Direction" />.
	/// </summary>
	public enum FlexDirection
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
	/// String to FlexDirection type converter
	/// </summary>
	public class FlexDirectionTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string stringValue)
			{
				if (Enum.TryParse(stringValue, true, out FlexDirection aligncontent))
					return aligncontent;
				if (stringValue.Equals("row-reverse", StringComparison.OrdinalIgnoreCase))
					return FlexDirection.RowReverse;
				if (stringValue.Equals("column-reverse", StringComparison.OrdinalIgnoreCase))
					return FlexDirection.ColumnReverse;
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FlexDirection)));
		}
	}



    [TypeConverter(typeof(FlexAlignContentTypeConverter))]
	/// <summary>
	/// Values for <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.AlignContent" />.
	/// </summary>
	public enum FlexAlignContent
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
	/// String to FlexAlignContent TypeConverter
	/// </summary>
	public class FlexAlignContentTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string stringValue)
			{
				if (Enum.TryParse(stringValue, true, out FlexAlignContent aligncontent))
					return aligncontent;
				if (stringValue.Equals("flex-start", StringComparison.OrdinalIgnoreCase))
					return FlexAlignContent.Start;
				if (stringValue.Equals("flex-end", StringComparison.OrdinalIgnoreCase))
					return FlexAlignContent.End;
				if (stringValue.Equals("space-between", StringComparison.OrdinalIgnoreCase))
					return FlexAlignContent.SpaceBetween;
				if (stringValue.Equals("space-around", StringComparison.OrdinalIgnoreCase))
					return FlexAlignContent.SpaceAround;
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FlexAlignContent)));
		}
	}



    [TypeConverter(typeof(FlexAlignItemsTypeConverter))]
	/// <summary>
	/// Values for <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.AlignItems" />.
	/// </summary>
	public enum FlexAlignItems
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
	/// String to FlexAlignItems type converter
	/// </summary>
	public class FlexAlignItemsTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string stringValue)
			{
				if (Enum.TryParse(stringValue, true, out FlexAlignItems alignitems))
					return alignitems;
				if (stringValue.Equals("flex-start", StringComparison.OrdinalIgnoreCase))
					return FlexAlignItems.Start;
				if (stringValue.Equals("flex-end", StringComparison.OrdinalIgnoreCase))
					return FlexAlignItems.End;
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FlexAlignItems)));
		}
	}


    [TypeConverter(typeof(FlexAlignSelfTypeConverter))]
	/// <summary>
	/// Values for <see cref="P:Microsoft.Toolkit.Uwp.UI.Controls.FlexItem.AlignSelf" />.
	/// </summary>
	public enum FlexAlignSelf
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
	/// String to FlexAlignSelf TypeConverter
	/// </summary>
	public class FlexAlignSelfTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string stringValue)
			{
				if (Enum.TryParse(stringValue, true, out FlexAlignSelf alignself))
					return alignself;
				if (stringValue.Equals("flex-start", StringComparison.OrdinalIgnoreCase))
					return FlexAlignSelf.Start;
				if (stringValue.Equals("flex-end", StringComparison.OrdinalIgnoreCase))
					return FlexAlignSelf.End;
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FlexAlignSelf)));
		}
	}


    [TypeConverter(typeof(FlexWrapTypeConverter))]
	/// <summary>
	/// Values for <see cref="P:XamBc3arin.Flex.FlexItem.Wrap" />.
	/// </summary>
	public enum FlexWrap
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
		Reverse = 2,
	}

	/// <summary>
	/// String to FlexWrap type converter
	/// </summary>
	public class FlexWrapTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string stringValue)
			{
				if (Enum.TryParse(stringValue, true, out FlexWrap wrap))
					return wrap;
				if (stringValue.Equals("wrap-reverse", StringComparison.OrdinalIgnoreCase))
					return FlexWrap.Reverse;
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FlexWrap)));
		}
	}




	public struct FlexBasis
	{
		bool _isLength;
		bool _isRelative;

		/// <summary>
		/// Main-axis length of element is calculated by FlexPanel
		/// </summary>
		public static FlexBasis Auto = new FlexBasis();
		
		/// <summary>
		/// Gets the main-axis length of the element in the FlexPanel
		/// </summary>
		public double Length { get; }

		/// <summary>
		/// Whether the basis is auto.
		/// </summary>
		internal bool IsAuto => !_isLength && !_isRelative;

		/// <summary>
		/// Whether the basis length is relative to parent's size.
		/// </summary>
		internal bool IsRelative => _isRelative;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Microsoft.Toolkit.Uwp.UI.Controls.FlexBasis"/> struct.
		/// </summary>
		/// <param name="length">Length.</param>
		/// <param name="isRelative">If set to <c>true</c> is relative.</param>
		public FlexBasis(double length, bool isRelative = false)
		{
			if (length < 0)
				throw new ArgumentException("should be a positive value", nameof(length));
			if (isRelative && length > 1)
				throw new ArgumentException("relative length should be in [0, 1]", nameof(length));
			_isLength = !isRelative;
			_isRelative = isRelative;
			Length = length;
		}

		/// <summary>
		/// Converts a double to a FlexBasis
		/// </summary>
		/// <param name="length"></param>
		public static implicit operator FlexBasis(double length)
			=> new FlexBasis(length);
		
		/// <summary>
		/// Converts a string to a FlexBasis
		/// </summary>
		/// <param name="value"></param>
		public static implicit operator FlexBasis(string value)
			=> Parse(value);

		/// <summary>
		/// Converts a FlexBasis to a string
		/// </summary>
		/// <returns></returns>
        public override string ToString()
        {
			if (IsAuto)
				return "auto";
			var result = Length.ToString();
			if (IsRelative)
				result += "," + "relative";
			return result;
		}

		/// <summary>
		/// Converts a string to a FlexBasis
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static FlexBasis Parse(string value)
		{
			value = value.Trim().ToLower();
			if (value.Contains("auto"))
				return Auto;
			if (double.TryParse(value.Split(',')[0], out double length))
			{
				if (length < 0)
					return Auto;
				else
					return new FlexBasis(length, value.Contains("relative"));
			}
			return Auto;
		}


	}

	/*
	public class FlexBasisTypeConverter : TypeConverter, IValueConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string stringValue)
			{
				if (stringValue.Equals("auto", StringComparison.OrdinalIgnoreCase))
					return FlexBasis.Auto;
				stringValue = stringValue.Trim();
				if (stringValue.EndsWith("%", StringComparison.OrdinalIgnoreCase) && double.TryParse(stringValue.Substring(0, stringValue.Length - 1), NumberStyles.Number, CultureInfo.InvariantCulture, out double relflex))
					return new FlexBasis(relflex / 100, isRelative: true);
				if (double.TryParse(stringValue, NumberStyles.Number, CultureInfo.InvariantCulture, out double flex))
					return new FlexBasis(flex);
			}
			throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FlexBasis)));
		}

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return ConvertFrom(null, null, value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
	*/
}
