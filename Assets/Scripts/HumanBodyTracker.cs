using System;
using System.Collections.Generic;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class HumanBodyTracker : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Skeleton prefab to be controlled.")]
        GameObject m_SkeletonPrefab;

        [SerializeField]
        [Tooltip("The ARHumanBodyManager which will produce body tracking events.")]
        ARHumanBodyManager m_HumanBodyManager;

        /// <summary>
        /// Get/Set the <c>ARHumanBodyManager</c>.
        /// </summary>
        public ARHumanBodyManager humanBodyManager
        {
            get { return m_HumanBodyManager; }
            set { m_HumanBodyManager = value; }
        }

        /// <summary>
        /// Get/Set the skeleton prefab.
        /// </summary>
        public GameObject skeletonPrefab
        {
            get { return m_SkeletonPrefab; }
            set { m_SkeletonPrefab = value; }
        }

        Dictionary<TrackableId, BoneController> m_SkeletonTracker = new Dictionary<TrackableId, BoneController>();

        private PuppetManager puppetManager;

        private BoneController boneController;

        private float estimatedHeightScaleFactor = 1.0f;

        private void Start()
        {
            puppetManager = GetComponent<PuppetManager>();
        }

        void OnEnable()
        {
            Debug.Assert(m_HumanBodyManager != null, "Human body manager is required.");
            m_HumanBodyManager.humanBodiesChanged += OnHumanBodiesChanged;

            humanBodyManager.pose3DScaleEstimationRequested = true;
        }

        void OnDisable()
        {
            if (m_HumanBodyManager != null)
            {
                m_HumanBodyManager.humanBodiesChanged -= OnHumanBodiesChanged;
                humanBodyManager.pose3DScaleEstimationRequested = true;
            }
        }

        void OnHumanBodiesChanged(ARHumanBodiesChangedEventArgs eventArgs)
        {
            foreach (var humanBody in eventArgs.added)
            {
                if (!m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    Debug.Log($"Adding a new skeleton [{humanBody.trackableId}].");

                    var newSkeletonGO = Instantiate(m_SkeletonPrefab, humanBody.transform);
                    boneController = newSkeletonGO.GetComponent<BoneController>();
                    m_SkeletonTracker.Add(humanBody.trackableId, boneController);
                }

                boneController.InitializeSkeletonJoints();

                puppetManager.InitRobotPose(boneController.transform, humanBody.transform.localPosition, humanBody.transform.localRotation, boneController.robotBoneMapping);

                boneController.ApplyBodyPose(humanBody);
            }

            foreach (var humanBody in eventArgs.updated)
            {
                if (m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    boneController.ApplyBodyPose(humanBody);
                    if (humanBody.estimatedHeightScaleFactor != estimatedHeightScaleFactor)
                    {
                        estimatedHeightScaleFactor = humanBody.estimatedHeightScaleFactor;
                        boneController.transform.localScale = new Vector3(humanBody.estimatedHeightScaleFactor, humanBody.estimatedHeightScaleFactor, humanBody.estimatedHeightScaleFactor);
                    }

                    puppetManager.UpdateRobotPose(humanBody.transform.localPosition, humanBody.transform.localRotation, humanBody.estimatedHeightScaleFactor);
                }
            }

            foreach (var humanBody in eventArgs.removed)
            {
                Debug.Log($"Removing a skeleton [{humanBody.trackableId}].");
                if (m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    Destroy(boneController.gameObject);
                    m_SkeletonTracker.Remove(humanBody.trackableId);
                }
            }
        }

        

        public void TestHumanBodyAdded(float randomHeight, Vector3 robotInitialPosition)
        {
            var newSkeletonGO = Instantiate(m_SkeletonPrefab);
            boneController = newSkeletonGO.GetComponent<BoneController>();
            boneController.InitializeSkeletonJoints();

            boneController.transform.localPosition = robotInitialPosition;

            estimatedHeightScaleFactor = randomHeight;
            newSkeletonGO.transform.localScale = new Vector3(estimatedHeightScaleFactor, estimatedHeightScaleFactor, estimatedHeightScaleFactor);

            puppetManager.InitRobotPose(
                boneController.transform, 
                boneController.transform.localPosition, 
                boneController.transform.localRotation, 
                boneController.robotBoneMapping);
        }

        public void TestHumanBodyMoved(Vector3 randomPosition, Quaternion randomRotation, Vector3 randomJointPosition, Quaternion randomJointRotation)
        {
            boneController.transform.localPosition += randomPosition;
            boneController.transform.localRotation *= randomRotation;
            
            boneController.TestApplyBodyPose(randomJointRotation);

            puppetManager.UpdateRobotPose(boneController.transform.localPosition, boneController.transform.localRotation, estimatedHeightScaleFactor);
        }
    }
}