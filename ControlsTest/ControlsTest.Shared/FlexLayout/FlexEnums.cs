using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Bc3.Forms
{
	[TypeConverter(typeof(FlexJustifyTypeConverter))]
	public enum FlexJustify
	{
		Start = Flex.Justify.Start,
		Center = Flex.Justify.Center,
		End = Flex.Justify.End,
		SpaceBetween = Flex.Justify.SpaceBetween,
		SpaceAround = Flex.Justify.SpaceAround,
		SpaceEvenly = Flex.Justify.SpaceEvenly,
	}

	//[Xaml.TypeConversion(typeof(FlexJustify))]
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

	public enum FlexPosition
	{
		Relative = Flex.Position.Relative,
		Absolute = Flex.Position.Absolute,
	}

	[TypeConverter(typeof(FlexDirectionTypeConverter))]
	public enum FlexDirection
	{
		Column = Flex.Direction.Column,
		ColumnReverse = Flex.Direction.ColumnReverse,
		Row = Flex.Direction.Row,
		RowReverse = Flex.Direction.RowReverse,
	}

	//[Xaml.TypeConversion(typeof(FlexDirection))]
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
	public enum FlexAlignContent
	{
		Stretch = Flex.AlignContent.Stretch,
		Center = Flex.AlignContent.Center,
		Start = Flex.AlignContent.Start,
		End = Flex.AlignContent.End,
		SpaceBetween = Flex.AlignContent.SpaceBetween,
		SpaceAround = Flex.AlignContent.SpaceAround,
		SpaceEvenly = Flex.AlignContent.SpaceEvenly,
	}

	//[Xaml.TypeConversion(typeof(FlexAlignContent))]
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
	public enum FlexAlignItems
	{
		Stretch = Flex.AlignItems.Stretch,
		Center = Flex.AlignItems.Center,
		Start = Flex.AlignItems.Start,
		End = Flex.AlignItems.End,
		//Baseline = Flex.AlignItems.Baseline,
	}

	//[Xaml.TypeConversion(typeof(FlexAlignItems))]
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
	public enum FlexAlignSelf
	{
		Auto = Flex.AlignSelf.Auto,
		Stretch = Flex.AlignSelf.Stretch,
		Center = Flex.AlignSelf.Center,
		Start = Flex.AlignSelf.Start,
		End = Flex.AlignSelf.End,
		//Baseline = Flex.AlignSelf.Baseline,
	}

	//[Xaml.TypeConversion(typeof(FlexAlignSelf))]
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
	public enum FlexWrap
	{
		NoWrap = Flex.Wrap.NoWrap,
		Wrap = Flex.Wrap.Wrap,
		Reverse = Flex.Wrap.WrapReverse,
	}

	//[Xaml.TypeConversion(typeof(FlexWrap))]
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

	//[TypeConverter(typeof(FlexBasisTypeConverter))]
	public struct FlexBasis
	{
		bool _isLength;
		bool _isRelative;
		public static FlexBasis Auto = new FlexBasis();
		public double Length { get; }
		internal bool IsAuto => !_isLength && !_isRelative;
		internal bool IsRelative => _isRelative;
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

		public static implicit operator FlexBasis(double length)
		{
			return new FlexBasis(length);
		}

		public static implicit operator FlexBasis(string value)
			=> Parse(value);
        //[Xaml.TypeConversion(typeof(FlexBasis))]

        public override string ToString()
        {
			if (IsAuto)
				return "auto";
			var result = Length.ToString();
			if (IsRelative)
				result += "," + "relative";
			return result;
		}

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
