using UnityEngine;

namespace Algorithm
{
    public class CreateMesh : MonoBehaviour
    {
        private void Start()
        {
            var mesh = createNoiseMesh(256);
            mesh.RecalculateNormals();

            GameObject gameObject = new GameObject();
            gameObject.AddComponent<MeshFilter>();
            gameObject.AddComponent<MeshRenderer>();
            gameObject.GetComponent<MeshFilter>().mesh = mesh;

            Material material = new Material(Shader.Find("Standard"));
            gameObject.GetComponent<MeshRenderer>().material = material;
        }

        private Mesh createNoiseMesh(int size)
        {
            Mesh mesh = new Mesh();
            Vector3[] vertexs = new Vector3[size * size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    var height = ValueNoise.fbmNoise(x/32f, y/32f,4) * 50;
                    vertexs[y * size + x] = new Vector3(x, height, y);
                }
            }

            mesh.vertices = vertexs;
            var triangles = new int[(size - 1) * 2 * (size - 1) * 3];
            int index = -1;
            for (int i = 0; i < triangles.Length/2; i += 3)
            {
                index++;
                triangles[i] = index;
                triangles[i + 1] = index + size;
                triangles[i + 2] = index + 1;
                if ((index % size) + 1 == size - 1)
                {
                    index++;
                }
              
            }

            index = 0;
            for (int i = triangles.Length/2; i <triangles.Length ; i += 3)
            {
                index++;
                triangles[i] = index;
                triangles[i + 1] = index + size-1;
                triangles[i + 2] = index + size;
                if ((index % size) ==size-1)
                {
                    index++;
                }
              
            }

            // StringBuilder builder = new StringBuilder();
            // for (int i = 0; i < triangles.Length; i++)
            // {
            //     builder.Append(triangles[i] + " ");
            // }
            // Debug.Log(builder.ToString());
            
            
             mesh.triangles = triangles;

            return mesh;
        }

        private Mesh createTriMesh()
        {
            Mesh mesh = new Mesh();
            var vertices = new Vector3[]
                           {
                               new Vector3(0, 0, 0),
                               new Vector3(2, 0, 0),
                               new Vector3(1, 2, 1)
                           };
            mesh.vertices = vertices;

            var triangles = new int[] {0, 1, 2};
            mesh.triangles = triangles;

            var uvs = new Vector2[]
                      {
                          new Vector2(0, 0),
                          new Vector2(1, 0),
                          new Vector2(1, 1)
                      };
            mesh.uv = uvs;
            
            return mesh;
        }
    }
}