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
using System.Windows.Forms;

namespace Pokemon_Save_Editor
{
    class PokemonSave
    {
        //private string _originalSaveName;
        private string _path;
        private bool _isSave64KB;
        private byte _bank;
        /// <summary>
        /// Sadrzi index-e blokova u save fileu 0-13 blokovi idu po redu
        /// </summary>
        private byte[] _blockOrder;

        /// <summary>
        /// Sadrzi cijeli save
        /// </summary>
        private byte[] _save;
        /// <summary>
        /// Sadrzi finalno organiziranu banku
        /// </summary>
        public byte[] saveBank { get; set; }
        /// <summary>
        /// Sluzi za provjeru dal je file ucitan
        /// </summary>
        public bool isLoaded { get; set; }

        public PokemonSave(string path)
        {
            //this._originalSaveName = Path.GetFileName(path);
            this._path = path;
            this._isSave64KB = false;
            _blockOrder = new byte[14];
            this.isLoaded = false;

            if (File.Exists(path))
            {
                LoadFromFile();
            }
            else
            {
                MessageBox.Show("Selected file does not exist.");
            }
            
        }

        /// <summary>
        /// Ucitavamo citav save u memoriju
        /// </summary>
        private void LoadFromFile()
        {
            long _saveLength;

            using (FileStream fs = File.OpenRead(_path))
            {
                _saveLength = fs.Length;

                if(_saveLength == 131072)//128KB
                { _isSave64KB = false; }
                else if (_saveLength == 65536)//64KB
                { _isSave64KB = true; }
                else//nes nije u redu sa file-om 
                {
                    MessageBox.Show("The pokemon savefile size must be 128kb or 64kb");
                    return;
                }

                //Kopiramo File u memoriju
                this._save = new byte[(int)_saveLength];
                fs.Read(_save, 0, (int)_saveLength);
            }
             //Sortiramo Blokove i kreiramo bank za njih
             SortBlocks();
            //Ako smo dosli do ovdje bez errora znaci da je file ucitan
             this.isLoaded = true;
        }

        /// <summary>
        /// Spremamo sve promjene u file
        /// </summary>
        public void SaveToFile()
        { 
            //Radimo backup filea
            try
            {
                DateTime dt = DateTime.Now;
                int index = _path.LastIndexOf(".");
                string str = "";
                if (index != -1)
                {
                    str = _path.Substring(0, index - 1);
                    str += "-Backup-";
                    str += dt.ToString("d-M_HH-mm-ss");
                    str += _path.Substring(index);
                }
                else 
                {
                    str = _path + "-Backup-" + dt.ToString("d-M_HH-mm-ss");
                }
               
                File.Copy(_path, str, true); 
            }
            catch 
            {
                MessageBox.Show("Unable to create backup file. Aborting Save.");
                return;
            }

            int currentOffset = _bank == 1 ? 0 : PokemonConstants.bank2Start;

            //Vracamo bank nazad u save file
            for (int i = 0; i < 14; i++)
            {
                Buffer.BlockCopy(saveBank, i * PokemonConstants.blockDataSize, _save, (_blockOrder[i] * PokemonConstants.blockSize) + currentOffset, PokemonConstants.blockDataSize);
            }

            //Izracunavamo CRC
            currentOffset += PokemonConstants.blockSize - 10;//offset CRC
            using (MemoryStream tempSave = new MemoryStream(_save))
            {
                BinaryWriter bw = new BinaryWriter(tempSave);
                BinaryReader br = new BinaryReader(tempSave);
                ushort calculatedCRC = 0;
                ushort originalCRC = 0;
                int seek = 0;

                for (int x = 0; x < 14; x++)
                {
                    calculatedCRC = CheckCRC(x);
                    //nalazimo di se nalazi trenutni blok x(predstavlja blok) u saveu pomocu _blockOrder koji sadrzi lokaciju
                    seek = (_blockOrder[x] * PokemonConstants.blockSize) + currentOffset;
                    br.BaseStream.Seek(seek, SeekOrigin.Begin);
                    originalCRC = br.ReadUInt16();

                    //Spremamo CRC u save ako je razlicit
                    if (calculatedCRC != originalCRC)
                    {
                        bw.BaseStream.Seek(seek, SeekOrigin.Begin);
                        bw.Write(calculatedCRC);
                    }
                }

                _save = tempSave.ToArray();
                br.Close();
                bw.Close();
            }

            //Spremamo save  u file
            using (FileStream fs = File.Create(_path))
            {
                fs.Write(_save, 0, _save.Length);
            }
        }

        #region Sortiranje Blokova i Kreiranje SaveBanke
        /// <summary>
        /// Sortira blokove da budu po redu
        /// </summary>
        private void SortBlocks()
        {
            if (_isSave64KB == true)
            {
                _bank = 1;
                SortBlocksHelper(0);
            }
            else 
            {
                int bank1, bank2;
                MemoryStream save = new MemoryStream(_save);

                using (BinaryReader br = new BinaryReader(save))
                {
                    br.BaseStream.Seek(PokemonConstants.bank1SaveNumber, SeekOrigin.Begin);
                    bank1 = br.ReadInt32();
                    br.BaseStream.Seek(PokemonConstants.bank2SaveNumber, SeekOrigin.Begin);
                    bank2 = br.ReadInt32();
                }
                save.Close();
                save.Dispose();

                //Provjerava koja banka/save je veci i koristi taj
                if (bank1 > bank2)
                { _bank = 1; SortBlocksHelper(0); }
                else
                { _bank = 2; SortBlocksHelper(14 * PokemonConstants.blockSize); } //14 zbog 14 blokova kolko pojedina banka ima
            }
        }

        /// <summary>
        /// Sortira blokove da budu po redu
        /// </summary>
        private void SortBlocksHelper(int startOffset)
        {
            MemoryStream tempSaveBank = new MemoryStream(14 * PokemonConstants.blockDataSize);//14 zbog toga sto samo 14 blokova sadrzi podatke
            MemoryStream tempSave = new MemoryStream(_save);

            byte currentBlock;
            int currentOffset = startOffset;

            BinaryReader br = new BinaryReader(tempSave);
            BinaryWriter bw = new BinaryWriter(tempSaveBank);
            
            //Prolazimo kroz svih 14 blokova jer neznamo di su koji blokovi
            for (int i = 0; i < 14; i++)
            {
                //Seek od Validacijskog Broja iako netreba provjera al ajd
                br.BaseStream.Seek(currentOffset +  PokemonConstants.blockSize  - 8, SeekOrigin.Begin);
                if (br.ReadInt32() == PokemonConstants.validationCode)
                {
                    //Seek od Broja Bloka
                    br.BaseStream.Seek(currentOffset +  PokemonConstants.blockSize - PokemonConstants.blockFooterSize, SeekOrigin.Begin);
                    currentBlock = br.ReadByte();
                    //Spremamo di se nalazi blok _blockOrder predstavlja 14 blokova a value njihovu poziciju u fileu
                    _blockOrder[currentBlock] = (byte)i;
                    // Postavljanje seeka za citanje i spremanje u sortiranu banku
                    br.BaseStream.Seek((i * PokemonConstants.blockSize) + startOffset, SeekOrigin.Begin);
                    bw.BaseStream.Seek(currentBlock * PokemonConstants.blockDataSize, SeekOrigin.Begin);
                    bw.Write(br.ReadBytes(PokemonConstants.blockDataSize));

                }
                currentOffset += PokemonConstants.blockSize;
            }

            //Spremamo sortirane blokove
            saveBank = tempSaveBank.ToArray();

            tempSaveBank.Close();
            tempSaveBank.Dispose();
            tempSave.Close();
            tempSave.Dispose();
            br.Close();
            bw.Close();
        }
        #endregion

        /// <summary>
        /// Izracunavamo CRC Bloka
        /// </summary>
        /// <param name="index">Index Bloka kojem izracunavamo CRC</param>
        /// <returns>Vracamo izracunati CRC</returns>
        private ushort CheckCRC(int index)
        {
            int tempCrc = 0;
            int temp = 0;

            using (MemoryStream tempSaveBank = new MemoryStream(saveBank))
            {
                using (BinaryReader br = new BinaryReader(tempSaveBank))
                {
                    br.BaseStream.Seek(index * PokemonConstants.blockDataSize, SeekOrigin.Begin);
                    for (int i = 0; i < 0x3E0; i++) //F80 : 4 byte zbog int
                    {
                        tempCrc += br.ReadInt32();
                    }
                }
            }

            temp = tempCrc >> 16;
            temp += tempCrc;

            return (ushort)(temp & 0xFFFF);
        }

    }
}
