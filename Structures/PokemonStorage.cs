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
    class PokemonStorage
    {
        /// <summary>
        /// Imena kutija u storage-u
        /// </summary>
        public byte[][] BoxNames { get; set; }
        /// <summary>
        /// Kutije u kojima se nalaze Pokemoni svaka kutija ima 30 pokemona
        /// ima 14 kutija
        /// </summary>
        public Pokemon[,] PokemonBoxes { get; set; }

        #region Properties
        /// <summary>
        /// Vraca ime kutija u stringu
        /// </summary>
        /// <param name="index">index kutije koju treba vratit u string</param>
        /// <returns>Vraca string od imena kutije</returns>
        public string GetBoxNamesString(int index)
        {
            return Player.PokemonTextToString(BoxNames[index]);
        }
        /// <summary>
        /// Postavljamo ime kutije
        /// </summary>
        /// <param name="index">Index kutije</param>
        /// <param name="value">Novo ime</param>
        public void SetBoxNamesString(int index, string value)
        {
            int size = value.Length;
            if (size < 10) //Zato jer je max 9 slova
            {
                //Inicijaliziramo array sa prekidajucim byteom, 
                //te kasnije kopiramo konvertirani string preko nje
                BoxNames[index] = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                Buffer.BlockCopy(Player.StringToPokemonText(value), 0, BoxNames[index], 0, size);
            }
        }
        #endregion


        public PokemonStorage()
        {
            this.BoxNames = new byte[14][];
            this.PokemonBoxes = new Pokemon[14,30];//14 kutija 30 pokemona u svakoj
        }

        /// <summary>
        /// Ucitavamo pokemon storage
        /// </summary>
        /// <param name="storage">Sadrzaj cijelog pokemon storage-a </param>
        public void Load(byte[] storage)
        {
            using (MemoryStream tempStorage = new MemoryStream(storage))
            {
                using (BinaryReader br = new BinaryReader(tempStorage))
                {
                    //Seek na pocetak za svaki slucaj
                    br.BaseStream.Seek(0, SeekOrigin.Begin);

                    //Ucitavanje pokemona
                    for (int x = 0; x < 14; x++)
                    {
                        for (int y = 0; y < 30; y++)
                        {
                            this.PokemonBoxes[x, y] = new Pokemon();
                            this.PokemonBoxes[x, y].Load(br.ReadBytes(PokemonConstants.pokemonStructureSize));
                        }
                    }
                    //Ucitavanje imena kutije
                    for (int i = 0; i < 14; i++)
                    { 
                        this.BoxNames[i] = new byte[9];
                        this.BoxNames[i] = br.ReadBytes(9);
                    }
                }//binary reader
            }//memory stream
        }

        /// <summary>
        /// Spremamo odnosno vracamo cijeli pokemon storage
        /// </summary>
        /// <returns>Vracamo kompletni sadrzaj pokemon storage-a</returns>
        public byte[] Save() 
        {
            byte[] storage = new byte[PokemonConstants.pokemonStorageSize];

            using (MemoryStream tempStorage = new MemoryStream(storage))
            {
                using (BinaryWriter bw = new BinaryWriter(tempStorage))
                {
                    //Seek na pocetak za svaki slucaj
                    bw.BaseStream.Seek(0, SeekOrigin.Begin);

                    //Ucitavanje pokemona
                    for (int x = 0; x < 14; x++)
                    {
                        for (int y = 0; y < 30; y++)
                        {
                            bw.Write(this.PokemonBoxes[x, y].Save());
                        }
                    }
                    //Ucitavanje imena kutije
                    for (int i = 0; i < 14; i++)
                    {
                        bw.Write(this.BoxNames[i]);
                    }

                    //Vracamo nazad array
                    storage = tempStorage.ToArray();

                }//binary writer
            }//memory stream

            return storage;
        }
    }
}
