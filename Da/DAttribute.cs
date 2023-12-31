﻿#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Text;


namespace SvgElements.Da {

	/// <summary>
	/// Represents a <i>d-attribute</i> of an SVG <i>path</i> element.
	/// </summary>
	internal class DAttribute {

		private List<DaClauseBase> _daList = new List<DaClauseBase>();
		private bool _isClosed;


		/// <summary>
		/// Gets a value indicating that this <see cref="DAttribute"/> contains no clause.
		/// </summary>
		/// <value>
		/// <b>true</b>, when the d-attribute is empty; otherwise, <b>false</b>;
		/// </value>
        public bool IsEmpty {
			get { return _daList.Count == 0; }
		}


        public void AddMove(double x, double y) {
			_daList.Add(new MoveAbsDaClause(x, y));
		}


		public void AddMoveRelative(double x, double y) {
			_daList.Add(new MoveRelDaClause(x, y));
		}


		public void AddLine(double x, double y) {
			_daList.Add(new LineAbsDaClause(x, y));
		}


		public void AddLineRelative(double x, double y) {
			_daList.Add(new LineRelDaClause(x, y));
		}


		public void AddMoveAndArc(double cx, double cy, double sa, double ea, double r, bool counterClockWise = true) {
			_daList.Add(new MoveAbsArcDaClause(cx, cy, sa, ea, r, counterClockWise));
		}


		public void AddMoveAndArc(double cx, double cy, double sa, double ea, double rx, double ry, double rot, bool counterClockWise = true) {
			_daList.Add(new MoveAbsArcDaClause(cx, cy, sa, ea, rx, ry, rot, counterClockWise));
		}


		public void AddLineAndArc(double cx, double cy, double sa, double ea, double r, bool counterClockWise = true) {
			_daList.Add(new LineAbsArcDaClause(cx, cy, sa, ea, r, counterClockWise));
		}


        internal void AddArc(double r1, double r2, double rot, bool lf, bool sf, double xe, double ye) {
			_daList.Add(new ArcDaClause(r1, r2, rot, lf, sf, xe, ye));
        }


        internal void AddMoveAndQSpline(double[] doubles) {
            _daList.Add(new QSplineDaClause(doubles[0], doubles[1], doubles[2], doubles[3], doubles[4], doubles[5]));
        }


        internal void AddMoveAndCSpline(double[] doubles) {
            _daList.Add(new CSplineDaClause(doubles[0], doubles[1], doubles[2], doubles[3], doubles[4], doubles[5], doubles[6], doubles[7]));
        }


        public void Close() {
			_isClosed = true;
		}


		public bool IsClosed() {
			return _isClosed;
		}


		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			foreach (DaClauseBase daClause in _daList) {
				sb.Append(daClause).Append(" ");
			}
			if (_isClosed) {
				sb.Append(new CloseDaClause());
            }
			return sb.ToString().Trim();
		}
    }
}
