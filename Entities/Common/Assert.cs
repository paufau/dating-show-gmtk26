using System;
using Godot;

namespace Utils
{
    public static class Assert
    {
        public static void That(bool condition, string message = "Assertion failed!")
        {
            if (!condition)
            {
                GD.PrintErr(message);
                throw new Exception(message);
            }
        }

        public static T NonNull<T>(T? value, string message = "Non nullable assertion failed!")
        {
            if (value != null)
            {
                return value;
            }

            GD.PrintErr(message);
            throw new Exception(message);
        }
    }
}
