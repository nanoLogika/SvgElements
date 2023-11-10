﻿#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Da {

	internal class MoveRelDaClause : DaClauseBase {

		public double X { get; }


		public double Y { get; }


		public MoveRelDaClause(double x, double y) : base("m") {
			X = x;
			Y = y;
		}


		public override string ToString() {
			return $"{base.ToString()} {Cd(X)} {Cd(Y)}";
		}
	}
}
