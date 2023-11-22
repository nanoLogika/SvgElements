#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

	/// <summary>
	/// Represent a SVG group element (<i>g</i>) containing other SVG elements.
	/// </summary>
	public class GroupElement : GroupElementBase {

		/// <inheritdoc />
		public override XElement GetXml() {
            XElement xElement = new XElement("g");
			if (!string.IsNullOrEmpty(Comment)) {
				xElement.Add(new XComment(Comment));
			}
			AddID(xElement);
			AddClass(xElement);
			AddTransform(xElement);
			AddStroke(xElement);
			AddFill(xElement);

			foreach (SvgElementBase child in Children) {
				if (child == null) {
					continue;
				}

				xElement.Add(child.GetXml());
			}

			return xElement;
		}
	}
}
