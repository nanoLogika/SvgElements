#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

    /// <summary>
    /// Represents SVG <i>ellipse</i> element.
    /// </summary>
	public class EllipseElement : SvgElementBase {

		/// <summary>
		/// Gets or sets the x-coordinate of the ellipse center.
		/// </summary>
		public double Cx { get; set; }


		/// <summary>
		/// Gets or sets the y-coordinate of the ellipse center.
		/// </summary>
		public double Cy { get; set; }


		/// <summary>
		/// Gets or sets the ellipse axis in x-direction.
		/// This property must be specified.
		/// </summary>
		public double Rx { get; set; }


		/// <summary>
		/// Gets or sets the ellipse axis in y-direction.
		/// This property must be specified.
		/// </summary>
		public double Ry { get; set; }


		/// <inheritdoc />
		public override XElement GetXml() {
			if (Rx == 0 || Ry == 0) {
				throw new InvalidOperationException("EllipseElement.Rx, .Ry must be specified.");
			}
			XElement xElement = new XElement("ellipse");
			AddID(xElement);
			AddClass(xElement);
			AddTransform(xElement);
			xElement.Add(new XAttribute("cx", Cd(Cx)));
			xElement.Add(new XAttribute("cy", Cd(Cy)));
			xElement.Add(new XAttribute("rx", Cd(Rx)));
			xElement.Add(new XAttribute("ry", Cd(Ry)));
			AddStroke(xElement);
			AddStrokeDashArray(xElement);
			AddFill(xElement);

			xElement.Value = string.Empty;
			return xElement;
		}
	}
}
