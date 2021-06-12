using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using System;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class BoneController : MonoBehaviour
    {
        // 3D joint skeleton

        const int k_NumSkeletonJoints = 91;

        [SerializeField]
        [Tooltip("The root bone of the skeleton.")]
        Transform m_SkeletonRoot;

        /// <summary>
        /// Get/Set the root bone of the skeleton.
        /// </summary>
        public Transform skeletonRoot {
            get {
                return m_SkeletonRoot;
            }
            set {
                m_SkeletonRoot = value;
            }
        }

        public Dictionary<JointIndices, Transform> robotBoneMapping = new Dictionary<JointIndices, Transform>();

        public void InitializeSkeletonJoints()
        {
            // Walk through all the child joints in the skeleton and
            // store the skeleton joints at the corresponding index in the m_BoneMapping array.
            // This assumes that the bones in the skeleton are named as per the
            // JointIndices enum above.
            Queue<Transform> nodes = new Queue<Transform>();
            nodes.Enqueue(m_SkeletonRoot);
            while (nodes.Count > 0)
            {
                Transform next = nodes.Dequeue();
                for (int i = 0; i < next.childCount; ++i)
                {
                    nodes.Enqueue(next.GetChild(i));
                }
                ProcessJoint(next);
            }
        }

        public void ApplyBodyPose(ARHumanBody body)
        {
            var joints = body.joints;
            if (!joints.IsCreated)
                return;

            for (int i = 0; i < k_NumSkeletonJoints; ++i)
            {
                XRHumanBodyJoint joint = joints[i];

                var jointIndex = (JointIndices)i;
                if (!robotBoneMapping.ContainsKey(jointIndex)) continue;

                var bone = robotBoneMapping[jointIndex];
                if (bone == null) continue;

                bone.transform.localPosition = joint.localPose.position;
                bone.transform.localRotation = joint.localPose.rotation;

            }
        }

        public void DebugVector3ToString(string name, Vector3 vector3)
        {
            var x = Mathf.Round(vector3.x * 100f) / 100f;
            var y = Mathf.Round(vector3.y * 100f) / 100f;
            var z = Mathf.Round(vector3.z * 100f) / 100f;

            Debug.Log($"{name} | x:{x} y:{y} z:{z}");
        }

        public void TestApplyBodyPose(Quaternion randomRotation)
        {
            for (int i = 0; i < k_NumSkeletonJoints; ++i)
            {
                var jointIndex = (JointIndices)i;

                //root bone shouldn't ever change, should start at hips
                if (jointIndex == JointIndices.Root) continue;

                if (!robotBoneMapping.ContainsKey(jointIndex)) continue;

                var bone = robotBoneMapping[jointIndex];
                if (bone == null) continue;

                bone.transform.localRotation *= randomRotation;

            }
        }

        void ProcessJoint(Transform joint)
        {
            int index = GetJointIndex(joint.name);
            if (index >= 0 && index < k_NumSkeletonJoints)
            {
                var jointIndex = (JointIndices)index;

                if (robotBoneMapping.ContainsKey(jointIndex))
                {
                    robotBoneMapping[jointIndex] = joint;
                }
                else
                {
                    robotBoneMapping.Add(jointIndex, joint);
                }
            }
            else
            {
                Debug.LogWarning($"{joint.name} was not found.");
            }
        }

        // Returns the integer value corresponding to the JointIndices enum value
        // passed in as a string.
        int GetJointIndex(string jointName)
        {
            foreach (int i in Enum.GetValues(typeof(JointIndices)))
            {
                var jointIndex = (JointIndices)i;

                var jointIndexName = jointIndex.ToString().ToLower();
                var strippedJointName = jointName.ToLower().Replace("_joint", "").Replace("_", "");

                if (jointIndexName != strippedJointName) continue;

                return (int)jointIndex;
            }
            return -1;
        }
    }
}