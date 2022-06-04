using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMoon : MonoBehaviour
{
    [SerializeField] private Transform moon;
   public void SetParent()
    {
        gameObject.transform.parent = moon;
    }
}
