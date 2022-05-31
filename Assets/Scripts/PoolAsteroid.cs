using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolAsteroid : PoolObjects<Asteroid>
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceOfPlayer;
    [SerializeField] private float timeAplications;
    [SerializeField] private float radius;
    private float startTime;
    private void Start()
    {
        startTime = timeAplications;
    }
    private void FixedUpdate()
    {
        if (player)
        {
            timeAplications -= Time.fixedDeltaTime;
            if (timeAplications <= 0)
            {
                transform.position = new Vector3(player.transform.position.x,
                    player.transform.position.y,
                    player.transform.position.z + distanceOfPlayer);
                GetVectorSpawn(RandomCircle(transform.position, this.radius));
                GetFreeElement();
                timeAplications = startTime;
            }
        }
    }
    public Vector3 RandomCircle(Vector3 center, float radius)
    {
        var ang = Random.value * 360;
        Vector3 pos = new Vector3();
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z + radius * Mathf.Tan(ang * Mathf.Deg2Rad);
        return pos;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
