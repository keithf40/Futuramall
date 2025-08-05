using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class CenterUIClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = new Vector2(Screen.width / 2, Screen.height / 2) // center of screen
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (var result in results)
            {
                Button button = result.gameObject.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.Invoke(); // simulate click
                    break;
                }
            }
        }
    }
}
