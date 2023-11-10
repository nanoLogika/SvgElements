#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

    /// <summary>
    /// Represents SVG <i>circle</i> element.
    /// </summary>
	public class CircleElement : SvgElementBase {

        /// <summary>
        /// Gets or sets the x-coordinate of the circle center.
        /// </summary>
        public double Cx { get; set; }


        /// <summary>
        /// Gets or sets the y-coordinate of the circle center.
        /// </summary>
        public double Cy { get; set; }


        /// <summary>
        /// Gets or sets the circle radius.
        /// </summary>
        public double R { get; set; }


        /// <inheritdoc />
        public override XElement GetXml() {
            if (R == 0) {
                throw new InvalidOperationException("CircleElement.R must be specified.");
            }
            XElement xElement = new XElement("circle");
            AddID(xElement);
            AddClass(xElement);
            AddTransform(xElement);
            xElement.Add(new XAttribute("cx", Cd(Cx)));
            xElement.Add(new XAttribute("cy", Cd(Cy)));
            xElement.Add(new XAttribute("r", Cd(R)));
            AddStroke(xElement);
            AddStrokeDashArray(xElement);
            AddFill(xElement);
            xElement.Value = string.Empty;
            return xElement;
        }
    }
}
