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
	public class PatternElement : GroupElementBase {

		public enum PatternUnits {
			UserSpaceOnUse,
			ObjectBoundingBox
		}


		public double X { get; set; } = 0;


		public double Y { get; set; } = 0;


		public string Width { get; set; } = "0";


		public string Height { get; set; } = "0";


		public PatternUnits Units { get; set; } = PatternUnits.UserSpaceOnUse;


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
			xElement.Add(new XAttribute("x", X));
			xElement.Add(new XAttribute("y", Y));
			xElement.Add(new XAttribute("width", Width));
			xElement.Add(new XAttribute("height", Height));

			string patternUnits = Units.ToString();
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
