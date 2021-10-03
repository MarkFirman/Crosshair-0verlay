using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CrosshairOverlay.Class
{
    public static class Hotkey
    {

        /// <summary>
        /// Available Keys
        /// </summary>
        public enum Key : uint
        {

            NONE = 0x0000,
            ALT = 0x0001,
            CONTROL = 0x0002,
            SHIFT = 0x0004,
            WIN = 0x0008,
            CAPITAL = 0x0014,
            PERIOD = 0x00BE,
            COMMA = 0x00BC,
            PLUS = 0x00BB,
            MINUS = 0x00BD,
            RETURN = 0x000D,
            BACK = 0x0008,
            ESCAPE = 0x001B,
            SPACE = 0x0020,
            END = 0x0023,
            HOME = 0x0024,
            INSERT = 0x002D,
            DELETE = 0x002E,

            ZERO = 0x0030,
            ONE = 0x0031,
            TWO = 0x0032,
            THREE = 0x0033,
            FOUR = 0x0034,
            FIVE = 0x0035,
            SIX = 0x0036,
            SEVEN = 0x0037,
            EIGHT = 0x0038,
            NINE = 0x0039,
            
            A = 0x0041,
            B = 0x0042,
            C = 0x0043,
            D = 0x0044,
            E = 0x0045,
            F = 0x0046,
            G = 0x0047,
            H = 0x0048,
            I = 0x0049,
            J = 0x004A,
            K = 0x004B,
            L = 0x004C,
            M = 0x004D,
            N = 0x004E,
            O = 0x004F,
            P = 0x0050,
            Q = 0x0051,
            R = 0x0052,
            S = 0x0053,
            T = 0x0054,
            U = 0x0055,
            V = 0x0056,
            W = 0x0057,
            X = 0x0058,
            Y = 0x0059,
            Z = 0x005A

        }


        // Keys
        private const uint MOD_NONE = 0x000000; // NONE/NADA/NOTHING
        private const uint MOD_ALT = 0x000001; // ALT
        private const uint MOD_CONTROL = 0x000002; // CTRL
        private const uint MOD_SHIFT = 0x000004; // SHIFT
        private const uint MOD_WIN = 0x000008; // WINDOWS
        private const uint VK_CAPITAL = 0x0014; // CAPS LOCK
        private const uint VK_OEM_PERIOD = 0x00BE; // PERIOD. FULLSTOP

        // Import required dependencies
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        /// <summary>
        /// Returns a Key
        /// </summary>
        /// <returns></returns>
        public static Key FindKeyByWindowsNum(int keycode)
        {
            Key k = Key.NONE;

            switch (keycode)
            {
                case 2:
                    k = Key.BACK;
                    break;

                case 768678:
                    k = Key.RETURN;
                    break;



                case 116:
                    k = Key.SHIFT;
                    break;
                case 118:
                    k = Key.CONTROL;
                    break;
                case 156:
                    k = Key.ALT;
                    break;
                case 8:
                    k = Key.CAPITAL;
                    break;
                case 13:
                    k = Key.ESCAPE;
                    break;

                case 32:
                    k = Key.DELETE;
                    break;

                 case 21:
                    k = Key.END;
                    break;
                case 22:
                    k = Key.HOME;
                    break;
                case 34:
                    k = Key.ZERO;
                    break;
                case 35:
                    k = Key.ONE;
                    break;
                case 36:
                    k = Key.TWO;
                    break;
                case 37:
                    k = Key.THREE;
                    break;
                case 38:
                    k = Key.FOUR;
                    break;
                case 39:
                    k = Key.FIVE;
                    break;
                case 40:
                    k = Key.SIX;
                    break;
                case 41:
                    k = Key.SEVEN;
                    break;
                case 42:
                    k = Key.EIGHT;
                    break;
                case 43:
                    k = Key.NINE;
                    break;
                case 44:
                    k = Key.A;
                    break;
                case 45:
                    k = Key.B;
                    break;
                case 46:
                    k = Key.C;
                    break;
                case 47:
                    k = Key.D;
                    break;
                case 48:
                    k = Key.E;
                    break;
                case 49:
                    k = Key.F;
                    break;
                case 50:
                    k = Key.G;
                    break;
                case 51:
                    k = Key.H;
                    break;
                case 52:
                    k = Key.I;
                    break;
                case 53:
                    k = Key.J;
                    break;
                case 54:
                    k = Key.K;
                    break;
                case 55:
                    k = Key.L;
                    break;
                case 56:
                    k = Key.M;
                    break;
                case 57:
                    k = Key.N;
                    break;
                case 58:
                    k = Key.O;
                    break;
                case 59:
                    k = Key.P;
                    break;
                case 60:
                    k = Key.Q;
                    break;
                case 61:
                    k = Key.R;
                    break;
                case 62:
                    k = Key.S;
                    break;
                case 63:
                    k = Key.T;
                    break;
                case 64:
                    k = Key.U;
                    break;
                case 65:
                    k = Key.V;
                    break;
                case 66:
                    k = Key.W;
                    break;
                case 67:
                    k = Key.X;
                    break;
                case 68:
                    k = Key.Y;
                    break;
                case 69:
                    k = Key.Z;
                    break;

                case 141:
                    k = Key.PLUS;
                    break;

                case 143:
                    k = Key.MINUS;
                    break;


                default:
                    k = Key.NONE;
                    break;

            }

            return k;

        }


    }
}
