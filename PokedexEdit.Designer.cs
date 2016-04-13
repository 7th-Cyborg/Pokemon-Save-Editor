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
    partial class PokedexEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PokedexEdit));
            this.uxPokedex = new System.Windows.Forms.DataGridView();
            this.uxSave = new System.Windows.Forms.Button();
            this.uxCancel = new System.Windows.Forms.Button();
            this.uxSeenSelectAll = new System.Windows.Forms.Button();
            this.uxSeenClearAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxOwnSelectAll = new System.Windows.Forms.Button();
            this.uxOwnClearAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxPokedex)).BeginInit();
            this.SuspendLayout();
            // 
            // uxPokedex
            // 
            this.uxPokedex.AllowUserToAddRows = false;
            this.uxPokedex.AllowUserToDeleteRows = false;
            this.uxPokedex.AllowUserToResizeColumns = false;
            this.uxPokedex.AllowUserToResizeRows = false;
            this.uxPokedex.BackgroundColor = System.Drawing.SystemColors.Window;
            this.uxPokedex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.uxPokedex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxPokedex.Location = new System.Drawing.Point(12, 12);
            this.uxPokedex.MultiSelect = false;
            this.uxPokedex.Name = "uxPokedex";
            this.uxPokedex.RowHeadersVisible = false;
            this.uxPokedex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uxPokedex.Size = new System.Drawing.Size(443, 305);
            this.uxPokedex.TabIndex = 0;
            this.uxPokedex.TabStop = false;
            // 
            // uxSave
            // 
            this.uxSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxSave.Location = new System.Drawing.Point(155, 374);
            this.uxSave.Name = "uxSave";
            this.uxSave.Size = new System.Drawing.Size(75, 23);
            this.uxSave.TabIndex = 1;
            this.uxSave.TabStop = false;
            this.uxSave.Text = "Confirm";
            this.uxSave.UseVisualStyleBackColor = true;
            this.uxSave.Click += new System.EventHandler(this.uxSave_Click);
            // 
            // uxCancel
            // 
            this.uxCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCancel.Location = new System.Drawing.Point(236, 374);
            this.uxCancel.Name = "uxCancel";
            this.uxCancel.Size = new System.Drawing.Size(75, 23);
            this.uxCancel.TabIndex = 2;
            this.uxCancel.TabStop = false;
            this.uxCancel.Text = "Cancel";
            this.uxCancel.UseVisualStyleBackColor = true;
            // 
            // uxSeenSelectAll
            // 
            this.uxSeenSelectAll.Location = new System.Drawing.Point(49, 333);
            this.uxSeenSelectAll.Name = "uxSeenSelectAll";
            this.uxSeenSelectAll.Size = new System.Drawing.Size(75, 23);
            this.uxSeenSelectAll.TabIndex = 3;
            this.uxSeenSelectAll.Text = "Select All";
            this.uxSeenSelectAll.UseVisualStyleBackColor = true;
            this.uxSeenSelectAll.Click += new System.EventHandler(this.uxSeenSelectAll_Click);
            // 
            // uxSeenClearAll
            // 
            this.uxSeenClearAll.Location = new System.Drawing.Point(130, 333);
            this.uxSeenClearAll.Name = "uxSeenClearAll";
            this.uxSeenClearAll.Size = new System.Drawing.Size(75, 23);
            this.uxSeenClearAll.TabIndex = 3;
            this.uxSeenClearAll.Text = "Clear All";
            this.uxSeenClearAll.UseVisualStyleBackColor = true;
            this.uxSeenClearAll.Click += new System.EventHandler(this.uxSeenClearAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Own :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seen :";
            // 
            // uxOwnSelectAll
            // 
            this.uxOwnSelectAll.Location = new System.Drawing.Point(299, 333);
            this.uxOwnSelectAll.Name = "uxOwnSelectAll";
            this.uxOwnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.uxOwnSelectAll.TabIndex = 3;
            this.uxOwnSelectAll.Text = "Select All";
            this.uxOwnSelectAll.UseVisualStyleBackColor = true;
            this.uxOwnSelectAll.Click += new System.EventHandler(this.uxOwnSelectAll_Click);
            // 
            // uxOwnClearAll
            // 
            this.uxOwnClearAll.Location = new System.Drawing.Point(380, 333);
            this.uxOwnClearAll.Name = "uxOwnClearAll";
            this.uxOwnClearAll.Size = new System.Drawing.Size(75, 23);
            this.uxOwnClearAll.TabIndex = 3;
            this.uxOwnClearAll.Text = "Clear All";
            this.uxOwnClearAll.UseVisualStyleBackColor = true;
            this.uxOwnClearAll.Click += new System.EventHandler(this.uxOwnClearAll_Click);
            // 
            // PokedexEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxOwnClearAll);
            this.Controls.Add(this.uxOwnSelectAll);
            this.Controls.Add(this.uxSeenClearAll);
            this.Controls.Add(this.uxSeenSelectAll);
            this.Controls.Add(this.uxCancel);
            this.Controls.Add(this.uxSave);
            this.Controls.Add(this.uxPokedex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PokedexEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pokedex";
            ((System.ComponentModel.ISupportInitialize)(this.uxPokedex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView uxPokedex;
        private System.Windows.Forms.Button uxSave;
        private System.Windows.Forms.Button uxCancel;
        private System.Windows.Forms.Button uxSeenSelectAll;
        private System.Windows.Forms.Button uxSeenClearAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uxOwnSelectAll;
        private System.Windows.Forms.Button uxOwnClearAll;
    }
}