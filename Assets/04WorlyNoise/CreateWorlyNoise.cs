using System.IO;
using UnityEditor;
using UnityEngine;

namespace Algorithm
{
    public class CreateWorlyNoise : MonoBehaviour
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
                    float grayscale = WorlyNoise.noise(x / (float) cellSize, y / (float) cellSize);
                    texture.SetPixel(x, y, new Color(grayscale, grayscale, grayscale));
                }
            }

            texture.Apply();
            saveTexture2D(texture, "tex");
        }

        void saveTexture2D(Texture2D texture, string fileName)
        {
            var bytes = texture.EncodeToPNG();
            var file = File.Create(Application.dataPath + "/04WorlyNoise/" + fileName + ".png");
            var binary = new BinaryWriter(file);
            binary.Write(bytes);
            file.Close();
            AssetDatabase.Refresh();
        }
    }
}