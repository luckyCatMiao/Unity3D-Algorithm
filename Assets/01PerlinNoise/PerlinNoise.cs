using System;
using UnityEngine;


public static class PerlinNoise
{
    static float interpolate(float a0, float a1, float w)
    {
        /* // You may want clamping by inserting:
         * if (0.0 > w) return a0;
         * if (1.0 < w) return a1;
         */
        return (a1 - a0) * w + a0;
        /* // Use this cubic interpolation [[Smoothstep]] instead, for a smooth appearance:
         * return (a1 - a0) * (3.0 - w * 2.0) * w * w + a0;
         *
         * // Use [[Smootherstep]] for an even smoother result with a second derivative equal to zero on boundaries:
         * return (a1 - a0) * ((w * (w * 6.0 - 15.0) + 10.0) * w * w * w) + a0;
         */
    }

    static Vector2 randomGradient(int ix, int iy)
    {
        double random = 2920f * Mathf.Sin(ix * 21942 + iy * 171324 + 8912) * Math.Cos(ix * 23157 * iy * 217832 + 9758);
        return new Vector2(Mathf.Sin((float) random), Mathf.Cos((float) random));
    }


    static float dotGridGradient(int ix, int iy, float x, float y)
    {
        // Get gradient from integer coordinates
        Vector2 gradient = randomGradient(ix, iy);

        // Compute the distance vector
        float dx = x - (float) ix;
        float dy = y - (float) iy;

        // Compute the dot-product
        return (dx * gradient.x + dy * gradient.y);
    }


    public static float perlin(float x, float y)
    {
        int x0 = 0;
        int x1 = 1;
        int y0 = 0;
        int y1 = 1;


        float sx = x;
        float sy = y;

        // Interpolate between grid point gradients
        float n0, n1, ix0, ix1, value;

        n0 = dotGridGradient(x0, y0, x, y);
        n1 = dotGridGradient(x1, y0, x, y);
        ix0 = interpolate(n0, n1, sx);

        n0 = dotGridGradient(x0, y1, x, y);
        n1 = dotGridGradient(x1, y1, x, y);
        ix1 = interpolate(n0, n1, sx);

        value = interpolate(ix0, ix1, sy);
        return value;
    }
}