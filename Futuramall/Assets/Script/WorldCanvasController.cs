using UnityEngine;

public class WorldCanvasController : MonoBehaviour
{
    public Camera playerCamera;         // Assign Main Camera
    public float distance = 2.0f;       // Distance in front of player
    public GameObject canvasRoot;       // The GameObject holding your Canvas

    private bool isVisible = false;

    void Start()
    {
        if (canvasRoot != null)
            canvasRoot.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleCanvas();
        }
    }

    public void ToggleCanvas()
    {
        if (!isVisible)
        {
            ShowCanvas();
        }
        else
        {
            HideCanvas();
        }
    }

    public void ShowCanvas()
    {
        isVisible = true;
        canvasRoot.SetActive(true);

        // Position in front of camera
        Vector3 forward = playerCamera.transform.forward;
        Vector3 spawnPosition = playerCamera.transform.position + forward * distance;
        canvasRoot.transform.position = spawnPosition;

        // Rotate to face camera (only on Y axis if you want it flat)
        Vector3 lookDir = canvasRoot.transform.position - playerCamera.transform.position;
        lookDir.y = 0; // Optional: keep upright
        canvasRoot.transform.rotation = Quaternion.LookRotation(lookDir);
    }

    public void HideCanvas()
    {
        isVisible = false;
        canvasRoot.SetActive(false);
    }
}
