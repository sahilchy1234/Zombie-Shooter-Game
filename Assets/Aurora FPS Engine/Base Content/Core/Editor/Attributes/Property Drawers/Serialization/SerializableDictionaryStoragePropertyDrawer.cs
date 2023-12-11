/* ==================================================================
   ----------------------------------------------------------------
   Project   :   Aurora FPS Engine
   Publisher :   Infinite Dawn
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright © 2017 Tamerlan Shakirov All rights reserved.
   ================================================================== */

using UnityEngine;
using UnityEditor;
using AuroraFPSRuntime.CoreModules.Serialization.Collections;

namespace AuroraFPSEditor.Attributes
{
    /// <summary>
    /// Custom property drawers SerializableDictionaryBase.Storage class.
    /// </summary>
    [DrawerTarget(typeof(SerializationStorageBase), SubClasses = true)]
    public class SerializableDictionaryStoragePropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Override this method to make your own IMGUI based GUI for the property.
        /// </summary>
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.Next(true);
            EditorGUI.PropertyField(position, property, label, true);
        }

        /// <summary>
        /// Override this method to specify how tall the GUI for this field is in pixels.
        ///
        /// The default is one line high.
        /// </summary>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// <returns>The height in pixels.</returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            property.Next(true);
            return EditorGUI.GetPropertyHeight(property);
        }
    }
}