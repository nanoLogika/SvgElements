#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Transform {

	internal class ScaleTransformClause : TransformClauseBase {

		public double X { get; }


		public double Y { get; }


		public ScaleTransformClause(double x, bool reverseY) : this(x, x, reverseY) {}


		public ScaleTransformClause(double x, double y, bool reverseY) : base("scale", reverseY) {
			X = x;
			Y = y;
		}


		public override string ToString() {
			var y = ReverseY ? -Y : Y;
			if (X == 1 && y == 1) {
				return string.Empty;
			}

			if (X == y) {
				return $"{base.ToString()}({Cd(X)})";
			}

			return $"{base.ToString()}({Cd(X)}, {Cd(y)})";
		}
	}
}
