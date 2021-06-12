using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarRobotBoneMap : MonoBehaviour
{
    [Header("Assign Avatar Bones to Controlled Robot Bones")]
    [Tooltip("Not every bone need be assigned")]
    [SerializeField] private JointToBone Root = new JointToBone { jointIndex = JointIndices.Root };
    [SerializeField] private JointToBone Hips = new JointToBone { jointIndex = JointIndices.Hips };
    [SerializeField] private JointToBone LeftUpLeg = new JointToBone { jointIndex = JointIndices.LeftUpLeg };
    [SerializeField] private JointToBone LeftLeg = new JointToBone { jointIndex = JointIndices.LeftLeg };
    [SerializeField] private JointToBone LeftFoot = new JointToBone { jointIndex = JointIndices.LeftFoot };
    [SerializeField] private JointToBone LeftToes = new JointToBone { jointIndex = JointIndices.LeftToes };
    [SerializeField] private JointToBone LeftToesEnd = new JointToBone { jointIndex = JointIndices.LeftToesEnd };
    [SerializeField] private JointToBone RightUpLeg = new JointToBone { jointIndex = JointIndices.RightUpLeg };
    [SerializeField] private JointToBone RightLeg = new JointToBone { jointIndex = JointIndices.RightLeg };
    [SerializeField] private JointToBone RightFoot = new JointToBone { jointIndex = JointIndices.RightFoot };
    [SerializeField] private JointToBone RightToes = new JointToBone { jointIndex = JointIndices.RightToes };
    [SerializeField] private JointToBone RightToesEnd = new JointToBone { jointIndex = JointIndices.RightToesEnd };
    [SerializeField] private JointToBone Spine1 = new JointToBone { jointIndex = JointIndices.Spine1 };
    [SerializeField] private JointToBone Spine2 = new JointToBone { jointIndex = JointIndices.Spine2 };
    [SerializeField] private JointToBone Spine3 = new JointToBone { jointIndex = JointIndices.Spine3 };
    [SerializeField] private JointToBone Spine4 = new JointToBone { jointIndex = JointIndices.Spine4 };
    [SerializeField] private JointToBone Spine5 = new JointToBone { jointIndex = JointIndices.Spine5 };
    [SerializeField] private JointToBone Spine6 = new JointToBone { jointIndex = JointIndices.Spine6 };
    [SerializeField] private JointToBone Spine7 = new JointToBone { jointIndex = JointIndices.Spine7 };
    [SerializeField] private JointToBone LeftShoulder1 = new JointToBone { jointIndex = JointIndices.LeftShoulder1 };
    [SerializeField] private JointToBone LeftArm = new JointToBone { jointIndex = JointIndices.LeftArm };
    [SerializeField] private JointToBone LeftForearm = new JointToBone { jointIndex = JointIndices.LeftForearm };
    [SerializeField] private JointToBone LeftHand = new JointToBone { jointIndex = JointIndices.LeftHand };
    [SerializeField] private JointToBone LeftHandIndexStart = new JointToBone { jointIndex = JointIndices.LeftHandIndexStart };
    [SerializeField] private JointToBone LeftHandIndex1 = new JointToBone { jointIndex = JointIndices.LeftHandIndex1 };
    [SerializeField] private JointToBone LeftHandIndex2 = new JointToBone { jointIndex = JointIndices.LeftHandIndex2 };
    [SerializeField] private JointToBone LeftHandIndex3 = new JointToBone { jointIndex = JointIndices.LeftHandIndex3 };
    [SerializeField] private JointToBone LeftHandIndexEnd = new JointToBone { jointIndex = JointIndices.LeftHandIndexEnd };
    [SerializeField] private JointToBone LeftHandMidStart = new JointToBone { jointIndex = JointIndices.LeftHandMidStart };
    [SerializeField] private JointToBone LeftHandMid1 = new JointToBone { jointIndex = JointIndices.LeftHandMid1 };
    [SerializeField] private JointToBone LeftHandMid2 = new JointToBone { jointIndex = JointIndices.LeftHandMid2 };
    [SerializeField] private JointToBone LeftHandMid3 = new JointToBone { jointIndex = JointIndices.LeftHandMid3 };
    [SerializeField] private JointToBone LeftHandMidEnd = new JointToBone { jointIndex = JointIndices.LeftHandMidEnd };
    [SerializeField] private JointToBone LeftHandPinkyStart = new JointToBone { jointIndex = JointIndices.LeftHandPinkyStart };
    [SerializeField] private JointToBone LeftHandPinky1 = new JointToBone { jointIndex = JointIndices.LeftHandPinky1 };
    [SerializeField] private JointToBone LeftHandPinky2 = new JointToBone { jointIndex = JointIndices.LeftHandPinky2 };
    [SerializeField] private JointToBone LeftHandPinky3 = new JointToBone { jointIndex = JointIndices.LeftHandPinky3 };
    [SerializeField] private JointToBone LeftHandPinkyEnd = new JointToBone { jointIndex = JointIndices.LeftHandPinkyEnd };
    [SerializeField] private JointToBone LeftHandRingStart = new JointToBone { jointIndex = JointIndices.LeftHandRingStart };
    [SerializeField] private JointToBone LeftHandRing1 = new JointToBone { jointIndex = JointIndices.LeftHandRing1 };
    [SerializeField] private JointToBone LeftHandRing2 = new JointToBone { jointIndex = JointIndices.LeftHandRing2 };
    [SerializeField] private JointToBone LeftHandRing3 = new JointToBone { jointIndex = JointIndices.LeftHandRing3 };
    [SerializeField] private JointToBone LeftHandRingEnd = new JointToBone { jointIndex = JointIndices.LeftHandRingEnd };
    [SerializeField] private JointToBone LeftHandThumbStart = new JointToBone { jointIndex = JointIndices.LeftHandThumbStart };
    [SerializeField] private JointToBone LeftHandThumb1 = new JointToBone { jointIndex = JointIndices.LeftHandThumb1 };
    [SerializeField] private JointToBone LeftHandThumb2 = new JointToBone { jointIndex = JointIndices.LeftHandThumb2 };
    [SerializeField] private JointToBone LeftHandThumbEnd = new JointToBone { jointIndex = JointIndices.LeftHandThumbEnd };
    [SerializeField] private JointToBone Neck1 = new JointToBone { jointIndex = JointIndices.Neck1 };
    [SerializeField] private JointToBone Neck2 = new JointToBone { jointIndex = JointIndices.Neck2 };
    [SerializeField] private JointToBone Neck3 = new JointToBone { jointIndex = JointIndices.Neck3 };
    [SerializeField] private JointToBone Neck4 = new JointToBone { jointIndex = JointIndices.Neck4 };
    [SerializeField] private JointToBone Head = new JointToBone { jointIndex = JointIndices.Head };
    [SerializeField] private JointToBone Jaw = new JointToBone { jointIndex = JointIndices.Jaw };
    [SerializeField] private JointToBone Chin = new JointToBone { jointIndex = JointIndices.Chin };
    [SerializeField] private JointToBone LeftEye = new JointToBone { jointIndex = JointIndices.LeftEye };
    [SerializeField] private JointToBone LeftEyeLowerLid = new JointToBone { jointIndex = JointIndices.LeftEyeLowerLid };
    [SerializeField] private JointToBone LeftEyeUpperLid = new JointToBone { jointIndex = JointIndices.LeftEyeUpperLid };
    [SerializeField] private JointToBone LeftEyeball = new JointToBone { jointIndex = JointIndices.LeftEyeball };
    [SerializeField] private JointToBone Nose = new JointToBone { jointIndex = JointIndices.Nose };
    [SerializeField] private JointToBone RightEye = new JointToBone { jointIndex = JointIndices.RightEye };
    [SerializeField] private JointToBone RightEyeLowerLid = new JointToBone { jointIndex = JointIndices.RightEyeLowerLid };
    [SerializeField] private JointToBone RightEyeUpperLid = new JointToBone { jointIndex = JointIndices.RightEyeUpperLid };
    [SerializeField] private JointToBone RightEyeball = new JointToBone { jointIndex = JointIndices.RightEyeball };
    [SerializeField] private JointToBone RightShoulder1 = new JointToBone { jointIndex = JointIndices.RightShoulder1 };
    [SerializeField] private JointToBone RightArm = new JointToBone { jointIndex = JointIndices.RightArm };
    [SerializeField] private JointToBone RightForearm = new JointToBone { jointIndex = JointIndices.RightForearm };
    [SerializeField] private JointToBone RightHand = new JointToBone { jointIndex = JointIndices.RightHand };
    [SerializeField] private JointToBone RightHandIndexStar = new JointToBone { jointIndex = JointIndices.RightHandIndexStart };
    [SerializeField] private JointToBone RightHandIndex1 = new JointToBone { jointIndex = JointIndices.RightHandIndex1 };
    [SerializeField] private JointToBone RightHandIndex2 = new JointToBone { jointIndex = JointIndices.RightHandIndex2 };
    [SerializeField] private JointToBone RightHandIndex3 = new JointToBone { jointIndex = JointIndices.RightHandIndex3 };
    [SerializeField] private JointToBone RightHandIndexEnd = new JointToBone { jointIndex = JointIndices.RightHandIndexEnd };
    [SerializeField] private JointToBone RightHandMidStart = new JointToBone { jointIndex = JointIndices.RightHandMidStart };
    [SerializeField] private JointToBone RightHandMid1 = new JointToBone { jointIndex = JointIndices.RightHandMid1 };
    [SerializeField] private JointToBone RightHandMid2 = new JointToBone { jointIndex = JointIndices.RightHandMid2 };
    [SerializeField] private JointToBone RightHandMid3 = new JointToBone { jointIndex = JointIndices.RightHandMid3 };
    [SerializeField] private JointToBone RightHandMidEnd = new JointToBone { jointIndex = JointIndices.RightHandMidEnd };
    [SerializeField] private JointToBone RightHandPinkyStar = new JointToBone { jointIndex = JointIndices.RightHandPinkyStart };
    [SerializeField] private JointToBone RightHandPinky1 = new JointToBone { jointIndex = JointIndices.RightHandPinky1 };
    [SerializeField] private JointToBone RightHandPinky2 = new JointToBone { jointIndex = JointIndices.RightHandPinky2 };
    [SerializeField] private JointToBone RightHandPinky3 = new JointToBone { jointIndex = JointIndices.RightHandPinky3 };
    [SerializeField] private JointToBone RightHandPinkyEnd = new JointToBone { jointIndex = JointIndices.RightHandPinkyEnd };
    [SerializeField] private JointToBone RightHandRingStart = new JointToBone { jointIndex = JointIndices.RightHandRingStart };
    [SerializeField] private JointToBone RightHandRing1 = new JointToBone { jointIndex = JointIndices.RightHandRing1 };
    [SerializeField] private JointToBone RightHandRing2 = new JointToBone { jointIndex = JointIndices.RightHandRing2 };
    [SerializeField] private JointToBone RightHandRing3 = new JointToBone { jointIndex = JointIndices.RightHandRing3 };
    [SerializeField] private JointToBone RightHandRingEnd = new JointToBone { jointIndex = JointIndices.RightHandRingEnd };
    [SerializeField] private JointToBone RightHandThumbStar = new JointToBone { jointIndex = JointIndices.RightHandThumbStart };
    [SerializeField] private JointToBone RightHandThumb1 = new JointToBone { jointIndex = JointIndices.RightHandThumb1 };
    [SerializeField] private JointToBone RightHandThumb2 = new JointToBone { jointIndex = JointIndices.RightHandThumb2 };
    [SerializeField] private JointToBone RightHandThumbEnd = new JointToBone { jointIndex = JointIndices.RightHandThumbEnd };

    public Dictionary<JointIndices, BoneMap> GetBoneMaps()
    {
        var boneMapList = new List<JointToBone> {
            Root,
            Hips,
            LeftUpLeg,
            LeftLeg,
            LeftFoot,
            LeftToes,
            LeftToesEnd,
            RightUpLeg,
            RightLeg,
            RightFoot,
            RightToes,
            RightToesEnd,
            Spine1,
            Spine2,
            Spine3,
            Spine4,
            Spine5,
            Spine6,
            Spine7,
            LeftShoulder1,
            LeftArm,
            LeftForearm,
            LeftHand,
            LeftHandIndexStart,
            LeftHandIndex1,
            LeftHandIndex2,
            LeftHandIndex3,
            LeftHandIndexEnd,
            LeftHandMidStart,
            LeftHandMid1,
            LeftHandMid2,
            LeftHandMid3,
            LeftHandMidEnd,
            LeftHandPinkyStart,
            LeftHandPinky1,
            LeftHandPinky2,
            LeftHandPinky3,
            LeftHandPinkyEnd,
            LeftHandRingStart,
            LeftHandRing1,
            LeftHandRing2,
            LeftHandRing3,
            LeftHandRingEnd,
            LeftHandThumbStart,
            LeftHandThumb1,
            LeftHandThumb2,
            LeftHandThumbEnd,
            Neck1,
            Neck2,
            Neck3,
            Neck4,
            Head,
            Jaw,
            Chin,
            LeftEye,
            LeftEyeLowerLid,
            LeftEyeUpperLid,
            LeftEyeball,
            Nose,
            RightEye,
            RightEyeLowerLid,
            RightEyeUpperLid,
            RightEyeball,
            RightShoulder1,
            RightArm,
            RightForearm,
            RightHand,
            RightHandIndexStar,
            RightHandIndex1,
            RightHandIndex2,
            RightHandIndex3,
            RightHandIndexEnd,
            RightHandMidStart,
            RightHandMid1,
            RightHandMid2,
            RightHandMid3,
            RightHandMidEnd,
            RightHandPinkyStar,
            RightHandPinky1,
            RightHandPinky2,
            RightHandPinky3,
            RightHandPinkyEnd,
            RightHandRingStart,
            RightHandRing1,
            RightHandRing2,
            RightHandRing3,
            RightHandRingEnd,
            RightHandThumbStar,
            RightHandThumb1,
            RightHandThumb2,
            RightHandThumbEnd
        };

        var boneMapDictionary = new Dictionary<JointIndices, BoneMap>();
        
        foreach(var item in boneMapList)
        {
            boneMapDictionary.Add(item.jointIndex, new BoneMap { avatarBone = item.avatarBone });
        }

        return boneMapDictionary;
    }

}
