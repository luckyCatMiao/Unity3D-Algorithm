using System.IO;
using UnityEditor;
using UnityEngine;

namespace Algorithm
{
    public class CreateValueNoise : MonoBehaviour
    {
        [Range(1, 512)] public int cellSize=16;

        private void Start()
        {
            Texture2D texture = new Texture2D(512, 512);
            this.GetComponent<Renderer>().material.mainTexture = texture;
            for (int y = 0; y < texture.height; y++)
            {
                for (int x = 0; x < texture.width; x++)
                {
                    float grayscale = ValueNoise.noise(x / (float) cellSize, y / (float) cellSize);
                    texture.SetPixel(x, y, new Color(grayscale, grayscale, grayscale));
                }
            }

            texture.Apply();
            saveTexture2D(texture, "tex");
        }

        void saveTexture2D(Texture2D texture, string fileName)
        {
            var bytes = texture.EncodeToPNG();
            var file = File.Create(Application.dataPath + "/02ValueNoise/" + fileName + ".png");
            var binary = new BinaryWriter(file);
            binary.Write(bytes);
            file.Close();
            AssetDatabase.Refresh();
        }
    }
}