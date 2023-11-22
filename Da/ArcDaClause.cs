#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Da {

    internal class ArcDaClause : DaClauseBase {
        private double _r1;
        private double _r2;
        private double _rot;
        private bool _lf;
        private bool _sf;
        private double _xe;
        private double _ye;


        public ArcDaClause(double r1, double r2, double rot, bool lf, bool sf, double xe, double ye) : base("A") {
            _r1 = r1;
            _r2 = r2;
            _rot = rot;
            _lf = lf;
            _sf = sf;
            _xe = xe;
            _ye = ye;
        }

        public override string ToString() {
            int lf = _lf ? 1 : 0;
            int sf = _sf ? 1 : 0;

            return $"{base.ToString()} {Cd(_r1)} {Cd(_r2)} {Cd(_rot)} {lf} {sf} {Cd(_xe)} {Cd(_ye)}";
        }
    }
}