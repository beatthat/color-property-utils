using UnityEngine;

namespace BeatThat.Properties
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


		private Material material { get { return m_material?? (m_material = this._renderer.material); } }
		private Material m_material;

		private Renderer _renderer { get { return m_renderer?? (m_renderer = GetComponent<Renderer>()); } }
	}
}

