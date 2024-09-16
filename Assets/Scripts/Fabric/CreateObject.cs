using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class CreateObject
{

    public static T Creator<T>(string path) where T : Component
    {
        var create = Resources.Load<GameObject>(path);

        var scr = create.AddComponent<T>();

        return scr;
    }

}
