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
using System.IO;

namespace Pokemon_Save_Editor
{
    public partial class PokemonSavegameEditor : Form
    {
        private PokemonSave pokemonSave;
        private Player player;
        private PlayerBag playerBag;
        private PokemonStorage pokemonStorage;
        private Pokedex pokedex;
        private bool isReady;
        private PokemonVersion pokemonVersion;
        /// <summary>
        /// Sluzi za Apply Gumbe
        /// </summary>
        private bool isReadyButtons;

        public PokemonSavegameEditor()
        {
            InitializeComponent();
            isReady = false;
            isReadyButtons = false;
            pokemonVersion = PokemonVersion.Emerald;
            uxPokemonVersion.SelectedIndex = 0;
        }

        /// <summary>
        /// Ucitavamo save iz zadane putanje
        /// </summary>
        /// <param name="path">Putanja do save filea</param>
        private void LoadSaveFile(string path)
        {
            this.player = new Player();
            this.playerBag = new PlayerBag(pokemonVersion);
            this.pokemonStorage = new PokemonStorage();
            this.pokedex = new Pokedex();
            this.pokemonSave = new PokemonSave(path);
            isReady = false;
            uxNationalDex.Checked = false;

            //File je ucitan i spreman za obradu
            if (pokemonSave.isLoaded)
            {
                using (MemoryStream tempSave = new MemoryStream(pokemonSave.saveBank))
                {
                    using (BinaryReader br = new BinaryReader(tempSave))
                    {
                        // Za svaki slucaj postavit na pocetak
                        br.BaseStream.Seek(0, SeekOrigin.Begin);
                        #region Player
                        //Name
                        player.Name = br.ReadBytes(7);
                        //Gender
                        br.BaseStream.Seek(PokemonConstants.playerGenderOffset, SeekOrigin.Begin);
                        player.Gender = br.ReadByte();
                        //TrainerID
                        br.BaseStream.Seek(PokemonConstants.playerTrainerIDOffset, SeekOrigin.Begin);
                        player.TrainerID = br.ReadUInt32();

                        //EncryptionKey
                        if (pokemonVersion == PokemonVersion.Emerald)
                        {
                            br.BaseStream.Seek(PokemonConstants.playerEncryptionKeyOffset, SeekOrigin.Begin);
                            player.EncryptionKey = br.ReadUInt32();
                        }
                        else if (pokemonVersion == PokemonVersion.FireRedAndLeafGreen)
                        {
                            br.BaseStream.Seek(PokemonConstants.playerEncryptionKeyOffsetFireLeaf, SeekOrigin.Begin);
                            player.EncryptionKey = br.ReadUInt32();
                        }
                        else //Ruby, Sapphire
                        {
                            player.EncryptionKey = 0;
                        }
                        //Money and Coins
                        if (pokemonVersion == PokemonVersion.FireRedAndLeafGreen)
                        {
                            //Money
                            br.BaseStream.Seek(PokemonConstants.playerMoneyOffsetFireLeaf, SeekOrigin.Begin);
                            player.Money = br.ReadUInt32();
                            //Coins
                            br.BaseStream.Seek(PokemonConstants.playerCoinsOffsetFireLeaf, SeekOrigin.Begin);
                            player.Coins = br.ReadUInt16();
                        }
                        else //Emerald , Ruby, Sapphire
                        {
                            //Money
                            br.BaseStream.Seek(PokemonConstants.playerMoneyOffset, SeekOrigin.Begin);
                            player.Money = br.ReadUInt32();
                            //Coins
                            br.BaseStream.Seek(PokemonConstants.playerCoinsOffset, SeekOrigin.Begin);
                            player.Coins = br.ReadUInt16();
                        }

                        #endregion
                        #region Items - Bag
                        //Bag
                        if (pokemonVersion == PokemonVersion.FireRedAndLeafGreen)
                        {
                            br.BaseStream.Seek(PokemonConstants.bagOffsetFireLeaf, SeekOrigin.Begin);
                            playerBag.Load(br.ReadBytes(PokemonConstants.bagSizeinBytes));
                        }
                        else if (pokemonVersion == PokemonVersion.RubyAndSapphire)
                        {
                            br.BaseStream.Seek(PokemonConstants.bagOffset, SeekOrigin.Begin);
                            playerBag.Load(br.ReadBytes(PokemonConstants.bagSizeinBytesRubySapphire));
                        }
                        else//Emerald
                        {
                            br.BaseStream.Seek(PokemonConstants.bagOffset, SeekOrigin.Begin);
                            playerBag.Load(br.ReadBytes(PokemonConstants.bagSizeinBytes));
                        }
                        #endregion
                        //Pokemon Storage
                        br.BaseStream.Seek(PokemonConstants.pokemonStorageOffset, SeekOrigin.Begin);
                        pokemonStorage.Load(br.ReadBytes(PokemonConstants.pokemonStorageSize));

                        #region Pokedex
                        //Own
                        br.BaseStream.Seek(PokemonConstants.pokedexOwnOffset, SeekOrigin.Begin);
                        pokedex.LoadOwn(br.ReadBytes(49));
                        //Seen
                        br.BaseStream.Seek(PokemonConstants.pokedexSeenOffset, SeekOrigin.Begin);
                        pokedex.LoadSeen(br.ReadBytes(49));
                        #endregion
                    }
                }//end memory stream
                //Postavljamo enkripcijski kljuc u Items
                Item.EncryptionKey = player.EncryptionKeySmall;
                isReady = true;
            }//end if
        }

        /// <summary>
        /// Spremamo save nazad u file
        /// </summary>
        private void SaveFile()
        {

            //File je ucitan i spreman za obradu
            if (pokemonSave.isLoaded)
            {
                using (MemoryStream tempSave = new MemoryStream(pokemonSave.saveBank))
                {
                    using (BinaryWriter bw = new BinaryWriter(tempSave))
                    {
                        // Za svaki slucaj postavit na pocetak
                        bw.BaseStream.Seek(0, SeekOrigin.Begin);
                        #region Player
                        //Name
                        bw.Write(player.Name);
                        //Gender
                        bw.BaseStream.Seek(PokemonConstants.playerGenderOffset, SeekOrigin.Begin);
                        bw.Write(player.Gender);
                        //TrainerID
                        bw.BaseStream.Seek(PokemonConstants.playerTrainerIDOffset, SeekOrigin.Begin);
                        bw.Write(player.TrainerID);
                        //EncryptionKey
                        //bw.BaseStream.Seek(PokemonConstants.playerEncryptionKeyOffset, SeekOrigin.Begin);
                        //bw.Write(player.EncryptionKey);
                        //Money and Coins
                        if (pokemonVersion == PokemonVersion.FireRedAndLeafGreen)
                        {
                            //Money
                            bw.BaseStream.Seek(PokemonConstants.playerMoneyOffsetFireLeaf, SeekOrigin.Begin);
                            bw.Write(player.Money);
                            //Coins
                            bw.BaseStream.Seek(PokemonConstants.playerCoinsOffsetFireLeaf, SeekOrigin.Begin);
                            bw.Write(player.Coins);
                        }
                        else//Emerald , Ruby, Sapphire
                        {
                            //Money
                            bw.BaseStream.Seek(PokemonConstants.playerMoneyOffset, SeekOrigin.Begin);
                            bw.Write(player.Money);
                            //Coins
                            bw.BaseStream.Seek(PokemonConstants.playerCoinsOffset, SeekOrigin.Begin);
                            bw.Write(player.Coins);
                        }

                        #endregion
                        #region Items - Bag
                        //Bag
                        if (pokemonVersion == PokemonVersion.FireRedAndLeafGreen)
                        {
                            bw.BaseStream.Seek(PokemonConstants.bagOffsetFireLeaf, SeekOrigin.Begin);
                            bw.Write(playerBag.Save());
                        }
                        else if (pokemonVersion == PokemonVersion.RubyAndSapphire)
                        {
                            bw.BaseStream.Seek(PokemonConstants.bagOffset, SeekOrigin.Begin);
                            bw.Write(playerBag.Save());
                        }
                        else//Emerald
                        {
                            bw.BaseStream.Seek(PokemonConstants.bagOffset, SeekOrigin.Begin);
                            bw.Write(playerBag.Save());
                        }
                        #endregion
                        //Pokemon Storage
                        bw.BaseStream.Seek(PokemonConstants.pokemonStorageOffset, SeekOrigin.Begin);
                        bw.Write(pokemonStorage.Save());

                        #region Pokedex
                        //Own
                        bw.BaseStream.Seek(PokemonConstants.pokedexOwnOffset, SeekOrigin.Begin);
                        bw.Write(pokedex.SaveOwn());
                        //Seen 1
                        bw.BaseStream.Seek(PokemonConstants.pokedexSeenOffset, SeekOrigin.Begin);
                        bw.Write(pokedex.SaveSeen());
                        //Dex Seen 2 i 3
                        if (pokemonVersion == PokemonVersion.Emerald)
                        {
                            //Seen2
                            bw.BaseStream.Seek(PokemonConstants.pokedexSeenOffset2, SeekOrigin.Begin);
                            bw.Write(pokedex.SaveSeen());
                            //Seen3
                            bw.BaseStream.Seek(PokemonConstants.pokedexSeenOffset3, SeekOrigin.Begin);
                            bw.Write(pokedex.SaveSeen());
                        }
                        else if (pokemonVersion == PokemonVersion.FireRedAndLeafGreen)
                        {
                            //Seen2
                            bw.BaseStream.Seek(PokemonConstants.pokedexSeenOffsetFireLeaf2, SeekOrigin.Begin);
                            bw.Write(pokedex.SaveSeen());
                            //Seen3
                            bw.BaseStream.Seek(PokemonConstants.pokedexSeenOffsetFireLeaf3, SeekOrigin.Begin);
                            bw.Write(pokedex.SaveSeen());
                        }
                        else//Ruby Sapphire 
                        {
                            //Seen2
                            bw.BaseStream.Seek(PokemonConstants.pokedexSeenOffsetRubySapphire2, SeekOrigin.Begin);
                            bw.Write(pokedex.SaveSeen());
                            //Seen3
                            bw.BaseStream.Seek(PokemonConstants.pokedexSeenOffsetRubySapphire3, SeekOrigin.Begin);
                            bw.Write(pokedex.SaveSeen());
                        }
                        #endregion

                        #region National Pokedex

                        if (uxNationalDex.Checked == true)
                        {
                            if (pokemonVersion == PokemonVersion.Emerald)
                            {
                                bw.BaseStream.Seek(0x1A, SeekOrigin.Begin);
                                bw.Write((byte)0xDA);
                                bw.BaseStream.Seek(0x2302, SeekOrigin.Begin);
                                bw.Write((byte)0x6D);
                                bw.BaseStream.Seek(0x23A8, SeekOrigin.Begin);
                                bw.Write((byte)0x02);
                                bw.BaseStream.Seek(0x23A9, SeekOrigin.Begin);
                                bw.Write((byte)0x03);
                            }
                            else if (pokemonVersion == PokemonVersion.FireRedAndLeafGreen)
                            {
                                bw.BaseStream.Seek(0x1B, SeekOrigin.Begin);
                                bw.Write((byte)0xB9);
                                bw.BaseStream.Seek(0x1F68, SeekOrigin.Begin);
                                bw.Write((byte)0xF1);
                                bw.BaseStream.Seek(0x201C, SeekOrigin.Begin);
                                bw.Write((byte)0x58);
                                bw.BaseStream.Seek(0x201D, SeekOrigin.Begin);
                                bw.Write((byte)0x62);
                            }
                            else//Ruby Sapphire 
                            {
                                bw.BaseStream.Seek(0x1A, SeekOrigin.Begin);
                                bw.Write((byte)0xDA);
                                bw.BaseStream.Seek(0x22A6, SeekOrigin.Begin);
                                bw.Write((byte)0x67);
                                bw.BaseStream.Seek(0x234C, SeekOrigin.Begin);
                                bw.Write((byte)0x02);
                                bw.BaseStream.Seek(0x234D, SeekOrigin.Begin);
                                bw.Write((byte)0x03);
                            }
                        }
                        #endregion

                        //Vracanje u array
                        pokemonSave.saveBank = tempSave.ToArray();
                    }
                }//end memory stream

                pokemonSave.SaveToFile();
            }//end if
        }

        /// <summary>
        /// Popunjavamo Kontrole sa ucitanim podacima
        /// </summary>
        private void FillControls()
        {
            //Player
            uxTrainerName.Text = player.NameString;
            uxTrainerID.Text = player.TrainerID.ToString();
            uxTrainerPublicID.Text = player.PublicTrainerID.ToString();
            uxTrainerPrivateID.Text = player.PrivateTrainerID.ToString();
            //Ruby i Sapphire nemaju enkriptirano pa moramo pristupit direktno
            if (pokemonVersion == PokemonVersion.RubyAndSapphire)
            {
                uxTrainerMoney.Text = player.Money.ToString();
                uxTrainerCoins.Text = player.Coins.ToString();
            }
            else
            {
                uxTrainerMoney.Text = player.MoneyEncryption.ToString();
                uxTrainerCoins.Text = player.CoinsEncryption.ToString();
            }

            uxTrainerGender.SelectedIndex = player.Gender;

            //Pokemon Storage
            List<string> temp = new List<string>();
            for (int i = 0; i < 14; i++)
            {
                temp.Add(pokemonStorage.GetBoxNamesString(i));
            }
            uxPokemonStorageBox.DataSource = temp;
            uxPokemonStorageBox.SelectedIndex = 0;
            StorageBoxHelper();

            //Trainer Bag
            uxTrainerBagSlot.SelectedIndex = 0;
            PokemonBagFill();
        }

        /// <summary>
        /// Popunjava Item box u ovisnosti o selektiranom pretincu
        /// </summary>
        private void PokemonBagFill()
        {
            int index = uxTrainerBagSlot.SelectedIndex;
            //Odredujemo slot
            switch (index)
            {
                case 0://Items
                    PokemonBagFillHelper(playerBag.Items);
                    break;
                case 1://KeyItems
                    PokemonBagFillHelper(playerBag.KeyItems);
                    break;
                case 2://PokeBalls
                    PokemonBagFillHelper(playerBag.PokeBalls);
                    break;
                case 3://TMsHMs
                    PokemonBagFillHelper(playerBag.TMsHMs);
                    break;
                case 4://Berries
                    PokemonBagFillHelper(playerBag.Berries);
                    break;
            }
        }

        private void PokemonBagFillHelper(Item[] items)
        {
            uxTrainerBagItems.Items.Clear();
            //DataTable table = new DataTable();
            //table.Columns.Add("Item Name", typeof(string));
            //table.Columns.Add("Quantity", typeof(string));
            ListViewItem li;
            //uxTrainerBagItems.BeginUpdate();
            for (int i = 0; i < items.Length; i++)
            {
                li = new ListViewItem(items[i].GetItemType.ItemName);
                //Ruby i Sapphire nemaju enkriptirano pa moramo pristupit direktno
                if (pokemonVersion == PokemonVersion.RubyAndSapphire)
                {
                    li.SubItems.Add(items[i].Quantity.ToString());
                }
                else
                {
                    li.SubItems.Add(items[i].GetQuantityDecryptedString);
                }
                uxTrainerBagItems.Items.Add(li);
                //table.Rows.Add(items[i].GetItemType.ItemName, items[i].GetQuantityDecryptedString);
            }
            //uxTrainerBagItems.EndUpdate();

            //uxTrainerBagItems.DataSource = table;
        }

        /// <summary>
        /// Sluzi za popunjavanje Pokemona u combobox
        /// </summary>
        private void StorageBoxHelper()
        {
            List<string> temp = new List<string>();
            int box = uxPokemonStorageBox.SelectedIndex;
            for (int i = 0; i < 30; i++)
            {
                temp.Add(pokemonStorage.PokemonBoxes[box,i].NicknameString);
            }
            uxPokemonStoragePokemon.DataSource = temp;
            uxPokemonStoragePokemon.SelectedIndex = 0;
        }

        /// <summary>
        /// Editiranje pokemona
        /// </summary>
        private void PokemonStorageEditHelper()
        {
            int box = uxPokemonStorageBox.SelectedIndex;
            int pokemon = uxPokemonStoragePokemon.SelectedIndex;
            PokemonEdit pe;

            if (uxPokemonStoragePokemon.Text != "Empty Slot")
            {
                pe = new PokemonEdit(pokemonStorage.PokemonBoxes[box, pokemon]);
                if (pe.ShowDialog() == DialogResult.OK)
                {
                    pokemonStorage.PokemonBoxes[box, pokemon] = pe.changedPokemon;
                    StorageBoxHelper();
                    if (pe.dexID != 0)
                    {
                        pokedex.pokedexOwn[pe.dexID - 1] = true;
                        pokedex.pokedexSeen[pe.dexID - 1] = true;
                    }
                }
                else 
                {
                    //Vracamo nepromjenjenog pokemona nazad u storage
                    pokemonStorage.PokemonBoxes[box, pokemon] = pe.originalPokemon;
                    StorageBoxHelper();
                }
                pe.Dispose();
                //Vracamo selektirani index koji je bio
                uxPokemonStoragePokemon.SelectedIndex = pokemon;
                return;
            }
            else
            {
                pe = new PokemonEdit(pokemonStorage.PokemonBoxes[box, pokemon], player);
                if (pe.ShowDialog() == DialogResult.OK)
                {
                    pokemonStorage.PokemonBoxes[box, pokemon] = pe.changedPokemon;
                    StorageBoxHelper();
                    if (pe.dexID != 0)
                    {
                        pokedex.pokedexOwn[pe.dexID - 1] = true;
                        pokedex.pokedexSeen[pe.dexID - 1] = true;
                    }
                }
                else 
                {
                    //Mora bit zbog reference
                    pokemonStorage.PokemonBoxes[box, pokemon].MakeBlankPokemonSpot();
                    StorageBoxHelper();
                }
                pe.Dispose();
                //Vracamo selektirani index koji je bio
                uxPokemonStoragePokemon.SelectedIndex = pokemon;
                return;
            }
        }

        /// <summary>
        /// Postavlja iz koje verzije pokemona je save 
        /// </summary>
        private void SetPokemonVersion()
        {
            switch (uxPokemonVersion.SelectedIndex) 
            {
                case 0:
                    this.pokemonVersion = PokemonVersion.Emerald;
                    break;
                case 1:
                    this.pokemonVersion = PokemonVersion.FireRedAndLeafGreen;
                    break;
                case 2:
                    this.pokemonVersion = PokemonVersion.RubyAndSapphire;
                    break;
                default:
                    this.pokemonVersion = PokemonVersion.Emerald;
                    break;
            }
        }

        private void uxLoad_Click(object sender, EventArgs e)
        {
            SetPokemonVersion();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select Pokemon Save File";
            ofd.Filter = "Pokemon save File|*.sav";
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            //Otvaramo dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            { 
                LoadSaveFile(ofd.FileName);
                //Popunjavamo Kontrole
                if (isReady)
                {
                    int index = ofd.FileName.LastIndexOf("\\");
                    uxPath.Text = ofd.FileName.Substring(index + 1);
                    FillControls();
                    isReadyButtons = true;
                }
            }
            ofd.Dispose();
        }

        private void uxSave_Click(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            SaveFile();
        }

        private void uxPokemonStorageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;
            StorageBoxHelper();
        }

        private void uxPokemonStorageEdit_Click(object sender, EventArgs e)
        {
            if (!isReady)
                return;
            PokemonStorageEditHelper();
        }

        private void uxPokemonStorageDelete_Click(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            if (uxPokemonStoragePokemon.Text != "Empty Slot")
            {
                int box = uxPokemonStorageBox.SelectedIndex;
                int pokemon = uxPokemonStoragePokemon.SelectedIndex;
                if (MessageBox.Show("Are you sure you want to delete : " + uxPokemonStoragePokemon.Text, "Delete Pokemon", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pokemonStorage.PokemonBoxes[box, pokemon].MakeBlankPokemonSpot();
                    StorageBoxHelper();
                }
            }
            else 
            {
                MessageBox.Show("You cannot delete Empty Slot");
            }
        }

        private void uxTrainerBagSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            PokemonBagFill();
        }

        private void uxTrainerApply_Click(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            //Player
            player.NameString = uxTrainerName.Text;
            player.TrainerID = (uint)uxTrainerID.GetNumberValue;

            //Ruby i Sapphire nemaju enkriptirano pa moramo pristupit direktno
            if (pokemonVersion == PokemonVersion.RubyAndSapphire) 
            {
                player.Money = (uint)uxTrainerMoney.GetNumberValue;
                player.Coins = (ushort)uxTrainerCoins.GetNumberValue;
            }
            else
            {
                player.MoneyEncryption = (uint)uxTrainerMoney.GetNumberValue;
                player.CoinsEncryption = (ushort)uxTrainerCoins.GetNumberValue;
            }

            player.Gender = (byte)uxTrainerGender.SelectedIndex;
            uxTrainerPublicID.Text = player.PublicTrainerID.ToString();
            uxTrainerPrivateID.Text = player.PrivateTrainerID.ToString();

            uxTrainerApply.Visible = false;
            uxTrainerCancel.Visible = false;
        }

        private void uxTrainerCancel_Click(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            //Player
            uxTrainerName.Text = player.NameString;
            uxTrainerID.Text = player.TrainerID.ToString();
            uxTrainerPublicID.Text = player.PublicTrainerID.ToString();
            uxTrainerPrivateID.Text = player.PrivateTrainerID.ToString();
            //Ruby i Sapphire nemaju enkriptirano pa moramo pristupit direktno
            if (pokemonVersion == PokemonVersion.RubyAndSapphire)
            {
                uxTrainerMoney.Text = player.Money.ToString();
                uxTrainerCoins.Text = player.Coins.ToString();
            }
            else
            {
                uxTrainerMoney.Text = player.MoneyEncryption.ToString();
                uxTrainerCoins.Text = player.CoinsEncryption.ToString();
            }

            uxTrainerGender.SelectedIndex = player.Gender;

            uxTrainerApply.Visible = false;
            uxTrainerCancel.Visible = false;
        }

        private void uxTrainerID_Leave(object sender, EventArgs e)
        {
            if (!isReady)
                return;

            long number = 0;
            if (long.TryParse(uxTrainerID.Text, out number))
            {
                if (number > uxTrainerID.NumberValueMax)
                {
                    //uxTrainerID.Text = uxTrainerID.NumberValueMax.ToString();
                    number = uxTrainerID.NumberValueMax;
                }
                else if (number < uxTrainerID.NumberValueMin)
                {
                    //uxTrainerID.Text = uxTrainerID.NumberValueMin.ToString();
                    number = uxTrainerID.NumberValueMin;
                }
            }
            else
            {
                //uxTrainerID.Text = uxTrainerID.NumberValueMin.ToString();
                number = uxTrainerID.NumberValueMin;
            }

            byte[] bytes = BitConverter.GetBytes((uint)number);
            uxTrainerPublicID.Text = BitConverter.ToUInt16(bytes, 0).ToString();
            uxTrainerPrivateID.Text = BitConverter.ToUInt16(bytes, 2).ToString();
        }

        private void uxPath_DragEnter(object sender, DragEventArgs e)
        {
            // Provjera da je zbilja file
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.All;
        }

        private void uxPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(files[0]);
            if ((fileInfo.Attributes & System.IO.FileAttributes.Directory) != System.IO.FileAttributes.Directory && fileInfo.Extension.ToLower() == ".sav")
            {
                SetPokemonVersion();
                //Ucitavamo file
                LoadSaveFile(fileInfo.FullName);
                //Popunjavamo Kontrole
                if (isReady)
                {
                    int index = fileInfo.FullName.LastIndexOf("\\");
                    uxPath.Text = fileInfo.FullName.Substring(index + 1);
                    FillControls();
                    isReadyButtons = true;
                }
                return;
            }
        }

        private void uxTrainerBagItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isReady || uxTrainerBagItems.SelectedIndices == null)
                return;

            int index = uxTrainerBagItems.SelectedIndices[0];
            Item itemToChange = new Item();
            PocketType pocket = PocketType.Items;
            string itemString;
            switch (uxTrainerBagSlot.SelectedIndex)
            {
                case 0://Items
                    itemToChange = playerBag.Items[index];
                    pocket = PocketType.Items;
                    break;
                case 1://KeyItems
                    itemToChange = playerBag.KeyItems[index];
                    pocket = PocketType.KeyItems;
                    break;
                case 2://PokeBalls
                    itemToChange = playerBag.PokeBalls[index];
                    pocket = PocketType.PokeBalls;
                    break;
                case 3://TMsHMs
                    itemToChange = playerBag.TMsHMs[index];
                    pocket = PocketType.TMsHMs;
                    break;
                case 4://Berries
                    itemToChange = playerBag.Berries[index];
                    pocket = PocketType.Berries;
                    break;
            }

            itemString = String.Format("{0:D3}", itemToChange.GetItemType.ItemID) + " " + itemToChange.GetItemType.ItemName;

            ItemEdit ite;

            //Ruby i Sapphire nemaju enkriptirano pa moramo pristupit direktno
            if (pokemonVersion == PokemonVersion.RubyAndSapphire)
            {
                ite = new ItemEdit(itemString, pocket, itemToChange.Quantity);
            }
            else 
            {
                ite = new ItemEdit(itemString, pocket, itemToChange.GetQuantityDecrypted);
            }

            if (ite.ShowDialog() == DialogResult.OK)
            {
                itemToChange.ItemType = ite.Item;
                //Ruby i Sapphire nemaju enkriptirano pa moramo pristupit direktno
                if (pokemonVersion == PokemonVersion.RubyAndSapphire)
                {
                    itemToChange.Quantity = ite.Quantity;
                }
                else
                {
                    itemToChange.SetQuantityEncrypted = ite.Quantity;
                }
                PokemonBagFill();
            }
            ite.Dispose();

        }

        private void uxTrainerName_TextChanged(object sender, EventArgs e)
        {
            if (!isReadyButtons)
                return;
            uxTrainerApply.Visible = true;
            uxTrainerCancel.Visible = true;
        }

        private void uxTrainerID_TextChanged(object sender, EventArgs e)
        {
            if (!isReadyButtons)
                return;
            uxTrainerApply.Visible = true;
            uxTrainerCancel.Visible = true;
        }

        private void uxTrainerMoney_TextChanged(object sender, EventArgs e)
        {
            if (!isReadyButtons)
                return;
            uxTrainerApply.Visible = true;
            uxTrainerCancel.Visible = true;
        }

        private void uxTrainerCoins_TextChanged(object sender, EventArgs e)
        {
            if (!isReadyButtons)
                return;
            uxTrainerApply.Visible = true;
            uxTrainerCancel.Visible = true;
        }

        private void uxTrainerGender_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isReadyButtons)
                return;
            uxTrainerApply.Visible = true;
            uxTrainerCancel.Visible = true;
        }

        private void uxPokedex_Click(object sender, EventArgs e)
        {
            if (!isReadyButtons)
                return;

            PokedexEdit pe = new PokedexEdit(pokedex);

            if (pe.ShowDialog() == DialogResult.OK)
            {
                pokedex = pe.dex;
            }
            pe.Dispose();
        }

        private void uxNationalDex_CheckedChanged(object sender, EventArgs e)
        {
            if (!isReadyButtons)
            {
                uxNationalDex.Checked = false;
                return;
            }
            //Provjera dal zaista zelimo to
            if (uxNationalDex.Checked == true)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to continue?\r\nThere's no \"Undo\" after your file is saved.", "Warning National Pokedex", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    uxNationalDex.Checked = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    uxNationalDex.Checked = false;
                }

            }
        }
    }
}
