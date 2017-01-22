using UnityEngine;
using System;

public class Sinus : MonoBehaviour
{
  public double gain = 0.05;
  public double frequency = 20;
  public double sampleRate = 48000;
  public double changeRate = 0.1;

  public bool scale = false;

  public bool swing = false;
  public bool oscillate = false;
  public float oscillationStart = 80f;
  public float oscillationEnd = 100f;
  public float oscillationRate = 1f;
  public float oscillationOffset = 0f;

  private float oscTheta = 0f;
  private double tau = 2 * Math.PI;

  private double theta;
  private float amplitude;

  void OnAudioFilterRead(float[] data, int channels) {
    double sinAmt = frequency * tau / sampleRate;

    for (var i = 0; i < data.Length; i = i + channels) {
      theta = theta + sinAmt;
      if (theta > tau) {
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
    if (oscillate) {
      oscTheta += (float)(Time.deltaTime * tau * oscillationRate);
      float oscPosition = ((float)Math.Sin(oscTheta + oscillationOffset) + 1) / 2f;

      frequency = Mathf.Lerp(
        oscillationEnd,
        oscillationStart,
        oscPosition
      );

      if (scale) {
        transform.localScale = new Vector3(
          Mathf.Lerp(0, 6, oscPosition),
          Mathf.Lerp(0, 6, oscPosition)
        );
      }

      if (swing) {
        transform.eulerAngles = new Vector3(0, 0, (float)Math.Sin(oscTheta + oscillationOffset) * 60f);
      }
    }
  }
}
