#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

	/// <summary>
	/// Represents a SVG <i>text</i> element. 
	/// </summary>
	public class TextElement : TextElementBase {

		private string _requestedAlignmentBaseline = string.Empty;

		/// <summary>
		/// Initializes a new instance of a <see cref="TextElement"/>.
		/// The stroke property is set to "none" by default.
		/// </summary>
		public TextElement() : base() {
			Stroke = "none";
		}


		/// <summary>
		/// Sets values for the <i>x</i> and <i>y</i> attributes
		/// and returns this element.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>This <see cref="TextElement"/>.</returns>
		public TextElement WithXY(double x, double y) {
			X = x;
			Y = y;
			return this;
		}


		/// <summary>
		/// Sets the values for the attributes <i>font-family</i>, <i>font-size</i>,
		/// <i>font-weight</i>, and <i>font-style</i> attributes.
		/// and returns this element.
		/// </summary>
		/// <param name="fontFamily">The name of the font family or empty if the
		/// <i>font-family</i> attribute is not to be set.</param>
		/// <param name="fontSize">The font size zero if the
		/// <i>font-size</i> attribute is not to be set.</param>
		/// <param name="bold"><b>true</b> if the <i>font-weight="bold"</i> attribute
		/// is to be set; otherwise, <b>false</b>.</param>
		/// <param name="italic"><b>true</b> if the <i>font-style="italic"</i> attribute
		/// is to be set; otherwise, <b>false</b>.</param>
		/// <returns>This <see cref="TextElement"/>.</returns>
		public TextElement WithFont(string fontFamily, double fontSize, bool bold, bool italic) {
			FontFamily = fontFamily;
			FontSize = fontSize;
			Bold = bold;
			Italic = italic;
			return this;
		}


		/// <summary>
		/// Sets the value for the <i>alignment-baseline</i> attribute
		/// and returns this element.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The SVG <i>text</i> element does not support the <i>alignment-baseline</i> attribute
		/// specifying the attribute forces inserting a <i>tspan</i> element.
		/// </para>
		/// </remarks>
		/// <param name="alignmentBaseline"></param>
		/// <returns>This <see cref="TextElement"/>.</returns>
		public TextElement WithAlignmentBaseline(string alignmentBaseline) {
			_requestedAlignmentBaseline = alignmentBaseline;
			return this;
		}


		/// <summary>
		/// Sets the value for the <i>text-anchor</i> attribute
		/// and returns this element.
		/// </summary>
		/// <param name="textAnchor"></param>
		/// <returns>This <see cref="TextElement"/>.</returns>
		public TextElement WithTextAnchor(string textAnchor) {
			TextAnchor = textAnchor;
			return this;
		}


		/// <summary>
		/// Adds a list of <see cref="TspanElement"/> object to the
		/// <see cref="TextElementBase.Tspans"/> list property
		/// and returns this element.
		/// </summary>
		/// <param name="tspans"></param>
		/// <returns>This <see cref="TextElement"/>.</returns>
		public TextElement WithTspans(IList<TspanElement> tspans) {
			if (tspans != null) {
				Tspans.AddRange(tspans);
            }
			return this;
		}


		/// <summary>
		/// Sets the value for the SVG <i>text</i> element
		/// and returns this element.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>This <see cref="TextElement"/>.</returns>
		public TextElement WithValue(string value) {
			Value = value;
			return this;
		}


		/// <inheritdoc />
		public override XElement GetXml() {
			XElement xElement = new XElement("text");
			AddID(xElement);
			AddClass(xElement);
			AddTransform(xElement);
			//	Position is needed only if we do not have tspan elements
			if (!string.IsNullOrEmpty(Value)) {
				xElement.Add(new XAttribute("x", Cd(X.GetValueOrDefault())));
				xElement.Add(new XAttribute("y", Cd(-Y.GetValueOrDefault())));
			}
			//	If an alignment-baseline attribute is requested
			//	A tspan element is needed to be placed inside this text element.
			//	The Value is cleared automatically.
			if (!string.IsNullOrEmpty(_requestedAlignmentBaseline)) {
				TspanElement dummyTspan = new TspanElement() {
					AlignmentBaseline = _requestedAlignmentBaseline,
					Value = this.Value
				};
				Tspans.Add(dummyTspan);
			}
			AddStroke(xElement);
			AddStrokeDashArray(xElement);
			AddFill(xElement);
            //	AddAttribute(xElement, "alignment-baseline", AlignmentBaseline, !string.IsNullOrEmpty(AlignmentBaseline));
            AddAttribute(xElement, "text-anchor", TextAnchor, !string.IsNullOrEmpty(TextAnchor));
            AddAttribute(xElement, "font-family", FontFamily, !string.IsNullOrEmpty(FontFamily));
            AddAttribute(xElement, "font-size", Cd(FontSize), FontSize > 0);
            AddAttribute(xElement, "font-weight", "bold", Bold);
            AddAttribute(xElement, "font-style", "italic", Italic);

			AddAttribute(xElement, "text-decoration", "underline", Underline);
			AddAttribute(xElement, "text-decoration", "line-through", Strikethrough);

			AddTextContent(xElement);

			return xElement;
		}
	}
}
