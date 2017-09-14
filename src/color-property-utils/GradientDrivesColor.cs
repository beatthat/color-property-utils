using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Use a gradient to drive the color of a (sibling) HasColor component.
	/// Exposes the IHasFloat set_value interface, so this component can be used more easily in transitions (e.g. as an element of a TransitionsElements)
	/// </summary>
	public class GradientDrivesColor : DisplaysFloat, IDrive<HasColor>
	{
		[SerializeField]private HasColor m_hasColor;
		[SerializeField]private Gradient m_gradient;
		[SerializeField]private GradientAsset m_gradientAsset;
		[SerializeField]private bool m_useGradientAsset;

		public HasColor driven { get { return m_hasColor?? (m_hasColor = GetComponent<HasColor>()); } }

		public object GetDrivenObject() { return this.driven; }

		public Gradient gradient { get { return m_useGradientAsset && m_gradientAsset != null? m_gradientAsset.gradient: m_gradient; } }

		override public void UpdateDisplay()
		{
			this.driven.value = this.gradient.Evaluate(this.value);
		}
	}
}
