using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private GameObject heldObject;
    public float radius = 2f;
    public float distance = 2f;
    public float height = 1f;

    private void Update()
    {
        var t = transform;
        var pressedE = Input.GetKeyDown(KeyCode.E);
        if (pressedE)
        {
            if(heldObject != null)
            {
                var rigidBody = heldObject.GetComponent<Rigidbody>();
                rigidBody.linearDamping = 1f;
                rigidBody.useGravity = true;
                rigidBody.isKinematic = false;
                rigidBody.constraints = RigidbodyConstraints.None;
                heldObject = null;
            }
            else
            {
                var hits = Physics.SphereCastAll(t.position + t.forward, radius, t.forward, radius);
                var hitIndex = Array.FindIndex(hits, hit => hit.transform.tag == "Pickupable");

                if (hitIndex != -1)
                {
                    var hitObject = hits[hitIndex].transform.gameObject;
                    heldObject = hitObject;
                    var rigidBody = heldObject.GetComponent<Rigidbody>();
                    rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
                    rigidBody.linearDamping = 25f;
                    rigidBody.useGravity = false;
                    rigidBody.isKinematic = true;

                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(heldObject != null)
        {
            var t = transform;
            heldObject.transform.position = t.position + distance * t.forward + height * t.up;
            heldObject.transform.rotation = t.rotation;
        }
    }
}