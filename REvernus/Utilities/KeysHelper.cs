using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace REvernus.Utilities
{
    public class KeysHelper
    {
        public static KeyEventArgs ToWinforms(System.Windows.Input.KeyEventArgs keyEventArgs)
        {
            var wpfKey = keyEventArgs.Key == Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;
            var winformModifiers = ToWinforms(keyEventArgs.KeyboardDevice.Modifiers);
            var winformKeys = (Keys)KeyInterop.VirtualKeyFromKey(wpfKey);
            return new KeyEventArgs(winformKeys | winformModifiers);
        }

        public static Keys ToWinforms(ModifierKeys modifier)
        {
            var retVal = Keys.None;
            if (modifier.HasFlag(ModifierKeys.Alt)) retVal |= Keys.Alt;
            if (modifier.HasFlag(ModifierKeys.Control)) retVal |= Keys.Control;
            if (modifier.HasFlag(ModifierKeys.None)) retVal |= Keys.None;
            if (modifier.HasFlag(ModifierKeys.Shift)) retVal |= Keys.Shift;
            if (modifier.HasFlag(ModifierKeys.Windows))
            {
            }

            return retVal;
        }
    }
}