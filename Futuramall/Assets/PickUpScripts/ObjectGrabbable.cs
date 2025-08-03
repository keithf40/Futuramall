using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objRigidbody;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        objRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objGrabPointTransform)
    {
        this.objectGrabPointTransform = objGrabPointTransform;
        objRigidbody.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        float lerpSpeed = 10f;
        if (objectGrabPointTransform != null)
        {
            Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objRigidbody.MovePosition(objectGrabPointTransform.position);
            objRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            objRigidbody.linearDamping = 5;
        }
    }
}
