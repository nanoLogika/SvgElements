#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

    /// <summary>
    /// Represents a SVG <i>rect</i> element. 
    /// </summary>
    public class RectangleElement : SvgElementBase<RectangleElement> {

        /// <summary>
        /// Gets or sets the x-coordinate of one of the corners
        /// of the rectangle. Default is X=0.
        /// </summary>
        public double X { get; set; } = 0;


        /// <summary>
        /// Gets or sets the y-coordinate of one of the corners
        /// of the rectangle. Default is Y=0.
        /// </summary>
        public double Y { get; set; } = 0;

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// Width must not be eugal to 0. 
        /// </summary>
        public double Width { get; set; } = 0;


        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// Height must not be eugal to 0. 
        /// </summary>
        public double Height { get; set; } = 0;


        /// <inheritdoc />
        public override XElement GetXml() {
            if (Width == 0 || Height == 0) {
                throw new InvalidOperationException("RectangleElement.Width and .Height must be specified.");
            }
            XElement xElement = new XElement("rect");
			AddID(xElement);
			AddClass(xElement);
			AddTransform(xElement);
            xElement.Add(new XAttribute("x", Cd(X)));
            xElement.Add(new XAttribute("y", Cd(Y)));
            xElement.Add(new XAttribute("width", Cd(Width)));
            xElement.Add(new XAttribute("height", Cd(Height)));
            AddStroke(xElement);
			AddStrokeDashArray(xElement);
			AddFill(xElement);
            xElement.Value = string.Empty;
            return xElement;
        }
    }
}
