using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailsController : MonoBehaviour
{
    [SerializeField] private bool ai;
    [SerializeField] private Detail prefabDetail;
    [SerializeField] private List<Detail> detailes;
    public List<Detail> Details => detailes;
    [SerializeField] private int countDetailes;
    [SerializeField] private float partGap;
    public float PartGap => partGap;
     private Vector3 posNewDetail;
    
    [SerializeField] private float timer;
    private float startTimer;
    public Action OnBranchDetails;
    [SerializeField] private bool menu;
    private void Start()
    {
        startTimer = timer;
        posNewDetail = transform.position;

        if (!ai)
        {
            countDetailes = PlayerPrefs.GetInt("CountDetails");
        }

        for (int i = 0; i < countDetailes; i++)
        {
            SpawnDetail(posNewDetail);
        }
    }
   
    public void SpawnDetail(Vector3 pos)
    {
        
            var detail = Instantiate(prefabDetail, pos, Quaternion.identity, this.gameObject.transform);
        if (menu)
        {
            detail.SetMenu();
        }
            posNewDetail = new Vector3(pos.x, pos.y, pos.z - partGap);
            detailes.Add(detail);
    }
    public void Update()
    {
        if (detailes.Count > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                print(detailes.Count - 1);
                RemoveDetails(detailes.Count-1);
               
                timer = startTimer;
            }
        }
    }
    public void RemoveDetails(int i)
    {
        print(i);
        detailes[i].DisActivated(false);
       
        detailes.RemoveAt(i);
        OnBranchDetails?.Invoke();
        //OnBranchDetails?.Invoke();
    }
}
