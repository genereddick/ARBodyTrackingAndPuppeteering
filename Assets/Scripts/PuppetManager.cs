using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;

public class PuppetManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Empty Gameobject with the Avatar armature inside")]
    private GameObject avatarParent;

    private Transform avatar;

    [SerializeField]
    [Tooltip("Default position offset from the controlled robot")]
    private Vector3 avatarPositionOffset;

    [SerializeField]
    [Tooltip("Default rotation offset from the controlled robot")]
    private Vector3 avatarRotationOffset;

    private HumanBoneMap humanBoneMap = new HumanBoneMap();

    private AvatarRobotBoneMap avatarRobotBoneMap;

    private Renderer controlledRobotRenderer;

    private Transform controlledRobot;

    private bool isOverlay = false;

    private bool startAvatarTracking = false;

    private AvatarRobotTestSuite avatarRobotTestSuite;

    private ARHumanBodyManager arHumanBodyManager;

    private bool isBodyTracking = false;

    private void Start()
    {
        avatarRobotTestSuite = GetComponent<AvatarRobotTestSuite>();
        arHumanBodyManager = FindObjectOfType<ARHumanBodyManager>();

        isBodyTracking = false;
        arHumanBodyManager.SetTrackablesActive(isBodyTracking);
        arHumanBodyManager.enabled = isBodyTracking;

        avatar = avatarParent.transform.GetChild(0);

        avatarParent.transform.localPosition += avatarPositionOffset;
        avatarParent.transform.localRotation *= Quaternion.Euler(avatarRotationOffset);

        avatarRobotBoneMap = avatar.GetComponent<AvatarRobotBoneMap>();
        humanBoneMap.BoneMaps = avatarRobotBoneMap.GetBoneMaps();
    }

    private void LateUpdate()
    {
        if (!startAvatarTracking) return;

        avatarParent.transform.localPosition += humanBoneMap.DeltaLocalPosition;
        avatarParent.transform.localRotation *= humanBoneMap.DeltaLocalRotation;

        for (var i = 0; i < humanBoneMap.BoneMaps.Count; i++)
        {
            var jointIndex = (JointIndices)i;

            if (!humanBoneMap.BoneMaps.ContainsKey(jointIndex)) continue;

            var boneMap = humanBoneMap.BoneMaps[jointIndex];
            if (boneMap.avatarBone == null || boneMap.robotBone == null) continue;

            //root bone rotation shouldn't ever change, should start at hips
            if (jointIndex == JointIndices.Root) continue;

            boneMap.UpdateAvatarBoneLocalRotation();
        }
    }

    public void InitRobotPose(Transform robot, Vector3 initialPosition, Quaternion initialRotation, Dictionary<JointIndices, Transform> robotBoneMapping)
    {
        controlledRobot = robot;
        controlledRobotRenderer = controlledRobot.gameObject.GetComponentInChildren<Renderer>();

        humanBoneMap.robotLocalPosition = initialPosition;
        humanBoneMap.robotLocalRotation = initialRotation;
        avatarParent.transform.localScale = humanBoneMap.robotLocalScale;

        for (var i = 0; i < robotBoneMapping.Count; i++)
        {
            var jointIndex = (JointIndices)i;

            if (!humanBoneMap.BoneMaps.ContainsKey(jointIndex)) continue;

            var robotBone = robotBoneMapping[jointIndex];

            var boneMap = humanBoneMap.BoneMaps[jointIndex];
            boneMap.robotBone = robotBone;

            boneMap.SetOriginalAvatarRobotRotationOffset();
        }

        startAvatarTracking = true;
    }

    public void UpdateRobotPose(Vector3 localPosition, Quaternion localRotation, float estimatedHeight)
    {
        humanBoneMap.robotLocalPosition = localPosition;
        humanBoneMap.robotLocalRotation = localRotation;

        if (humanBoneMap.robotEstimatedHeight != estimatedHeight)
        {
            humanBoneMap.robotEstimatedHeight = estimatedHeight;
            avatarParent.transform.localScale = humanBoneMap.robotLocalScale;
            Debug.Log("Estimated Height Changed: " + estimatedHeight);
        }
    }

    public void HideRobot()
    {
        if (controlledRobotRenderer == null) return;

        controlledRobotRenderer.enabled = !controlledRobotRenderer.enabled;
    }

    public void StartBodyTracking()
    {
        isOverlay = false;

        if (controlledRobotRenderer != null)
        {
            controlledRobotRenderer.enabled = true;
        }

        avatarRobotTestSuite.isTesting = false;

        isBodyTracking = !isBodyTracking;
        arHumanBodyManager.SetTrackablesActive(isBodyTracking);
        arHumanBodyManager.enabled = isBodyTracking;
    }
    public void StartTest()
    {
        isBodyTracking = false;
        arHumanBodyManager.SetTrackablesActive(isBodyTracking);
        arHumanBodyManager.enabled = isBodyTracking;

        avatarRobotTestSuite.isTesting = !avatarRobotTestSuite.isTesting;
        if (avatarRobotTestSuite.isTesting)
        {
            StartCoroutine(avatarRobotTestSuite.TestPositionUpdate());
        }
    }

    public void OverlayAvatar()
    {
        if (controlledRobot == null) return;

        isOverlay = !isOverlay;

        if (isOverlay)
        {
            BoneMap rootBoneMap;
            if (humanBoneMap.BoneMaps.TryGetValue(JointIndices.Root, out rootBoneMap))
            {
                avatarParent.transform.position = rootBoneMap.robotBone.position;
            }
        }
    }

    public void DebugVector3ToString(string name, Vector3 vector3)
    {
        if (vector3 == Vector3.zero) return;

        var debugString = $"{name} | x:{vector3.x:0.##} y:{vector3.y:0.##} z:{vector3.z:0.##}";
        Debug.Log(debugString);
    }
}
