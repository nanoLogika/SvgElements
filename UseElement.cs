#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Xml.Linq;


namespace SvgElements {

	/// <summary>
	/// Represents SVG <i>use</i> element.
	/// </summary>
	public class UseElement : SvgElementBase<UseElement> {

		private string _groupId;

		/// <summary>
		/// Gets or sets an optional x-coordinate of the location for the
		/// content referenced by this <see cref="UseElement"/>. Default
		/// is x = 0.
		/// </summary>
		public double? X { get; set; }


		/// <summary>
		/// Gets or sets an optional y-coordinate of the location for the
		/// content referenced by this <see cref="UseElement"/>. Default
		/// is y = 0.
		/// </summary>
		public double? Y { get; set; }


		/// <summary>
		/// Gets or sets the the ID of the SVG group to be
		/// referenced and returns this element.
		/// </summary>
		/// <value>
		/// A string containing the ID of the SVG group as defined by the
		/// <i>id</i>-Attribute.
		/// </value>
		public string GroupId {
			get {
				return _groupId;
			}
			set {
				_groupId = value;
				if (!_groupId.StartsWith("#")) {
					_groupId = $"#{_groupId}";
				}
			}
		}


		/// <summary>
		/// Sets the location (<see cref="X"/>, <see cref="Y"/>) for the
		/// content referenced by this <see cref="UseElement"/> and returns
		/// this element.
		/// </summary>
		/// <param name="x">The x-coordinate of the location.</param>
		/// <param name="y">The y-coordinate of the location.</param>
		/// <returns>This <see cref="UseElement"/>.</returns>
		public UseElement WithXY(double x, double y) {
			X = x;
			Y = y;
			return this;
		}


		/// <summary>
		/// Sets the <see cref="GroupId"/>, i.e. the ID of the SVG group to be
		/// referenced and returns this element.
		/// </summary>
		/// <param name="groupId">The ID of a SVG group as defined by the
		/// <i>id</i>-Attribute.</param>
		/// <returns>This <see cref="UseElement"/>.</returns>
		public UseElement WithGroupId(string groupId) {
			GroupId = groupId;
			return this;
		}


		/// <inheritdoc />
		public override XElement GetXml() {
			if (string.IsNullOrEmpty(_groupId)) {
				throw new InvalidOperationException("UseElement.BlockName must be specified.");
			}
			XElement xElement = new XElement("use");
			AddAttribute(xElement, "x", Cd(X.GetValueOrDefault()), X.HasValue);
			AddAttribute(xElement, "y", Cd(Y.GetValueOrDefault()), Y.HasValue);
			AddTransform(xElement);
			xElement.Add(new XAttribute("href", _groupId));
			xElement.Value = string.Empty;
			return xElement;
		}
	}
}
