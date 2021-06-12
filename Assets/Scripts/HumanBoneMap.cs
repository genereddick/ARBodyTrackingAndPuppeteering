using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class HumanBoneMap
{
    public Vector3 robotLocalPosition = Vector3.zero;

    public Quaternion robotLocalRotation = Quaternion.identity;

    public float robotEstimatedHeight = 1.0f;

    private Vector3 previousLocalPosition = Vector3.zero;

    private Quaternion previousLocalRotation = Quaternion.identity;

    public Vector3 robotLocalScale {
        get {
            return new Vector3(robotEstimatedHeight, robotEstimatedHeight, robotEstimatedHeight);
        }
    }


    public Vector3 DeltaLocalPosition {  get {
            var deltaPosition = robotLocalPosition - previousLocalPosition;
            previousLocalPosition = robotLocalPosition;

            return deltaPosition;
        } 
    }

    public Quaternion DeltaLocalRotation {  get {
            var deltaRotation = robotLocalRotation * Quaternion.Inverse(previousLocalRotation);
            previousLocalRotation = robotLocalRotation;

            return deltaRotation;
        } 
    }

    public Dictionary<JointIndices, BoneMap> BoneMaps = new Dictionary<JointIndices, BoneMap>();
}
