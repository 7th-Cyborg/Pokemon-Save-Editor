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
namespace Pokemon_Save_Editor
{
    partial class PokemonSavegameEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PokemonSavegameEditor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uxTrainerCancel = new System.Windows.Forms.Button();
            this.uxTrainerApply = new System.Windows.Forms.Button();
            this.uxTrainerGender = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxTrainerCoins = new Pokemon_Save_Editor.PokemonTextBox();
            this.uxTrainerMoney = new Pokemon_Save_Editor.PokemonTextBox();
            this.uxTrainerPrivateID = new Pokemon_Save_Editor.PokemonTextBox();
            this.uxTrainerPublicID = new Pokemon_Save_Editor.PokemonTextBox();
            this.uxTrainerID = new Pokemon_Save_Editor.PokemonTextBox();
            this.uxTrainerName = new Pokemon_Save_Editor.PokemonTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uxTrainerBagItems = new Pokemon_Save_Editor.ListViewNF();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxTrainerBagSlot = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.uxPokemonStorageDelete = new System.Windows.Forms.Button();
            this.uxPokemonStorageEdit = new System.Windows.Forms.Button();
            this.uxPokemonStoragePokemon = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uxPokemonStorageBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.uxPokedex = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.uxPokemonVersion = new System.Windows.Forms.ComboBox();
            this.uxPath = new System.Windows.Forms.TextBox();
            this.uxSave = new System.Windows.Forms.Button();
            this.uxLoad = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.uxNationalDex = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uxTrainerCancel);
            this.groupBox1.Controls.Add(this.uxTrainerApply);
            this.groupBox1.Controls.Add(this.uxTrainerGender);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.uxTrainerCoins);
            this.groupBox1.Controls.Add(this.uxTrainerMoney);
            this.groupBox1.Controls.Add(this.uxTrainerPrivateID);
            this.groupBox1.Controls.Add(this.uxTrainerPublicID);
            this.groupBox1.Controls.Add(this.uxTrainerID);
            this.groupBox1.Controls.Add(this.uxTrainerName);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trainer";
            // 
            // uxTrainerCancel
            // 
            this.uxTrainerCancel.Location = new System.Drawing.Point(144, 225);
            this.uxTrainerCancel.Name = "uxTrainerCancel";
            this.uxTrainerCancel.Size = new System.Drawing.Size(75, 23);
            this.uxTrainerCancel.TabIndex = 3;
            this.uxTrainerCancel.TabStop = false;
            this.uxTrainerCancel.Text = "Cancel";
            this.uxTrainerCancel.UseVisualStyleBackColor = true;
            this.uxTrainerCancel.Visible = false;
            this.uxTrainerCancel.Click += new System.EventHandler(this.uxTrainerCancel_Click);
            // 
            // uxTrainerApply
            // 
            this.uxTrainerApply.Location = new System.Drawing.Point(63, 225);
            this.uxTrainerApply.Name = "uxTrainerApply";
            this.uxTrainerApply.Size = new System.Drawing.Size(75, 23);
            this.uxTrainerApply.TabIndex = 3;
            this.uxTrainerApply.TabStop = false;
            this.uxTrainerApply.Text = "Apply";
            this.uxTrainerApply.UseVisualStyleBackColor = true;
            this.uxTrainerApply.Visible = false;
            this.uxTrainerApply.Click += new System.EventHandler(this.uxTrainerApply_Click);
            // 
            // uxTrainerGender
            // 
            this.uxTrainerGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxTrainerGender.FormattingEnabled = true;
            this.uxTrainerGender.Items.AddRange(new object[] {
            "Boy",
            "Girl"});
            this.uxTrainerGender.Location = new System.Drawing.Point(81, 184);
            this.uxTrainerGender.Name = "uxTrainerGender";
            this.uxTrainerGender.Size = new System.Drawing.Size(175, 21);
            this.uxTrainerGender.TabIndex = 2;
            this.uxTrainerGender.TabStop = false;
            this.uxTrainerGender.SelectedValueChanged += new System.EventHandler(this.uxTrainerGender_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Gender :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Coins :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Money :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Private ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Public ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name :";
            // 
            // uxTrainerCoins
            // 
            this.uxTrainerCoins.Location = new System.Drawing.Point(81, 158);
            this.uxTrainerCoins.MaxLength = 8;
            this.uxTrainerCoins.Name = "uxTrainerCoins";
            this.uxTrainerCoins.NumberValueMax = ((long)(9999));
            this.uxTrainerCoins.NumberValueMin = ((long)(0));
            this.uxTrainerCoins.Size = new System.Drawing.Size(175, 20);
            this.uxTrainerCoins.TabIndex = 6;
            this.uxTrainerCoins.TabStop = false;
            this.uxTrainerCoins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxTrainerCoins.TxtType = Pokemon_Save_Editor.PokemonTextBox.TextType.NumericOnly;
            this.uxTrainerCoins.TextChanged += new System.EventHandler(this.uxTrainerCoins_TextChanged);
            // 
            // uxTrainerMoney
            // 
            this.uxTrainerMoney.Location = new System.Drawing.Point(81, 132);
            this.uxTrainerMoney.MaxLength = 8;
            this.uxTrainerMoney.Name = "uxTrainerMoney";
            this.uxTrainerMoney.NumberValueMax = ((long)(999999));
            this.uxTrainerMoney.NumberValueMin = ((long)(0));
            this.uxTrainerMoney.Size = new System.Drawing.Size(175, 20);
            this.uxTrainerMoney.TabIndex = 5;
            this.uxTrainerMoney.TabStop = false;
            this.uxTrainerMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxTrainerMoney.TxtType = Pokemon_Save_Editor.PokemonTextBox.TextType.NumericOnly;
            this.uxTrainerMoney.TextChanged += new System.EventHandler(this.uxTrainerMoney_TextChanged);
            // 
            // uxTrainerPrivateID
            // 
            this.uxTrainerPrivateID.Location = new System.Drawing.Point(81, 106);
            this.uxTrainerPrivateID.MaxLength = 12;
            this.uxTrainerPrivateID.Name = "uxTrainerPrivateID";
            this.uxTrainerPrivateID.NumberValueMax = ((long)(65535));
            this.uxTrainerPrivateID.NumberValueMin = ((long)(0));
            this.uxTrainerPrivateID.ReadOnly = true;
            this.uxTrainerPrivateID.Size = new System.Drawing.Size(175, 20);
            this.uxTrainerPrivateID.TabIndex = 4;
            this.uxTrainerPrivateID.TabStop = false;
            this.uxTrainerPrivateID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxTrainerPrivateID.TxtType = Pokemon_Save_Editor.PokemonTextBox.TextType.NumericOnly;
            // 
            // uxTrainerPublicID
            // 
            this.uxTrainerPublicID.Location = new System.Drawing.Point(81, 80);
            this.uxTrainerPublicID.MaxLength = 12;
            this.uxTrainerPublicID.Name = "uxTrainerPublicID";
            this.uxTrainerPublicID.NumberValueMax = ((long)(65535));
            this.uxTrainerPublicID.NumberValueMin = ((long)(0));
            this.uxTrainerPublicID.ReadOnly = true;
            this.uxTrainerPublicID.Size = new System.Drawing.Size(175, 20);
            this.uxTrainerPublicID.TabIndex = 3;
            this.uxTrainerPublicID.TabStop = false;
            this.uxTrainerPublicID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxTrainerPublicID.TxtType = Pokemon_Save_Editor.PokemonTextBox.TextType.NumericOnly;
            // 
            // uxTrainerID
            // 
            this.uxTrainerID.Location = new System.Drawing.Point(81, 54);
            this.uxTrainerID.MaxLength = 12;
            this.uxTrainerID.Name = "uxTrainerID";
            this.uxTrainerID.NumberValueMax = ((long)(4294967295));
            this.uxTrainerID.NumberValueMin = ((long)(0));
            this.uxTrainerID.Size = new System.Drawing.Size(175, 20);
            this.uxTrainerID.TabIndex = 2;
            this.uxTrainerID.TabStop = false;
            this.uxTrainerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxTrainerID.TxtType = Pokemon_Save_Editor.PokemonTextBox.TextType.NumericOnly;
            this.uxTrainerID.TextChanged += new System.EventHandler(this.uxTrainerID_TextChanged);
            this.uxTrainerID.Leave += new System.EventHandler(this.uxTrainerID_Leave);
            // 
            // uxTrainerName
            // 
            this.uxTrainerName.Location = new System.Drawing.Point(81, 28);
            this.uxTrainerName.MaxLength = 7;
            this.uxTrainerName.Name = "uxTrainerName";
            this.uxTrainerName.NumberValueMax = ((long)(255));
            this.uxTrainerName.NumberValueMin = ((long)(0));
            this.uxTrainerName.Size = new System.Drawing.Size(175, 20);
            this.uxTrainerName.TabIndex = 1;
            this.uxTrainerName.TabStop = false;
            this.uxTrainerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxTrainerName.TxtType = Pokemon_Save_Editor.PokemonTextBox.TextType.PokemonText;
            this.uxTrainerName.TextChanged += new System.EventHandler(this.uxTrainerName_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uxTrainerBagItems);
            this.groupBox2.Controls.Add(this.uxTrainerBagSlot);
            this.groupBox2.Location = new System.Drawing.Point(303, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 335);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trainer Bag";
            // 
            // uxTrainerBagItems
            // 
            this.uxTrainerBagItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.uxTrainerBagItems.FullRowSelect = true;
            this.uxTrainerBagItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.uxTrainerBagItems.Location = new System.Drawing.Point(14, 57);
            this.uxTrainerBagItems.MultiSelect = false;
            this.uxTrainerBagItems.Name = "uxTrainerBagItems";
            this.uxTrainerBagItems.Size = new System.Drawing.Size(276, 262);
            this.uxTrainerBagItems.TabIndex = 4;
            this.uxTrainerBagItems.TabStop = false;
            this.uxTrainerBagItems.UseCompatibleStateImageBehavior = false;
            this.uxTrainerBagItems.View = System.Windows.Forms.View.Details;
            this.uxTrainerBagItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.uxTrainerBagItems_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Names";
            this.columnHeader1.Width = 176;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // uxTrainerBagSlot
            // 
            this.uxTrainerBagSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxTrainerBagSlot.FormattingEnabled = true;
            this.uxTrainerBagSlot.Items.AddRange(new object[] {
            "Items",
            "KeyItems",
            "PokeBalls",
            "TMsHMs",
            "Berries"});
            this.uxTrainerBagSlot.Location = new System.Drawing.Point(65, 24);
            this.uxTrainerBagSlot.Name = "uxTrainerBagSlot";
            this.uxTrainerBagSlot.Size = new System.Drawing.Size(175, 21);
            this.uxTrainerBagSlot.TabIndex = 2;
            this.uxTrainerBagSlot.TabStop = false;
            this.uxTrainerBagSlot.SelectedIndexChanged += new System.EventHandler(this.uxTrainerBagSlot_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.uxPokemonStorageDelete);
            this.groupBox3.Controls.Add(this.uxPokemonStorageEdit);
            this.groupBox3.Controls.Add(this.uxPokemonStoragePokemon);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.uxPokemonStorageBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 350);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 130);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pokemon Storage";
            // 
            // uxPokemonStorageDelete
            // 
            this.uxPokemonStorageDelete.Location = new System.Drawing.Point(144, 91);
            this.uxPokemonStorageDelete.Name = "uxPokemonStorageDelete";
            this.uxPokemonStorageDelete.Size = new System.Drawing.Size(75, 23);
            this.uxPokemonStorageDelete.TabIndex = 3;
            this.uxPokemonStorageDelete.TabStop = false;
            this.uxPokemonStorageDelete.Text = "Delete";
            this.uxPokemonStorageDelete.UseVisualStyleBackColor = true;
            this.uxPokemonStorageDelete.Click += new System.EventHandler(this.uxPokemonStorageDelete_Click);
            // 
            // uxPokemonStorageEdit
            // 
            this.uxPokemonStorageEdit.Location = new System.Drawing.Point(63, 91);
            this.uxPokemonStorageEdit.Name = "uxPokemonStorageEdit";
            this.uxPokemonStorageEdit.Size = new System.Drawing.Size(75, 23);
            this.uxPokemonStorageEdit.TabIndex = 3;
            this.uxPokemonStorageEdit.TabStop = false;
            this.uxPokemonStorageEdit.Text = "Edit";
            this.uxPokemonStorageEdit.UseVisualStyleBackColor = true;
            this.uxPokemonStorageEdit.Click += new System.EventHandler(this.uxPokemonStorageEdit_Click);
            // 
            // uxPokemonStoragePokemon
            // 
            this.uxPokemonStoragePokemon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxPokemonStoragePokemon.FormattingEnabled = true;
            this.uxPokemonStoragePokemon.Location = new System.Drawing.Point(81, 55);
            this.uxPokemonStoragePokemon.Name = "uxPokemonStoragePokemon";
            this.uxPokemonStoragePokemon.Size = new System.Drawing.Size(175, 21);
            this.uxPokemonStoragePokemon.TabIndex = 2;
            this.uxPokemonStoragePokemon.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Pokemon :";
            // 
            // uxPokemonStorageBox
            // 
            this.uxPokemonStorageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxPokemonStorageBox.FormattingEnabled = true;
            this.uxPokemonStorageBox.Location = new System.Drawing.Point(81, 28);
            this.uxPokemonStorageBox.Name = "uxPokemonStorageBox";
            this.uxPokemonStorageBox.Size = new System.Drawing.Size(175, 21);
            this.uxPokemonStorageBox.TabIndex = 2;
            this.uxPokemonStorageBox.TabStop = false;
            this.uxPokemonStorageBox.SelectedIndexChanged += new System.EventHandler(this.uxPokemonStorageBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Box :";
            // 
            // uxPokedex
            // 
            this.uxPokedex.Location = new System.Drawing.Point(14, 20);
            this.uxPokedex.Name = "uxPokedex";
            this.uxPokedex.Size = new System.Drawing.Size(75, 23);
            this.uxPokedex.TabIndex = 7;
            this.uxPokedex.Text = "Pokedex";
            this.uxPokedex.UseVisualStyleBackColor = true;
            this.uxPokedex.Click += new System.EventHandler(this.uxPokedex_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.uxPokemonVersion);
            this.groupBox4.Controls.Add(this.uxPath);
            this.groupBox4.Controls.Add(this.uxSave);
            this.groupBox4.Controls.Add(this.uxLoad);
            this.groupBox4.Location = new System.Drawing.Point(12, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(597, 56);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Load/Save";
            // 
            // uxPokemonVersion
            // 
            this.uxPokemonVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxPokemonVersion.FormattingEnabled = true;
            this.uxPokemonVersion.Items.AddRange(new object[] {
            "Emerald",
            "FireRed and LeafGreen",
            "Ruby and Sapphire"});
            this.uxPokemonVersion.Location = new System.Drawing.Point(16, 22);
            this.uxPokemonVersion.Name = "uxPokemonVersion";
            this.uxPokemonVersion.Size = new System.Drawing.Size(160, 21);
            this.uxPokemonVersion.TabIndex = 4;
            this.uxPokemonVersion.TabStop = false;
            // 
            // uxPath
            // 
            this.uxPath.AllowDrop = true;
            this.uxPath.Location = new System.Drawing.Point(182, 23);
            this.uxPath.Name = "uxPath";
            this.uxPath.Size = new System.Drawing.Size(237, 20);
            this.uxPath.TabIndex = 0;
            this.uxPath.TabStop = false;
            this.uxPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.uxPath_DragDrop);
            this.uxPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.uxPath_DragEnter);
            // 
            // uxSave
            // 
            this.uxSave.Location = new System.Drawing.Point(506, 21);
            this.uxSave.Name = "uxSave";
            this.uxSave.Size = new System.Drawing.Size(75, 23);
            this.uxSave.TabIndex = 3;
            this.uxSave.TabStop = false;
            this.uxSave.Text = "Save";
            this.uxSave.UseVisualStyleBackColor = true;
            this.uxSave.Click += new System.EventHandler(this.uxSave_Click);
            // 
            // uxLoad
            // 
            this.uxLoad.Location = new System.Drawing.Point(425, 21);
            this.uxLoad.Name = "uxLoad";
            this.uxLoad.Size = new System.Drawing.Size(75, 23);
            this.uxLoad.TabIndex = 3;
            this.uxLoad.TabStop = false;
            this.uxLoad.Text = "Load";
            this.uxLoad.UseVisualStyleBackColor = true;
            this.uxLoad.Click += new System.EventHandler(this.uxLoad_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.uxNationalDex);
            this.groupBox5.Controls.Add(this.uxPokedex);
            this.groupBox5.Location = new System.Drawing.Point(303, 421);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(306, 59);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pokedex";
            // 
            // uxNationalDex
            // 
            this.uxNationalDex.AutoSize = true;
            this.uxNationalDex.Location = new System.Drawing.Point(128, 24);
            this.uxNationalDex.Name = "uxNationalDex";
            this.uxNationalDex.Size = new System.Drawing.Size(135, 17);
            this.uxNationalDex.TabIndex = 8;
            this.uxNationalDex.Text = "Give National Pokedex";
            this.uxNationalDex.UseVisualStyleBackColor = true;
            this.uxNationalDex.CheckedChanged += new System.EventHandler(this.uxNationalDex_CheckedChanged);
            // 
            // PokemonSavegameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 493);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PokemonSavegameEditor";
            this.Text = "Pokemon Save Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PokemonTextBox uxTrainerName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private PokemonTextBox uxTrainerPrivateID;
        private PokemonTextBox uxTrainerPublicID;
        private PokemonTextBox uxTrainerID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private PokemonTextBox uxTrainerCoins;
        private PokemonTextBox uxTrainerMoney;
        private System.Windows.Forms.ComboBox uxTrainerGender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button uxTrainerCancel;
        private System.Windows.Forms.Button uxTrainerApply;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox uxPokemonStorageBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox uxPokemonStoragePokemon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox uxTrainerBagSlot;
        private System.Windows.Forms.Button uxPokemonStorageDelete;
        private System.Windows.Forms.Button uxPokemonStorageEdit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox uxPath;
        private System.Windows.Forms.Button uxSave;
        private System.Windows.Forms.Button uxLoad;
        private ListViewNF uxTrainerBagItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox uxPokemonVersion;
        private System.Windows.Forms.Button uxPokedex;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox uxNationalDex;

    }
}

