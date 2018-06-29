using BeatThat.CollectionsExt;
using BeatThat.ColorAssets;
using BeatThat.GetComponentsExt;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BeatThat.Properties
{
    // NOTE: because we want to do things with sibling components, 
    // it would be hard to support CanEditMultipleObjects
    // Turning it on will lead to broken behaviour
    [CustomEditor(typeof(SetColor), true)]
	public class SetColorEditor : UnityEditor.Editor
	{
		/// <summary>
		/// if we go and change the color of a SetColor's ColorAsset, we want to detect and propagate that change, so...
		/// </summary>
		public Color? m_lastAssetColor;

		override public void OnInspectorGUI() 
		{
			var setColor = (this.target as SetColor);

			EditorGUI.BeginChangeCheck();

			var hasColorProp = this.serializedObject.FindProperty("m_hasColor");
			EditorGUILayout.PropertyField(hasColorProp, new GUIContent("Target", "HasColor component that will be colored by this color"));

			if (!Application.isPlaying) {
				var hasColor = hasColorProp.objectReferenceValue as HasColor;
				if (hasColor == null) {
					hasColor = setColor.GetComponent<HasColor> ();
					if (hasColor == null && setColor.GetComponent<Graphic> () != null) {
						hasColor = setColor.AddIfMissing<GraphicColor>();
					}
					hasColorProp.objectReferenceValue = hasColor;
				}
			}

			var useAssetProp = this.serializedObject.FindProperty("m_useColorAsset");

			if(useAssetProp.boolValue) {
				var assetProp = this.serializedObject.FindProperty("m_colorAsset");
				EditorGUILayout.PropertyField(assetProp, new GUIContent("Color", "a shared ColorAsset for places where you want consistency"));
				var colorAsset = assetProp.objectReferenceValue as ColorAsset;
				if (colorAsset != null && (!m_lastAssetColor.HasValue || m_lastAssetColor.Value != colorAsset.value)) {
					m_lastAssetColor = colorAsset.value;
					setColor.UpdateDisplay ();
				}
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


