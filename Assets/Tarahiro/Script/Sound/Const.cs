using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const
{
    // 計算用に使う定数
    public const float Sqrt2per2 = 0.70710678118f;


    public static void RandomIndexList(out List<int> o_indexList, int t_maxNumber)
    {
        List<int> t_intList = new List<int>();

        for(int i = 0; i < t_maxNumber; i++)
        {
            t_intList.Add(i);
        }

        List<int> t_indexList = new List<int>();

        while(t_intList.Count > 0)
        {
            int i = Random.Range(0, t_intList.Count);
            t_indexList.Add(t_intList[i]);
            t_intList.RemoveAt(i);
        }

        o_indexList = t_indexList;
    }

    // 数値補完関連
    public enum InterpolateType
    {
        AccelDecel,
        Decel,
        Accel,
        Linear
    }
    public static float Interpolate(float ratio, InterpolateType type)
    {
        switch (type)
        {
            case InterpolateType.AccelDecel:
                return AccelDecel(ratio);
            case InterpolateType.Decel:
                return Decel(ratio);
            case InterpolateType.Accel:
                return Accel(ratio);
            case InterpolateType.Linear:
                return ratio;
            default:
                return 1.0f;
        }
    }

    // 定義域0.0～1.0の補間関数
    public static float Accel(float x)
    {
        return x * x;
    }
    public static float Decel(float x)
    {
        return 1.0f - (1.0f - x) * (1.0f - x);
    }
    // 加速→減速
    public static float AccelDecel(float x)
    {
        if (x < 0.5f)
        {
            return Accel(x * 2.0f) / 2.0f; // 0.0～0.5→0.0～0.5の写像を加速で行う
        }
        else
        {
            return Decel((x - 0.5f) * 2.0f) / 2.0f + 0.5f; // 0.5～1.0→0.5～1.0の写像を減速で行う
        }
    }

    // 減速→加速
    public static float DecelAccel(float x)
    {
        if (x < 0.5f)
        {
            return Decel(x * 2.0f) / 2.0f; // 0.0～0.5→0.0～0.5の写像を減速で行う
        }
        else
        {
            return Accel((x - 0.5f) * 2.0f) / 2.0f + 0.5f; // 0.5～1.0→0.5～1.0の写像を加速で行う
        }
    }
}
