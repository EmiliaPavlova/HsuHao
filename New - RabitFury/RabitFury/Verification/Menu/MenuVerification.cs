namespace RabitFury.Verification.Menu
{
    using System;

    using Enums;

    public static class MenuVerification
    {
        public static void ButtonStateTypeVerification(int index)
        {
            if (index != (int)ButtonStateType.Normal &&
                index != (int)ButtonStateType.Hovered &&
                index != (int)ButtonStateType.Clicked &&
                index != (int)ButtonStateType.Locked)
            {
                throw new IndexOutOfRangeException("Button state index cannot be less than '0' and more than '3'");
            }
        }
    }
}
