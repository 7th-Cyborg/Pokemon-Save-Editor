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
    class Player
    {
        private byte[] _name;//7 slova
        private byte _gender;
        private uint _trainerID;
        private ushort _publicTrainerID;
        private ushort _privateTrainerID;
        private uint _encryptionKey;
        private ushort _smallEncryptionKey;
        private uint _money;
        private ushort _coins;

        #region Properties
        /// <summary>
        /// Ime igraca u poke text formatu kao byte
        /// </summary>
        public byte[] Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Ime igraca string
        /// </summary>
        public string NameString
        {
            get { return PokemonTextToString(_name); }
            set
            {
                int size = value.Length;
                if (size < 8) //Zato jer je max 7 slova
                {
                    //Inicijaliziramo array sa prekidajucim byteom, 
                    //te kasnije kopiramo konvertirani string preko nje
                    _name = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                    Buffer.BlockCopy(StringToPokemonText(value), 0, _name, 0, size);
                }
            }
        }

        /// <summary>
        /// Spol Playera
        /// </summary>
        public byte Gender 
        {
            get { return _gender; }
            set 
            {
                if (value > 0)
                {
                    _gender = 1;
                }
                else
                {
                    _gender = 0;
                }
            }
        }

        /// <summary>
        /// Spol Playera String
        /// </summary>
        public string GenderString
        {
            get { return _gender == 0 ? "Boy" : "Girl"; }
            set
            {
                if (value == "Girl")
                {
                    _gender = 1;
                }
                else
                {
                    _gender = 0;
                }
            }
        }

        /// <summary>
        /// Trainer ID
        /// </summary>
        public uint TrainerID 
        {
            get { return _trainerID; }
            set 
            {
                _trainerID = value;
                byte[] bytes = BitConverter.GetBytes(_trainerID);
                _publicTrainerID = BitConverter.ToUInt16(bytes, 0);
                _privateTrainerID = BitConverter.ToUInt16(bytes, 2);

            }
        }

        /// <summary>
        /// Public Trainer ID
        /// </summary>
        public ushort PublicTrainerID
        {
            get { return _publicTrainerID; }
            set 
            {
                _publicTrainerID = value;
                TrainerID_Helper();

            }
        }

        /// <summary>
        /// Private Trainer ID
        /// </summary>
        public ushort PrivateTrainerID
        {
            get { return _privateTrainerID; }
            set 
            { 
                _privateTrainerID = value;
                TrainerID_Helper();
            }
        }

        /// <summary>
        /// Enkripcijski kljuc veliki
        /// </summary>
        public uint EncryptionKey
        {
            get { return _encryptionKey; }
            set 
            { 
                _encryptionKey = value;
                //Uzimamo zadnja 2 bytea koji onda predstavljaju  _smallEncryptionKey
                byte[] bytes = BitConverter.GetBytes(_encryptionKey);
                _smallEncryptionKey = BitConverter.ToUInt16(bytes, 0);
            }
        }

        /// <summary>
        /// Enkripcijski kljuc veliki
        /// </summary>
        public ushort EncryptionKeySmall
        {
            get { return _smallEncryptionKey; }
            //set { _smallEncryptionKey = value; }
        }

        /// <summary>
        /// Novac - pristup vec enkriptiranoj variabli i postavljanje vec enkriptirane vrijednosti
        /// </summary>
        public uint Money
        {
            get { return _money; }
            set 
            {
                _money = value;
            }
        }

        /// <summary>
        /// Novac - ovo svojstvo se brine o enkripciji/dekripciji automatski
        /// </summary>
        public uint MoneyEncryption
        {
            get { return _money ^ _encryptionKey; }
            set
            {
                uint m = value;
                if (m > 999999)
                {
                    _money = 999999 ^ _encryptionKey;
                }
                else
                {
                    _money = m ^ _encryptionKey;
                }
            }
        }

        /// <summary>
        /// Novcici - pristup vec enkriptiranoj variabli i postavljanje vec enkriptirane vrijednosti
        /// </summary>
        public ushort Coins
        {
            get { return _coins; }
            set 
            {
                _coins = value;
            }
        }

        /// <summary>
        /// Novcici - ovo svojstvo se brine o enkripciji/dekripciji automatski
        /// </summary>
        public ushort CoinsEncryption
        {
            get { return (ushort)(_coins ^ _smallEncryptionKey); } 
            set
            {
                ushort c = value;
                if (c > 9999)
                {
                    _coins = (ushort)(9999 ^ _smallEncryptionKey);
                }
                else
                {
                    _coins = (ushort)(c ^ _smallEncryptionKey);
                }
            }
        }

        #endregion

        /// <summary>
        /// Konstruktor klase
        /// </summary>
        public Player()
        {
            this._name = new byte[7];
        }

        /// <summary>
        /// Konvertira pokemon byte text u string
        /// </summary>
        /// <param name="pokeText">pokemon byte text koji trebamo konvertirat</param>
        /// <returns>vraca konvertirani string</returns>
        public static string PokemonTextToString(byte[] pokeText)
        {
            string text = "";

            foreach (byte b in pokeText) 
            {
                //Provjeravamo prekidajuci byte koji oznacava kraj texta
                if (b != 0xFF)
                {
                    text += PokemonConstants.PokemonCharToString(b);
                }
            }

            return text;
        }

        /// <summary>
        /// Konvertira string u pokemon byte text
        /// </summary>
        /// <param name="text">text za konvertirat</param>
        /// <returns>vraca konvertirani byte array</returns>
        public static byte[] StringToPokemonText(string text)
        {
            byte[] pokeText = new byte[text.Length];
            char[] chars = text.ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                pokeText[i] = PokemonConstants.CharToPokemonChar(chars[i]);
            }

                return pokeText;
        }

        /// <summary>
        /// Kreira TrainerID iz privatnog i javnog trainerID-a
        /// </summary>
        private void TrainerID_Helper() 
        {
            byte[] bytes = new byte[4];
            bytes[0] = BitConverter.GetBytes(_publicTrainerID)[0];
            bytes[1] = BitConverter.GetBytes(_publicTrainerID)[1];
            bytes[2] = BitConverter.GetBytes(_privateTrainerID)[0];
            bytes[3] = BitConverter.GetBytes(_privateTrainerID)[1];
            _trainerID = BitConverter.ToUInt32(bytes, 0);
        }
    }
}
