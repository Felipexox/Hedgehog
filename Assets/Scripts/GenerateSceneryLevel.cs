using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSceneryLevel : MonoBehaviour {
    [SerializeField]
    private Texture2D[] textures = new Texture2D[0];

    [SerializeField]
    private ColorToPrefab[] colors = new ColorToPrefab[0];

    private void Awake()
    {
        GenerateMap(0);
    }

    private void GenerateMap(int index)
    {
        for(int i = 0; i < textures[index].width; i++)
        {
            for(int j = 0; j < textures[index].height; j++)
            {
                Generate(i, j, index);
            }
        }
    }

    private void Generate(int x, int y, int index)
    {
        Color pixel = textures[index].GetPixel(x, y);
        if (pixel.a == 0)
            // ignore pixels were alpha is zero
            return;
        foreach(ColorToPrefab color in colors)
        {
            if (color.color.Equals(pixel))
            {
                Vector3 position = new Vector2(x, y);
                Instantiate(color.prefab, position, color.prefab.transform.rotation);
            }
        }
    }


}
