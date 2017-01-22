using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
  public float speed = 20f;
  void Start() {
  }

  void Update() {
    if(Camera.current == null) { return; }

    float xAxisValue = Input.GetAxis("Horizontal") * speed;
    float yAxisValue = Input.GetAxis("Vertical") * speed;
    Camera.current.transform.Rotate(new Vector3(0, 0, xAxisValue));
  }
}
