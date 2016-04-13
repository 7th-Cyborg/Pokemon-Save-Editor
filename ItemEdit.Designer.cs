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
    partial class ItemEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEdit));
            this.uxOK = new System.Windows.Forms.Button();
            this.uxCancel = new System.Windows.Forms.Button();
            this.uxItems = new System.Windows.Forms.ComboBox();
            this.uxDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uxQuantity = new Pokemon_Save_Editor.PokemonTextBox();
            this.SuspendLayout();
            // 
            // uxOK
            // 
            this.uxOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxOK.Location = new System.Drawing.Point(99, 192);
            this.uxOK.Name = "uxOK";
            this.uxOK.Size = new System.Drawing.Size(75, 23);
            this.uxOK.TabIndex = 0;
            this.uxOK.Text = "OK";
            this.uxOK.UseVisualStyleBackColor = true;
            this.uxOK.Click += new System.EventHandler(this.uxOK_Click);
            // 
            // uxCancel
            // 
            this.uxCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCancel.Location = new System.Drawing.Point(180, 192);
            this.uxCancel.Name = "uxCancel";
            this.uxCancel.Size = new System.Drawing.Size(75, 23);
            this.uxCancel.TabIndex = 0;
            this.uxCancel.Text = "Cancel";
            this.uxCancel.UseVisualStyleBackColor = true;
            // 
            // uxItems
            // 
            this.uxItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxItems.FormattingEnabled = true;
            this.uxItems.Location = new System.Drawing.Point(117, 24);
            this.uxItems.Name = "uxItems";
            this.uxItems.Size = new System.Drawing.Size(184, 21);
            this.uxItems.TabIndex = 1;
            this.uxItems.SelectedIndexChanged += new System.EventHandler(this.uxItems_SelectedIndexChanged);
            // 
            // uxDesc
            // 
            this.uxDesc.Location = new System.Drawing.Point(54, 119);
            this.uxDesc.Name = "uxDesc";
            this.uxDesc.Size = new System.Drawing.Size(247, 52);
            this.uxDesc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Description :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantity :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Item Type :";
            // 
            // uxQuantity
            // 
            this.uxQuantity.Location = new System.Drawing.Point(117, 60);
            this.uxQuantity.Name = "uxQuantity";
            this.uxQuantity.NumberValueMax = ((long)(255));
            this.uxQuantity.NumberValueMin = ((long)(0));
            this.uxQuantity.Size = new System.Drawing.Size(184, 20);
            this.uxQuantity.TabIndex = 4;
            this.uxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxQuantity.TxtType = Pokemon_Save_Editor.PokemonTextBox.TextType.NumericOnly;
            // 
            // ItemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 229);
            this.Controls.Add(this.uxQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxDesc);
            this.Controls.Add(this.uxItems);
            this.Controls.Add(this.uxCancel);
            this.Controls.Add(this.uxOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxOK;
        private System.Windows.Forms.Button uxCancel;
        private System.Windows.Forms.ComboBox uxItems;
        private System.Windows.Forms.Label uxDesc;
        private System.Windows.Forms.Label label1;
        private PokemonTextBox uxQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}