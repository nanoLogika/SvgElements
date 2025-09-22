#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Da {

	internal class LineAbsArcDaClause : DaAbsArcClauseBase {

		public LineAbsArcDaClause(double startX, double startY, double endX, double endY, double r, bool largeArc, bool sweep)
            : base(startX, startY, endX, endY, r, largeArc, sweep, "L") {
		}


        public LineAbsArcDaClause(double startX, double startY, double endX, double endY, double rx, double ry, double rot, bool largeArc, bool sweep)
            : base(startX, startY, endX, endY, rx, ry, rot, largeArc, sweep, "L") {
        }
	}
}
