using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseClickHandler : MonoBehaviour
{
    public bool ShowWorldPosition;
    public bool SnapWorldPositionToGround;
    public TextMeshProUGUI PositionText;
    public UnityEngine.Plane Plane;
    public Canvas Canvas;

    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        Vector3 clickPosition = Input.mousePosition;

        if (SnapWorldPositionToGround)
        {
            Ray ray = mainCamera.ScreenPointToRay(clickPosition);
            float enter;
            if (Plane.Raycast(ray, out enter))
            {
                Vector3 planePosition = ray.GetPoint(enter);
                PositionText.text = "Position on plane: " + planePosition.ToString();
                Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(mainCamera, planePosition);
                PositionText.rectTransform.parent.position = screenPoint;

                if (Input.GetMouseButtonDown(0))
                {
                    RectTransform pointer = Instantiate(PositionText.rectTransform.parent.GetComponent<RectTransform>());
                    pointer.parent = Canvas.transform;
                    pointer.position = screenPoint;
                }
            }
        }
        else if (ShowWorldPosition)
        {
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(clickPosition.x, clickPosition.y, mainCamera.nearClipPlane));
            PositionText.text = "World Position: " + worldPosition.ToString();
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(mainCamera, worldPosition);
            PositionText.rectTransform.parent.position = screenPoint;
            if (Input.GetMouseButtonDown(0))
            {
                RectTransform pointer = Instantiate(PositionText.rectTransform.parent.GetComponent<RectTransform>());
                pointer.parent = Canvas.transform;
                pointer.position = screenPoint;
            }
        }
        else
        {
            PositionText.text = "Screen Position: " + clickPosition.ToString();
            PositionText.rectTransform.parent.position = clickPosition;
            if (Input.GetMouseButtonDown(0))
            {
                RectTransform pointer = Instantiate(PositionText.rectTransform.parent.GetComponent<RectTransform>());
                pointer.parent = Canvas.transform;
                pointer.position = clickPosition;
            }
        }
    }
}
