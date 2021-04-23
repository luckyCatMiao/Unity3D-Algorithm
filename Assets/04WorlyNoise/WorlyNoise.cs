using UnityEngine;

namespace Algorithm
{
    public static class WorlyNoise
    {
        public static float noise(float x, float y)
        {
            float distance = float.MaxValue;
            for (int Y = -1; Y <= 1; Y++)
            {
                for (int X = -1; X <= 1; X++)
                {
                    Vector2 cellPoint = hash(new Vector2((int) x + X, (int) y + Y));
                    distance = Mathf.Min(distance, Vector2.Distance(cellPoint, new Vector2(x, y)));
                }
            }

            return 1-distance;
        }

        static Vector2 hash(Vector2 p)
        {
            float random = Mathf.Sin(666 + p.x * 5678 + p.y * 1234) * 4321;
            return new Vector2(p.x+Mathf.Sin(random)/2+0.5f, p.y+Mathf.Cos(random)/2+0.5f);
        }
        
        public static float fbmNoise(float x, float y,int layer)
        {
            float value =0;
            float frequency = 1;
            float amplitude = 0.5f;
            for(int i = 0; i < layer; i++)
            {
                value += noise(x*frequency,y*frequency) * amplitude;
                frequency *= 2;
                amplitude *= 0.5f;
            }

            return value;
        }
    }
}