using UnityEngine.UI;
using UnityEngine;
using BeatThat.ColorExtensions;

namespace BeatThat.UI.UnityUI
{
	/// <summary>
	/// Expose a color as a text property. Useful if your generating some formatted text
	/// with inline color changes and you want to use a ColorAsset (for consistency)
	/// rather than hard coding the color values in to the text/format string.
	/// </summary>
	public class ColorValueText : HasText 
	{
		public HasColor m_hasColor;
		public string m_defaultColorValueText = "";

		public override string value 
		{
			get { 
				var hc = this.hasColor;
				if (hc == null) {
					return m_defaultColorValueText;
				}

				return hc.value.ToHex();
			}
			set { }
		}

		public override bool sendsValueObjChanged { get { return false; } }
		public override object valueObj { get { return this.value; } }


		public HasColor hasColor { get { return m_hasColor?? (m_hasColor = GetComponent<HasColor>()); } }

		void Reset()
		{
			m_hasColor = GetComponent<HasColor>();
			if (m_hasColor == null) {
				m_hasColor = this.AddIfMissing<ColorProperty> ();
			}
		}
	}
}
