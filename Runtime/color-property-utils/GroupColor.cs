using UnityEngine;

namespace BeatThat.Properties
{
    public class GroupColor : HasColor 
	{
		public Color m_color;
		public HasColor[] m_group;


		public override Color value 
		{
			get { return m_color; }
			set { 
				m_color = value;
				foreach(var i in this.group) {
					i.value = m_color;
				}
			}
		}

		public override bool sendsValueObjChanged { get { return false; } }
		public override object valueObj { get { return this.value; } }


		public HasColor[] group 
		{
			get { 
				if(m_group == null || m_group.Length == 0) {
					m_group = this.GetComponentsInChildren<HasColor>(true);
				}
				return m_group;
			} 
		}

	}
}

