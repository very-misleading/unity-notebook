using UnityEditor;

[CustomEditor(typeof(FantasticCreature))]
public class FantasticCreatureEditor : Editor
{
    private SerializedProperty m_health;
    private SerializedProperty m_name;
    private SerializedProperty m_description;

    private bool m_editStringValues = false;

    public override void OnInspectorGUI( )
    {
        serializedObject.Update( );

        m_editStringValues = EditorGUILayout.BeginToggleGroup( "String values", m_editStringValues );
        EditorGUILayout.PropertyField( m_name );
        EditorGUILayout.PropertyField( m_description );
        EditorGUILayout.EndToggleGroup( );

        EditorGUILayout.Slider( m_health, 0f, 100f );

        serializedObject.ApplyModifiedProperties( );
    }

    private void OnEnable( )
    {
        m_health = serializedObject.FindProperty( "m_health" );
        m_name = serializedObject.FindProperty( "m_name" );
        m_description = serializedObject.FindProperty( "m_description" );
    }
}
