using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnim : MonoBehaviour
{
    public void DestroyParent()
    {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }
}
