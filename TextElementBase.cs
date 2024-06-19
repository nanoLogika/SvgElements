#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

    /// <summary>
    /// Base class for the classes that represent SVG text and tspan elements.
    /// </summary>
    public abstract class TextElementBase<T> : SvgElementBase<T> {

        private string _value;


        /// <summary>
        /// Defines valid values for the <see cref="LengthAdjust"/> property,
        /// i.e. values for the <i>length-adjust</i> attribute.
        /// </summary>
        public enum LengthAdjustType {
            /// <summary>No length adjust, attribute will not be assigned.</summary>
            None,
            /// <summary>Stretch using spacing only</summary>
            Spacing,
            /// <summary>Stretch using spacing and glyphs.</summary>
            SpacingAndGlyphs
        }


        /// <summary>
        /// Gets or sets the text value for this <see cref="TspanElement"/>.
        /// The list of children that were previously added is cleared.
        /// </summary>
        public string Value {
            get {
                return _value;
            }
            set {
                _value = value;
                Tspans.Clear();
            }
        }


        /// <summary>
        /// The x coordinate of the starting point of the text baseline.
        /// </summary>
        /// <value>
        /// Value type: <length>|<percentage> ; Default value: none; Animatable: yes
        /// </value>
        public double? X { get; set; }


        /// <summary>
        /// The y coordinate of the starting point of the text baseline. 
        /// </summary>
        /// <value>
        /// Value type: <length>|<percentage> ; Default value: none; Animatable: yes
        /// </value>
        public double? Y { get; set; }


        /// <summary>
        /// Shifts the text position horizontally from a previous text element.
        /// </summary>
        /// <value>
        ///  Value type: <length>|<percentage> ; Default value: none; Animatable: yes
        /// </value>
        public double? Dx { get; set; }


        /// <summary>
        /// Shifts the text vertically horizontally from a previous text element.
        /// </summary>
        /// <value>
        ///  Value type: <length>|<percentage> ; Default value: none; Animatable: yes
        /// </value>
        public double? Dy { get; set; }


        /// <summary>
        /// Rotates orientation of each individual glyph. Can rotate glyphs individually.
        /// </summary>
        /// <value>
        /// Value type: <list-of-number> ; Default value: none; Animatable: yes
        /// </value>
        public double? Rotate { get; set; }


        /// <summary>
        /// How the text is stretched or compressed to fit the width defined by the textLength attribute.
        /// </summary>
        /// <value>
        /// Value type: spacing|spacingAndGlyphs; Default value: spacing; Animatable: yes
        /// </value>
        public LengthAdjustType LengthAdjust { get; set; } = LengthAdjustType.None;


        /// <summary>
        /// Gets or set a font name for this <see cref="TspanElement"/>.
        /// If the font name is set a <i>font-family</i> attribute is created.
        /// </summary>
        public string FontFamily { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets a value indicating bold text for this <see cref="TspanElement"/>.
        /// If this property is <b>true</b> a <i>font-weight="bold"</i> attribute is created.
        /// </summary>
        public bool Bold { get; set; } = false;


        /// <summary>
        /// Gets or sets a value indicating italic text for this <see cref="TspanElement"/>.
        /// If this property is <b>true</b> a <i>font-style="italic"</i> attribute is created.
        /// </summary>
        public bool Italic { get; set; } = false;


        /// <summary>
        /// Gets or set the font size for this <see cref="TspanElement"/>.
        /// If this property is not equal to zero <i>font-size</i> attribute with the
        /// specified value is created.
        /// </summary>
        public double FontSize { get; set; }


        /// <summary>
        /// Gets or sets the value for an <i>text-anchor</i> attribute for this <see cref="TspanElement"/>.
        /// This is used is used to align a text in text direction. 
        /// </summary>
        /// <value>
        /// Valid values are: start | middle | end.
        /// </value>
        public string TextAnchor { get; set; }


        /// <summary>
        /// Gets or sets a value indicating that text is underlined in this <see cref="TspanElement"/>.
        /// If this property is <b>true</b> a <i>text-decoration="underline"</i> attribute is created.
        /// </summary>
        public bool Underline { get; set; }


        /// <summary>
        /// Gets or sets a value indicating that text is overstriked in this <see cref="TspanElement"/>.
        /// A respective <i>text-decoration</i> is not available in SVG.
        /// </summary>
        public bool Overstrike { get; set; }


        /// <summary>
        /// Gets or sets a value indicating that text is striked through in this <see cref="TspanElement"/>.
        /// If this property is <b>true</b> a <i>text-decoration="line-through"</i> attribute is created.
        /// </summary>
        public bool Strikethrough { get; set; }


        /// <summary>
        /// A width that the text should be scaled to fit.
        /// </summary>
        /// <value>
        /// Value type: <length>|<percentage> ; Default value: none; Animatable: yes
        /// </value>
        public double? TextLength { get; set; }


        /// <summary>
        /// Gets the list of child tspans of this <see cref="TspanElement"/>.
        /// </summary>
        /// <value>
        /// A IList of <see cref="TspanElement"/> objects.
        /// </value>
        public List<TspanElement> Tspans { get; } = new List<TspanElement>();


        /// <summary>
        /// Adds <i>tspan</i> elements or text value.
        /// </summary>
        /// <param name="xElement"></param>
        protected void AddTextContent(XElement xElement) {
            if (Tspans.Count > 0) {
                foreach (TspanElement tspan in Tspans) {
                    xElement.Add(tspan.GetXml());
                }
            }
            else if (!string.IsNullOrEmpty(Value)) {
                xElement.Value = Value;
            }
            else {
                xElement.Add(new XAttribute("visibility", "hidden"));
                xElement.Value = ".";
            }
        }
    }
}
