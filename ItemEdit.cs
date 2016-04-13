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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pokemon_Save_Editor.Structures;

namespace Pokemon_Save_Editor
{
     partial class ItemEdit : Form
    {
        /// <summary>
        /// Tip Itema koji je odabran
        /// </summary>
        public ushort Item { get; set; }
        /// <summary>
        /// Kolicina koja je odabrana
        /// </summary>
        public ushort Quantity { get; set; }
        private bool isReady;

        public ItemEdit(string item, PocketType it, ushort quantity)
        {
            InitializeComponent();
            isReady = false;
            //Moja initalizacija
            MyInitialize(it);
            isReady = true;
            //Kontrole
            uxItems.Text = item;
            uxQuantity.Text = quantity.ToString();

        }

        private void MyInitialize(PocketType it)
        {
            //Postavljamo kolka kolicina moze bit
            switch (it) 
            {
                case PocketType.Items:
                    uxQuantity.NumberValueMax = 99;
                    break;
                case PocketType.KeyItems:
                    uxQuantity.NumberValueMax = 1;
                    break;
                case PocketType.PokeBalls:
                    uxQuantity.NumberValueMax = 99;
                    break;
                case PocketType.TMsHMs:
                    uxQuantity.NumberValueMax = 99;
                    break;
                case PocketType.Berries:
                    uxQuantity.NumberValueMax = 99;
                    break;
            }

            //Dohvacamo sve iteme koji su odredenog Pocket tipa
            var items = from item in PokemonConstants.ItemTypes
                        where item.Value.PocketType == it
                        select item.Value;

            List<string> itemStrings = new List<string>();
            //Stavljamo mogucnost da napravimo prazan item
            itemStrings.Add("000 Nothing");

            foreach (var itm in items)
            {
                itemStrings.Add(String.Format("{0:D3}", itm.ItemID) + " " + itm.ItemName);
            }

            uxItems.DataSource = itemStrings;
        }

        private void uxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            ItemType it = new ItemType();
            string[] str = uxItems.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.ItemTypes.TryGetValue(index, out it))
            {
                uxDesc.Text = it.ItemDescription;
            }
        }

        private void uxOK_Click(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            ItemType it = new ItemType();
            string[] str = uxItems.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.ItemTypes.TryGetValue(index, out it))
            {
                this.Item = it.ItemID;
                if (this.Item == 0)
                {
                    this.Quantity = 0;
                }
                else if (this.Item != 0 && (ushort)uxQuantity.GetNumberValue == 0)
                {
                    this.Quantity = 1;
                }
                else
                {
                    this.Quantity = (ushort)uxQuantity.GetNumberValue;
                }
            }
        }
    }
}
