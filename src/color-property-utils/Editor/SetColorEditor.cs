using UnityEditor;
using UnityEngine;

namespace BeatThat
{
	[CustomEditor(typeof(SetColor), true)]
	[CanEditMultipleObjects]
	public class SetColorEditor : UnityEditor.Editor
	{
		override public void OnInspectorGUI() 
		{
			EditorGUI.BeginChangeCheck();

			var hasColorProp = this.serializedObject.FindProperty("m_hasColor");
			EditorGUILayout.PropertyField(hasColorProp, new GUIContent("Target", "HasColor component that will be colored by this color"));

			var useAssetProp = this.serializedObject.FindProperty("m_useColorAsset");

			if(useAssetProp.boolValue) {
				var assetProp = this.serializedObject.FindProperty("m_colorAsset");
				EditorGUILayout.PropertyField(assetProp, new GUIContent("Color", "a shared ColorAsset for places where you want consistency"));
			}
			else {
				var colorProp = this.serializedObject.FindProperty("m_color");
				EditorGUILayout.PropertyField(colorProp);
			}

			EditorGUILayout.PropertyField(useAssetProp, new GUIContent("Use Color Asset", "Use a shared color asset or a local color property?"));

			this.serializedObject.ApplyModifiedProperties();

			if(EditorGUI.EndChangeCheck()) {
				(this.target as SetColor).UpdateDisplay();
			}


		}
	}
}