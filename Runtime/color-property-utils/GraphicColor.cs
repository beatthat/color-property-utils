using UnityEngine;
using UnityEngine.UI;

namespace BeatThat.Properties
{
    public class GraphicColor : HasColor, IDrive<Graphic>
	{
		public object GetDrivenObject ()
		{
			return this.graphic;
		}

		public bool ClearDriven ()
		{
			m_graphic = null;
			return true;
		}
			
		public Graphic driven { get { return this.graphic; } }

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

