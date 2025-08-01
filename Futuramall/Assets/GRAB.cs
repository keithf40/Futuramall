using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
public float grabDistance = 3f; // Maximum distance to grab objects
public Transform holdPoint; // Point where the object will be held
private GameObject grabbedObject;
private Rigidbody grabbedRigidbody;

void Update()
{
if (Input.GetKeyDown(KeyCode.E)) // Left mouse button to grab/release
{
if (grabbedObject == null)
{
TryGrabObject();
}
else
{
ReleaseObject();
}
}

if (grabbedObject != null)
{
// Keep the object at the hold point
grabbedRigidbody.MovePosition(holdPoint.position);
}
}

void TryGrabObject()
{
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
if (Physics.Raycast(ray, out RaycastHit hit, grabDistance))
{
if (hit.collider.CompareTag("Grabbable")) // Ensure object has "Grabbable" tag
{
grabbedObject = hit.collider.gameObject;
grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();

if (grabbedRigidbody != null)
{
grabbedRigidbody.useGravity = false; // Disable gravity while holding
grabbedRigidbody.freezeRotation = true; // Prevent rotation
}
}
}
}

void ReleaseObject()
{
if (grabbedRigidbody != null)
{
grabbedRigidbody.useGravity = true;
grabbedRigidbody.freezeRotation = false;
}

grabbedObject = null;
grabbedRigidbody = null;
}
}
