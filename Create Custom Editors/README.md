# Create Custom Editors
## The Basic Structure of the Custom Editor Script
Suppose you have a class such as:

```
public class FantasticCreature : MonoBehaviour
{
    [SerializeField] private float m_health = 10;
    [SerializeField] private string m_name = "Dragon";
}
```

You can change how you view and edit the component in the Inspector window. Start with creating an empty Custom Editor script.
```
using UnityEditor;

// The line below tells Unity that this is the default way of displaying/editing the component type.
[CustomEditor(typeof(FantasticCreature))]
public class FantasticCreatureEditor : Editor
{
    // Use the method below to change how Unity displays/edits the component.
    public override void OnInspectorGUI( )
    {
        
    }
}
```

If you look at the Inspector window now, you'll notice that the FantasticCreature shows up completely empty.

## How to Add Fields
Unity has useful methods for displaying and editing the fields. When you use them, Unity handles undo and redo actions.

You will need to use [SerializedObject](https://docs.unity3d.com/ScriptReference/SerializedObject.html) and [SerializedProperty](https://docs.unity3d.com/ScriptReference/SerializedProperty.html) classes.

First, let's find the properties we want to edit. This can be done in the OnEnable method.

```
[CustomEditor(typeof(FantasticCreature))]
public class FantasticCreatureEditor : Editor
{
    private SerializedProperty m_health;
    private SerializedProperty m_name;

    [,,,]

    private void OnEnable( )
    {
        // Find specified properties to edit, by using their names in the target script.
        m_health = serializedObject.FindProperty( "m_health" );
        m_name = serializedObject.FindProperty( "m_name" );
    }
}
```

After that, you can draw the fields:

```
[CustomEditor(typeof(FantasticCreature))]
public class FantasticCreatureEditor : Editor
{
    [...]

    public override void OnInspectorGUI( )
    {
        // Display the fields in the default manner.
        EditorGUILayout.PropertyField( m_name );
        EditorGUILayout.PropertyField( m_health );
    }

    [...]
}
```

When you look at the inspector window, you see the fields. However, when you try to edit the fields, you will soon notice that no changes are saved. You need to tell Unity to store the changes:

```
[CustomEditor(typeof(FantasticCreature))]
public class FantasticCreatureEditor : Editor
{
    [...]

    public override void OnInspectorGUI( )
    {
        EditorGUILayout.PropertyField( m_name );
        EditorGUILayout.PropertyField( m_health );

        // This does the trick
        serializedObject.ApplyModifiedProperties( );
    }

    [...]
}
```

But we aren't done yet! You might wish to undo your changes while you are _actively_ editing a field, such as the name of the creature. Right now, undo _seems_ to do nothing to such a field _as long as it's active_. Click elsewhere, and the field becomes updated to show the data as it should be.

```
[CustomEditor(typeof(FantasticCreature))]
public class FantasticCreatureEditor : Editor
{
    [...]

    public override void OnInspectorGUI( )
    {
        // This fixes the problem
        serializedObject.Update( );

        EditorGUILayout.PropertyField( m_name );
        EditorGUILayout.PropertyField( m_health );

        serializedObject.ApplyModifiedProperties( );
    }

    [...]
}
```

## Customized Property Fields
The point of customized editors is to change the default appearances and/or behavior. The example below turns the health field to a slider, with a range from 0 to 100.

```
[CustomEditor(typeof(FantasticCreature))]
public class FantasticCreatureEditor : Editor
{
    [...]

    public override void OnInspectorGUI( )
    {
        serializedObject.Update( );

        EditorGUILayout.PropertyField( m_name );

        // Show a slider instead of the default field.
        EditorGUILayout.Slider( m_health, 0f, 100f );

        serializedObject.ApplyModifiedProperties( );
    }

    [...]
}
```

![The result looks like this](/Images/Slider.png)


## Additional Links
[Unity Answers: Why SerializedProperty.Update is called in the beginning?](https://answers.unity.com/questions/1455633/why-serializedpropertyupdate-is-called-in-the-begi.html)