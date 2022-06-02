using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Transform moon;
    public Transform Moon => moon;
    [SerializeField]private const float  pointFinish = 100f;
    public float PointFinish => pointFinish;
    [SerializeField] private float distance;
    public float Distance => distance;
    [SerializeField] private bool finish;
    public bool Finish => finish;
   
    private void LateUpdate()
    {
        if (!finish)
        {
            distance = (moon.position - transform.position).magnitude;
         
            if (distance <= pointFinish)
            {
                finish = true;
            }
        }
    }
}
