namespace Codeparts.NSms
{
    using System;

    [Flags]
    public enum PhoneNumberFormat
    {
        PlusSign = 1,
        Braces = 2,
        Spaces = 4
    }
}