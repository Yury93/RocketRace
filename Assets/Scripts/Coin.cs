using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioSource cash;
    [SerializeField] private float timeLives;
   [SerializeField] private int speed,rotateSpeed;
    [SerializeField] private GameObject childObj;
 
    private void Start()
    {
        StartCoroutine(CorDisable());
        IEnumerator CorDisable()
        {
            yield return new WaitForSeconds(timeLives);
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
        childObj.transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        var ship = other.GetComponentInParent<InputController>();
        if(ship)
        {
            EffectContainer.Instance.GetVectorSpawn(gameObject.transform.position);
            EffectContainer.Instance.GetFreeElement();
            ship.GetComponentInChildren<AudioSource>().Play();
            UIController.Instance.AddScore(1);
            gameObject.SetActive(false);
        }
    }
}
