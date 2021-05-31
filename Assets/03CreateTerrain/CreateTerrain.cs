using Algorithm;
using UnityEngine;

public class CreateTerrain : MonoBehaviour
{
    
    void Start()
    {
        for (int z = 0; z < 128; z++)
        {
            for (int x = 0; x < 128; x++)
            {
                float grayscale = PerlinNoise.fbmNoise(x / (float) 32, z / (float) 32,8);
                var cube=GameObject.CreatePrimitive(PrimitiveType.Cube);
                int cubeY = (int) (grayscale * 30);
                cube.transform.position = new Vector3(x, cubeY, z);
                cube.GetComponent<Renderer>().material.color=new Color(0,grayscale,0);
            }
        }
    }
}