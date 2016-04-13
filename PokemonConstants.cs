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

namespace Pokemon_Save_Editor
{
    static class PokemonConstants
    {
        #region Save Blocks Stuff
        /// <summary>
        /// Velicina Bloka  0x1000
        /// </summary>
        public const int blockSize = 0x1000;
        /// <summary>
        /// Velicina Podataka u bloku 0xF80
        /// </summary>
        public const int blockDataSize = 0xF80;
        /// <summary>
        /// Velicina Footera u Bloku 0xC
        /// </summary>
        public const int blockFooterSize = 0xC;
        /// <summary>
        /// Pocetak Druge Banke 0xE000
        /// </summary>
        public const int bank2Start = 0xE000;

        /// <summary>
        /// Pozicija Save Broja u Banci 1 0xFFC
        /// </summary>
        public const int bank1SaveNumber = 0xFFC;
        /// <summary>
        /// Pozicija Save Broja u Banci 2 0xEFFC
        /// </summary>
        public const int bank2SaveNumber = 0xEFFC;
        /// <summary>
        /// Validacijski Kod Bloka 0x08012025
        /// </summary>
        public const int validationCode = 0x08012025;
        #endregion

        #region Pokemon Text Stuff
        /// <summary>
        /// Konvertira PokemonChar u string
        /// </summary>
        /// <param name="pokeChar">Pokemon Char</param>
        /// <returns>Vraca konvertirani string</returns>
        public static string PokemonCharToString(byte pokeChar) 
        {
            switch (pokeChar)
            {
                case 0xA1: return "0";
                case 0xA2: return "1";
                case 0xA3: return "2";
                case 0xA4: return "3";
                case 0xA5: return "4";
                case 0xA6: return "5";
                case 0xA7: return "6";
                case 0xA8: return "7";
                case 0xA9: return "8";
                case 0xAA: return "9";
                case 0xBB: return "A";
                case 0xBC: return "B";
                case 0xBD: return "C";
                case 0xBE: return "D";
                case 0xBF: return "E";
                case 0xC0: return "F";
                case 0xC1: return "G";
                case 0xC2: return "H";
                case 0xC3: return "I";
                case 0xC4: return "J";
                case 0xC5: return "K";
                case 0xC6: return "L";
                case 0xC7: return "M";
                case 0xC8: return "N";
                case 0xC9: return "O";
                case 0xCA: return "P";
                case 0xCB: return "Q";
                case 0xCC: return "R";
                case 0xCD: return "S";
                case 0xCE: return "T";
                case 0xCF: return "U";
                case 0xD0: return "V";
                case 0xD1: return "W";
                case 0xD2: return "X";
                case 0xD3: return "Y";
                case 0xD4: return "Z";
                case 0xD5: return "a";
                case 0xD6: return "b";
                case 0xD7: return "c";
                case 0xD8: return "d";
                case 0xD9: return "e";
                case 0xDA: return "f";
                case 0xDB: return "g";
                case 0xDC: return "h";
                case 0xDD: return "i";
                case 0xDE: return "j";
                case 0xDF: return "k";
                case 0xE0: return "l";
                case 0xE1: return "m";
                case 0xE2: return "n";
                case 0xE3: return "o";
                case 0xE4: return "p";
                case 0xE5: return "q";
                case 0xE6: return "r";
                case 0xE7: return "s";
                case 0xE8: return "t";
                case 0xE9: return "u";
                case 0xEA: return "v";
                case 0xEB: return "w";
                case 0xEC: return "x";
                case 0xED: return "y";
                case 0xEE: return "z";
                case 0xAD: return ".";//Tocka
                case 0xB8: return ",";//Zarez
                case 0xAB: return "!";//Usklicnik
                case 0xAC: return "?";//Upitnik
                case 0xB5: return ">";//Znak za musko
                case 0xB6: return "<";//Znak za zensko
                case 0xBA: return "/";//Kosa crta
                case 0xAE: return "-";//Minus
                case 0xB0: return "_";//Znak za ... (tri tockice u nizu)
                case 0xB1: return ":";//Pocetni dvostruki navodnik 
                case 0xB2: return "\"";//Dvostruki navodnik "
                case 0xB3: return ";";//Pocetni jednostruki navodnik '
                case 0xB4: return "\'";//Jednostruki navodnik
                case 0x00: return " ";//Space (Prazno mijesto)
                default: return "";
            }

        }
        /// <summary>
        /// Konvertira Char u PokemonChar
        /// </summary>
        /// <param name="Char">Char</param>
        /// <returns>Vraca konvertirani byte</returns>
        public static byte CharToPokemonChar(char Char)
        {
            switch (Char)
            {
                case '0': return 0xA1;
                case '1': return 0xA2;
                case '2': return 0xA3;
                case '3': return 0xA4;
                case '4': return 0xA5;
                case '5': return 0xA6;
                case '6': return 0xA7;
                case '7': return 0xA8;
                case '8': return 0xA9;
                case '9': return 0xAA;
                case 'A': return 0xBB;
                case 'B': return 0xBC;
                case 'C': return 0xBD;
                case 'D': return 0xBE;
                case 'E': return 0xBF;
                case 'F': return 0xC0;
                case 'G': return 0xC1;
                case 'H': return 0xC2;
                case 'I': return 0xC3;
                case 'J': return 0xC4;
                case 'K': return 0xC5;
                case 'L': return 0xC6;
                case 'M': return 0xC7;
                case 'N': return 0xC8;
                case 'O': return 0xC9;
                case 'P': return 0xCA;
                case 'Q': return 0xCB;
                case 'R': return 0xCC;
                case 'S': return 0xCD;
                case 'T': return 0xCE;
                case 'U': return 0xCF;
                case 'V': return 0xD0;
                case 'W': return 0xD1;
                case 'X': return 0xD2;
                case 'Y': return 0xD3;
                case 'Z': return 0xD4;
                case 'a': return 0xD5;
                case 'b': return 0xD6;
                case 'c': return 0xD7;
                case 'd': return 0xD8;
                case 'e': return 0xD9;
                case 'f': return 0xDA;
                case 'g': return 0xDB;
                case 'h': return 0xDC;
                case 'i': return 0xDD;
                case 'j': return 0xDE;
                case 'k': return 0xDF;
                case 'l': return 0xE0;
                case 'm': return 0xE1;
                case 'n': return 0xE2;
                case 'o': return 0xE3;
                case 'p': return 0xE4;
                case 'q': return 0xE5;
                case 'r': return 0xE6;
                case 's': return 0xE7;
                case 't': return 0xE8;
                case 'u': return 0xE9;
                case 'v': return 0xEA;
                case 'w': return 0xEB;
                case 'x': return 0xEC;
                case 'y': return 0xED;
                case 'z': return 0xEE;
                case '.': return 0xAD;//Tocka
                case ',': return 0xB8;//Zarez
                case '!': return 0xAB;//Usklicnik
                case '?': return 0xAC;//Upitnik
                case '>': return 0xB5;//Znak za musko
                case '<': return 0xB6;//Znak za zensko
                case '/': return 0xBA;//Kosa crta
                case '-': return 0xAE;//Minus
                case '_': return 0xB0;//Znak za ... (tri tockice u nizu)
                case ':': return 0xB1;//Pocetni dvostruki navodnik 
                case '\"': return 0xB2;//Dvostruki navodnik "
                case ';': return 0xB3;//Pocetni jednostruki navodnik '
                case '\'': return 0xB4;//Jednostruki navodnik
                case ' ': return 0x00;//Space (Prazno mijesto)
                default: return 0x00;
            }

        }
        #endregion

        #region Items
        #region Definirana lista predmeta
        private static Dictionary<ushort, Structures.ItemType> _itemTypes = new Dictionary<ushort, Structures.ItemType> 
        { 
            {0x0000, new Structures.ItemType{ ItemID = 0x0000, ItemName = "Nothing", ItemDescription = "Empty space", PocketType = Structures.PocketType.Unknown}},
            {0x0001, new Structures.ItemType{ ItemID = 0x0001, ItemName = "Master Ball", ItemDescription = "The best ball that catches a Pokemon without fail.", PocketType = Structures.PocketType.PokeBalls}},
            {0x0002, new Structures.ItemType{ ItemID = 0x0002, ItemName = "Ultra Ball", ItemDescription = "A better ball with a higher catch rate than a Great Ball.", PocketType = Structures.PocketType.PokeBalls}},
            {0x0003, new Structures.ItemType{ ItemID = 0x0003, ItemName = "Great Ball", ItemDescription = "A good ball with a higher catch rate than a Poke Ball.", PocketType = Structures.PocketType.PokeBalls}},
            {0x0004, new Structures.ItemType{ ItemID = 0x0004, ItemName = "Poke Ball", ItemDescription = "A tool for catching wild Pokemon.", PocketType = Structures.PocketType.PokeBalls}},
            {0x0005, new Structures.ItemType{ ItemID = 0x0005, ItemName = "Safari Ball", ItemDescription = "A special ball that is used only in the Safari Zone.", PocketType = Structures.PocketType.PokeBalls}},
            {0x0006, new Structures.ItemType{ ItemID = 0x0006, ItemName = "Net Ball", ItemDescription = "A ball that works well on Water and Bug type Pokemon.", PocketType = Structures.PocketType.PokeBalls}},
            {0x0007, new Structures.ItemType{ ItemID = 0x0007, ItemName = "Dive Ball", ItemDescription = "A ball that works better on Pokemon on the ocean floor.", PocketType = Structures.PocketType.PokeBalls}},
            {0x0008, new Structures.ItemType{ ItemID = 0x0008, ItemName = "Nest Ball", ItemDescription = "A ball that works better on weaker Pokemon.", PocketType = Structures.PocketType.PokeBalls}},
            {0x0009, new Structures.ItemType{ ItemID = 0x0009, ItemName = "Repeat Ball", ItemDescription = "A ball that works better on Pokemon caught before.", PocketType = Structures.PocketType.PokeBalls}},
            {0x000A, new Structures.ItemType{ ItemID = 0x000A, ItemName = "Timer Ball", ItemDescription = "More effective as more turns are taken in battle.", PocketType = Structures.PocketType.PokeBalls}},
            {0x000B, new Structures.ItemType{ ItemID = 0x000B, ItemName = "Luxury Ball", ItemDescription = "A cozy ball that makes Pokemon more friendly.", PocketType = Structures.PocketType.PokeBalls}},
            {0x000C, new Structures.ItemType{ ItemID = 0x000C, ItemName = "Premier Ball", ItemDescription = "A rare ball made in commemoration of some event.", PocketType = Structures.PocketType.PokeBalls}},
            {0x000D, new Structures.ItemType{ ItemID = 0x000D, ItemName = "Potion", ItemDescription = "Restores the HP of a Pokemon by 20 points.", PocketType = Structures.PocketType.Items}},
            {0x000E, new Structures.ItemType{ ItemID = 0x000E, ItemName = "Antidote", ItemDescription = "Heals a poisoned Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x000F, new Structures.ItemType{ ItemID = 0x000F, ItemName = "Burn Heal", ItemDescription = "Heals Pokemon of a burn.", PocketType = Structures.PocketType.Items}},
            {0x0010, new Structures.ItemType{ ItemID = 0x0010, ItemName = "Ice Heal", ItemDescription = "Defrosts a frozen Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0011, new Structures.ItemType{ ItemID = 0x0011, ItemName = "Awakening", ItemDescription = "Awakens a sleeping Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0012, new Structures.ItemType{ ItemID = 0x0012, ItemName = "Parlyz Heal", ItemDescription = "Heals a paralyzed Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0013, new Structures.ItemType{ ItemID = 0x0013, ItemName = "Full Restore", ItemDescription = "Fully restores the HP and status of a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0014, new Structures.ItemType{ ItemID = 0x0014, ItemName = "Max Potion", ItemDescription = "Fully restores the HP of a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0015, new Structures.ItemType{ ItemID = 0x0015, ItemName = "Hyper Potion", ItemDescription = "Restores the HP of a Pokemon by 200 points.", PocketType = Structures.PocketType.Items}},
            {0x0016, new Structures.ItemType{ ItemID = 0x0016, ItemName = "Super Potion", ItemDescription = "Restores the HP of a Pokemon by 50 points.", PocketType = Structures.PocketType.Items}},
            {0x0017, new Structures.ItemType{ ItemID = 0x0017, ItemName = "Full Heal", ItemDescription = "Heals all the status problems of one Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0018, new Structures.ItemType{ ItemID = 0x0018, ItemName = "Revive", ItemDescription = "Revives a fainted Pokemon with half its HP.", PocketType = Structures.PocketType.Items}},
            {0x0019, new Structures.ItemType{ ItemID = 0x0019, ItemName = "Max Revive", ItemDescription = "Revives a fainted Pokemon with all its HP.", PocketType = Structures.PocketType.Items}},
            {0x001A, new Structures.ItemType{ ItemID = 0x001A, ItemName = "Fresh Water", ItemDescription = "A mineral water that restores HP by 50 points.", PocketType = Structures.PocketType.Items}},
            {0x001B, new Structures.ItemType{ ItemID = 0x001B, ItemName = "Soda Pop", ItemDescription = "A fizzy soda drink that restores HP by 60 points.", PocketType = Structures.PocketType.Items}},
            {0x001C, new Structures.ItemType{ ItemID = 0x001C, ItemName = "Lemonade", ItemDescription = "A very sweet drink that restores HP by 80 points.", PocketType = Structures.PocketType.Items}},
            {0x001D, new Structures.ItemType{ ItemID = 0x001D, ItemName = "Moomoo Milk", ItemDescription = "A nutritious milk that restores HP by 100 points.", PocketType = Structures.PocketType.Items}},
            {0x001E, new Structures.ItemType{ ItemID = 0x001E, ItemName = "EnergyPowder", ItemDescription = "A bitter powder that restores HP by 50 points.", PocketType = Structures.PocketType.Items}},
            {0x001F, new Structures.ItemType{ ItemID = 0x001F, ItemName = "Energy Root", ItemDescription = "A bitter root that restores HP by 200 points.", PocketType = Structures.PocketType.Items}},
            {0x0020, new Structures.ItemType{ ItemID = 0x0020, ItemName = "Heal Powder", ItemDescription = "A bitter powder that heals all status problems.", PocketType = Structures.PocketType.Items}},
            {0x0021, new Structures.ItemType{ ItemID = 0x0021, ItemName = "Revival Herb", ItemDescription = "A very bitter herb that revives a fainted Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0022, new Structures.ItemType{ ItemID = 0x0022, ItemName = "Ether", ItemDescription = "Restores 10 PP of one move.", PocketType = Structures.PocketType.Items}},
            {0x0023, new Structures.ItemType{ ItemID = 0x0023, ItemName = "Max Ether", ItemDescription = "Fully restores the PP of a selected move.", PocketType = Structures.PocketType.Items}},
            {0x0024, new Structures.ItemType{ ItemID = 0x0024, ItemName = "Elixir", ItemDescription = "Restores 10 PP to each move.", PocketType = Structures.PocketType.Items}},
            {0x0025, new Structures.ItemType{ ItemID = 0x0025, ItemName = "Max Elixir", ItemDescription = "Fully restores the PP of a Pokemon's moves.", PocketType = Structures.PocketType.Items}},
            {0x0026, new Structures.ItemType{ ItemID = 0x0026, ItemName = "Lava Cookie", ItemDescription = "A local specialty that heals all status problems.", PocketType = Structures.PocketType.Items}},
            {0x0027, new Structures.ItemType{ ItemID = 0x0027, ItemName = "Blue Flute", ItemDescription = "A glass flute that awakens sleeping Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0028, new Structures.ItemType{ ItemID = 0x0028, ItemName = "Yellow Flute", ItemDescription = "A glass flute that snaps Pokemon out of confusion.", PocketType = Structures.PocketType.Items}},
            {0x0029, new Structures.ItemType{ ItemID = 0x0029, ItemName = "Red Flute", ItemDescription = "A glass flute that snaps Pokemon out of attraction.", PocketType = Structures.PocketType.Items}},
            {0x002A, new Structures.ItemType{ ItemID = 0x002A, ItemName = "Black Flute", ItemDescription = "A glass flute that keeps away wild Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x002B, new Structures.ItemType{ ItemID = 0x002B, ItemName = "White Flute", ItemDescription = "A glass flute that lures wild Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x002C, new Structures.ItemType{ ItemID = 0x002C, ItemName = "Berry Juice", ItemDescription = "A 100% pure juice that restores HP by 20 points.", PocketType = Structures.PocketType.Items}},
            {0x002D, new Structures.ItemType{ ItemID = 0x002D, ItemName = "Sacred Ash", ItemDescription = "Fully revives and restores all fainted Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x002E, new Structures.ItemType{ ItemID = 0x002E, ItemName = "Shoal Salt", ItemDescription = "Salt obtained deep inside the Shoal Cave.", PocketType = Structures.PocketType.Items}},
            {0x002F, new Structures.ItemType{ ItemID = 0x002F, ItemName = "Shoal Shell", ItemDescription = "A seashell found deep inside the Shoal Cave.", PocketType = Structures.PocketType.Items}},
            {0x0030, new Structures.ItemType{ ItemID = 0x0030, ItemName = "Red Shard", ItemDescription = "A shard from an ancient item. Can be sold cheaply.", PocketType = Structures.PocketType.Items}},
            {0x0031, new Structures.ItemType{ ItemID = 0x0031, ItemName = "Blue Shard", ItemDescription = "A shard from an ancient item. Can be sold cheaply.", PocketType = Structures.PocketType.Items}},
            {0x0032, new Structures.ItemType{ ItemID = 0x0032, ItemName = "Yellow Shard", ItemDescription = "A shard from an ancient item. Can be sold cheaply.", PocketType = Structures.PocketType.Items}},
            {0x0033, new Structures.ItemType{ ItemID = 0x0033, ItemName = "Green Shard", ItemDescription = "A shard from an ancient item. Can be sold cheaply.", PocketType = Structures.PocketType.Items}},
            {0x003F, new Structures.ItemType{ ItemID = 0x003F, ItemName = "HP Up", ItemDescription = "Raises the base HP of one Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0040, new Structures.ItemType{ ItemID = 0x0040, ItemName = "Protein", ItemDescription = "Raises the base Attack stat of one Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0041, new Structures.ItemType{ ItemID = 0x0041, ItemName = "Iron", ItemDescription = "Raises the base Defense stat of one Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0042, new Structures.ItemType{ ItemID = 0x0042, ItemName = "Carbos", ItemDescription = "Raises the base Speed stat of one Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0043, new Structures.ItemType{ ItemID = 0x0043, ItemName = "Calcium", ItemDescription = "Raises the base Sp. Atk stat of one Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0044, new Structures.ItemType{ ItemID = 0x0044, ItemName = "Rare Candy", ItemDescription = "Raises the level of a Pokemon by one.", PocketType = Structures.PocketType.Items}},
            {0x0045, new Structures.ItemType{ ItemID = 0x0045, ItemName = "PP Up", ItemDescription = "Raises the maximum PP of a selected move.", PocketType = Structures.PocketType.Items}},
            {0x0046, new Structures.ItemType{ ItemID = 0x0046, ItemName = "Zinc", ItemDescription = "Raises the base Sp. Def stat of one Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0047, new Structures.ItemType{ ItemID = 0x0047, ItemName = "PP Max", ItemDescription = "Raises the PP of a move to its maximum points.", PocketType = Structures.PocketType.Items}},
            {0x0049, new Structures.ItemType{ ItemID = 0x0049, ItemName = "Guard Spec.", ItemDescription = "Prevents stat reduction when used in battle.", PocketType = Structures.PocketType.Items}},
            {0x004A, new Structures.ItemType{ ItemID = 0x004A, ItemName = "Dire Hit", ItemDescription = "Raises the critical-hit ratio during one battle.", PocketType = Structures.PocketType.Items}},
            {0x004B, new Structures.ItemType{ ItemID = 0x004B, ItemName = "X Attack", ItemDescription = "Raises the stat Attack during one battle.", PocketType = Structures.PocketType.Items}},
            {0x004C, new Structures.ItemType{ ItemID = 0x004C, ItemName = "X Defend", ItemDescription = "Raises the stat Defense during one battle.", PocketType = Structures.PocketType.Items}},
            {0x004D, new Structures.ItemType{ ItemID = 0x004D, ItemName = "X Speed", ItemDescription = "Raises the stat Speed one battle.", PocketType = Structures.PocketType.Items}},
            {0x004E, new Structures.ItemType{ ItemID = 0x004E, ItemName = "X Accuracy", ItemDescription = "Raises accuracy of attack moves during one battle.", PocketType = Structures.PocketType.Items}},
            {0x004F, new Structures.ItemType{ ItemID = 0x004F, ItemName = "X Special", ItemDescription = "Raises the stat Sp.Atk during one battle.", PocketType = Structures.PocketType.Items}},
            {0x0050, new Structures.ItemType{ ItemID = 0x0050, ItemName = "Poke Doll", ItemDescription = "Use to flee from any battle with a wild Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0051, new Structures.ItemType{ ItemID = 0x0051, ItemName = "Fluffy Tail", ItemDescription = "Use to flee from any battle with a wild Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0053, new Structures.ItemType{ ItemID = 0x0053, ItemName = "Super Repel", ItemDescription = "Repels weak wild Pokemon for 200 steps.", PocketType = Structures.PocketType.Items}},
            {0x0054, new Structures.ItemType{ ItemID = 0x0054, ItemName = "Max Repel", ItemDescription = "Repels weak wild Pokemon for 250 steps.", PocketType = Structures.PocketType.Items}},
            {0x0055, new Structures.ItemType{ ItemID = 0x0055, ItemName = "Escape Rope", ItemDescription = "Use to escape instantly from a cave or dungeon.", PocketType = Structures.PocketType.Items}},
            {0x0056, new Structures.ItemType{ ItemID = 0x0056, ItemName = "Repel", ItemDescription = "Repels weak wild Pokemon for 100 steps.", PocketType = Structures.PocketType.Items}},
            {0x005D, new Structures.ItemType{ ItemID = 0x005D, ItemName = "Sun Stone", ItemDescription = "Makes certain species of Pokemon evolve.", PocketType = Structures.PocketType.Items}},
            {0x005E, new Structures.ItemType{ ItemID = 0x005E, ItemName = "Moon Stone", ItemDescription = "Makes certain species of Pokemon evolve.", PocketType = Structures.PocketType.Items}},
            {0x005F, new Structures.ItemType{ ItemID = 0x005F, ItemName = "Fire Stone", ItemDescription = "Makes certain species of Pokemon evolve.", PocketType = Structures.PocketType.Items}},
            {0x0060, new Structures.ItemType{ ItemID = 0x0060, ItemName = "Thunderstone", ItemDescription = "Makes certain species of Pokemon evolve.", PocketType = Structures.PocketType.Items}},
            {0x0061, new Structures.ItemType{ ItemID = 0x0061, ItemName = "Water Stone", ItemDescription = "Makes certain species of Pokemon evolve.", PocketType = Structures.PocketType.Items}},
            {0x0062, new Structures.ItemType{ ItemID = 0x0062, ItemName = "Leaf Stone", ItemDescription = "Makes certain species of Pokemon evolve.", PocketType = Structures.PocketType.Items}},
            {0x0067, new Structures.ItemType{ ItemID = 0x0067, ItemName = "TinyMushroom", ItemDescription = "A plain mushroom that would sell at a cheap price.", PocketType = Structures.PocketType.Items}},
            {0x0068, new Structures.ItemType{ ItemID = 0x0068, ItemName = "Big Mushroom", ItemDescription = "A rare mushroom that would sell at a high price.", PocketType = Structures.PocketType.Items}},
            {0x006A, new Structures.ItemType{ ItemID = 0x006A, ItemName = "Pearl", ItemDescription = "A pretty pearl. Can be sold cheaply.", PocketType = Structures.PocketType.Items}},
            {0x006B, new Structures.ItemType{ ItemID = 0x006B, ItemName = "Big Pearl", ItemDescription = "A lovely large pearl that would sell at a high price.", PocketType = Structures.PocketType.Items}},
            {0x006C, new Structures.ItemType{ ItemID = 0x006C, ItemName = "Stardust", ItemDescription = "Beautiful red sand. Can be sold at a high price.", PocketType = Structures.PocketType.Items}},
            {0x006D, new Structures.ItemType{ ItemID = 0x006D, ItemName = "Star Piece", ItemDescription = "A red gem shard. It would sell for a very high price.", PocketType = Structures.PocketType.Items}},
            {0x006E, new Structures.ItemType{ ItemID = 0x006E, ItemName = "Nugget", ItemDescription = "A nugget of pure gold. Can be sold at a high price.", PocketType = Structures.PocketType.Items}},
            {0x006F, new Structures.ItemType{ ItemID = 0x006F, ItemName = "Heart Scale", ItemDescription = "A lovely scale. It is coveted by collectors.", PocketType = Structures.PocketType.Items}},
            {0x0079, new Structures.ItemType{ ItemID = 0x0079, ItemName = "Orange Mail", ItemDescription = "A Zigzagoon-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x007A, new Structures.ItemType{ ItemID = 0x007A, ItemName = "Harbor Mail", ItemDescription = "A Wingull-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x007B, new Structures.ItemType{ ItemID = 0x007B, ItemName = "Glitter Mail", ItemDescription = "A Pikachu-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x007C, new Structures.ItemType{ ItemID = 0x007C, ItemName = "Mech Mail", ItemDescription = "A Magnemite-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x007D, new Structures.ItemType{ ItemID = 0x007D, ItemName = "Wood Mail", ItemDescription = "A Slakoth-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x007E, new Structures.ItemType{ ItemID = 0x007E, ItemName = "Wave Mail", ItemDescription = "A Wailmer-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x007F, new Structures.ItemType{ ItemID = 0x007F, ItemName = "Bead Mail", ItemDescription = "Mail featuring a sketch of the holding Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0080, new Structures.ItemType{ ItemID = 0x0080, ItemName = "Shadow Mail", ItemDescription = "A Duskull-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0081, new Structures.ItemType{ ItemID = 0x0081, ItemName = "Tropic Mail", ItemDescription = "A Bellossom-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0082, new Structures.ItemType{ ItemID = 0x0082, ItemName = "Dream Mail", ItemDescription = "Mail featuring a sketch of the holding Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0083, new Structures.ItemType{ ItemID = 0x0083, ItemName = "Fab Mail", ItemDescription = "A gorgeous-print mail to be held by a Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0084, new Structures.ItemType{ ItemID = 0x0084, ItemName = "Retro Mail", ItemDescription = "Mail featuring the drawings of three Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x0085, new Structures.ItemType{ ItemID = 0x0085, ItemName = "Cheri Berry", ItemDescription = "A hold item that heals paralysis in battle.", PocketType = Structures.PocketType.Berries}},
            {0x0086, new Structures.ItemType{ ItemID = 0x0086, ItemName = "Chesto Berry", ItemDescription = "A hold item that awakens Pokemon in battle.", PocketType = Structures.PocketType.Berries}},
            {0x0087, new Structures.ItemType{ ItemID = 0x0087, ItemName = "Pecha Berry", ItemDescription = "A hold item that heals poisoning in battle.", PocketType = Structures.PocketType.Berries}},
            {0x0088, new Structures.ItemType{ ItemID = 0x0088, ItemName = "Rawst Berry", ItemDescription = "A hold item that heals a burn in battle.", PocketType = Structures.PocketType.Berries}},
            {0x0089, new Structures.ItemType{ ItemID = 0x0089, ItemName = "Aspear Berry", ItemDescription = "A hold item that defrosts Pokemon in battle.", PocketType = Structures.PocketType.Berries}},
            {0x008A, new Structures.ItemType{ ItemID = 0x008A, ItemName = "Leppa Berry", ItemDescription = "A hold item that restores 10 PP in battle.", PocketType = Structures.PocketType.Berries}},
            {0x008B, new Structures.ItemType{ ItemID = 0x008B, ItemName = "Oran Berry", ItemDescription = "A hold item that restores 10 HP in battle.", PocketType = Structures.PocketType.Berries}},
            {0x008C, new Structures.ItemType{ ItemID = 0x008C, ItemName = "Persim Berry", ItemDescription = "A hold item that heals confusion in battle.", PocketType = Structures.PocketType.Berries}},
            {0x008D, new Structures.ItemType{ ItemID = 0x008D, ItemName = "Lum Berry", ItemDescription = "A hold item that heals any status problem in battle.", PocketType = Structures.PocketType.Berries}},
            {0x008E, new Structures.ItemType{ ItemID = 0x008E, ItemName = "Sitrus Berry", ItemDescription = "A hold item that restores 30 HP in battle.", PocketType = Structures.PocketType.Berries}},
            {0x008F, new Structures.ItemType{ ItemID = 0x008F, ItemName = "Figy Berry", ItemDescription = "A hold item that restores HP but may confuse.", PocketType = Structures.PocketType.Berries}},
            {0x0090, new Structures.ItemType{ ItemID = 0x0090, ItemName = "Wiki Berry", ItemDescription = "A hold item that restores HP but may confuse.", PocketType = Structures.PocketType.Berries}},
            {0x0091, new Structures.ItemType{ ItemID = 0x0091, ItemName = "Mago Berry", ItemDescription = "A hold item that restores HP but may confuse.", PocketType = Structures.PocketType.Berries}},
            {0x0092, new Structures.ItemType{ ItemID = 0x0092, ItemName = "Aguav Berry", ItemDescription = "A hold item that restores HP but may confuse.", PocketType = Structures.PocketType.Berries}},
            {0x0093, new Structures.ItemType{ ItemID = 0x0093, ItemName = "Iapapa Berry", ItemDescription = "A hold item that restores HP but may confuse.", PocketType = Structures.PocketType.Berries}},
            {0x0094, new Structures.ItemType{ ItemID = 0x0094, ItemName = "Razz Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Razz.", PocketType = Structures.PocketType.Berries}},
            {0x0095, new Structures.ItemType{ ItemID = 0x0095, ItemName = "Bluk Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Bluk.", PocketType = Structures.PocketType.Berries}},
            {0x0096, new Structures.ItemType{ ItemID = 0x0096, ItemName = "Nanab Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Nanab.", PocketType = Structures.PocketType.Berries}},
            {0x0097, new Structures.ItemType{ ItemID = 0x0097, ItemName = "Wepear Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Wepear.", PocketType = Structures.PocketType.Berries}},
            {0x0098, new Structures.ItemType{ ItemID = 0x0098, ItemName = "Pinap Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Pinap.", PocketType = Structures.PocketType.Berries}},
            {0x0099, new Structures.ItemType{ ItemID = 0x0099, ItemName = "Pomeg Berry", ItemDescription = "Makes a Pokemon friendly but lowers base HP.", PocketType = Structures.PocketType.Berries}},
            {0x009A, new Structures.ItemType{ ItemID = 0x009A, ItemName = "Kelpsy Berry", ItemDescription = "Makes a Pokemon friendly but lowers base Attack.", PocketType = Structures.PocketType.Berries}},
            {0x009B, new Structures.ItemType{ ItemID = 0x009B, ItemName = "Qualot Berry", ItemDescription = "Makes a Pokemon friendly but lowers base Defense.", PocketType = Structures.PocketType.Berries}},
            {0x009C, new Structures.ItemType{ ItemID = 0x009C, ItemName = "Hondew Berry", ItemDescription = "Makes a Pokemon friendly but lowers base Sp.Atk.", PocketType = Structures.PocketType.Berries}},
            {0x009D, new Structures.ItemType{ ItemID = 0x009D, ItemName = "Grepa Berry", ItemDescription = "Makes a Pokemon friendly but lowers base Sp.Def.", PocketType = Structures.PocketType.Berries}},
            {0x009E, new Structures.ItemType{ ItemID = 0x009E, ItemName = "Tamato Berry", ItemDescription = "Makes a Pokemon friendly but lowers base Speed.", PocketType = Structures.PocketType.Berries}},
            {0x009F, new Structures.ItemType{ ItemID = 0x009F, ItemName = "Cornn Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Cornn.", PocketType = Structures.PocketType.Berries}},
            {0x00A0, new Structures.ItemType{ ItemID = 0x00A0, ItemName = "Magost Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Magost.", PocketType = Structures.PocketType.Berries}},
            {0x00A1, new Structures.ItemType{ ItemID = 0x00A1, ItemName = "Rabuta Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Rabuta.", PocketType = Structures.PocketType.Berries}},
            {0x00A2, new Structures.ItemType{ ItemID = 0x00A2, ItemName = "Nomel Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Nomel.", PocketType = Structures.PocketType.Berries}},
            {0x00A3, new Structures.ItemType{ ItemID = 0x00A3, ItemName = "Spelon Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Spelon.", PocketType = Structures.PocketType.Berries}},
            {0x00A4, new Structures.ItemType{ ItemID = 0x00A4, ItemName = "Pamtre Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Pamtre.", PocketType = Structures.PocketType.Berries}},
            {0x00A5, new Structures.ItemType{ ItemID = 0x00A5, ItemName = "Watmel Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Watmel.", PocketType = Structures.PocketType.Berries}},
            {0x00A6, new Structures.ItemType{ ItemID = 0x00A6, ItemName = "Durin Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Durin.", PocketType = Structures.PocketType.Berries}},
            {0x00A7, new Structures.ItemType{ ItemID = 0x00A7, ItemName = "Belue Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow Belue.", PocketType = Structures.PocketType.Berries}},
            {0x00A8, new Structures.ItemType{ ItemID = 0x00A8, ItemName = "Liechi Berry", ItemDescription = "A hold item that raises Attack in a pinch.", PocketType = Structures.PocketType.Berries}},
            {0x00A9, new Structures.ItemType{ ItemID = 0x00A9, ItemName = "Ganlon Berry", ItemDescription = "A hold item that raises Defense in a pinch.", PocketType = Structures.PocketType.Berries}},
            {0x00AA, new Structures.ItemType{ ItemID = 0x00AA, ItemName = "Salac Berry", ItemDescription = "A hold item that raises Speed in a pinch.", PocketType = Structures.PocketType.Berries}},
            {0x00AB, new Structures.ItemType{ ItemID = 0x00AB, ItemName = "Petaya Berry", ItemDescription = "A hold item that raises Sp.Atk in a pinch.", PocketType = Structures.PocketType.Berries}},
            {0x00AC, new Structures.ItemType{ ItemID = 0x00AC, ItemName = "Apicot Berry", ItemDescription = "A hold item that raises Sp.Def in a pinch.", PocketType = Structures.PocketType.Berries}},
            {0x00AD, new Structures.ItemType{ ItemID = 0x00AD, ItemName = "Lansat Berry", ItemDescription = "A hold item that ups the critical-hit rate in a pinch.", PocketType = Structures.PocketType.Berries}},
            {0x00AE, new Structures.ItemType{ ItemID = 0x00AE, ItemName = "Starf Berry", ItemDescription = "A hold item that sharply boosts a stat in a pinch.", PocketType = Structures.PocketType.Berries}},
            {0x00AF, new Structures.ItemType{ ItemID = 0x00AF, ItemName = "Enigma Berry", ItemDescription = "Pokeblock ingredient. Plant in loamy soil to grow a mystery.", PocketType = Structures.PocketType.Berries}},
            {0x00B3, new Structures.ItemType{ ItemID = 0x00B3, ItemName = "Bright Powder", ItemDescription = "A hold item that casts a glare to reduce accuracy.", PocketType = Structures.PocketType.Items}},
            {0x00B4, new Structures.ItemType{ ItemID = 0x00B4, ItemName = "White Herb", ItemDescription = "A hold item that restores any lowered stat.", PocketType = Structures.PocketType.Items}},
            {0x00B5, new Structures.ItemType{ ItemID = 0x00B5, ItemName = "Macho Brace", ItemDescription = "A hold item that promotes growth, but it reduces Speed.", PocketType = Structures.PocketType.Items}},
            {0x00B6, new Structures.ItemType{ ItemID = 0x00B6, ItemName = "Exp. Share", ItemDescription = "A hold item that gets Exp. points from battles.", PocketType = Structures.PocketType.Items}},
            {0x00B7, new Structures.ItemType{ ItemID = 0x00B7, ItemName = "Quick Claw", ItemDescription = "A hold item that occasionally allows first strike.", PocketType = Structures.PocketType.Items}},
            {0x00B8, new Structures.ItemType{ ItemID = 0x00B8, ItemName = "Soothe Bell", ItemDescription = "A held item that calms spirits and fosters friendship.", PocketType = Structures.PocketType.Items}},
            {0x00B9, new Structures.ItemType{ ItemID = 0x00B9, ItemName = "Mental Herb", ItemDescription = "A hold item that snaps Pokemon out of infatuation.", PocketType = Structures.PocketType.Items}},
            {0x00BA, new Structures.ItemType{ ItemID = 0x00BA, ItemName = "Choice Band", ItemDescription = "Raises a move's power, but permits only that move.", PocketType = Structures.PocketType.Items}},
            {0x00BB, new Structures.ItemType{ ItemID = 0x00BB, ItemName = "King's Rock", ItemDescription = "A hold item that may cause flinching when a foe is hit.", PocketType = Structures.PocketType.Items}},
            {0x00BC, new Structures.ItemType{ ItemID = 0x00BC, ItemName = "SilverPowder", ItemDescription = "A hold item that raises the power of Bug-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00BD, new Structures.ItemType{ ItemID = 0x00BD, ItemName = "Amulet Coin", ItemDescription = "Doubles money in battle if the holder takes part.", PocketType = Structures.PocketType.Items}},
            {0x00BE, new Structures.ItemType{ ItemID = 0x00BE, ItemName = "Cleanse Tag", ItemDescription = "A hold item that helps repel wild Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x00BF, new Structures.ItemType{ ItemID = 0x00BF, ItemName = "Soul Dew", ItemDescription = "Soul Dew is a held item that raises the Special Attack and Special Defense of Latios or Latias by 50% when held.", PocketType = Structures.PocketType.Items}},
            {0x00C0, new Structures.ItemType{ ItemID = 0x00C0, ItemName = "DeepSeaTooth", ItemDescription = "A hold item that raises the Sp. Atk of Clamperl.", PocketType = Structures.PocketType.Items}},
            {0x00C1, new Structures.ItemType{ ItemID = 0x00C1, ItemName = "DeepSeaScale", ItemDescription = "A hold item that raises the Sp. Def of Clamperl.", PocketType = Structures.PocketType.Items}},
            {0x00C2, new Structures.ItemType{ ItemID = 0x00C2, ItemName = "Smoke Ball", ItemDescription = "A hold item that assures fleeing from a wild Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x00C3, new Structures.ItemType{ ItemID = 0x00C3, ItemName = "Everstone", ItemDescription = "A wondrous stone a hold item that prevents evolution.", PocketType = Structures.PocketType.Items}},
            {0x00C4, new Structures.ItemType{ ItemID = 0x00C4, ItemName = "Focus Band", ItemDescription = "A hold item that occasionally prevents fainting.", PocketType = Structures.PocketType.Items}},
            {0x00C5, new Structures.ItemType{ ItemID = 0x00C5, ItemName = "Lucky Egg", ItemDescription = "A hold item that boosts EXP. points earned in battle.", PocketType = Structures.PocketType.Items}},
            {0x00C6, new Structures.ItemType{ ItemID = 0x00C6, ItemName = "Scope Lens", ItemDescription = "A hold item that improves the critical-hit rate.", PocketType = Structures.PocketType.Items}},
            {0x00C7, new Structures.ItemType{ ItemID = 0x00C7, ItemName = "Metal Coat", ItemDescription = "A hold item that raises the power of Steel-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00C8, new Structures.ItemType{ ItemID = 0x00C8, ItemName = "Leftovers", ItemDescription = "A hold item that gradually restores HP in a battle.", PocketType = Structures.PocketType.Items}},
            {0x00C9, new Structures.ItemType{ ItemID = 0x00C9, ItemName = "Dragon Scale", ItemDescription = "A strange scale held by Dragon-Type Pokemon.", PocketType = Structures.PocketType.Items}},
            {0x00CA, new Structures.ItemType{ ItemID = 0x00CA, ItemName = "Light Ball", ItemDescription = "A hold item that raises the Sp. Atk of Pikachu.", PocketType = Structures.PocketType.Items}},
            {0x00CB, new Structures.ItemType{ ItemID = 0x00CB, ItemName = "Soft Sand", ItemDescription = "A hold item that raises the power of Ground-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00CC, new Structures.ItemType{ ItemID = 0x00CC, ItemName = "Hard Stone", ItemDescription = "A hold item that raises the power of Rock-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00CD, new Structures.ItemType{ ItemID = 0x00CD, ItemName = "Miracle Seed", ItemDescription = "A hold item that raises the power of Grass-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00CE, new Structures.ItemType{ ItemID = 0x00CE, ItemName = "BlackGlasses", ItemDescription = "A hold item that raises the power of Dark-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00CF, new Structures.ItemType{ ItemID = 0x00CF, ItemName = "Black Belt", ItemDescription = "A hold item that boosts Fighting-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D0, new Structures.ItemType{ ItemID = 0x00D0, ItemName = "Magnet", ItemDescription = "A hold item that boosts Electric-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D1, new Structures.ItemType{ ItemID = 0x00D1, ItemName = "Mystic Water", ItemDescription = "A hold item that raises the power of Water-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D2, new Structures.ItemType{ ItemID = 0x00D2, ItemName = "Sharp Beak", ItemDescription = "A hold item that raises the power of Flying-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D3, new Structures.ItemType{ ItemID = 0x00D3, ItemName = "Poison Barb", ItemDescription = "A hold item that raises the power of Poison-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D4, new Structures.ItemType{ ItemID = 0x00D4, ItemName = "NeverMeltIce", ItemDescription = "A hold item that raises the power of Ice-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D5, new Structures.ItemType{ ItemID = 0x00D5, ItemName = "Spell Tag", ItemDescription = "A hold item that raises the power of Ghost-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D6, new Structures.ItemType{ ItemID = 0x00D6, ItemName = "TwistedSpoon", ItemDescription = "A hold item that boosts Psychic-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D7, new Structures.ItemType{ ItemID = 0x00D7, ItemName = "Charcoal", ItemDescription = "A hold item that raises the power of Fire-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D8, new Structures.ItemType{ ItemID = 0x00D8, ItemName = "Dragon Fang", ItemDescription = "A hold item that raises the power of Dragon-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00D9, new Structures.ItemType{ ItemID = 0x00D9, ItemName = "Silk Scarf", ItemDescription = "A hold item that raises the power of Normal-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00DA, new Structures.ItemType{ ItemID = 0x00DA, ItemName = "Up-Grade", ItemDescription = "A peculiar box made by Silph Co.", PocketType = Structures.PocketType.Items}},
            {0x00DB, new Structures.ItemType{ ItemID = 0x00DB, ItemName = "Shell Bell", ItemDescription = "A hold item that restores HP upon striking the foe.", PocketType = Structures.PocketType.Items}},
            {0x00DC, new Structures.ItemType{ ItemID = 0x00DC, ItemName = "Sea Incense", ItemDescription = "A hold item that slightly boosts Water-type moves.", PocketType = Structures.PocketType.Items}},
            {0x00DD, new Structures.ItemType{ ItemID = 0x00DD, ItemName = "Lax Incense", ItemDescription = "A hold item that slightly lowers the foe's accuracy.", PocketType = Structures.PocketType.Items}},
            {0x00DE, new Structures.ItemType{ ItemID = 0x00DE, ItemName = "Lucky Punch", ItemDescription = "A hold item that raises Chansey's critical-hit rate.", PocketType = Structures.PocketType.Items}},
            {0x00DF, new Structures.ItemType{ ItemID = 0x00DF, ItemName = "Metal Powder", ItemDescription = "A hold item that raises Ditto's Defense.", PocketType = Structures.PocketType.Items}},
            {0x00E0, new Structures.ItemType{ ItemID = 0x00E0, ItemName = "Thick Club", ItemDescription = "A bone of some sort. It can be sold cheaply.", PocketType = Structures.PocketType.Items}},
            {0x00E1, new Structures.ItemType{ ItemID = 0x00E1, ItemName = "Stick", ItemDescription = "A stick of leek. It can be sold cheaply.", PocketType = Structures.PocketType.Items}},
            {0x00FE, new Structures.ItemType{ ItemID = 0x00FE, ItemName = "Red Scarf", ItemDescription = "A hold item that raises COOL in CONTESTS.", PocketType = Structures.PocketType.Items}},
            {0x00FF, new Structures.ItemType{ ItemID = 0x00FF, ItemName = "Blue Scarf", ItemDescription = "A hold item that raises BEAUTY in CONTESTS.", PocketType = Structures.PocketType.Items}},
            {0x0100, new Structures.ItemType{ ItemID = 0x0100, ItemName = "Pink Scarf", ItemDescription = "A hold item that raises CUTE in CONTESTS.", PocketType = Structures.PocketType.Items}},
            {0x0101, new Structures.ItemType{ ItemID = 0x0101, ItemName = "Green Scarf", ItemDescription = "A hold item that raises SMART in CONTESTS.", PocketType = Structures.PocketType.Items}},
            {0x0102, new Structures.ItemType{ ItemID = 0x0102, ItemName = "Yellow Scarf", ItemDescription = "A hold item that raises TOUGH in CONTESTS.", PocketType = Structures.PocketType.Items}},
            {0x0103, new Structures.ItemType{ ItemID = 0x0103, ItemName = "Mach Bike", ItemDescription = "A folding bicycle that doubles your speed or better.", PocketType = Structures.PocketType.KeyItems}},
            {0x0104, new Structures.ItemType{ ItemID = 0x0104, ItemName = "Coin Case", ItemDescription = "A case that holds up to 9,999 coins.", PocketType = Structures.PocketType.KeyItems}},
            {0x0105, new Structures.ItemType{ ItemID = 0x0105, ItemName = "Itemfinder", ItemDescription = "A device that signals an invisible item by sound.", PocketType = Structures.PocketType.KeyItems}},
            {0x0106, new Structures.ItemType{ ItemID = 0x0106, ItemName = "Old Rod", ItemDescription = "Use by any body of water to fish for wild Pokemon.", PocketType = Structures.PocketType.KeyItems}},
            {0x0107, new Structures.ItemType{ ItemID = 0x0107, ItemName = "Good Rod", ItemDescription = "A decent fishing rod for catching wild Pokemon.", PocketType = Structures.PocketType.KeyItems}},
            {0x0108, new Structures.ItemType{ ItemID = 0x0108, ItemName = "Super Rod", ItemDescription = "The best fishing rod for catching wild Pokemon.", PocketType = Structures.PocketType.KeyItems}},
            {0x0109, new Structures.ItemType{ ItemID = 0x0109, ItemName = "S.S. Ticket", ItemDescription = "The ticket required for sailing on a ferry.", PocketType = Structures.PocketType.KeyItems}},
            {0x010A, new Structures.ItemType{ ItemID = 0x010A, ItemName = "Contest Pass", ItemDescription = "The pass required for entering Pokemon Contests. It has a drawing of an award ribbon on it.", PocketType = Structures.PocketType.KeyItems}},
            {0x010C, new Structures.ItemType{ ItemID = 0x010C, ItemName = "Wailmer Pail", ItemDescription = "A tool used for watering Berries and plants.", PocketType = Structures.PocketType.KeyItems}},
            {0x010D, new Structures.ItemType{ ItemID = 0x010D, ItemName = "Devon Goods", ItemDescription = "A package that contains Devon's machine part.", PocketType = Structures.PocketType.KeyItems}},
            {0x010E, new Structures.ItemType{ ItemID = 0x010E, ItemName = "Soot Sack", ItemDescription = "A sack used to gather and hold volcanic ash.", PocketType = Structures.PocketType.KeyItems}},
            {0x010F, new Structures.ItemType{ ItemID = 0x010F, ItemName = "Basement Key", ItemDescription = "The key for New Mauville beneath Mauville City.", PocketType = Structures.PocketType.KeyItems}},
            {0x0110, new Structures.ItemType{ ItemID = 0x0110, ItemName = "Acro Bike", ItemDescription = "A folding bicycle capable of jumps and wheelies.", PocketType = Structures.PocketType.KeyItems}},
            {0x0111, new Structures.ItemType{ ItemID = 0x0111, ItemName = "Pokeblock Case", ItemDescription = "A case for holding Pokeblocks made with a Berry Blender.", PocketType = Structures.PocketType.KeyItems}},
            {0x0112, new Structures.ItemType{ ItemID = 0x0112, ItemName = "Letter", ItemDescription = "An extremely important letter to Steven from the President of the Devon Corporation.", PocketType = Structures.PocketType.KeyItems}},
            {0x0113, new Structures.ItemType{ ItemID = 0x0113, ItemName = "Eon Ticket", ItemDescription = "The ticket required for sailing on a ferry to a distant southern island. It features a drawing of an island.", PocketType = Structures.PocketType.KeyItems}},
            {0x0114, new Structures.ItemType{ ItemID = 0x0114, ItemName = "Red Orb", ItemDescription = "A red, glowing orb said to contain an ancient power.", PocketType = Structures.PocketType.KeyItems}},
            {0x0115, new Structures.ItemType{ ItemID = 0x0115, ItemName = "Blue Orb", ItemDescription = "A blue, glowing orb said to contain an ancient power.", PocketType = Structures.PocketType.KeyItems}},
            {0x0116, new Structures.ItemType{ ItemID = 0x0116, ItemName = "Scanner", ItemDescription = "A device found inside the Abandoned Ship.", PocketType = Structures.PocketType.KeyItems}},
            {0x0117, new Structures.ItemType{ ItemID = 0x0117, ItemName = "Go-Goggles", ItemDescription = "Nifty goggles that protect eyes from desert sandstorms.", PocketType = Structures.PocketType.KeyItems}},
            {0x0118, new Structures.ItemType{ ItemID = 0x0118, ItemName = "Meteorite", ItemDescription = "A meteorite found at Meteor Falls.", PocketType = Structures.PocketType.KeyItems}},
            {0x0119, new Structures.ItemType{ ItemID = 0x0119, ItemName = "Rm. 1 Key", ItemDescription = "A key that opens a door inside the Abandoned Ship.", PocketType = Structures.PocketType.KeyItems}},
            {0x011A, new Structures.ItemType{ ItemID = 0x011A, ItemName = "Rm. 2 Key", ItemDescription = "A key that opens a door inside the Abandoned Ship.", PocketType = Structures.PocketType.KeyItems}},
            {0x011B, new Structures.ItemType{ ItemID = 0x011B, ItemName = "Rm. 4 Key", ItemDescription = "A key that opens a door inside the Abandoned Ship.", PocketType = Structures.PocketType.KeyItems}},
            {0x011C, new Structures.ItemType{ ItemID = 0x011C, ItemName = "Rm. 6 Key", ItemDescription = "A key that opens a door inside the Abandoned Ship.", PocketType = Structures.PocketType.KeyItems}},
            {0x011D, new Structures.ItemType{ ItemID = 0x011D, ItemName = "Storage Key", ItemDescription = "A key that opens the storage hold inside the Abandoned Ship. It is old and looks easily broken.", PocketType = Structures.PocketType.KeyItems}},
            {0x011E, new Structures.ItemType{ ItemID = 0x011E, ItemName = "Root Fossil", ItemDescription = "A fossil of an ancient, seafloor-dwelling Pokemon. It appears to be part of a plant root.", PocketType = Structures.PocketType.KeyItems}},
            {0x011F, new Structures.ItemType{ ItemID = 0x011F, ItemName = "Claw Fossil", ItemDescription = "A fossil of an ancient, seafloor-dwelling Pokemon.", PocketType = Structures.PocketType.KeyItems}},
            {0x0120, new Structures.ItemType{ ItemID = 0x0120, ItemName = "Devon Scope", ItemDescription = "A device by Devon that signals any unseeable Pokemon.", PocketType = Structures.PocketType.KeyItems}},
            {0x0121, new Structures.ItemType{ ItemID = 0x0121, ItemName = "TM01 Focus Punch", ItemDescription = "Powerful, but makes the user flinch if hit by foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0122, new Structures.ItemType{ ItemID = 0x0122, ItemName = "TM02 Dragon Claw", ItemDescription = "Hooks and slashes the foe with long, sharp claws.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0123, new Structures.ItemType{ ItemID = 0x0123, ItemName = "TM03 Water Pulse", ItemDescription = "Generates an ultrasonic wave that may confuse.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0124, new Structures.ItemType{ ItemID = 0x0124, ItemName = "TM04 Calm Mind", ItemDescription = "Raises Sp. Atk and Sp. Def by focusing the mind.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0125, new Structures.ItemType{ ItemID = 0x0125, ItemName = "TM05 Roar", ItemDescription = "A savage roar that makes the foe flee to end the battle.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0126, new Structures.ItemType{ ItemID = 0x0126, ItemName = "TM06 Toxic", ItemDescription = "Poisons the foe with a toxin that gradually worsens.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0127, new Structures.ItemType{ ItemID = 0x0127, ItemName = "TM07 Hail", ItemDescription = "Summons a hailstorm that hurts all types except Ice.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0128, new Structures.ItemType{ ItemID = 0x0128, ItemName = "TM08 Bulk Up", ItemDescription = "Bulks up the body to boost both Attack & Defense.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0129, new Structures.ItemType{ ItemID = 0x0129, ItemName = "TM09 Bullet Seed", ItemDescription = "Shoots 2 to 5 seeds in a row to strike the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x012A, new Structures.ItemType{ ItemID = 0x012A, ItemName = "TM10 Hidden Power", ItemDescription = "The attack power varies among different Pokemon.", PocketType = Structures.PocketType.TMsHMs}},
            {0x012B, new Structures.ItemType{ ItemID = 0x012B, ItemName = "TM11 Sunny Day", ItemDescription = "Raises the power of Fire-type moves for 5 turns.", PocketType = Structures.PocketType.TMsHMs}},
            {0x012C, new Structures.ItemType{ ItemID = 0x012C, ItemName = "TM12 Taunt", ItemDescription = "Enrages the foe so it can only use attack moves.", PocketType = Structures.PocketType.TMsHMs}},
            {0x012D, new Structures.ItemType{ ItemID = 0x012D, ItemName = "TM13 Ice Beam", ItemDescription = "Fires an icy cold beam that may freeze the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x012E, new Structures.ItemType{ ItemID = 0x012E, ItemName = "TM14 Blizzard", ItemDescription = "A brutal snow-and-wind attack that may freeze the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x012F, new Structures.ItemType{ ItemID = 0x012F, ItemName = "TM15 Hyper Beam", ItemDescription = "Powerful, but needs recharging the next turn.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0130, new Structures.ItemType{ ItemID = 0x0130, ItemName = "TM16 Light Screen", ItemDescription = "Creates a wall of light that lowers Sp. Atk damage.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0131, new Structures.ItemType{ ItemID = 0x0131, ItemName = "TM17 Protect", ItemDescription = "Negates all damage, but may fail if used in succession.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0132, new Structures.ItemType{ ItemID = 0x0132, ItemName = "TM18 Rain Dance", ItemDescription = "Raises the power of Water-type moves for 5 turns.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0133, new Structures.ItemType{ ItemID = 0x0133, ItemName = "TM19 Giga Drain", ItemDescription = "Recovers half the HP of the damage this move inflicts.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0134, new Structures.ItemType{ ItemID = 0x0134, ItemName = "TM20 Safeguard", ItemDescription = "Prevents status abnormality with a mystical power.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0135, new Structures.ItemType{ ItemID = 0x0135, ItemName = "TM21 Frustration", ItemDescription = "The less the user likes you, the more powerful this move.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0136, new Structures.ItemType{ ItemID = 0x0136, ItemName = "TM22 SolarBeam", ItemDescription = "Absorbs sunlight in the 1st turn, then attacks next turn.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0137, new Structures.ItemType{ ItemID = 0x0137, ItemName = "TM23 Iron Tail", ItemDescription = "Slams the foe with a hard tail. It may lower Defense.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0138, new Structures.ItemType{ ItemID = 0x0138, ItemName = "TM24 Thunderbolt", ItemDescription = "A strong electrical attack that may paralyze the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0139, new Structures.ItemType{ ItemID = 0x0139, ItemName = "TM25 Thunder", ItemDescription = "A lightning attack that may cause paralysis.", PocketType = Structures.PocketType.TMsHMs}},
            {0x013A, new Structures.ItemType{ ItemID = 0x013A, ItemName = "TM26 Earthquake", ItemDescription = "Causes a quake that has no effect on flying foes.", PocketType = Structures.PocketType.TMsHMs}},
            {0x013B, new Structures.ItemType{ ItemID = 0x013B, ItemName = "TM27 Return", ItemDescription = "The more the user likes you, the more powerful this move.", PocketType = Structures.PocketType.TMsHMs}},
            {0x013C, new Structures.ItemType{ ItemID = 0x013C, ItemName = "TM28 Dig", ItemDescription = "Digs underground the 1st turn, then strikes next turn.", PocketType = Structures.PocketType.TMsHMs}},
            {0x013D, new Structures.ItemType{ ItemID = 0x013D, ItemName = "TM29 Psychic", ItemDescription = "A powerful psychic attack that may lower Sp. Def.", PocketType = Structures.PocketType.TMsHMs}},
            {0x013E, new Structures.ItemType{ ItemID = 0x013E, ItemName = "TM30 Shadow Ball", ItemDescription = "Hurls a dark lump at the foe. It may lower Sp. Def.", PocketType = Structures.PocketType.TMsHMs}},
            {0x013F, new Structures.ItemType{ ItemID = 0x013F, ItemName = "TM31 Brick Break", ItemDescription = "Destroys barriers like Light Screen and causes damage.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0140, new Structures.ItemType{ ItemID = 0x0140, ItemName = "TM32 Double Team", ItemDescription = "Creates illusory copies to enhance elusiveness.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0141, new Structures.ItemType{ ItemID = 0x0141, ItemName = "TM33 Reflect", ItemDescription = "Creates a wall of light that weakens physical attacks.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0142, new Structures.ItemType{ ItemID = 0x0142, ItemName = "TM34 Shock Wave", ItemDescription = "Zaps the foe with a jolt of electricity that never misses.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0143, new Structures.ItemType{ ItemID = 0x0143, ItemName = "TM35 Flamethrower", ItemDescription = "Looses a stream of fire that may burn the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0144, new Structures.ItemType{ ItemID = 0x0144, ItemName = "TM36 Sludge Bomb", ItemDescription = "Hurls sludge at the foe. It may poison the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0145, new Structures.ItemType{ ItemID = 0x0145, ItemName = "TM37 Sandstorm", ItemDescription = "Causes a sandstorm that hits the foe over several turns.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0146, new Structures.ItemType{ ItemID = 0x0146, ItemName = "TM38 Fire Blast", ItemDescription = "A powerful fire attack that may burn the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0147, new Structures.ItemType{ ItemID = 0x0147, ItemName = "TM39 Rock Tomb", ItemDescription = "Stops the foe from moving with rocks. May lower Speed.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0148, new Structures.ItemType{ ItemID = 0x0148, ItemName = "TM40 Aerial Ace", ItemDescription = "An extremely fast attack that can't be avoided.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0149, new Structures.ItemType{ ItemID = 0x0149, ItemName = "TM41 Torment", ItemDescription = "Prevents the foe from using the same move in a row.", PocketType = Structures.PocketType.TMsHMs}},
            {0x014A, new Structures.ItemType{ ItemID = 0x014A, ItemName = "TM42 Facade", ItemDescription = "Raises Attack when poisoned, burned, or paralyzed.", PocketType = Structures.PocketType.TMsHMs}},
            {0x014B, new Structures.ItemType{ ItemID = 0x014B, ItemName = "TM43 Secret Power", ItemDescription = "Adds an effect to attack depending on the location.", PocketType = Structures.PocketType.TMsHMs}},
            {0x014C, new Structures.ItemType{ ItemID = 0x014C, ItemName = "TM44 Rest", ItemDescription = "The user sleeps for 2 turns to restore health and status.", PocketType = Structures.PocketType.TMsHMs}},
            {0x014D, new Structures.ItemType{ ItemID = 0x014D, ItemName = "TM45 Attract", ItemDescription = "Makes it tough to attack a foe of the opposite gender.", PocketType = Structures.PocketType.TMsHMs}},
            {0x014E, new Structures.ItemType{ ItemID = 0x014E, ItemName = "TM46 Thief", ItemDescription = "While attacking, it may steal the foe's held item.", PocketType = Structures.PocketType.TMsHMs}},
            {0x014F, new Structures.ItemType{ ItemID = 0x014F, ItemName = "TM47 Steel Wing", ItemDescription = "Spreads hard-edged wings and slams into the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0150, new Structures.ItemType{ ItemID = 0x0150, ItemName = "TM48 Skill Swap", ItemDescription = "Switches abilities with the foe on the turn this is used.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0151, new Structures.ItemType{ ItemID = 0x0151, ItemName = "TM49 Snatch", ItemDescription = "Steals the effects of the move the foe is trying to use.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0152, new Structures.ItemType{ ItemID = 0x0152, ItemName = "TM50 Overheat", ItemDescription = "Enables full-power attack, but sharply lowers the Sp.Atk.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0153, new Structures.ItemType{ ItemID = 0x0153, ItemName = "HM01 Cut", ItemDescription = "Attacks the foe with sharp blades or claws.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0154, new Structures.ItemType{ ItemID = 0x0154, ItemName = "HM02 Fly", ItemDescription = "Flies up on the first turn, then attacks next turn.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0155, new Structures.ItemType{ ItemID = 0x0155, ItemName = "HM03 Surf", ItemDescription = "Creates a huge wave, then crashes it down on the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0156, new Structures.ItemType{ ItemID = 0x0156, ItemName = "HM04 Strength", ItemDescription = "Builds enormous power, then slams the foe.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0157, new Structures.ItemType{ ItemID = 0x0157, ItemName = "HM05 Flash", ItemDescription = "Looses a powerful blast of light that reduces accuracy.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0158, new Structures.ItemType{ ItemID = 0x0158, ItemName = "HM06 Rock Smash", ItemDescription = "A rock-crushingly tough attack that may lower Defense.", PocketType = Structures.PocketType.TMsHMs}},
            {0x0159, new Structures.ItemType{ ItemID = 0x0159, ItemName = "HM07 Waterfall", ItemDescription = "Attacks the foe with enough power to climb waterfalls.", PocketType = Structures.PocketType.TMsHMs}},
            {0x015A, new Structures.ItemType{ ItemID = 0x015A, ItemName = "HM08 Dive", ItemDescription = "Dives underwater the 1st turn, then attacks next turn.", PocketType = Structures.PocketType.TMsHMs}},
            {0x015D, new Structures.ItemType{ ItemID = 0x015D, ItemName = "Oak's Parcel", ItemDescription = "A parcel for Prof. Oak from a Pokemon Mart's clerk. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x015E, new Structures.ItemType{ ItemID = 0x015E, ItemName = "Poke Flute", ItemDescription = "A sweet-sounding flute that awakens Pokemon. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x015F, new Structures.ItemType{ ItemID = 0x015F, ItemName = "Secret Key", ItemDescription = "The key to the Cinnabar Island Gym's entrance. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0160, new Structures.ItemType{ ItemID = 0x0160, ItemName = "Bike Voucher", ItemDescription = "A voucher for obtaining a bicycle from the bike shop. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0161, new Structures.ItemType{ ItemID = 0x0161, ItemName = "Gold Teeth", ItemDescription = "Gold dentures lost by the Safari Zone's Warden. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0162, new Structures.ItemType{ ItemID = 0x0162, ItemName = "Old Amber", ItemDescription = "A stone containing the genes of an ancient Pokemon. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0163, new Structures.ItemType{ ItemID = 0x0163, ItemName = "Card Key", ItemDescription = "A card-type door key used in Silph Co's office. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0164, new Structures.ItemType{ ItemID = 0x0164, ItemName = "Lift Key", ItemDescription = "An elevator key used in Team Rocket's hideout. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0165, new Structures.ItemType{ ItemID = 0x0165, ItemName = "Dome Fossil", ItemDescription = "A piece of ancient marine Pokemon's shell. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0166, new Structures.ItemType{ ItemID = 0x0166, ItemName = "Helix Fossil", ItemDescription = "A piece of an ancient marine Pokemon's seashell. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0167, new Structures.ItemType{ ItemID = 0x0167, ItemName = "Silph Scope", ItemDescription = "Silph Co's scope makes unseeable Pokemon visible. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0168, new Structures.ItemType{ ItemID = 0x0168, ItemName = "Bicycle", ItemDescription = "A folding bicycle that is faster than the Running Shoes. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0169, new Structures.ItemType{ ItemID = 0x0169, ItemName = "Town Map", ItemDescription = "Can be viewed anytime. Shows your present location. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x016A, new Structures.ItemType{ ItemID = 0x016A, ItemName = "Vs. Seeker", ItemDescription = "A rechargeable unit that flags battle-ready Trainers. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x016B, new Structures.ItemType{ ItemID = 0x016B, ItemName = "Fame Checker", ItemDescription = "Stores information on famous people for instant recall. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x016C, new Structures.ItemType{ ItemID = 0x016C, ItemName = "TM Case", ItemDescription = "A convenient case that holds TMs and HMs. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x016D, new Structures.ItemType{ ItemID = 0x016D, ItemName = "Berry Pouch", ItemDescription = "A convenient container that holds Berries. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x016E, new Structures.ItemType{ ItemID = 0x016E, ItemName = "Teachy TV", ItemDescription = "A TV set tuned to an advice program for Trainers. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x016F, new Structures.ItemType{ ItemID = 0x016F, ItemName = "Tri-Pass", ItemDescription = "A pass for ferries between One, Two, and Three Island. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0170, new Structures.ItemType{ ItemID = 0x0170, ItemName = "Rainbow Pass", ItemDescription = "For ferries serving Vermilion and the Sevii Islands. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0171, new Structures.ItemType{ ItemID = 0x0171, ItemName = "Tea", ItemDescription = "A thirst-quenching tea prepared by an old lady. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0172, new Structures.ItemType{ ItemID = 0x0172, ItemName = "MysticTicket", ItemDescription = "A ticket required to board the ship to Navel Rock. It glows with a mystic light.", PocketType = Structures.PocketType.KeyItems}},
            {0x0173, new Structures.ItemType{ ItemID = 0x0173, ItemName = "AuroraTicket", ItemDescription = "A ticket required to board the ship to Birth Island. It glows beautifully.", PocketType = Structures.PocketType.KeyItems}},
            {0x0174, new Structures.ItemType{ ItemID = 0x0174, ItemName = "Powder Jar", ItemDescription = "Stores Berry Powder made using a Berry Crusher.", PocketType = Structures.PocketType.KeyItems}},
            {0x0175, new Structures.ItemType{ ItemID = 0x0175, ItemName = "Ruby", ItemDescription = "An exquisite, red-glowing gem that symbolizes passion. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0176, new Structures.ItemType{ ItemID = 0x0176, ItemName = "Sapphire", ItemDescription = "A brilliant blue gem that symbolizes honesty. FRLG-Item", PocketType = Structures.PocketType.KeyItems}},
            {0x0177, new Structures.ItemType{ ItemID = 0x0177, ItemName = "Magma Emblem", ItemDescription = "A medal-like item in the same shape as Team Magma's mark.", PocketType = Structures.PocketType.KeyItems}},
            {0x0178, new Structures.ItemType{ ItemID = 0x0178, ItemName = "Old Sea Map", ItemDescription = "A faded sea chart that shows the way to a certain island.", PocketType = Structures.PocketType.KeyItems}}
        };
        #endregion
        /// <summary>
        /// Pristupa kolekciji predmeta
        /// </summary>
        public static Dictionary<ushort, Structures.ItemType> ItemTypes 
        {
            get { return _itemTypes; }
        }

        /// <summary>
        /// Velicina cijele torbe u byteovima 0x2E8
        /// </summary>
        public const int bagSizeinBytes = 0x2E8;
        /// <summary>
        /// Velicina cijele torbe u byteovima 0x298 Ruby Sapphire
        /// </summary>
        public const int bagSizeinBytesRubySapphire = 0x298;

        #endregion

        #region Offsets
        /// <summary>
        /// Offset za spol playera 0x08
        /// </summary>
        public const byte playerGenderOffset = 0x08;
        /// <summary>
        /// Offset za trainer ID 0x0A
        /// </summary>
        public const byte playerTrainerIDOffset = 0x0A;
        /// <summary>
        /// Offset za EncryptionKey 0xAC
        /// </summary>
        public const byte playerEncryptionKeyOffset = 0xAC;
        /// <summary>
        /// Offset za money 0x1410
        /// </summary>
        public const ushort playerMoneyOffset = 0x1410;
        /// <summary>
        /// Offset za coins 0x1414
        /// </summary>
        public const ushort playerCoinsOffset = 0x1414;
        /// <summary>
        /// Offset za torbu 0x14E0
        /// </summary>
        public const ushort bagOffset = 0x14E0;
        /// <summary>
        /// Offset za pokemone spremljene u storage-u 0x4D84
        /// </summary>
        public const ushort pokemonStorageOffset = 0x4D84;
        /// <summary>
        /// Offset za pokedex pokemona koji su uhvaceni 0x28
        /// </summary>
        public const byte pokedexOwnOffset = 0x28;
        /// <summary>
        /// Offset za pokedex pokemona koji su videni 0x5C
        /// </summary>
        public const byte pokedexSeenOffset = 0x5C;
        /// <summary>
        /// Offset za pokedex pokemona koji su videni 0x1908
        /// </summary>
        public const ushort pokedexSeenOffset2 = 0x1908;
        /// <summary>
        /// Offset za pokedex pokemona koji su videni 0x4AA4
        /// </summary>
        public const ushort pokedexSeenOffset3 = 0x4AA4;

        /// <summary>
        /// Offset za pokedex pokemona koji su videni 0x1578
        /// </summary>
        public const ushort pokedexSeenOffsetFireLeaf2 = 0x1578;
        /// <summary>
        /// Offset za pokedex pokemona koji su videni 0x4998
        /// </summary>
        public const ushort pokedexSeenOffsetFireLeaf3 = 0x4998;

        /// <summary>
        /// Offset za pokedex pokemona koji su videni 0x18B8
        /// </summary>
        public const ushort pokedexSeenOffsetRubySapphire2 = 0x18B8;
        /// <summary>
        /// Offset za pokedex pokemona koji su videni 0x4A0C
        /// </summary>
        public const ushort pokedexSeenOffsetRubySapphire3 = 0x4A0C;

        #region Fire Red Leaf Green
        /// <summary>
        /// Offset za EncryptionKey FireLeaf 0xF20
        /// </summary>
        public const ushort playerEncryptionKeyOffsetFireLeaf = 0xF20;
        /// <summary>
        /// Offset za money FireLeaf 0x1210
        /// </summary>
        public const ushort playerMoneyOffsetFireLeaf = 0x1210;
        /// <summary>
        /// Offset za coins FireLeaf 0x1214
        /// </summary>
        public const ushort playerCoinsOffsetFireLeaf = 0x1214;
        /// <summary>
        /// Offset za torbu FireLeaf 0x1290
        /// </summary>
        public const ushort bagOffsetFireLeaf = 0x1290;
        #endregion

        #endregion

        #region Pokemon Stuff
        /// <summary>
        /// Velicina Pokemon Strukture 0x50
        /// </summary>
        public const byte pokemonStructureSize = 0x50;
        /// <summary>
        /// Velicina Pokemon Storage-a 0x83BE
        /// </summary>
        public const ushort pokemonStorageSize = 0x83BE;
        #endregion

        #region Sve vezano za pokemone podaci
        #region Natures
        private static Dictionary<byte, Natures> _natures = new Dictionary<byte, Natures> 
        { 
            {0,new Natures(0,"Hardy","-","-","-","-")},
            {1,new Natures(1,"Lonely","Attack","Defense","Spicy","Sour")},
            {2,new Natures(2,"Brave","Attack","Speed","Spicy","Sweet")},
            {3,new Natures(3,"Adamant","Attack","Sp.Attack ","Spicy","Dry")},
            {4,new Natures(4,"Naughty","Attack","Sp.Defense","Spicy","Bitter")},
            {5,new Natures(5,"Bold","Defense","Attack","Sour","Spicy")},
            {6,new Natures(6,"Docile","-","-","-","-")},
            {7,new Natures(7,"Relaxed","Defense","Speed","Sour","Sweet")},
            {8,new Natures(8,"Impish","Defense","Sp.Attack","Sour","Dry")},
            {9,new Natures(9,"Lax","Defense","Sp.Defense","Sour","Bitter")},
            {10,new Natures(10,"Timid","Speed","Attack","Sweet","Spicy")},
            {11,new Natures(11,"Hasty","Speed","Defense","Sweet","Sour")},
            {12,new Natures(12,"Serious","-","-","-","-")},
            {13,new Natures(13,"Jolly","Speed","Sp.Attack","Sweet","Dry")},
            {14,new Natures(14,"Naive","Speed","Sp.Defense","Sweet","Bitter")},
            {15,new Natures(15,"Modest","Sp.Attack","Attack","Dry","Spicy")},
            {16,new Natures(16,"Mild","Sp.Attack","Defense","Dry","Sour")},
            {17,new Natures(17,"Quiet","Sp.Attack","Speed","Dry","Sweet")},
            {18,new Natures(18,"Bashful","-","-","-","-")},
            {19,new Natures(19,"Rash","Sp.Attack","Sp.Defense","Dry","Bitter")},
            {20,new Natures(20,"Calm","Sp.Defense","Attack","Bitter","Spicy")},
            {21,new Natures(21,"Gentle","Sp.Defense","Defense","Bitter","Sour")},
            {22,new Natures(22,"Sassy","Sp.Defense","Speed","Bitter","Sweet")},
            {23,new Natures(23,"Careful","Sp.Defense","Sp. Attack","Bitter","Dry")},
            {24,new Natures(24,"Quirky","-","-","-","-")}
        };
        /// <summary>
        /// Pristupa kolekciji Nature-a
        /// </summary>
        public static Dictionary<byte, Natures> Natures
        {
            get { return _natures; }
        }
        #endregion
        #region Locations
        private static Dictionary<byte, Locations> _locations = new Dictionary<byte, Locations> 
        {
            {000,new Locations(000,"Littleroot Town")},
            {001,new Locations(001,"Oldale Town")},
            {002,new Locations(002,"Dewford Town")},
            {003,new Locations(003,"Lavaridge Town")},
            {004,new Locations(004,"Fallarbor Town")},
            {005,new Locations(005,"Verdanturf Town")},
            {006,new Locations(006,"Pacifidlog Town")},
            {007,new Locations(007,"Petalburg City")},
            {008,new Locations(008,"Slateport City")},
            {009,new Locations(009,"Mauville City")},
            {010,new Locations(010,"Rustboro City")},
            {011,new Locations(011,"Fortree City")},
            {012,new Locations(012,"Lilycove City")},
            {013,new Locations(013,"Mossdeep City")},
            {014,new Locations(014,"Sootopolis City")},
            {015,new Locations(015,"Ever Grande City")},
            {016,new Locations(016,"Route 101")},
            {017,new Locations(017,"Route 102")},
            {018,new Locations(018,"Route 103")},
            {019,new Locations(019,"Route 104")},
            {020,new Locations(020,"Route 105")},
            {021,new Locations(021,"Route 106")},
            {022,new Locations(022,"Route 107")},
            {023,new Locations(023,"Route 108")},
            {024,new Locations(024,"Route 109")},
            {025,new Locations(025,"Route 110")},
            {026,new Locations(026,"Route 111")},
            {027,new Locations(027,"Route 112")},
            {028,new Locations(028,"Route 113")},
            {029,new Locations(029,"Route 114")},
            {030,new Locations(030,"Route 115")},
            {031,new Locations(031,"Route 116")},
            {032,new Locations(032,"Route 117")},
            {033,new Locations(033,"Route 118")},
            {034,new Locations(034,"Route 119")},
            {035,new Locations(035,"Route 120")},
            {036,new Locations(036,"Route 121")},
            {037,new Locations(037,"Route 122")},
            {038,new Locations(038,"Route 123")},
            {039,new Locations(039,"Route 124")},
            {040,new Locations(040,"Route 125")},
            {041,new Locations(041,"Route 126")},
            {042,new Locations(042,"Route 127")},
            {043,new Locations(043,"Route 128")},
            {044,new Locations(044,"Route 129")},
            {045,new Locations(045,"Route 130")},
            {046,new Locations(046,"Route 131")},
            {047,new Locations(047,"Route 132")},
            {048,new Locations(048,"Route 133")},
            {049,new Locations(049,"Route 134")},
            {050,new Locations(050,"Underwater (Route 124)")},
            {051,new Locations(051,"Underwater (Route 126)")},
            {052,new Locations(052,"Underwater (Route 127)")},
            {053,new Locations(053,"Underwater (Route 128)")},
            {054,new Locations(054,"Underwater (Sootopolis City)")},
            {055,new Locations(055,"Battle Tower")},
            {056,new Locations(056,"Mt.Chimney")},
            {057,new Locations(057,"Safari Zone")},
            {058,new Locations(058,"Battle Frontier")},
            {059,new Locations(059,"Petalburg Woods")},
            {060,new Locations(060,"Rusturf Tunnel")},
            {061,new Locations(061,"Abandoned Ship")},
            {062,new Locations(062,"New Mauville")},
            {063,new Locations(063,"Meteor Falls")},
            {064,new Locations(064,"Meteor Falls (Unused)")},
            {065,new Locations(065,"Mt.Pyre")},
            {066,new Locations(066,"Aqua/Magma Hideout")},
            {067,new Locations(067,"Shoal Cave")},
            {068,new Locations(068,"Seafloor Cavern")},
            {069,new Locations(069,"Underwater (Seafloor Cavern)")},
            {070,new Locations(070,"Victory Road")},
            {071,new Locations(071,"Mirage Island")},
            {072,new Locations(072,"Cave of Origin")},
            {073,new Locations(073,"Southern Island")},
            {074,new Locations(074,"Fiery Path")},
            {075,new Locations(075,"Fiery Path")},
            {076,new Locations(076,"Jagged Pass")},
            {077,new Locations(077,"Jagged Pass")},
            {078,new Locations(078,"Sealed Chamber")},
            {079,new Locations(079,"Underwater (Route 134)")},
            {080,new Locations(080,"Scorched Slab")},
            {081,new Locations(081,"Island Cave")},
            {082,new Locations(082,"Desert Ruins")},
            {083,new Locations(083,"Ancient Tomb")},
            {084,new Locations(084,"Inside of Truck")},
            {085,new Locations(085,"Sky Pillar")},
            {086,new Locations(086,"Secret Base")},
            {087,new Locations(087,"Ferry")},
            {088,new Locations(088,"Pallet Town")},
            {089,new Locations(089,"Viridian City")},
            {090,new Locations(090,"Pewter City")},
            {091,new Locations(091,"Cerulean City")},
            {092,new Locations(092,"Lavender Town")},
            {093,new Locations(093,"Vermilion City")},
            {094,new Locations(094,"Celadon City")},
            {095,new Locations(095,"Fuchsia City")},
            {096,new Locations(096,"Cinnabar Island")},
            {097,new Locations(097,"Indigo Plateau")},
            {098,new Locations(098,"Saffron City")},
            {099,new Locations(099,"Route 4 (Pokemon Center)")},
            {100,new Locations(100,"Route 10 (Pokemon Center)")},
            {101,new Locations(101,"Route 1")},
            {102,new Locations(102,"Route 2")},
            {103,new Locations(103,"Route 3")},
            {104,new Locations(104,"Route 4")},
            {105,new Locations(105,"Route 5")},
            {106,new Locations(106,"Route 6")},
            {107,new Locations(107,"Route 7")},
            {108,new Locations(108,"Route 8")},
            {109,new Locations(109,"Route 9")},
            {110,new Locations(110,"Route 10")},
            {111,new Locations(111,"Route 11")},
            {112,new Locations(112,"Route 12")},
            {113,new Locations(113,"Route 13")},
            {114,new Locations(114,"Route 14")},
            {115,new Locations(115,"Route 15")},
            {116,new Locations(116,"Route 16")},
            {117,new Locations(117,"Route 17")},
            {118,new Locations(118,"Route 18")},
            {119,new Locations(119,"Route 19")},
            {120,new Locations(120,"Route 20")},
            {121,new Locations(121,"Route 21")},
            {122,new Locations(122,"Route 22")},
            {123,new Locations(123,"Route 23")},
            {124,new Locations(124,"Route 24")},
            {125,new Locations(125,"Route 25")},
            {126,new Locations(126,"Viridian Forest")},
            {127,new Locations(127,"Mt.Moon")},
            {128,new Locations(128,"S.S.Anne")},
            {129,new Locations(129,"Underground Path (Routes 5-6)")},
            {130,new Locations(130,"Underground Path (Routes 7-8)")},
            {131,new Locations(131,"Diglett's Cave")},
            {132,new Locations(132,"Victory Road")},
            {133,new Locations(133,"Rocket Hideout")},
            {134,new Locations(134,"Silph Co.")},
            {135,new Locations(135,"Pokemon Mansion")},
            {136,new Locations(136,"Safari Zone")},
            {137,new Locations(137,"Pokemon League")},
            {138,new Locations(138,"Rock Tunnel")},
            {139,new Locations(139,"Seafoam Islands")},
            {140,new Locations(140,"Pokemon Tower")},
            {141,new Locations(141,"Cerulean Cave")},
            {142,new Locations(142,"Power Plant")},
            {143,new Locations(143,"One Island")},
            {144,new Locations(144,"Two Island")},
            {145,new Locations(145,"Three Island")},
            {146,new Locations(146,"Four Island")},
            {147,new Locations(147,"Five Island")},
            {148,new Locations(148,"Seven Island")},
            {149,new Locations(149,"Six Island")},
            {150,new Locations(150,"Kindle Road")},
            {151,new Locations(151,"Treasure Beach")},
            {152,new Locations(152,"Cape Brink")},
            {153,new Locations(153,"Bond Bridge")},
            {154,new Locations(154,"Three Isle Port")},
            {155,new Locations(155,"Sevii Isle 6")},
            {156,new Locations(156,"Sevii Isle 7")},
            {157,new Locations(157,"Sevii Isle 8")},
            {158,new Locations(158,"Sevii Isle 9")},
            {159,new Locations(159,"Resort Gorgeous")},
            {160,new Locations(160,"Water Labyrinth")},
            {161,new Locations(161,"Five Isle Meadow")},
            {162,new Locations(162,"Memorial Pillar")},
            {163,new Locations(163,"Outcast Island")},
            {164,new Locations(164,"Green Path")},
            {165,new Locations(165,"Water Path")},
            {166,new Locations(166,"Ruin Valley")},
            {167,new Locations(167,"Trainer Tower")},
            {168,new Locations(168,"Canyon Entrance")},
            {169,new Locations(169,"Sevault Canyon")},
            {170,new Locations(170,"Tanoby Ruins")},
            {171,new Locations(171,"Sevii Isle 22")},
            {172,new Locations(172,"Sevii Isle 23")},
            {173,new Locations(173,"Sevii Isle 24")},
            {174,new Locations(174,"Navel Rock")},
            {175,new Locations(175,"Mt.Ember")},
            {176,new Locations(176,"Berry Forest")},
            {177,new Locations(177,"Icefall Cave")},
            {178,new Locations(178,"Rocket Warehouse")},
            {179,new Locations(179,"Trainer Tower")},
            {180,new Locations(180,"Dotted Hole")},
            {181,new Locations(181,"Lost Cave")},
            {182,new Locations(182,"Pattern Bush")},
            {183,new Locations(183,"Altering Cave")},
            {184,new Locations(184,"Tanoby Chambers")},
            {185,new Locations(185,"Three Isle Path")},
            {186,new Locations(186,"Tanoby Key")},
            {187,new Locations(187,"Birth Island")},
            {188,new Locations(188,"Monean Chamber")},
            {189,new Locations(189,"Liptoo Chamber")},
            {190,new Locations(190,"Weepth Chamber")},
            {191,new Locations(191,"Dilford Chamber")},
            {192,new Locations(192,"Scufib Chamber")},
            {193,new Locations(193,"Rixy Chamber")},
            {194,new Locations(194,"Viapois Chamber")},
            {195,new Locations(195,"Ember Spa")},
            {196,new Locations(196,"Special Area")},
            {197,new Locations(197,"Aqua Hideout")},
            {198,new Locations(198,"Magma Hideout")},
            {199,new Locations(199,"Mirage Tower")},
            {200,new Locations(200,"Birth Island")},
            {201,new Locations(201,"Faraway Island")},
            {202,new Locations(202,"Artisan Cave")},
            {203,new Locations(203,"Marine Cave")},
            {204,new Locations(204,"Underwater (Marine Cave)")},
            {205,new Locations(205,"Terra Cave")},
            {206,new Locations(206,"Underwater (Marine Cave)")},
            {207,new Locations(207,"Underwater (Marine Cave)")},
            {208,new Locations(208,"Underwater (Marine Cave)")},
            {209,new Locations(209,"Desert Underpass")},
            {210,new Locations(210,"Altering Cave")},
            {211,new Locations(211,"Navel Rock")},
            {212,new Locations(212,"Trainer Hill")},
            {254,new Locations(254,"In-game trade")},
            {255,new Locations(255,"Fateful encounter")}
        };

        /// <summary>
        /// Pristupa kolekciji Locations
        /// </summary>
        public static Dictionary<byte, Locations> Locations
        {
            get { return _locations; }
        }
        #endregion
        #region XP
        private static Dictionary<byte, Experience> _experiences = new Dictionary<byte, Experience>
        {
            {1,new Experience(1,0,0,0,0,0,0)},
            {2,new Experience(2,15,6,8,9,10,4)},
            {3,new Experience(3,52,21,27,57,33,13)},
            {4,new Experience(4,122,51,64,96,80,32)},
            {5,new Experience(5,237,100,125,135,156,65)},
            {6,new Experience(6,406,172,216,179,270,112)},
            {7,new Experience(7,637,274,343,236,428,178)},
            {8,new Experience(8,942,409,512,314,640,276)},
            {9,new Experience(9,1326,583,729,419,911,393)},
            {10,new Experience(10,1800,800,1000,560,1250,540)},
            {11,new Experience(11,2369,1064,1331,742,1663,745)},
            {12,new Experience(12,3041,1382,1728,973,2160,967)},
            {13,new Experience(13,3822,1757,2197,1261,2746,1230)},
            {14,new Experience(14,4719,2195,2744,1612,3430,1591)},
            {15,new Experience(15,5737,2700,3375,2035,4218,1957)},
            {16,new Experience(16,6881,3276,4096,2535,5120,2457)},
            {17,new Experience(17,8155,3930,4913,3120,6141,3046)},
            {18,new Experience(18,9564,4665,5832,3798,7290,3732)},
            {19,new Experience(19,11111,5487,6859,4575,8573,4526)},
            {20,new Experience(20,12800,6400,8000,5460,10000,5440)},
            {21,new Experience(21,14632,7408,9261,6458,11576,6482)},
            {22,new Experience(22,16610,8518,10648,7577,13310,7666)},
            {23,new Experience(23,18737,9733,12167,8825,15208,9003)},
            {24,new Experience(24,21012,11059,13824,10208,17280,10506)},
            {25,new Experience(25,23437,12500,15625,11735,19531,12187)},
            {26,new Experience(26,26012,14060,17576,13411,21970,14060)},
            {27,new Experience(27,28737,15746,19683,15244,24603,16140)},
            {28,new Experience(28,31610,17561,21952,17242,27440,18439)},
            {29,new Experience(29,34632,19511,24389,19411,30486,20974)},
            {30,new Experience(30,37800,21600,27000,21760,33750,23760)},
            {31,new Experience(31,41111,23832,29791,24294,37238,26811)},
            {32,new Experience(32,44564,26214,32768,27021,40960,30146)},
            {33,new Experience(33,48155,28749,35937,29949,44921,33780)},
            {34,new Experience(34,51881,31443,39304,33084,49130,37731)},
            {35,new Experience(35,55737,34300,42875,36435,53593,42017)},
            {36,new Experience(36,59719,37324,46656,40007,58320,46656)},
            {37,new Experience(37,63822,40522,50653,43808,63316,50653)},
            {38,new Experience(38,68041,43897,54872,47846,68590,55969)},
            {39,new Experience(39,72369,47455,59319,52127,74148,60505)},
            {40,new Experience(40,76800,51200,64000,56660,80000,66560)},
            {41,new Experience(41,81326,55136,68921,61450,86151,71677)},
            {42,new Experience(42,85942,59270,74088,66505,92610,78533)},
            {43,new Experience(43,90637,63605,79507,71833,99383,84277)},
            {44,new Experience(44,95406,68147,85184,77440,106480,91998)},
            {45,new Experience(45,100237,72900,91125,83335,113906,98415)},
            {46,new Experience(46,105122,77868,97336,89523,121670,107069)},
            {47,new Experience(47,110052,83058,103823,96012,129778,114205)},
            {48,new Experience(48,115015,88473,110592,102810,138240,123863)},
            {49,new Experience(49,120001,94119,117649,109923,147061,131766)},
            {50,new Experience(50,125000,100000,125000,117360,156250,142500)},
            {51,new Experience(51,131324,106120,132651,125126,165813,151222)},
            {52,new Experience(52,137795,112486,140608,133229,175760,163105)},
            {53,new Experience(53,144410,119101,148877,141677,186096,172697)},
            {54,new Experience(54,151165,125971,157464,150476,196830,185807)},
            {55,new Experience(55,158056,133100,166375,159635,207968,196322)},
            {56,new Experience(56,165079,140492,175616,169159,219520,210739)},
            {57,new Experience(57,172229,148154,185193,179056,231491,222231)},
            {58,new Experience(58,179503,156089,195112,189334,243890,238036)},
            {59,new Experience(59,186894,164303,205379,199999,256723,250562)},
            {60,new Experience(60,194400,172800,216000,211060,270000,267840)},
            {61,new Experience(61,202013,181584,226981,222522,283726,281456)},
            {62,new Experience(62,209728,190662,238328,234393,297910,300293)},
            {63,new Experience(63,217540,200037,250047,246681,312558,315059)},
            {64,new Experience(64,225443,209715,262144,259392,327680,335544)},
            {65,new Experience(65,233431,219700,274625,272535,343281,351520)},
            {66,new Experience(66,241496,229996,287496,286115,359370,373744)},
            {67,new Experience(67,249633,240610,300763,300140,375953,390991)},
            {68,new Experience(68,257834,251545,314432,314618,393040,415050)},
            {69,new Experience(69,267406,262807,328509,329555,410636,433631)},
            {70,new Experience(70,276458,274400,343000,344960,428750,459620)},
            {71,new Experience(71,286328,286328,357911,360838,447388,479600)},
            {72,new Experience(72,296358,298598,373248,377197,466560,507617)},
            {73,new Experience(73,305767,311213,389017,394045,486271,529063)},
            {74,new Experience(74,316074,324179,405224,411388,506530,559209)},
            {75,new Experience(75,326531,337500,421875,429235,527343,582187)},
            {76,new Experience(76,336255,351180,438976,447591,548720,614566)},
            {77,new Experience(77,346965,365226,456533,466464,570666,639146)},
            {78,new Experience(78,357812,379641,474552,485862,593190,673863)},
            {79,new Experience(79,367807,394431,493039,505791,616298,700115)},
            {80,new Experience(80,378880,409600,512000,526260,640000,737280)},
            {81,new Experience(81,390077,425152,531441,547274,664301,765275)},
            {82,new Experience(82,400293,441094,551368,568841,689210,804997)},
            {83,new Experience(83,411686,457429,571787,590969,714733,834809)},
            {84,new Experience(84,423190,474163,592704,613664,740880,877201)},
            {85,new Experience(85,433572,491300,614125,636935,767656,908905)},
            {86,new Experience(86,445239,508844,636056,660787,795070,954084)},
            {87,new Experience(87,457001,526802,658503,685228,823128,987754)},
            {88,new Experience(88,467489,545177,681472,710266,851840,1035837)},
            {89,new Experience(89,479378,563975,704969,735907,881211,1071552)},
            {90,new Experience(90,491346,583200,729000,762160,911250,1122660)},
            {91,new Experience(91,501878,602856,753571,789030,941963,1160499)},
            {92,new Experience(92,513934,622950,778688,816525,973360,1214753)},
            {93,new Experience(93,526049,643485,804357,844653,1005446,1254796)},
            {94,new Experience(94,536557,664467,830584,873420,1038230,1312322)},
            {95,new Experience(95,548720,685900,857375,902835,1071718,1354652)},
            {96,new Experience(96,560922,707788,884736,932903,1105920,1415577)},
            {97,new Experience(97,571333,730138,912673,963632,1140841,1460276)},
            {98,new Experience(98,583539,752953,941192,995030,1176490,1524731)},
            {99,new Experience(99,591882,776239,970299,1027103,1212873,1571884)},
            {100,new Experience(100,600000,800000,1000000,1059860,1250000,1640000)},
            {101,new Experience(101,600050,800050,1000050,1059880,1250050,1640050)}
        };

        /// <summary>
        /// Pristupa kolekciji Experience
        /// </summary>
        public static Dictionary<byte, Experience> Experiences
        {
            get { return _experiences; }
        }
        #endregion
        #region Abilities
        private static Dictionary<byte, Ability> _abilities = new Dictionary<byte, Ability>
        {
            {0,new Ability(0,"No Ability","No special ability.")},
            {1,new Ability(1,"Stench","The stench helps keep wild Pokemon away.")},
            {2,new Ability(2,"Drizzle","The Pokemon makes it rain if it appears in battle.")},
            {3,new Ability(3,"Speed Boost","The Pokemons Speed stat is gradually boosted.")},
            {4,new Ability(4,"Battle Armor","The Pokemon is protected against critical hits.")},
            {5,new Ability(5,"Sturdy","The Pokemon is protected against 1-hit KO attacks.")},
            {6,new Ability(6,"Damp","Prevents combatants from self destructing.")},
            {7,new Ability(7,"Limber","The Pokemon is protected from paralysis.")},
            {8,new Ability(8,"Sand Veil","Boosts the Pokemons evasion in a sandstorm.")},
            {9,new Ability(9,"Static","Contact with the Pokemon may cause paralysis.")},
            {10,new Ability(10,"Volt Absorb","Restores HP if hit by an Electric-type move.")},
            {11,new Ability(11,"Water Absorb","Restores HP if hit by a Water-type move.")},
            {12,new Ability(12,"Oblivious","Prevents the Pokemon from becoming infatuated.")},
            {13,new Ability(13,"Cloud Nine","Eliminates the effects of weather.")},
            {14,new Ability(14,"Compoundeyes","The Pokemons accuracy is boosted.")},
            {15,new Ability(15,"Insomnia","Prevents the Pokemon from falling asleep.")},
            {16,new Ability(16,"Color Change","Changes the Pokemons type to the foes move.")},
            {17,new Ability(17,"Immunity","Prevents the Pokemon from getting poisoned.")},
            {18,new Ability(18,"Flash Fire","Powers up Fire-type moves if hit by a fire move.")},
            {19,new Ability(19,"Shield Dust","Blocks the added effects of attacks taken.")},
            {20,new Ability(20,"Own Tempo","Prevents the Pokemon from becoming confused.")},
            {21,new Ability(21,"Suction Cups","Negates moves that force switching out.")},
            {22,new Ability(22,"Intimidate","Lowers the foes Attack stat.")},
            {23,new Ability(23,"Shadow Tag","Prevents the foe from escaping.")},
            {24,new Ability(24,"Rough Skin","Inflicts damage to the foe on contact.")},
            {25,new Ability(25,"Wonder Guard","Only super effective moves will hit.")},
            {26,new Ability(26,"Levitate","Gives full immunity to all Ground-type moves.")},
            {27,new Ability(27,"Effect Spore","Contact may paralyze, poison, or cause sleep.")},
            {28,new Ability(28,"Synchronize","Passes on a burn, poison, or paralysis to the foe.")},
            {29,new Ability(29,"Clear Body","Prevents the Pokemons stats from being lowered.")},
            {30,new Ability(30,"Natural Cure","All status problems are healed upon switching out.")},
            {31,new Ability(31,"Lightningrod","The Pokemon draws in all Electric-type moves.")},
            {32,new Ability(32,"Serene Grace","Boosts the likelihood of added effects appearing.")},
            {33,new Ability(33,"Swift Swim","Boosts the Pokemons Speed in rain.")},
            {34,new Ability(34,"Chlorophyll","Boosts the Pokemons Speed in sunshine.")},
            {35,new Ability(35,"Illuminate","Raises the likelihood of meeting wild Pokemon.")},
            {36,new Ability(36,"Trace","The Pokemon copies a foe's Ability.")},
            {37,new Ability(37,"Huge Power","Raises the Pokemons Attack stat.")},
            {38,new Ability(38,"Poison Point","Contact with the Pokemon may poison the foe.")},
            {39,new Ability(39,"Inner Focus","The Pokemon is protected from flinching.")},
            {40,new Ability(40,"Magma Armor","Prevents the Pokemon from becoming frozen.")},
            {41,new Ability(41,"Water Veil","Prevents the Pokemon from getting a burn.")},
            {42,new Ability(42,"Magnet Pull","Prevents Steel-type Pokemon from escaping.")},
            {43,new Ability(43,"Soundproof","Gives full immunity to all sound-based moves.")},
            {44,new Ability(44,"Rain Dish","The Pokemon gradually recovers HP in rain.")},
            {45,new Ability(45,"Sand Stream","The Pokemon summons a sandstorm in battle.")},
            {46,new Ability(46,"Pressure","The Pokemon raises the foes PP usage.")},
            {47,new Ability(47,"Thick Fat","Raises resistance to Fire- and Ice-type moves.")},
            {48,new Ability(48,"Early Bird","The Pokemon awakens quickly from sleep.")},
            {49,new Ability(49,"Flame Body","Contact with the Pokemon may burn the foe.")},
            {50,new Ability(50,"Run Away","Enables sure getaway from wild Pokemon.")},
            {51,new Ability(51,"Keen Eye","Prevents the Pokemon from losing accuracy.")},
            {52,new Ability(52,"Hyper Cutter","Prevents the Attack stat from being lowered.")},
            {53,new Ability(53,"Pickup","The Pokemon may pick up items.")},
            {54,new Ability(54,"Truant","The Pokemon can't attack on consecutive turns.")},
            {55,new Ability(55,"Hustle","Boosts the Attack stat, but lowers accuracy.")},
            {56,new Ability(56,"Cute Charm","Contact with the Pokemon may cause infatuation.")},
            {57,new Ability(57,"Plus","Boosts Sp. Atk if another Pokemon has Minus.")},
            {58,new Ability(58,"Minus","Boosts Sp. Atk if another Pokemon has Plus.")},
            {59,new Ability(59,"Forecast","Transforms with the weather.")},
            {60,new Ability(60,"Sticky Hold","Protects the Pokemon from item theft.")},
            {61,new Ability(61,"Shed Skin","The Pokemon may heal its own status problems.")},
            {62,new Ability(62,"Guts","Boosts Attack if there is a status problem.")},
            {63,new Ability(63,"Marvel Scale","Boosts Defense if there is a status problem.")},
            {64,new Ability(64,"Liquid Ooze","Inflicts damage on foes using any draining move.")},
            {65,new Ability(65,"Overgrow","Powers up Grass-type moves in a pinch.")},
            {66,new Ability(66,"Blaze","Powers up Fire-type moves in a pinch.")},
            {67,new Ability(67,"Torrent","Powers up Water-type moves in a pinch.")},
            {68,new Ability(68,"Swarm","Powers up Bug-type moves in a pinch.")},
            {69,new Ability(69,"Rock Head","Protects the Pokemon from recoil damage.")},
            {70,new Ability(70,"Drought","The Pokemon makes it sunny if it is in battle.")},
            {71,new Ability(71,"Arena Trap","Prevents the foe from fleeing.")},
            {72,new Ability(72,"Vital Spirit","Prevents the Pokemon from falling asleep.")},
            {73,new Ability(73,"White Smoke","Prevents the Pokemons stats from being lowered.")},
            {74,new Ability(74,"Pure Power","Boosts the power of physical attacks.")},
            {75,new Ability(75,"Shell Armor","The Pokemon is protected against critical hits.")},
            {76,new Ability(76,"Air Lock","Eliminates the effects of weather.")}
        };

        /// <summary>
        /// Pristupa kolekciji Abilities
        /// </summary>
        public static Dictionary<byte, Ability> Abilities
        {
            get { return _abilities; }
        }
        #endregion
        #region Moves
        private static Dictionary<ushort, Move> _moves = new Dictionary<ushort, Move>
        {
            {000,new Move(000,"Empty Move","Nothing","Nothing","Nothing",0,"0","0%","None")},
            {001,new Move(001,"Pound","Normal","Physical","Tough",35,"40","100%","Pounds the foe with forelegs or tail.")},
            {002,new Move(002,"Karate Chop","Fighting","Physical","Tough",25,"50","100%","A chopping attack with a high critical-hit ratio.")},
            {003,new Move(003,"DoubleSlap","Normal","Physical","Tough",10,"15","85%","Repeatedly slaps the foe 2 to 5 times.")},
            {004,new Move(004,"Comet Punch","Normal","Physical","Tough",15,"18","85%","Repeatedly punches the foe 2 to 5 times.")},
            {005,new Move(005,"Mega Punch","Normal","Physical","Tough",20,"80","85%","A strong punch thrown with incredible power.")},
            {006,new Move(006,"Pay Day","Normal","Physical","Smart",20,"40","100%","Throws coins at the foe. Money is recovered after.")},
            {007,new Move(007,"Fire Punch","Fire","Physical","Beauty",15,"75","100%","A fiery punch that may burn the foe.")},
            {008,new Move(008,"Ice Punch","Ice","Physical","Beauty",15,"75","100%","An icy punch that may freeze the foe.")},
            {009,new Move(009,"ThunderPunch","Electric","Physical","Cool",15,"75","100%","An electrified punch that may paralyze the foe.")},
            {010,new Move(010,"Scratch","Normal","Physical","Tough",35,"40","100%","Scratches the foe with sharp claws.")},
            {011,new Move(011,"ViceGrip","Normal","Physical","Tough",30,"55","100%","Grips the foe with large and powerful pincers.")},
            {012,new Move(012,"Guillotine","Normal","Physical","Cool",5,"-","-","A powerful pincer attack that may cause fainting.")},
            {013,new Move(013,"Razor Wind","Normal","Special","Cool",10,"80","100%","A 2-turn move that strikes the foe on the 2nd turn.")},
            {014,new Move(014,"Swords Dance","Normal","Status","Beauty",30,"-","-","A fighting dance that sharply raises Attack.")},
            {015,new Move(015,"Cut","Normal","Physical","Cool",30,"50","95%","Attacks the foe with sharp blades or claws.")},
            {016,new Move(016,"Gust","Flying","Special","Smart",35,"40","100%","Strikes the foe with a gust of wind whipped up by wings.")},
            {017,new Move(017,"Wing Attack","Flying","Physical","Cool",35,"60","100%","Strikes the foe with wings spread wide.")},
            {018,new Move(018,"Whirlwind","Normal","Status","Smart",20,"-","100%","Blows away the foe with wind and ends the battle.")},
            {019,new Move(019,"Fly","Flying","Physical","Smart",15,"70","95%","Flies up on the first turn, then attacks next turn.")},
            {020,new Move(020,"Bind","Normal","Physical","Tough",20,"15","75%","Binds and squeezes the foe for 2 to 5 turns.")},
            {021,new Move(021,"Slam","Normal","Physical","Tough",20,"80","75%","Slams the foe with a long tail, vine, etc.")},
            {022,new Move(022,"Vine Whip","Grass","Physical","Cool",10,"35","100%","Strikes the foe with slender, whiplike vines.")},
            {023,new Move(023,"Stomp","Normal","Physical","Tough",20,"65","100%","Stomps the enemy with a big foot. May cause flinching.")},
            {024,new Move(024,"Double Kick","Fighting","Physical","Cool",30,"30","100%","A double-kicking attack that strikes the foe twice.")},
            {025,new Move(025,"Mega Kick","Normal","Physical","Cool",5,"120","75%","An extremely powerful kick with intense force.")},
            {026,new Move(026,"Jump Kick","Fighting","Physical","Cool",25,"70","95%","A strong jumping kick. May miss and hurt the kicker.")},
            {027,new Move(027,"Rolling Kick","Fighting","Physical","Cool",15,"60","85%","A fast kick delivered from a rapid spin.")},
            {028,new Move(028,"Sand-Attack","Ground","Status","Cute",15,"-","100%","Reduces the foe's accuracy by hurling sand in its face.")},
            {029,new Move(029,"Headbutt","Normal","Physical","Tough",15,"70","100%","A ramming attack that may cause flinching.")},
            {030,new Move(030,"Horn Attack","Normal","Physical","Cool",25,"65","100%","Jabs the foe with sharp horns.")},
            {031,new Move(031,"Fury Attack","Normal","Physical","Cool",20,"15","85%","Jabs the foe 2 to 5 times with sharp horns, etc.")},
            {032,new Move(032,"Horn Drill","Normal","Physical","Cool",5,"-","-","A one-hit KO attack that uses a horn like a drill.")},
            {033,new Move(033,"Tackle","Normal","Physical","Tough",30,"35","95%","Charges the foe with a full-body tackle.")},
            {034,new Move(034,"Body Slam","Normal","Physical","Tough",15,"85","100%","A full-body slam that may cause paralysis.")},
            {035,new Move(035,"Wrap","Normal","Physical","Tough",20,"15","85%","Wraps and squeezes the foe 2 to 5 times with vines, etc.")},
            {036,new Move(036,"Take Down","Normal","Physical","Tough",20,"90","85%","A reckless charge attack that also hurts the user.")},
            {037,new Move(037,"Thrash","Normal","Physical","Tough",20,"90","100%","A rampage of 2 to 3 turns that confuses the user.")},
            {038,new Move(038,"Double-Edge","Normal","Physical","Tough",15,"100","100%","A life-risking tackle that also hurts the user.")},
            {039,new Move(039,"Tail Whip","Normal","Status","Cute",30,"-","100%","Wags the tail to lower the foe's Defense.")},
            {040,new Move(040,"Poison Sting","Poison","Physical","Smart",35,"15","100%","A toxic attack with barbs, etc., that may poison.")},
            {041,new Move(041,"Twineedle","Bug","Physical","Cool",20,"25","100%","Stingers on the forelegs jab the foe twice.")},
            {042,new Move(042,"Pin Missile","Bug","Physical","Cool",20,"14","85%","Sharp pins are fired to strike 2 to 5 times.")},
            {043,new Move(043,"Leer","Normal","Status","Cool",30,"-","100%","Frightens the foe with a leer to lower Defense.")},
            {044,new Move(044,"Bite","Dark","Physical","Tough",25,"60","100%","Bites with vicious fangs. May cause flinching.")},
            {045,new Move(045,"Growl","Normal","Status","Cute",40,"-","100%","Growls cutely to reduce the foe's Attack.")},
            {046,new Move(046,"Roar","Normal","Status","Cool",20,"-","100%","A savage roar that makes the foe flee to end the battle.")},
            {047,new Move(047,"Sing","Normal","Status","Cute",15,"-","55%","A soothing song lulls the foe into a deep slumber.")},
            {048,new Move(048,"Supersonic","Normal","Status","Smart",20,"-","55%","Emits bizarre sound waves that may confuse the foe.")},
            {049,new Move(049,"SonicBoom","Normal","Special","Cool",20,"","90%","Launches shock waves that always inflict 20 HP damage.")},
            {050,new Move(050,"Disable","Normal","Status","Smart",20,"-","80%","Psychically disables one of the foe's moves.")},
            {051,new Move(051,"Acid","Poison","Special","Smart",30,"40","100%","Sprays a hide-melting acid. May lower Defense.")},
            {052,new Move(052,"Ember","Fire","Special","Beauty",25,"40","100%","A weak fire attack that may inflict a burn.")},
            {053,new Move(053,"Flamethrower","Fire","Special","Beauty",15,"95","100%","Looses a stream of fire that may burn the foe.")},
            {054,new Move(054,"Mist","Ice","Status","Beauty",30,"-","-","Creates a mist that stops reduction of abilities.")},
            {055,new Move(055,"Water Gun","Water","Special","Cute",25,"40","100%","Squirts water to attack the foe.")},
            {056,new Move(056,"Hydro Pump","Water","Special","Beauty",5,"120","80%","Blasts water at high power to strike the foe.")},
            {057,new Move(057,"Surf","Water","Special","Beauty",15,"95","100%","Creates a huge wave, then crashes it down on the foe.")},
            {058,new Move(058,"Ice Beam","Ice","Special","Beauty",10,"95","100%","Fires an icy cold beam that may freeze the foe.")},
            {059,new Move(059,"Blizzard","Ice","Special","Beauty",5,"120","70%","A brutal snow-and-wind attack that may freeze the foe.")},
            {060,new Move(060,"Psybeam","Psychic","Special","Beauty",20,"65","100%","Fires a peculiar ray that may confuse the foe.")},
            {061,new Move(061,"BubbleBeam","Water","Special","Beauty",20,"65","100%","Forcefully sprays bubbles that may lower Speed.")},
            {062,new Move(062,"Aurora Beam","Ice","Special","Beauty",20,"65","100%","Fires a rainbow-colored beam that may lower Attack.")},
            {063,new Move(063,"Hyper Beam","Normal","Special","Cool",5,"150","90%","Powerful, but needs recharging the next turn.")},
            {064,new Move(064,"Peck","Flying","Physical","Cool",35,"35","100%","Attacks the foe with a jabbing beak, etc.")},
            {065,new Move(065,"Drill Peck","Flying","Physical","Cool",20,"80","100%","A corkscrewing attack with the beak acting as a drill.")},
            {066,new Move(066,"Submission","Fighting","Physical","Cool",25,"80","80%","A reckless body slam that also hurts the user.")},
            {067,new Move(067,"Low Kick","Fighting","Physical","Tough",20,"-","100%","A kick that inflicts more damage on heavier foes.")},
            {068,new Move(068,"Counter","Fighting","Physical","Tough",20,"-","100%","Retaliates any physical hit with double the power.")},
            {069,new Move(069,"Seismic Toss","Fighting","Physical","Tough",20,"-","100%","Inflicts damage identical to the user's level.")},
            {070,new Move(070,"Strength","Normal","Physical","Tough",15,"80","100%","Builds enormous power, then slams the foe.")},
            {071,new Move(071,"Absorb","Grass","Special","Smart",20,"20","100%","An attack that absorbs half the damage inflicted.")},
            {072,new Move(072,"Mega Drain","Grass","Special","Smart",10,"40","100%","An attack that absorbs half the damage inflicted.")},
            {073,new Move(073,"Leech Seed","Grass","Status","Smart",10,"-","90%","Plants a seed on the foe to steal HP on every turn.")},
            {074,new Move(074,"Growth","Normal","Status","Beauty",40,"-","-","Forces the body to grow and heightens Sp. Atk.")},
            {075,new Move(075,"Razor Leaf","Grass","Physical","Cool",25,"55","95%","Cuts the enemy with leaves. High critical-hit ratio.")},
            {076,new Move(076,"SolarBeam","Grass","Special","Cool",10,"120","100%","Absorbs sunlight in the 1st turn, then attacks next turn.")},
            {077,new Move(077,"PoisonPowder","Poison","Status","Smart",35,"-","75%","Scatters a toxic powder that may poison the foe.")},
            {078,new Move(078,"Stun Spore","Grass","Status","Smart",30,"-","75%","Scatters a powder that may paralyze the foe.")},
            {079,new Move(079,"Sleep Powder","Grass","Status","Smart",15,"-","75%","Scatters a powder that may cause the foe to sleep.")},
            {080,new Move(080,"Petal Dance","Grass","Special","Beauty",20,"70","100%","A rampage of 2 to 3 turns that confuses the user.")},
            {081,new Move(081,"String Shot","Bug","Status","Smart",40,"-","95%","Binds the foe with string to reduce its Speed.")},
            {082,new Move(082,"Dragon Rage","Dragon","Special","Cool",10,"","100%","Launches shock waves that always inflict 40 HP damage.")},
            {083,new Move(083,"Fire Spin","Fire","Special","Beauty",15,"15","70%","Traps the foe in a ring of fire for 2 to 5 turns.")},
            {084,new Move(084,"ThunderShock","Electric","Special","Cool",30,"40","100%","An electrical attack that may paralyze the foe.")},
            {085,new Move(085,"Thunderbolt","Electric","Special","Cool",15,"95","100%","A strong electrical attack that may paralyze the foe.")},
            {086,new Move(086,"Thunder Wave","Electric","Status","Cool",20,"-","100%","A weak jolt of electricity that paralyzes the foe.")},
            {087,new Move(087,"Thunder","Electric","Special","Cool",10,"120","70%","A lightning attack that may cause paralysis.")},
            {088,new Move(088,"Rock Throw","Rock","Physical","Tough",15,"50","90%","Throws small rocks to strike the foe.")},
            {089,new Move(089,"Earthquake","Ground","Physical","Tough",10,"100","100%","Causes a quake that has no effect on flying foes.")},
            {090,new Move(090,"Fissure","Ground","Physical","Tough",5,"-","-","A one-hit KO move that drops the foe in a fissure.")},
            {091,new Move(091,"Dig","Ground","Physical","Smart",10,"60","100%","Digs underground the 1st turn, then strikes next turn.")},
            {092,new Move(092,"Toxic","Poison","Status","Smart",10,"-","85%","Poisons the foe with a toxin that gradually worsens.")},
            {093,new Move(093,"Confusion","Psychic","Special","Smart",25,"50","100%","A psychic attack that may cause confusion.")},
            {094,new Move(094,"Psychic","Psychic","Special","Smart",10,"90","100%","A powerful psychic attack that may lower Sp. Def.")},
            {095,new Move(095,"Hypnosis","Psychic","Status","Smart",20,"-","60%","A hypnotizing move that may induce sleep.")},
            {096,new Move(096,"Meditate","Psychic","Status","Beauty",40,"-","-","Meditates in a peaceful fashion to raise Attack.")},
            {097,new Move(097,"Agility","Psychic","Status","Cool",30,"-","-","Relaxes the body to sharply boost Speed.")},
            {098,new Move(098,"Quick Attack","Normal","Physical","Cool",30,"40","100%","An extremely fast attack that always strikes first.")},
            {099,new Move(099,"Rage","Normal","Physical","Cool",20,"20","100%","Raises the user's Attack every time it is hit.")},
            {100,new Move(100,"Teleport","Psychic","Status","Cool",20,"-","-","A psychic move for fleeing from battle instantly.")},
            {101,new Move(101,"Night Shade","Ghost","Special","Smart",15,"-","100%","Inflicts damage identical to the user's level.")},
            {102,new Move(102,"Mimic","Normal","Status","Cute",10,"-","100%","Copies a move used by the foe during one battle.")},
            {103,new Move(103,"Screech","Normal","Status","Smart",40,"-","85%","Emits a screech to sharply reduce the foe's Defense.")},
            {104,new Move(104,"Double Team","Normal","Status","Cool",15,"-","-","Creates illusory copies to enhance elusiveness.")},
            {105,new Move(105,"Recover","Normal","Status","Smart",20,"-","-","Recovers up to half the user's maximum HP.")},
            {106,new Move(106,"Harden","Normal","Status","Tough",30,"-","-","Stiffens the body's muscles to raise Defense.")},
            {107,new Move(107,"Minimize","Normal","Status","Cute",20,"-","-","Minimizes the user's size to raise evasiveness.")},
            {108,new Move(108,"SmokeScreen","Normal","Status","Smart",20,"-","100%","Lowers the foe's accuracy using smoke, ink, etc.")},
            {109,new Move(109,"Confuse Ray","Ghost","Status","Smart",10,"-","100%","A sinister ray that confuses the foe.")},
            {110,new Move(110,"Withdraw","Water","Status","Cute",40,"-","-","Withdraws the body into its hard shell to raise Defense.")},
            {111,new Move(111,"Defense Curl","Normal","Status","Cute",40,"-","-","Curls up to conceal weak spots and raise Defense.")},
            {112,new Move(112,"Barrier","Psychic","Status","Cool",30,"-","-","Creates a barrier that sharply raises Defense.")},
            {113,new Move(113,"Light Screen","Psychic","Status","Beauty",30,"-","-","Creates a wall of light that lowers Sp. Atk damage.")},
            {114,new Move(114,"Haze","Ice","Status","Beauty",30,"-","-","Creates a black haze that eliminates all stat changes.")},
            {115,new Move(115,"Reflect","Psychic","Status","Smart",20,"-","-","Creates a wall of light that weakens physical attacks.")},
            {116,new Move(116,"Focus Energy","Normal","Status","Cool",30,"-","-","Focuses power to raise the critical-hit ratio.")},
            {117,new Move(117,"Bide","Normal","Physical","Tough",10,"-","100%","Endures attack for 2 turns to retaliate double.")},
            {118,new Move(118,"Metronome","Normal","Status","Cute",10,"-","-","Waggles a finger to use any Pokemon move at random.")},
            {119,new Move(119,"Mirror Move","Flying","Status","Smart",20,"-","-","Counters the foe's attack with the same move.")},
            {120,new Move(120,"Selfdestruct","Normal","Physical","Beauty",5,"200","100%","Inflicts severe damage but makes the user faint.")},
            {121,new Move(121,"Egg Bomb","Normal","Physical","Tough",10,"100","75%","An egg is forcibly hurled at the foe.")},
            {122,new Move(122,"Lick","Ghost","Physical","Tough",30,"20","100%","Licks with a long tongue to injure. May also paralyze.")},
            {123,new Move(123,"Smog","Poison","Special","Tough",20,"20","70%","An exhaust-gas attack that may also poison.")},
            {124,new Move(124,"Sludge","Poison","Special","Tough",20,"65","100%","Sludge is hurled to inflict damage. May also poison.")},
            {125,new Move(125,"Bone Club","Ground","Physical","Tough",20,"65","85%","Clubs the foe with a bone. May cause flinching.")},
            {126,new Move(126,"Fire Blast","Fire","Special","Beauty",5,"120","85%","A powerful fire attack that may burn the foe.")},
            {127,new Move(127,"Waterfall","Water","Physical","Tough",15,"80","100%","Attacks the foe with enough power to climb waterfalls.")},
            {128,new Move(128,"Clamp","Water","Physical","Tough",10,"35","75%","Traps and squeezes the foe for 2 to 5 turns.")},
            {129,new Move(129,"Swift","Normal","Special","Cool",20,"60","-","Sprays star-shaped rays that never miss.")},
            {130,new Move(130,"Skull Bash","Normal","Physical","Tough",15,"100","100%","Tucks in the head, then attacks on the next turn.")},
            {131,new Move(131,"Spike Cannon","Normal","Physical","Cool",15,"20","100%","Launches sharp spikes that strike 2 to 5 times.")},
            {132,new Move(132,"Constrict","Normal","Physical","Tough",35,"10","100%","Constricts to inflict pain. May lower Speed.")},
            {133,new Move(133,"Amnesia","Psychic","Status","Cute",20,"-","-","Forgets about something and sharply raises Sp. Def.")},
            {134,new Move(134,"Kinesis","Psychic","Status","Smart",15,"-","80%","Distracts the foe. May lower accuracy.")},
            {135,new Move(135,"Softboiled","Normal","Status","Beauty",10,"-","-","Recovers up to half the user's maximum HP.")},
            {136,new Move(136,"Hi Jump Kick","Fighting","Physical","Cool",20,"85","90%","A jumping knee kick. If it misses, the user is hurt.")},
            {137,new Move(137,"Glare","Normal","Status","Tough",30,"-","75%","Intimidates and frightens the foe into paralysis.")},
            {138,new Move(138,"Dream Eater","Psychic","Special","Smart",15,"100","100%","Takes one half the damage inflicted on a sleeping foe.")},
            {139,new Move(139,"Poison Gas","Poison","Status","Smart",40,"-","55%","Envelops the foe in a toxic gas that may poison.")},
            {140,new Move(140,"Barrage","Normal","Physical","Tough",20,"15","85%","Hurls round objects at the foe 2 to 5 times.")},
            {141,new Move(141,"Leech Life","Bug","Physical","Smart",15,"20","100%","An attack that steals half the damage inflicted.")},
            {142,new Move(142,"Lovely Kiss","Normal","Status","Beauty",10,"-","75%","Demands a kiss with a scary face that induces sleep.")},
            {143,new Move(143,"Sky Attack","Flying","Physical","Cool",5,"140","90%","Searches out weak spots, then strikes the next turn.")},
            {144,new Move(144,"Transform","Normal","Status","Smart",10,"-","-","Alters the user's cells to become a copy of the foe.")},
            {145,new Move(145,"Bubble","Water","Special","Cute",30,"20","100%","An attack using bubbles. May lower the foe's Speed.")},
            {146,new Move(146,"Dizzy Punch","Normal","Physical","Cool",10,"70","100%","A rhythmic punch that may confuse the foe.")},
            {147,new Move(147,"Spore","Grass","Status","Beauty",15,"-","100%","Scatters a cloud of spores that always induce sleep.")},
            {148,new Move(148,"Flash","Normal","Status","Beauty",20,"-","75%","Looses a powerful blast of light that reduces accuracy.")},
            {149,new Move(149,"Psywave","Psychic","Special","Smart",15,"-","80%","Attacks with a psychic wave of varying intensity.")},
            {150,new Move(150,"Splash","Normal","Status","Cute",40,"-","-","It's just a splash... Has no effect whatsoever.")},
            {151,new Move(151,"Acid Armor","Poison","Status","Tough",40,"-","-","Liquifies the user's body to sharply raise Defense.")},
            {152,new Move(152,"Crabhammer","Water","Physical","Tough",10,"90","85%","Hammers with a pincer. Has a high critical-hit ratio.")},
            {153,new Move(153,"Explosion","Normal","Physical","Beauty",5,"250","100%","Inflicts severe damage but makes the user faint.")},
            {154,new Move(154,"Fury Swipes","Normal","Physical","Tough",15,"18","80%","Rakes the foe with sharp claws, etc., 2 to 5 times.")},
            {155,new Move(155,"Bonemerang","Ground","Physical","Tough",10,"50","90%","Throws a bone boomerang that strikes twice.")},
            {156,new Move(156,"Rest","Psychic","Status","Cute",10,"-","-","The user sleeps for 2 turns to restore health and status.")},
            {157,new Move(157,"Rock Slide","Rock","Physical","Tough",10,"75","90%","Large boulders are hurled. May cause flinching.")},
            {158,new Move(158,"Hyper Fang","Normal","Physical","Cool",15,"80","90%","Attacks with sharp fangs. May cause flinching.")},
            {159,new Move(159,"Sharpen","Normal","Status","Cute",30,"-","-","Reduces the polygon count and raises Attack.")},
            {160,new Move(160,"Conversion","Normal","Status","Beauty",30,"-","-","Changes the user's type into a known move's type.")},
            {161,new Move(161,"Tri Attack","Normal","Special","Beauty",10,"80","100%","Fires three types of beams at the same time.")},
            {162,new Move(162,"Super Fang","Normal","Physical","Tough",10,"-","90%","Attacks with sharp fangs and cuts half the foe's HP.")},
            {163,new Move(163,"Slash","Normal","Physical","Cool",20,"70","100%","Slashes with claws, etc. Has a high critical-hit ratio.")},
            {164,new Move(164,"Substitute","Normal","Status","Smart",10,"-","-","Creates a decoy using 1/4 of the user's maximum HP.")},
            {165,new Move(165,"Struggle","Normal","Physical","Cool",1,"50","100%","Used only if all PP are gone. Also hurts the user a little.")},
            {166,new Move(166,"Sketch","Normal","Status","Smart",1,"-","-","Copies the foe's last move permanently.")},
            {167,new Move(167,"Triple Kick","Fighting","Physical","Cool",10,"10","90%","Kicks the foe 3 times in a row with rising intensity.")},
            {168,new Move(168,"Thief","Dark","Physical","Tough",10,"40","100%","While attacking, it may steal the foe's held item.")},
            {169,new Move(169,"Spider Web","Bug","Status","Smart",10,"-","100%","Ensnares the foe to stop it from fleeing or switching.")},
            {170,new Move(170,"Mind Reader","Normal","Status","Smart",5,"-","100%","Senses the foe's action to ensure the next move's hit.")},
            {171,new Move(171,"Nightmare","Ghost","Status","Smart",15,"-","100%","Inflicts 1/4 damage on a sleeping foe every turn.")},
            {172,new Move(172,"Flame Wheel","Fire","Physical","Beauty",25,"60","100%","A fiery charge attack that may inflict a burn.")},
            {173,new Move(173,"Snore","Normal","Special","Cute",15,"40","100%","A loud attack that can be used only while asleep.")},
            {174,new Move(174,"Curse","Ghost","Status","Tough",10,"-","-","A move that functions differently for Ghosts.")},
            {175,new Move(175,"Flail","Normal","Physical","Cute",15,"-","100%","Inflicts more damage when the user's HP is down.")},
            {176,new Move(176,"Conversion 2","Normal","Status","Beauty",30,"-","100%","Makes the user resistant to the last attack's type.")},
            {177,new Move(177,"Aeroblast","Flying","Special","Cool",5,"100","95%","Launches a vacuumed blast. High critical-hit ratio.")},
            {178,new Move(178,"Cotton Spore","Grass","Status","Beauty",40,"-","85%","Spores cling to the foe, sharply reducing Speed.")},
            {179,new Move(179,"Reversal","Fighting","Physical","Cool",15,"-","100%","Inflicts more damage when the user's HP is down.")},
            {180,new Move(180,"Spite","Ghost","Status","Tough",10,"-","100%","Spitefully cuts the PP of the foe's last move.")},
            {181,new Move(181,"Powder Snow","Ice","Special","Beauty",25,"40","100%","Blasts the foe with a snowy gust. May cause freezing.")},
            {182,new Move(182,"Protect","Normal","Status","Cute",10,"-","-","Negates all damage, but may fail if used in succession.")},
            {183,new Move(183,"Mach Punch","Fighting","Physical","Cool",30,"40","100%","A punch is thrown at wicked speed to strike first.")},
            {184,new Move(184,"Scary Face","Normal","Status","Tough",10,"-","90%","Frightens with a scary face to sharply reduce Speed.")},
            {185,new Move(185,"Faint Attack","Dark","Physical","Smart",20,"60","-","Draws the foe close, then strikes without fail.")},
            {186,new Move(186,"Sweet Kiss","Normal","Status","Cute",10,"-","75%","Demands a kiss with a cute look. May cause confusion.")},
            {187,new Move(187,"Belly Drum","Normal","Status","Cute",10,"-","-","Maximizes Attack while sacrificing HP.")},
            {188,new Move(188,"Sludge Bomb","Poison","Special","Tough",10,"90","100%","Hurls sludge at the foe. It may poison the foe.")},
            {189,new Move(189,"Mud-Slap","Ground","Special","Cute",10,"20","100%","Hurls mud in the foe's face to reduce its accuracy.")},
            {190,new Move(190,"Octazooka","Water","Special","Tough",10,"65","85%","Fires a lump of ink to damage and cut accuracy.")},
            {191,new Move(191,"Spikes","Ground","Status","Smart",20,"-","-","Sets spikes that hurt a foe switching in.")},
            {192,new Move(192,"Zap Cannon","Electric","Special","Cool",5,"120","50%","Powerful and sure to cause paralysis, but inaccurate.")},
            {193,new Move(193,"Foresight","Normal","Status","Smart",40,"-","100%","Negates the foe's efforts to heighten evasiveness.")},
            {194,new Move(194,"Destiny Bond","Ghost","Status","Smart",5,"-","-","If the user faints, the foe is also made to faint.")},
            {195,new Move(195,"Perish Song","Normal","Status","Beauty",5,"-","-","Any Pokemon hearing this song faints in 3 turns.")},
            {196,new Move(196,"Icy Wind","Ice","Special","Beauty",15,"55","95%","A chilling attack that lowers the foe's Speed.")},
            {197,new Move(197,"Detect","Fighting","Status","Cool",5,"-","-","Evades attack, but may fail if used in succession.")},
            {198,new Move(198,"Bone Rush","Ground","Physical","Tough",10,"25","80%","Strikes the foe with a bone in hand 2 to 5 times.")},
            {199,new Move(199,"Lock-On","Normal","Status","Smart",5,"-","100%","Locks on to the foe to ensure the next move hits")},
            {200,new Move(200,"Outrage","Dragon","Physical","Cool",15,"90","100%","A rampage of 2 to 3 turns that confuses the user.")},
            {201,new Move(201,"Sandstorm","Rock","Status","Tough",10,"-","-","Causes a sandstorm that hits the foe over several turns.")},
            {202,new Move(202,"Giga Drain","Grass","Special","Smart",5,"60","100%","Recovers half the HP of the damage this move inflicts.")},
            {203,new Move(203,"Endure","Normal","Status","Tough",10,"-","-","Endures any attack for 1 turn, leaving at least 1 HP.")},
            {204,new Move(204,"Charm","Normal","Status","Cute",20,"-","100%","Charms the foe and sharply reduces its Attack.")},
            {205,new Move(205,"Rollout","Rock","Physical","Tough",20,"30","90%","An attack lasting 5 turns with rising intensity.")},
            {206,new Move(206,"False Swipe","Normal","Physical","Cool",40,"40","100%","An attack that leaves the foe with at least 1 HP.")},
            {207,new Move(207,"Swagger","Normal","Status","Cute",15,"-","90%","Confuses the foe, but also sharply raises Attack.")},
            {208,new Move(208,"Milk Drink","Normal","Status","Cute",10,"-","-","Recovers up to half the user's maximum HP.")},
            {209,new Move(209,"Spark","Electric","Physical","Cool",20,"65","100%","An electrified tackle that may paralyze the foe.")},
            {210,new Move(210,"Fury Cutter","Bug","Physical","Cool",20,"10","95%","An attack that intensifies on each successive hit.")},
            {211,new Move(211,"Steel Wing","Steel","Physical","Cool",25,"70","90%","Spreads hard-edged wings and slams into the foe.")},
            {212,new Move(212,"Mean Look","Normal","Status","Beauty",5,"-","100%","Fixes the foe with a mean look that prevents escape.")},
            {213,new Move(213,"Attract","Normal","Status","Cute",15,"-","100%","Makes it tough to attack a foe of the opposite gender.")},
            {214,new Move(214,"Sleep Talk","Normal","Status","Cute",10,"-","-","Uses an available move randomly while asleep.")},
            {215,new Move(215,"Heal Bell","Normal","Status","Beauty",5,"-","-","Chimes soothingly to heal all status abnormalities.")},
            {216,new Move(216,"Return","Normal","Physical","Cute",20,"-","100%","The more the user likes you, the more powerful this move.")},
            {217,new Move(217,"Present","Normal","Physical","Cute",15,"-","90%","A gift in the form of a bomb. May restore HP.")},
            {218,new Move(218,"Frustration","Normal","Physical","Cute",20,"-","100%","The less the user likes you, the more powerful this move.")},
            {219,new Move(219,"Safeguard","Normal","Status","Beauty",25,"-","-","Prevents status abnormality with a mystical power.")},
            {220,new Move(220,"Pain Split","Normal","Status","Smart",20,"-","100%","Adds the user and foe's HP, then shares them equally.")},
            {221,new Move(221,"Sacred Fire","Fire","Physical","Beauty",5,"100","95%","A mystical fire attack that may inflict a burn.")},
            {222,new Move(222,"Magnitude","Ground","Physical","Tough",30,"-","100%","A ground-shaking attack of random intensity.")},
            {223,new Move(223,"DynamicPunch","Fighting","Physical","Cool",5,"100","50%","Powerful and sure to cause confusion, but inaccurate.")},
            {224,new Move(224,"Megahorn","Bug","Physical","Cool",10,"120","85%","A brutal ramming attack using out-thrust horns.")},
            {225,new Move(225,"DragonBreath","Dragon","Special","Cool",20,"60","100%","Strikes the foe with an incredible blast of breath.")},
            {226,new Move(226,"Baton Pass","Normal","Status","Cute",40,"-","-","Switches out the user while keeping effects in play.")},
            {227,new Move(227,"Encore","Normal","Status","Cute",5,"-","100%","Makes the foe repeat its last move over 2 to 6 turns.")},
            {228,new Move(228,"Pursuit","Dark","Physical","Smart",20,"40","100%","Inflicts bad damage if used on a foe switching out.")},
            {229,new Move(229,"Rapid Spin","Normal","Physical","Cool",40,"20","100%","Spins the body at high speed to strike the foe.")},
            {230,new Move(230,"Sweet Scent","Normal","Status","Cute",20,"-","100%","Allures the foe to reduce evasiveness.")},
            {231,new Move(231,"Iron Tail","Steel","Physical","Cool",15,"100","75%","Slams the foe with a hard tail. It may lower Defense.")},
            {232,new Move(232,"Metal Claw","Steel","Physical","Cool",35,"50","95%","A claw attack that may raise the user's Attack.")},
            {233,new Move(233,"Vital Throw","Fighting","Physical","Cool",10,"70","100%","Makes the user's move last, but it never misses.")},
            {234,new Move(234,"Morning Sun","Normal","Status","Beauty",5,"-","-","Restores HP. The amount varies with the weather.")},
            {235,new Move(235,"Synthesis","Grass","Status","Smart",5,"-","-","Restores HP. The amount varies with the weather.")},
            {236,new Move(236,"Moonlight","Normal","Status","Beauty",5,"-","-","Restores HP. The amount restored with the weather.")},
            {237,new Move(237,"Hidden Power","Normal","Special","Smart",15,"-","100%","The attack power varies among different Pokemon.")},
            {238,new Move(238,"Cross Chop","Fighting","Physical","Cool",5,"100","80%","A double-chopping attack. High critical-hit ratio.")},
            {239,new Move(239,"Twister","Dragon","Special","Cool",20,"40","100%","Whips up a vicious twister to tear at the foe.")},
            {240,new Move(240,"Rain Dance","Water","Status","Tough",5,"-","-","Raises the power of Water-type moves for 5 turns.")},
            {241,new Move(241,"Sunny Day","Fire","Status","Beauty",5,"-","-","Raises the power of Fire-type moves for 5 turns.")},
            {242,new Move(242,"Crunch","Dark","Physical","Tough",15,"80","100%","Crunches with sharp fangs. May lower Sp. Def.")},
            {243,new Move(243,"Mirror Coat","Psychic","Special","Beauty",20,"-","100%","Counters the foe's special attack at double the power.")},
            {244,new Move(244,"Psych Up","Normal","Status","Smart",10,"-","-","Copies the foe's effect(s) and gives to the user.")},
            {245,new Move(245,"ExtremeSpeed","Normal","Physical","Cool",5,"80","100%","An extremely fast and powerful attack.")},
            {246,new Move(246,"AncientPower","Rock","Special","Tough",5,"60","100%","An attack that may raise all stats.")},
            {247,new Move(247,"Shadow Ball","Ghost","Special","Smart",15,"80","100%","Hurls a dark lump at the foe. It may lower Sp. Def.")},
            {248,new Move(248,"Future Sight","Psychic","Special","Smart",15,"80","90%","Heightens inner power to strike 2 turns later.")},
            {249,new Move(249,"Rock Smash","Fighting","Physical","Tough",15,"20","100%","A rock-crushingly tough attack that may lower Defense.")},
            {250,new Move(250,"Whirlpool","Water","Special","Beauty",15,"15","70%","Traps and hurts the foe in a whirlpool for 2 to 5 turns.")},
            {251,new Move(251,"Beat Up","Dark","Physical","Smart",10,"10","100%","Summons party Pokemon to join in the attack.")},
            {252,new Move(252,"Fake Out","Normal","Physical","Cute",10,"40","100%","A 1st-turn, 1st-strike move that causes flinching.")},
            {253,new Move(253,"Uproar","Normal","Special","Cute",10,"50","100%","Causes an uproar for 2 to 5 turns and prevents sleep.")},
            {254,new Move(254,"Stockpile","Normal","Status","Tough",20,"-","-","Charges up power for up to 3 turns.")},
            {255,new Move(255,"Spit Up","Normal","Special","Tough",10,"-","100%","Releases stockpiled power (the more the better).")},
            {256,new Move(256,"Swallow","Normal","Status","Tough",10,"-","-","Absorbs stockpiled power and restores HP.")},
            {257,new Move(257,"Heat Wave","Fire","Special","Beauty",10,"100","90%","Exhales a hot breath on the foe. May inflict a burn.")},
            {258,new Move(258,"Hail","Ice","Status","Beauty",10,"-","-","Summons a hailstorm that hurts all types except Ice.")},
            {259,new Move(259,"Torment","Dark","Status","Tough",15,"-","100%","Prevents the foe from using the same move in a row.")},
            {260,new Move(260,"Flatter","Dark","Status","Smart",15,"-","100%","Confuses the foe, but raises its Sp. Atk.")},
            {261,new Move(261,"Will-O-Wisp","Fire","Status","Beauty",15,"-","75%","Inflicts a burn on the foe with intense fire.")},
            {262,new Move(262,"Memento","Dark","Status","Tough",10,"-","100%","The user faints and lowers the foe's abilities.")},
            {263,new Move(263,"Facade","Normal","Physical","Cute",20,"70","100%","Raises Attack when poisoned, burned, or paralyzed.")},
            {264,new Move(264,"Focus Punch","Fighting","Physical","Tough",20,"150","100%","Powerful, but makes the user flinch if hit by foe.")},
            {265,new Move(265,"SmellingSalt","Normal","Physical","Smart",10,"60","100%","Powerful against paralyzed foes, but also heals them.")},
            {266,new Move(266,"Follow Me","Normal","Status","Cute",20,"-","100%","Draws attention to make foes attack only the user.")},
            {267,new Move(267,"Nature Power","Normal","Status","Beauty",20,"-","95%","The type of attack varies depending on the location.")},
            {268,new Move(268,"Charge","Electric","Status","Smart",20,"-","100%","Charges power to boost the electric move used next.")},
            {269,new Move(269,"Taunt","Dark","Status","Smart",20,"-","100%","Enrages the foe so it can only use attack moves.")},
            {270,new Move(270,"Helping Hand","Normal","Status","Smart",20,"-","100%","Boosts the power of the recipient's moves.")},
            {271,new Move(271,"Trick","Psychic","Status","Smart",10,"-","100%","Tricks the foe into trading held items.")},
            {272,new Move(272,"Role Play","Psychic","Status","Cute",10,"-","100%","Mimics the target and copies its special ability.")},
            {273,new Move(273,"Wish","Normal","Status","Cute",10,"-","100%","A wish that restores HP. It takes time to work.")},
            {274,new Move(274,"Assist","Normal","Status","Cute",20,"-","100%","Attacks randomly with one of the partner's moves.")},
            {275,new Move(275,"Ingrain","Grass","Status","Smart",20,"-","100%","Lays roots that restore HP. The user can't switch out.")},
            {276,new Move(276,"Superpower","Fighting","Physical","Tough",5,"120","100%","Boosts strength sharply, but lowers abilities.")},
            {277,new Move(277,"Magic Coat","Psychic","Status","Beauty",15,"-","100%","Reflects special effects back to the attacker.")},
            {278,new Move(278,"Recycle","Normal","Status","Smart",10,"-","100%","Recycles a used item for one more use.")},
            {279,new Move(279,"Revenge","Fighting","Physical","Tough",10,"60","100%","An attack that gains power if injured by the foe.")},
            {280,new Move(280,"Brick Break","Fighting","Physical","Cool",15,"75","100%","Destroys barriers like Light Screen and causes damage.")},
            {281,new Move(281,"Yawn","Normal","Status","Cute",10,"-","100%","Lulls the foe into yawning, then sleeping the next turn.")},
            {282,new Move(282,"Knock Off","Dark","Physical","Smart",20,"20","100%","Knocks down the foe's held item to prevent its use.")},
            {283,new Move(283,"Endeavor","Normal","Physical","Tough",5,"-","100%","Gains power if the user's HP is lower than the foe's HP.")},
            {284,new Move(284,"Eruption","Fire","Special","Beauty",5,"-","100%","The higher the user's HP, the more damage caused.")},
            {285,new Move(285,"Skill Swap","Psychic","Status","Smart",10,"-","100%","Switches abilities with the foe on the turn this is used.")},
            {286,new Move(286,"Imprison","Psychic","Status","Smart",10,"-","100%","Prevents foes from using moves known by the user.")},
            {287,new Move(287,"Refresh","Normal","Status","Cute",20,"-","100%","Heals poisoning, paralysis, or a burn.")},
            {288,new Move(288,"Grudge","Ghost","Status","Tough",5,"-","100%","If the user faints, deletes all PP of foe's last move.")},
            {289,new Move(289,"Snatch","Dark","Status","Smart",10,"-","100%","Steals the effects of the move the foe is trying to use.")},
            {290,new Move(290,"Secret Power","Normal","Physical","Smart",20,"70","100%","Adds an effect to attack depending on the location.")},
            {291,new Move(291,"Dive","Water","Physical","Beauty",10,"80","100%","Dives underwater the 1st turn, then attacks next turn.")},
            {292,new Move(292,"Arm Thrust","Fighting","Physical","Tough",20,"15","100%","Straight-arm punches that strike the foe 2 to 5 times.")},
            {293,new Move(293,"Camouflage","Normal","Status","Smart",20,"-","100%","Alters the Pokemon's type depending on the location.")},
            {294,new Move(294,"Tail Glow","Bug","Status","Beauty",20,"-","100%","Flashes a light that sharply raises Sp. Atk.")},
            {295,new Move(295,"Luster Purge","Psychic","Special","Smart",5,"70","100%","Attacks with a burst of light. May lower Sp. Def.")},
            {296,new Move(296,"Mist Ball","Psychic","Special","Smart",5,"70","100%","Attacks with a flurry of down. May lower Sp. Atk.")},
            {297,new Move(297,"FeatherDance","Flying","Status","Beauty",15,"-","100%","Envelops the foe with down to sharply reduce Attack.")},
            {298,new Move(298,"Teeter Dance","Normal","Status","Cute",20,"-","100%","Confuses all Pokemon on the scene.")},
            {299,new Move(299,"Blaze Kick","Fire","Physical","Beauty",10,"85","90%","A kick with a high critical- hit ratio. May cause a burn.")},
            {300,new Move(300,"Mud Sport","Ground","Status","Cute",15,"-","100%","Covers the user in mud to raise electrical resistance.")},
            {301,new Move(301,"Ice Ball","Ice","Physical","Beauty",20,"30","90%","A 5-turn attack that gains power on successive hits.")},
            {302,new Move(302,"Needle Arm","Grass","Physical","Smart",15,"60","100%","Attacks with thorny arms. May cause flinching.")},
            {303,new Move(303,"Slack Off","Normal","Status","Cute",10,"-","100%","Slacks off and restores half the maximum HP.")},
            {304,new Move(304,"Hyper Voice","Normal","Special","Cool",10,"90","100%","A loud attack that uses sound waves to injure.")},
            {305,new Move(305,"Poison Fang","Poison","Physical","Smart",15,"50","100%","A sharp-fanged attack. May badly poison the foe.")},
            {306,new Move(306,"Crush Claw","Normal","Physical","Cool",10,"75","95%","Tears at the foe with sharp claws. May lower Defense.")},
            {307,new Move(307,"Blast Burn","Fire","Special","Beauty",5,"150","90%","Powerful, but leaves the user immobile the next turn.")},
            {308,new Move(308,"Hydro Cannon","Water","Special","Beauty",5,"150","90%","Powerful, but leaves the user immobile the next turn.")},
            {309,new Move(309,"Meteor Mash","Steel","Physical","Cool",10,"100","85%","Fires a meteor-like punch. May raise Attack.")},
            {310,new Move(310,"Astonish","Ghost","Physical","Smart",15,"30","100%","An attack that may shock the foe into flinching.")},
            {311,new Move(311,"Weather Ball","Normal","Special","Smart",10,"50","100%","The move's type and power change with the weather.")},
            {312,new Move(312,"Aromatherapy","Grass","Status","Smart",5,"-","-","Heals all status problems with a soothing scent.")},
            {313,new Move(313,"Fake Tears","Dark","Status","Smart",20,"-","100%","Feigns crying to sharply lower the foe's Sp. Def.")},
            {314,new Move(314,"Air Cutter","Flying","Special","Cool",25,"55","95%","Hacks with razorlike wind. High critical-hit ratio.")},
            {315,new Move(315,"Overheat","Fire","Special","Beauty",5,"140","90%","Enables full-power attack, but sharply lowers the Sp.Atk.")},
            {316,new Move(316,"Odor Sleuth","Normal","Status","Smart",40,"-","100%","Negates the foe's efforts to heighten evasiveness.")},
            {317,new Move(317,"Rock Tomb","Rock","Physical","Smart",10,"50","80%","Stops the foe from moving with rocks. May lower Speed.")},
            {318,new Move(318,"Silver Wind","Bug","Special","Beauty",5,"60","100%","A powdery attack that may raise abilities.")},
            {319,new Move(319,"Metal Sound","Steel","Status","Smart",40,"-","85%","Emits a horrible screech that sharply lowers Sp. Def.")},
            {320,new Move(320,"GrassWhistle","Grass","Status","Smart",15,"-","55%","Lulls the foe into sleep with a pleasant melody.")},
            {321,new Move(321,"Tickle","Normal","Status","Cute",20,"-","100%","Makes the foe laugh to lower Attack and Defense.")},
            {322,new Move(322,"Cosmic Power","Psychic","Status","Cool",20,"-","-","Raises Defense and Sp. Def with a mystic power.")},
            {323,new Move(323,"Water Spout","Water","Special","Beauty",5,"-","100%","Inflicts more damage if the user's HP is high.")},
            {324,new Move(324,"Signal Beam","Bug","Special","Beauty",15,"75","100%","A strange beam attack that may confuse the foe.")},
            {325,new Move(325,"Shadow Punch","Ghost","Physical","Smart",20,"60","-","An unavoidable punch that is thrown from shadows.")},
            {326,new Move(326,"Extrasensory","Psychic","Special","Cool",30,"80","100%","Attacks with a peculiar power. May cause flinching.")},
            {327,new Move(327,"Sky Uppercut","Fighting","Physical","Cool",15,"85","90%","An uppercut thrown as if leaping into the sky.")},
            {328,new Move(328,"Sand Tomb","Ground","Physical","Smart",15,"15","70%","Traps and hurts the foe in quicksand for 2 to 5 turns.")},
            {329,new Move(329,"Sheer Cold","Ice","Special","Beauty",5,"-","-","A chilling attack that causes fainting if it hits.")},
            {330,new Move(330,"Muddy Water","Water","Special","Tough",10,"95","85%","Attacks with muddy water. May lower accuracy.")},
            {331,new Move(331,"Bullet Seed","Grass","Physical","Cool",30,"10","100%","Shoots 2 to 5 seeds in a row to strike the foe.")},
            {332,new Move(332,"Aerial Ace","Flying","Physical","Cool",20,"60","-","An extremely fast attack that can't be avoided.")},
            {333,new Move(333,"Icicle Spear","Ice","Physical","Beauty",30,"10","100%","Attacks the foe by firing 2 to 5 icicles in a row.")},
            {334,new Move(334,"Iron Defense","Steel","Status","Tough",15,"-","-","Hardens the body's surface to sharply raise Defense.")},
            {335,new Move(335,"Block","Normal","Status","Cute",5,"-","100%","Blocks the foe's way to prevent escape.")},
            {336,new Move(336,"Howl","Normal","Status","Cool",40,"-","-","Howls to raise the spirit and boosts Attack.")},
            {337,new Move(337,"Dragon Claw","Dragon","Physical","Cool",15,"80","100%","Hooks and slashes the foe with long, sharp claws.")},
            {338,new Move(338,"Frenzy Plant","Grass","Special","Cool",5,"150","90%","Powerful, but leaves the user immobile the next turn.")},
            {339,new Move(339,"Bulk Up","Fighting","Status","Beauty",20,"-","-","Bulks up the body to boost both Attack & Defense.")},
            {340,new Move(340,"Bounce","Flying","Physical","Cute",5,"85","85%","Bounces up, then down the next turn. May paralyze.")},
            {341,new Move(341,"Mud Shot","Ground","Special","Tough",15,"55","95%","Hurls mud at the foe and reduces Speed.")},
            {342,new Move(342,"Poison Tail","Poison","Physical","Smart",25,"50","100%","Has a high critical-hit ratio. May also poison.")},
            {343,new Move(343,"Covet","Normal","Physical","Cute",40,"40","100%","Cutely begs to obtain an item held by the foe.")},
            {344,new Move(344,"Volt Tackle","Electric","Physical","Cool",15,"120","100%","A life-risking tackle that slightly hurts the user.")},
            {345,new Move(345,"Magical Leaf","Grass","Special","Beauty",20,"60","-","Attacks with a strange leaf that cannot be evaded.")},
            {346,new Move(346,"Water Sport","Water","Status","Cute",15,"-","100%","The user becomes soaked to raise resistance to fire.")},
            {347,new Move(347,"Calm Mind","Psychic","Status","Smart",20,"-","-","Raises Sp. Atk and Sp. Def by focusing the mind.")},
            {348,new Move(348,"Leaf Blade","Grass","Physical","Cool",15,"90","100%","Slashes with a sharp leaf. High critical-hit ratio.")},
            {349,new Move(349,"Dragon Dance","Dragon","Status","Cool",20,"-","-","A mystical dance that ups Attack and Speed.")},
            {350,new Move(350,"Rock Blast","Rock","Physical","Tough",10,"25","80%","Hurls boulders at the foe 2 to 5 times in a row.")},
            {351,new Move(351,"Shock Wave","Electric","Special","Cool",20,"60","-","Zaps the foe with a jolt of electricity that never misses.")},
            {352,new Move(352,"Water Pulse","Water","Special","Beauty",20,"60","100%","Generates an ultrasonic wave that may confuse.")},
            {353,new Move(353,"Doom Desire","Steel","Special","Cool",5,"120","85%","Summons strong sunlight to attack 2 turns later.")},
            {354,new Move(354,"Psycho Boost","Psychic","Special","Smart",5,"140","90%","Allows a full-power attack, but sharply lowers Sp. Atk.")}
        };

        /// <summary>
        /// Pristupa kolekciji Moves
        /// </summary>
        public static Dictionary<ushort, Move> Moves
        {
            get { return _moves; }
        }
        #endregion
        #region Pokemon List
        private static Dictionary<ushort, PokemonStructure> _pokemonList = new Dictionary<ushort, PokemonStructure>
        {
            {000,new PokemonStructure(000,1,"??????????","Normal","Nothing",3,65,0,new ushort[]{0,14,15,22,33,34,38,45,70,73,74,75,76,77,79,80,92,99,102,104,111,113,130,148,156,164,173,174,182,188,189,202,203,204,207,210,213,214,216,218,219,230,235,237,241,249,263,290,320,331,345})},
            {001,new PokemonStructure(001,1,"Bulbasaur","Grass","Poison",3,65,0,new ushort[]{0,14,15,22,33,34,38,45,70,73,74,75,76,77,79,80,92,99,102,104,111,113,130,148,156,164,173,174,182,188,189,202,203,204,207,210,213,214,216,218,219,230,235,237,241,249,263,290,320,331,345})},
            {002,new PokemonStructure(002,2,"Ivysaur","Grass","Poison",3,65,0,new ushort[]{0,14,15,22,33,34,38,45,70,73,74,75,76,77,79,92,99,102,104,111,148,156,164,173,182,188,189,202,203,207,210,213,214,216,218,230,235,237,241,249,263,290,331})},
            {003,new PokemonStructure(003,3,"Venusaur","Grass","Poison",3,65,0,new ushort[]{0,14,15,22,33,34,38,45,46,63,70,73,74,75,76,77,79,89,92,99,102,104,111,148,156,164,173,182,188,189,202,203,207,210,213,214,216,218,230,235,237,241,249,263,290,331,338})},
            {004,new PokemonStructure(004,4,"Charmander","Fire","Nothing",3,66,0,new ushort[]{0,5,7,10,14,15,25,34,38,44,45,52,53,68,69,70,82,83,91,92,99,102,104,108,111,126,129,156,157,163,164,173,182,184,187,189,200,203,207,210,213,214,216,218,223,231,232,237,241,246,249,251,263,264,280,290,315,332,337,349})},
            {005,new PokemonStructure(005,5,"Charmeleon","Fire","Nothing",3,66,0,new ushort[]{0,5,7,10,14,15,25,34,38,45,52,53,68,69,70,82,83,91,92,99,102,104,108,111,126,129,156,157,163,164,173,182,184,189,203,207,210,213,214,216,218,223,231,232,237,241,249,263,264,280,290,315,332,337})},
            {006,new PokemonStructure(006,6,"Charizard","Fire","Flying",3,66,0,new ushort[]{0,5,7,10,14,15,17,19,25,34,38,45,46,52,53,63,68,69,70,82,83,89,91,92,99,102,104,108,111,126,129,156,157,163,164,173,182,184,189,203,207,210,211,213,214,216,218,223,231,232,237,241,249,257,263,264,280,290,307,315,332,337})},
            {007,new PokemonStructure(007,7,"Squirtle","Water","Nothing",3,67,0,new ushort[]{0,5,8,25,33,34,38,39,44,54,55,56,57,58,59,68,69,70,91,92,99,102,104,110,111,114,127,130,145,156,164,173,175,182,189,193,196,203,205,207,213,214,216,218,223,229,231,237,240,243,249,258,263,264,280,281,287,290,291,300,352})},
            {008,new PokemonStructure(008,8,"Wartortle","Water","Nothing",3,67,0,new ushort[]{0,5,8,25,33,34,38,39,44,55,56,57,58,59,68,69,70,91,92,99,102,104,110,111,127,130,145,156,164,173,182,189,196,203,205,207,213,214,216,218,223,229,231,237,240,249,258,263,264,280,290,291,352})},
            {009,new PokemonStructure(009,9,"Blastoise","Water","Nothing",3,67,0,new ushort[]{0,5,8,25,33,34,38,39,44,46,55,56,57,58,59,63,68,69,70,89,91,92,99,102,104,110,111,127,130,145,156,164,173,182,189,196,203,205,207,213,214,216,218,223,229,231,237,240,249,258,263,264,280,290,291,308,352})},
            {010,new PokemonStructure(010,10,"Caterpie","Bug","Nothing",2,19,0,new ushort[]{0,33,81})},
            {011,new PokemonStructure(011,11,"Metapod","Bug","Nothing",2,61,0,new ushort[]{0,106})},
            {012,new PokemonStructure(012,12,"Butterfree","Bug","Flying",2,14,0,new ushort[]{0,16,18,38,48,60,63,76,77,78,79,92,93,94,99,102,104,129,138,148,156,164,168,173,182,202,203,207,213,214,216,218,219,237,240,241,247,263,285,290,318,332})},
            {013,new PokemonStructure(013,13,"Weedle","Bug","Poison",2,19,0,new ushort[]{0,40,81})},
            {014,new PokemonStructure(014,14,"Kakuna","Bug","Poison",2,61,0,new ushort[]{0,106})},
            {015,new PokemonStructure(015,15,"Beedrill","Bug","Poison",2,68,0,new ushort[]{0,14,15,31,38,41,42,63,76,92,97,99,102,104,116,129,156,164,168,173,182,188,203,207,210,213,214,216,218,228,237,241,249,263,280,283,290,332})},
            {016,new PokemonStructure(016,16,"Pidgey","Normal","Flying",3,51,0,new ushort[]{0,16,17,18,19,28,33,38,82,92,97,98,99,102,104,119,129,156,164,168,173,182,185,189,193,203,207,211,213,214,216,218,228,237,241,263,290,297,314,332})},
            {017,new PokemonStructure(017,17,"Pidgeotto","Normal","Flying",3,51,0,new ushort[]{0,16,17,18,19,28,33,38,92,97,98,99,102,104,119,129,156,164,168,173,182,189,203,207,211,213,214,216,218,237,241,263,290,297,332})},
            {018,new PokemonStructure(018,18,"Pidgeot","Normal","Flying",3,51,0,new ushort[]{0,16,17,18,19,28,33,38,63,92,97,98,99,102,104,119,127,129,156,164,168,173,182,189,203,207,211,213,214,216,218,237,241,263,290,297,332})},
            {019,new PokemonStructure(019,19,"Rattata","Normal","Nothing",2,50,62,new ushort[]{0,15,33,34,38,39,44,58,59,68,85,86,87,91,92,98,99,102,103,104,111,116,129,154,156,158,162,164,168,172,173,179,182,189,196,203,207,213,214,216,218,228,231,237,241,247,249,253,263,269,283,290,351})},
            {020,new PokemonStructure(020,20,"Raticate","Normal","Nothing",2,50,62,new ushort[]{0,15,33,34,38,39,46,58,59,63,68,70,85,86,87,91,92,98,99,102,104,111,129,156,158,162,164,168,173,182,184,189,196,203,207,213,214,216,218,228,231,237,241,247,249,263,269,283,290,351})},
            {021,new PokemonStructure(021,21,"Spearow","Normal","Flying",2,51,0,new ushort[]{0,19,31,38,43,45,64,65,92,97,98,99,102,104,119,129,143,156,161,164,168,173,182,184,185,189,203,206,207,211,213,214,216,218,228,237,241,263,290,310,332})},
            {022,new PokemonStructure(022,22,"Fearow","Normal","Flying",2,51,0,new ushort[]{0,19,31,38,43,45,63,64,65,92,97,99,102,104,119,129,156,164,168,173,182,189,203,207,211,213,214,216,218,228,237,241,263,290,332})},
            {023,new PokemonStructure(023,23,"Ekans","Poison","Nothing",2,22,61,new ushort[]{0,21,34,35,38,40,43,44,51,70,89,91,92,99,102,103,104,114,137,156,157,164,168,173,180,182,188,202,203,207,213,214,216,218,228,231,237,241,251,254,255,256,259,263,289,290,305,342})},
            {024,new PokemonStructure(024,24,"Arbok","Poison","Nothing",2,22,61,new ushort[]{0,34,35,38,40,43,44,51,63,70,89,91,92,99,102,103,104,114,137,156,157,164,168,173,182,188,202,203,207,213,214,216,218,231,237,241,254,255,256,259,263,289,290})},
            {025,new PokemonStructure(025,25,"Pikachu","Electric","Nothing",2,9,0,new ushort[]{0,5,9,21,25,34,38,39,45,68,69,70,84,85,86,87,91,92,97,98,99,102,104,111,113,129,148,156,164,173,182,189,203,205,207,213,214,216,218,223,231,237,240,249,263,264,280,290,351})},
            {026,new PokemonStructure(026,26,"Raichu","Electric","Nothing",2,9,0,new ushort[]{0,5,9,25,34,38,63,68,69,70,84,85,86,87,91,92,99,102,104,111,113,129,148,156,164,168,173,182,189,203,205,207,213,214,216,218,223,231,237,240,249,263,264,280,290,351})},
            {027,new PokemonStructure(027,27,"Sandshrew","Ground","Nothing",2,8,0,new ushort[]{0,10,14,15,28,34,38,40,68,69,70,89,91,92,99,102,104,111,129,154,156,157,163,164,168,173,182,189,201,203,205,207,210,213,214,216,218,219,223,229,231,232,237,241,249,263,264,280,290,306,317,328,332})},
            {028,new PokemonStructure(028,28,"Sandslash","Ground","Nothing",2,8,0,new ushort[]{0,10,14,15,28,34,38,40,63,68,69,70,89,91,92,99,102,104,111,129,154,156,157,163,164,168,173,182,189,201,203,205,207,210,213,214,216,218,223,231,237,241,249,263,264,280,290,317,328,332})},
            {029,new PokemonStructure(029,29,"Nidoran<","Poison","Nothing",3,38,0,new ushort[]{0,10,15,24,34,36,38,39,40,44,45,48,50,58,59,68,70,85,87,91,92,99,102,104,111,116,154,156,164,168,173,182,188,189,203,204,207,213,214,216,218,231,237,240,241,242,249,251,260,263,270,290,332,351,352})},
            {030,new PokemonStructure(030,30,"Nidorina","Poison","Nothing",3,38,0,new ushort[]{0,10,15,24,34,38,39,40,44,45,58,59,68,70,85,87,91,92,99,102,104,111,154,156,164,168,173,182,188,189,203,207,213,214,216,218,231,237,240,241,242,249,260,263,270,290,332,351,352})},
            {031,new PokemonStructure(031,31,"Nidoqueen","Poison","Ground",3,38,0,new ushort[]{0,5,7,8,9,10,15,24,25,34,38,39,40,46,53,57,58,59,63,68,69,70,85,87,89,91,92,99,102,104,111,126,156,157,164,168,173,182,188,189,196,201,203,205,207,210,213,214,216,218,223,231,237,240,241,247,249,259,263,264,269,276,280,290,317,332,351,352})},
            {032,new PokemonStructure(032,32,"Nidoran>","Poison","Nothing",3,38,0,new ushort[]{0,15,24,30,31,32,34,36,38,40,43,48,50,58,59,64,68,70,85,87,91,92,93,99,102,104,111,116,133,156,164,168,173,182,188,189,203,207,213,214,216,218,231,237,240,241,249,251,260,263,270,290,351,352})},
            {033,new PokemonStructure(033,33,"Nidorino","Poison","Nothing",3,38,0,new ushort[]{0,15,24,30,31,32,34,38,40,43,58,59,64,68,70,85,87,91,92,99,102,104,111,116,156,164,168,173,182,188,189,203,207,213,214,216,218,231,237,240,241,249,260,263,270,290,351,352})},
            {034,new PokemonStructure(034,34,"Nidoking","Poison","Ground",3,38,0,new ushort[]{0,5,7,8,9,15,24,25,34,37,38,40,46,53,57,58,59,63,64,68,69,70,85,87,89,91,92,99,102,104,111,116,126,156,157,164,168,173,182,188,189,196,201,203,207,210,213,214,216,218,223,224,231,237,240,241,247,249,259,263,264,269,280,290,317,351,352})},
            {035,new PokemonStructure(035,35,"Clefairy","Normal","Nothing",1,56,0,new ushort[]{0,1,3,5,7,8,9,25,34,38,45,47,53,58,59,68,69,70,76,85,86,87,91,92,94,99,102,104,107,111,113,115,118,126,135,138,148,156,164,173,182,189,203,205,207,213,214,216,218,219,223,227,231,236,237,240,241,244,247,263,264,266,280,289,290,309,322,347,351,352})},
            {036,new PokemonStructure(036,36,"Clefable","Normal","Nothing",1,56,0,new ushort[]{0,3,5,7,8,9,25,34,38,47,53,58,59,63,68,69,70,76,85,86,87,91,92,94,99,102,104,107,111,113,115,118,126,135,138,148,156,164,173,182,189,203,205,207,213,214,216,218,219,223,231,237,240,241,244,247,263,264,280,289,290,347,351,352})},
            {037,new PokemonStructure(037,37,"Vulpix","Fire","Nothing",2,18,0,new ushort[]{0,34,38,39,46,50,52,53,83,91,92,95,98,99,102,104,109,126,129,156,164,173,180,182,185,203,207,213,214,216,218,219,231,237,241,244,257,261,263,286,288,290,315,336})},
            {038,new PokemonStructure(038,38,"Ninetales","Fire","Nothing",2,18,0,new ushort[]{0,34,38,46,52,53,63,83,91,92,98,99,102,104,109,126,129,156,164,173,182,203,207,213,214,216,218,219,231,237,241,263,290,315})},
            {039,new PokemonStructure(039,39,"Jigglypuff","Normal","Nothing",1,56,0,new ushort[]{0,1,3,5,7,8,9,25,34,38,47,50,53,58,59,68,69,70,76,85,86,87,91,92,94,99,102,104,111,113,115,126,138,148,156,164,173,182,189,203,205,207,213,214,216,218,219,223,237,240,241,244,247,263,264,280,289,290,304,351,352})},
            {040,new PokemonStructure(040,40,"Wigglytuff","Normal","Nothing",1,56,0,new ushort[]{0,3,5,7,8,9,25,34,38,47,50,53,58,59,63,68,69,70,76,85,86,87,91,92,94,99,102,104,111,113,115,126,138,148,156,164,173,182,189,203,205,207,213,214,216,218,219,223,237,240,241,244,247,263,264,280,289,290,351,352})},
            {041,new PokemonStructure(041,41,"Zubat","Poison","Flying",2,39,0,new ushort[]{0,16,17,18,38,44,48,92,98,99,102,104,109,114,129,141,156,164,168,173,174,182,185,188,202,203,207,211,212,213,214,216,218,228,237,241,247,259,263,269,289,290,305,310,314,332})},
            {042,new PokemonStructure(042,42,"Golbat","Poison","Flying",2,39,0,new ushort[]{0,17,38,44,48,63,92,99,102,103,104,109,114,129,141,156,164,168,173,182,188,202,203,207,211,212,213,214,216,218,237,241,247,259,263,269,289,290,305,310,314,332})},
            {043,new PokemonStructure(043,43,"Oddish","Grass","Poison",3,34,0,new ushort[]{0,14,15,38,51,71,75,76,77,78,79,80,92,99,102,104,148,156,164,173,175,182,188,202,203,204,207,213,214,216,218,230,235,236,237,241,263,275,290,331})},
            {044,new PokemonStructure(044,44,"Gloom","Grass","Poison",3,34,0,new ushort[]{0,14,15,38,51,71,76,77,78,79,80,92,99,102,104,148,156,164,173,182,188,202,203,207,213,214,216,218,230,236,237,241,263,290,331})},
            {045,new PokemonStructure(045,45,"Vileplume","Grass","Poison",3,34,0,new ushort[]{0,14,15,34,38,63,72,76,78,80,92,99,102,104,148,156,164,173,182,188,202,203,207,213,214,216,218,237,241,263,290,312,331})},
            {046,new PokemonStructure(046,46,"Paras","Bug","Grass",2,27,0,new ushort[]{0,10,14,15,34,38,60,68,74,76,77,78,91,92,99,102,103,104,113,141,147,148,156,163,164,168,173,175,182,188,202,203,206,207,210,213,214,216,218,228,230,237,241,249,263,290,312,331,332})},
            {047,new PokemonStructure(047,47,"Parasect","Bug","Grass",2,27,0,new ushort[]{0,10,14,15,34,38,63,68,74,76,77,78,91,92,99,102,104,141,147,148,156,163,164,168,173,182,188,202,203,207,210,213,214,216,218,237,241,249,263,290,312,331,332})},
            {048,new PokemonStructure(048,48,"Venonat","Bug","Poison",2,14,0,new ushort[]{0,33,38,48,50,60,76,77,78,79,92,93,94,99,102,103,104,129,141,148,156,164,168,173,182,188,193,202,203,207,213,214,216,218,226,237,241,263,285,290,324})},
            {049,new PokemonStructure(049,49,"Venomoth","Bug","Poison",2,19,0,new ushort[]{0,16,33,38,48,50,60,63,76,77,78,79,92,93,94,99,102,104,129,141,148,156,164,168,173,182,188,193,202,203,207,213,214,216,218,237,241,263,285,290,318,332})},
            {050,new PokemonStructure(050,50,"Diglett","Ground","Nothing",2,8,71,new ushort[]{0,10,15,28,34,38,45,89,90,91,92,99,102,103,104,154,156,157,163,164,168,173,182,185,188,189,203,207,213,214,216,218,222,228,237,241,246,249,251,253,263,290,317,332})},
            {051,new PokemonStructure(051,51,"Dugtrio","Ground","Nothing",2,8,71,new ushort[]{0,10,15,28,34,38,45,63,89,90,91,92,99,102,104,154,156,157,161,163,164,168,173,182,188,189,203,207,213,214,216,218,222,237,241,249,263,290,317,328,332})},
            {052,new PokemonStructure(052,52,"Meowth","Normal","Nothing",2,53,0,new ushort[]{0,6,10,15,34,38,44,45,85,87,91,92,95,99,102,103,104,111,129,133,138,148,154,156,163,164,168,173,180,182,185,189,196,203,204,207,213,214,216,218,231,237,241,244,247,252,259,263,269,274,289,290,332,351,352})},
            {053,new PokemonStructure(053,53,"Persian","Normal","Nothing",2,7,0,new ushort[]{0,6,10,15,34,38,44,45,46,63,85,87,91,92,99,102,103,104,111,129,138,148,154,156,163,164,168,173,182,185,189,196,203,207,213,214,216,218,231,237,241,244,247,252,259,263,269,289,290,332,351,352})},
            {054,new PokemonStructure(054,54,"Psyduck","Water","Nothing",2,6,13,new ushort[]{0,5,8,10,25,34,38,39,50,56,57,58,59,60,68,69,70,91,92,93,94,95,99,102,103,104,113,127,129,148,154,156,164,173,182,189,193,196,203,207,213,214,216,218,223,231,237,238,240,244,248,249,258,263,264,280,287,290,291,332,346,347,352})},
            {055,new PokemonStructure(055,55,"Golduck","Water","Nothing",2,6,13,new ushort[]{0,5,8,10,25,34,38,39,50,56,57,58,59,63,68,69,70,91,92,93,99,102,103,104,127,129,148,154,156,164,173,182,189,196,203,207,210,213,214,216,218,223,231,237,240,244,249,258,263,264,280,290,291,332,346,347,352})},
            {056,new PokemonStructure(056,56,"Mankey","Fighting","Nothing",2,72,0,new ushort[]{0,2,5,7,8,9,10,25,34,37,38,43,67,68,69,70,85,87,89,91,92,96,99,102,103,104,111,116,118,129,154,156,157,164,168,173,179,182,189,193,203,207,213,214,216,218,223,231,237,238,241,244,249,251,263,264,265,269,279,280,290,315,317,332,339})},
            {057,new PokemonStructure(057,57,"Primeape","Fighting","Nothing",2,72,0,new ushort[]{0,2,5,7,8,9,10,25,34,37,38,43,63,67,68,69,70,85,87,89,91,92,99,102,103,104,111,116,118,129,154,156,157,164,168,173,182,189,203,207,213,214,216,218,223,231,237,238,241,244,249,263,264,269,280,290,315,317,332,339})},
            {058,new PokemonStructure(058,58,"Growlithe","Fire","Nothing",4,22,18,new ushort[]{0,34,36,37,38,43,44,46,52,53,70,83,91,92,97,99,102,104,126,129,156,164,168,172,173,182,203,207,213,214,216,218,219,231,237,241,242,249,257,263,270,290,315,316,332,336})},
            {059,new PokemonStructure(059,59,"Arcanine","Fire","Nothing",4,22,18,new ushort[]{0,34,38,44,46,52,53,63,70,91,92,99,102,104,126,129,156,164,168,173,182,203,207,213,214,216,218,231,237,241,245,249,263,290,315,316,332})},
            {060,new PokemonStructure(060,60,"Poliwag","Water","Nothing",3,11,6,new ushort[]{0,3,34,38,54,55,56,57,58,59,61,68,91,92,94,95,99,102,104,111,114,127,145,150,156,164,168,170,173,182,187,196,203,207,213,214,216,218,237,240,258,263,290,291,301,346,352})},
            {061,new PokemonStructure(061,61,"Poliwhirl","Water","Nothing",3,11,6,new ushort[]{0,3,5,8,25,34,38,55,56,57,58,59,68,69,70,89,91,92,94,95,99,102,104,111,118,127,145,156,164,168,173,182,187,189,196,203,207,213,214,216,218,237,240,249,258,263,264,280,290,291,352})},
            {062,new PokemonStructure(062,62,"Poliwrath","Water","Fighting",3,11,6,new ushort[]{0,3,5,8,25,34,38,55,57,58,59,63,66,68,69,70,89,91,92,94,95,99,102,104,111,118,127,156,164,168,170,173,182,189,196,203,207,213,214,216,218,223,237,240,249,258,263,264,280,290,291,317,339,352})},
            {063,new PokemonStructure(063,63,"Abra","Psychic","Nothing",3,28,39,new ushort[]{0,5,7,8,9,25,34,38,68,69,86,92,94,99,100,102,104,112,113,115,118,138,148,156,164,168,173,182,203,207,213,214,216,218,219,223,227,231,237,240,241,244,247,259,263,264,269,282,285,289,290,347,351})},
            {064,new PokemonStructure(064,64,"Kadabra","Psychic","Nothing",3,28,39,new ushort[]{0,5,7,8,9,25,34,38,50,60,68,69,86,92,93,94,99,100,102,104,105,113,115,118,134,138,148,156,164,168,173,182,203,207,213,214,216,218,219,223,231,237,240,241,244,247,248,259,263,264,269,271,272,285,289,290,347,351})},
            {065,new PokemonStructure(065,65,"Alakazam","Psychic","Nothing",3,28,39,new ushort[]{0,5,7,8,9,25,34,38,50,60,63,68,69,86,92,93,94,99,100,102,104,105,113,115,118,134,138,148,156,164,168,173,182,203,207,213,214,216,218,219,223,231,237,240,241,244,247,248,259,263,264,269,271,285,289,290,347,351})},
            {066,new PokemonStructure(066,66,"Machop","Fighting","Nothing",3,62,0,new ushort[]{0,2,5,7,8,9,25,27,34,38,43,53,66,67,68,69,70,89,91,92,96,99,102,104,113,116,118,126,156,157,164,168,173,182,184,189,193,203,207,213,214,216,218,223,227,233,237,238,241,249,263,264,265,279,280,290,317,339})},
            {067,new PokemonStructure(067,67,"Machoke","Fighting","Nothing",3,62,0,new ushort[]{0,2,5,7,8,9,25,34,38,43,53,66,67,68,69,70,89,91,92,99,102,104,116,118,126,156,157,164,168,173,182,184,189,193,203,207,213,214,216,218,223,233,237,238,241,249,263,264,279,280,290,317,339})},
            {068,new PokemonStructure(068,68,"Machamp","Fighting","Nothing",3,62,0,new ushort[]{0,2,5,7,8,9,25,34,38,43,53,63,66,67,68,69,70,89,91,92,99,102,104,116,118,126,156,157,164,168,173,182,184,189,193,203,207,213,214,216,218,223,233,237,238,241,249,263,264,279,280,290,317,339})},
            {069,new PokemonStructure(069,69,"Bellsprout","Grass","Poison",3,34,0,new ushort[]{0,14,15,21,22,35,38,51,74,75,76,77,78,79,92,99,102,104,115,141,148,156,164,168,173,182,188,202,203,207,213,214,216,218,227,230,235,237,241,263,275,290,331,345})},
            {070,new PokemonStructure(070,70,"Weepinbell","Grass","Poison",3,34,0,new ushort[]{0,14,15,21,22,35,38,51,74,75,76,77,78,79,92,99,102,104,148,156,164,168,173,182,188,202,203,207,213,214,216,218,230,237,241,263,290,331})},
            {071,new PokemonStructure(071,71,"Victreebel","Grass","Poison",3,34,0,new ushort[]{0,14,15,22,34,38,63,75,76,79,92,99,102,104,148,156,164,168,173,182,188,202,203,207,213,214,216,218,230,237,241,254,255,256,263,290,331})},
            {072,new PokemonStructure(072,72,"Tentacool","Water","Poison",4,29,64,new ushort[]{0,14,15,35,38,40,48,51,56,57,58,59,61,62,92,99,102,103,104,109,112,114,127,132,156,164,168,173,182,188,196,202,203,207,213,214,216,218,219,229,237,240,243,258,263,290,291,352})},
            {073,new PokemonStructure(073,73,"Tentacruel","Water","Poison",4,29,64,new ushort[]{0,14,15,35,38,40,48,51,56,57,58,59,61,63,92,99,102,103,104,112,127,132,156,164,168,173,182,188,196,202,203,207,213,214,216,218,237,240,258,263,290,291,352})},
            {074,new PokemonStructure(074,74,"Geodude","Rock","Ground",3,69,5,new ushort[]{0,5,7,33,34,38,53,68,69,70,88,89,91,92,99,102,104,111,118,120,126,153,156,157,164,173,182,189,201,203,205,207,213,214,216,218,222,223,237,241,249,263,264,280,290,300,317,335,350})},
            {075,new PokemonStructure(075,75,"Graveler","Rock","Ground",3,69,5,new ushort[]{0,5,7,33,34,38,53,68,69,70,88,89,91,92,99,102,104,111,118,120,126,153,156,157,164,173,182,189,201,203,205,207,213,214,216,218,222,223,237,241,249,263,264,280,290,300,317,350})},
            {076,new PokemonStructure(076,76,"Golem","Rock","Ground",3,69,5,new ushort[]{0,5,7,25,33,34,38,46,53,63,68,69,70,88,89,91,92,99,102,104,111,118,120,126,153,156,157,164,173,182,189,201,203,205,207,210,213,214,216,218,222,223,237,241,249,263,264,280,290,300,317,350})},
            {077,new PokemonStructure(077,77,"Ponyta","Fire","Nothing",2,50,18,new ushort[]{0,23,24,33,34,36,37,38,39,45,52,53,70,76,83,92,95,97,98,99,102,104,126,129,156,164,172,173,182,203,204,207,213,214,216,218,231,237,241,263,290,315,340})},
            {078,new PokemonStructure(078,78,"Rapidash","Fire","Nothing",2,50,18,new ushort[]{0,23,31,33,34,36,38,39,45,52,53,63,70,76,83,92,97,98,99,102,104,126,129,156,164,173,182,203,207,213,214,216,218,231,237,241,263,290,315,340})},
            {079,new PokemonStructure(079,79,"Slowpoke","Water","Psychic",2,12,20,new ushort[]{0,23,29,33,34,38,45,50,53,55,57,58,59,70,86,89,91,92,93,94,99,102,104,126,129,133,138,148,156,164,173,174,182,187,189,196,203,207,213,214,216,218,219,231,237,240,241,244,247,248,258,263,281,285,290,291,300,347,352})},
            {080,new PokemonStructure(080,80,"Slowbro","Water","Psychic",2,12,20,new ushort[]{0,5,8,25,29,33,34,38,45,50,53,55,57,58,59,63,68,69,70,86,89,91,92,93,94,99,102,104,110,126,129,133,138,148,156,164,173,174,182,189,196,203,207,210,213,214,216,218,219,223,231,237,240,241,244,247,249,258,263,264,280,281,285,290,291,347,352})},
            {081,new PokemonStructure(081,81,"Magnemite","Electric","Steel",2,42,5,new ushort[]{0,33,38,48,49,84,85,86,87,92,99,102,103,104,115,129,148,156,164,173,182,192,199,203,205,207,209,214,216,218,237,240,241,263,290,319,351})},
            {082,new PokemonStructure(082,82,"Magneton","Electric","Steel",2,42,5,new ushort[]{0,33,38,48,49,63,84,85,86,87,92,99,102,103,104,115,129,148,156,161,164,173,182,192,199,203,205,207,209,214,216,218,237,240,241,263,290,319,351})},
            {083,new PokemonStructure(083,83,"Farfetch'd","Normal","Flying",2,51,39,new ushort[]{0,14,15,16,19,28,31,34,38,43,64,92,97,98,99,102,104,119,129,156,163,164,168,173,174,182,189,193,203,206,207,210,211,213,214,216,218,231,237,241,244,263,282,290,297,332})},
            {084,new PokemonStructure(084,84,"Doduo","Normal","Flying",2,50,48,new ushort[]{0,19,31,34,38,45,48,64,65,92,97,98,99,102,104,114,129,156,161,164,168,173,175,182,185,189,203,207,211,213,214,216,218,228,237,241,253,263,283,290,332})},
            {085,new PokemonStructure(085,85,"Dodrio","Normal","Flying",2,50,48,new ushort[]{0,19,31,34,38,45,63,64,65,92,97,99,102,104,129,156,161,164,168,173,182,189,203,207,211,213,214,216,218,228,237,241,253,259,263,269,290,332})},
            {086,new PokemonStructure(086,86,"Seel","Water","Nothing",2,47,0,new ushort[]{0,21,29,32,34,36,38,45,50,57,58,59,62,92,99,102,104,122,127,156,164,168,173,182,195,196,203,207,213,214,216,218,219,227,237,240,252,258,263,290,291,333,352})},
            {087,new PokemonStructure(087,87,"Dewgong","Water","Ice",2,47,0,new ushort[]{0,29,34,36,38,45,57,58,59,62,63,92,99,102,104,127,156,164,168,173,182,196,203,207,213,214,216,218,219,237,240,258,263,290,291,324,329,352})},
            {088,new PokemonStructure(088,88,"Grimer","Poison","Nothing",2,1,60,new ushort[]{0,1,7,8,9,34,38,50,53,85,87,91,92,99,102,103,104,106,107,114,122,124,126,139,151,153,156,164,168,173,174,182,188,189,202,203,207,212,213,214,216,218,223,237,241,259,262,263,269,286,290,317,325,351})},
            {089,new PokemonStructure(089,89,"Muk","Poison","Nothing",2,1,60,new ushort[]{0,1,7,8,9,34,38,50,53,63,70,85,87,91,92,99,102,103,104,106,107,124,126,139,151,153,156,164,168,173,182,188,189,202,203,207,213,214,216,218,223,237,241,249,259,262,263,264,269,280,290,317,351})},
            {090,new PokemonStructure(090,90,"Shellder","Water","Nothing",4,75,0,new ushort[]{0,33,36,38,43,48,57,58,59,61,62,92,99,102,103,104,110,112,128,129,153,156,164,173,182,196,203,207,213,214,216,218,229,237,240,258,263,290,291,333,352})},
            {091,new PokemonStructure(091,91,"Cloyster","Water","Ice",4,75,0,new ushort[]{0,38,48,57,58,59,62,63,92,99,102,104,110,129,131,153,156,164,173,182,191,196,203,207,213,214,216,218,237,240,258,259,263,290,291,352})},
            {092,new PokemonStructure(092,92,"Gastly","Ghost","Poison",3,26,0,new ushort[]{0,38,85,92,94,95,99,101,102,104,109,114,122,138,149,153,156,164,168,171,173,174,180,182,188,194,195,202,203,207,212,213,214,216,218,237,240,241,244,247,259,261,263,269,285,288,289,290,310})},
            {093,new PokemonStructure(093,93,"Haunter","Ghost","Poison",3,26,0,new ushort[]{0,38,85,92,94,95,99,101,102,104,109,122,138,153,156,164,168,171,173,174,180,182,188,194,202,203,207,212,213,214,216,218,237,240,241,244,247,259,263,269,285,289,290,325})},
            {094,new PokemonStructure(094,94,"Gengar","Ghost","Poison",3,26,0,new ushort[]{0,5,7,8,9,25,34,38,63,68,69,70,85,87,92,94,95,99,101,102,104,109,118,122,138,153,156,164,168,171,173,174,180,182,188,194,202,203,207,212,213,214,216,218,223,237,240,241,244,247,249,259,263,264,269,280,285,289,290,325})},
            {095,new PokemonStructure(095,95,"Onix","Rock","Ground",2,69,5,new ushort[]{0,20,21,33,34,38,46,70,88,89,91,92,99,102,103,104,106,153,156,157,164,173,175,182,189,201,203,207,213,214,216,218,225,231,237,241,244,249,259,263,269,290,317,328,335})},
            {096,new PokemonStructure(096,96,"Drowzee","Psychic","Nothing",2,15,0,new ushort[]{0,1,5,7,8,9,25,29,34,38,50,68,69,86,92,93,94,95,96,99,102,104,112,113,115,118,138,139,148,156,164,168,173,182,203,207,213,214,216,218,219,223,237,240,241,244,247,248,259,263,264,269,272,274,280,285,289,290,347})},
            {097,new PokemonStructure(097,97,"Hypno","Psychic","Nothing",2,15,0,new ushort[]{0,1,5,7,8,9,25,29,34,38,50,63,68,69,86,92,93,94,95,96,99,102,104,113,115,118,138,139,148,156,164,168,171,173,182,203,207,213,214,216,218,219,223,237,240,241,244,247,248,259,263,264,269,280,285,289,290,347})},
            {098,new PokemonStructure(098,98,"Krabby","Water","Nothing",2,52,75,new ushort[]{0,11,12,14,15,21,23,34,38,43,57,58,59,70,91,92,99,102,104,106,114,133,145,152,156,164,168,173,175,182,189,196,203,207,210,213,214,216,218,237,240,249,258,263,282,290,291,317,341,352})},
            {099,new PokemonStructure(099,99,"Kingler","Water","Nothing",2,52,75,new ushort[]{0,11,12,14,15,23,34,38,43,57,58,59,63,70,91,92,99,102,104,106,145,152,156,164,168,173,175,182,189,196,203,207,210,213,214,216,218,232,237,240,249,258,263,290,291,317,341,352})},
            {100,new PokemonStructure(100,100,"Voltorb","Electric","Nothing",2,43,9,new ushort[]{0,33,38,49,85,86,87,92,102,103,104,113,120,129,148,153,156,164,168,173,182,203,205,207,209,214,216,218,237,240,243,259,263,268,269,290,351})},
            {101,new PokemonStructure(101,101,"Electrode","Electric","Nothing",2,43,9,new ushort[]{0,33,38,49,63,85,86,87,92,102,103,104,113,120,129,148,153,156,164,168,173,182,203,205,207,209,214,216,218,237,240,243,259,263,268,269,290,351})},
            {102,new PokemonStructure(102,102,"Exeggcute","Grass","Psychic",4,34,0,new ushort[]{0,38,70,73,76,77,78,79,92,93,94,95,99,102,104,113,115,138,140,148,153,156,164,168,173,174,182,188,202,203,205,207,213,214,216,218,235,236,237,241,244,246,253,263,275,285,290,331})},
            {103,new PokemonStructure(103,103,"Exeggutor","Grass","Psychic",4,34,0,new ushort[]{0,23,38,63,70,76,92,93,94,95,99,102,104,113,115,121,138,140,148,153,156,164,168,173,182,188,202,203,205,207,213,214,216,218,237,241,244,263,285,290,331})},
            {104,new PokemonStructure(104,104,"Cubone","Ground","Nothing",2,69,31,new ushort[]{0,5,7,9,14,25,29,34,37,38,39,43,45,53,58,59,68,69,70,89,91,92,99,102,103,104,116,125,126,130,155,156,157,164,168,173,182,187,189,195,196,198,201,203,206,207,213,214,216,218,223,231,237,241,246,249,263,264,280,290,317,332})},
            {105,new PokemonStructure(105,105,"Marowak","Ground","Nothing",2,69,31,new ushort[]{0,5,7,9,14,25,29,34,37,38,39,43,45,53,58,59,63,68,69,70,89,91,92,99,102,104,116,125,126,155,156,157,164,168,173,182,189,196,198,201,203,206,207,213,214,216,218,223,231,237,241,249,263,264,280,290,317,332})},
            {106,new PokemonStructure(106,106,"Hitmonlee","Fighting","Nothing",2,7,0,new ushort[]{0,5,24,25,26,27,34,38,68,69,70,89,92,96,99,102,104,116,118,129,136,156,157,164,168,170,173,179,182,189,193,203,207,213,214,216,218,223,237,241,249,263,264,279,280,290,317,339})},
            {107,new PokemonStructure(107,107,"Hitmonchan","Fighting","Nothing",2,51,0,new ushort[]{0,4,5,7,8,9,25,34,38,68,69,70,89,92,97,99,102,104,118,129,156,157,164,168,173,182,183,189,197,203,207,213,214,216,218,223,228,237,241,249,263,264,279,280,290,317,327,339})},
            {108,new PokemonStructure(108,108,"Lickitung","Normal","Nothing",2,20,12,new ushort[]{0,5,7,8,9,14,15,21,23,25,34,35,38,48,50,53,57,58,59,63,68,69,70,76,85,87,89,91,92,99,102,103,104,111,122,126,138,156,157,164,168,173,174,182,187,189,196,201,203,205,207,213,214,216,218,222,223,231,237,240,241,244,247,249,263,264,265,280,282,287,290,317,351,352})},
            {109,new PokemonStructure(109,109,"Koffing","Poison","Nothing",2,26,0,new ushort[]{0,33,53,60,85,87,92,99,103,104,108,114,120,123,124,126,139,148,149,153,156,168,173,182,188,194,205,213,216,218,220,237,241,247,259,261,262,263,269,290,351})},
            {110,new PokemonStructure(110,110,"Weezing","Poison","Nothing",2,26,0,new ushort[]{0,33,53,63,85,87,92,99,104,108,114,120,123,124,126,139,148,153,156,168,173,182,188,194,205,213,216,218,237,241,247,259,262,263,269,290,351})},
            {111,new PokemonStructure(111,111,"Rhyhorn","Ground","Rock",4,31,69,new ushort[]{0,14,23,30,31,32,36,38,39,46,53,58,59,68,70,85,87,89,91,92,99,102,104,126,156,157,164,168,173,174,179,182,184,189,196,201,203,205,207,213,214,216,218,222,224,231,237,241,242,249,263,290,306,317,350,351})},
            {112,new PokemonStructure(112,112,"Rhydon","Ground","Rock",4,31,69,new ushort[]{0,5,7,9,14,15,23,25,30,31,32,34,36,38,39,46,53,57,58,59,63,68,69,70,85,87,89,91,92,99,102,104,126,156,157,164,168,173,182,184,189,196,201,203,205,207,210,213,214,216,218,223,224,231,237,241,249,263,264,280,290,317,350,351})},
            {113,new PokemonStructure(113,113,"Chansey","Normal","Nothing",1,30,32,new ushort[]{0,1,3,5,25,34,38,39,45,47,53,58,59,63,68,69,70,76,85,86,87,89,92,94,99,102,104,107,111,113,118,121,126,135,138,148,156,164,173,182,189,196,201,203,205,207,213,214,215,216,217,218,219,223,231,237,240,241,244,247,249,258,263,264,280,285,287,289,290,312,317,347,351,352})},
            {114,new PokemonStructure(114,114,"Tangela","Grass","Nothing",2,34,0,new ushort[]{0,14,15,20,21,22,34,38,63,71,72,73,74,76,77,78,79,92,93,99,102,104,115,132,133,148,156,164,168,173,175,182,188,202,203,207,213,214,216,218,237,241,244,249,263,267,275,290,321,331})},
            {115,new PokemonStructure(115,115,"Kangaskhan","Normal","Nothing",2,48,0,new ushort[]{0,4,5,7,8,9,15,23,25,34,38,39,43,44,46,50,53,57,58,59,63,68,69,70,85,87,89,91,92,99,102,104,116,126,146,156,157,164,168,173,179,182,189,193,196,201,203,207,210,213,214,216,218,219,223,231,237,240,241,247,249,252,258,263,264,280,290,306,317,332,351,352})},
            {116,new PokemonStructure(116,116,"Horsea","Water","Nothing",2,33,0,new ushort[]{0,38,43,50,55,56,57,58,59,62,92,97,99,102,104,108,127,129,145,150,156,164,173,175,182,190,196,203,207,213,214,216,218,225,237,239,240,258,263,290,291,349,352})},
            {117,new PokemonStructure(117,117,"Seadra","Water","Nothing",2,38,0,new ushort[]{0,38,43,55,56,57,58,59,63,92,97,99,102,104,108,127,129,145,156,164,173,182,196,203,207,213,214,216,218,237,239,240,258,263,290,291,349,352})},
            {118,new PokemonStructure(118,118,"Goldeen","Water","Nothing",2,33,41,new ushort[]{0,30,31,32,38,39,48,56,57,58,59,60,64,92,97,99,102,104,114,127,129,156,164,173,175,182,196,203,207,213,214,216,218,224,237,240,258,263,290,291,300,346,352})},
            {119,new PokemonStructure(119,119,"Seaking","Water","Nothing",2,33,41,new ushort[]{0,30,31,32,38,39,48,57,58,59,63,64,92,97,99,102,104,127,129,156,164,173,175,182,196,203,207,213,214,216,218,224,237,240,258,263,290,291,346,352})},
            {120,new PokemonStructure(120,120,"Staryu","Water","Nothing",4,35,30,new ushort[]{0,33,38,55,56,57,58,59,61,85,86,87,92,94,99,102,104,105,106,107,113,115,127,129,148,156,164,173,182,196,203,207,214,216,218,229,237,240,244,258,263,290,291,293,322,352})},
            {121,new PokemonStructure(121,121,"Starmie","Water","Psychic",4,35,30,new ushort[]{0,38,55,57,58,59,61,63,85,86,87,92,94,99,102,104,105,109,113,115,127,129,138,148,156,164,173,182,196,203,207,214,216,218,229,237,240,244,258,263,285,290,291,352})},
            {122,new PokemonStructure(122,122,"Mr. Mime","Psychic","Nothing",2,43,0,new ushort[]{0,3,5,7,8,9,25,34,38,63,68,69,76,85,86,87,92,93,94,95,96,99,102,104,112,113,115,118,148,156,164,168,173,182,189,203,207,213,214,216,218,219,226,227,237,241,244,247,248,252,259,263,264,269,271,272,278,280,285,289,290,345,347,351})},
            {123,new PokemonStructure(123,123,"Scyther","Bug","Flying",2,68,0,new ushort[]{0,13,14,15,17,38,43,63,68,92,97,98,99,102,104,113,116,129,156,163,164,168,173,179,182,203,206,207,210,211,213,214,216,218,219,226,228,237,241,249,263,290,318,332})},
            {124,new PokemonStructure(124,124,"Jynx","Ice","Psychic",2,12,0,new ushort[]{0,1,3,5,8,25,34,38,58,59,63,68,69,92,94,99,102,104,113,115,118,122,138,142,148,156,164,168,173,181,182,189,195,196,203,207,212,213,214,216,218,223,237,240,244,247,258,259,263,264,269,280,285,290,313,347,352})},
            {125,new PokemonStructure(125,125,"Electabuzz","Electric","Nothing",2,9,0,new ushort[]{0,5,7,8,9,25,34,38,43,63,68,69,70,85,86,87,92,94,98,99,102,103,104,113,129,148,156,164,168,173,182,189,203,207,213,214,216,218,223,231,237,240,249,263,264,280,290,351})},
            {126,new PokemonStructure(126,126,"Magmar","Fire","Nothing",2,49,0,new ushort[]{0,5,7,9,25,34,38,43,52,53,63,68,69,70,92,94,99,102,104,108,109,123,126,156,164,168,173,182,189,203,207,213,214,216,218,223,231,237,241,249,263,264,280,290})},
            {127,new PokemonStructure(127,127,"Pinsir","Bug","Nothing",4,52,0,new ushort[]{0,11,12,14,15,20,31,34,38,63,66,69,70,89,91,92,99,102,104,106,116,156,157,164,168,173,175,182,185,203,206,207,210,213,214,216,218,237,241,249,263,264,279,280,290,317,339})},
            {128,new PokemonStructure(128,128,"Tauros","Normal","Nothing",4,22,0,new ushort[]{0,30,33,34,36,37,38,39,53,57,58,59,63,70,76,85,87,89,92,99,102,104,126,156,164,173,182,184,196,201,203,207,213,214,216,218,228,231,237,241,249,263,290,317,351,352})},
            {129,new PokemonStructure(129,129,"Magikarp","Water","Nothing",4,33,0,new ushort[]{0,33,150,175})},
            {130,new PokemonStructure(130,130,"Gyarados","Water","Flying",4,22,0,new ushort[]{0,34,37,38,43,44,46,53,56,57,58,59,63,70,82,85,86,87,89,92,99,102,104,126,127,156,164,173,182,196,201,203,207,213,214,216,218,237,239,240,249,258,259,263,269,290,291,349,352})},
            {131,new PokemonStructure(131,131,"Lapras","Water","Ice",4,11,75,new ushort[]{0,32,34,38,45,46,47,54,55,56,57,58,59,63,70,85,87,92,94,99,102,104,109,127,138,156,164,173,174,182,193,195,196,203,207,213,214,216,218,219,231,237,240,249,258,263,287,290,291,321,329,349,351,352})},
            {132,new PokemonStructure(132,132,"Ditto","Normal","Nothing",2,7,0,new ushort[]{0,144})},
            {133,new PokemonStructure(133,133,"Eevee","Normal","Nothing",2,50,0,new ushort[]{0,28,33,34,36,38,39,44,45,91,92,98,99,102,104,129,156,164,173,174,182,189,203,204,207,213,214,216,218,226,231,237,240,241,247,263,270,273,290,321})},
            {134,new PokemonStructure(134,134,"Vaporeon","Water","Nothing",2,11,0,new ushort[]{0,28,33,34,38,39,44,46,55,56,57,58,59,62,63,91,92,98,99,102,104,114,127,129,151,156,164,173,182,189,196,203,207,213,214,216,218,231,237,240,241,247,258,263,270,290,291,352})},
            {135,new PokemonStructure(135,135,"Jolteon","Electric","Nothing",2,10,0,new ushort[]{0,24,28,33,34,38,39,42,46,63,84,85,86,87,91,92,97,98,99,102,104,129,148,156,164,173,182,189,203,207,213,214,216,218,231,237,240,241,247,263,270,290,351})},
            {136,new PokemonStructure(136,136,"Flareon","Fire","Nothing",2,18,0,new ushort[]{0,28,33,34,38,39,43,44,46,52,53,63,83,91,92,98,99,102,104,123,126,129,156,164,173,182,189,203,207,213,214,216,218,231,237,240,241,247,263,270,290,315})},
            {137,new PokemonStructure(137,137,"Porygon","Normal","Nothing",2,36,0,new ushort[]{0,33,38,58,59,60,63,76,85,86,87,92,94,97,99,102,104,105,129,138,148,156,159,160,161,164,168,173,176,182,192,196,199,203,207,214,216,218,231,237,240,241,244,247,263,278,290,332,351})},
            {138,new PokemonStructure(138,138,"Omanyte","Rock","Water",2,33,75,new ushort[]{0,21,34,38,43,44,48,55,56,57,58,59,61,62,92,99,102,104,110,114,127,132,156,157,164,168,173,182,191,196,201,203,205,207,213,214,216,218,237,240,246,249,258,263,290,291,317,321,341,352})},
            {139,new PokemonStructure(139,139,"Omastar","Rock","Water",2,33,75,new ushort[]{0,34,38,43,44,55,56,57,58,59,63,69,92,99,102,104,110,127,131,132,156,157,164,168,173,182,196,201,203,205,207,213,214,216,218,237,240,246,249,258,263,290,291,317,321,341,352})},
            {140,new PokemonStructure(140,140,"Kabuto","Rock","Water",2,33,4,new ushort[]{0,10,28,34,38,43,57,58,59,61,62,71,72,91,92,99,102,104,106,109,127,156,157,164,168,173,182,196,201,202,203,205,207,213,214,216,218,229,237,240,246,249,258,263,282,290,317,319,332,341,352})},
            {141,new PokemonStructure(141,141,"Kabutops","Rock","Water",2,33,4,new ushort[]{0,10,14,15,25,28,34,38,43,57,58,59,63,69,71,72,91,92,99,102,104,106,127,156,157,163,164,168,173,182,196,201,202,203,205,207,210,213,214,216,218,237,240,246,249,258,263,280,290,291,317,319,332,341,352})},
            {142,new PokemonStructure(142,142,"Aerodactyl","Rock","Flying",4,69,46,new ushort[]{0,17,18,19,36,38,44,46,48,53,63,89,92,97,99,102,104,126,129,156,157,164,168,173,174,182,184,193,201,203,207,211,213,214,216,218,225,228,231,237,240,241,246,249,259,263,269,290,317,332,337})},
            {143,new PokemonStructure(143,143,"Snorlax","Normal","Nothing",4,17,47,new ushort[]{0,5,7,8,9,25,29,33,34,38,53,57,58,59,63,68,69,70,76,85,87,89,90,92,94,99,102,104,111,118,122,126,133,156,157,164,173,174,182,187,189,196,201,203,204,205,207,213,214,216,218,223,237,240,241,244,247,263,264,280,281,290,317,335,343,351,352})},
            {144,new PokemonStructure(144,144,"Articuno","Ice","Flying",4,46,0,new ushort[]{0,16,19,38,46,54,58,59,63,92,97,99,102,104,115,129,156,164,170,173,181,182,189,196,201,203,207,211,214,216,218,237,240,241,249,258,263,290,329,332,352})},
            {145,new PokemonStructure(145,145,"Zapdos","Electric","Flying",4,46,0,new ushort[]{0,19,38,46,63,64,65,84,85,86,87,92,97,99,102,104,113,129,148,156,164,173,182,189,197,201,203,207,211,214,216,218,237,240,241,249,263,268,290,332,351})},
            {146,new PokemonStructure(146,146,"Moltres","Fire","Flying",4,46,0,new ushort[]{0,17,19,38,46,52,53,63,83,92,97,99,102,104,126,129,143,156,164,173,182,189,201,203,207,211,214,216,218,219,237,240,241,249,257,263,290,315,332})},
            {147,new PokemonStructure(147,147,"Dratini","Dragon","Nothing",4,61,0,new ushort[]{0,21,34,35,38,43,48,53,54,57,58,59,63,82,85,86,87,92,97,99,102,104,113,114,126,127,129,156,164,173,182,196,200,203,207,213,214,216,218,219,225,231,237,239,240,241,258,263,290,349,351,352})},
            {148,new PokemonStructure(148,148,"Dragonair","Dragon","Nothing",4,61,0,new ushort[]{0,21,34,35,38,43,53,57,58,59,63,82,85,86,87,92,97,99,102,104,126,127,129,156,164,173,182,196,200,203,207,213,214,216,218,219,231,237,239,240,241,258,263,290,351,352})},
            {149,new PokemonStructure(149,149,"Dragonite","Dragon","Flying",4,39,0,new ushort[]{0,7,8,9,17,19,21,34,35,38,43,46,53,57,58,59,63,70,82,85,86,89,92,97,99,102,104,126,127,129,156,164,173,182,189,196,200,201,203,207,210,211,213,214,216,218,219,223,231,237,239,240,241,249,258,263,264,280,290,291,317,332,337,351,352})},
            {150,new PokemonStructure(150,150,"Mewtwo","Psychic","Nothing",4,46,0,new ushort[]{0,5,7,8,9,25,34,38,50,53,54,58,59,63,68,69,70,76,85,86,87,89,92,93,94,99,102,104,105,112,113,115,118,126,129,133,138,148,156,164,173,182,189,196,201,203,207,214,216,218,219,223,231,237,240,241,244,247,248,249,258,259,263,264,269,280,285,289,290,317,332,339,347,351,352})},
            {151,new PokemonStructure(151,151,"Mew","Psychic","Nothing",3,28,0,new ushort[]{0,1,5,7,8,9,14,15,19,25,34,38,46,53,57,58,59,63,68,69,70,76,85,86,87,89,91,92,94,99,102,104,111,113,115,118,126,127,129,135,138,144,148,153,156,157,164,168,173,182,188,189,196,201,202,203,205,207,210,211,213,214,216,218,219,223,231,237,240,241,244,246,247,249,258,259,263,264,269,280,285,289,290,291,315,317,331,332,337,339,347,351,352})},
            {152,new PokemonStructure(152,152,"Chikorita","Grass","Nothing",3,65,0,new ushort[]{0,14,15,22,33,34,38,45,68,73,75,76,77,92,99,102,104,113,115,148,156,164,173,175,182,189,202,203,207,213,214,216,218,219,231,235,237,241,246,263,267,275,290,320,331})},
            {153,new PokemonStructure(153,153,"Bayleef","Grass","Nothing",3,65,0,new ushort[]{0,14,15,33,34,38,45,68,70,75,76,77,92,99,102,104,113,115,148,156,164,173,182,189,202,203,207,210,213,214,216,218,219,231,235,237,241,249,263,290,331})},
            {154,new PokemonStructure(154,154,"Meganium","Grass","Nothing",3,65,0,new ushort[]{0,14,15,33,34,38,45,63,68,70,75,76,77,89,92,99,102,104,113,115,148,156,164,173,182,189,202,203,207,210,213,214,216,218,219,231,235,237,241,249,263,290,331})},
            {155,new PokemonStructure(155,155,"Cyndaquil","Fire","Nothing",3,66,0,new ushort[]{0,15,33,34,37,38,43,52,53,91,92,98,99,102,104,108,111,126,129,154,156,164,172,173,179,182,189,193,203,205,207,213,214,216,218,237,241,263,290,306,315,332,336,343})},
            {156,new PokemonStructure(156,156,"Quilava","Fire","Nothing",3,66,0,new ushort[]{0,15,33,34,38,43,46,52,53,70,91,92,98,99,102,104,108,111,126,129,156,164,172,173,182,189,203,205,207,210,213,214,216,218,237,241,249,263,264,280,290,315,332})},
            {157,new PokemonStructure(157,157,"Typhlosion","Fire","Nothing",3,66,0,new ushort[]{0,5,7,9,15,25,33,34,38,43,46,52,53,63,68,69,70,89,91,92,98,99,102,104,108,111,126,129,156,157,164,172,173,182,189,203,205,207,210,213,214,216,218,223,237,241,249,263,264,280,290,315,332})},
            {158,new PokemonStructure(158,158,"Totodile","Water","Nothing",3,67,0,new ushort[]{0,5,8,10,14,15,25,34,37,38,43,44,55,56,57,58,59,68,69,91,92,99,102,103,104,127,156,157,163,164,173,182,184,189,196,203,207,213,214,216,218,223,231,237,240,242,246,258,263,264,280,290,291,300,332,337,346,352})},
            {159,new PokemonStructure(159,159,"Croconaw","Water","Nothing",3,67,0,new ushort[]{0,5,8,10,14,15,25,34,38,43,44,46,55,56,57,58,59,68,69,70,91,92,99,102,103,104,127,156,157,163,164,173,182,184,189,196,203,207,210,213,214,216,218,223,231,237,240,249,258,263,264,280,290,291,332,352})},
            {160,new PokemonStructure(160,160,"Feraligatr","Water","Nothing",3,67,0,new ushort[]{0,5,8,10,14,15,25,34,38,43,44,46,55,56,57,58,59,63,68,69,70,89,91,92,99,102,103,104,127,156,157,163,164,173,182,184,189,196,203,207,210,213,214,216,218,223,231,237,240,249,258,263,264,280,290,291,332,337,352})},
            {161,new PokemonStructure(161,161,"Sentret","Normal","Nothing",2,50,51,new ushort[]{0,7,8,9,15,21,34,38,53,57,58,85,91,92,98,99,102,104,111,116,129,133,154,156,163,164,168,173,179,182,189,203,205,207,210,213,214,216,218,223,228,231,237,241,247,263,264,266,270,271,274,280,290,351,352})},
            {162,new PokemonStructure(162,162,"Furret","Normal","Nothing",2,50,51,new ushort[]{0,7,8,9,10,15,21,34,38,53,57,58,59,63,70,85,87,91,92,98,99,102,104,111,129,133,154,156,164,168,173,182,189,203,205,207,210,213,214,216,218,223,231,237,241,247,249,263,264,266,270,280,290,351,352})},
            {163,new PokemonStructure(163,163,"Hoothoot","Normal","Flying",2,15,51,new ushort[]{0,17,18,19,33,36,38,45,48,64,92,93,94,95,99,102,104,115,119,129,138,143,148,156,164,168,173,182,185,189,193,203,207,211,213,214,216,218,237,241,247,263,290,297,332})},
            {164,new PokemonStructure(164,164,"Noctowl","Normal","Flying",2,15,51,new ushort[]{0,19,33,36,38,45,63,64,92,93,94,95,99,102,104,115,129,138,148,156,164,168,173,182,189,193,203,207,211,213,214,216,218,237,241,247,263,290,332})},
            {165,new PokemonStructure(165,165,"Ledyba","Bug","Flying",1,68,48,new ushort[]{0,4,5,8,9,14,25,33,38,48,60,76,91,92,97,99,102,104,113,115,117,129,148,156,164,168,173,182,202,203,205,207,213,214,216,218,219,223,226,237,241,263,264,280,290,318,332})},
            {166,new PokemonStructure(166,166,"Ledian","Bug","Flying",1,68,48,new ushort[]{0,4,5,8,9,14,25,33,38,48,63,76,91,92,97,99,102,104,113,115,129,148,156,164,168,173,182,202,203,205,207,213,214,216,218,219,223,226,237,241,263,264,280,290,332})},
            {167,new PokemonStructure(167,167,"Spinarak","Bug","Poison",1,68,15,new ushort[]{0,34,38,40,49,50,60,76,81,91,92,94,97,99,101,102,104,132,141,148,154,156,164,168,169,173,182,184,188,202,203,207,213,214,216,218,226,228,237,241,263,290,324})},
            {168,new PokemonStructure(168,168,"Ariados","Bug","Poison",1,68,15,new ushort[]{0,34,38,40,63,76,81,91,92,94,97,99,101,102,104,132,141,148,154,156,164,168,169,173,182,184,188,202,203,207,213,214,216,218,237,241,263,290})},
            {169,new PokemonStructure(169,169,"Crobat","Poison","Flying",2,39,0,new ushort[]{0,17,19,38,44,48,63,92,99,102,103,104,109,114,129,141,156,164,168,173,182,188,202,203,207,211,212,213,214,216,218,237,241,247,259,263,269,289,290,305,310,314,332})},
            {170,new PokemonStructure(170,170,"Chinchou","Water","Electric",4,10,35,new ushort[]{0,36,38,48,55,56,57,58,59,85,86,87,92,99,102,103,104,109,127,133,145,148,156,164,173,175,182,203,207,209,213,214,216,218,237,258,263,268,290,291,351,352})},
            {171,new PokemonStructure(171,171,"Lanturn","Water","Electric",4,10,35,new ushort[]{0,36,38,48,55,56,57,58,59,63,85,86,87,92,99,102,104,109,127,145,148,156,164,173,175,182,203,207,209,213,214,216,218,237,240,258,263,268,290,291,351,352})},
            {172,new PokemonStructure(172,172,"Pichu","Electric","Nothing",2,9,0,new ushort[]{0,3,5,25,34,38,39,68,69,84,85,86,87,92,99,102,104,111,113,117,129,148,156,164,173,179,182,186,189,203,204,205,207,213,214,216,217,218,227,231,237,240,263,268,273,290,344,351})},
            {173,new PokemonStructure(173,173,"Cleffa","Normal","Nothing",1,56,0,new ushort[]{0,1,5,25,34,38,47,53,68,69,76,86,91,92,94,99,102,104,111,113,115,118,126,133,135,138,148,150,156,164,173,182,186,187,189,196,203,204,205,207,213,214,216,217,218,219,227,231,237,240,241,244,247,263,273,290,345,351,352})},
            {174,new PokemonStructure(174,174,"Igglybuff","Normal","Nothing",1,56,0,new ushort[]{0,1,5,25,34,38,47,53,68,69,76,86,91,92,94,99,102,104,111,113,115,126,138,148,156,164,173,182,185,186,189,195,196,203,204,205,207,213,214,216,217,218,219,237,240,241,244,247,263,273,290,313,351,352})},
            {175,new PokemonStructure(175,175,"Togepi","Normal","Nothing",1,55,32,new ushort[]{0,5,25,34,38,45,53,64,68,69,76,86,92,94,99,102,104,111,113,115,118,119,126,129,135,138,148,156,164,173,182,186,189,193,203,204,205,207,213,214,216,217,218,219,226,227,237,240,241,244,246,247,248,249,263,266,273,281,290,351,352})},
            {176,new PokemonStructure(176,176,"Togetic","Normal","Flying",1,55,32,new ushort[]{0,5,19,25,34,38,45,53,63,68,69,76,86,92,94,99,102,104,111,113,115,118,126,129,135,138,148,156,164,173,182,186,189,203,204,205,207,211,213,214,216,218,219,226,227,237,240,241,244,246,247,249,263,264,266,273,280,281,290,332,345,351,352})},
            {177,new PokemonStructure(177,177,"Natu","Psychic","Flying",2,28,48,new ushort[]{0,38,43,64,65,76,86,92,94,98,99,100,101,102,104,109,113,114,115,129,138,148,156,164,168,173,182,185,202,203,207,211,213,214,216,218,237,241,244,247,248,263,273,285,287,290,297,332,347})},
            {178,new PokemonStructure(178,178,"Xatu","Psychic","Flying",2,28,48,new ushort[]{0,19,38,43,63,64,76,86,92,94,99,100,101,102,104,109,113,115,129,138,148,156,164,168,173,182,202,203,207,211,213,214,216,218,237,241,244,247,248,263,273,285,290,332,347})},
            {179,new PokemonStructure(179,179,"Mareep","Electric","Nothing",3,9,0,new ushort[]{0,33,34,36,38,45,84,85,86,87,92,99,102,103,104,111,113,115,129,148,156,164,173,178,182,203,207,213,214,216,218,219,231,237,240,260,263,268,290,316,351})},
            {180,new PokemonStructure(180,180,"Flaaffy","Electric","Nothing",3,9,0,new ushort[]{0,5,7,9,25,33,34,38,45,68,69,70,84,85,86,87,92,99,102,104,111,113,129,148,156,164,173,178,182,203,207,213,214,216,218,223,231,237,240,249,263,264,280,290,351})},
            {181,new PokemonStructure(181,181,"Ampharos","Electric","Nothing",3,9,0,new ushort[]{0,5,7,9,25,33,34,38,45,63,68,69,70,84,85,86,87,92,99,102,104,111,113,129,148,156,164,173,178,182,203,207,213,214,216,218,223,231,237,240,249,263,264,280,290,351})},
            {182,new PokemonStructure(182,182,"Bellossom","Grass","Nothing",3,34,0,new ushort[]{0,14,15,38,63,71,76,78,80,92,99,102,104,148,156,164,173,182,188,202,203,207,213,214,216,218,219,230,237,241,263,290,331,345})},
            {183,new PokemonStructure(183,183,"Marill","Water","Nothing",1,47,37,new ushort[]{0,5,8,25,33,34,38,39,48,55,56,57,58,59,61,69,70,91,92,99,102,104,111,113,127,129,133,156,164,173,182,187,189,195,196,203,205,207,213,214,216,217,218,223,231,237,240,248,249,258,263,264,280,290,291,352})},
            {184,new PokemonStructure(184,184,"Azumarill","Water","Nothing",1,47,37,new ushort[]{0,5,8,25,33,34,38,39,55,56,57,58,59,61,63,69,70,91,92,99,102,104,111,127,129,156,164,173,182,189,196,203,205,207,213,214,216,218,223,231,237,240,249,258,263,264,280,290,291,352})},
            {185,new PokemonStructure(185,185,"Sudowoodo","Rock","Nothing",2,5,69,new ushort[]{0,5,7,8,9,21,25,34,38,67,68,69,70,88,89,91,92,99,102,104,111,120,153,156,157,164,168,173,175,182,185,189,201,203,205,207,213,214,216,218,223,237,241,244,249,263,264,269,280,290,317,335,347})},
            {186,new PokemonStructure(186,186,"Politoed","Water","Nothing",3,11,6,new ushort[]{0,3,5,25,34,38,55,57,58,59,63,68,69,70,89,91,92,94,95,99,102,104,111,118,127,156,164,168,173,182,189,195,196,203,207,213,214,216,218,223,237,240,249,258,263,264,280,290,291,352})},
            {187,new PokemonStructure(187,187,"Hoppip","Grass","Flying",3,34,0,new ushort[]{0,14,33,38,39,72,73,76,77,78,79,92,93,99,102,104,111,115,133,148,150,156,164,173,178,182,202,203,207,213,214,216,218,227,235,237,241,244,263,270,290,331,332})},
            {188,new PokemonStructure(188,188,"Skiploom","Grass","Flying",3,34,0,new ushort[]{0,14,33,38,39,72,73,76,77,78,79,92,99,102,104,111,148,150,156,164,173,178,182,202,203,207,213,214,216,218,235,237,241,263,290,331,332})},
            {189,new PokemonStructure(189,189,"Jumpluff","Grass","Flying",3,34,0,new ushort[]{0,14,33,38,39,63,72,73,76,77,78,79,92,99,102,104,111,148,150,156,164,173,178,182,202,203,207,213,214,216,218,235,237,241,263,290,331,332})},
            {190,new PokemonStructure(190,190,"Aipom","Normal","Nothing",1,50,53,new ushort[]{0,3,5,7,8,9,10,15,21,25,28,34,38,39,68,69,70,76,85,86,87,91,92,97,99,102,103,104,111,118,129,138,154,156,164,168,173,180,182,189,203,207,210,213,214,216,218,223,226,228,231,237,241,247,249,251,263,264,269,280,289,290,310,321,332,351,352})},
            {191,new PokemonStructure(191,191,"Sunkern","Grass","Nothing",3,34,0,new ushort[]{0,14,15,38,71,72,73,74,76,92,99,102,104,113,148,156,164,173,174,182,188,202,203,207,213,214,216,218,219,227,235,237,241,263,267,270,275,283,290,320,331})},
            {192,new PokemonStructure(192,192,"Sunflora","Grass","Nothing",3,34,0,new ushort[]{0,1,14,15,38,63,71,74,75,76,80,92,99,102,104,113,148,156,164,173,182,188,202,203,207,213,214,216,218,219,237,241,263,275,290,331})},
            {193,new PokemonStructure(193,193,"Yanma","Bug","Flying",2,3,14,new ushort[]{0,17,18,33,38,48,49,76,92,94,95,98,99,102,103,104,129,138,141,148,156,164,168,173,179,182,193,197,202,203,207,211,213,214,216,218,237,241,247,253,263,290,318,324,332})},
            {194,new PokemonStructure(194,194,"Wooper","Water","Ground",2,6,11,new ushort[]{0,8,21,34,38,39,54,55,57,58,59,89,91,92,99,102,104,111,114,127,133,148,156,164,173,174,182,188,189,201,203,205,207,213,214,216,218,219,223,231,237,240,246,249,254,255,256,258,263,281,290,291,300,341,352})},
            {195,new PokemonStructure(195,195,"Quagsire","Water","Ground",2,6,11,new ushort[]{0,5,8,21,25,34,38,39,54,55,57,58,59,63,68,69,70,89,91,92,99,102,104,111,114,127,133,148,156,164,173,182,188,189,201,203,205,207,213,214,216,218,223,231,237,240,249,258,263,264,280,281,290,291,317,341,352})},
            {196,new PokemonStructure(196,196,"Espeon","Psychic","Nothing",2,28,0,new ushort[]{0,15,28,33,34,38,39,60,63,91,92,93,94,98,99,102,104,113,115,129,138,148,156,164,173,182,189,203,207,213,214,216,218,231,234,237,240,241,244,247,263,270,285,290,347})},
            {197,new PokemonStructure(197,197,"Umbreon","Dark","Nothing",2,28,0,new ushort[]{0,15,28,33,34,38,39,63,91,92,94,98,99,102,103,104,109,129,138,148,156,164,173,182,185,189,203,207,212,213,214,216,218,228,231,236,237,240,241,244,247,259,263,269,270,289,290})},
            {198,new PokemonStructure(198,198,"Murkrow","Dark","Flying",3,15,0,new ushort[]{0,17,18,19,38,64,65,86,92,99,101,102,104,109,114,119,129,138,143,156,164,168,173,182,185,189,195,196,203,207,211,212,213,214,216,218,228,237,241,244,247,259,263,269,289,290,297,310,332,347})},
            {199,new PokemonStructure(199,199,"Slowking","Water","Psychic",2,12,20,new ushort[]{0,5,8,25,29,33,34,38,45,50,53,55,57,58,59,63,68,69,70,86,89,91,92,93,94,99,102,104,126,129,138,148,156,164,173,174,182,189,196,203,207,210,213,214,216,218,219,223,231,237,240,241,244,247,249,258,263,264,280,281,285,290,291,347,352})},
            {200,new PokemonStructure(200,200,"Misdreavus","Ghost","Nothing",1,26,0,new ushort[]{0,38,45,60,85,86,87,92,94,99,102,103,104,109,111,129,138,148,149,156,164,168,173,180,182,194,195,203,207,212,213,214,216,218,220,237,240,241,244,247,259,263,269,285,286,288,289,290,310,332,347,351})},
            {201,new PokemonStructure(201,201,"Unown A","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {202,new PokemonStructure(202,202,"Wobbuffet","Psychic","Nothing",2,23,0,new ushort[]{0,68,194,219,243})},
            {203,new PokemonStructure(203,203,"Girafarig","Normal","Psychic",2,39,48,new ushort[]{0,23,33,34,36,38,45,60,70,85,86,87,89,92,93,94,97,99,102,104,113,115,129,133,138,148,156,164,168,173,182,189,193,203,207,213,214,216,218,226,231,237,241,242,244,247,248,249,251,263,273,277,285,290,310,316,347,351})},
            {204,new PokemonStructure(204,204,"Pineco","Bug","Nothing",2,5,0,new ushort[]{0,33,34,36,38,42,68,70,76,89,91,92,99,102,104,111,113,115,117,120,129,153,156,157,164,173,175,182,191,201,202,203,205,207,213,214,216,218,229,237,241,249,263,290,328})},
            {205,new PokemonStructure(205,205,"Forretress","Bug","Steel",2,5,0,new ushort[]{0,33,34,36,38,63,68,70,76,89,91,92,99,102,104,111,113,115,117,120,153,156,157,164,173,182,191,192,201,202,203,205,207,213,214,216,218,229,237,241,249,263,290})},
            {206,new PokemonStructure(206,206,"Dunsparce","Normal","Nothing",2,32,50,new ushort[]{0,29,34,36,38,44,53,58,59,68,70,76,85,86,87,89,91,92,99,102,103,104,111,117,126,137,138,156,157,164,168,173,174,175,180,182,189,203,205,207,213,214,216,218,228,231,237,240,241,244,246,247,249,263,281,283,290,310,317,347,351,352})},
            {207,new PokemonStructure(207,207,"Gligar","Ground","Flying",3,52,8,new ushort[]{0,12,13,14,15,17,28,38,40,68,70,89,91,92,98,99,102,103,104,106,129,138,156,157,163,164,168,173,182,185,188,201,203,207,210,211,213,214,216,218,231,232,237,241,249,263,290,317,328,332})},
            {208,new PokemonStructure(208,208,"Steelix","Steel","Ground",2,69,5,new ushort[]{0,15,20,21,33,34,38,46,63,70,88,89,91,92,99,102,103,104,106,111,153,156,157,164,173,182,189,201,203,205,207,213,214,216,218,225,231,237,241,242,249,259,263,269,290,317})},
            {209,new PokemonStructure(209,209,"Snubbull","Normal","Nothing",1,22,50,new ushort[]{0,5,7,8,9,25,33,34,36,38,39,44,46,53,68,69,70,76,85,86,87,89,91,92,99,102,104,111,115,118,122,126,156,164,168,173,182,184,185,188,189,203,204,207,213,214,215,216,217,218,223,237,240,241,242,247,249,259,263,264,265,269,280,290,315,339,351,352})},
            {210,new PokemonStructure(210,210,"Granbull","Normal","Nothing",1,22,0,new ushort[]{0,5,7,8,9,25,33,34,36,38,39,44,46,53,63,68,69,70,76,85,86,87,89,91,92,99,102,104,111,118,122,126,156,157,164,168,173,182,184,188,189,203,204,207,213,214,216,218,223,231,237,240,241,242,247,249,259,263,264,269,280,290,315,317,339,351,352})},
            {211,new PokemonStructure(211,211,"Qwilfish","Water","Poison",2,38,33,new ushort[]{0,14,33,36,38,40,42,48,55,56,57,58,59,61,86,92,99,102,104,106,107,111,114,127,129,156,164,173,175,182,188,191,194,196,203,205,207,213,214,216,218,237,240,247,258,263,279,290,291,310,351,352})},
            {212,new PokemonStructure(212,212,"Scizor","Bug","Steel",2,68,0,new ushort[]{0,14,15,38,43,63,68,70,92,97,98,99,102,104,116,129,156,163,164,168,173,182,201,203,206,207,210,211,213,214,216,218,228,232,237,241,249,263,290,332,334})},
            {213,new PokemonStructure(213,213,"Shuckle","Bug","Rock",3,5,0,new ushort[]{0,34,35,38,70,89,91,92,99,102,104,110,111,117,132,148,156,157,164,173,182,188,189,201,203,205,207,213,214,216,218,219,227,230,237,241,249,263,290,317})},
            {214,new PokemonStructure(214,214,"Heracross","Bug","Fighting",4,68,62,new ushort[]{0,14,15,30,31,33,34,36,38,43,63,68,69,70,89,91,92,99,102,104,106,117,156,157,164,168,173,175,179,182,203,206,207,210,213,214,216,218,224,237,241,249,263,264,280,290,317,339})},
            {215,new PokemonStructure(215,215,"Sneasel","Dark","Ice",3,39,51,new ushort[]{0,8,10,14,15,38,43,44,57,58,59,68,70,91,92,97,98,99,102,103,104,111,115,129,138,154,156,163,164,168,173,180,182,185,189,193,196,203,207,210,213,214,216,218,223,231,232,237,240,241,244,247,249,251,252,258,259,263,264,269,280,289,290,306,332,347})},
            {216,new PokemonStructure(216,216,"Teddiursa","Normal","Nothing",2,53,0,new ushort[]{0,5,7,8,9,10,14,15,25,34,36,37,38,43,46,68,69,70,89,91,92,99,102,104,111,116,118,122,129,154,156,163,164,168,173,182,185,189,203,205,207,210,213,214,216,218,223,232,237,241,242,249,259,263,264,269,280,281,290,313,332,339})},
            {217,new PokemonStructure(217,217,"Ursaring","Normal","Nothing",2,62,0,new ushort[]{0,5,7,8,9,10,14,15,25,34,37,38,43,46,63,68,69,70,89,91,92,99,102,104,111,118,122,129,154,156,157,163,164,168,173,182,185,189,203,205,207,210,213,214,216,218,223,237,241,249,259,263,264,269,280,290,313,317,332,339})},
            {218,new PokemonStructure(218,218,"Slugma","Fire","Nothing",2,40,49,new ushort[]{0,34,38,52,53,88,92,99,102,104,106,111,113,115,123,126,133,151,156,157,164,173,182,189,203,205,207,213,214,216,218,237,241,249,257,263,281,290,315})},
            {219,new PokemonStructure(219,219,"Magcargo","Fire","Rock",2,40,49,new ushort[]{0,34,38,52,53,63,70,88,89,92,99,102,104,106,111,113,115,123,126,133,156,157,164,173,182,189,201,203,205,207,213,214,216,218,237,241,249,263,281,290,315,317})},
            {220,new PokemonStructure(220,220,"Swinub","Ice","Ground",4,12,0,new ushort[]{0,33,34,36,38,44,46,54,58,59,70,89,91,92,99,102,104,111,113,115,133,156,157,164,173,181,182,189,196,201,203,207,213,214,216,218,237,240,246,249,258,263,290,316,317,333,341})},
            {221,new PokemonStructure(221,221,"Piloswine","Ice","Ground",4,12,0,new ushort[]{0,30,31,34,36,38,46,54,58,59,63,70,89,91,92,99,102,104,111,113,115,133,156,157,164,173,181,182,189,196,201,203,207,213,214,216,218,237,240,249,258,263,290,316,317})},
            {222,new PokemonStructure(222,222,"Corsola","Water","Rock",1,55,30,new ushort[]{0,33,34,38,54,57,58,59,61,70,89,91,92,94,99,102,103,104,105,106,109,111,112,113,115,131,133,145,153,156,157,164,173,182,189,201,203,205,207,213,214,216,218,219,237,240,241,243,246,247,249,258,263,275,287,290,317,333,347,350,352})},
            {223,new PokemonStructure(223,223,"Remoraid","Water","Nothing",2,55,0,new ushort[]{0,38,48,53,55,57,58,59,60,61,62,63,86,92,94,99,102,103,104,111,114,116,126,127,129,156,164,168,173,182,189,190,199,203,207,213,214,216,218,237,240,241,263,290,291,350,352})},
            {224,new PokemonStructure(224,224,"Octillery","Water","Nothing",2,21,0,new ushort[]{0,38,53,55,57,58,59,60,61,62,63,69,86,92,94,99,102,104,111,116,126,127,129,132,156,164,168,173,182,188,189,190,203,207,213,214,216,218,237,240,241,263,290,291,331,352})},
            {225,new PokemonStructure(225,225,"Delibird","Ice","Flying",1,72,55,new ushort[]{0,5,19,25,34,38,58,59,62,68,69,92,98,99,102,104,129,150,156,164,168,173,182,189,196,203,207,213,214,216,217,218,229,237,240,248,258,263,264,290,301,332,352})},
            {226,new PokemonStructure(226,226,"Mantine","Water","Flying",4,33,11,new ushort[]{0,17,21,33,34,36,38,48,56,57,58,59,61,89,92,97,99,102,104,109,114,127,129,145,156,157,164,168,173,182,189,196,203,207,213,214,216,218,237,239,240,258,263,290,291,300,332,352})},
            {227,new PokemonStructure(227,227,"Skarmory","Steel","Flying",4,51,5,new ushort[]{0,15,18,19,28,31,38,43,46,64,65,68,92,97,99,102,104,129,143,156,157,164,168,173,174,182,189,191,201,203,207,211,213,214,216,218,228,237,241,249,259,263,269,290,314,319,332})},
            {228,new PokemonStructure(228,228,"Houndour","Dark","Fire",4,48,18,new ushort[]{0,34,38,43,44,46,52,53,68,76,83,92,99,102,104,123,126,129,138,156,164,168,173,179,180,182,185,188,189,203,207,213,214,216,218,228,231,237,241,242,247,249,251,259,261,263,269,289,290,315,316,336})},
            {229,new PokemonStructure(229,229,"Houndoom","Dark","Fire",4,48,18,new ushort[]{0,34,38,43,44,46,52,53,63,68,70,76,92,99,102,104,123,126,129,138,156,164,168,173,182,185,188,189,203,207,213,214,216,218,231,237,241,242,247,249,259,263,269,289,290,315,316,336})},
            {230,new PokemonStructure(230,230,"Kingdra","Water","Dragon",2,33,0,new ushort[]{0,34,38,43,55,56,57,58,59,63,92,97,99,102,104,108,127,129,145,156,164,173,182,196,203,207,213,214,216,218,237,239,240,258,263,290,291,349,352})},
            {231,new PokemonStructure(231,231,"Phanpy","Ground","Nothing",2,53,0,new ushort[]{0,33,34,36,38,45,46,68,70,89,90,92,99,102,104,111,116,156,164,173,175,182,189,201,203,205,207,213,214,216,218,231,237,241,246,249,263,290,316,317})},
            {232,new PokemonStructure(232,232,"Donphan","Ground","Nothing",2,5,0,new ushort[]{0,30,31,34,38,45,46,63,68,70,89,92,99,102,104,111,156,157,164,173,175,182,189,201,203,205,207,213,214,216,218,229,231,237,241,249,263,290,316,317})},
            {233,new PokemonStructure(233,233,"Porygon2","Normal","Nothing",2,36,0,new ushort[]{0,33,38,58,59,60,63,76,85,86,87,92,94,97,99,102,104,105,111,129,138,148,156,160,161,164,168,173,176,182,192,196,199,203,207,214,216,218,231,237,240,241,244,247,263,278,290,332,351})},
            {234,new PokemonStructure(234,234,"Stantler","Normal","Nothing",4,22,0,new ushort[]{0,23,28,33,34,36,38,43,44,46,50,76,85,86,87,89,92,94,95,99,102,104,109,113,115,129,138,148,156,164,168,173,180,182,189,203,207,213,214,216,218,231,237,240,241,244,247,263,272,285,290,310,326,347,351})},
            {235,new PokemonStructure(235,235,"Smeargle","Normal","Nothing",1,20,0,new ushort[]{0,166})},
            {236,new PokemonStructure(236,236,"Tyrogue","Fighting","Nothing",2,62,0,new ushort[]{0,25,33,34,38,68,69,70,89,92,99,102,104,129,136,156,157,164,168,170,173,182,183,189,203,207,213,214,216,218,229,237,241,249,263,270,280,290,339})},
            {237,new PokemonStructure(237,237,"Hitmontop","Fighting","Nothing",2,22,0,new ushort[]{0,25,27,34,38,68,69,70,89,91,92,97,98,99,102,104,116,129,156,157,164,167,168,173,182,189,197,201,203,207,213,214,216,218,228,229,237,241,249,263,279,280,283,290,339})},
            {238,new PokemonStructure(238,238,"Smoochum","Ice","Psychic",2,12,0,new ushort[]{0,1,5,8,25,34,38,47,58,59,68,69,92,93,94,96,99,102,104,113,115,118,122,138,148,156,164,168,173,181,182,186,189,195,196,203,207,212,213,214,216,218,223,237,240,244,247,252,258,263,273,285,290,313,347,352})},
            {239,new PokemonStructure(239,239,"Elekid","Electric","Nothing",2,9,0,new ushort[]{0,2,5,7,8,9,25,27,34,38,43,68,69,85,86,87,92,94,96,98,99,102,103,104,112,113,129,148,156,164,168,173,182,189,203,207,213,214,216,218,223,237,238,240,249,263,264,280,290,351})},
            {240,new PokemonStructure(240,240,"Magby","Fire","Nothing",2,49,0,new ushort[]{0,2,5,7,9,25,34,38,43,52,53,68,69,92,94,99,102,103,104,108,109,112,123,126,156,164,168,173,182,189,203,207,213,214,216,218,223,231,237,238,241,249,263,264,280,290})},
            {241,new PokemonStructure(241,241,"Miltank","Normal","Nothing",4,47,0,new ushort[]{0,5,7,8,9,23,25,33,34,38,45,57,58,59,63,68,69,70,76,85,86,87,89,92,99,102,104,111,117,118,156,157,164,173,174,179,182,189,196,201,202,203,205,207,208,213,214,215,216,217,218,223,231,237,240,241,244,247,249,263,264,270,280,290,317,351,352})},
            {242,new PokemonStructure(242,242,"Blissey","Normal","Nothing",1,30,32,new ushort[]{0,1,3,5,25,34,38,39,45,47,53,58,59,63,68,69,70,76,85,86,87,89,92,94,99,102,104,107,111,113,118,121,126,135,138,148,156,164,173,182,189,196,201,203,205,207,213,214,216,218,219,223,231,237,240,241,247,249,258,263,264,280,285,287,289,290,317,347,351,352})},
            {243,new PokemonStructure(243,243,"Raikou","Electric","Nothing",4,46,0,new ushort[]{0,15,34,38,43,44,46,63,70,84,85,86,87,91,92,98,99,102,104,115,129,148,156,164,173,182,189,201,203,207,209,214,216,218,231,237,240,241,242,244,249,263,290,347,351})},
            {244,new PokemonStructure(244,244,"Entei","Fire","Nothing",4,46,0,new ushort[]{0,15,23,34,38,43,44,46,52,53,63,70,76,83,91,92,99,102,104,115,126,129,148,156,164,173,182,189,201,203,207,214,216,218,231,237,240,241,244,249,263,290,347})},
            {245,new PokemonStructure(245,245,"Suicune","Water","Nothing",4,46,0,new ushort[]{0,15,16,34,38,43,44,46,54,56,57,58,59,61,62,63,91,92,99,102,104,115,127,129,156,164,173,182,189,196,201,203,207,214,216,218,231,237,240,241,243,244,249,258,263,290,291,347,352})},
            {246,new PokemonStructure(246,246,"Larvitar","Rock","Ground",4,62,0,new ushort[]{0,23,34,37,38,43,44,63,89,91,92,99,102,103,104,116,156,157,164,173,174,182,184,189,200,201,203,207,213,214,216,218,228,237,240,241,242,246,249,259,263,269,280,290,349})},
            {247,new PokemonStructure(247,247,"Pupitar","Rock","Ground",4,61,0,new ushort[]{0,34,37,38,43,44,63,89,91,92,99,102,103,104,156,157,164,173,182,184,189,201,203,207,213,214,216,218,237,240,241,242,249,259,263,269,280,290})},
            {248,new PokemonStructure(248,248,"Tyranitar","Rock","Dark",4,45,0,new ushort[]{0,5,7,15,25,34,37,38,43,44,46,53,57,58,59,63,68,69,70,85,86,87,89,91,92,99,102,103,104,126,156,157,164,173,182,184,189,201,203,207,210,213,214,216,218,223,231,237,240,241,242,249,259,263,264,269,280,290,317,332,337,351,352})},
            {249,new PokemonStructure(249,249,"Lugia","Psychic","Flying",4,46,0,new ushort[]{0,16,18,19,34,38,46,56,57,58,59,63,70,85,86,87,89,92,94,99,102,104,105,113,115,127,129,138,156,164,173,177,182,189,196,201,202,203,207,211,214,216,218,219,231,237,240,241,244,246,247,248,249,258,263,285,290,291,332,347,351,352})},
            {250,new PokemonStructure(250,250,"Ho-Oh","Fire","Flying",4,46,0,new ushort[]{0,16,18,19,38,46,53,63,70,76,85,86,87,89,92,94,99,102,104,105,113,115,126,129,138,148,156,164,173,182,189,201,202,203,207,211,214,216,218,219,221,237,240,241,244,246,247,248,249,263,290,315,332,347,351})},
            {251,new PokemonStructure(251,251,"Celebi","Psychic","Grass",3,30,0,new ushort[]{0,14,15,38,63,73,76,92,93,94,99,102,104,105,111,113,115,118,129,138,148,156,164,173,182,189,195,201,202,203,207,214,215,216,218,219,226,237,240,241,244,246,247,248,263,285,290,332,347,351,352})},
            {277,new PokemonStructure(277,252,"Treecko","Grass","Nothing",3,65,0,new ushort[]{0,1,5,9,14,15,21,25,34,38,43,68,69,70,71,72,73,76,91,92,97,98,99,102,103,104,129,148,156,164,173,182,189,197,202,203,207,210,213,214,216,218,219,223,225,228,231,237,241,242,249,263,264,280,283,290,300,306,317,331,332})},
            {278,new PokemonStructure(278,253,"Grovyle","Grass","Nothing",3,65,0,new ushort[]{0,1,5,9,14,15,21,25,34,38,43,68,69,70,71,76,91,92,97,98,99,102,103,104,129,148,156,164,173,182,189,197,202,203,206,207,210,213,214,216,218,219,223,228,231,237,241,249,263,264,280,290,317,331,332,348})},
            {279,new PokemonStructure(279,254,"Sceptile","Grass","Nothing",3,65,0,new ushort[]{0,1,5,9,14,15,21,25,34,38,43,46,63,68,69,70,71,76,89,91,92,97,98,99,102,103,104,129,148,156,164,173,182,189,197,202,203,206,207,210,213,214,216,218,219,223,228,231,237,241,249,263,264,280,290,317,331,332,337,348})},
            {280,new PokemonStructure(280,255,"Torchic","Fire","Nothing",3,66,0,new ushort[]{0,5,10,14,15,25,28,34,38,45,52,53,64,68,69,70,83,91,92,98,99,102,104,116,119,126,129,156,157,163,164,173,179,182,189,203,207,213,214,216,218,237,241,249,263,265,290,315,317,332})},
            {281,new PokemonStructure(281,256,"Combusken","Fire","Fighting",3,66,0,new ushort[]{0,5,7,9,10,14,15,24,25,28,34,38,45,52,53,64,68,69,70,91,92,98,99,102,104,116,119,126,129,156,157,163,164,173,182,189,203,207,210,213,214,216,218,223,237,241,249,263,264,280,290,315,317,327,332,339})},
            {282,new PokemonStructure(282,257,"Blaziken","Fire","Fighting",3,66,0,new ushort[]{0,5,7,9,10,14,15,24,25,28,34,38,45,46,52,53,63,64,68,69,70,89,91,92,98,99,102,104,116,119,126,129,156,157,163,164,173,182,189,203,207,210,213,214,216,218,223,237,241,249,263,264,280,290,299,315,317,327,332,339})},
            {283,new PokemonStructure(283,258,"Mudkip","Water","Nothing",3,67,0,new ushort[]{0,23,33,34,36,38,45,55,56,57,58,59,70,91,92,99,102,104,111,117,127,156,164,173,174,182,189,193,196,203,205,207,213,214,216,218,231,237,240,243,249,250,253,258,263,283,287,290,291,300,301,317,352})},
            {284,new PokemonStructure(284,259,"Marshtomp","Water","Ground",3,67,0,new ushort[]{0,5,8,25,33,34,36,38,45,55,57,58,59,68,69,70,89,91,92,99,102,104,111,117,127,156,157,164,173,182,189,193,196,203,205,207,213,214,216,218,223,231,237,240,249,258,263,283,290,291,300,317,330,341,352})},
            {285,new PokemonStructure(285,260,"Swampert","Water","Ground",3,67,0,new ushort[]{0,5,8,25,33,34,36,38,45,46,55,57,58,59,63,68,69,70,89,91,92,99,102,104,111,117,127,156,157,164,173,182,189,193,196,203,205,207,213,214,216,218,223,231,237,240,249,258,263,264,280,283,290,291,300,317,330,341,352})},
            {286,new PokemonStructure(286,261,"Poochyena","Dark","Nothing",2,50,0,new ushort[]{0,28,33,34,36,38,43,44,46,68,91,92,99,102,104,156,164,168,173,182,184,189,203,207,213,214,216,218,231,237,240,241,242,244,247,249,259,263,269,281,289,290,305,310,316,336,343})},
            {287,new PokemonStructure(287,262,"Mightyena","Dark","Nothing",2,22,0,new ushort[]{0,28,33,34,36,38,44,46,63,68,70,91,92,99,102,104,156,164,168,173,182,184,189,203,207,213,214,216,218,231,237,240,241,242,244,247,249,259,263,269,289,290,316,336})},
            {288,new PokemonStructure(288,263,"Zigzagoon","Normal","Nothing",2,53,0,new ushort[]{0,15,28,29,33,34,38,39,42,45,57,58,59,85,86,87,91,92,99,102,104,111,129,156,164,168,173,175,182,187,189,196,203,204,205,207,210,213,214,216,218,228,231,237,240,241,247,249,263,271,290,300,316,321,343,351,352})},
            {289,new PokemonStructure(289,264,"Linoone","Normal","Nothing",2,53,0,new ushort[]{0,15,28,29,33,34,38,39,45,46,57,58,59,63,70,85,86,87,91,92,99,102,104,111,129,154,156,163,164,168,173,182,187,189,196,203,205,207,210,213,214,216,218,231,237,240,241,247,249,263,290,300,316,343,351,352})},
            {290,new PokemonStructure(290,265,"Wurmple","Bug","Nothing",2,19,0,new ushort[]{0,33,40,81})},
            {291,new PokemonStructure(291,266,"Silcoon","Bug","Nothing",2,61,0,new ushort[]{0,106})},
            {292,new PokemonStructure(292,267,"Beautifly","Bug","Flying",2,68,0,new ushort[]{0,16,18,38,63,71,72,76,78,92,94,99,102,104,129,148,156,164,168,173,182,202,203,207,213,214,216,218,219,234,237,241,247,263,290,318,332})},
            {293,new PokemonStructure(293,268,"Cascoon","Bug","Nothing",2,61,0,new ushort[]{0,106})},
            {294,new PokemonStructure(294,269,"Dustox","Bug","Poison",2,19,0,new ushort[]{0,16,18,38,60,63,76,92,93,94,99,102,104,113,129,148,156,164,168,173,182,188,202,203,207,213,214,216,218,236,237,241,247,263,290,318,332})},
            {295,new PokemonStructure(295,270,"Lotad","Water","Grass",3,33,44,new ushort[]{0,14,34,38,45,54,55,57,58,59,71,72,73,75,76,92,99,102,104,148,156,164,168,173,175,182,196,202,203,207,213,214,216,218,230,235,237,240,241,258,263,267,290,310,331,352})},
            {296,new PokemonStructure(296,271,"Lombre","Water","Grass",3,33,44,new ushort[]{0,7,8,9,14,34,38,45,56,57,58,59,70,71,76,92,99,102,104,127,148,154,156,164,168,173,182,189,196,202,203,207,213,214,216,218,223,237,240,241,249,252,253,258,263,267,280,290,291,310,331,346,352})},
            {297,new PokemonStructure(297,272,"Ludicolo","Water","Grass",3,33,44,new ushort[]{0,5,7,8,9,14,25,34,38,45,57,58,59,63,68,69,70,71,76,92,99,102,104,118,127,148,156,164,168,173,182,189,196,202,203,207,213,214,216,218,223,237,240,241,249,258,263,264,267,280,290,291,310,331,352})},
            {298,new PokemonStructure(298,273,"Seedot","Grass","Nothing",3,34,48,new ushort[]{0,13,14,34,36,38,73,74,76,91,92,98,99,102,104,106,111,117,133,148,153,156,164,173,182,202,203,205,206,207,213,214,216,218,235,237,241,247,249,263,267,290,331})},
            {299,new PokemonStructure(299,274,"Nuzleaf","Grass","Dark",3,34,48,new ushort[]{0,1,13,14,15,25,34,38,63,70,74,76,91,92,99,102,104,106,111,129,148,153,156,164,168,173,182,185,189,202,203,205,207,210,213,214,216,218,237,241,244,247,249,252,259,263,267,280,290,317,326,331})},
            {300,new PokemonStructure(300,275,"Shiftry","Grass","Dark",3,34,48,new ushort[]{0,1,14,15,25,34,38,63,70,74,76,91,92,99,102,104,106,111,129,148,153,156,164,168,173,182,189,202,203,205,207,210,213,214,216,218,237,241,244,247,249,259,263,267,280,290,317,331,332})},
            {304,new PokemonStructure(304,276,"Taillow","Normal","Flying",3,62,0,new ushort[]{0,17,19,38,45,48,64,92,97,98,99,102,104,116,119,129,143,156,164,168,173,182,189,203,207,211,213,214,216,218,228,237,240,241,263,283,287,290,332})},
            {305,new PokemonStructure(305,277,"Swellow","Normal","Flying",3,62,0,new ushort[]{0,17,19,38,45,63,64,68,92,97,98,99,102,104,116,129,156,164,168,173,182,189,203,207,211,213,214,216,218,237,240,241,263,283,290,332})},
            {309,new PokemonStructure(309,278,"Wingull","Water","Flying",2,51,0,new ushort[]{0,16,17,19,38,45,48,54,55,58,59,92,97,98,99,102,104,129,156,164,168,173,182,189,196,203,207,211,213,214,216,218,228,237,239,240,258,263,290,332,346,351,352})},
            {310,new PokemonStructure(310,279,"Pelipper","Water","Flying",2,51,0,new ushort[]{0,17,19,38,45,48,54,55,56,57,58,59,63,92,99,102,104,129,156,164,168,173,182,189,196,203,207,211,213,214,216,218,237,240,254,255,256,258,263,290,332,346,351,352})},
            {392,new PokemonStructure(392,280,"Ralts","Psychic","Nothing",4,28,36,new ushort[]{0,7,8,9,34,38,45,50,85,86,92,93,94,95,99,100,102,104,111,113,115,138,148,156,164,168,173,182,189,194,196,203,207,212,213,214,216,218,219,237,240,241,244,247,248,259,261,262,263,269,285,286,289,290,347,351})},
            {393,new PokemonStructure(393,281,"Kirlia","Psychic","Nothing",4,28,36,new ushort[]{0,7,8,9,34,38,45,85,86,92,93,94,95,99,100,102,104,111,113,115,138,148,156,164,168,173,182,189,196,203,207,213,214,216,218,219,237,240,241,244,247,248,259,263,269,285,286,289,290,345,347,351})},
            {394,new PokemonStructure(394,282,"Gardevoir","Psychic","Nothing",4,28,36,new ushort[]{0,7,8,9,34,38,45,63,85,86,92,93,94,95,99,100,102,104,111,113,115,138,148,156,164,168,173,182,189,196,203,207,213,214,216,218,219,237,240,241,244,247,248,259,263,269,285,286,289,290,347,351})},
            {311,new PokemonStructure(311,283,"Surskit","Bug","Water",2,33,0,new ushort[]{0,38,54,56,58,59,60,61,76,92,97,98,99,102,104,114,129,145,148,156,164,168,170,173,182,193,196,202,203,207,213,214,216,218,230,237,240,241,244,247,263,290,341,346,352})},
            {312,new PokemonStructure(312,284,"Masquerain","Bug","Flying",2,22,0,new ushort[]{0,16,18,38,58,59,63,76,78,92,98,99,102,104,129,145,148,156,164,168,173,182,184,196,202,203,207,213,214,216,218,230,237,240,241,244,247,263,290,318,332,346,352})},
            {306,new PokemonStructure(306,285,"Shroomish","Grass","Nothing",5,27,0,new ushort[]{0,14,29,33,34,38,71,72,73,74,76,77,78,92,99,102,104,147,148,156,164,173,182,188,202,203,204,206,207,213,214,216,218,219,237,241,263,270,289,290,313,331})},
            {307,new PokemonStructure(307,286,"Breloom","Grass","Fighting",5,27,0,new ushort[]{0,5,9,14,15,25,29,33,34,38,63,68,69,70,71,72,73,76,78,92,99,102,104,148,156,164,170,173,182,183,188,189,202,203,207,210,213,214,216,218,219,223,231,237,241,249,263,264,280,289,290,327,331,339})},
            {364,new PokemonStructure(364,287,"Slakoth","Normal","Nothing",4,54,0,new ushort[]{0,5,7,8,9,10,15,25,34,38,53,58,59,68,69,70,76,85,87,92,99,102,104,126,133,156,157,163,164,173,174,175,182,185,189,196,203,207,210,213,214,216,218,223,227,228,237,240,241,247,249,263,264,280,281,290,303,306,332,339,343,351,352})},
            {365,new PokemonStructure(365,288,"Vigoroth","Normal","Nothing",4,72,0,new ushort[]{0,5,7,8,9,10,15,25,34,38,46,53,58,59,68,69,70,76,85,87,89,92,99,102,104,116,126,154,156,157,163,164,173,179,182,189,196,203,207,210,213,214,216,218,223,227,237,240,241,247,249,253,263,264,269,280,290,332,339,351,352})},
            {366,new PokemonStructure(366,289,"Slaking","Normal","Nothing",4,54,0,new ushort[]{0,5,7,8,9,10,15,25,34,38,46,53,58,59,63,68,69,70,76,85,87,89,92,99,102,104,126,133,156,157,164,173,175,182,185,189,196,203,207,210,213,214,216,218,223,227,237,240,241,247,249,263,264,269,280,281,290,303,332,339,343,351,352})},
            {301,new PokemonStructure(301,290,"Nincada","Bug","Ground",0,14,0,new ushort[]{0,10,15,16,28,38,76,91,92,99,102,104,106,141,148,154,156,164,170,173,182,185,189,201,202,203,206,207,210,214,216,218,232,237,241,247,263,290,318,332})},
            {302,new PokemonStructure(302,291,"Ninjask","Bug","Flying",0,3,0,new ushort[]{0,10,14,15,28,38,63,76,91,92,97,99,102,103,104,106,129,141,148,154,156,163,164,168,170,173,182,189,201,202,203,207,210,213,214,216,218,226,237,241,247,263,290,332})},
            {303,new PokemonStructure(303,292,"Shedinja","Bug","Ghost",0,25,0,new ushort[]{0,10,15,28,38,63,76,91,92,99,102,104,106,109,138,141,148,154,156,164,168,170,173,180,182,189,201,202,203,207,210,214,216,218,237,241,247,263,288,290,332})},
            {370,new PokemonStructure(370,293,"Whismur","Normal","Nothing",3,43,0,new ushort[]{0,1,5,7,8,9,23,25,34,36,38,46,48,53,58,59,68,69,76,92,99,102,103,104,111,126,156,164,173,182,189,196,203,205,207,213,214,216,218,223,237,240,241,244,247,253,263,265,290,304,310,326,336,351,352})},
            {371,new PokemonStructure(371,294,"Loudred","Normal","Nothing",3,43,0,new ushort[]{0,1,5,7,8,9,23,25,34,38,46,48,53,58,59,68,69,70,76,89,92,99,102,103,104,111,126,156,157,164,173,182,189,196,203,205,207,213,214,216,218,223,237,240,241,244,247,249,253,259,263,269,280,290,304,310,315,336,351,352})},
            {372,new PokemonStructure(372,295,"Exploud","Normal","Nothing",3,43,0,new ushort[]{0,1,5,7,8,9,23,25,34,38,46,48,53,58,59,63,68,69,70,76,89,92,99,102,103,104,111,126,156,157,164,173,182,189,196,203,205,207,213,214,216,218,223,237,240,241,244,247,249,253,259,263,269,280,290,304,310,315,336,351,352})},
            {335,new PokemonStructure(335,296,"Makuhita","Fighting","Nothing",5,47,62,new ushort[]{0,5,7,8,9,18,25,28,33,34,38,57,68,69,70,89,91,92,99,102,104,116,118,156,157,164,173,179,182,185,187,189,193,197,203,207,213,214,216,218,223,233,237,238,240,241,249,252,263,264,265,270,279,280,282,290,292,317,339})},
            {336,new PokemonStructure(336,297,"Hariyama","Fighting","Nothing",5,47,62,new ushort[]{0,5,7,8,9,18,25,28,33,34,38,57,63,68,69,70,89,91,92,99,102,104,116,118,156,157,164,173,179,182,187,189,203,207,213,214,216,218,223,233,237,240,241,249,252,263,264,265,280,282,290,292,317,339})},
            {350,new PokemonStructure(350,298,"Azurill","Normal","Nothing",1,47,37,new ushort[]{0,21,34,38,39,47,55,57,58,59,92,99,102,104,111,127,129,145,150,156,164,173,182,189,196,203,204,205,207,213,214,216,218,227,231,237,240,258,263,287,290,321,352})},
            {320,new PokemonStructure(320,299,"Nosepass","Rock","Nothing",2,5,42,new ushort[]{0,7,8,9,33,34,38,70,85,86,87,88,89,92,99,102,104,106,111,153,156,157,164,173,182,189,192,199,201,203,205,207,213,214,216,218,222,223,237,241,249,259,263,269,290,317,335,351})},
            {315,new PokemonStructure(315,300,"Skitty","Normal","Nothing",1,56,0,new ushort[]{0,3,33,34,38,39,45,47,58,59,76,85,86,87,91,92,99,102,104,111,129,138,148,156,164,173,182,185,189,196,203,204,205,207,213,214,215,216,218,219,226,231,237,240,241,244,247,253,263,270,273,274,290,313,321,343,347,351,352})},
            {316,new PokemonStructure(316,301,"Delcatty","Normal","Nothing",1,56,0,new ushort[]{0,3,34,38,45,47,58,59,63,70,76,85,86,87,91,92,99,102,104,111,129,138,148,156,164,173,182,189,196,203,205,207,213,214,216,218,219,231,237,240,241,244,247,249,263,290,347,351,352})},
            {322,new PokemonStructure(322,302,"Sableye","Dark","Ghost",3,51,0,new ushort[]{0,5,7,8,9,10,15,25,34,38,43,68,69,91,92,94,99,101,102,104,105,109,118,138,148,154,156,164,168,173,182,185,189,193,197,203,207,210,212,213,214,216,218,223,236,237,240,241,244,247,249,252,259,263,264,269,280,282,289,290,310,317,332,347,351,352})},
            {355,new PokemonStructure(355,303,"Mawile","Steel","Nothing",1,52,22,new ushort[]{0,5,8,9,11,14,25,34,38,44,53,58,63,68,69,70,76,92,99,102,104,126,156,157,164,173,182,185,188,189,196,201,203,206,207,213,214,216,218,223,226,230,237,240,241,242,244,246,249,254,255,256,259,263,264,269,280,290,305,310,313,317,321,334})},
            {382,new PokemonStructure(382,304,"Aron","Steel","Rock",4,5,69,new ushort[]{0,15,23,29,33,34,36,38,46,70,89,91,92,99,102,104,106,111,156,157,164,173,182,189,201,203,205,207,210,213,214,216,218,231,232,237,240,241,249,263,265,283,290,317,319,332,334,351,352})},
            {383,new PokemonStructure(383,305,"Lairon","Steel","Rock",4,5,69,new ushort[]{0,15,29,33,34,36,38,46,70,89,91,92,99,102,104,106,111,156,157,164,173,182,189,201,203,205,207,210,213,214,216,218,231,232,237,240,241,249,263,290,317,319,332,334,351,352})},
            {384,new PokemonStructure(384,306,"Aggron","Steel","Rock",4,5,69,new ushort[]{0,5,7,8,9,15,25,29,33,34,36,38,46,53,57,58,59,63,68,70,76,85,86,87,89,91,92,99,102,104,106,111,126,156,157,164,173,182,189,196,201,203,205,207,210,213,214,216,218,223,231,232,237,240,241,249,263,264,269,280,290,317,319,332,334,337,351,352})},
            {356,new PokemonStructure(356,307,"Meditite","Fighting","Psychic",2,74,0,new ushort[]{0,5,7,8,9,25,34,38,68,69,70,92,93,94,96,99,102,104,105,113,115,117,118,129,136,138,148,156,164,170,173,179,182,189,193,197,203,207,213,214,216,218,223,226,237,240,241,244,247,249,252,263,264,280,290,317,339,347})},
            {357,new PokemonStructure(357,308,"Medicham","Fighting","Psychic",2,74,0,new ushort[]{0,5,7,8,9,25,34,38,63,68,69,70,92,93,94,96,99,102,104,105,113,115,117,118,129,136,138,148,156,157,164,170,173,179,182,189,197,203,207,213,214,216,218,223,237,240,241,244,247,249,263,264,280,290,317,339,347})},
            {337,new PokemonStructure(337,309,"Electrike","Electric","Nothing",4,9,31,new ushort[]{0,29,33,34,38,43,44,46,70,85,86,87,92,98,99,102,104,129,148,156,164,168,173,174,182,189,203,207,209,213,214,216,218,231,237,240,242,253,263,268,290,316,336,351})},
            {338,new PokemonStructure(338,310,"Manectric","Electric","Nothing",4,9,31,new ushort[]{0,33,34,38,43,44,46,63,70,85,86,87,92,98,99,102,104,129,148,156,164,168,173,182,189,203,207,209,213,214,216,218,231,237,240,263,268,290,316,336,351})},
            {353,new PokemonStructure(353,311,"Plusle","Electric","Nothing",2,57,0,new ushort[]{0,5,9,25,34,38,45,68,69,85,86,87,92,97,98,99,102,104,111,113,118,129,148,156,164,173,182,189,203,205,207,209,213,214,216,218,223,226,227,231,237,240,263,268,270,273,290,313,351})},
            {354,new PokemonStructure(354,312,"Minun","Electric","Nothing",2,58,0,new ushort[]{0,5,9,25,34,38,45,68,69,85,86,87,92,97,98,99,102,104,111,113,118,129,148,156,164,173,182,189,203,204,205,207,209,213,214,216,218,223,226,227,231,237,240,263,268,270,273,290,351})},
            {386,new PokemonStructure(386,313,"Volbeat","Bug","Nothing",0,35,68,new ushort[]{0,5,8,9,25,33,34,38,68,69,76,85,86,87,92,98,99,102,104,109,113,118,129,148,156,164,168,173,182,189,202,203,207,213,214,216,218,223,226,236,237,240,241,244,247,263,264,270,271,280,290,294,318,324,332,351,352})},
            {387,new PokemonStructure(387,314,"Illumise","Bug","Nothing",5,12,0,new ushort[]{0,5,8,9,25,33,34,38,68,69,74,76,85,86,87,92,98,99,102,104,113,118,129,148,156,164,168,173,182,189,202,203,204,207,213,214,216,218,223,226,227,230,236,237,240,241,244,247,260,263,264,270,273,280,290,318,332,343,351,352})},
            {363,new PokemonStructure(363,315,"Roselia","Grass","Poison",3,30,38,new ushort[]{0,14,15,34,38,40,42,71,72,73,74,76,78,80,92,99,102,104,129,148,156,164,173,178,182,188,189,191,202,203,207,210,213,214,216,218,230,235,237,241,244,247,263,275,290,312,320,331,345})},
            {367,new PokemonStructure(367,316,"Gulpin","Poison","Nothing",5,64,60,new ushort[]{0,1,7,8,9,34,38,58,68,70,76,92,99,102,104,111,123,124,133,138,139,151,153,156,164,173,182,188,189,202,203,205,207,213,214,216,218,220,223,227,237,240,241,247,249,254,255,256,263,281,289,290,331,351,352})},
            {368,new PokemonStructure(368,317,"Swalot","Poison","Nothing",5,64,60,new ushort[]{0,1,7,8,9,34,38,58,63,68,70,76,92,99,102,104,111,124,133,138,139,153,156,164,173,182,188,189,202,203,205,207,213,214,216,218,223,227,237,240,241,247,249,254,255,256,263,281,289,290,331,351,352})},
            {330,new PokemonStructure(330,318,"Carvanha","Water","Dark",4,24,0,new ushort[]{0,36,37,38,43,44,56,57,58,59,92,97,99,102,103,104,116,127,129,156,164,168,173,182,184,189,196,203,207,210,213,214,216,218,237,240,242,258,259,263,269,290,291,352})},
            {331,new PokemonStructure(331,319,"Sharpedo","Water","Dark",4,24,0,new ushort[]{0,38,43,44,46,57,58,59,63,70,89,92,97,99,102,103,104,116,127,129,130,156,163,164,168,173,182,184,189,196,203,207,210,213,214,216,218,237,240,242,249,258,259,263,269,290,291,317,352})},
            {313,new PokemonStructure(313,320,"Wailmer","Water","Nothing",5,41,12,new ushort[]{0,34,37,38,45,46,54,55,56,57,58,59,70,89,90,92,99,102,104,111,127,133,150,156,164,173,174,182,196,203,205,207,213,214,216,218,237,240,249,250,258,263,290,291,310,317,321,323,352})},
            {314,new PokemonStructure(314,321,"Wailord","Water","Nothing",5,41,12,new ushort[]{0,34,38,45,46,54,55,56,57,58,59,63,70,89,92,99,102,104,111,127,133,150,156,164,173,182,196,203,205,207,213,214,216,218,237,240,249,250,258,263,290,291,310,317,323,352})},
            {339,new PokemonStructure(339,322,"Numel","Fire","Ground",2,12,0,new ushort[]{0,23,33,34,36,38,52,53,70,89,91,92,99,102,104,111,116,126,133,156,157,164,173,182,184,189,201,203,205,207,213,214,216,218,222,237,241,249,263,290,315,317,336})},
            {340,new PokemonStructure(340,323,"Camerupt","Fire","Ground",2,40,0,new ushort[]{0,33,34,36,38,45,46,52,53,63,70,89,90,91,92,99,102,104,111,116,126,133,153,156,157,164,173,182,189,201,203,205,207,213,214,216,218,222,237,241,249,263,284,290,315,317})},
            {321,new PokemonStructure(321,324,"Torkoal","Fire","Nothing",2,73,0,new ushort[]{0,34,38,52,53,70,83,92,99,102,104,108,123,126,133,153,156,157,164,173,174,175,182,188,189,203,207,213,214,216,218,231,237,241,249,257,263,281,284,290,315,334})},
            {351,new PokemonStructure(351,325,"Spoink","Psychic","Nothing",1,47,20,new ushort[]{0,34,38,60,92,94,99,102,104,109,113,115,129,138,148,149,150,156,164,168,173,182,196,203,207,213,214,216,218,231,237,240,241,243,244,247,248,259,263,269,271,277,285,289,290,316,326,340,347,351})},
            {352,new PokemonStructure(352,326,"Grumpig","Psychic","Nothing",1,47,20,new ushort[]{0,5,7,8,9,25,34,38,60,63,68,69,92,94,99,102,104,109,113,115,129,138,148,149,150,156,164,168,173,182,189,196,203,207,213,214,216,218,223,231,237,240,241,244,247,259,263,264,269,277,285,289,290,316,340,347,351})},
            {308,new PokemonStructure(308,327,"Spinda","Normal","Nothing",1,20,0,new ushort[]{0,5,7,8,9,25,33,34,37,38,50,60,68,69,70,91,92,94,95,99,102,104,111,118,129,138,146,148,156,157,164,168,173,175,182,185,189,196,203,205,207,213,214,216,218,219,223,226,227,237,240,241,244,247,249,253,263,264,265,271,273,274,280,285,289,290,298,317,347,351,352})},
            {332,new PokemonStructure(332,328,"Trapinch","Ground","Nothing",3,52,71,new ushort[]{0,16,28,34,38,44,63,70,76,89,91,92,98,99,102,104,116,156,157,164,173,182,185,189,201,202,203,207,213,214,216,218,237,241,242,249,263,290,317,328})},
            {333,new PokemonStructure(333,329,"Vibrava","Ground","Dragon",3,26,0,new ushort[]{0,19,28,34,38,44,63,70,76,89,91,92,99,102,103,104,129,156,157,164,173,182,185,189,201,202,203,207,211,213,214,216,218,225,237,241,242,249,263,290,317,328})},
            {334,new PokemonStructure(334,330,"Flygon","Ground","Dragon",3,26,0,new ushort[]{0,7,19,28,34,38,44,53,63,70,76,89,91,92,99,102,103,104,126,129,156,157,164,173,182,185,189,201,202,203,207,210,211,213,214,216,218,225,231,237,241,242,249,263,290,317,328,337})},
            {344,new PokemonStructure(344,331,"Cacnea","Grass","Nothing",3,8,0,new ushort[]{0,5,9,14,15,28,34,38,40,42,43,51,68,69,71,73,74,76,92,99,102,104,148,156,164,173,178,182,185,189,191,194,201,202,203,207,210,213,214,216,218,223,237,241,263,264,275,290,298,302,320,331})},
            {345,new PokemonStructure(345,332,"Cacturne","Grass","Dark",3,8,0,new ushort[]{0,5,9,14,15,25,28,34,38,40,42,43,63,68,69,70,71,73,74,76,92,99,102,104,148,156,164,173,178,182,185,189,191,194,201,202,203,207,210,213,214,216,218,223,237,241,263,264,275,279,290,302,331})},
            {358,new PokemonStructure(358,333,"Swablu","Normal","Flying",0,30,0,new ushort[]{0,19,31,34,36,38,45,47,54,58,64,76,92,97,99,102,104,114,119,129,138,156,164,168,173,182,189,195,203,207,211,213,214,216,218,219,228,237,240,241,244,263,287,290,310,332})},
            {359,new PokemonStructure(359,334,"Altaria","Dragon","Flying",0,30,0,new ushort[]{0,19,31,34,36,38,45,46,47,53,54,58,63,64,76,89,92,99,102,104,126,129,138,143,156,164,168,173,182,189,195,203,207,211,213,214,216,218,219,225,231,237,240,241,244,249,263,287,290,310,332,337,349})},
            {380,new PokemonStructure(380,335,"Zangoose","Normal","Nothing",0,17,0,new ushort[]{0,5,7,8,9,10,13,14,24,25,34,38,43,46,53,58,59,68,69,70,76,85,86,87,91,92,98,99,102,104,111,126,129,156,157,163,164,168,173,174,182,189,196,197,202,203,205,206,207,210,213,214,216,218,223,228,231,232,237,240,241,247,249,263,264,269,280,290,306,332,351,352})},
            {379,new PokemonStructure(379,336,"Seviper","Poison","Nothing",5,61,0,new ushort[]{0,34,35,38,44,53,70,89,91,92,99,102,103,104,114,122,129,137,156,164,168,173,182,188,189,202,203,207,210,213,214,216,218,231,237,240,241,242,249,254,255,256,263,269,289,290,305,342})},
            {348,new PokemonStructure(348,337,"Lunatone","Rock","Psychic",1,26,0,new ushort[]{0,33,34,38,58,63,88,89,92,93,94,95,99,102,104,106,111,113,115,129,138,148,149,153,156,157,164,173,182,201,203,205,207,213,214,216,218,219,237,240,244,247,248,263,285,290,317,322,347})},
            {349,new PokemonStructure(349,338,"Solrock","Rock","Psychic",1,26,0,new ushort[]{0,33,34,38,53,63,76,83,88,89,92,93,94,99,102,104,106,111,113,115,126,129,138,148,149,153,156,157,164,173,182,201,203,205,207,214,216,218,219,237,241,244,247,263,285,290,315,317,322,347})},
            {323,new PokemonStructure(323,339,"Barboach","Water","Ground",2,12,0,new ushort[]{0,37,38,55,57,58,59,89,90,92,99,102,104,127,133,156,164,173,182,189,196,201,203,207,209,213,214,216,218,222,237,240,248,250,258,263,290,291,300,317,346,352})},
            {324,new PokemonStructure(324,340,"Whiscash","Water","Ground",2,12,0,new ushort[]{0,38,55,57,58,59,63,70,89,90,92,99,102,104,127,133,156,157,164,173,182,189,196,201,203,207,213,214,216,218,222,237,240,248,249,258,263,290,291,300,317,321,346,352})},
            {326,new PokemonStructure(326,341,"Corphish","Water","Nothing",5,52,75,new ushort[]{0,11,12,14,15,34,38,43,57,58,59,61,68,70,91,92,99,102,104,106,127,145,152,156,164,173,182,188,189,196,203,207,210,213,214,216,218,237,240,242,246,249,258,263,269,280,282,283,290,300,317,332,352})},
            {327,new PokemonStructure(327,342,"Crawdaunt","Water","Dark",5,52,75,new ushort[]{0,11,12,14,15,34,38,43,57,58,59,61,63,68,70,91,92,99,102,104,106,127,129,145,152,156,164,173,182,188,189,196,203,207,210,213,214,216,218,237,240,242,249,258,263,269,280,282,290,291,317,332,352})},
            {318,new PokemonStructure(318,343,"Baltoy","Ground","Psychic",2,26,0,new ushort[]{0,38,58,60,76,89,91,92,93,94,99,102,104,106,113,115,120,138,148,153,156,157,164,173,182,189,201,203,207,214,216,218,229,237,240,241,244,246,247,263,285,290,317,322})},
            {319,new PokemonStructure(319,344,"Claydol","Ground","Psychic",2,26,0,new ushort[]{0,38,58,60,63,70,76,89,91,92,93,94,99,100,102,104,106,113,115,120,138,148,153,156,157,164,173,182,189,201,203,207,214,216,218,229,237,240,241,244,246,247,249,263,285,290,317,322})},
            {388,new PokemonStructure(388,345,"Lileep","Rock","Grass",0,21,0,new ushort[]{0,34,38,51,76,92,99,102,104,105,109,112,132,133,156,157,164,173,182,188,189,201,202,203,207,213,214,216,218,237,241,243,244,246,254,255,256,263,275,290,310,331})},
            {389,new PokemonStructure(389,346,"Cradily","Rock","Grass",0,21,0,new ushort[]{0,34,38,51,63,70,76,89,92,99,102,104,109,132,133,156,157,164,173,182,188,189,201,202,203,207,213,214,216,218,237,241,244,246,249,254,255,256,263,275,290,310,317,331})},
            {390,new PokemonStructure(390,347,"Anorith","Rock","Bug",0,4,0,new ushort[]{0,10,14,15,34,38,55,91,92,99,102,104,106,156,157,163,164,173,182,189,201,203,207,210,213,214,216,218,229,232,237,241,246,249,263,280,282,290,300,317,332,350,352})},
            {391,new PokemonStructure(391,348,"Armaldo","Rock","Bug",0,4,0,new ushort[]{0,10,14,15,34,38,55,63,69,70,89,91,92,99,102,104,106,156,157,163,164,173,182,189,201,203,207,210,213,214,216,218,231,232,237,241,246,249,263,280,290,300,317,332,350,352})},
            {328,new PokemonStructure(328,349,"Feebas","Water","Nothing",0,33,0,new ushort[]{0,33,38,57,58,59,92,95,99,102,104,109,113,127,129,150,156,164,173,175,182,196,203,207,213,214,216,218,225,237,240,243,258,263,290,291,300,352})},
            {329,new PokemonStructure(329,350,"Milotic","Water","Nothing",0,63,0,new ushort[]{0,34,35,38,55,56,57,58,59,63,92,99,102,104,105,127,129,156,164,173,182,189,196,203,207,213,214,216,218,219,231,237,239,240,244,258,263,287,290,291,346,352})},
            {385,new PokemonStructure(385,351,"Castform","Normal","Nothing",2,59,0,new ushort[]{0,33,34,38,52,53,55,58,59,76,85,86,87,92,99,102,104,111,126,129,148,156,164,168,173,181,182,196,201,203,207,213,214,216,218,237,240,241,244,247,248,258,263,290,311,351,352})},
            {317,new PokemonStructure(317,352,"Kecleon","Normal","Nothing",3,16,0,new ushort[]{0,5,7,8,9,10,15,20,25,34,38,39,50,53,58,59,60,68,69,70,76,85,86,87,91,92,99,102,103,104,111,118,122,126,129,148,154,156,157,163,164,168,173,182,185,189,196,203,205,207,210,213,214,216,218,223,231,237,240,241,244,246,247,249,263,264,271,277,280,285,289,290,310,317,332,351,352})},
            {377,new PokemonStructure(377,353,"Shuppet","Ghost","Nothing",1,15,0,new ushort[]{0,34,38,50,85,86,87,92,94,99,101,102,103,104,138,148,156,164,168,173,174,180,182,185,193,194,196,203,207,213,214,216,218,237,240,241,244,247,259,261,263,269,282,285,286,288,289,290,310,347,351})},
            {378,new PokemonStructure(378,354,"Banette","Ghost","Nothing",1,15,0,new ushort[]{0,34,38,63,85,86,87,92,94,99,101,102,103,104,118,138,148,156,164,168,173,174,180,182,185,189,196,203,207,213,214,216,218,237,240,241,244,247,259,261,263,269,282,285,288,289,290,347,351})},
            {361,new PokemonStructure(361,355,"Duskull","Ghost","Nothing",1,26,0,new ushort[]{0,34,38,43,50,58,59,92,94,99,101,102,104,109,138,148,156,164,168,173,174,182,185,193,194,196,203,207,212,213,214,216,218,220,228,237,240,241,244,247,248,259,261,262,263,269,285,286,288,289,290,310,347})},
            {362,new PokemonStructure(362,356,"Dusclops","Ghost","Nothing",1,46,0,new ushort[]{0,5,7,8,9,20,25,34,38,43,50,58,59,63,68,69,70,89,92,94,99,101,102,104,109,118,138,148,156,157,164,168,173,174,182,189,193,196,203,207,212,213,214,216,218,223,228,237,240,241,244,247,248,249,259,261,263,264,269,285,289,290,310,317,325,347})},
            {369,new PokemonStructure(369,357,"Tropius","Grass","Flying",4,34,0,new ushort[]{0,13,14,15,16,18,19,21,23,29,34,38,43,46,63,70,73,74,75,76,89,92,99,102,104,148,156,164,173,182,189,202,203,207,210,211,213,214,216,218,230,235,237,241,249,263,267,290,331,332,345})},
            {411,new PokemonStructure(411,358,"Chimecho","Psychic","Nothing",1,26,0,new ushort[]{0,35,36,38,45,50,92,93,94,95,99,102,104,111,113,115,138,148,149,156,164,173,174,182,196,203,205,207,213,214,215,216,218,219,237,240,241,244,247,253,259,263,269,281,285,289,290,310,347})},
            {376,new PokemonStructure(376,359,"Absol","Dark","Nothing",3,46,0,new ushort[]{0,10,13,14,15,34,38,43,44,53,58,59,63,68,70,85,86,87,92,98,99,102,104,126,129,138,148,156,157,163,164,168,173,174,182,185,189,195,196,201,203,207,210,213,214,216,218,226,231,237,240,241,244,247,248,249,258,259,263,269,277,289,290,332,347,351,352})},
            {360,new PokemonStructure(360,360,"Wynaut","Psychic","Nothing",2,23,0,new ushort[]{0,68,150,194,204,219,227,243})},
            {346,new PokemonStructure(346,361,"Snorunt","Ice","Nothing",2,39,0,new ushort[]{0,29,34,38,43,44,58,59,92,99,102,104,113,148,156,164,173,181,182,191,196,203,207,213,214,216,218,219,237,240,242,247,258,263,290,335,352})},
            {347,new PokemonStructure(347,362,"Glalie","Ice","Nothing",2,39,0,new ushort[]{0,29,34,38,43,44,58,59,63,89,92,99,102,104,111,113,148,153,156,164,173,181,182,196,203,205,207,213,214,216,218,219,237,240,242,247,258,259,263,269,290,329,352})},
            {341,new PokemonStructure(341,363,"Spheal","Ice","Water",3,47,0,new ushort[]{0,34,38,45,55,57,58,59,62,70,89,90,92,99,102,104,111,127,156,157,164,173,174,181,182,189,196,203,205,207,213,214,216,218,227,231,237,240,249,254,255,256,258,263,281,290,291,301,317,329,346,352})},
            {342,new PokemonStructure(342,364,"Sealeo","Ice","Water",3,47,0,new ushort[]{0,34,38,45,46,55,57,58,59,62,70,89,92,99,102,104,111,127,156,157,164,173,181,182,189,196,203,205,207,213,214,216,218,227,231,237,240,249,258,263,290,291,301,317,329,352})},
            {343,new PokemonStructure(343,365,"Walrein","Ice","Water",3,47,0,new ushort[]{0,34,38,45,46,55,57,58,59,62,63,70,89,92,99,102,104,111,127,156,157,164,173,181,182,189,196,203,205,207,213,214,216,218,227,231,237,240,249,258,263,290,291,301,317,329,352})},
            {373,new PokemonStructure(373,366,"Clamperl","Water","Nothing",0,75,0,new ushort[]{0,34,38,48,55,57,58,59,92,99,102,104,109,112,127,128,156,164,173,182,196,203,207,213,214,216,218,237,240,250,258,263,287,290,291,300,334,352})},
            {374,new PokemonStructure(374,367,"Huntail","Water","Nothing",0,33,0,new ushort[]{0,34,38,44,56,57,58,59,63,92,99,102,103,104,127,129,156,164,173,182,184,189,196,203,207,213,214,216,218,226,237,240,242,250,258,263,289,290,291,317,352})},
            {375,new PokemonStructure(375,368,"Gorebyss","Water","Nothing",0,33,0,new ushort[]{0,34,38,56,57,58,59,63,92,93,94,97,99,102,104,127,129,133,156,164,173,182,189,196,203,207,213,214,216,218,219,226,237,240,247,250,258,263,290,291,352})},
            {381,new PokemonStructure(381,369,"Relicanth","Water","Rock",4,33,69,new ushort[]{0,33,34,36,38,55,56,57,58,59,63,89,92,99,102,104,106,127,130,133,156,157,164,173,182,189,196,201,203,207,213,214,216,218,219,222,237,240,244,246,249,258,263,281,290,291,300,317,346,347,352})},
            {325,new PokemonStructure(325,370,"Luvdisc","Water","Nothing",1,33,0,new ushort[]{0,33,36,38,48,55,57,58,59,92,97,99,102,104,127,129,150,156,164,173,175,182,186,196,203,204,207,213,214,216,218,219,237,240,244,258,263,290,291,300,346,352})},
            {395,new PokemonStructure(395,371,"Bagon","Dragon","Nothing",4,69,0,new ushort[]{0,15,29,34,37,38,43,44,46,52,53,56,70,82,92,99,102,104,116,126,156,157,164,173,182,184,189,203,207,210,213,214,216,218,225,237,239,240,241,242,249,263,280,290,317,332,337,349})},
            {396,new PokemonStructure(396,372,"Shelgon","Dragon","Nothing",4,69,0,new ushort[]{0,15,29,34,38,43,44,46,52,53,70,92,99,102,104,111,116,126,156,157,164,173,182,184,189,203,205,207,210,213,214,216,218,225,237,240,241,242,249,263,280,290,317,332,337})},
            {397,new PokemonStructure(397,373,"Salamence","Dragon","Flying",4,22,0,new ushort[]{0,15,19,29,34,38,43,44,46,52,53,63,70,89,92,99,102,104,111,116,126,129,156,157,164,173,182,184,189,203,205,207,210,211,213,214,216,218,225,231,237,240,241,242,249,263,280,290,317,332,337})},
            {398,new PokemonStructure(398,374,"Beldum","Steel","Psychic",4,29,0,new ushort[]{0,36})},
            {399,new PokemonStructure(399,375,"Metang","Steel","Psychic",4,29,0,new ushort[]{0,8,9,15,34,36,38,63,70,89,92,93,94,97,99,102,104,111,113,115,129,148,153,156,157,164,173,182,184,188,189,196,201,203,205,207,210,213,214,216,218,223,228,232,237,240,241,244,247,249,263,280,290,309,317,332,334})},
            {400,new PokemonStructure(400,376,"Metagross","Steel","Psychic",4,29,0,new ushort[]{0,8,9,15,34,36,38,63,70,89,92,93,94,97,99,102,104,111,113,115,129,148,153,156,157,164,173,182,184,188,189,196,201,203,205,207,210,213,214,216,218,223,228,232,237,240,241,244,247,249,263,280,290,309,317,332,334})},
            {401,new PokemonStructure(401,377,"Regirock","Rock","Nothing",4,29,0,new ushort[]{0,5,7,8,9,25,34,38,63,68,69,70,85,86,87,88,89,91,92,99,102,104,111,153,156,157,164,173,174,182,189,192,199,201,203,205,207,214,216,218,219,223,237,241,244,246,249,263,264,276,280,290,317,334,351})},
            {402,new PokemonStructure(402,378,"Regice","Ice","Nothing",4,29,0,new ushort[]{0,5,8,9,25,34,38,58,59,63,68,69,70,85,86,87,89,92,99,102,104,111,133,153,156,157,164,173,174,182,189,192,196,199,203,205,207,214,216,218,219,223,237,240,244,246,249,258,263,264,276,280,290,351})},
            {403,new PokemonStructure(403,379,"Registeel","Steel","Nothing",4,29,0,new ushort[]{0,5,8,9,25,34,38,63,68,69,70,85,86,87,89,92,99,102,104,111,133,153,156,157,164,173,174,182,189,192,199,201,203,205,207,214,216,218,219,223,232,237,240,241,244,246,249,263,264,276,280,290,317,332,334,351})},
            {407,new PokemonStructure(407,380,"Latias","Dragon","Psychic",4,26,0,new ushort[]{0,15,19,34,38,46,57,58,63,76,85,86,87,89,92,94,99,102,104,105,113,115,127,129,138,148,149,156,164,173,182,189,196,201,203,204,207,210,211,213,214,216,218,219,225,237,240,241,244,247,263,270,273,287,290,291,296,332,337,346,347,351,352})},
            {408,new PokemonStructure(408,381,"Latios","Dragon","Psychic",4,26,0,new ushort[]{0,15,19,34,38,46,57,58,63,76,85,86,87,89,92,94,99,102,104,105,113,115,127,129,138,148,149,156,164,173,182,189,196,201,203,207,210,211,213,214,216,218,219,225,237,240,241,244,247,262,263,270,287,290,291,295,332,337,347,349,351,352})},
            {404,new PokemonStructure(404,382,"Kyogre","Water","Nothing",4,2,0,new ushort[]{0,34,38,46,56,57,58,59,63,70,85,86,87,89,92,99,102,104,111,127,129,156,157,164,173,182,184,189,196,203,207,214,216,218,219,237,240,244,246,249,258,263,280,290,291,317,323,329,347,351,352})},
            {405,new PokemonStructure(405,383,"Groudon","Ground","Nothing",4,70,0,new ushort[]{0,5,7,9,14,15,25,34,38,46,53,63,68,69,70,76,85,86,87,89,90,91,92,99,102,104,111,126,129,156,157,164,173,182,184,189,201,203,205,207,210,214,216,218,219,223,231,237,241,244,246,249,263,280,284,290,315,317,332,337,339,341,351})},
            {406,new PokemonStructure(406,384,"Rayquaza","Dragon","Flying",4,76,0,new ushort[]{0,19,34,38,46,53,57,58,59,63,70,76,85,86,87,89,92,99,102,104,126,127,129,156,157,164,173,182,184,189,196,200,201,203,207,210,214,216,218,231,237,239,240,241,242,244,245,246,249,263,280,290,291,315,332,337,339,349,351,352})},
            {409,new PokemonStructure(409,385,"Jirachi","Steel","Psychic",4,32,0,new ushort[]{0,7,8,9,34,38,63,85,86,87,92,93,94,99,102,104,111,113,115,118,129,138,148,156,164,173,182,189,196,201,203,207,214,216,218,219,223,237,240,241,244,247,248,263,270,273,285,287,290,322,332,347,351,352,353})},
            {410,new PokemonStructure(410,386,"Deoxys","Psychic","Nothing",4,46,0,new ushort[]{0,5,7,8,9,15,25,34,35,38,43,58,63,68,69,70,76,85,86,87,92,94,97,99,100,101,102,104,105,113,115,129,133,138,148,156,157,164,173,182,189,191,192,196,203,207,214,216,218,219,223,228,237,240,241,244,245,247,249,259,263,264,269,276,280,282,285,289,290,317,322,332,334,352,354})},
            {412,new PokemonStructure(413,387,"Pokemon Egg","Nothing","Nothing",2,0,0,new ushort[]{0})},
            {413,new PokemonStructure(413,201,"Unown B","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {414,new PokemonStructure(414,201,"Unown C","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {415,new PokemonStructure(415,201,"Unown D","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {416,new PokemonStructure(416,201,"Unown E","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {417,new PokemonStructure(417,201,"Unown F","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {418,new PokemonStructure(418,201,"Unown G","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {419,new PokemonStructure(419,201,"Unown H","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {420,new PokemonStructure(420,201,"Unown I","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {421,new PokemonStructure(421,201,"Unown J","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {422,new PokemonStructure(422,201,"Unown K","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {423,new PokemonStructure(423,201,"Unown L","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {424,new PokemonStructure(424,201,"Unown M","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {425,new PokemonStructure(425,201,"Unown N","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {426,new PokemonStructure(426,201,"Unown O","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {427,new PokemonStructure(427,201,"Unown P","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {428,new PokemonStructure(428,201,"Unown Q","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {429,new PokemonStructure(429,201,"Unown R","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {430,new PokemonStructure(430,201,"Unown S","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {431,new PokemonStructure(431,201,"Unown T","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {432,new PokemonStructure(432,201,"Unown U","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {433,new PokemonStructure(433,201,"Unown V","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {434,new PokemonStructure(434,201,"Unown W","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {435,new PokemonStructure(435,201,"Unown X","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {436,new PokemonStructure(436,201,"Unown Y","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {437,new PokemonStructure(437,201,"Unown Z","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {438,new PokemonStructure(438,201,"Unown !","Psychic","Nothing",2,26,0,new ushort[]{0,237})},
            {439,new PokemonStructure(439,201,"Unown ?","Psychic","Nothing",2,26,0,new ushort[]{0,237})}
        };

        /// <summary>
        /// Pristupa kolekciji Pokemona
        /// </summary>
        public static Dictionary<ushort, PokemonStructure> PokemonList
        {
            get { return _pokemonList; }
        }
        #endregion
        #endregion

        //private static Dictionary<byte, Experience> _experiences = new Dictionary<byte, Experience>
        //{

        //};

        ///// <summary>
        ///// Pristupa kolekciji Experience
        ///// </summary>
        //public static Dictionary<byte, Experience> Experiences
        //{
        //    get { return _experiences; }
        //}
    }

    #region HELPER CLASSES
    class Natures
    {
        /// <summary>
        /// Id od nature 0-24
        /// </summary>
        public byte ID { get; set; }
        /// <summary>
        /// Ime nature-a
        /// </summary>
        public string NatureName { get; set; }
        /// <summary>
        /// Stat koji je povecan
        /// </summary>
        public string IncreasedStat { get; set; }
        /// <summary>
        /// Stat koji je smanjen
        /// </summary>
        public string DecreasedStat { get; set; }
        /// <summary>
        /// Kakav okus Pokemon voli
        /// </summary>
        public string FavoriteFlavor { get; set; }
        /// <summary>
        /// Kakav okus Pokemon nevoli
        /// </summary>
        public string DislikedFlavor { get; set; }

        public Natures()
        { }

        public Natures(byte id, string natureName, string increasedStat,
        string decreasedStat, string favoriteFlavor, string dislikedFlavor)
        {
            this.ID = id;
            this.NatureName = natureName;
            this.IncreasedStat = increasedStat;
            this.DecreasedStat = decreasedStat;
            this.FavoriteFlavor = favoriteFlavor;
            this.DislikedFlavor = dislikedFlavor;
        }
    }
    class Locations
    {
        /// <summary>
        /// ID lokacije
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Ime lokacije
        /// </summary>
        public string Name { get; set; }

        public Locations() { }

        public Locations(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
    class Experience
    {
        public byte Level { get; set; }
        public uint Erratic { get; set; }
        public uint Fast { get; set; }
        public uint MediumFast { get; set; }
        public uint MediumSlow { get; set; }
        public uint Slow { get; set; }
        public uint Fluctuating  { get; set; }

        public Experience(byte level, uint erratic, uint fast, uint mediumFast,
            uint mediumSlow, uint slow, uint fluctuating)
        {
            this.Level = level;
            this.Erratic = erratic;
            this.Fast = fast;
            this.MediumFast = mediumFast;
            this.MediumSlow = mediumSlow;
            this.Slow = slow;
            this.Fluctuating = fluctuating;
        }
    }
    class Ability 
    {
        public byte ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Ability(byte id, string name, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
        }
    }
    class Move
    {
        /// <summary>
        /// ID
        /// </summary>
        public ushort ID { get; set; }
        /// <summary>
        /// Ime poteza
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Tip poteza
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Kategorija poteza
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Tip poteza na natjecanjima
        /// </summary>
        public string ContestType { get; set; }
        /// <summary>
        /// PP
        /// </summary>
        public byte PP { get; set; }
        /// <summary>
        /// Jacina poteza
        /// </summary>
        public string Power { get; set; }
        /// <summary>
        /// Postotak uspjesnosti
        /// </summary>
        public string Accuracy { get; set; }
        /// <summary>
        /// Opis poteza
        /// </summary>
        public string Description { get; set; }

        public Move() { }

        public Move(ushort id, string name, string type, string category,
            string contestType, byte pp, string power, string accuracy,
            string description)
        {
            this.ID = id;
            this.Name = name;
            this.Type = type;
            this.Category = category;
            this.ContestType = contestType;
            this.PP = pp;
            this.Power = power;
            this.Accuracy = accuracy;
            this.Description = description;
        }
    }
    class PokemonStructure
    {
        /// <summary>
        /// ID
        /// </summary>
        public ushort ID { get; set; }
        /// <summary>
        /// ID od slike
        /// </summary>
        public ushort picID { get; set; }
        /// <summary>
        /// Ime pokemona
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Tip pokemona 1
        /// </summary>
        public string PokemonType1 { get; set; }
        /// <summary>
        /// Tip pokemona 2
        /// </summary>
        public string PokemonType2 { get; set; }
        /// <summary>
        /// XP group Erratic =  0, Fast = 1, MediumFast =  2
        /// MediumSlow = 3, Slow = 4, Fluctuating =  5
        /// </summary>
        public byte XPGroup { get; set; }
        /// <summary>
        /// Pokemon Ability 1
        /// </summary>
        public byte PokemonAbility1 { get; set; }
        /// <summary>
        /// Pokemon Ability 2
        /// </summary>
        public byte PokemonAbility2 { get; set; }
        /// <summary>
        /// Lista poteza koje moze koristit
        /// </summary>
        public ushort[] MoveList { get; set; }

        public PokemonStructure() { }

        public PokemonStructure(ushort id, ushort picId, string name, string pokemonType1,
            string pokemonType2, byte xpGroup, byte pokemonAbility1,
            byte pokemonAbility2, ushort[] moveList)
        {
            this.ID = id;
            this.picID = picId;
            this.Name = name;
            this.PokemonType1 = pokemonType1;
            this.PokemonType2 = pokemonType2;
            this.XPGroup = xpGroup;
            this.PokemonAbility1 = pokemonAbility1;
            this.PokemonAbility2 = pokemonAbility2;
            this.MoveList = moveList;
        }

        /// <summary>
        /// Vraca Ability 1 kao classu
        /// </summary>
        public Ability Ability1
        {
            get
            {
                Ability ab;
                if (PokemonConstants.Abilities.TryGetValue(this.PokemonAbility1, out ab))
                {
                    return ab;
                }
                else
                {
                    //Vraca prazan ability
                    PokemonConstants.Abilities.TryGetValue(0, out ab);
                    return ab;
                }
            }
        }

        /// <summary>
        /// Vraca Ability 1 kao classu
        /// </summary>
        public Ability Ability2
        {
            get
            {
                Ability ab;
                if (PokemonConstants.Abilities.TryGetValue(this.PokemonAbility2, out ab))
                {
                    return ab;
                }
                else
                {
                    //Vraca prazan ability
                    PokemonConstants.Abilities.TryGetValue(0, out ab);
                    return ab;
                }
            }
        }
    }
    #endregion
}
