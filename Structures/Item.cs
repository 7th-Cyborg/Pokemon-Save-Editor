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
    /// Definicija Predmet Klase
    /// </summary>
    class Item
    {
        /// <summary>
        /// Tip predmeta
        /// </summary>
        public ushort ItemType { get; set; }
        /// <summary>
        /// Kolicina predmeta enkriptirana vrijednost
        /// </summary>
        public ushort Quantity { get; set; }
        /// <summary>
        /// Kljuc koji sluzi za enkripciju i dekripciju
        /// </summary>
        public static ushort EncryptionKey { get; set; }

        /// <summary>
        /// Postavlja kolicinu enkriptirajuci vrijednost
        /// </summary>
        public ushort SetQuantityEncrypted
        {
            set { Quantity = (ushort)(value ^ EncryptionKey); }
        }

        /// <summary>
        /// Dohvaca kolicinu dekriptiranu
        /// </summary>
        public ushort GetQuantityDecrypted
        {
            get { return (ushort)(Quantity ^ EncryptionKey); }
        }

        /// <summary>
        /// Dohvaca kolicinu dekriptiranu kao string
        /// </summary>
        public string GetQuantityDecryptedString 
        {
            get { return Convert.ToString((ushort)(Quantity ^ EncryptionKey)); }
        }

        /// <summary>
        /// Dohvaca tip predmeta
        /// </summary>
        public ItemType GetItemType
        {
            get
            {
                ItemType it;
                if (PokemonConstants.ItemTypes.TryGetValue(this.ItemType, out it))
                {
                    return it;
                }
                else 
                {
                    it = new ItemType();
                    it.ItemID = 0;
                    it.PocketType = PocketType.Unknown;
                    it.ItemName = "Unknown Item";
                    it.ItemDescription = "Unknown Item Description";
                    return it;
                }
            }
        }

        /// <summary>
        /// Konstruktor klase Item
        /// </summary>
        /// <param name="itemType">Tip predmeta</param>
        /// <param name="quantity">Kolicina predmeta</param>
        public Item(ushort itemType, ushort quantity)
        {
            this.ItemType = itemType;
            this.Quantity = quantity;
        }

        public Item()
        { }
    }
}
