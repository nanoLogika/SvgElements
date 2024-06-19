#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Text;
using System.Xml.Linq;


namespace SvgElements {

    /// <summary>
    /// Represents the <i>svg</i> Element.
    /// </summary>
    public class SvgElement : SvgElementBase<SvgElement> {

        /// <summary>
        /// Gets or sets the min-x value for the <i>viewbox</i> attribute.
        /// This value is optional; to enable the <i>viewbox</i> attribute the
        /// properties <see cref="ViewboxMinX"/>, <see cref="ViewboxMinY"/>
        /// <see cref="ViewboxWidth"/>, and <see cref="ViewboxHeight"/> must
        /// be set.
        /// </summary>
        public double? ViewboxMinX { get; set; }


        /// <summary>
        /// Gets or sets the min-y value for the <i>viewbox</i> attribute.
        /// This value is optional; to enable the <i>viewbox</i> attribute the
        /// properties <see cref="ViewboxMinX"/>, <see cref="ViewboxMinY"/>
        /// <see cref="ViewboxWidth"/>, and <see cref="ViewboxHeight"/> must
        /// be set.
        /// </summary>
        public double? ViewboxMinY { get; set; }


        /// <summary>
        /// Gets or sets the width value for the <i>viewbox</i> attribute.
        /// This value is optional; to enable the <i>viewbox</i> attribute the
        /// properties <see cref="ViewboxMinX"/>, <see cref="ViewboxMinY"/>
        /// <see cref="ViewboxWidth"/>, and <see cref="ViewboxHeight"/> must
        /// be set.
        /// </summary>
        public double? ViewboxWidth { get; set; }


        /// <summary>
        /// Gets or sets the height value for the <i>viewbox</i> attribute.
        /// This value is optional; to enable the <i>viewbox</i> attribute the
        /// properties <see cref="ViewboxMinX"/>, <see cref="ViewboxMinY"/>
        /// <see cref="ViewboxWidth"/>, and <see cref="ViewboxHeight"/> must
        /// be set.
        /// </summary>
        public double? ViewboxHeight { get; set; }


        /// <summary>
        /// Gets or sets the width value for SVG element.
        /// </summary>
        public string Width { get; set; }


        /// <summary>
        /// Gets or sets the height value for SVG element.
        /// </summary>
        public string Height { get; set; }


        /// <summary>
        /// Gets or sets a value for the <i>style</i> attribute.
        /// </summary>
        public string Style { get; set; } = "width:100%;height:100%;position:fixed;";
        
        
        /// <summary>
        /// Gets or sets the value for the <i>xmlns</i> attribute.
        /// Default is "http://www.w3.org/2000/svg".
        /// </summary>
        public string Xmlns { get; set; } = "http://www.w3.org/2000/svg";


        /// <summary>
        /// Gets or sets the value for the <i>version</i> attribute.
        /// Default is "1.1".
        /// </summary>
        public string Version { get; set; } = "1.1";


        /// <summary>
        /// Sets the values <i>min-x</i>, <i>min-y</i>, <i>width</i>, and <i>height</i> for
        /// the <i>viewbox</i> attribute
        /// and returns this <see cref="SvgElement"/>.
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="minY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>This <see cref="SvgElement"/>.</returns>
        public SvgElement WithViewbox(double? minX, double? minY, double? width, double? height) {
            ViewboxMinX = minX;
            ViewboxMinY = minY;
            ViewboxWidth = width;
            ViewboxHeight = height;
            return this;
        }


        private XElement _styleXElement;
        private StringBuilder _valueSb = new StringBuilder();


        public SvgElement AddCss(string css, bool addCss = true) {
            if (!addCss || string.IsNullOrEmpty(css)) {
                return this;
            }
            _styleXElement = new XElement("style");
            _styleXElement.Add(new XAttribute("type", "text/css"));
            _styleXElement.Value = css;
            return this;
        }


        public SvgElement AddValue(string value, bool addValue = true) {
            if (!addValue || string.IsNullOrEmpty(value)) {
                return this;
            }
            _valueSb.AppendLine(value);
            return this;
        }


        /// <inheritdoc />
        public override XElement GetXml() {
			XNamespace xmlnssvg = Xmlns;
			XElement svg = new XElement(xmlnssvg + "svg");
			AddID(svg);
            bool withSize = !string.IsNullOrEmpty(Width) && !string.IsNullOrEmpty(Height);
			bool withViewbox = ViewboxMinX != null && ViewboxMinY != null && ViewboxWidth != null && ViewboxHeight != null;
			AddAttribute(svg, "viewbox", $"{ViewboxMinX} {ViewboxMinY} {ViewboxWidth} {ViewboxHeight}", !withSize && withViewbox);
            AddAttribute(svg, "width", Width, withSize && !withViewbox);
            AddAttribute(svg, "height", Height, withSize && !withViewbox);
			AddAttribute(svg, "style", Style, !string.IsNullOrEmpty(Style));
			AddAttribute(svg, "version", Version, !string.IsNullOrEmpty(Version));
			AddStroke(svg);
			AddFill(svg);

            StringBuilder sb = new StringBuilder();
            if (_styleXElement != null) {
                sb.AppendLine(_styleXElement.ToString());
            }
            if (_valueSb.Length > 0) {
                sb.AppendLine(_valueSb.ToString());
            }
            svg.Value = sb.ToString();

			return svg;
		}
    }
}
