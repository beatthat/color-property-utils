using UnityEngine;

namespace BeatThat.UI.UnityUI
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

//		#region implemented abstract members of HasColor
//		override protected Color GetColor() 
//		{
//			return m_color;
//		}
//
//		override protected void _SetColor(Color c)
//		{
//			m_color = c;
//			foreach(var i in this.group) {
//				i.color = c;
//			}
//		}
//		#endregion

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
