using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ActiveWare.CSS {
	/// <summary></summary>
	public interface IRuleSetContainer {
		/// <summary></summary>
		List<RuleSet> RuleSets { get; set; }
	}
}