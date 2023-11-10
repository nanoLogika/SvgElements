#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Transform {

	internal class TranslateTransformClause : TransformClauseBase {

		public double X { get; }


		public double Y { get; }


		public TranslateTransformClause(double x, bool reverseY) : this(x, 0, reverseY) { }


		public TranslateTransformClause(double x, double y, bool reverseY) : base("translate", reverseY) {
			X = x;
			Y = y;
		}


		public override string ToString() {
			if (X == 0 && Y == 0) {
				return string.Empty;
			}

			if (Y == 0) {
				return $"{base.ToString()}({Cd(X)})";
			}

			double y = ReverseY ? -Y : Y;
			return $"{base.ToString()}({Cd(X)}, {Cd(y)})";
		}
	}
}
