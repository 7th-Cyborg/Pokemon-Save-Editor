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
    class PokemonData
    {
        /// <summary>
        /// Growth struktura
        /// </summary>
        public Growth Growth { get; set; }
        /// <summary>
        /// Attacks struktura
        /// </summary>
        public Attacks Attacks { get; set; }
        /// <summary>
        /// Effort struktura
        /// </summary>
        public Effort Effort { get; set; }
        /// <summary>
        /// Misc struktura
        /// </summary>
        public Misc Misc { get; set; }

        public PokemonData()
        {
            this.Growth = new Growth();
            this.Attacks = new Attacks();
            this.Effort = new Effort();
            this.Misc = new Misc();
        }

        #region Bit Operacije
        /// <summary>
        /// Selektira odredene bitove i vraca njihovu vrijednost
        /// </summary>
        /// <param name="input">Vrijednost iz koje zelimo selektirat bitove</param>
        /// <param name="startIndex">Pocetni index od kud zelimo dohvacat bitove</param>
        /// <param name="count">Kolko bitova zelimo dohvatiti max 8</param>
        /// <returns>Vracamo selektirane bitove kao byte</returns>
        public static byte BitSelector(uint input, byte startIndex, byte count)
        {
            //Predstavlja bitove
            byte[] bits = new byte[] { 1, 2, 4, 8, 16, 32, 64, 128 };
            //maska s kojom dohvacamo bitove
            uint mask = 0;
            //Finalna vrijednost dohvacenih bitova
            uint final = 0;
            //inicijaliziramu masku sa OR operatorom postavljamo bitove koje zelimo dohvatit
            for (int i = 0; i < count; i++)
            {
                mask |= bits[i];
            }
            //Postavljamo masku na pravu lokaciju zeljenih bitova tako da ju shiftamo uljevo
            mask <<= startIndex;
            //Dohvacamo zeljene bitove AND operatorom
            final = input & mask;
            //Shiftamo u desno kako bi mogli iscitat vrijednost dohvacenih bitova
            final >>= startIndex;
            //Vracamo vrijednost iscitanih bitova
            return (byte)final;
        }

        /// <summary>
        /// Postavlja odredene bitove i vraca vrijednost
        /// </summary>
        /// <param name="input">Vrijednost u kojoj zelimo postavit bitove</param>
        /// <param name="value">Vrijednost koju postavljamo</param>
        /// <param name="startIndex">Index gdje zelimo postavit vrijednost</param>
        /// <param name="count">Kolko bitova zelimo spremit max 8</param>
        /// <returns>Vraca vrijednost sa postavljenim bitovima kao byte</returns>
        public static byte BitSet(byte input, byte value, byte startIndex, byte count)
        {
            //Predstavlja bitove
            byte[] bits = new byte[] { 1, 2, 4, 8, 16, 32, 64, 128 };
            //maska s kojom dohvacamo bitove
            uint mask = 0;
            //spremamo input u uint varijablu
            uint final = input;
            //inicijaliziramu masku sa OR operatorom postavljamo bitove koje zelimo dohvatit
            for (int i = 0; i < count; i++)
            {
                mask |= bits[i];
            }

            //Postavljamo masku na pravu lokaciju zeljenih bitova
            mask <<= startIndex;
            //Resetiramo zeljene bitove na 0 sa operatorima AND i NOT
            final = final & ~mask;

            //Shiftamo za index u ljevo
            value <<= startIndex;
            //Upisujemo vrijednost pomocu OR operatora
            return (byte)(final |= value);
        }

        /// <summary>
        /// Postavlja odredene bitove i vraca vrijednost
        /// </summary>
        /// <param name="input">Vrijednost u kojoj zelimo postavit bitove</param>
        /// <param name="value">Vrijednost koju postavljamo</param>
        /// <param name="startIndex">Index gdje zelimo postavit vrijednost</param>
        /// <param name="count">Kolko bitova zelimo spremit max 8</param>
        /// <returns>Vraca vrijednost sa postavljenim bitovima kao byte</returns>
        public static uint BitSet(uint input, uint value, byte startIndex, byte count)
        {
            //Predstavlja bitove
            byte[] bits = new byte[] { 1, 2, 4, 8, 16, 32, 64, 128 };
            //maska s kojom dohvacamo bitove
            uint mask = 0;
            //spremamo input u uint varijablu
            //inicijaliziramu masku sa OR operatorom postavljamo bitove koje zelimo dohvatit
            for (int i = 0; i < count; i++)
            {
                mask |= bits[i];
            }

            //Postavljamo masku na pravu lokaciju zeljenih bitova
            mask <<= startIndex;
            //Resetiramo zeljene bitove na 0 sa operatorima AND i NOT
            input = input & ~mask;

            //Shiftamo za index u ljevo
            value <<= startIndex;
            //Upisujemo vrijednost pomocu OR operatora
            return input |= value;

        }

        /// <summary>
        /// Postavlja 8 bit u jedinicu
        /// </summary>
        /// <param name="input">Broj u koji treba upisat tu jedinicu</param>
        /// <returns></returns>
        public static sbyte BitSet8bit(byte input)
        {
            byte b = 128;
            sbyte s = (sbyte)(input | b);
            return s;
        }
        #endregion
    }
    
    class Growth
    {
        /// <summary>
        /// Tip Pokemona npr.Bulbasaur
        /// </summary>
        public ushort Species { get; set; }
        /// <summary>
        /// Predmet koji drzi taj Pokemon
        /// </summary>
        public ushort ItemHeld { get; set; }
        /// <summary>
        /// Kolko ima trenutno XP-a
        /// </summary>
        public uint Experience { get; set; }
        /// <summary>
        /// Sadrzi kolko je puta iskoristito PP-Up itema na pojedinom skillu
        /// svaki skill je predocen kao 2 bita i s time moze bit max 3 puta iskoristit PP-Up
        /// 00 = 0puta, 01 = 1puta, 10 = 2 puta, 11 = 3puta
        /// 00     00     00     00   - bits
        /// 4skill 3skill 2skill 1skill
        /// </summary>
        public byte PPbonuses { get; set; }
        /// <summary>
        /// Prijateljstvo sa Pokemonom defaultna vrijednost na divljem pokemonu je 70
        /// </summary>
        public byte Friendship { get; set; }
        /// <summary>
        /// Nezna se cemu sluzi
        /// Vrlo vjerojatno da zaokruzi velicinu na 48byteova zbog encrypcije
        /// uvijek 0
        /// </summary>
        public ushort Unknown { get; set; }

        #region Properties
        /// <summary>
        /// Sadrzi kolko je puta iskoristito PP-Up itema na prvom skillu max vrijednost 3
        /// </summary>
        public byte PPBonus1 
        {
            get { return PokemonData.BitSelector(PPbonuses, 0, 2); }
            set { PPbonuses = PokemonData.BitSet(PPbonuses,value, 0, 2); }
        }
        /// <summary>
        /// Sadrzi kolko je puta iskoristito PP-Up itema na drugom skillu max vrijednost 3
        /// </summary>
        public byte PPBonus2
        {
            get { return PokemonData.BitSelector(PPbonuses, 2, 2); }
            set { PPbonuses = PokemonData.BitSet(PPbonuses, value, 2, 2); }
        }
        /// <summary>
        /// Sadrzi kolko je puta iskoristito PP-Up itema na trecem skillu max vrijednost 3
        /// </summary>
        public byte PPBonus3
        {
            get { return PokemonData.BitSelector(PPbonuses, 4, 2); }
            set { PPbonuses = PokemonData.BitSet(PPbonuses, value, 4, 2); }
        }
        /// <summary>
        /// Sadrzi kolko je puta iskoristito PP-Up itema na cetvrtom skillu max vrijednost 3
        /// </summary>
        public byte PPBonus4
        {
            get { return PokemonData.BitSelector(PPbonuses, 6, 2); }
            set { PPbonuses = PokemonData.BitSet(PPbonuses, value, 6, 2); }
        }

        /// <summary>
        /// Dohvaca tip predmeta koji pokemon drzi
        /// </summary>
        public ItemType GetItemType
        {
            get
            {
                ItemType it;
                if (PokemonConstants.ItemTypes.TryGetValue(ItemHeld, out it))
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
        /// Dohvaca tip pokemona
        /// </summary>
        public PokemonStructure GetPokemonType
        {
            get
            {
                PokemonStructure pok;
                if (PokemonConstants.PokemonList.TryGetValue(this.Species, out pok))
                {
                    return pok;
                }
                else
                {
                    //Vraca 1 pokemona u listi bulbasaur
                    PokemonConstants.PokemonList.TryGetValue(1, out pok);
                    return pok;
                }
            }
        }

        /// <summary>
        /// Level od Pokemona
        /// </summary>
        public byte PokemonLevel
        {
            get { return GetLevel(); }
            set { SetLevel(value); }
        }
        #endregion

        #region Helper Funkcije
        /// <summary>
        /// Postavlja level pokemona
        /// </summary>
        /// <param name="level">level na koji treba postavit range 1-100</param>
        private void SetLevel(byte level)
        {
            Experience xp;
            PokemonConstants.Experiences.TryGetValue(level, out xp);
            PokemonStructure pokemon = GetPokemonType;

            if (pokemon.XPGroup == 0)
            {
                this.Experience = xp.Erratic;
            }
            else if (pokemon.XPGroup == 1)
            {
                this.Experience = xp.Fast;
            }
            else if (pokemon.XPGroup == 2)
            {
                this.Experience = xp.MediumFast;
            }
            else if (pokemon.XPGroup == 3)
            {
                this.Experience = xp.MediumSlow;
            }
            else if (pokemon.XPGroup == 4)
            {
                this.Experience = xp.Slow;
            }
            else if (pokemon.XPGroup == 5)
            {
                this.Experience = xp.Fluctuating;
            }

        }
        /// <summary>
        /// Dohvaca Level od Pokemona
        /// </summary>
        /// <returns>vraca level</returns>
        private byte GetLevel()
        {
            List<Experience> xp = new List<Experience>();
            PokemonStructure pokemon = GetPokemonType;

            foreach (KeyValuePair<byte, Experience> kvp in PokemonConstants.Experiences)
            {
                xp.Add(kvp.Value);
            }
            //Trazimo level
            for (int i = 0; i < xp.Count; i++)
            {
                if (pokemon.XPGroup == 0)
                {
                    if (this.Experience >= xp[i].Erratic && this.Experience < xp[i + 1].Erratic)
                    { return (byte)(i + 1); }
                }
                else if (pokemon.XPGroup == 1)
                {
                    if (this.Experience >= xp[i].Fast && this.Experience < xp[i + 1].Fast)
                    { return (byte)(i + 1); }
                }
                else if (pokemon.XPGroup == 2)
                {
                    if (this.Experience >= xp[i].MediumFast && this.Experience < xp[i + 1].MediumFast)
                    { return (byte)(i + 1); }
                }
                else if (pokemon.XPGroup == 3)
                {
                    if (this.Experience >= xp[i].MediumSlow && this.Experience < xp[i + 1].MediumSlow)
                    { return (byte)(i + 1); }
                }
                else if (pokemon.XPGroup == 4)
                {
                    if (this.Experience >= xp[i].Slow && this.Experience < xp[i + 1].Slow)
                    { return (byte)(i + 1); }
                }
                else if (pokemon.XPGroup == 5)
                {
                    if (this.Experience >= xp[i].Fluctuating && this.Experience < xp[i + 1].Fluctuating)
                    { return (byte)(i + 1); }
                }
            }
            return 0;
        }
        #endregion
    }

    class Attacks
    {
        /// <summary>
        /// Skill 1
        /// </summary>
        public ushort Attack1 { get; set; }
        /// <summary>
        /// Skill 2
        /// </summary>
        public ushort Attack2 { get; set; }
        /// <summary>
        /// Skill 3
        /// </summary>
        public ushort Attack3 { get; set; }
        /// <summary>
        /// Skill 4
        /// </summary>
        public ushort Attack4 { get; set; }
        /// <summary>
        /// Kolicina Power points-a za skill 1
        /// </summary>
        public byte PP1 { get; set; }
        /// <summary>
        /// Kolicina Power points-a za skill 2
        /// </summary>
        public byte PP2 { get; set; }
        /// <summary>
        /// Kolicina Power points-a za skill 3
        /// </summary>
        public byte PP3 { get; set; }
        /// <summary>
        /// Kolicina Power points-a za skill 4
        /// </summary>
        public byte PP4 { get; set; }

        #region Properties
        /// <summary>
        /// Potez 1
        /// </summary>
        public Move AttackMove1
        {
            get 
            {
                Move mov;
                if (PokemonConstants.Moves.TryGetValue(this.Attack1, out mov))
                {
                    return mov;
                }
                else
                {
                    //Vraca prazan potez
                    PokemonConstants.Moves.TryGetValue(0, out mov);
                    return mov;
                }
            }
        }
        /// <summary>
        /// Potez 2
        /// </summary>
        public Move AttackMove2
        {
            get
            {
                Move mov;
                if (PokemonConstants.Moves.TryGetValue(this.Attack2, out mov))
                {
                    return mov;
                }
                else
                {
                    //Vraca prazan potez
                    PokemonConstants.Moves.TryGetValue(0, out mov);
                    return mov;
                }
            }
        }
        /// <summary>
        /// Potez 3
        /// </summary>
        public Move AttackMove3
        {
            get
            {
                Move mov;
                if (PokemonConstants.Moves.TryGetValue(this.Attack3, out mov))
                {
                    return mov;
                }
                else
                {
                    //Vraca prazan potez
                    PokemonConstants.Moves.TryGetValue(0, out mov);
                    return mov;
                }
            }
        }
        /// <summary>
        /// Potez 4
        /// </summary>
        public Move AttackMove4
        {
            get
            {
                Move mov;
                if (PokemonConstants.Moves.TryGetValue(this.Attack4, out mov))
                {
                    return mov;
                }
                else
                {
                    //Vraca prazan potez
                    PokemonConstants.Moves.TryGetValue(0, out mov);
                    return mov;
                }
            }
        }
        #endregion
    }
    
    class Effort 
    {
        /// <summary>
        /// HP Effort value
        /// </summary>
        public byte HPEv { get; set; }
        /// <summary>
        /// Attack Effort value
        /// </summary>
        public byte AttackEv { get; set; }
        /// <summary>
        /// Defense Effort value
        /// </summary>
        public byte DefenseEv { get; set; }
        /// <summary>
        /// Speed Effort value
        /// </summary>
        public byte SpeedEv { get; set; }
        /// <summary>
        /// Sp.Attack Effort value
        /// </summary>
        public byte SpAttackEv { get; set; }
        /// <summary>
        /// Sp.Defense Effort value
        /// </summary>
        public byte SpDefenseEv { get; set; }
        /// <summary>
        /// Coolness
        /// </summary>
        public byte Coolness { get; set; }
        /// <summary>
        /// Beauty
        /// </summary>
        public byte Beauty { get; set; }
        /// <summary>
        /// Cuteness
        /// </summary>
        public byte Cuteness { get; set; }
        /// <summary>
        /// Smartness
        /// </summary>
        public byte Smartness { get; set; }
        /// <summary>
        /// Toughness
        /// </summary>
        public byte Toughness { get; set; }
        /// <summary>
        /// Feel
        /// </summary>
        public byte Feel { get; set; }
    }

    class Misc 
    {
        /// <summary>
        /// Pokerus 0 = je da nema, 116  = traje 4 dana, 99 = 3 dana
        /// 82 = 2 dana, 65 = 1 dan
        /// </summary>
        public byte Pokerus { get; set; }
        /// <summary>
        /// Lokacija di je Pokemon uhvatit
        /// </summary>
        public byte LocationCaught { get; set; }
        /// <summary>
        /// Level na kojem je Pokemon uhvacen 1-127 raspon koristi se kod "Level # (met)" poruke
        /// </summary>
        public sbyte LevelCaught { get; set; }
        //public byte LevelCaught { get; set; }
        /// <summary>
        /// Tip Poke lopte u kojoj je Pokemon Ulovljen i spol playera
        /// Bits 3-6 je Pokeball bit7 je spol playera
        /// na b0 mora bit 1 neznam cemu sluzi
        /// </summary>
        public byte PokeBallAndPlayerGender { get; set; }
        /// <summary>
        /// Predstavlja predefinirane vrijednosti za 
        /// HP,Attack, Defense, Speed, Sp. Attack, Sp. Defense
        /// 0-31 je range svaka vrijednost je predstavljena sa 5 bita zadnja 2 bita koja se ne koriste su 0
        /// b0 starta sa HP pa tako redom
        /// </summary>
        public uint Individualvalues { get; set; }
        /// <summary>
        /// Predstavlja nagrade na natjecanjima
        /// </summary>
        public uint Ribbons { get; set; }

        #region Properties
        /// <summary>
        /// Sluzi za postavit Obedient bit za Mew I Deox pokemone
        /// </summary>
        public bool SetObedient
        {
            get 
            {
                if (PokemonData.BitSelector(Ribbons, 31, 1) == 1)
                {
                    return true;
                }
                else { return false; }
            }
            set 
            {
                if (value == true)
                {
                    Ribbons = PokemonData.BitSet(Ribbons, 1, 31, 1);
                }
                else 
                {
                    Ribbons = PokemonData.BitSet(Ribbons, 0, 31, 1);
                }
            }
        }

        /// <summary>
        /// Level na kojem je Pokemon uhvacen 1-127 raspon koristi se kod "Level # (met)" poruke
        /// Dohvaca samo 7 bitova iz sbytea
        /// </summary>
        public sbyte LevelCaught7bit
        {
            get { return (sbyte)PokemonData.BitSelector((byte)LevelCaught, 0, 7); }
            set
            {
                //Postavljamo 8 bit na 1
               LevelCaught =  PokemonData.BitSet8bit((byte)value); 
            }
        }
        /// <summary>
        /// Tip Pokemon lopte u kojoj se nalazi pokemon 1-12 raspon
        /// </summary>
        public byte PokeballType
        {
            get { return PokemonData.BitSelector(PokeBallAndPlayerGender, 3, 4); }
            set { PokeBallAndPlayerGender = PokemonData.BitSet(PokeBallAndPlayerGender, value, 3, 4); }
        }
        /// <summary>
        /// Spol trenera ciji je to pokemon
        /// </summary>
        public byte TrainerGender 
        {
            get { return PokemonData.BitSelector(PokeBallAndPlayerGender, 7, 1); }
            set 
            {
                if (value > 0)
                {
                    PokeBallAndPlayerGender = PokemonData.BitSet(PokeBallAndPlayerGender, 1, 7, 1);
                }
                else
                {
                    PokeBallAndPlayerGender = PokemonData.BitSet(PokeBallAndPlayerGender, 0, 7, 1);
                }
                
            }
        }

        /// <summary>
        /// Spol trenera ciji je to pokemon string
        /// </summary>
        public string TrainerGenderString
        {
            get { return PokemonData.BitSelector(PokeBallAndPlayerGender, 7, 1) == 0 ? "Boy" : "Girl"; }
            set
            {
                if (value == "Girl")
                {
                    PokeBallAndPlayerGender = PokemonData.BitSet(PokeBallAndPlayerGender, 1, 7, 1);
                }
                else
                {
                    PokeBallAndPlayerGender = PokemonData.BitSet(PokeBallAndPlayerGender, 0, 7, 1);
                }
            }
        }

        //IV HP,Attack, Defense, Speed, Sp. Attack, Sp. Defense
        /// <summary>
        /// Predstavlja induvidualnu vrijednost za HP range 0-31
        /// </summary>
        public byte IV_HP
        {
            get { return PokemonData.BitSelector(Individualvalues, 0, 5); }
            set { Individualvalues = PokemonData.BitSet(Individualvalues, value, 0, 5); }
        }
        /// <summary>
        /// Predstavlja induvidualnu vrijednost za Attack range 0-31
        /// </summary>
        public byte IV_Attack 
        {
            get { return PokemonData.BitSelector(Individualvalues, 5, 5); }
            set { Individualvalues = PokemonData.BitSet(Individualvalues, value, 5, 5); }
        }
        /// <summary>
        /// Predstavlja induvidualnu vrijednost za Defense range 0-31
        /// </summary>
        public byte IV_Defense 
        {
            get { return PokemonData.BitSelector(Individualvalues, 10, 5); }
            set { Individualvalues = PokemonData.BitSet(Individualvalues, value, 10, 5); }
        }
        /// <summary>
        /// Predstavlja induvidualnu vrijednost za Speed range 0-31
        /// </summary>
        public byte IV_Speed 
        {
            get { return PokemonData.BitSelector(Individualvalues, 15, 5); }
            set { Individualvalues = PokemonData.BitSet(Individualvalues, value, 15, 5); }
        }
        /// <summary>
        /// Predstavlja induvidualnu vrijednost za Sp.Attack range 0-31
        /// </summary>
        public byte IV_SpAttack 
        {
            get { return PokemonData.BitSelector(Individualvalues, 20, 5); }
            set { Individualvalues = PokemonData.BitSet(Individualvalues, value, 20, 5); }
        }
        /// <summary>
        /// Predstavlja induvidualnu vrijednost za Sp.Defense range 0-31
        /// </summary>
        public byte IV_SpDefense 
        {
            get { return PokemonData.BitSelector(Individualvalues, 25, 5); }
            set { Individualvalues = PokemonData.BitSet(Individualvalues, value, 25, 5); }
        }
        /// <summary>
        /// Predstavlja induvidualnu vrijednost za to dal je pokemon jaje ili ne range 0-1
        /// </summary>
        public byte IV_isEgg 
        {
            get { return PokemonData.BitSelector(Individualvalues, 30, 1); }
            set 
            {
                if (value > 0)
                {
                    Individualvalues = PokemonData.BitSet(Individualvalues, 1, 30, 1);
                }
                else
                {
                    Individualvalues = PokemonData.BitSet(Individualvalues, 0, 30, 1);
                }
            }
        }
        /// <summary>
        /// Predstavlja induvidualnu vrijednost za Ability range 0-1
        /// Ability odreduje koji ability ce bit koristen ako pokemon rasa ima 2 ability-a
        /// ako nema onda je 0 postavito, ako se stavi u 1 pokemon nece imat ability
        /// </summary>
        public byte IV_Ability 
        {
            get { return PokemonData.BitSelector(Individualvalues, 31, 1); }
            set 
            {
                if (value > 0)
                {
                    Individualvalues = PokemonData.BitSet(Individualvalues, 1, 31, 1);
                }
                else 
                {
                    Individualvalues = PokemonData.BitSet(Individualvalues, 0, 31, 1);
                }
            }
        }

        //Ribbons

        /// <summary>
        /// Ribbon Cool range 0-4
        /// 0 - None, 1 - Normal, 2 - Super, 3 - Hyper, 4 - Master
        /// </summary>
        public byte Ribbon_Cool
        {
            get { return PokemonData.BitSelector(Ribbons, 0, 3); }
            set { Ribbons = PokemonData.BitSet(Ribbons, value, 0, 3); }
        }

        /// <summary>
        /// Ribbon Beauty range 0-4
        /// 0 - None, 1 - Normal, 2 - Super, 3 - Hyper, 4 - Master
        /// </summary>
        public byte Ribbon_Beauty
        {
            get { return PokemonData.BitSelector(Ribbons, 3, 3); }
            set { Ribbons = PokemonData.BitSet(Ribbons, value, 3, 3); }
        }

        /// <summary>
        /// Ribbon Cute range 0-4
        /// 0 - None, 1 - Normal, 2 - Super, 3 - Hyper, 4 - Master
        /// </summary>
        public byte Ribbon_Cute
        {
            get { return PokemonData.BitSelector(Ribbons, 6, 3); }
            set { Ribbons = PokemonData.BitSet(Ribbons, value, 6, 3); }
        }

        /// <summary>
        /// Ribbon Smart range 0-4
        /// 0 - None, 1 - Normal, 2 - Super, 3 - Hyper, 4 - Master
        /// </summary>
        public byte Ribbon_Smart
        {
            get { return PokemonData.BitSelector(Ribbons, 9, 3); }
            set { Ribbons = PokemonData.BitSet(Ribbons, value, 9, 3); }
        }

        /// <summary>
        /// Ribbon  Tough range 0-4
        /// 0 - None, 1 - Normal, 2 - Super, 3 - Hyper, 4 - Master
        /// </summary>
        public byte Ribbon_Tough
        {
            get { return PokemonData.BitSelector(Ribbons, 12, 3); }
            set { Ribbons = PokemonData.BitSet(Ribbons, value, 12, 3); }
        }

        /// <summary>
        /// Vraca Lokaciju
        /// </summary>
        public Locations Locations
        {
            get
            {
                Locations loc;
                if (PokemonConstants.Locations.TryGetValue(this.LocationCaught, out loc))
                {
                    return loc;
                }
                else
                {
                    loc = new Locations(254, "In-game trade");
                    return loc;
                }
            }
        }

        /// <summary>
        /// Vraca ime Lokacije String
        /// </summary>
        public String LocationsNameString
        {
            get
            {
                Locations loc;
                if (PokemonConstants.Locations.TryGetValue(this.LocationCaught, out loc))
                {
                    return loc.Name;
                }
                else
                {
                    return "In-game trade";
                }
            }
        }
        #endregion
    }
}
