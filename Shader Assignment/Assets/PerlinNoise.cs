using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    private int width = 256;
    private int height = 256;
    private float scale = 15;

    public Material material;

    void Start() {
      material.SetTexture("_MainTex", GenerateTexture());
    }

    Texture2D GenerateTexture () {
      Texture2D texture = new Texture2D(width, height);

      for (int x = 0; x < width; x++) {
        for (int y = 0; y < height; y++) {
          Color color = CalculateColor(x, y);
          texture.SetPixel(x, y, color);
        }
      }
      texture.Apply();
      return texture;
    }


    Color CalculateColor (int x, int y) {
      float xCoord = (float)x / width * scale;
      float yCoord = (float)y / height * scale;

      float sample = Mathf.PerlinNoise(xCoord, yCoord);
      return new Color (sample, sample, sample);
    }
}
