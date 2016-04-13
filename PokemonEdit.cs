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
using System.Reflection;
using System.IO;

namespace Pokemon_Save_Editor
{
    partial class PokemonEdit : Form
    {
        private string move1Description;
        private string move2Description;
        private string move3Description;
        private string move4Description;
        private bool isReady;
        private bool originalPokemonShininess;
        private Random rnd;
        /// <summary>
        /// Sadrzi promjenjenog pokemona
        /// </summary>
        public Pokemon changedPokemon {get; set;}
        /// <summary>
        /// Originalni pokemon koji je prosljedit (nemodificirani)
        /// </summary>
        public Pokemon originalPokemon { get; set; }
        /// <summary>
        /// Pokedex ID
        /// </summary>
        public int dexID { get; set; }

        public PokemonEdit()
        {
            InitializeComponent();
            rnd = new Random();
            //Moja inicijalizacija
            MyInitialize();
        }

        /// <summary>
        /// Normalan poziv kad je pokemon u slotu
        /// </summary>
        /// <param name="pok"></param>
        public PokemonEdit(Structures.Pokemon pok)
        {
            InitializeComponent();
            //Spremamo nepromjenjenog pokemona
            originalPokemon = pok;
            rnd = new Random();
            //Moja inicijalizacija
            MyInitialize();
            //Popunjavamo kontrole
            PokemonFill(pok);
            //Spremamo pokemona za kasnije
            originalPokemonShininess = pok.PokemonShininess;
            //this.originalPokemon = new Pokemon();
            //this.originalPokemon = pok;
        }

        /// <summary>
        /// Poziva se samo kad je Empty Spot u storageu
        /// </summary>
        /// <param name="pok"></param>
        /// <param name="player"></param>
        public PokemonEdit(Structures.Pokemon pok, Player player)
        {
            InitializeComponent();
            rnd = new Random();
            //Moja inicijalizacija
            MyInitialize();

            //Pravimo Random Pokemona
            #region Random Pokemon
            Pokemon pokTemp = new Pokemon();
            pokTemp = pok;
            PokemonData pokData = new PokemonData();
            //pokData = pokTemp.DecryptPokemonData();

            pokTemp.Personality = (uint)(GetRandomLong(0, 4294967295));
            pokTemp.Language = 0x0202;
            pokTemp.OriginalTrainerID = player.TrainerID;
            pokTemp.OriginalTrainerName = player.Name;
            pokTemp.NicknameString = "BULBASAUR";
            pokTemp.Unknown = 0;
            pokTemp.StorageBoxMark = 0;

            //misc
            pokData.Misc.IV_Ability = (byte)GetRandom(0, 31);
            pokData.Misc.IV_Attack = (byte)GetRandom(0, 31);
            pokData.Misc.IV_Defense = (byte)GetRandom(0, 31);
            pokData.Misc.IV_HP = (byte)GetRandom(0, 31);
            pokData.Misc.IV_SpAttack = (byte)GetRandom(0, 31);
            pokData.Misc.IV_SpDefense = (byte)GetRandom(0, 31);
            pokData.Misc.IV_Speed = (byte)GetRandom(0, 31);
            pokData.Misc.LevelCaught7bit = 5;
            pokData.Misc.LocationCaught = 254;
            pokData.Misc.PokeBallAndPlayerGender = 25;
            pokData.Misc.PokeballType = 4;
            pokData.Misc.TrainerGender = player.Gender;
            pokData.Misc.IV_Ability = 0;
            pokData.Misc.Ribbons = 0;
            pokData.Misc.Pokerus = 0;

            pokData.Growth.Species = 1;
            pokData.Growth.Friendship = 70;
            pokData.Growth.PokemonLevel = 5;
            pokData.Growth.ItemHeld = 0;
            pokData.Growth.Unknown = 0;
            pokData.Growth.PPbonuses = 0;
            //Moves
            pokData.Attacks.Attack1 = 33;
            pokData.Attacks.PP1 = 35;
            pokData.Attacks.Attack2 = 0;
            pokData.Attacks.PP2 = 0;
            pokData.Attacks.Attack3 = 0;
            pokData.Attacks.PP3 = 0;
            pokData.Attacks.Attack4 = 0;
            pokData.Attacks.PP4 = 0;
            //Effort
            pokData.Effort.AttackEv = 0;
            pokData.Effort.Beauty = 0;
            pokData.Effort.Coolness = 0;
            pokData.Effort.Cuteness = 0;
            pokData.Effort.DefenseEv = 0;
            pokData.Effort.Feel = 0;
            pokData.Effort.HPEv = 0;
            pokData.Effort.Smartness = 0;
            pokData.Effort.SpAttackEv = 0; 
            pokData.Effort.SpDefenseEv = 0;
            pokData.Effort.SpeedEv = 0;
            pokData.Effort.Toughness = 0;
            

            pokTemp.EncryptPokemonData(pokData);

            #endregion
            //Spremamo pokemona za kasnije
            originalPokemonShininess = pok.PokemonShininess;
            

            //Popunjavamo kontrole
            PokemonFill(pokTemp);
        }

        private void MyInitialize()
        {
            List<string> tempList = new List<string>();
            //Pokemon
            foreach (var p in PokemonConstants.PokemonList)
            {
                tempList.Add(String.Format("{0:D3}", p.Key) + "  #" + String.Format("{0:D3}", p.Value.picID) + "   " + p.Value.Name);
            }
            uxPokemonSpecies.DataSource = tempList;

            //Nature
            tempList = new List<string>();
            foreach (var n in PokemonConstants.Natures)
            {
                tempList.Add(n.Value.NatureName + "  +" + n.Value.IncreasedStat + " -" + n.Value.DecreasedStat);
            }
            //tempList.Add("Do Nothing");
            uxPokemonNature.DataSource = tempList;

            //Items
            tempList = new List<string>();
            foreach (var i in PokemonConstants.ItemTypes)
            {
                tempList.Add(String.Format("{0:D3}", i.Key) + " " + i.Value.ItemName);
            }
            uxPokemonItem.DataSource = tempList;

            //Location
            tempList = new List<string>();
            foreach (var l in PokemonConstants.Locations)
            {
                tempList.Add(String.Format("{0:D3}", l.Key) + " " +l.Value.Name);
            }
            uxPokemonLocationCaught.DataSource = tempList;

            //Moves1
            tempList = new List<string>();
            foreach (var m in PokemonConstants.Moves)
            {
                tempList.Add(String.Format("{0:D3}", m.Key) + " " + m.Value.Name);
            }
            uxMove1.DataSource = tempList;
            //Moves2
            tempList = new List<string>();
            foreach (var m2 in PokemonConstants.Moves)
            {
                tempList.Add(String.Format("{0:D3}", m2.Key) + " " + m2.Value.Name);
            }
            uxMove2.DataSource = tempList;
            //Moves3
            tempList = new List<string>();
            foreach (var m3 in PokemonConstants.Moves)
            {
                tempList.Add(String.Format("{0:D3}", m3.Key) + " " + m3.Value.Name);
            }
            uxMove3.DataSource = tempList;
            //Moves4
            tempList = new List<string>();
            foreach (var m4 in PokemonConstants.Moves)
            {
                tempList.Add(String.Format("{0:D3}", m4.Key) + " " + m4.Value.Name);
            }
            uxMove4.DataSource = tempList;

            //IV1
            tempList = new List<string>();
            for (int iv = 0; iv < 32; iv++)
            {
                tempList.Add(iv.ToString());
            }
            uxIVHitPoints.DataSource = tempList;
            //IV2
            tempList = new List<string>();
            for (int iv2 = 0; iv2 < 32; iv2++)
            {
                tempList.Add(iv2.ToString());
            }
            uxIVAttack.DataSource = tempList;
            //IV3
            tempList = new List<string>();
            for (int iv3 = 0; iv3 < 32; iv3++)
            {
                tempList.Add(iv3.ToString());
            }
            uxIVDefence.DataSource = tempList;
            //IV4
            tempList = new List<string>();
            for (int iv4 = 0; iv4 < 32; iv4++)
            {
                tempList.Add(iv4.ToString());
            }
            uxIVSpecialAttack.DataSource = tempList;
            //IV5
            tempList = new List<string>();
            for (int iv5 = 0; iv5 < 32; iv5++)
            {
                tempList.Add(iv5.ToString());
            }
            uxIVSpecialDefence.DataSource = tempList;
            //IV6
            tempList = new List<string>();
            for (int iv6 = 0; iv6 < 32; iv6++)
            {
                tempList.Add(iv6.ToString());
            }
            uxIVSpeed.DataSource = tempList;
        }

        /// <summary>
        /// Popunjava kontrole
        /// </summary>
        /// <param name="pokemon">pokemon za popunit</param>
        private void PokemonFill(Structures.Pokemon pokemon)
        {
            isReady = false;
            Structures.PokemonData pokemonData = pokemon.DecryptPokemonData();

            #region Verzija igre
            switch (pokemon.Language) 
            {
                case 0x0201:
                    uxOTLanguage.SelectedIndex = 0;
                    break;
                case 0x0202:
                    uxOTLanguage.SelectedIndex = 1;
                    break;
                case 0x0203:
                    uxOTLanguage.SelectedIndex = 2;
                    break;
                case 0x0204:
                    uxOTLanguage.SelectedIndex = 3;
                    break;
                case 0x0205:
                    uxOTLanguage.SelectedIndex = 4;
                    break;
                case 0x0207:
                    uxOTLanguage.SelectedIndex = 5;
                    break;
                default:
                    uxOTLanguage.SelectedIndex = 1;
                    break;
            }
            #endregion
            #region pokemon varijabla
            uxPokemonNickname.Text = pokemon.NicknameString;
            uxOTID.Text = pokemon.OriginalTrainerID.ToString();
            uxOTName.Text = pokemon.OriginalTrainerNameString;
            uxPokemonPID.Text = pokemon.Personality.ToString();
            uxPokemonNature.SelectedIndex = pokemon.PokemonNature;
            uxPokemonShiny.Checked = pokemon.PokemonShininess;
            uxPokemonCircle.Checked = pokemon.StorageBoxMarkCircle;
            uxPokemonSquare.Checked = pokemon.StorageBoxMarkSquare;
            uxPokemonTriangle.Checked = pokemon.StorageBoxMarkTriangle;
            uxPokemonHeart.Checked = pokemon.StorageBoxMarkHeart;
            #endregion
            #region PokemonData
            //Effort
            uxEVHitPoints.Text = pokemonData.Effort.HPEv.ToString();
            uxEVAttack.Text =pokemonData.Effort.AttackEv.ToString();
            uxEVDefence.Text =pokemonData.Effort.DefenseEv.ToString();
            uxEVSpecialAttack.Text =pokemonData.Effort.SpAttackEv.ToString();
            uxEVSpecialDefence.Text =pokemonData.Effort.SpDefenseEv.ToString();
            uxEVSpeed.Text = pokemonData.Effort.SpeedEv.ToString();
            //Contest
            uxContestCoolness.Text = pokemonData.Effort.Coolness.ToString();
            uxContestBeauty.Text = pokemonData.Effort.Beauty.ToString();
            uxContestCuteness.Text = pokemonData.Effort.Cuteness.ToString(); 
            uxContestSmartness.Text = pokemonData.Effort.Smartness.ToString();
            uxContestToughness.Text = pokemonData.Effort.Toughness.ToString();
            uxContestFeel.Text = pokemonData.Effort.Feel.ToString();
            #region Moves
            //Moves
            uxMove1.SelectedIndex = pokemonData.Attacks.Attack1;
            uxMove2.SelectedIndex = pokemonData.Attacks.Attack2;
            uxMove3.SelectedIndex = pokemonData.Attacks.Attack3;
            uxMove4.SelectedIndex = pokemonData.Attacks.Attack4;
            //MovesPP
            uxMove1PP.Text = pokemonData.Attacks.PP1.ToString();
            uxMove2PP.Text = pokemonData.Attacks.PP2.ToString();
            uxMove3PP.Text = pokemonData.Attacks.PP3.ToString();
            uxMove4PP.Text = pokemonData.Attacks.PP4.ToString();
            //MovesPP-UP
            uxMove1PP_UP.SelectedIndex = pokemonData.Growth.PPBonus1;
            uxMove2PP_UP.SelectedIndex = pokemonData.Growth.PPBonus2;
            uxMove3PP_UP.SelectedIndex = pokemonData.Growth.PPBonus3;
            uxMove4PP_UP.SelectedIndex = pokemonData.Growth.PPBonus4;
            //Moves ostalo
            //Move1
            Move mv = new Move();
            mv = pokemonData.Attacks.AttackMove1;
            move1Description = mv.Name + ": " + mv.Description;
            uxMove1Power.Text = mv.Power;
            uxMove1Accuracy.Text = mv.Accuracy;
            uxMove1Type.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + mv.Type + ".png"));
            uxMove1TypeContest.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonContest." + mv.ContestType + ".png"));
            //Move2
            mv = new Move();
            mv = pokemonData.Attacks.AttackMove2;
            move2Description = mv.Name + ": " + mv.Description;
            uxMove2Power.Text = mv.Power;
            uxMove2Accuracy.Text = mv.Accuracy;
            uxMove2Type.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + mv.Type + ".png"));
            uxMove2TypeContest.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonContest." + mv.ContestType + ".png"));
            //Move3
            mv = new Move();
            mv = pokemonData.Attacks.AttackMove3;
            move3Description = mv.Name + ": " + mv.Description;
            uxMove3Power.Text = mv.Power;
            uxMove3Accuracy.Text = mv.Accuracy;
            uxMove3Type.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + mv.Type + ".png"));
            uxMove3TypeContest.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonContest." + mv.ContestType + ".png"));
            //Move4
            mv = new Move();
            mv = pokemonData.Attacks.AttackMove4;
            move4Description = mv.Name + ": " + mv.Description;
            uxMove4Power.Text = mv.Power;
            uxMove4Accuracy.Text = mv.Accuracy;
            uxMove4Type.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + mv.Type + ".png"));
            uxMove4TypeContest.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonContest." + mv.ContestType + ".png"));
            //Disposing
            //mv = null;
            uxMovesDescription.Text = move1Description + Environment.NewLine + move2Description + Environment.NewLine + move3Description + Environment.NewLine + move4Description;
            #endregion
            //Growth
            PokemonStructure pstr = pokemonData.Growth.GetPokemonType;
            FillFilter(pstr.MoveList);
            uxPokemonPic.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.Pokemon." + pstr.picID.ToString() + ".png"));
            uxPokemonType1.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + pstr.PokemonType1 + ".png"));
            uxPokemonType2.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + pstr.PokemonType2 + ".png"));
            uxPokemonSpecies.Text = String.Format("{0:D3}", pstr.ID) + "  #" + String.Format("{0:D3}", pstr.picID) + "   " + pstr.Name;
            //List<string> ability = new List<string>();
            //ability.Add(pstr.Ability1.Name);
            //ability.Add(pstr.Ability2.Name);
            //uxPokemonAbility.DataSource = ability;
            uxPokemonAbility.Items.Clear();
            uxPokemonAbility.Items.AddRange(new object[] { pstr.Ability1.Name, pstr.Ability2.Name });
            uxPokemonAbility.SelectedIndex = pokemonData.Misc.IV_Ability;
            ItemType it =  pokemonData.Growth.GetItemType;
            uxPokemonItem.Text = String.Format("{0:D3}", it.ItemID) + " " + it.ItemName;
            uxPokemonLevel.Text = pokemonData.Growth.PokemonLevel.ToString();
            uxPokemonHappiness.Text = pokemonData.Growth.Friendship.ToString();
            //Misc
            //Ribbons
            uxContestCoolRibbon.SelectedIndex = pokemonData.Misc.Ribbon_Cool;
            uxContestBeautyRibbon.SelectedIndex = pokemonData.Misc.Ribbon_Beauty;
            uxContestCuteRibbon.SelectedIndex = pokemonData.Misc.Ribbon_Cute;
            uxContestSmartRibbon.SelectedIndex = pokemonData.Misc.Ribbon_Smart;
            uxContestToughRibbon.SelectedIndex = pokemonData.Misc.Ribbon_Tough;
            //IV
            uxIVHitPoints.SelectedIndex = pokemonData.Misc.IV_HP;
            uxIVAttack.SelectedIndex = pokemonData.Misc.IV_Attack;
            uxIVDefence.SelectedIndex = pokemonData.Misc.IV_Defense;
            uxIVSpecialAttack.SelectedIndex = pokemonData.Misc.IV_SpAttack;
            uxIVSpecialDefence.SelectedIndex = pokemonData.Misc.IV_SpDefense;
            uxIVSpeed.SelectedIndex = pokemonData.Misc.IV_Speed;
            //pokerus
            uxPokemonPokerus.Checked = pokemonData.Misc.Pokerus != 0 ? true : false;
            uxPokemonLevelCaught.Text = pokemonData.Misc.LevelCaught7bit.ToString();
            Locations lc =  pokemonData.Misc.Locations;
            uxPokemonLocationCaught.Text = String.Format("{0:D3}", lc.ID) + " " + lc.Name;
            uxPokemonPokeball.SelectedIndex = pokemonData.Misc.PokeballType - 1;
            uxOTGender.SelectedIndex = pokemonData.Misc.TrainerGender;
            uxPokemonEgg.Checked = pokemonData.Misc.IV_isEgg != 0 ? true : false;
            #endregion

            //Zbog dizajna pokemon classe moramo vratit nazad inace ostaje data polje dekriptirano
            pokemon.EncryptPokemonData(pokemonData);
            isReady = true;
        }

        /// <summary>
        /// Sprema sve promjene
        /// </summary>
        /// <returns></returns>
        private Pokemon PokemonSaveChanges()
        {
            Pokemon pok = new Pokemon();
            PokemonData pokData = new PokemonData();

            #region Pokemon
            pok.Personality = (uint)uxPokemonPID.GetNumberValue;
            pok.OriginalTrainerID = (uint)uxOTID.GetNumberValue;
            pok.NicknameString = uxPokemonNickname.Text;
            #region Verzija
            switch (uxOTLanguage.SelectedIndex)
            {
                case 0:
                    pok.Language = 0x0201;
                    break;
                case 1:
                    pok.Language = 0x0202;
                    break;
                case 2:
                    pok.Language = 0x0203;
                    break;
                case 3:
                    pok.Language = 0x0204;
                    break;
                case 4:
                    pok.Language = 0x0205;
                    break;
                case 5:
                    pok.Language = 0x0207;
                    break;
                default:
                    pok.Language = 0x0202;
                    break;
            }
            #endregion
            pok.OriginalTrainerNameString = uxOTName.Text;
            pok.StorageBoxMarkCircle = uxPokemonCircle.Checked;
            pok.StorageBoxMarkHeart = uxPokemonHeart.Checked;
            pok.StorageBoxMarkSquare = uxPokemonSquare.Checked;
            pok.StorageBoxMarkTriangle = uxPokemonTriangle.Checked;
            #endregion
            #region Pokemon Data
            string[] str = uxPokemonSpecies.Text.Split(' ');
            ushort tempID = 0;
            //Pokemon Tip
            ushort.TryParse(str[0], out tempID);
            pokData.Growth.Species = tempID;
            //PokeDex
            PokemonStructure dexPokemon;
            if (PokemonConstants.PokemonList.TryGetValue(tempID, out dexPokemon))
            {
                this.dexID = dexPokemon.picID;
            }
            else 
            {
                this.dexID = 0;
            }
            //Item
            str = uxPokemonItem.Text.Split(' ');
            ushort.TryParse(str[0], out tempID);
            pokData.Growth.ItemHeld = tempID;
            //Level
            pokData.Growth.PokemonLevel = (byte)uxPokemonLevel.GetNumberValue;
            //PP-UP-Bonusi
            pokData.Growth.PPBonus1 = (byte)uxMove1PP_UP.SelectedIndex;
            pokData.Growth.PPBonus2 = (byte)uxMove2PP_UP.SelectedIndex;
            pokData.Growth.PPBonus3 = (byte)uxMove3PP_UP.SelectedIndex;
            pokData.Growth.PPBonus4 = (byte)uxMove4PP_UP.SelectedIndex;
            //Friendship
            pokData.Growth.Friendship = (byte)uxPokemonHappiness.GetNumberValue;
            //Moves
            //1
            str = uxMove1.Text.Split(' ');
            ushort.TryParse(str[0], out tempID);
            if (tempID != 0)
            {
                pokData.Attacks.Attack1 = tempID;
                pokData.Attacks.PP1 = (byte)uxMove1PP.GetNumberValue;
            }
            else 
            {
                pokData.Attacks.Attack1 = 0;
                pokData.Attacks.PP1 = 0;
                pokData.Growth.PPBonus1 = 0;
            }
            //2
            str = uxMove2.Text.Split(' ');
            ushort.TryParse(str[0], out tempID);
            if (tempID != 0)
            {
                pokData.Attacks.Attack2 = tempID;
                pokData.Attacks.PP2 = (byte)uxMove2PP.GetNumberValue;
            }
            else
            {
                pokData.Attacks.Attack2 = 0;
                pokData.Attacks.PP2 = 0;
                pokData.Growth.PPBonus2 = 0;
            }
            //3
            str = uxMove3.Text.Split(' ');
            ushort.TryParse(str[0], out tempID);
            if (tempID != 0)
            {
                pokData.Attacks.Attack3 = tempID;
                pokData.Attacks.PP3 = (byte)uxMove3PP.GetNumberValue;
            }
            else
            {
                pokData.Attacks.Attack3 = 0;
                pokData.Attacks.PP3 = 0;
                pokData.Growth.PPBonus3 = 0;
            }
            //4
            str = uxMove4.Text.Split(' ');
            ushort.TryParse(str[0], out tempID);
            if (tempID != 0)
            {
                pokData.Attacks.Attack4 = tempID;
                pokData.Attacks.PP4 = (byte)uxMove4PP.GetNumberValue;
            }
            else
            {
                pokData.Attacks.Attack4 = 0;
                pokData.Attacks.PP4 = 0;
                pokData.Growth.PPBonus4 = 0;
            }
            //Effort
            pokData.Effort.HPEv = (byte)uxEVHitPoints.GetNumberValue;
            pokData.Effort.AttackEv = (byte)uxEVAttack.GetNumberValue;
            pokData.Effort.DefenseEv = (byte)uxEVDefence.GetNumberValue;
            pokData.Effort.SpeedEv = (byte)uxEVSpeed.GetNumberValue;
            pokData.Effort.SpAttackEv = (byte)uxEVSpecialAttack.GetNumberValue;
            pokData.Effort.SpDefenseEv = (byte)uxEVSpecialDefence.GetNumberValue;
            //contest
            pokData.Effort.Coolness = (byte)uxContestCoolness.GetNumberValue;
            pokData.Effort.Beauty = (byte)uxContestBeauty.GetNumberValue;
            pokData.Effort.Cuteness = (byte)uxContestCuteness.GetNumberValue;
            pokData.Effort.Smartness = (byte)uxContestSmartness.GetNumberValue;
            pokData.Effort.Toughness = (byte)uxContestToughness.GetNumberValue;
            pokData.Effort.Feel = (byte)uxContestFeel.GetNumberValue;
            //Misc.
            //Pokerus
            if (uxPokemonPokerus.Checked == true)
            {pokData.Misc.Pokerus = 116;}
            else{pokData.Misc.Pokerus = 0;}
            //Location caught
            str = uxPokemonLocationCaught.Text.Split(' ');
            ushort.TryParse(str[0], out tempID);
            pokData.Misc.LocationCaught = (byte)tempID;
            //Level caught
            pokData.Misc.LevelCaught7bit = (sbyte)uxPokemonLevelCaught.GetNumberValue;
            //Poke Ball
            pokData.Misc.PokeballType = (byte)(uxPokemonPokeball.SelectedIndex + 1);
            //Gender
            pokData.Misc.TrainerGender = (byte)uxOTGender.SelectedIndex;
            //IV
            pokData.Misc.IV_HP = (byte)uxIVHitPoints.SelectedIndex;
            pokData.Misc.IV_Attack = (byte)uxIVAttack.SelectedIndex;
            pokData.Misc.IV_Defense = (byte)uxIVDefence.SelectedIndex;
            pokData.Misc.IV_Speed = (byte)uxIVSpeed.SelectedIndex;
            pokData.Misc.IV_SpAttack = (byte)uxIVSpecialAttack.SelectedIndex;
            pokData.Misc.IV_SpDefense = (byte)uxIVSpecialDefence.SelectedIndex;
            //Ribbons
            pokData.Misc.Ribbon_Cool = (byte)uxContestCoolRibbon.SelectedIndex;
            pokData.Misc.Ribbon_Beauty = (byte)uxContestBeautyRibbon.SelectedIndex;
            pokData.Misc.Ribbon_Cute = (byte)uxContestCuteRibbon.SelectedIndex;
            pokData.Misc.Ribbon_Smart = (byte)uxContestSmartRibbon.SelectedIndex;
            pokData.Misc.Ribbon_Tough = (byte)uxContestToughRibbon.SelectedIndex;
            //Egg
            if (uxPokemonEgg.Checked == true)
            { pokData.Misc.IV_isEgg = 1; }
            else { pokData.Misc.IV_isEgg = 0; }
            //Ability
            pokData.Misc.IV_Ability = (byte)uxPokemonAbility.SelectedIndex;
            //Shiny
            if (uxPokemonShiny.Checked == true && originalPokemonShininess != true)
            {
                pok.PokemonShininess = true;
            }
            #endregion
            //Provjere za Mew I Deox
            if (pokData.Growth.Species == 151)//mew
            {
                pokData.Misc.SetObedient = true;
                //pokData.Misc.LocationCaught = 201;
            }
            if (pokData.Growth.Species == 410)//Deox
            {
                pokData.Misc.SetObedient = true;
                //pokData.Misc.LocationCaught = 200;
            }
            //Spremamo enkriptiramo i vracamo nazad
            pok.EncryptPokemonData(pokData);
            return pok;
        }

        /// <summary>
        /// Popunjava filter combobox u moves-ima
        /// </summary>
        /// <param name="filter"></param>
        private void FillFilter(ushort[] filter)
        {
            FillFilterHelper(uxMove1Filter, filter);
            FillFilterHelper(uxMove2Filter, filter);
            FillFilterHelper(uxMove3Filter, filter);
            FillFilterHelper(uxMove4Filter, filter);
        }

        /// <summary>
        /// Helper
        /// </summary>
        /// <param name="filter"></param>
        private void FillFilterHelper(ComboBox cb, ushort[] filter)
        {
            List<string> tempList = new List<string>();
            Move mv;
            foreach (ushort f in filter)
            {
                mv = new Move();
                if (PokemonConstants.Moves.TryGetValue(f, out mv))
                {
                    tempList.Add(String.Format("{0:D3}", mv.ID) + " " + mv.Name);
                }
            }
            //cb.Items.Clear();
            cb.DataSource = tempList;
        }


        /// <summary>
        /// Pomocna funkcija za dobit random broj izmedu min i max
        /// </summary>
        /// <param name="min">min</param>
        /// <param name="max">max</param>
        /// <returns>vraca random broj</returns>
        private int GetRandom(int min, int max)
        {
            //Random rnd = new Random();
            return rnd.Next(min, max);
        }

        /// <summary>
        /// Pomocna funkcija za dobit random broj izmedu min i max
        /// </summary>
        /// <param name="min">min</param>
        /// <param name="max">max</param>
        /// <returns>vraca random broj</returns>
        private long GetRandomLong(uint min, uint max)
        {
            //Random rnd = new Random();
            byte[] buf = new byte[8];
            rnd.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        #region Mouse Events za Random
        private void uxEVHitPointsRandom_Click(object sender, EventArgs e)
        {
            uxEVHitPoints.Text = GetRandom(0, 255).ToString();
        }

        private void uxEVAttackRandom_Click(object sender, EventArgs e)
        {
            uxEVAttack.Text = GetRandom(0, 255).ToString();
        }

        private void uxEVDefenceRandom_Click(object sender, EventArgs e)
        {
            uxEVDefence.Text = GetRandom(0, 255).ToString();
        }

        private void uxEVSpecialAttackRandom_Click(object sender, EventArgs e)
        {
            uxEVSpecialAttack.Text = GetRandom(0, 255).ToString();
        }

        private void uxEVSpecialDefenceRandom_Click(object sender, EventArgs e)
        {
            uxEVSpecialDefence.Text = GetRandom(0, 255).ToString();
        }

        private void uxEVSpeedRandom_Click(object sender, EventArgs e)
        {
            uxEVSpeed.Text = GetRandom(0, 255).ToString();
        }

        private void uxContestCoolnessRandom_Click(object sender, EventArgs e)
        {
            uxContestCoolness.Text = GetRandom(0, 255).ToString();
        }

        private void uxContestBeautyRandom_Click(object sender, EventArgs e)
        {
            uxContestBeauty.Text = GetRandom(0, 255).ToString();
        }

        private void uxContestCutenessRandom_Click(object sender, EventArgs e)
        {
            uxContestCuteness.Text = GetRandom(0, 255).ToString();
        }

        private void uxContestSmartnessRandom_Click(object sender, EventArgs e)
        {
            uxContestSmartness.Text = GetRandom(0, 255).ToString();
        }

        private void uxContestToughnessRandom_Click(object sender, EventArgs e)
        {
            uxContestToughness.Text = GetRandom(0, 255).ToString();
        }

        private void uxContestFeelRandom_Click(object sender, EventArgs e)
        {
            uxContestFeel.Text = GetRandom(0, 255).ToString();
        }

        private void uxIVHitPointsRandom_Click(object sender, EventArgs e)
        {
            uxIVHitPoints.SelectedIndex = GetRandom(0, 31);
        }

        private void uxIVAttackRandom_Click(object sender, EventArgs e)
        {
            uxIVAttack.SelectedIndex = GetRandom(0, 31);
        }

        private void uxIVDefenceRandom_Click(object sender, EventArgs e)
        {
            uxIVDefence.SelectedIndex = GetRandom(0, 31);
        }

        private void uxIVSpecialAttackRandom_Click(object sender, EventArgs e)
        {
            uxIVSpecialAttack.SelectedIndex = GetRandom(0, 31);
        }

        private void uxIVSpecialDefenceRandom_Click(object sender, EventArgs e)
        {
            uxIVSpecialDefence.SelectedIndex = GetRandom(0, 31);
        }

        private void uxIVSpeedRandom_Click(object sender, EventArgs e)
        {
            uxIVSpeed.SelectedIndex = GetRandom(0, 31);
        }
        #endregion

        #region Combo Events
        //Move
        private void uxMove1Filter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!isReady)
                return;
            uxMove1.Text = uxMove1Filter.Text;
        }
        private void uxMove2Filter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!isReady)
                return;
            uxMove2.Text = uxMove2Filter.Text;
        }

        private void uxMove3Filter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!isReady)
                return;
            uxMove3.Text = uxMove3Filter.Text;
        }

        private void uxMove4Filter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!isReady)
                return;
            uxMove4.Text = uxMove4Filter.Text;
        }
        
        private void uxMove1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            Move mv;
            mv = new Move();
            string[] str = uxMove1.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;
            
            if (PokemonConstants.Moves.TryGetValue(index, out mv))
            {
                move1Description = mv.Name + ": " + mv.Description;
                uxMove1Power.Text = mv.Power;
                uxMove1Accuracy.Text = mv.Accuracy;
                uxMove1Type.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + mv.Type + ".png"));
                uxMove1TypeContest.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonContest." + mv.ContestType + ".png"));
                uxMove1PP.Text = mv.PP.ToString();
                uxMove1PP_UP.SelectedIndex = 0;
                uxMovesDescription.Text = move1Description + Environment.NewLine + move2Description + Environment.NewLine + move3Description + Environment.NewLine + move4Description;
            }

        }

        private void uxMove2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            Move mv;
            mv = new Move();
            string[] str = uxMove2.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.Moves.TryGetValue(index, out mv))
            {
                move2Description = mv.Name + ": " + mv.Description;
                uxMove2Power.Text = mv.Power;
                uxMove2Accuracy.Text = mv.Accuracy;
                uxMove2Type.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + mv.Type + ".png"));
                uxMove2TypeContest.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonContest." + mv.ContestType + ".png"));
                uxMove2PP.Text = mv.PP.ToString();
                uxMove2PP_UP.SelectedIndex = 0;
                uxMovesDescription.Text = move1Description + Environment.NewLine + move2Description + Environment.NewLine + move3Description + Environment.NewLine + move4Description;
            }
        }

        private void uxMove3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            Move mv;
            mv = new Move();
            string[] str = uxMove3.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.Moves.TryGetValue(index, out mv))
            {
                move3Description = mv.Name + ": " + mv.Description;
                uxMove3Power.Text = mv.Power;
                uxMove3Accuracy.Text = mv.Accuracy;
                uxMove3Type.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + mv.Type + ".png"));
                uxMove3TypeContest.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonContest." + mv.ContestType + ".png"));
                uxMove3PP.Text = mv.PP.ToString();
                uxMove3PP_UP.SelectedIndex = 0;
                uxMovesDescription.Text = move1Description + Environment.NewLine + move2Description + Environment.NewLine + move3Description + Environment.NewLine + move4Description;
            }
        }

        private void uxMove4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            Move mv;
            mv = new Move();
            string[] str = uxMove4.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.Moves.TryGetValue(index, out mv))
            {
                move4Description = mv.Name + ": " + mv.Description;
                uxMove4Power.Text = mv.Power;
                uxMove4Accuracy.Text = mv.Accuracy;
                uxMove4Type.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + mv.Type + ".png"));
                uxMove4TypeContest.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonContest." + mv.ContestType + ".png"));
                uxMove4PP.Text = mv.PP.ToString();
                uxMove4PP_UP.SelectedIndex = 0;
                uxMovesDescription.Text = move1Description + Environment.NewLine + move2Description + Environment.NewLine + move3Description + Environment.NewLine + move4Description;
            }
        }
        //Pokemon
        private void uxPokemonSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            PokemonStructure ps = new PokemonStructure();
            string[] str = uxPokemonSpecies.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.PokemonList.TryGetValue(index, out ps))
            {
                FillFilter(ps.MoveList);
                uxPokemonPic.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.Pokemon." + ps.picID.ToString() + ".png"));
                uxPokemonType1.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + ps.PokemonType1 + ".png"));
                uxPokemonType2.Image = Image.FromStream(Assembly.GetEntryAssembly().GetManifestResourceStream("Pokemon_Save_Editor.Images.PokemonType." + ps.PokemonType2 + ".png"));
                uxPokemonNickname.Text = ps.Name.ToUpper();
                uxPokemonAbility.Items.Clear();
                uxPokemonAbility.Items.AddRange(new object[] { ps.Ability1.Name, ps.Ability2.Name });
                if (ps.Ability2.Name == "No Ability")
                {
                    uxPokemonAbility.SelectedIndex = 0;
                }
                else 
                {
                    uxPokemonAbility.SelectedIndex = GetRandom(0,1);
                }
            }
        }
        // Move PP UP
        private void uxMove1PP_UP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            //Razne provjere
            if (uxMove1.SelectedIndex == 0 || uxMove1PP.Text == "0")
            {
                uxMove1PP_UP.SelectedIndex = 0;
                return;
            } 

            Move mv = new Move();
            string[] str = uxMove1.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.Moves.TryGetValue(index, out mv))
            {
                //Ako je odabrani index 0 moramo vratit pp na pocetnu rijednost poteza
                if (uxMove1PP_UP.SelectedIndex == 0)
                {
                    uxMove1PP.Text = mv.PP.ToString();
                    return;
                }
                else //Slucaj za ostale indexe
                {
                    int pp = mv.PP;
                    double result = (pp * 0.2) * uxMove1PP_UP.SelectedIndex;
                    pp += (int)result;
                    uxMove1PP.Text = pp.ToString();
                    return;
                }
            }
        }

        private void uxMove2PP_UP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            //Razne provjere
            if (uxMove2.SelectedIndex == 0 || uxMove2PP.Text == "0")
            {
                uxMove2PP_UP.SelectedIndex = 0;
                return;
            }

            Move mv = new Move();
            string[] str = uxMove2.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.Moves.TryGetValue(index, out mv))
            {
                //Ako je odabrani index 0 moramo vratit pp na pocetnu rijednost poteza
                if (uxMove2PP_UP.SelectedIndex == 0)
                {
                    uxMove2PP.Text = mv.PP.ToString();
                    return;
                }
                else //Slucaj za ostale indexe
                {
                    int pp = mv.PP;
                    double result = (pp * 0.2) * uxMove2PP_UP.SelectedIndex;
                    pp += (int)result;
                    uxMove2PP.Text = pp.ToString();
                    return;
                }
            }
        }

        private void uxMove3PP_UP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            //Razne provjere
            if (uxMove3.SelectedIndex == 0 || uxMove3PP.Text == "0")
            {
                uxMove3PP_UP.SelectedIndex = 0;
                return;
            }

            Move mv = new Move();
            string[] str = uxMove3.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.Moves.TryGetValue(index, out mv))
            {
                //Ako je odabrani index 0 moramo vratit pp na pocetnu rijednost poteza
                if (uxMove3PP_UP.SelectedIndex == 0)
                {
                    uxMove3PP.Text = mv.PP.ToString();
                    return;
                }
                else //Slucaj za ostale indexe
                {
                    int pp = mv.PP;
                    double result = (pp * 0.2) * uxMove3PP_UP.SelectedIndex;
                    pp += (int)result;
                    uxMove3PP.Text = pp.ToString();
                    return;
                }
            }
        }

        private void uxMove4PP_UP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            //Razne provjere
            if (uxMove4.SelectedIndex == 0 || uxMove4PP.Text == "0")
            {
                uxMove4PP_UP.SelectedIndex = 0;
                return;
            }

            Move mv = new Move();
            string[] str = uxMove4.Text.Split(' ');
            ushort index = 0;

            if (!ushort.TryParse(str[0], out index))
                return;

            if (PokemonConstants.Moves.TryGetValue(index, out mv))
            {
                //Ako je odabrani index 0 moramo vratit pp na pocetnu rijednost poteza
                if (uxMove4PP_UP.SelectedIndex == 0)
                {
                    uxMove4PP.Text = mv.PP.ToString();
                    return;
                }
                else //Slucaj za ostale indexe
                {
                    int pp = mv.PP;
                    double result = (pp * 0.2) * uxMove4PP_UP.SelectedIndex;
                    pp += (int)result;
                    uxMove4PP.Text = pp.ToString();
                    return;
                }
            }
        }
        
        private void uxPokemonNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            Pokemon pok = new Pokemon();
            pok.Personality = (uint)uxPokemonPID.GetNumberValue;
            pok.OriginalTrainerID = (uint)uxOTID.GetNumberValue;
            pok.PokemonNature = (byte)uxPokemonNature.SelectedIndex;

            uxPokemonPID.Text = pok.Personality.ToString();
        }

        private void uxPokemonPID_TextChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;
            uxPokemonNature.SelectedIndex = (byte)(uxPokemonPID.GetNumberValue % 25);
        }
        #endregion

        //private void uxOTCancel_Click(object sender, EventArgs e)
        //{
        //    //this.Close();
        //}

        private void uxOTSave_Click(object sender, EventArgs e)
        {
            Pokemon pok = new Pokemon();
            pok = PokemonSaveChanges();
            this.changedPokemon = pok;
            //DexID
            //this.dexID = 0;


            this.Close();
        }

        private void uxOTImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select Pokemon File";
            ofd.Filter = "Pokemon File|*.pok";

            if (Directory.Exists("Pokemon"))
            { 
                ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) +  "\\Pokemon";
            }
            else
            {
                ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            }
            //Otvaramo dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(ofd.FileName);
                if (f.Length != 80)
                {
                    MessageBox.Show("The selected file is not a valid pokemon file");
                    return;
                }

                //Ucitavamo file
                try
                {
                    Pokemon pok = new Pokemon();
                    pok.ImportPokemon(f.FullName);
                    PokemonFill(pok);
                    MessageBox.Show("File successfully imported");
                }
                catch
                {
                    MessageBox.Show("Sorry, Something went wrong");
                }
            }
            
        }

        private void uxOTExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Please name Pokemon File";
            sfd.Filter = "Pokemon File|*.pok";

            if (Directory.Exists("Pokemon"))
            {
                sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Pokemon";
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Application.ExecutablePath) + "\\Pokemon");
                    sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Pokemon";
                }
                catch
                {
                    sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                }
            }
            //Otvaramo dialog
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Ucitavamo file
                    Pokemon pok = new Pokemon();
                    pok = PokemonSaveChanges();
                    pok.ExportPokemon(sfd.FileName);
                    MessageBox.Show("File successfully exported");
                }
                catch 
                {
                    MessageBox.Show("Sorry, Something went wrong");
                }
            }
        }

        private void uxOTCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon pok = new Pokemon();
                pok = PokemonSaveChanges();
                string str = Hexadecimal.BytesToHexString(pok.Save());
                str = "PO" + str + "KE";
                Clipboard.SetText(str);
            }
            catch 
            {
                MessageBox.Show("Sorry, Something went wrong");
            }
        }

        private void uxOTPaste_Click(object sender, EventArgs e)
        {
            string data = Clipboard.GetText();
            if (data != "" && data.Length == 164)
            {
                string check = data.Substring(0, 2);
                check += data.Substring(data.Length - 2, 2);
                //micemo POKE iz texta
                data = data.Substring(2, data.Length - 4);

                if (check == "POKE" && data.Length % 2 == 0 && data.Length == 160)
                {
                    try
                    {
                        Pokemon pok = new Pokemon();
                        byte[] bytes = Hexadecimal.HexStringToBytes(data);
                        pok.Load(bytes);
                        PokemonFill(pok);
                    }
                    catch 
                    {
                        MessageBox.Show("Sorry, Something went wrong");
                    }
                }
                else 
                {
                    MessageBox.Show("Not valid Pokemon Data");
                }
            }
        }
    }
}
