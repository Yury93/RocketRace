using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AIShip : Ship
{
   [SerializeField]private float speed;
    [SerializeField] private float timer;
    private float startTimer;

    private void Start()
    {
        startTimer = timer;
        speed = Random.Range(15, 35);
    }

   private void Update()
    {
        if (!Finish)
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            timer -= Time.deltaTime;
            if (timer < 0)
            {

                timer = startTimer;
            }
        }
    }
}
