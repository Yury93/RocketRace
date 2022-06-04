using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IObstacle
{
    [SerializeField] private AudioSource explosion;
    [SerializeField] private float timeLives;
    [SerializeField] private float speed;
    private float startSpeed;
    [SerializeField] private Rigidbody rigidbody;
    private float startTime;
    private void Awake()
    {
        startTime = timeLives;
        startSpeed = speed;
    }
    private void OnDisable()
    {
        timeLives = startTime;
        speed = startSpeed;
    }
    public void DisableObstacle(float t)
    {
        timeLives -= Time.fixedDeltaTime;
        if (timeLives <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        rigidbody.AddForce(-Vector3.forward * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        DisableObstacle(timeLives);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var ship = collision.gameObject.GetComponentInParent<InputController>();
        if(ship)
        {
            EffectContainer.Instance.CreateExplosion(collision.gameObject.transform.position);

            explosion.Play();
            Destroy(ship.gameObject);
            SceneController.Instance.SceneLose();
        }
    }
}
