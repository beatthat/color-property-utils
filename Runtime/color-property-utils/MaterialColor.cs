using UnityEngine;

namespace BeatThat.Properties
{
    public class MaterialColor : HasColor 
	{
		public string m_colorProperty = "_Color";
		public HasMaterial m_hasMaterial;


		override public Color value
		{
			get {
				return this.hasMaterial.material.GetColor(m_colorProperty);
			}
			set {
				this.hasMaterial.material.SetColor(m_colorProperty, value);
			}
		}

		public override bool sendsValueObjChanged { get { return false; } }
		public override object valueObj { get { return this.value; } }


		private HasMaterial hasMaterial { get { return m_hasMaterial?? (m_hasMaterial = GetComponent<HasMaterial>()); } }
	}
}

