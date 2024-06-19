#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

	/// <summary>
	/// Represents a SVG <i>defs</i> element.
	/// </summary>
	public class DefsElement : GroupElementBase<DefsElement> {

		/// <summary>
		/// Gets a value indicating whether a group element with the
		/// specified <paramref name="id"/> exists in this <see cref="DefsElement" />.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>
		/// <b>true</b>, when a group element with the specified
		/// <paramref name="id"/> exists; otherwise,<b>false</b>.
		/// </returns>
		public bool Contains(string id) {
			foreach (SvgElementBase groupElement in Children) {
				if (groupElement.ID == id) {
					return true;
				}
			}

			return false;
		}


		/// <inheritdoc/>
		public override XElement GetXml() {
			if (Children.Count == 0) {
				return null;
			}

			XElement xElement = new XElement("defs");
			foreach (SvgElementBase def in Children) {
				xElement.Add(def.GetXml());
			}
			return xElement;
		}
	}
}
