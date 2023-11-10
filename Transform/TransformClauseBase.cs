#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Globalization;


namespace SvgElements.Transform {

	internal abstract class TransformClauseBase {

		public string Name { get; }


		public TransformClauseBase(string name, bool reverseY) {
			Name = name;
			ReverseY = reverseY;
		}


		public bool ReverseY { get; set; }


		//	TODO Why is this method different?
		protected static string Cd(double? val) {
			if (val == null) {
				return "0";
			}

			return SvgElementBase.Cd(val.Value);
		}


		public override string ToString() {
			return Name;
		}
	}
}
