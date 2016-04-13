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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_Save_Editor
{
    class PokemonTextBox:TextBox
    {
        public enum TextType
        {
            PokemonText,
            NumericOnly
        };

        /// <summary>
        /// Tip texta koji predstavlja ovaj TextBox
        /// </summary>
        public TextType TxtType { get; set; }

        /// <summary>
        /// Minimalna vrijednost koju moze sadrzavat textbox
        /// </summary>
        public long NumberValueMin { get; set; }
        /// <summary>
        /// Maximalna vrijednost koju moze sadrzavat textbox
        /// </summary>
        public long NumberValueMax { get; set; }

        /// <summary>
        /// Vraca vrijednost iz textboxa, vraca minimalnu vrijednost ako nije uspio parse
        /// </summary>
        public long GetNumberValue
        {
            get 
            {
                long number = 0;
                if (long.TryParse(this.Text, out number))
                {
                    return number;
                }
                else 
                {
                    return this.NumberValueMin;
                }
            }
        }

        public PokemonTextBox()
        {
            NumberValueMin = 0;
            NumberValueMax = 255;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            //CTRL + V
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string data = Clipboard.GetText();
                if (data != "")
                {
                    switch (TxtType)
                    {
                        case TextType.PokemonText:
                            ValidatePokemonText(data);
                            break;
                        default:
                            ValidateNumbers(data);
                            break;
                    }
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (TxtType == TextType.NumericOnly)
            {
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '-'))
                    e.Handled = true;
            }
            else if (TxtType == TextType.PokemonText)
            {
                if (!(isPokemonText(e.KeyChar) || char.IsControl(e.KeyChar)))
                    e.Handled = true;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            //if (TxtType != TextType.NumericOnly)
            //    return;

            if (TxtType == TextType.NumericOnly)
            {
                long number = 0;
                if (long.TryParse(this.Text, out number))
                {
                    if (number > NumberValueMax)
                    {
                        this.Text = NumberValueMax.ToString();
                    }
                    else if (number < NumberValueMin)
                    {
                        this.Text = NumberValueMin.ToString();
                    }
                }
                else
                {
                    this.Text = NumberValueMin.ToString();
                }
            }
            else 
            {
                if (this.Text == "")
                {
                    this.Text = " ";
                }
            }
        }

        /// <summary>
        /// Provjerava dal je PokemonText
        /// </summary>
        /// <param name="c">char za provjerit</param>
        /// <returns>true/false</returns>
        private bool isPokemonText(char c)
        {
            switch (c)
            {
                case '0': return true;
                case '1': return true;
                case '2': return true;
                case '3': return true;
                case '4': return true;
                case '5': return true;
                case '6': return true;
                case '7': return true;
                case '8': return true;
                case '9': return true;
                case 'A': return true;
                case 'B': return true;
                case 'C': return true;
                case 'D': return true;
                case 'E': return true;
                case 'F': return true;
                case 'G': return true;
                case 'H': return true;
                case 'I': return true;
                case 'J': return true;
                case 'K': return true;
                case 'L': return true;
                case 'M': return true;
                case 'N': return true;
                case 'O': return true;
                case 'P': return true;
                case 'Q': return true;
                case 'R': return true;
                case 'S': return true;
                case 'T': return true;
                case 'U': return true;
                case 'V': return true;
                case 'W': return true;
                case 'X': return true;
                case 'Y': return true;
                case 'Z': return true;
                case 'a': return true;
                case 'b': return true;
                case 'c': return true;
                case 'd': return true;
                case 'e': return true;
                case 'f': return true;
                case 'g': return true;
                case 'h': return true;
                case 'i': return true;
                case 'j': return true;
                case 'k': return true;
                case 'l': return true;
                case 'm': return true;
                case 'n': return true;
                case 'o': return true;
                case 'p': return true;
                case 'q': return true;
                case 'r': return true;
                case 's': return true;
                case 't': return true;
                case 'u': return true;
                case 'v': return true;
                case 'w': return true;
                case 'x': return true;
                case 'y': return true;
                case 'z': return true;
                case '.': return true;//Tocka
                case ',': return true;//Zarez
                case '!': return true;//Usklicnik
                case '?': return true;//Upitnik
                case '>': return true;//Znak za musko
                case '<': return true;//Znak za zensko
                case '/': return true;//Kosa crta
                case '-': return true;//Minus
                case '_': return true;//Znak za ... (tri tockice u nizu)
                case ':': return true;//Pocetni dvostruki navodnik 
                case '\"': return true;//Dvostruki navodnik "
                case ';': return true;//Pocetni jednostruki navodnik '
                case '\'': return true;//Jednostruki navodnik
                case ' ': return true;//Space (Prazno mijesto)
                default: return false;
            }
        }

        /// <summary>
        /// Validacija PokemonText-a
        /// </summary>
        /// <param name="text">text za validaciju</param>
        private void ValidatePokemonText(string text)
        {
            string tempText = "";

            foreach (char c in text)
            {
                if (isPokemonText(c))
                {
                    tempText += c;
                }
            }
            //Provjera duzine texta
            if (tempText.Length > this.MaxLength)
                tempText = tempText.Substring(0, this.MaxLength);

            this.Text = tempText;
        }
        /// <summary>
        /// Validacija Brojeva
        /// </summary>
        /// <param name="text">text za validaciju</param>
        private void ValidateNumbers(string text)
        {
            string tempText = "";

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    tempText += c;
                }
            }
            this.Text = tempText;
        }
    }
}
