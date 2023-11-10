#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Transform {

	internal class RotateTransformClause : TransformClauseBase {

		public double A { get; }


		public double? X { get; }


		public double? Y { get; }


		public RotateTransformClause(double a, bool reverseY) : this(a, null, null, reverseY) {

		}


		public RotateTransformClause(double a, double? x, double? y, bool reverseY) : base("rotate", reverseY) {
			A = a;
			X = x;
			Y = y;
		}


		public override string ToString() {
			if (Math.Abs(A) == 0 || Math.Abs(A) % 360 == 0) {
				return string.Empty;
			}

			if (X == null || Y == null) {
				return $"{base.ToString()}({Cd(A)})";
			}

			double y = ReverseY ? -Y.Value : Y.Value;
			double a = ReverseY ? -A : A;
			return $"{base.ToString()}({Cd(a)}, {Cd(X)}, {Cd(y)})";
		}
	}
}
