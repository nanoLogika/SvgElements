#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion


namespace SvgElements {

	/// <summary>
	/// Base class for objects representing a group-like SVG element such
	/// as <i>g</i>, <i>pattern</i>, <i>defs</i>.
	/// </summary>
	public abstract class GroupElementBase<T> : SvgElementBase<T> {

		/// <summary>
		/// Get the list of child SVG elements of this group element
		/// (<i>g</i>, <i>pattern</i>, <i>defs</i>).
		/// </summary>
		public List<SvgElementBase> Children { get; } = new List<SvgElementBase>();
	}
}
