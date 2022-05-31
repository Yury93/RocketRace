using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailsController : MonoBehaviour
{
    [SerializeField] private Detail prefabDetail;
    [SerializeField] private List<Detail> detailes;
    [SerializeField] private int countDetailes;
    [SerializeField] private float partGap;
    private Vector3 posNewDetail;

    [SerializeField] private float timer;
    private float startTimer;
    public Action OnBranchDetails;
    private void Start()
    {
        startTimer = timer;
        posNewDetail = transform.position;

        for (int i = 0; i < countDetailes; i++)
        {
            SpawnDetail(posNewDetail);
        }
    }
    public void SpawnDetail(Vector3 pos)
    {
        var detail = Instantiate(prefabDetail, pos, Quaternion.identity,gameObject.transform);
        posNewDetail = new Vector3(pos.x, pos.y, pos.z - partGap);
        detailes.Add(detail);
    }
    public void FixedUpdate()
    {
        if (detailes.Count > 0)
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                detailes[detailes.Count-1].DisActivated(false);
                OnBranchDetails?.Invoke();
                RemoveDetails(detailes.Count-1);
                timer = startTimer;
            }
        }
    }
    public void RemoveDetails(int i)
    {
        if (detailes.Count > 0)
        {
            detailes.RemoveAt(i);
        }
    }
}
