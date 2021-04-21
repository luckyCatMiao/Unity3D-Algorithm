using System.IO;
using UnityEngine;

namespace _01PerlinNoise
{
    public class CreatePerlinNoiseTex : MonoBehaviour
    {
        void Start()
        {
            Texture2D texture = new Texture2D(128, 128);

            this.GetComponent<Renderer>().material.mainTexture = texture;

            for (int y = 0; y < texture.height; y++)
            {
                for (int x = 0; x < texture.width; x++)
                {
                    float grayscale = PerlinNoise.perlin(x / 128f, y / 128f);
                    texture.SetPixel(x, y, new Color(grayscale,grayscale,grayscale));
                }
            }

            texture.Apply();
            saveTexture2D(texture, "tex");
        }


        void saveTexture2D(Texture2D texture, string fileName)
        {
            var bytes = texture.EncodeToPNG();
            var file = File.Create(Application.dataPath + "/" + fileName + ".png");
            var binary = new BinaryWriter(file);
            binary.Write(bytes);
            file.Close();
            UnityEditor.AssetDatabase.Refresh();
        }
    }
}