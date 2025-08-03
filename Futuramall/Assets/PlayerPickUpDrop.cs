using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickUpDist = 5f;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycastHit, pickUpDist))
            {
                Debug.Log(raycastHit.transform);
            }
        }
    }
}
