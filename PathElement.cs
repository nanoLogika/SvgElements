#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using SvgElements.Da;
using System.Xml.Linq;


namespace SvgElements {

    /// <summary>
    /// Represents a SVG <i>path</i> element. 
    /// </summary>
	public class PathElement : SvgElementBase {

        private DAttribute _da = new DAttribute();


        /// <summary>
        /// Adds an absolute move clause and one or more absolute line clauses to the
        /// d-Attribute of this path element and returns this element.
        /// </summary>
        /// <param name="coords">An array of y and y coordinates.</param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddPoints(params double[] coords) {
            return AddPoints(true, coords);
        }


        /// <summary>
        /// Adds an absolute move or line clause and one or more absolute line clauses
        /// to the d-Attribute of this path element and returns this element.
        /// </summary>
        /// <param name="firstPointMove"><b>true</b>, if the first clause is a move; otherwise, <b>false</b>.</param>
        /// <param name="coords">An array of y and y coordinates.</param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddPoints(bool firstPointMove, params double[] coords) {
            if (coords.Length == 0) {
                return this;
            }

            if (!coordinatesValid(coords)) {
                throw new ArgumentException("Invalid coordinates.");
            }

            for (int i = 0; i < coords.Length; i += 2) {
                var x = coords[i];
                var y = coords[i + 1];

                if (i == 0 && firstPointMove) {
                    AddMove(x, y);
                }
                else {
                    AddLine(x, y);
                }
            }

            return this;
        }


        /// <summary>
        /// Adds an absolute move clause M {x} {y} to the d-Attribute of
        /// this path element and returns this element.
        /// </summary>
        /// <param name="x">Absolute x-coordinate.</param>
        /// <param name="y">Absolute y-coordinate.</param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddMove(double x, double y) {
            _da.AddMove(x, y);
            return this;
        }


        /// <summary>
        /// Adds an relative move clause m {x} {y} to the d-Attribute of
        /// this path element and returns this element.
        /// </summary>
        /// <param name="x">Relative x-coordinate.</param>
        /// <param name="y">Relative y-coordinate.</param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddMoveRelative(double x, double y) {
            _da.AddMoveRelative(x, y);
            return this;
        }


        /// <summary>
        /// Adds an absolute line clause L {x} {y} to the d-Attribute of
        /// this path element and returns this element.
        /// </summary>
        /// <param name="x">Absolute x-coordinate.</param>
        /// <param name="y">Absolute y-coordinate.</param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddLine(double x, double y) {
            _da.AddLine(x, y);
            return this;
        }


        /// <summary>
        /// Adds an relative line clause l {x} {y} to the d-Attribute of
        /// this path element and returns this element.
        /// </summary>
        /// <param name="x">Relative x-coordinate.</param>
        /// <param name="y">Relative y-coordinate.</param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddLineRelative(double x, double y) {
            _da.AddLineRelative(x, y);
            return this;
        }


        /// <summary>
        /// Adds an absolute move and a line clause M {x} {y} L {x} {y} to the d-Attribute
        /// of this path element and returns this element.
        /// </summary>
        /// <param name="fromX">Absolute x-coordinate of begin of line.</param>
        /// <param name="fromY">Absolute y-coordinate of begin of line.</param>
        /// <param name="toX">Absolute x-coordinate of end of line.</param>
        /// <param name="toY">Relative y-coordinate of end of line.</param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddLine(double fromX, double fromY, double toX, double toY) {
            _da.AddMove(fromX, fromY);
            _da.AddLine(toX, toY);
            return this;
        }


        /// <summary>
        /// Adds a move clause and an circular arc clause to the d-Attribute
        /// of this path element and returns this element.
        /// </summary>
        /// <param name="cx"></param> 
        /// <param name="cy"></param>
        /// <param name="sa"></param>
        /// <param name="ea"></param>
        /// <param name="r"></param>
        /// <param name="counterClockWise"></param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddMoveAndArc(double cx, double cy, double sa, double ea, double r, bool counterClockWise = true) {
            _da.AddMoveAndArc(cx, cy, sa, ea, r, counterClockWise);
            return this;
        }


        /// <summary>
        /// Adds a move clause and an elliptic arc clause to the d-Attribute
        /// of this path element and returns this element.
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="sa"></param>
        /// <param name="ea"></param>
        /// <param name="rx"></param>
        /// <param name="ry"></param>
        /// <param name="rot"></param>
        /// <param name="counterClockWise"></param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddMoveAndArc(double cx, double cy, double sa, double ea, double rx, double ry, double rot, bool counterClockWise = true) {
            _da.AddMoveAndArc(cx, cy, sa, ea, rx, ry, rot, counterClockWise);
            return this;
        }


        /// <summary>
        /// Adds a line clause and an arc clause to the d-Attribute
        /// of this path element and returns this element.
        /// </summary>
        /// <param name="cx"></param> 
        /// <param name="cy"></param>
        /// <param name="sa"></param>
        /// <param name="ea"></param>
        /// <param name="r"></param>
        /// <param name="counterClockWise"></param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddLineAndArc(double cx, double cy, double sa, double ea, double r, bool counterClockWise = true) {
            _da.AddLineAndArc(cx, cy, sa, ea, r, counterClockWise);
            return this;
        }


        /// <summary>
        /// Adds an arc clause without a move or line clause before to the d-Attribute
        /// of this path element and returns this element.
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="rot"></param>
        /// <param name="lf"></param>
        /// <param name="sf"></param>
        /// <param name="xe"></param>
        /// <param name="ye"></param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddArc(double r1, double r2, double rot, bool lf, bool sf, double xe, double ye) {
            _da.AddArc(r1, r2, rot, lf, sf, xe, ye);
            return this;
        }


        /// <summary>
        /// Adds a move clause and quadratic spline clause to the d-Attribute
        /// of this path element and returns this element.
        /// </summary>
        /// <param name="doubles"></param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddMoveAndQSpline(double[] doubles) {
            _da.AddMoveAndQSpline(doubles);
            return this;
        }


        /// <summary>
        /// Adds a move clause and quadratic spline clause to the d-Attribute
        /// of this path element and returns this element.
        /// </summary>
        /// <param name="doubles"></param>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement AddMoveAndCSpline(double[] doubles) {
            _da.AddMoveAndCSpline(doubles);
            return this;
        }


        /// <summary>
        /// Adds a close clause Z to the d-Attribute
        /// of this path element and returns this element.
        /// </summary>
        /// <returns>This <see cref="PathElement"/>.</returns>
        public PathElement Close(bool close = true) {
            if (close) {
                _da.Close();
            }
            return this;
        }


        private bool coordinatesValid(params double[] coords) {
            return coords != null && coords.Length > 0 && coords.Length % 2 == 0;
        }


        /// <inheritdoc />
        public override XElement GetXml() {
            if (_da.IsEmpty) {
                throw new InvalidOperationException("PathElement d-Attribute must not be empty.");
            }
            XElement xElement = new XElement("path");
			AddID(xElement);
			AddClass(xElement);
			AddTransform(xElement);
            xElement.Add(new XAttribute("d", _da.ToString()));
            AddStroke(xElement);
			AddStrokeDashArray(xElement);
			AddFill(xElement);
            xElement.Value = string.Empty;
            return xElement;
        }
    }
}