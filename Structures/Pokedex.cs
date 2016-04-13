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
using System.Collections;

namespace Pokemon_Save_Editor.Structures
{
    class Pokedex
    {
        /// <summary>
        /// Sadrzi bitove od pokemona koji su videni
        /// </summary>
        public BitArray pokedexSeen { get; set; }
        /// <summary>
        /// Sadrzi bitove od pokemona koji su uhvaceni
        /// </summary>
        public BitArray pokedexOwn { get; set; }

        #region Load
        /// <summary>
        /// Ucitava byte array od pokedex-a videnih pokemona
        /// </summary>
        /// <param name="bytes"></param>
        public void LoadSeen(byte[] bytes)
        {
            pokedexSeen = new BitArray(bytes);
        }
        /// <summary>
        /// Ucitava byte array od pokedex-a uhvacenih pokemona
        /// </summary>
        /// <param name="bytes"></param>
        public void LoadOwn(byte[] bytes)
        {
            pokedexOwn = new BitArray(bytes);
        }
        #endregion

        #region Save
        /// <summary>
        /// Vraca array od pokedex-a videnih pokemona
        /// </summary>
        /// <returns></returns>
        public byte[] SaveSeen()
        {
            byte[] ret = new byte[49];
            pokedexSeen.CopyTo(ret, 0);
            return ret;

        }
        /// <summary>
        /// Vraca array od pokedex-a uhvacenih pokemona
        /// </summary>
        /// <returns></returns>
        public byte[] SaveOwn()
        {
            byte[] ret = new byte[49];
            pokedexOwn.CopyTo(ret, 0);
            return ret;
        }
        #endregion
    }
}
