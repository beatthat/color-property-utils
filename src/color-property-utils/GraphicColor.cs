using UnityEngine.UI;
using UnityEngine;

namespace BeatThat.UI.UnityUI
{
	public class GraphicColor : HasColor 
	{
		public Graphic m_graphic;

		public override Color value 
		{
			get { return this.graphic.color; }
			set { this.graphic.color = value; }
		}

		public override bool sendsValueObjChanged { get { return false; } }
		public override object valueObj { get { return this.value; } }


		public Graphic graphic { get { return m_graphic?? (m_graphic = GetComponent<Graphic>()); } }

		void Reset()
		{
			m_graphic = GetComponent<Graphic>();
		}
	}
}
