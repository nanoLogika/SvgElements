#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Text;


namespace SvgElements.Transform {

	internal class TransformAttribute {

		private bool _reverseY = false;
		private List<TransformClauseBase> _transformList = new List<TransformClauseBase>();


		public bool ReverseY {
			get {
				return _reverseY;
			}
			set {
				_reverseY = value;
				bool scaleClauseExists = false;
				foreach (TransformClauseBase clause in _transformList) {
					clause.ReverseY = value;
					if (clause is ScaleTransformClause scaleClause) {
						scaleClauseExists = true;
					}
				}
				if (value && !scaleClauseExists) {
					_transformList.Add(new ScaleTransformClause(1, true));
				}
            }
		}


		public void AddTranslate(double x, double y) {
			_transformList.Add(new TranslateTransformClause(x, y, _reverseY));
		}


		public void AddRotate(double a) {
			_transformList.Add(new RotateTransformClause(a, _reverseY));
		}


		public void AddRotate(double a, double x, double y) {
			_transformList.Add(new RotateTransformClause(a, x, y, _reverseY));
		}


		public void AddScale(double x) {
			_transformList.Add(new ScaleTransformClause(x, _reverseY));
		}


		public void AddScale(double x, double y) {
			_transformList.Add(new ScaleTransformClause(x, y, _reverseY));
		}


		public void Clear()
		{
			_transformList.Clear();
		}


		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			foreach (TransformClauseBase transformClause in _transformList) {
				string value = transformClause.ToString();
				if (!string.IsNullOrEmpty(value)) {
					sb.Append(value).Append(" ");
				}
			}
			return sb.ToString().Trim();
		}
	}
}
