using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public Material lineMaterial; // Drag your material here in the Inspector
    public string sortingLayerName = "Foreground"; // The sorting layer name you want to set.
    public int sortingOrder = 1; // The order in layer you want to set.
    public int linecount;
    private int pointscount;
    public int maxcount;

    private List<GameObject> lineObjects = new List<GameObject>();
    private List<Vector2> points = new List<Vector2>();

    void Update()
    {
        if (Input.touchCount > 0 && linecount > -1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            if (touch.phase == TouchPhase.Began)
            {
                pointscount = 0;
                CreateNewLine();
                linecount = linecount - 1;
                points.Clear();
                points.Add(touchPosition);
                UpdateLineRenderer(touchPosition);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (points.Count < 2) 
                {
                    Destroy(lineObjects[lineObjects.Count - 1]);
                    linecount = linecount + 1;
                }
                else
                {
                    UpdateCollider();
                }
            }
            else if (touch.phase == TouchPhase.Moved && pointscount < maxcount)
            {
                if (Vector2.Distance(points[points.Count - 1], touchPosition) > 0.1f) // Add point if it's far enough from the last point
                {
                    pointscount = pointscount + 1;
                    points.Add(touchPosition);
                    UpdateLineRenderer(touchPosition);
                    // UpdateCollider();
                }
            }
        }
    }

    private void CreateNewLine()
    {
        GameObject lineObject = new GameObject("Line");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        EdgeCollider2D edgeCollider = lineObject.AddComponent<EdgeCollider2D>();

        // Configure LineRenderer
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.useWorldSpace = true;
        lineRenderer.numCornerVertices = 10; // Adjust this number for smoother corners
        lineRenderer.numCapVertices = 10;    // Adjust this number for smoother end caps

        lineRenderer.sortingLayerName = sortingLayerName;
        lineRenderer.sortingOrder = sortingOrder;

        // Configure EdgeCollider2D
        edgeCollider.edgeRadius = 0.05f;
        edgeCollider.points = new Vector2[0];

        lineObjects.Add(lineObject);
    }

    private void UpdateLineRenderer(Vector2 touchPosition)
    {
        LineRenderer lineRenderer = lineObjects[lineObjects.Count - 1].GetComponent<LineRenderer>();
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, new Vector3(touchPosition.x, touchPosition.y, 0));
    }

    private void UpdateCollider()
    {
        if (points.Count > 2)
        {
            EdgeCollider2D edgeCollider = lineObjects[lineObjects.Count - 1].GetComponent<EdgeCollider2D>();
            edgeCollider.points = points.ToArray();
        }
    }

    public void DeleteLastLine()
    {
        Destroy(lineObjects[lineObjects.Count - 1]);
    }

    public void IncrementLineCount()
    {
        linecount = linecount + 1;
    }
}