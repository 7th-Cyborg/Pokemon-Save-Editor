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

namespace Pokemon_Save_Editor
{
     partial class PokedexEdit : Form
    {
         /// <summary>
         /// Promjenjeni dex
         /// </summary>
         public Pokedex dex { get; set; }


        public PokedexEdit(Pokedex pokedex)
        {
            InitializeComponent();

            dex = pokedex;

            DataTable table = new DataTable();
            table.Columns.Add("Seen", typeof(bool));
            table.Columns.Add("Own", typeof(bool));
            table.Columns.Add("Dex.No", typeof(string));
            table.Columns.Add("Species", typeof(string));

            int counter = 0;
            foreach (var ps in PokemonConstants.PokemonList)
            {
                if (counter == 0)//preskacemo nultog
                {
                    counter++;
                    continue;
                }

                if (counter == 387)//387 zbog onog prvog pokemona na 0
                    break;
                //Unosimo u tablicu
                table.Rows.Add(pokedex.pokedexSeen.Get(counter - 1), pokedex.pokedexOwn.Get(counter - 1), ps.Value.picID.ToString("D3"), ps.Value.Name);

                counter++;
            }

            uxPokedex.DataSource = table;
            uxPokedex.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            uxPokedex.Columns[0].Width = 50;
            uxPokedex.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            uxPokedex.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            uxPokedex.Columns[1].Width = 50;
            uxPokedex.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            uxPokedex.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            uxPokedex.Columns[2].Width = 50;
            uxPokedex.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            uxPokedex.Columns[2].ReadOnly = true;
            uxPokedex.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            uxPokedex.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            uxPokedex.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            uxPokedex.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            uxPokedex.Columns[3].ReadOnly = true;
            uxPokedex.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void uxSeenSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in uxPokedex.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void uxSeenClearAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in uxPokedex.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void uxOwnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in uxPokedex.Rows)
            {
                row.Cells[1].Value = true;
            }
        }

        private void uxOwnClearAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in uxPokedex.Rows)
            {
                row.Cells[1].Value = false;
            }
        }

        private void uxSave_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (DataGridViewRow row in uxPokedex.Rows)
            {
                dex.pokedexSeen[counter] = (bool)row.Cells[0].Value;
                dex.pokedexOwn[counter] = (bool)row.Cells[1].Value;
                counter++;
            }

            this.Close();
        }
    }
}
