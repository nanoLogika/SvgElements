#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion


using System.Xml.Linq;


namespace SvgElements {

	/// <summary>
	/// Represents 
	/// </summary>
	public class PatternElement : GroupElementBase<PatternElement> {

		public enum PatternUnitsType {
			UserSpaceOnUse,
			ObjectBoundingBox
		}


		/// <summary>
		/// Get or sets the x-coordinate of left-bottom corner of the patterns's bounding box.
		/// </summary>
		public double X { get; set; } = 0;


		/// <summary>
		/// Get or sets the y-coordinate of left-bottom corner of the patterns's bounding box.
		/// </summary>
		public double Y { get; set; } = 0;


		/// <summary>
		/// Gets or sets the width of the patterns's bounding box.
		/// </summary>
		public double Width { get; set; } = 0;


		/// <summary>
		/// Gets or sets the width of the patterns's bounding box.
		/// </summary>
		public double Height { get; set; } = 0;


		/// <summary>
		/// Gets or sets the value for the <i>patternUnits</i> attribute.
		/// </summary>
		public PatternUnitsType PatternUnits { get; set; } = PatternUnitsType.UserSpaceOnUse;


		/// <summary>
		/// Gets or sets the list of <see cref="XElement"/> objects.
		/// </summary>
		public List<XElement> Elements = new List<XElement>();


		/// <inheritdoc />
		public override XElement GetXml() {
            if (string.IsNullOrEmpty(ID)) {
                throw new InvalidOperationException("PatternElement.id must be specified.");
            }
            XElement xElement = new XElement("pattern");
			if (!string.IsNullOrEmpty(Comment)) {
				xElement.Add(new XComment(Comment));
			}
			AddID(xElement);
			xElement.Add(new XAttribute("x", Cd(X)));
			xElement.Add(new XAttribute("y", Cd(Y)));
			xElement.Add(new XAttribute("width", Cd(Width)));
			xElement.Add(new XAttribute("height", Cd(Height)));
			AddStroke(xElement);

			string patternUnits = PatternUnits.ToString();
			patternUnits = patternUnits[0].ToString().ToLower() + patternUnits.Substring(1);
			xElement.Add(new XAttribute("patternUnits", patternUnits));

			AddTransform(xElement);
			foreach (XElement element in Elements) {
				xElement.Add(element);
			}
			return xElement;
		}
	}
}
