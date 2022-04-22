using UnityEngine;

namespace Werewolf.Ravenwood {
   // TODO : ADD README.md Changes
   // TODO : Tan/Log Table
   // TODO : Document differences in <summary>
   // TODO : Benchmarking using Pre-Randomly Generated Int/Float Arrays (And Show Tests for correctness)

   /*
   Default to Lerp Unclamped
   Remove Epsilon and Approximately
   Infinity is highest max float
   Remove RandomToLong
   Remove Gamma
   Repeat only for Positive
   Add Clamp0, Sqr, SqrMag, Dot
   */

   public static class Mathf { }

   public static class FM {
      public static float SqrMag(Vector3 v) => (v.x * v.x) + (v.y * v.y) + (v.z * v.z);
      public static float Dot(Vector3 a, Vector3 b) => (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
      public static float Min(float a, float b) => a < b ? a : b;
      public static int Min(int a, int b) => b + ((a - b) & (a - b) >> 31);
      public static float Max(float a, float b) => a > b ? a : b;
      public static int Max(int a, int b) => a - ((a - b) & (a - b) >> 31);
      public static float Sqr(float f) => f * f;
      public const float Infinity = 340282300000000000000000000000000000000f;
      public static float Clamp0(float f) => Max(f, 0);
      public static int Clamp0(int i) => Max(i, 0);
      ///<summary> Clamps a value between a minimum float and maximum float value.</summary>
      public static float Clamp(float value, float min, float max) {
         if (value < min)
            value = min;
         else if (value > max)
            value = max;
         return value;
      }
      ///<summary> Clamps a value between a minimum float and maximum float value.</summary>
      public static int Clamp(int value, int min, int max) {
         return Min(max, Max(min, value));
      }
      ///<summary> Clamps value between 0 and 1 and returns value.</summary>
      public static float Clamp01(float value) {
         if (value < 0F)
            return 0F;
         else if (value > 1F)
            return 1F;
         else
            return value;
      }
      ///<summary> Loops the value t, so that it is never larger than length and never smaller than 0.</summary>
      public static int Repeat(int t, int length) => t % length;
      ///<summary> Loops the value t, so that it is never larger than length and never smaller than 0.</summary>
      public static float Repeat(float t, float length) => t % length;
      ///<summary> Interpolates between /a/ and /b/ by /t/ without clamping the interpolant.</summary>

      public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => a + (b - a) * t;
      public static float Lerp(float a, float b, float t) => a + (b - a) * t;
      ///<summary> Interpolates between /a/ and /b/ by /t/. /t/ is clamped between 0 and 1.</summary>
      public static float LerpClamped(float a, float b, float t) => a + (b - a) * Clamp01(t);
      ///<summary> Same as ::ref::Lerp but makes sure the values interpolate correctly when they wrap around 360 degrees.</summary>
      public static float LerpAngleClamped(float a, float b, float t) => UnityEngine.Mathf.LerpAngle(a, b, t);
      public static float RepeatAllowNegative(float t, float length) => Clamp(t - Floor(t / length) * length, 0.0f, length);
      public static float RepeatAllowNegative(int t, int length) => Clamp(t - Floor(t / length) * length, 0, length);
      public static float Ceil(float f) => (int)f + 1;
      public static float Floor(float f) => (int)f;
      public static float Round(float f) => (int)(f + 0.5f);
      public static int CeilToInt(float f) => (int)f + 1;
      public static int FloorToInt(float f) => (int)f;
      public static int RoundToInt(float f) => (int)(f + 0.5f);
      ///<summary> Returns the sine of angle /f/ in radians.</summary>
      public static float Sin(float f) => (float)System.Math.Sin(f);
      ///<summary> Returns the cosine of angle /f/ in radians.</summary>
      public static float Cos(float f) => (float)System.Math.Cos(f);
      ///<summary> Returns the absolute value of /f/.</summary>
      public static float Abs(float f) => (float)System.Math.Abs(f);
      ///<summary> Returns the absolute value of /value/.</summary>
      public static int Abs(int i) => (i ^ (i >> 31)) - (i >> 31);

      // * -------------------------------------------------------------------------------------------------------------------------------

      ///<summary> Returns the tangent of angle /f/ in radians.</summary>
      public static float Tan(float f) { return (float)System.Math.Tan(f); }
      ///<summary> Returns the arc-sine of /f/ - the angle in radians whose sine is /f/.</summary>
      public static float Asin(float f) { return (float)System.Math.Asin(f); }
      ///<summary> Returns the arc-cosine of /f/ - the angle in radians whose cosine is /f/.</summary>
      public static float Acos(float f) { return (float)System.Math.Acos(f); }
      ///<summary> Returns the arc-tangent of /f/ - the angle in radians whose tangent is /f/.</summary>
      public static float Atan(float f) { return (float)System.Math.Atan(f); }
      ///<summary> Returns the angle in radians whose ::ref::Tan is @@y/x@@.</summary>
      public static float Atan2(float y, float x) { return (float)System.Math.Atan2(y, x); }
      ///<summary> Returns square root of /f/.</summary>
      public static float Sqrt(float f) { return (float)System.Math.Sqrt(f); }
      ///<summary> Returns the sign of /f/.</summary>
      public static float Sign(float f) { return f >= 0F ? 1F : -1F; }
      ///<summary> The infamous ''3.14159265358979...'' value (RO).</summary>
      public const float PI = (float)System.Math.PI;
      ///<summary> A representation of negative infinity (RO).</summary>
      public const float NegativeInfinity = -Infinity;
      ///<summary> Degrees-to-radians conversion constant (RO).</summary>
      public const float Deg2Rad = PI * 2F / 360F;
      ///<summary> Radians-to-degrees conversion constant (RO).</summary>
      public const float Rad2Deg = 1F / Deg2Rad;
      ///<summary> PingPongs the value t, so that it is never larger than length and never smaller than 0.</summary>
      public static float PingPong(float t, float length) {
         t = RepeatAllowNegative(t, length * 2F);
         return length - Abs(t - length);
      }
      ///<summary> Calculates the ::ref::Lerp parameter between of two values.</summary>
      public static float InverseLerp(float a, float b, float value) {
         if (a != b)
            return Clamp01((value - a) / (b - a));
         else
            return 0.0f;
      }
      ///<summary> Calculates the shortest difference between two given angles.</summary>
      public static float DeltaAngle(float current, float target) {
         float delta = RepeatAllowNegative((target - current), 360.0F);
         if (delta > 180.0F)
            delta -= 360.0F;
         return delta;
      }
   }
}
