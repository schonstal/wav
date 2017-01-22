using UnityEngine;
using System;

public class Sinus : MonoBehaviour
{
  public double gain = 0.05;
  public double frequency = 20;
  public double sampleRate = 48000;
  public double changeRate = 0.1;
  public bool scale = false;

  private double theta;
  private float amplitude;

  void OnAudioFilterRead(float[] data, int channels) {
    double sinAmt = frequency * 2 * Math.PI / sampleRate;

    for (var i = 0; i < data.Length; i = i + channels) {
      theta = theta + sinAmt;
      if (theta > 2 * Math.PI) {
        theta = 0;
      }

      amplitude = (float)(gain * Math.Sin(theta));
      data[i] = amplitude;
      if (channels > 1) {
        data[i + 1] = data[i];
      }
    }
  }

  void Update() {
    if (Input.GetKeyDown("space")) {
      frequency += changeRate;
    }

    if (scale) {
      transform.localScale = new Vector3(6 * amplitude, 6 * amplitude, 1);
    }
  }
}
