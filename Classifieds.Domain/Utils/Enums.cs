using System;
using System.ComponentModel;

namespace Classifieds.Domain.Utils
{
    public enum ControlType
    {
        CheckBox = 0,
        TextBoxInt = 1,
        TextBoxReal = 2,
        TextBox = 3,
        DropDown = 4
    }

    public static class ControlTypeExtensions
    {
        public static string ToDescriptionString(this ControlType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}