using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoon : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime);
    }
}
