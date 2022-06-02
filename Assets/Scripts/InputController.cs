using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InputController : MonoBehaviour
{
    [SerializeField] private Joystick joystickMove;
    [SerializeField] private float speedForward;
    [SerializeField] private float speedOffset = 1f;
    private Rigidbody rb;
    [SerializeField] private Ship ship;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ship = GetComponent<Ship>();
    }
    void Update()
    {
        if (!ship.Finish)
        {
            var directMove = new Vector3(joystickMove.Horizontal, joystickMove.Vertical, 1);
            rb.AddForce(directMove * speedForward * Time.deltaTime, ForceMode.Impulse);
        }
            var directRotate = new Vector3(0, 0, joystickMove.Horizontal);
            rb.AddTorque(-directRotate * speedForward * speedOffset * Time.deltaTime, ForceMode.Impulse);
    }
    public void SetSpeed( float speedForward = 0, float speedOffset = 0)
    {
        this.speedForward += speedForward;
        this.speedOffset += speedOffset;
    }
}
