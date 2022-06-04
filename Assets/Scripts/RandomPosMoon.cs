using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosMoon : MonoBehaviour
{
    private void Start()
    {
        int rnd = Random.Range(1400, 2300);
        transform.position = new Vector3(transform.position.x, transform.position.y, rnd);
    }
}
