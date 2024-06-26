﻿#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Globalization;
using System.Text;
using System.Xml.Linq;

using SvgElements.Transform;


namespace SvgElements {

    /// <summary>
    /// Base class for all classes that represent SVG elements.
    /// </summary>
	public abstract class SvgElementBase {

        internal TransformAttribute _ta = new TransformAttribute();

        /// <summary>
        /// Returns an XML-element built from the properties of this SVG-element
        /// object.
        /// </summary>
        /// <returns>
        /// The <see cref="XElement"/> built from the properties of this
        /// SVG-element.
        /// </returns>
        public abstract XElement GetXml();


        /// <summary>
        /// Formats a double value with a decimal dot as needed in numerical attribute
        /// of a SVG element.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="places"></param>
        /// <returns>A string containing the formatted double value.</returns>
        public static string Cd(double val, int places = 6) {
            return Math.Round(val, places).ToString(CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Gets or sets an optional value for the <i>id</i> attribute.
        /// </summary>
        public string ID { get; set; }


        /// <summary>
        /// Gets or sets an optional value for the <i>class</i> attribute.
        /// </summary>
        public string Class { get; set; }


        /// <summary>
        /// Gets or sets a value indicating that a comment associated with this
        /// <see cref="SvgElementBase"/> is to be displayed.
        /// </summary>
        /// <value><b>true</b>, when the comment is to be displayed; otherwise, <b>false</b>.</value>
        public static bool CommentsEnabled { get; set; } = false;


        /// <summary>
        /// Gets or sets an optional string value for a comment to be placed in
        /// this element.
        /// </summary>
        public string Comment { get; set; }


        /// <summary>
        /// Gets or sets an optional value for the <i>stroke</i> attribute.
        /// </summary>
		public string Stroke { get; set; }


        /// <summary>
        /// Gets or sets an optional value for the <i>stroke-width</i> attribute.
        /// </summary>
		public double? StrokeWidth { get; set; } = 0;


        /// <summary>
        /// Gets or sets an optional value for the <i>stroke-dasharray</i> attribute.
        /// </summary>
        public string StrokeDashArray { get; set; } = null;


        /// <summary>
        /// Gets or sets an optional value for the <i>fill</i> attribute.
        /// </summary>
		public string Fill { get; set; }


        /// <summary>
        /// Gets the value of the <i>transform</i> attribute, built from the specified clauses.
        /// </summary>
        public string Transform {
            get { return _ta.ToString(); }
        }
    }

    /// <summary>
    /// Base class for all classes that represent SVG elements.
    /// </summary>
    public abstract class SvgElementBase<T> : SvgElementBase {

        /// <summary>
        /// Sets the value for the <i>id</i> attribute
        /// and returns this element.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>This <see cref="T"/>.</returns>
        public T WithID(string id) {
            ID = id;
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Sets the value for the <i>class</i> attribute
        /// and returns this element.
        /// </summary>
        /// <param name="className"></param>
        /// <returns>This <see cref="T"/>.</returns>
        public T WithClass(string className) {
            Class = className;
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Sets the value for the <i>stroke</i> attribute
        /// and returns this element.
        /// </summary>
        /// <param name="stroke"></param>
        /// <returns>This <see cref="T"/>.</returns>

        public T WithStroke(string stroke) {
            Stroke = stroke;
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Sets the values for the <i>stroke-width</i> attribute
        /// and returns this element.
        /// </summary>
        /// <param name="strokeWidth"></param>
        /// <returns>This <see cref="T"/>.</returns>
        public T WithStrokeWidth(double? strokeWidth) {
            StrokeWidth = strokeWidth;
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Sets the value for the <i>stroke-dasharray</i> attribute
        /// and returns this element.
        /// </summary>
        /// <param name="strokeDashArray"></param>
        /// <returns>This <see cref="T"/>.</returns>
        public T WithStrokeDashArray(string strokeDashArray) {
            StrokeDashArray = strokeDashArray;
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Sets the fill property with an fill attribute value containg a
        /// color name or Hex RGB-value and returns this element.
        /// </summary>
        /// <param name="fill"></param>
        /// <returns>This <see cref="T"/>.</returns>
        public T WithFill(string fill) {
            Fill = fill;
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Sets the fill property with a fill attribute value containg a URL
        /// expression with the passed fill URL and returns this element.
        /// </summary>
        /// <param name="fillUrl"></param>
        /// <returns>This <see cref="T"/>.</returns>
        public T WithFillURL(string fillUrl) {
            Fill = $"url({fillUrl})";
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Adds a scale clause with individual scale factors for x and y 
        /// to the transform attribute and returns this element.
        /// </summary>
        /// <param name="x">Scale factor for x.</param>
        /// <param name="y">Scale factor for y.</param>
        /// <returns></returns>
        public T AddScale(double x, double y) {
            _ta.AddScale(x, y);
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Adds a scale clause with equal scale factors for x and y 
        /// to the transform attribute and returns this element.
        /// </summary>
        /// <param name="xy">Scale factor for x and y.</param>
        /// <returns></returns>
        public T AddScale(double xy) {
            _ta.AddScale(xy);
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Adds a rotate clause to the transform attribute and returns this
        /// element.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public T AddRotate(double a) {
            _ta.AddRotate(a);
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Adds a rotate clause to the transform attribute and returns this
        /// element.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T AddRotate(double a, double x, double y) {
            _ta.AddRotate(a, x, y);
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Adds a transalate clause to the transform attribute and returns this
        /// element.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T AddTranslate(double x, double y) {
            _ta.AddTranslate(x, y);
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Sets a value indicating that a transform atrribute provides a inversion of
        /// the y-coordinate.
        /// </summary>
        /// <returns></returns>
        public T ReverseY(bool value = true) {
            _ta.ReverseY = value;
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Sets the <see cref="Comment"/> property
        /// and return this element.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>This <see cref="T"/>.</returns>
        public T WithComment(string comment) {
            Comment = comment;
            return (T)Convert.ChangeType(this, typeof(T));
        }


        /// <summary>
        /// Returns an XML-element built from the properties of this SVG-element
        /// object as string. If the <see cref="Comment"/> property contains a
        /// value and comments are enbled a XML Comment element is placed before
        /// the XML-element.
        /// </summary>
        /// <returns>A string containing <see cref="XElement"/> built from the properties of this
        /// SVG-element preceeded by a <see cref="XComment"/> element.
        /// </returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            if (CommentsEnabled && !string.IsNullOrEmpty(Comment)) {
                sb.AppendLine(new XComment(Comment).ToString());
            }
            sb.Append(GetXml());
            return replaceSpecialCharacters(sb.ToString());
        }


		private string replaceSpecialCharacters(string value) {
			return value.Replace("&gt;", ">").Replace("&lt;", "<");
		}


        #region Internal methods to add optional attributes

        internal void AddID(XElement xElement) {
            if (!string.IsNullOrEmpty(ID)) {
                xElement.Add(new XAttribute("id", ID));
            }
        }


        internal void AddClass(XElement xElement) {
            if (!string.IsNullOrEmpty(Class)) {
                xElement.Add(new XAttribute("class", Class));
            }
        }


        internal void AddTransform(XElement xElement) {
            if (!string.IsNullOrEmpty(Transform)) {
                xElement.Add(new XAttribute("transform", Transform));
            }
        }


        internal void AddStroke(XElement xElement) {
            if (!string.IsNullOrEmpty(Stroke)) {
                xElement.Add(new XAttribute("stroke", Stroke));
            }
            if (StrokeWidth != null && StrokeWidth > 0) {
                xElement.Add(new XAttribute("stroke-width", Math.Round(StrokeWidth.GetValueOrDefault(), 4)));
            }
        }


        internal void AddStrokeDashArray(XElement xElement) {
            if (!string.IsNullOrEmpty(StrokeDashArray)) {
                xElement.Add(new XAttribute("stroke-dasharray", StrokeDashArray));
            }
        }


        internal void AddFill(XElement xElement) {
            if (!string.IsNullOrEmpty(Fill)) {
                xElement.Add(new XAttribute("fill", Fill));
            }
        }


        /// <summary>
        /// Adds an attribute with specified name and value if the <paramref name="specified"/>
        /// parameter is true and the specified value is not null.
        /// </summary>
        /// <param name="xElement">The element the attribute is to added to.</param>
        /// <param name="name">The name of the attributre.</param>
        /// <param name="value">The value for the attribute.</param>
        /// <param name="specified"><b>true</b>, if the attribute is to be added; otherwise; <b>false</b>.</param>
        internal static void AddAttribute(XElement xElement, string name, object value, bool specified) {
            if (value == null || !specified) {
                return;
            }
            xElement.Add(new XAttribute(name, value.ToString()));
        }

        #endregion
    }
}
