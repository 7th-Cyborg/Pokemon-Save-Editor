/*
	Pokemon Save Editor
    Copyright (C) 7th Cyborg

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon_Save_Editor
{
    static class Hexadecimal
    {
        /// <summary>
        /// Konvertira byte-ove u hexadecimalni string
        /// </summary>
        /// <param name="bytes">byte-ovi koje zelimo konvertirati</param>
        /// <returns>vraca konvertirani string</returns>
        public static string BytesToHexString(byte[] bytes)
        {
            string str = "";
            foreach (byte b in bytes)
            {
                str += b.ToString("X2");
            }
            return str;
        }

        /// <summary>
        /// Konvertira hexString nazad u byteove
        /// </summary>
        /// <param name="hexString">string</param>
        /// <returns>vraca array byteova</returns>
        public static byte[] HexStringToBytes(string hexString)
        {
            byte[] bytes = new byte[hexString.Length >> 1];//dijeljeno length sa 2

            for (int i = 0; i < hexString.Length >> 1; ++i)
            {
                bytes[i] = (byte)((GetHexVal(hexString[i << 1]) << 4) + (GetHexVal(hexString[(i << 1) + 1])));
            }

            return bytes;

        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex; 
            return val - (val < 58 ? 48 : 55);
        }

    }
}
