using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFlash : MonoBehaviour {
  private double tau = 2 * Math.PI;

  public float speed = 0.1f;

  public double accumulator = 0;

  void Start() {
  }

  void Update() {
    if(Camera.current == null) { return; }

    accumulator += Time.deltaTime;

    if (accumulator >= speed) {
      if (Camera.current.backgroundColor == Color.black) {
        Camera.current.backgroundColor = Color.white;
      } else {
        Camera.current.backgroundColor = Color.black;
      }
      accumulator = 0;
    }
  }
}
