using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Maths
{
    //把vec变量key在t时间内差值到目标值target
    //返回值是key的新位置；
    public static Vector3 Flerp(float time_ding, float time_bian, Vector3 target, Vector3 key, Vector3 begin)
    {

        key = Vector3.Lerp(begin, target, time_bian / time_ding);
        return key;
    }
    public static Vector3 Flerp(float time_ding, float time_bian, Vector3 target, Vector3 begin)
    {
        Vector3 key = Vector3.Lerp(begin, target, time_bian / time_ding);
        return key;
    }

    public static Vector2 Vector3ToVector2(Vector3 target)
    {
        return new Vector2(target.x, target.y);
    }


    public static Vector3 Vector2ToVector3(Vector2 target)
    {
        return new Vector3(target.x, target.y, 0);
    }


    public static Vector3 Vector2ToVector3(Vector2 target, float newZValue)
    {
        return new Vector3(target.x, target.y, newZValue);
    }


    public static Vector3 RoundVector3(Vector3 vector)
    {
        return new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
    }


    public static Vector2 RandomVector2(Vector2 minimum, Vector2 maximum)
    {
        return new Vector2(UnityEngine.Random.Range(minimum.x, maximum.x),
                                         UnityEngine.Random.Range(minimum.y, maximum.y));
    }


    public static Vector3 RandomVector3(Vector3 minimum, Vector3 maximum)
    {
        return new Vector3(UnityEngine.Random.Range(minimum.x, maximum.x),
                                         UnityEngine.Random.Range(minimum.y, maximum.y),
                                         UnityEngine.Random.Range(minimum.z, maximum.z));
    }


    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, float angle)
    {
        angle = angle * (Mathf.PI / 180f);
        var rotatedX = Mathf.Cos(angle) * (point.x - pivot.x) - Mathf.Sin(angle) * (point.y - pivot.y) + pivot.x;
        var rotatedY = Mathf.Sin(angle) * (point.x - pivot.x) + Mathf.Cos(angle) * (point.y - pivot.y) + pivot.y;
        return new Vector3(rotatedX, rotatedY, 0);
    }
    public static Vector3 FloatZtoVector3(float z)
    {
        Vector3 point = Vector3.up;
        Vector3 pivot = Vector3.zero;
        z = z * (Mathf.PI / 180f);
        var rotatedX = Mathf.Cos(z) * (point.x - pivot.x) - Mathf.Sin(z) * (point.y - pivot.y) + pivot.x;
        var rotatedY = Mathf.Sin(z) * (point.x - pivot.x) + Mathf.Cos(z) * (point.y - pivot.y) + pivot.y;
        return new Vector3(rotatedX, rotatedY, 0);
    }
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angle)
    {

        Vector3 direction = point - pivot;

        direction = Quaternion.Euler(angle) * direction;

        point = direction + pivot;
        return point;
    }


    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion quaternion)
    {

        Vector3 direction = point - pivot;

        direction = quaternion * direction;


        point = direction + pivot;
        return point;
    }


    public static Vector2 RotateVector2(Vector2 vector, float angle)
    {
        if (angle == 0)
        {
            return vector;
        }
        float sinus = Mathf.Sin(angle * Mathf.Deg2Rad);
        float cosinus = Mathf.Cos(angle * Mathf.Deg2Rad);

        float oldX = vector.x;
        float oldY = vector.y;
        vector.x = (cosinus * oldX) - (sinus * oldY);
        vector.y = (sinus * oldX) + (cosinus * oldY);
        return vector;
    }

    public static float AngleBetween(Vector2 vectorA, Vector2 vectorB)
    {
        float angle = Vector2.Angle(vectorA, vectorB);
        Vector3 cross = Vector3.Cross(vectorA, vectorB);

        if (cross.z > 0)
        {
            angle = 360 - angle;
        }

        return angle;
    }
    public static float AngleBetween(Vector2 vectorB)
    {
        float angle = Vector2.Angle(Vector3.up, vectorB);
        Vector3 cross = Vector3.Cross(Vector3.up, vectorB);

        if (cross.z > 0)
        {
            angle = 360 - angle;
        }

        return angle;
    }


    public static float ClampAngle(float angle, float minimumAngle, float maximumAngle)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, minimumAngle, maximumAngle);
    }


    public static Vector3 DirectionFromAngle(float angle, float additionalAngle)
    {
        angle += additionalAngle;

        Vector3 direction = Vector3.zero;
        direction.x = Mathf.Sin(angle * Mathf.Deg2Rad);
        direction.y = 0f;
        direction.z = Mathf.Cos(angle * Mathf.Deg2Rad);
        return direction;
    }

    public static Vector3 DirectionFromAngle2D(float angle, float additionalAngle)
    {
        angle += additionalAngle;

        Vector3 direction = Vector3.zero;
        direction.x = Mathf.Sin(angle * Mathf.Deg2Rad);
        direction.y = Mathf.Cos(angle * Mathf.Deg2Rad);
        direction.z = 0f;
        return direction;
    }
    public static Vector3 CheckWallTargetPos(Vector3 BegPos,Vector3 Dir,float Distance,bool checkPlayer = false)
    {

        Vector3 targetPos;
        RaycastHit2D hit;
        if (checkPlayer)
        {
            hit = Physics2D.Raycast(BegPos, Dir, Distance+1, 1 << 11|1<<14);
        }
        else
        {
            hit = Physics2D.Raycast(BegPos, Dir, Distance, 1 << 11);
        }
   
        if (hit)
        {
            targetPos = hit.point;
        }
        else
        {
            targetPos = BegPos + Distance * Dir;
        }
        return targetPos;
    }
    public static Vector3 CheckEnemyargetPos(Vector3 BegPos, Vector3 Dir, float Distance,float DistanceBetweenEnemy = 2.5f)
    {

        Vector3 targetPos;
        RaycastHit2D hit = Physics2D.BoxCast(BegPos,Vector2.one ,0,Dir, Distance+ DistanceBetweenEnemy, 1 << 13|1 << 11|1<<8);
     
        if (hit)
        {
            targetPos = hit.point+((Vector2)BegPos-hit.point).normalized* DistanceBetweenEnemy;
            targetPos = CheckWallTargetPos(BegPos, (targetPos - BegPos).normalized, (targetPos - BegPos).magnitude);
        }
        else
        {
            targetPos = BegPos + Distance * Dir;
        }
        return targetPos;
    }
}

