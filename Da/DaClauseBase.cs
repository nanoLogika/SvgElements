#region copyright LGPL nanoLogika
//  Copyright 2023, nanoLogika GmbH.
//  All rights reserved. 
//  This source code is licensed under the "LGPL v3 or any later version" license. 
//  See LICENSE file in the project root for full license information.
#endregion

using System.Globalization;


namespace SvgElements.Da {

	internal abstract class DaClauseBase {

		public string Letter { get; }


		public DaClauseBase(string letter) {
			Letter = letter;
		}


		protected static string Cd(double val) {
			return SvgElementBase.Cd(val);
		}


		public override string ToString() {
			return Letter;
		}
	}
}
