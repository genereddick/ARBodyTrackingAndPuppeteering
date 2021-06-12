using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation.Samples;

public class AvatarRobotTestSuite : MonoBehaviour
{
    [Header("Test")]

    [SerializeField]
    private float testTimeBetweenUpdates = 1f;

    [SerializeField]
    private Vector3 robotInitialPosition = new Vector3(0, 0, 3f);

    [Header("Random Robot Pose")]

    [SerializeField]
    private Vector3 minRandomPositionChange = Vector3.zero;

    [SerializeField]
    private Vector3 maxRandomPositionChange = Vector3.zero;

    [SerializeField]
    private Vector3 minRandomRotationChange = Vector3.zero;

    [SerializeField]
    private Vector3 maxRandomRotationChange = Vector3.zero;

    [Header("Random Joint Pose")]

    [SerializeField]
    private Vector3 minRandomJointPositionChange = Vector3.zero;

    [SerializeField]
    private Vector3 maxRandomJointPositionChange = Vector3.zero;

    [SerializeField]
    private Vector3 minRandomJointRotationChange = Vector3.zero;

    [SerializeField]
    private Vector3 maxRandomJointRotationChange = Vector3.zero;

    [Header("Random Scale Factor")]

    [SerializeField]
    private float minRandomHeight = 1.0f;

    [SerializeField]
    private float maxRandomHeight = 1.0f;

    private HumanBodyTracker humanBodyTracker;

    public bool isTesting;

    void Start()
    {
        humanBodyTracker = GetComponent<HumanBodyTracker>();
       
    }
    public IEnumerator TestPositionUpdate()
    {
        yield return new WaitForSeconds(testTimeBetweenUpdates);

        var randomHeight = Random.Range(minRandomHeight, maxRandomHeight);
        humanBodyTracker.TestHumanBodyAdded(randomHeight, robotInitialPosition);

        while (isTesting)
        {
            yield return new WaitForSeconds(testTimeBetweenUpdates);

            var rndPos = new Vector3(
            Random.Range(minRandomPositionChange.x, maxRandomPositionChange.x),
            Random.Range(minRandomPositionChange.y, maxRandomPositionChange.y),
            Random.Range(minRandomPositionChange.z, maxRandomPositionChange.z));

            var rndRot = Quaternion.Euler(
              Random.Range(minRandomRotationChange.x, maxRandomRotationChange.x),
              Random.Range(minRandomRotationChange.y, maxRandomRotationChange.y),
              Random.Range(minRandomRotationChange.z, maxRandomRotationChange.z));



            var rndJointPos = new Vector3(
             Random.Range(minRandomJointPositionChange.x, maxRandomJointPositionChange.x),
             Random.Range(minRandomJointPositionChange.y, maxRandomJointPositionChange.y),
             Random.Range(minRandomJointPositionChange.z, maxRandomJointPositionChange.z));

            var rndJointRot = Quaternion.Euler(
              Random.Range(minRandomJointRotationChange.x, maxRandomJointRotationChange.x),
              Random.Range(minRandomJointRotationChange.y, maxRandomJointRotationChange.y),
              Random.Range(minRandomJointRotationChange.z, maxRandomJointRotationChange.z));

            humanBodyTracker.TestHumanBodyMoved(rndPos, rndRot, rndJointPos, rndJointRot);
        }
    }
}
