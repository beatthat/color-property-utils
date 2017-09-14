using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Use a gradient texture to drive the color of a (sibling) HasColor component.
	/// Exposes the IHasFloat set_value interface, so this component can be used more easily in transitions (e.g. as an element of a TransitionsElements)
	/// 
	/// The gradient is read horizontally, to the texture can be sizes like 32x1. 
	/// The texture MUST be imported as readable
	/// </summary>
	public class ColorRampDrivesColor : HasFloat
	{
		public HasColor m_hasColor;
		public Texture2D m_colorRamp;
		public bool m_disabled;

		[Range(0f, 1f)]
		public float m_value;

		public override float value 
		{
			get {
				return m_value;
			}
			set {
				m_value = value;
				UpdateDisplay();
			}
		}
			
		public override bool sendsValueObjChanged { get { return false; } }

		private HasColor hasColor { get { return m_hasColor?? (m_hasColor = GetComponent<HasColor>()); } }
		private Texture2D colorRamp { get { return m_colorRamp; } }

		void OnEnable()
		{
			UpdateDisplay();
		}

		public void UpdateDisplay()
		{
			if(m_disabled) {
				return;
			}
			this.hasColor.value = this.colorRamp.GetPixelBilinear(0, this.value);
		}

		void OnDidApplyAnimationProperties()
		{
			UpdateDisplay();
		}
	}
}
