#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Da {

	internal class LineAbsArcDaClause : DaClauseBase {

		public double Mx { get; }


		public double My { get; }


		public double R { get; }


		public double Lf { get; }


		public double Sf { get; }


		public double Ex { get; }


		public double Ey { get; }


		public LineAbsArcDaClause(double cx, double cy, double sa, double ea, double r, bool counterClockWise = true) : base("L") {
			var f = counterClockWise ? 1 : -1;
			Sf = counterClockWise ? 1 : 0;
			Mx = cx + r * Math.Cos(sa);
			My = cy + r * f * Math.Sin(sa);
			Ex = cx + r * Math.Cos(ea);
			Ey = cy + r * f * Math.Sin(ea);

			R = r;

			Lf = counterClockWise && (ea - sa) < Math.PI ||
				!counterClockWise && (ea - sa) < Math.PI
				?
				0 : 1;
		}


		public override string ToString() {
			return $"{base.ToString()} {Cd(Mx)} {Cd(My)} A {Cd(R)} {Cd(R)} 0 {Lf} {Sf} {Cd(Ex)} {Cd(Ey)}";
		}
	}
}
