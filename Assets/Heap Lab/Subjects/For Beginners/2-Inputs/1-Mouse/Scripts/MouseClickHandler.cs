#define OverlayCamera

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

#if OverlayCamera
public class MouseClickHandler : MonoBehaviour
{
    public bool ShowWorldPosition;
    public bool SnapWorldPositionToGround;
    public TextMeshProUGUI PositionText;
    public GameObject Ground;
    public Canvas Canvas;

    Camera mainCamera;
    UnityEngine.Plane plane;

    private void Awake()
    {
        mainCamera = Camera.main;
        plane = new Plane(Ground.transform.up, Ground.transform.position);
    }
    private void Update()
    {
        Vector3 clickPosition = Input.mousePosition;

        if (SnapWorldPositionToGround)
        {
            Ray ray = mainCamera.ScreenPointToRay(clickPosition);
            float enter;
            if (plane.Raycast(ray, out enter))
            {
                Vector3 planePosition = ray.GetPoint(enter);
                PositionText.text = "Position on plane: " + planePosition.ToString();
                Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(mainCamera, planePosition);
                PositionText.rectTransform.parent.position = screenPoint;

                if (Input.GetMouseButtonDown(0))
                {
                    SpawnPositionText(screenPoint);
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
                SpawnPositionText(screenPoint);
            }
        }
        else
        {
            PositionText.text = "Screen Position: " + clickPosition.ToString();
            PositionText.rectTransform.parent.position = clickPosition;

            if (Input.GetMouseButtonDown(0))
            {
                SpawnPositionText(clickPosition);
            }
        }
    }

    private void SpawnPositionText(Vector3 position)
    {
        RectTransform newText = Instantiate(PositionText.rectTransform, Canvas.transform);
        newText.position = position;
        newText.GetComponent<TextMeshProUGUI>().text = PositionText.text;
    }
}
#else

public class MouseClickHandler : MonoBehaviour
{
    public bool ShowWorldPosition;
    public bool SnapWorldPositionToGround;
    public TextMeshProUGUI PositionText;
    public GameObject Ground;
    public Canvas Canvas;

    private Camera mainCamera;
    private UnityEngine.Plane plane;

    private void Awake()
    {
        mainCamera = Canvas.worldCamera; // Canvas'ın bağlı olduğu kamerayı kullanıyoruz
        plane = new UnityEngine.Plane(Ground.transform.up, Ground.transform.position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Input.mousePosition;

            if (SnapWorldPositionToGround && Ground != null)
            {
                Ray ray = mainCamera.ScreenPointToRay(clickPosition);
                float enter;
                if (plane.Raycast(ray, out enter))
                {
                    Vector3 planePosition = ray.GetPoint(enter);
                    PositionText.text = "Position on plane: " + planePosition.ToString();
                    Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(mainCamera, planePosition);
                    PositionText.rectTransform.position = screenPoint;

                    SpawnPositionText(screenPoint);
                }
            }
            else if (ShowWorldPosition)
            {
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(clickPosition.x, clickPosition.y, mainCamera.nearClipPlane));
                PositionText.text = "World Position: " + worldPosition.ToString();
                Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(mainCamera, worldPosition);
                PositionText.rectTransform.position = screenPoint;

                SpawnPositionText(screenPoint);
            }
            else
            {
                PositionText.text = "Screen Position: " + clickPosition.ToString();
                PositionText.rectTransform.position = clickPosition;

                SpawnPositionText(clickPosition);
            }
        }
    }

    private void SpawnPositionText(Vector3 position)
    {
        RectTransform newText = Instantiate(PositionText.rectTransform, Canvas.transform);
        newText.position = position;
        newText.GetComponent<TextMeshProUGUI>().text = PositionText.text;
    }
}
#endif