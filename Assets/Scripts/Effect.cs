using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CorEffect());
        IEnumerator CorEffect()
        {
            yield return new WaitForSeconds(4f);
            gameObject.SetActive(false);
        }
    }
}
