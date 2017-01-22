using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Target : MonoBehaviour {
  public double speed = 1;
  public Vector3 direction = Vector3.right;

  private bool started = false;

  void Start() {
  }

  void Update() {
    if (Input.GetKeyDown("space")) {
      started = true;
    }

    if (started) {
      transform.position += ((float)(Time.deltaTime * speed) * direction);
    }
  }
}
