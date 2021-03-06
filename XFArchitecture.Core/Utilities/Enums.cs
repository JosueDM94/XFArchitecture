﻿using System;

namespace XFArchitecture.Core.Utilities
{
    public enum DeviceType
    {
        IOS = 0,
        DROID = 1
    }

    public enum GenderType
    {
        Male = 0,
        Female = 1
    }

    public enum FontAwesomeType
    {
        Solid = 0,
        Brands = 1,
        Regular = 2
    }

    public enum NavigationBarStyle
    {
        MenuBar = 0,
        BackBar = 1,
        TitleBar = 2,
        SearchBar = 3,
        CustomBar = 4
    }

    public enum RightButtons
    {
        None = 0,
        One = 1,
        Two = 2
    }

    public enum ErrorType
    {
        Error = 0,
        Sucess =1,
        Warning = 2,
        Information = 3
    }

    public enum PriorityType
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}