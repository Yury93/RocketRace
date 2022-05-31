using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail : MonoBehaviour
{
    [SerializeField] private float speed;
    private DetailsController controller;
    public bool Active { get; private set; }
    private void Awake()
    {
        Active = true;
        controller = GetComponentInParent<DetailsController>();
        controller.OnBranchDetails += OnBranch;
    }

    private void OnBranch()
    {
        if(!Active)
        {
            print("отделение детали");
        }
    }
    public void DisActivated(bool isActive)
    {
        Active = isActive;
    }
    public float GetSpeedDetail()
    {
        return speed;
    }
}
