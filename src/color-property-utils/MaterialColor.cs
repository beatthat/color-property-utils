using UnityEngine;

namespace BeatThat
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

//		#region implemented abstract members of HasColor
//		override protected Color GetColor() 
//		{
//			return this.hasMaterial.material.GetColor(m_colorProperty);
//		}
//
//		override protected void _SetColor(Color c)
//		{
//			this.hasMaterial.material.SetColor(m_colorProperty, c);
//		}
//		#endregion

		private HasMaterial hasMaterial { get { return m_hasMaterial?? (m_hasMaterial = GetComponent<HasMaterial>()); } }
	}
}
