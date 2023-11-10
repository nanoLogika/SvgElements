#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

    /// <summary>
    /// Represents a SVG <i>tspan</i> element.
    /// </summary>
    public class TspanElement : TextElementBase {

        /// <summary>
        /// Initializes a new instance of a <see cref="TspanElement"/>
        /// that represents an in-line tspan, to be placed after the
        /// preceding tspan, i.e. no location is specified.
        /// </summary>
        public TspanElement() { }


        /// <summary>
        /// Initializes a new instance of a <see cref="TspanElement"/>
        /// that represents a tspan that is to be placed on a new line.
        /// </summary>
        public TspanElement(double x, double lineHeight) {
            X = x;
            Dy = lineHeight;
        }


        /// <summary>
        /// This property is currently not used.
        /// </summary>
        public string CodePage { get; set; } = string.Empty;

        /// <summary>
        /// This property is currently not used.
        /// </summary>
        public string Alignment { get; set; } = string.Empty;

        /// <summary>
        /// This property is currently not used.
        /// </summary>
        public double Height { get; set; } = 0.0;

        /// <summary>
        /// This property is currently not used.
        /// </summary>
        public double Width { get; set; } = 0.0;

        /// <summary>
        /// This property is currently not used.
        /// </summary>
        public double SlantAngle { get; set; }


        /// <summary>
        /// Gets or sets a string to create a <i>alignment-baseline</i> attribute. It specifies
        /// how the text is aligned with respect to its parent.
        /// </summary>
        /// <value><para>
        /// A string, valid values are:
        /// </para>
        /// <para>
        /// auto | baseline | before-edge | text-before-edge | middle | central | after-edge |
        /// text-after-edge | ideographic | alphabetic | hanging | mathematical | top | center |
        /// bottom
        /// </para><para>
        /// For more information see, e.g. <see cref="https://developer.mozilla.org/en-US/docs/Web/SVG/Attribute/alignment-baseline"/>
        /// </para>
        /// </value>
        public string AlignmentBaseline { get; set; }


        /// <summary>
        /// Gets the parent element if this <see cref="TspanElement"/> was created
        /// as a child of an element.
        /// </summary>
        /// <value>
        /// A <see cref="TspanElement"/> or null when the element was not created as
        /// a child of another element.
        /// </value>
        public TspanElement? ParentElement { get; private set; }


        /// <summary>
        /// Adds a <see cref="TspanElement"/> to the list of children of this
        /// <see cref="TspanElement"/>. If a value has been specified before this
        /// value is set null.
        /// </summary>
        /// <param name="tspan"></param>
        public TspanElement AddChild(TspanElement tspan) {
            if (!string.IsNullOrEmpty(Value)) {
                Value = null;
            }
            tspan.ParentElement = this;
            Tspans.Add(tspan);
            return this;
        }


        /// <inhertdoc />
        public override XElement GetXml() {
            XElement xElement = new XElement("tspan");
            AddAttribute(xElement, "x", Cd(X.GetValueOrDefault()), X.HasValue);
            AddAttribute(xElement, "y", Cd(Y.GetValueOrDefault()), Y.HasValue);
            AddAttribute(xElement, "dx", Cd(Dx.GetValueOrDefault()), Dx.HasValue);
            AddAttribute(xElement, "dy", Cd(Dy.GetValueOrDefault()), Dy.HasValue);

            AddAttribute(xElement, "font-family", FontFamily, !string.IsNullOrEmpty(FontFamily));
            AddAttribute(xElement, "font-size", Cd(FontSize), FontSize > 0);
            AddAttribute(xElement, "font-weight", "bold", Bold);
            AddAttribute(xElement, "font-style", "italic", Italic);

            AddAttribute(xElement, "text-decoration", "underline", Underline);
            AddAttribute(xElement, "text-decoration", "line-through", Strikethrough) ;

            AddAttribute(xElement, "lengthAdjust", LengthAdjust, LengthAdjust != LengthAdjustType.None);

            if (Tspans.Count > 0) {
                foreach (TspanElement tspan in Tspans) {
                    xElement.Add(tspan);
                }
            }
            else if (!string.IsNullOrEmpty(Value)) {
                xElement.Value = Value;
            }
            else {
                xElement.Value = "&nbsp;";
            }

            return xElement;
        }


        public TspanElement Clone() {
            var cloned = new TspanElement();

            cloned.X = this.X;
            cloned.Y = this.Y;
            cloned.Dx = this.Dx;
            cloned.Dy = this.Dy;
            cloned.FontFamily = this.FontFamily;
            cloned.Bold = this.Bold;
            cloned.Italic = this.Italic;
            cloned.CodePage = string.Empty;
            cloned.Alignment = this.Alignment;
            cloned.Width = this.Width;
            cloned.SlantAngle = this.SlantAngle;
            cloned.Underline = this.Underline;
            cloned.Overstrike = this.Overstrike;
            cloned.Strikethrough = this.Strikethrough;
            cloned.Fill = this.Fill;

            return cloned;
        }
    }
}