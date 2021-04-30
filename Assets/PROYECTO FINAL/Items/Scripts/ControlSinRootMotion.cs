using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSinRootMotion : MonoBehaviour
{
    public CharacterController _controller;
    public float _speed = 10;
    public float _rotSpeed = 180;
    private Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        // Lee input horizontal para orientar en eje Y
        this.rotation = new Vector3(0, H * _rotSpeed * Time.deltaTime, 0);
        // Lee input vertical para crear traslación en Z
        Vector3 move = new Vector3(0, 0, V * Time.deltaTime);
        // Crea el vector de movimiento en la dir. del personaje
        move = this.transform.TransformDirection(move);
        // Aplica el movimiento al CHARACTER CONTROLLER
        _controller.Move(move * _speed);
        // Aplica la rotación al OBJETO
        this.transform.Rotate(this.rotation);
    }
}
