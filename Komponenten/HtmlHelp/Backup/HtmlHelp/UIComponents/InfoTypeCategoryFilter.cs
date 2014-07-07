using System;
using System.Collections;

using HtmlHelp;
using HtmlHelp.ChmDecoding;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// The class <c>InfoTypeCategoryFilter</c> implements properties/methods for defining a filter 
	/// for toc and index. Content will be filtered using information types and categories.
	/// </summary>
	public class InfoTypeCategoryFilter
	{
		private bool _containsExclusive=false;
		private ArrayList _informationTypes = new ArrayList();
		private ArrayList _categories = new ArrayList();

		/// <summary>
		/// Gets a flag if the filter is enabled.
		/// </summary>
		/// <remarks>False means that no filtering will be done (all contents will be displayed)</remarks>
		public bool FilterEnabled
		{
			get
			{
				bool bRet = false;

				bRet |= (_informationTypes.Count>0);
				bRet |= (_categories.Count>0);

				return bRet;
			}
		}

		/// <summary>
		/// Adds a new information type to the filter
		/// </summary>
		/// <param name="infoType">information type to add</param>
		public void AddInformationType(InformationType infoType)
		{
			if(! _informationTypes.Contains(infoType))
			{
				if(infoType.Mode == InformationTypeMode.Exclusive)
				{
					_containsExclusive=true;
					ResetFilter();
					_informationTypes.Add(infoType);
				} 
				else 
				{
					if(!_containsExclusive)
						_informationTypes.Add(infoType);
				}
			}
		}

		/// <summary>
		/// Adds a new category to the filter
		/// </summary>
		/// <param name="cat">category to add</param>
		public void AddCategory(Category cat)
		{
			if((! _categories.Contains(cat) )&&(!_containsExclusive))
				_categories.Add(cat);
		}

		/// <summary>
		/// Resets the filter
		/// </summary>
		public void ResetFilter()
		{
			_informationTypes.Clear();
			_categories.Clear();
		}

		/// <summary>
		/// Checks if a special information type is part of the filter
		/// </summary>
		/// <param name="type">information type to check</param>
		/// <returns>Returns true if the specified type is part of this filter</returns>
		public bool ContainsInformationType(InformationType type)
		{
			return _informationTypes.Contains(type);
		}

		/// <summary>
		/// Checks if a special category is part of the filter
		/// </summary>
		/// <param name="cat">category to check</param>
		/// <returns>Returns true if the specified category is part of the filter</returns>
		public bool ContainsCategory(Category cat)
		{
			return _categories.Contains(cat);
		}

		/// <summary>
		/// Checks if a type string matches the filter. 
		/// Type strings are of the following format: &lt;category name&gt;::&lt;information type name&gt; 
		/// (category name is optional)
		/// </summary>
		/// <param name="type">type string to check</param>
		/// <returns>True if the type string matches the filter</returns>
		public bool Match(string type)
		{
			if(type.Length<=0) // empty type string matches everything
				return true;

			if(!FilterEnabled)
				return true;

			if(type.IndexOf("::")>0)
			{
				int nIdx = type.IndexOf("::");
				string sCategory = type.Substring(0, nIdx);
				string sInfotype = type.Substring(nIdx+2);

				for(int i=0;i<_categories.Count;i++)
				{
					Category curCat = _categories[i] as Category;

					if(curCat.Name == sCategory)
					{
						for(int j=0; j<curCat.InformationTypes.Count; j++)
						{
							InformationType curType = curCat.InformationTypes[j] as InformationType;

							if(curType.Name == sInfotype)
								return true;
						}
					}
				}
			} 
			else 
			{
				for(int i=0;i<_informationTypes.Count;i++)
				{
					InformationType curType = _informationTypes[i] as InformationType;
					if(curType.Name == type)
						return true;
				}
			}

			return false;
		}

	}
}
