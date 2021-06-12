using UnityEngine;

public class BoneMap 
{
    public Transform avatarBone;
    public Transform robotBone;

    public Quaternion originalRotationOffset;

    public void UpdateAvatarBoneLocalRotation()
    {
        var lookRotation = Quaternion.LookRotation(robotBone.forward, robotBone.up);
        var rotation = lookRotation * Quaternion.Inverse(originalRotationOffset);
        
        avatarBone.rotation = rotation.normalized;
    }

    public void SetOriginalAvatarRobotRotationOffset()
    {
        if (avatarBone == null || robotBone == null) return;

        var robotBoneLocalRotation = robotBone.worldToLocalMatrix.rotation;
        var avatarBoneLocalRotation = avatarBone.worldToLocalMatrix.rotation;

        var offset = avatarBoneLocalRotation * Quaternion.Inverse(robotBoneLocalRotation);
        originalRotationOffset = offset.normalized;
    }
}