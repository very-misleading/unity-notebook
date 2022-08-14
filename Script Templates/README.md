# Script Templates
When you create a new script through Unity's menu (Assets/Create/C# Script), Unity Editor uses a script template to generate its contents.

81-Scriptable-NewScriptableObject.cs.txt is an example of a template script.

You can write custom script templates to suit your specific needs.

## Create the folder
In your Unity project, create a new folder in Assets: ScriptTemplates.

## Create an empty template file
Add a new text file to ScriptTemplates folder. Use this pattern to name it: 

**{Number}-{Display Name}-{DefaultName}.cs.txt**

**{Number}** affects the placement of the menu item in the dropdown list. Multiple templates can share this same number.

You can see the **{Display Name}** in the dropdown list.

**{DefaultName}**.cs is the name of the new file before you rename it.

Note that the template file needs to be a txt file.

## Add content to the template file
This is the template file Unity uses to generate default C# scripts.

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#ROOTNAMESPACEBEGIN#
public class #SCRIPTNAME# : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        #NOTRIM#
    }

    // Update is called once per frame
    void Update()
    {
        #NOTRIM#
    }
}
#ROOTNAMESPACEEND#
```

Most of it is familiar. There are some special variables, though:

When you give the new file a name, `#SCRIPTNAME#` will be replaced with it.

`#NOTRIM#` sets the indentation for lines that have only whitespace.

`#ROOTNAMESPACEBEGIN#` will be replaced with `namespace [...] {`, assuming that you have defined a root namespace. Otherwise, this will be left as an empty line.

`#ROOTNAMESPACEEND#`marks the end of the namespace.

## Restart Unity
You will see your templates listed in Unity's Assets/Create menu after you have restarted Unity.

## Sources and further information
[Unity Answers: Is it possible to create several different script templates?](https://answers.unity.com/questions/1253204/is-it-possible-to-create-several-different-script.html)
[Unity Forum: What is #NOTRIM# for?](https://forum.unity.com/threads/what-is-notrim-for-and-using-other-monobehaviour-template-built-in-magic-variables.466694/)

[Instructions for changing Unity's default templates](https://support.unity.com/hc/en-us/articles/210223733-How-to-customize-Unity-script-templates) (Note that these changes might become overwritten)
