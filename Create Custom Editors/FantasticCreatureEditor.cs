using UnityEditor;

[CustomEditor(typeof(FantasticCreature))]
public class FantasticCreatureEditor : Editor
{
    private SerializedProperty m_health;
    private SerializedProperty m_name;

    public override void OnInspectorGUI( )
    {
        serializedObject.Update( );

        EditorGUILayout.PropertyField( m_name );
        EditorGUILayout.PropertyField( m_health );

        serializedObject.ApplyModifiedProperties( );
    }

    private void OnEnable( )
    {
        m_health = serializedObject.FindProperty( "m_health" );
        m_name = serializedObject.FindProperty( "m_name" );
    }
}
