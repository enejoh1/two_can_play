using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime 
{

    public Vector3 positions;
    public Quaternion rotations;

    public PointInTime (Vector3 _position, Quaternion _rotation)
    {
        positions = _position;
        rotations = _rotation;
    }

}
