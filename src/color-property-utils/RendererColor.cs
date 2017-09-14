using UnityEngine;

namespace BeatThat
{
	public class RendererColor : HasColor 
	{
		public string m_colorProperty = "_Color";
		public Renderer m_renderer;

		override public Color value
		{
			get {
				return this.material.GetColor(m_colorProperty);
			}
			set {
				this.material.SetColor(m_colorProperty, value);
			}
		}

		public override bool sendsValueObjChanged { get { return false; } }
		public override object valueObj { get { return this.value; } }

//		#region implemented abstract members of HasColor
//		override protected Color GetColor() 
//		{
//			return this.material.GetColor(m_colorProperty);
//		}
//
//		override protected void _SetColor(Color c)
//		{
//			this.material.SetColor(m_colorProperty, c);
//		}
//		#endregion

		private Material material { get { return m_material?? (m_material = this._renderer.material); } }
		private Material m_material;

		private Renderer _renderer { get { return m_renderer?? (m_renderer = GetComponent<Renderer>()); } }
	}
}
