using UnityEngine;

namespace Algorithm
{
    public static class ValueNoise
    {
        public static float noise(float x, float y)
        {
            //声明四个顶点
            Vector2 rightUp = new Vector2((int) x + 1, (int) y + 1);
            Vector2 rightDown = new Vector2((int) x + 1, (int) y);
            Vector2 leftUp = new Vector2((int) x, (int) y + 1);
            Vector2 leftDown = new Vector2((int) x, (int) y);

            //正方形插值
            float v1 = Mathf.SmoothStep(hash(leftDown), hash(rightDown), x-(int)x);
            float v2 = Mathf.SmoothStep(hash(leftUp), hash(rightUp), x-(int)x);
            
            return Mathf.SmoothStep(v1, v2, y-(int)y);
        }

        private static float hash(Vector2 v) => (Mathf.Cos(Mathf.Sin(1234 + v.x * 123 + v.y * 353) * 12334)+1)/2;
    }
}