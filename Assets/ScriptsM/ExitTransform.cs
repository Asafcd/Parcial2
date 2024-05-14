using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public static class ExitTransform
{

    public static void DestroyChilodren(this Transform t, bool destroyInmediatel = false) {
        foreach (Transform child  in t)
        {
            if(destroyInmediatel)
            {
                MonoBehaviour.DestroyImmediate(child.gameObject);
            }
            else{
                MonoBehaviour.Destroy(child.gameObject);
            }
        }

    }

   
}
