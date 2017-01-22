using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
  public float speed = 0.1f;
  void Start() {
  }

  void Update() {
    if(Camera.current == null) { return; }

  }
}
