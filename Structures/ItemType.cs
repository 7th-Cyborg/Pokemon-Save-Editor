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

namespace Pokemon_Save_Editor.Structures
{
    /// <summary>
    /// Odreduje pretinac di se predmet nalazi u torbi
    /// </summary>
    enum PocketType
    {
        Unknown,
        Items,
        KeyItems,
        PokeBalls,
        TMsHMs,
        Berries
    }

    struct ItemType
    {
        /// <summary>
        /// ID od predmeta
        /// </summary>
        public ushort ItemID;
        /// <summary>
        /// Ime predmeta
        /// </summary>
        public string ItemName;
        /// <summary>
        /// Opis predmeta
        /// </summary>
        public string ItemDescription;
        /// <summary>
        /// Odreduje pretinac di se predmet nalazi u torbi
        /// </summary>
        public PocketType PocketType;
    }
}
