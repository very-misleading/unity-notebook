using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// Get the GameObjects in children.
    /// </summary>
    /// <param name="parent">The parent transform</param>
    /// <param name="includeInactive">Do we include inactive children?</param>
    /// <returns></returns>
    public static GameObject[ ] GetGosInChildren( this Transform parent, bool includeInactive = true )
    {
        List<GameObject> gos = new List<GameObject>( );
        Transform[ ] transforms = parent.GetComponentsInChildren<Transform>(
            includeInactive
        );

        foreach ( Transform trans in transforms )
        {
            // Skip the parent transform itself
            if ( trans.Equals( parent ) ) continue;

            gos.Add( trans.gameObject );
        }

        return gos.ToArray( );
    }
}

