using UnityEngine;

public class WorldCanvasController : MonoBehaviour
{
    [Header("Canvas Settings")]
    public Camera playerCamera;           // Assign Main Camera
    public float distance = 2.0f;         // Distance in front of player
    public GameObject canvasRoot;         // The GameObject holding your Canvas

    [Header("Input Settings")]
    public bool enableKeyboardToggle = true; // Can this canvas be toggled by key?
    public KeyCode toggleKey = KeyCode.None; // Assign key in Inspector (optional)

    private bool isVisible = false;

    void Start()
    {
        if (canvasRoot != null)
            canvasRoot.SetActive(false);
    }

    void Update()
    {
        if (enableKeyboardToggle && toggleKey != KeyCode.None && Input.GetKeyDown(toggleKey))
        {
            ToggleCanvas();
        }
    }

    public void ToggleCanvas()
    {
        if (!isVisible)
            ShowCanvas();
        else
            HideCanvas();
    }

    public void ShowCanvas()
    {
        isVisible = true;
        canvasRoot.SetActive(true);

        Vector3 forward = playerCamera.transform.forward;
        Vector3 spawnPosition = playerCamera.transform.position + forward * distance;
        canvasRoot.transform.position = spawnPosition;

        Vector3 lookDir = canvasRoot.transform.position - playerCamera.transform.position;
        lookDir.y = 0;
        canvasRoot.transform.rotation = Quaternion.LookRotation(lookDir);
    }

    public void HideCanvas()
    {
        isVisible = false;
        canvasRoot.SetActive(false);
    }
}
