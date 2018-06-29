using UnityEditor;
using UnityEngine;

namespace BeatThat.Properties
{
    [CustomEditor(typeof(GradientDrivesColor), true)]
	[CanEditMultipleObjects]
	public class GradientDrivesColorEditor : DisplaysFloatEditor
	{
		override protected void OnDisplaysFloatInspectorGUI() 
		{
			var hasColorProp = this.serializedObject.FindProperty("m_hasColor");
			EditorGUILayout.PropertyField(hasColorProp, new GUIContent("Target", "HasColor component that will be colored by this gradient"));

			PropertyBindingEditor.HandleDrivenProperty<Color> (this.target, hasColorProp, true);

			var valueProp = this.serializedObject.FindProperty("m_value");
			EditorGUILayout.Slider(valueProp, 0f, 1f);

			var useGradientAssetProp = this.serializedObject.FindProperty("m_useGradientAsset");

			if(useGradientAssetProp.boolValue) {
				var gradientAssetProp = this.serializedObject.FindProperty("m_gradientAsset");
				EditorGUILayout.PropertyField(gradientAssetProp, new GUIContent("Gradient", "a shared GradientAsset for places where you want consistency"));
			}
			else {
				var gradientProp = this.serializedObject.FindProperty("m_gradient");
				EditorGUILayout.PropertyField(gradientProp);
			}

			EditorGUILayout.PropertyField(useGradientAssetProp, new GUIContent("Use GradientAsset", "Use a shared gradient asset or a local gradient property?"));

			var updateDisplayOnEnableProp = this.serializedObject.FindProperty("m_updateDisplayOnEnable");
			EditorGUILayout.PropertyField(updateDisplayOnEnableProp);

			EditPropertyBindings (this.serializedObject, this.target.GetType());

			this.serializedObject.ApplyModifiedProperties();

		}
	}
}
