using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T prefab;
    [SerializeField] private Transform container;
    [SerializeField] private bool autoPool;
    [SerializeField] private List<T> pool;
    [SerializeField] private Vector3 vectorSpawn;
    public void CreatePool(int count)
    {
        pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObj();
        }
    }
    public T CreateObj(bool activeObj = false)
    {
        var newObj = UnityEngine.Object.Instantiate(prefab, vectorSpawn,Quaternion.identity,container);
        newObj.gameObject.SetActive(activeObj);
        pool.Add(newObj);
        return newObj;
    }
    public bool SearchFreeElement(out T element)
    {
        foreach (var elem in pool)
        {
            if(!elem.gameObject.activeInHierarchy)
            {
                element = elem;
                elem.gameObject.SetActive(true);
                elem.transform.position = vectorSpawn;
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeElement()
    {
        if(SearchFreeElement(out var element))
            return element;
        if(autoPool)
            return CreateObj(true);
      
        throw new Exception($"Объекта в пуле {typeof(T)} не найдено!");
    }
    public void GetVectorSpawn(Vector3 vector)
    {
        vectorSpawn = vector;
    }
}
