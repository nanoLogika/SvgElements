#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion


namespace SvgElements.Da {

    internal class QSplineDaClause : DaClauseBase {

        private double _x0;
        private double _y0;
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;


        public QSplineDaClause(double x0, double y0, double x1, double y1, double x2, double y2) : base("M") {
            _x0 = x0;
            _y0 = y0;
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }


        public override string ToString() {
            return $"{base.ToString()} {Cd(_x0)} {Cd(_y0)} Q {Cd(_x1)} {Cd(_y1)} {Cd(_x2)} {Cd(_y2)}";
        }
    }
}