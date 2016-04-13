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

namespace Pokemon_Save_Editor.Structures
{
    class Pokemon
    {
        /// <summary>
        /// Vrijednost za Osobnost Pokemona iz nje se izracunava puno toga vezanog za karakteristike
        /// </summary>
        public uint Personality { get; set; }
        /// <summary>
        /// ID trenera ciji je to Pokemon
        /// </summary>
        public uint OriginalTrainerID { get; set; }
        /// <summary>
        /// Nadimak pokemona
        /// </summary>
        public byte[] Nickname { get; set; }
        /// <summary>
        /// Odreduje iz koje verzije je Pokemon
        /// 0x0201 = Japanese  0x0202 = USA  0x0203 = French  
        /// 0x0204 = Italian  0x0205 = German   0x0207 = Spanish 
        /// </summary>
        public ushort Language { get; set; }
        /// <summary>
        /// Ime trenera ciji je to Pokemon
        /// </summary>
        public byte[] OriginalTrainerName { get; set; }
        /// <summary>
        /// Oznaka koja se pokazuje u Storage-u
        /// bit0 = Circle  bit1 = Square bit2 = Triangle bit3 = Heart
        /// ovisno koji su bitovi postaviti u 1 ta kombinacija ce bit vidljiva kao oznaka
        /// </summary>
        public byte StorageBoxMark { get; set; }
        /// <summary>
        /// CRC Check od 48byte-a Data bloka
        /// </summary>
        public ushort Checksum { get; set; }
        /// <summary>
        /// Nezna se cemu sluzi
        /// vrlo vjerojatno da je postavito samo da bi se zaoruzila velicina strukture na 80 byteova
        /// uvijek 0
        /// </summary>
        public ushort Unknown { get; set; }
        /// <summary>
        /// Enkriptirani dio u njemu se nalaze karakteristike Pokemona
        /// </summary>
        public byte[] Data { get; set; }

        #region Properties

        /// <summary>
        /// Dali je pokemon Shiny 
        /// ukoliko pokemon nije Shiny prvi put kad se pozove za postavljanje vrijednosti 
        /// napravi ga Shiny
        /// ukoliko pokemon je vec Shiny onda ga pretvara u ne Shiny
        /// </summary>
        public bool PokemonShininess
        {
            get { return IsShiny(); }
            set 
            {
                //da se izbjegne value error ili to ili jedna varijabla
                if (value == true)
                {
                    SetShiny();
                }
                else 
                {
                    SetShiny();
                }
            }
        }


        /// <summary>
        /// Postavlja Nature od pokemona broj se izracunava sa zadnjim byteom od Personality
        /// range 0-24
        /// </summary>
        public byte PokemonNature 
        {
            get 
            { 
                return (byte)(Personality % 25);
            }
            set { SetPokemonNature(value); }
        }

        /// <summary>
        /// Vraca ime Nature-a
        /// </summary>
        public string PokemonNatureName
        {
            get
            {
                Natures nt;
                if (PokemonConstants.Natures.TryGetValue((byte)(Personality % 25), out nt))
                {
                    return nt.NatureName;
                }
                else
                {
                    return "Invalid Nature";
                }
            }
        }

        /// <summary>
        /// Pokemon Unown slova
        /// </summary>
        public byte PokemonUnownLetter
        {
            get { return GetPokemonUnownLetter(); }
            set { SetPokemonUnownLetter(value); }
        }

        /// <summary>
        /// Nadimak pokemona
        /// </summary>
        public string NicknameString
        {
            get 
            {
                if (Checksum == 0 && Language == 0)
                {
                    return "Empty Slot";
                }
                else
                {
                    List<byte> tempName = new List<byte>();
                    foreach (byte b in Nickname)
                    {
                        if (b == 255)
                        {
                            break;
                        }
                        tempName.Add(b);
                    }
                    return Player.PokemonTextToString(tempName.ToArray());
                }
            }
            set
            {
                int size = value.Length;
                if (size < 11) //Zato jer je max 10 slova
                {
                    //Inicijaliziramo array sa prekidajucim byteom, 
                    //te kasnije kopiramo konvertirani string preko nje
                    Nickname = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                    Buffer.BlockCopy(Player.StringToPokemonText(value), 0, Nickname, 0, size);
                }
            }
        }
        /// <summary>
        /// Ime trenera ciji je to Pokemon
        /// </summary>
        public string OriginalTrainerNameString
        {
            get { return Player.PokemonTextToString(OriginalTrainerName); }
            set
            {
                int size = value.Length;
                if (size < 8) //Zato jer je max 7 slova
                {
                    //Inicijaliziramo array sa prekidajucim byteom, 
                    //te kasnije kopiramo konvertirani string preko nje
                    OriginalTrainerName = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                    Buffer.BlockCopy(Player.StringToPokemonText(value), 0, OriginalTrainerName, 0, size);
                }
            }
        }

        /// <summary>
        /// Oznaka Circle
        /// </summary>
        public bool StorageBoxMarkCircle
        {
            get { return PokemonData.BitSelector(StorageBoxMark, 0, 1) == 1 ? true : false; }
            set 
            { 
                if(value)
                {
                    StorageBoxMark = PokemonData.BitSet(StorageBoxMark,1,0,1);
                }
                else
                {
                    StorageBoxMark = PokemonData.BitSet(StorageBoxMark,0,0,1);
                }
            }          
        }

        /// <summary>
        /// Oznaka Square
        /// </summary>
        public bool StorageBoxMarkSquare
        {
            get { return PokemonData.BitSelector(StorageBoxMark, 1, 1) == 1 ? true : false; }
            set
            {
                if (value)
                {
                    StorageBoxMark = PokemonData.BitSet(StorageBoxMark, 1, 1, 1);
                }
                else
                {
                    StorageBoxMark = PokemonData.BitSet(StorageBoxMark, 0, 1, 1);
                }
            }
        }

        /// <summary>
        /// Oznaka Triangle
        /// </summary>
        public bool StorageBoxMarkTriangle
        {
            get { return PokemonData.BitSelector(StorageBoxMark, 2, 1) == 1 ? true : false; }
            set
            {
                if (value)
                {
                    StorageBoxMark = PokemonData.BitSet(StorageBoxMark, 1, 2, 1);
                }
                else
                {
                    StorageBoxMark = PokemonData.BitSet(StorageBoxMark, 0, 2, 1);
                }
            }
        }

        /// <summary>
        /// Oznaka Heart
        /// </summary>
        public bool StorageBoxMarkHeart
        {
            get { return PokemonData.BitSelector(StorageBoxMark, 3, 1) == 1 ? true : false; }
            set
            {
                if (value)
                {
                    StorageBoxMark = PokemonData.BitSet(StorageBoxMark, 1, 3, 1);
                }
                else
                {
                    StorageBoxMark = PokemonData.BitSet(StorageBoxMark, 0, 3, 1);
                }
            }
        }
        #endregion

        public Pokemon()
        {
            this.Nickname = new byte[10];
            this.OriginalTrainerName = new byte[7];
            this.Data = new byte[48];
        }

        #region Load , Save, Export, Import
        /// <summary>
        /// Ucitavamo Pokemona iz 80 byte strukture
        /// </summary>
        /// <param name="pokemon">pokemon array velicine 80 byteova</param>
        public void Load(byte[] pokemon)
        {
            using (MemoryStream tempPokemon = new MemoryStream(pokemon))
            {
                using (BinaryReader br = new BinaryReader(tempPokemon))
                {
                    //Seek na pocetak za svaki slucaj
                    br.BaseStream.Seek(0, SeekOrigin.Begin);

                    this.Personality = br.ReadUInt32();
                    this.OriginalTrainerID = br.ReadUInt32();
                    this.Nickname = br.ReadBytes(10);
                    this.Language = br.ReadUInt16();
                    this.OriginalTrainerName = br.ReadBytes(7);
                    this.StorageBoxMark = br.ReadByte();
                    this.Checksum = br.ReadUInt16();
                    this.Unknown = br.ReadUInt16();
                    this.Data = br.ReadBytes(48);
                }
            }
        }

        /// <summary>
        /// Spremamo odnosno vracamo pokemon strukturu
        /// </summary>
        /// <returns>Vracamo pokemon strukturu</returns>
        public byte[] Save()
        {
            byte[] pokemon = new byte[PokemonConstants.pokemonStructureSize];

            using (MemoryStream tempPokemon = new MemoryStream(pokemon))
            {
                using (BinaryWriter bw = new BinaryWriter(tempPokemon))
                {
                    //Seek na pocetak za svaki slucaj
                    bw.BaseStream.Seek(0, SeekOrigin.Begin);

                    bw.Write(this.Personality);
                    bw.Write(this.OriginalTrainerID);
                    bw.Write(this.Nickname);
                    bw.Write(this.Language);
                    bw.Write(this.OriginalTrainerName);
                    bw.Write(this.StorageBoxMark);
                    bw.Write(this.Checksum);
                    bw.Write(this.Unknown);
                    bw.Write(this.Data);

                    //Vracamo nazad array
                    pokemon = tempPokemon.ToArray();
                }
            }

            return pokemon;
        }

        /// <summary>
        /// Importiranje Pokemona
        /// </summary>
        /// <param name="path">Putanja do pokemona kojeg trebamo importat</param>
        public void ImportPokemon(string path) 
        {
            try
            {
                if (File.Exists(path))
                {
                    byte[] pokemon = new byte[PokemonConstants.pokemonStructureSize];

                    using (FileStream fs = File.OpenRead(path))
                    {
                        if (fs.Length == PokemonConstants.pokemonStructureSize)
                        {
                            fs.Read(pokemon, 0, PokemonConstants.pokemonStructureSize);
                            Load(pokemon);
                        }
                        else
                        {
                            MessageBox.Show("The pokemon import file size must be 80bytes");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selected file does not exist.");
                    return;
                }
            }
            catch 
            {
                MessageBox.Show("Error occured while importing " + path);
                return;
            }
        }

        /// <summary>
        /// Exportiranje pokemona
        /// </summary>
        /// <param name="path">Putanja i ime filea pokemona kojeg zelimo exportat</param>
        public void ExportPokemon(string path)
        {
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    fs.Write(Save(), 0, PokemonConstants.pokemonStructureSize);
                }
            }
            catch 
            {
                MessageBox.Show("Error occured while exporting " + path);
                return;
            }
        }
        #endregion

        #region Encryption Decryption CRC
        /// <summary>
        /// Enkriptira PokemonData strukturu
        /// </summary>
        /// <param name="data">Struktura za encrypciju</param>
        public void EncryptPokemonData(PokemonData data)
        {
            byte[] _tempData = new byte[48];
            char[] order = PokemonDataOrder();

            using (MemoryStream tempData = new MemoryStream(_tempData))
            {
                using (BinaryWriter bw = new BinaryWriter(tempData))
                {
                    //Seek na pocetak za svaki slucaj
                    bw.BaseStream.Seek(0, SeekOrigin.Begin);

                    //Ucitavamo sve strukture u byte array
                    #region Ucitavanje
                    for (int i = 0; i < 4; i++)
                    {
                        if (order[i] == 'G')//Growth
                        {
                            bw.Write(data.Growth.Species);
                            bw.Write(data.Growth.ItemHeld);
                            bw.Write(data.Growth.Experience);
                            bw.Write(data.Growth.PPbonuses);
                            bw.Write(data.Growth.Friendship);
                            bw.Write(data.Growth.Unknown);
                        }
                        else if (order[i] == 'A')//Attacks
                        {
                            bw.Write(data.Attacks.Attack1);
                            bw.Write(data.Attacks.Attack2);
                            bw.Write(data.Attacks.Attack3);
                            bw.Write(data.Attacks.Attack4);
                            bw.Write(data.Attacks.PP1);
                            bw.Write(data.Attacks.PP2);
                            bw.Write(data.Attacks.PP3);
                            bw.Write(data.Attacks.PP4);
                        }
                        else if (order[i] == 'E')//Effort
                        {
                            bw.Write(data.Effort.HPEv);
                            bw.Write(data.Effort.AttackEv);
                            bw.Write(data.Effort.DefenseEv);
                            bw.Write(data.Effort.SpeedEv);
                            bw.Write(data.Effort.SpAttackEv);
                            bw.Write(data.Effort.SpDefenseEv);
                            bw.Write(data.Effort.Coolness);
                            bw.Write(data.Effort.Beauty);
                            bw.Write(data.Effort.Cuteness);
                            bw.Write(data.Effort.Smartness);
                            bw.Write(data.Effort.Toughness);
                            bw.Write(data.Effort.Feel);
                        }
                        else //Misc
                        {
                            bw.Write(data.Misc.Pokerus);
                            bw.Write(data.Misc.LocationCaught);
                            bw.Write(data.Misc.LevelCaught);
                            bw.Write(data.Misc.PokeBallAndPlayerGender);
                            bw.Write(data.Misc.Individualvalues);
                            bw.Write(data.Misc.Ribbons);
                        }
                    }
                    #endregion

                    //Vracamo nazad array
                    _tempData = tempData.ToArray();

                    //Izracunavamo Checksum
                    CalculateCRC(_tempData);

                    //Postavljamo enkriptiranu vrijednost
                    this.Data = EncryptDecryptHelper(_tempData); 
                    
                }
            }


        }

        /// <summary>
        /// Dekriptira PokemonData strukturu
        /// </summary>
        /// <returns>Vraca PokemonData strukturu</returns>
        public PokemonData DecryptPokemonData() 
        {
            PokemonData data = new PokemonData();
            // decryptedData = new byte[48];
            byte[] decryptedData = EncryptDecryptHelper(this.Data);
            char[] order = PokemonDataOrder();

            using (MemoryStream tempData = new MemoryStream(decryptedData))
            {
                using (BinaryReader br = new BinaryReader(tempData))
                {
                    //Seek na pocetak za svaki slucaj
                    br.BaseStream.Seek(0, SeekOrigin.Begin);

                    //Ucitavamo sve strukture u byte array
                    #region Ucitavanje
                    for (int i = 0; i < 4; i++)
                    {
                        if (order[i] == 'G')//Growth
                        {
                            data.Growth.Species = br.ReadUInt16();
                            data.Growth.ItemHeld = br.ReadUInt16();
                            data.Growth.Experience = br.ReadUInt32();
                            data.Growth.PPbonuses = br.ReadByte();
                            data.Growth.Friendship = br.ReadByte();
                            data.Growth.Unknown = br.ReadUInt16();
                        }
                        else if (order[i] == 'A')//Attacks
                        {
                            data.Attacks.Attack1 = br.ReadUInt16();
                            data.Attacks.Attack2 = br.ReadUInt16();
                            data.Attacks.Attack3 = br.ReadUInt16();
                            data.Attacks.Attack4 = br.ReadUInt16();
                            data.Attacks.PP1 = br.ReadByte();
                            data.Attacks.PP2 = br.ReadByte();
                            data.Attacks.PP3 = br.ReadByte();
                            data.Attacks.PP4 = br.ReadByte();
                        }
                        else if (order[i] == 'E')//Effort
                        {
                            data.Effort.HPEv = br.ReadByte();
                            data.Effort.AttackEv = br.ReadByte();
                            data.Effort.DefenseEv = br.ReadByte();
                            data.Effort.SpeedEv = br.ReadByte();
                            data.Effort.SpAttackEv = br.ReadByte();
                            data.Effort.SpDefenseEv = br.ReadByte();
                            data.Effort.Coolness = br.ReadByte();
                            data.Effort.Beauty = br.ReadByte();
                            data.Effort.Cuteness = br.ReadByte();
                            data.Effort.Smartness = br.ReadByte();
                            data.Effort.Toughness = br.ReadByte();
                            data.Effort.Feel = br.ReadByte();
                        }
                        else //Misc
                        {
                            data.Misc.Pokerus = br.ReadByte();
                            data.Misc.LocationCaught = br.ReadByte();
                            data.Misc.LevelCaught = br.ReadSByte();
                            //data.Misc.LevelCaught = br.ReadByte();
                            data.Misc.PokeBallAndPlayerGender = br.ReadByte();
                            data.Misc.Individualvalues = br.ReadUInt32();
                            data.Misc.Ribbons = br.ReadUInt32();
                        }
                    }
                    #endregion

                }
            }

            return data;
        }

        /// <summary>
        /// Funkcija koja obavlja XOR operaciju nad byteovima
        /// </summary>
        /// <param name="data">Pokemon data struktura</param>
        /// <returns>Vracamo Enkriptiranu ili dekriptiranu data strukturu</returns>
        private byte[] EncryptDecryptHelper(byte[] data)
        {
            uint encyptionKey = OriginalTrainerID ^ Personality;
            byte[] key = BitConverter.GetBytes(encyptionKey);
            byte[] tempData = data;

            for (int i = 0; i < 48; i++)
            {
                tempData[i] ^= key[i % 4];
            }

            return tempData;
        }

        /// <summary>
        /// Izracunavamo i postavljamo Checksum
        /// </summary>
        /// <param name="data">48byte-a koji predstavljaju PokemonData decryptiranu strukturu</param>
        private void CalculateCRC(byte[] data)
        {
            ushort tempChecksum = 0;
            using (MemoryStream tempData = new MemoryStream(data))
            {
                using (BinaryReader br = new BinaryReader(tempData))
                {
                    for (int i = 0; i < 24; i++)//48 djeljeno sa 2
                    {
                        tempChecksum += br.ReadUInt16(); 
                    }
                }
            }

            this.Checksum = tempChecksum;
        }

        /// <summary>
        /// Pronalazi kako su strukture poredane u Data dijelu od Pokemona
        /// Growth, Attacks, Effort, and Misc
        /// </summary>
        /// <returns>Vraca redosljed struktura</returns>
        private char[] PokemonDataOrder()
        {
            switch (Personality % 24)
            {
                case 0: return "GAEM".ToCharArray();
                case 1: return "GAME".ToCharArray();
                case 2: return "GEAM".ToCharArray();
                case 3: return "GEMA".ToCharArray();
                case 4: return "GMAE".ToCharArray();
                case 5: return "GMEA".ToCharArray();
                case 6: return "AGEM".ToCharArray();
                case 7: return "AGME".ToCharArray();
                case 8: return "AEGM".ToCharArray();
                case 9: return "AEMG".ToCharArray();
                case 10: return "AMGE".ToCharArray();
                case 11: return "AMEG".ToCharArray();
                case 12: return "EGAM".ToCharArray();
                case 13: return "EGMA".ToCharArray();
                case 14: return "EAGM".ToCharArray();
                case 15: return "EAMG".ToCharArray();
                case 16: return "EMGA".ToCharArray();
                case 17: return "EMAG".ToCharArray();
                case 18: return "MGAE".ToCharArray();
                case 19: return "MGEA".ToCharArray();
                case 20: return "MAGE".ToCharArray();
                case 21: return "MAEG".ToCharArray();
                case 22: return "MEGA".ToCharArray();
                case 23: return "MEAG".ToCharArray();
                default: return "MEAG".ToCharArray();
            }
        }
        #endregion

        #region Helper Funkcije

        /// <summary>
        /// Provjerava dali je Pokemon Shiny ili ne
        /// </summary>
        /// <returns>vraca true ako je</returns>
        private bool IsShiny()
        {
            byte[] bytesPersonality = BitConverter.GetBytes(Personality);
            byte[] bytesTrainerID = BitConverter.GetBytes(OriginalTrainerID);
            
            ushort publicID = BitConverter.ToUInt16(bytesTrainerID, 0);
            ushort privateID = BitConverter.ToUInt16(bytesTrainerID, 2);
            ushort p1 = BitConverter.ToUInt16(bytesPersonality, 0);
            ushort p2 = BitConverter.ToUInt16(bytesPersonality, 2);
            ushort IDxor = (ushort)(publicID ^ privateID);
            ushort Pxor = (ushort)(p1 ^ p2);
            ushort final = (ushort)(IDxor ^ Pxor);

            if (final < 8)
            {
                return true;
            }
            else { return false; }  
        }
        /// <summary>
        /// Postavlja Pokemona da bude Shiny
        /// </summary>
        private void SetShiny()
        {
            byte[] bytesPersonality = BitConverter.GetBytes(Personality);
            byte[] bytesTrainerID = BitConverter.GetBytes(OriginalTrainerID);

            ushort publicID = BitConverter.ToUInt16(bytesTrainerID, 0);
            ushort privateID = BitConverter.ToUInt16(bytesTrainerID, 2);
            ushort p1 = BitConverter.ToUInt16(bytesPersonality, 0);
            ushort p2 = BitConverter.ToUInt16(bytesPersonality, 2);
            ushort IDxor = (ushort)(publicID ^ privateID);
            ushort IDxorP2 = (ushort)(IDxor ^ p2);

            //Postavljamo sve bitove kod p1 da kad ga xoramo sa p2 da sve bude 0
            for (int i = 3; i < 16; i++)
            {
                if (PokemonData.BitSelector(IDxorP2, (byte)i, 1) == 1)
                {
                    p1 = (ushort)PokemonData.BitSet(p1, 1, (byte)i, 1);
                }
                else 
                {
                    p1 = (ushort)PokemonData.BitSet(p1, 0, (byte)i, 1);
                }
            }
            byte[] temp = BitConverter.GetBytes(p1);
            bytesPersonality[0] = temp[0];
            bytesPersonality[1] = temp[1];
            //Vracamo nazad
            Personality = BitConverter.ToUInt32(bytesPersonality, 0);
        }

        /// <summary>
        /// Postavljamo Pokemon Nature range 0-24
        /// </summary>
        /// <param name="value">0-24 vrijednost koju zelimo postavit</param>
        private void SetPokemonNature(byte value)
        {
            uint currentNature = Personality % 25;
            //Nature koji zelimo vec je prisutan u Personality
            if (currentNature == value)
                return;
            //Resetiramo Personality na Nature 0
            currentNature = Personality - currentNature;

            //Provjere da nepredemo max uint barijeru
            if (((long)currentNature + value) > 4294967295)
            {
                Personality = (uint)(currentNature -  (25 - value));
            }
            else 
            {
                Personality = currentNature + value;
            }
        }

        /// <summary>
        /// Slova zs Unown Pokemona range  0 - 28
        /// </summary>
        /// <returns>vraca slovo</returns>
        private byte GetPokemonUnownLetter()
        {
            return GetPokemonUnownLetter(false);
        }

       /// <summary>
        /// Slova zs Unown Pokemona range  0 - 28
       /// </summary>
       /// <param name="returnValue">dali zelimo samo vrijednost bytea</param>
       /// <returns></returns>
        private byte GetPokemonUnownLetter(bool returnValue)
        {
            //byte[] bytes = BitConverter.GetBytes(Personality);
            byte n = PokemonData.BitSelector(Personality, 0, 2);
            byte n1 = PokemonData.BitSelector(Personality, 8, 2);
            byte n2 = PokemonData.BitSelector(Personality, 16, 2);
            byte n3 = PokemonData.BitSelector(Personality, 24, 2);

            n = PokemonData.BitSet(n, n1, 2, 2);
            n = PokemonData.BitSet(n, n2, 4, 2);
            n = PokemonData.BitSet(n, n3, 6, 2);

            if (returnValue)
                return n;

            return (byte)(n % 28);
        }

        /// <summary>
        /// Postavlja Unown  Letter na zeljenu vrijednost
        /// </summary>
        /// <param name="value">zeljena vrijednost</param>
        private void SetPokemonUnownLetter(byte value)
        {
            byte currentValue = GetPokemonUnownLetter(true);
            byte currentLetter = (byte)(currentValue % 28);
            if (currentLetter == value)
                return;

            //Resetiramo Letter na 0
            currentLetter = (byte)(currentValue - currentLetter);

            //Provjere da nepredemo max byte barijeru
            if ((int)currentLetter + value > 255)
            {
                currentValue = (byte)(currentLetter - (28 - value));
            }
            else
            {
                currentValue = (byte)(currentLetter + value);
            }

            byte n = PokemonData.BitSelector(currentValue, 0, 2);
            byte n1 = PokemonData.BitSelector(currentValue, 2, 2);
            byte n2 = PokemonData.BitSelector(currentValue, 4, 2);
            byte n3 = PokemonData.BitSelector(currentValue, 6, 2);

            Personality = PokemonData.BitSet(Personality, n, 0, 2);
            Personality = PokemonData.BitSet(Personality, n1, 8, 2);
            Personality = PokemonData.BitSet(Personality, n2, 16, 2);
            Personality = PokemonData.BitSet(Personality, n3, 24, 2);


        }
        #endregion

        /// <summary>
        /// Kreira Defaultnog Pokemona
        /// </summary>
        public void MakeDefaultPokemon()
        {
 
        }

        /// <summary>
        /// Kreira Pokemona koji predstavlja prazno mjesto u Storage-u
        /// </summary>
        public void MakeBlankPokemonSpot()
        {
            this.Personality = 0;
            this.OriginalTrainerID = 0;
            this.Nickname = new byte[10];
            this.Language = 0;
            this.OriginalTrainerName = new byte[7];
            this.StorageBoxMark = 0;
            this.Checksum = 0;
            this.Unknown = 0;
            this.Data = new byte[48];
        }
    }
}
