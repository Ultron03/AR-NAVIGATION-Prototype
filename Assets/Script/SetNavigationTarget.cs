using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetNavigationTarget : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera topDownCamera;
    [SerializeField]
    private GameObject navTargetObject;

    // Current Calculated Path
    private NavMeshPath path;
    //LineRenderer to display Path
    private LineRenderer line;

    private bool lineToggle = false;

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            lineToggle = !lineToggle;
        }
        if (lineToggle)
        {
            NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            line.enabled = true;
        }
    }
}
