using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Target : MonoBehaviour {
  public double speed = 1;
  public Vector3 direction = Vector3.right;

  void Start() {
  }

  void Update() {
    if(Camera.current == null) { return; }

    transform.position += ((float)(Time.deltaTime * speed) * direction);
  }
}
