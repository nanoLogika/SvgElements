#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

namespace SvgElements.Da {

    internal class DaAbsArcClauseBase : DaClauseBase {

        public DaAbsArcClauseBase(double startX, double startY, double endX, double endY, double r, bool largeArc, bool sweep, string letter)
            : base(letter) {

            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
            Rx = r;
            Ry = r;
            Rot = 0;
            Lf = largeArc ? 1 : 0;
            Sf = sweep ? 1 : 0;
        }


        public DaAbsArcClauseBase(double startX, double startY, double endX, double endY, double rx, double ry, double rot, bool largeArc, bool sweep, string letter)
            : base(letter) {

            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
            Rx = rx;
            Ry = ry;
            Rot = rot;
            Lf = largeArc ? 1 : 0;
            Sf = sweep ? 1 : 0;
        }


        public double StartX { get; }


        public double StartY { get; }


        public double Rx { get; set; }


        public double Ry { get; set; }


        public double Rot { get; set; }


        public double Lf { get; }


        public double Sf { get; }


        public double EndX { get; }


        public double EndY { get; }


        public override string ToString() {
            return $"{base.ToString()} {Cd(StartX)} {Cd(StartY)} A {Cd(Rx)} {Cd(Ry)} {Cd(Rot)} {Lf} {Sf} {Cd(EndX)} {Cd(EndY)}";
        }

    }
}