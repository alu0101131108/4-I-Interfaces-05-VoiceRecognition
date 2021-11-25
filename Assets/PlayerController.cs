using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed = 30.0f;
  public float LateralRotationSpeed = 100.0f;
  public float VerticalRotationSpeed = 100.0f;

  void Update()
  {
    float translation = Input.GetAxis("Vertical") * speed;
    float Yrotation = Input.GetAxis("Horizontal") * LateralRotationSpeed;
    float Xrotation = Input.GetAxis("Mouse ScrollWheel") * VerticalRotationSpeed;

    translation *= Time.deltaTime;
    Yrotation *= Time.deltaTime;
    Xrotation *= Time.deltaTime;

    // Move towards z axis
    transform.Translate(0, 0, translation);

    // Rotate around y axis
    transform.Rotate(0, Yrotation, 0);
    transform.Rotate(Xrotation, 0, 0);
  }
}
