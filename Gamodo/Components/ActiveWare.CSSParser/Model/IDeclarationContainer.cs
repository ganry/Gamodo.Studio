using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ActiveWare.CSS {
	/// <summary></summary>
	public interface IDeclarationContainer {
		/// <summary></summary>
		List<Declaration> Declarations { get; set; }
	}
}