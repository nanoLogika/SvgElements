#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Da {

	internal class MoveAbsArcDaClause : DaClauseBase {

		public double Mx { get; }


		public double My { get; }


		public double Rx { get; set; }


		public double Ry { get; set; }


		public double Rot { get; set; }


		public double Lf { get; set; }


		public double Sf { get; set; }


		public double Ex { get; set; }


		public double Ey { get; set; }


		public MoveAbsArcDaClause(double cx, double cy, double sa, double ea, double r, bool counterClockWise = true)  : base("M") {
			var f = counterClockWise ? 1 : -1;
			Sf = counterClockWise ? 1 : 0;
			Mx = cx + r * Math.Cos(sa);
			My = cy + r * f * Math.Sin(sa);
			Ex = cx + r * Math.Cos(ea);
			Ey = cy + r * f * Math.Sin(ea);

			Rx = r;
			Ry = r;
			Rot = 0;

			Lf = counterClockWise && (ea - sa) < Math.PI ||
				!counterClockWise && (ea - sa) < Math.PI
				?
				0 : 1;
		}


		public MoveAbsArcDaClause(double cx, double cy, double sa, double ea, double rx, double ry, double rot, bool counterClockWise = true) : base("M") {
			var f = counterClockWise ? 1 : -1;
			Sf = counterClockWise ? 1 : 0;
			Mx = cx + rx * Math.Cos(rot) * Math.Cos(sa) - ry * Math.Sin(rot) * Math.Sin(sa);
			My = cy + rx * Math.Sin(rot) * Math.Cos(sa) + ry * Math.Cos(rot) * Math.Sin(sa);
			Ex = cx + rx * Math.Cos(rot) * Math.Cos(ea) - ry * Math.Sin(rot) * Math.Sin(ea);
			Ey = cy + rx * Math.Sin(rot) * Math.Cos(ea) + ry * Math.Cos(rot) * Math.Sin(ea);

			Rx = rx;
			Ry = ry;
			Rot = rot / Math.PI * 180;

			Lf = counterClockWise && (ea - sa) < Math.PI ||
				!counterClockWise && (ea - sa) < Math.PI
				?
				0 : 1;
		}


		public override string ToString() {
			return $"{base.ToString()} {Cd(Mx)} {Cd(My)} A {Cd(Rx)} {Cd(Rx)} {Cd(Rot)} {Lf} {Sf} {Cd(Ex)} {Cd(Ey)}";
		}
	}
}
