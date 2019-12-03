using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace REvernus.Utilities
{
    public class KeysHelper
    {
        public static System.Windows.Forms.KeyEventArgs ToWinforms(System.Windows.Input.KeyEventArgs keyEventArgs)
        {
            var wpfKey = keyEventArgs.Key == System.Windows.Input.Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;
            var winformModifiers = ToWinforms(keyEventArgs.KeyboardDevice.Modifiers);
            var winformKeys = (System.Windows.Forms.Keys)System.Windows.Input.KeyInterop.VirtualKeyFromKey(wpfKey);
            return new System.Windows.Forms.KeyEventArgs(winformKeys | winformModifiers);
        }

        public static System.Windows.Forms.Keys ToWinforms(System.Windows.Input.ModifierKeys modifier)
        {
            var retVal = System.Windows.Forms.Keys.None;
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.Alt))
            {
                retVal |= System.Windows.Forms.Keys.Alt;
            }
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.Control))
            {
                retVal |= System.Windows.Forms.Keys.Control;
            }
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.None))
            {
                retVal |= System.Windows.Forms.Keys.None;
            }
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.Shift))
            {
                retVal |= System.Windows.Forms.Keys.Shift;
            }
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.Windows))
            {
            }
            return retVal;
        }

    }
}
