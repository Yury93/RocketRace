using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectContainer : PoolObjects<Effect>
{
    public static EffectContainer Instance;
    [SerializeField] private GameObject explosion;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this.gameObject.GetComponent<EffectContainer>();
        }
    }
    public void CreateExplosion(Vector3 pos)
    {
        var p = Instantiate(explosion, pos, Quaternion.identity);
        
    }
}
