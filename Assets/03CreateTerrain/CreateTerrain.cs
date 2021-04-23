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
                float grayscale = ValueNoise.noise(x / (float) 16, z / (float) 16);
                var cube=GameObject.CreatePrimitive(PrimitiveType.Cube);
                int cubeY = (int) (grayscale * 20);
                cube.transform.position = new Vector3(x, cubeY, z);
                cube.GetComponent<Renderer>().material.color=Color.green;
            }
        }
    }
}