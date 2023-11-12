#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

    /// <summary>
    /// Represents the <i>svg</i> Element.
    /// </summary>
    public class SvgElement : SvgElementBase {

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
        /// Gets or sets a value for the <i>style</i> attribute.
        /// </summary>
        public string Style { get; set; } = "width:100%;height:100%;position:fixed;top:0;left:0;bottom:0;right:0;";
        
        
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
        public SvgElement WithViewbox(double minX, double minY, double width, double height) {
            ViewboxMinX = minX;
            ViewboxMinY = minY;
            ViewboxWidth = width;
            ViewboxHeight = height;
            return this;
        }


        /// <inheritdoc />
        public override XElement GetXml() {
            XNamespace xmlnssvg = Xmlns;
            XElement svg = new XElement(xmlnssvg + "svg");
            AddID(svg);
            bool withViewbox = ViewboxMinX != null && ViewboxMinY != null && ViewboxWidth != null && ViewboxHeight != null;
            AddAttribute(svg, "viewbox", $"{ViewboxMinX} {ViewboxMinY} {ViewboxWidth} {ViewboxHeight}", withViewbox);
            AddAttribute(svg, "style", Style, !string.IsNullOrEmpty(Style));
            AddAttribute(svg, "version", Version, !string.IsNullOrEmpty(Version));
            AddStroke(svg);
            AddFill(svg);
            return svg;
        }
    }
}
