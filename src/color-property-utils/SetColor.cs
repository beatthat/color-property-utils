using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Set the color on of a target HasColor OnEnable.
	/// 
	/// Useful for multi-state UI layouts: when the layout lands on a new state, 
	///	that state's (set of) SetColor components can be activated 
	/// to set the colors of UI components for the state.
	/// 
	/// This can be important as a consistency measure even if inter-state transitions 
	/// *usually* complete and bring all colors to their state targets.
	/// </summary>
	public class SetColor : MonoBehaviour, IDrive<HasColor>
	{
		[SerializeField]private HasColor m_hasColor;
		[SerializeField]private ColorAsset m_colorAsset;
		[SerializeField]private Color m_color;
		[SerializeField]private bool m_useColorAsset;

		public HasColor driven { get { return m_hasColor?? (m_hasColor = GetComponent<HasColor>()); } }

		public object GetDrivenObject() { return this.driven; }

		public Color color { get { return m_useColorAsset && m_colorAsset != null? m_colorAsset.value: m_color; } }

		void OnEnable()
		{
			UpdateDisplay();
		}

		public void UpdateDisplay()
		{
			var d = this.driven;
			if(d == null) {
				if(!Application.isPlaying) {
					return;
				}
				#if BT_DEBUG_UNSTRIP
				Debug.LogWarning("[" + Time.frameCount + "][" + this.Path() + "] driven HasColor for SetColor is not set");
				#endif
				return;
			}
			d.value = this.color;
		}

		void OnDidApplyAnimationProperties()
		{
			UpdateDisplay();
		}

		void Reset()
		{
			m_hasColor = GetComponent<HasColor>();
		}
			
	}
}
