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
using System.IO;

namespace Pokemon_Save_Editor.Structures
{
    /// <summary>
    /// Verzija Pokemon Igre
    /// </summary>
    enum PokemonVersion 
    {
        Emerald,
        FireRedAndLeafGreen,
        RubyAndSapphire
    }

    class PlayerBag
    {
        /// <summary>
        /// Pretinac za normalne predmete
        /// </summary>
        public Item[] Items { get; set; }
        /// <summary>
        /// Pretinac za kljucne predmete
        /// </summary>
        public Item[] KeyItems { get; set; }
        /// <summary>
        /// Pretinac za Pokemon lopte
        /// </summary>
        public Item[] PokeBalls { get; set; }
        /// <summary>
        /// Pretinac za TM and HM skill-ove
        /// </summary>
        public Item[] TMsHMs { get; set; }
        /// <summary>
        ///Pretinac za Berries
        /// </summary>
        public Item[] Berries { get; set; }

        /// <summary>
        /// Velicina torbe u byteovima 
        /// </summary>
        private int bagSizeBytes;

        public PlayerBag(PokemonVersion pokVersion)
        {
            if (pokVersion == PokemonVersion.Emerald)
            {
                this.Items = new Item[30];
                this.KeyItems = new Item[30];
                this.PokeBalls = new Item[16];
                this.TMsHMs = new Item[64];
                this.Berries = new Item[46];
                bagSizeBytes = PokemonConstants.bagSizeinBytes;
            }
            else if (pokVersion == PokemonVersion.RubyAndSapphire)
            {
                this.Items = new Item[20];
                this.KeyItems = new Item[20];
                this.PokeBalls = new Item[16];
                this.TMsHMs = new Item[64];
                this.Berries = new Item[46];
                bagSizeBytes = PokemonConstants.bagSizeinBytesRubySapphire;
            }
            else //Fire Red Leaf Green
            {
                this.Items = new Item[42];
                this.KeyItems = new Item[30];
                this.PokeBalls = new Item[13];
                this.TMsHMs = new Item[58];
                this.Berries = new Item[43];
                bagSizeBytes = PokemonConstants.bagSizeinBytes;
            }
        }

        /// <summary>
        /// Ucitavamo predmete u array iz kompletne torbe
        /// </summary>
        /// <param name="bag">Kompletni sadrzaj torbe velicina mu je 0x2E8 byteova</param>
        public void Load(byte[] bag)
        {
            using (MemoryStream tempBag = new MemoryStream(bag))
            {
                using (BinaryReader br = new BinaryReader(tempBag))
                {
                    //Seek na pocetak za svaki slucaj
                    br.BaseStream.Seek(0, SeekOrigin.Begin);

                    //Items
                    for(int i = 0 ; i < Items.Length; i++)
                    {
                        this.Items[i] = new Item(br.ReadUInt16(), br.ReadUInt16());
                    }

                    //KeyItems
                    for (int k = 0; k < KeyItems.Length; k++) 
                    {
                        this.KeyItems[k] = new Item(br.ReadUInt16(), br.ReadUInt16());
                    }

                    //PokeBalls
                    for (int p = 0; p < PokeBalls.Length; p++)
                    {
                        this.PokeBalls[p] = new Item(br.ReadUInt16(), br.ReadUInt16());
                    }

                    //TMsHMs
                    for (int t = 0; t < TMsHMs.Length; t++) 
                    {
                        this.TMsHMs[t] = new Item(br.ReadUInt16(), br.ReadUInt16());
                    }

                    //Berries
                    for (int b = 0; b < Berries.Length; b++)
                    {
                        this.Berries[b] = new Item(br.ReadUInt16(), br.ReadUInt16());
                    }
                }
            }

        }

        /// <summary>
        /// Spremamo odnosno vracamo cijelu torbu
        /// </summary>
        /// <returns>Vracamo kompletni sadrzaj torbe</returns>
        public byte[] Save()
        {
            byte[] bag = new byte[bagSizeBytes];

            using (MemoryStream tempBag = new MemoryStream(bag))
            {
                using (BinaryWriter bw = new BinaryWriter(tempBag))
                {
                    //Seek na pocetak za svaki slucaj
                    bw.BaseStream.Seek(0, SeekOrigin.Begin);

                    //Items
                    for (int i = 0; i < Items.Length; i++)
                    {
                        bw.Write(this.Items[i].ItemType);
                        bw.Write(this.Items[i].Quantity);
                    }

                    //KeyItems
                    for (int k = 0; k < KeyItems.Length; k++)
                    {
                        bw.Write(this.KeyItems[k].ItemType);
                        bw.Write(this.KeyItems[k].Quantity);
                    }

                    //PokeBalls
                    for (int p = 0; p < PokeBalls.Length; p++)
                    {
                        bw.Write(this.PokeBalls[p].ItemType);
                        bw.Write(this.PokeBalls[p].Quantity);
                    }

                    //TMsHMs
                    for (int t = 0; t < TMsHMs.Length; t++)
                    {
                        bw.Write(this.TMsHMs[t].ItemType);
                        bw.Write(this.TMsHMs[t].Quantity);
                    }

                    //Berries
                    for (int b = 0; b < Berries.Length; b++)
                    {
                        bw.Write(this.Berries[b].ItemType);
                        bw.Write(this.Berries[b].Quantity);
                    }

                    //Vracamo nazad array
                    bag = tempBag.ToArray();
                }
            }

            return bag;
        }

        //TO-DO ak bude trebalo sortirat predmete u nekim pretincima
    }
}
