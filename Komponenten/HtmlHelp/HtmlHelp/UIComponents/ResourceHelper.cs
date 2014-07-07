using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// The class <c>ResourceHelper</c> implements methods for easy resource loading/using
	/// </summary>
	public sealed class ResourceHelper
	{
		/// <summary>
		/// Internal member storing the default resource namespace
		/// </summary>
		private string _defaultNamespace = "";
		/// <summary>
		/// Internal member storing the resource assembly
		/// </summary>
		private Assembly _resAssembly = null;
		/// <summary>
		/// Internal resource manager
		/// </summary>
		private ResourceManager m_resourceManager;
		/// <summary>
		/// Internal member storing the bitmap/icon/images default namepsace
		/// </summary>
		private string _defaultBitmapNamespace = "";
		/// <summary>
		/// Internal member storing the default namespace for string resources
		/// </summary>
		private string _defaultStringNamespace = "";

		/// <summary>
		/// Constructs a new resource helper class.
		/// </summary>
		/// <remarks>Uses "<c>Flextronics.eLounge2.Application</c>" as default namespace and the current module's assembly 
		/// as default resource assembly.</remarks>
		public ResourceHelper() : this("HtmlHelp", null)
		{
		}
		/// <summary>
		/// Constructs a new resource helper class.
		/// </summary>
		/// <param name="resAssembly">resource assembly</param>
		/// <remarks>Uses "<c>Flextronics.eLounge2.Application</c>" as default namespace.</remarks>
		public ResourceHelper(Assembly resAssembly) : this("HtmlHelp", resAssembly)
		{
		}
		/// <summary>
		/// Constructs a new resource helper class.
		/// </summary>
		/// <param name="defaultNamespace">default namespace for loading resources</param>
		/// <remarks>Uses the current module's assembly as default resource assembly.</remarks>
		public ResourceHelper(string defaultNamespace) : this (defaultNamespace, null)
		{
		}
		/// <summary>
		/// Constructs a new resource helper class.
		/// </summary>
		/// <param name="defaultNamespace">default namespace for loading resources</param>
		/// <param name="resAssembly">resource assembly</param>
		public ResourceHelper(string defaultNamespace, Assembly resAssembly)
		{
			if(resAssembly == null)
				_resAssembly = this.GetType().Module.Assembly;
			else
				_resAssembly = resAssembly;

			_defaultNamespace = defaultNamespace;
			
		}

		/// <summary>
		/// Gets the default resource namespace
		/// </summary>
		public string DefaultNamespace
		{
			get { return _defaultNamespace; }
		}

		/// <summary>
		/// Gets the default resource assembly
		/// </summary>
		public Assembly ResourceAssembly
		{
			get { return _resAssembly; }
		}

		/// <summary>
		/// Gets the name of the default resource assembly
		/// </summary>
		public string ResourceAssemblyName
		{
			get 
			{ 
				if(_resAssembly == null)
					return "";

				return _resAssembly.FullName; 
			}
		}

		/// <summary>
		/// Gets/sets the default namespace for loading bitmaps/icons/images etc.
		/// </summary>
		/// <remarks>This namespace will be combined with the <see cref="DefaultNamespace">DefaultNamespace</see> property.</remarks>
		public string DefaultBitmapNamespace
		{
			get { return _defaultBitmapNamespace; }
			set { _defaultBitmapNamespace = value; }
		}

		/// <summary>
		/// Gets/sets the default namespace for loading string resources.
		/// </summary>
		/// <remarks>This namespace will be combined with the <see cref="DefaultNamespace">DefaultNamespace</see> property.</remarks>
		public string DefaultStringNamespace
		{
			get { return _defaultStringNamespace; }
			set { _defaultStringNamespace = value; }
		}

		/// <summary>
		/// Loads a bitmap from the combined resources and returns an <see cref="System.Drawing.Bitmap">Bitmap</see> instance to the caller.
		/// </summary>
		/// <param name="name">name of the bitmap file/resource</param>
		/// <returns>Returns an <see cref="System.Drawing.Bitmap">Bitmap</see> instance to the caller.</returns>
		public Bitmap LoadBitmap(string name)
		{
			return LoadBitmap(DefaultBitmapNamespace, name);
		}

		/// <summary>
		/// Loads an icon from the combined resources and returns an <see cref="System.Drawing.Bitmap">Bitmap</see> instance to the caller.
		/// </summary>
		/// <param name="bmpNamespace">bitmap namespace used for loading the resource</param>
		/// <param name="name">name of the bitmap file/resource</param>
		/// <returns>Returns an <see cref="System.Drawing.Bitmap">Bitmap</see> instance to the caller.</returns>
		/// <remarks>The bitmap namespace will be combined with the <see cref="DefaultNamespace">DefaultNamespace</see> property.</remarks>
		public Bitmap LoadBitmap(string bmpNamespace, string name)
		{
			string fullNamePrefix = CombineResource(DefaultNamespace, bmpNamespace);
			return new Bitmap(ResourceAssembly.GetManifestResourceStream(CombineResource(fullNamePrefix, name)));
		}

		/// <summary>
		/// Loads a bitmap from the combined resources and returns an <see cref="System.Drawing.Icon">Icon</see> instance to the caller.
		/// </summary>
		/// <param name="name">name of the icon file/resource</param>
		/// <returns>Returns an <see cref="System.Drawing.Bitmap">Bitmap</see> instance to the caller.</returns>
		public Icon LoadIcon(string name)
		{
			return LoadIcon(DefaultBitmapNamespace, name);
		}

		/// <summary>
		/// Loads an icon from the combined resources and returns an <see cref="System.Drawing.Icon">Icon</see> instance to the caller.
		/// </summary>
		/// <param name="bmpNamespace">bitmap namespace used for loading the resource</param>
		/// <param name="name">name of the icon file/resource</param>
		/// <returns>Returns an <see cref="System.Drawing.Icon">Icon</see> instance to the caller.</returns>
		/// <remarks>The bitmap namespace will be combined with the <see cref="DefaultNamespace">DefaultNamespace</see> property.</remarks>
		public Icon LoadIcon(string bmpNamespace, string name)
		{
			string fullNamePrefix = CombineResource(DefaultNamespace, bmpNamespace);
			return new Icon(ResourceAssembly.GetManifestResourceStream(CombineResource(fullNamePrefix, name)));
		}

		/// <summary>
		/// Loads a resource string from.
		/// </summary>
		/// <param name="name">name of the string resource</param>
		/// <returns>Returns a string value for the given resource name</returns>
		public string GetString(string name)
		{
			return GetString(DefaultStringNamespace, name);
		}

		/// <summary>
		/// Loads a resource string from.
		/// </summary>
		/// <param name="strNamespace">namespace for loading string resources</param>
		/// <param name="name">name of the string resource</param>
		/// <returns>Returns a string value for the given resource name</returns>
		/// <remarks>The string namespace will be combined with the <see cref="DefaultNamespace">DefaultNamespace</see> property.</remarks>
		public string GetString(string strNamespace, string name)
		{
			m_resourceManager = new ResourceManager(CombineResource(_defaultNamespace, strNamespace), _resAssembly);
			return m_resourceManager.GetString(name);
		}

		/// <summary>
		/// Combines two namespacestrings into one.
		/// </summary>
		/// <param name="namePrefix">namespace prefix</param>
		/// <param name="resourceName">resource name or sub namespace</param>
		/// <returns>A combine resource name or resource namespace name</returns>
		private string CombineResource(string namePrefix, string resourceName)
		{
			if( namePrefix[ namePrefix.Length-1 ] != '.')
				namePrefix += ".";

			return namePrefix + resourceName;
		}
	}
}
