using System;

namespace ActiveWare.CSS {
	public enum AttributeOperator {
		/// <summary></summary>
		Equals,     // =
		/// <summary></summary>
		InList,     // ~=
		/// <summary></summary>
		Hyphenated, // |=
		/// <summary></summary>
		EndsWith,   // $=
		/// <summary></summary>
		BeginsWith, // ^=
		/// <summary></summary>
		Contains    // *=
	}
}