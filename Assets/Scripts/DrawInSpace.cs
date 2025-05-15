using UnityEngine;
using System;
using System.Collections.Generic;

public class DrawInSpace : MonoBehaviour
{
    public LineRenderer linePrefab;
    private LineRenderer currentLine;
    private List<Vector3> points = new List<Vector3>();
    public float minDistance = 0.01f;

    private bool isDrawing = false;

    void Update()
    {
        if (isDrawing)
        {
            Vector3 currentPos = transform.position;
            if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], currentPos) > minDistance)
            {
                points.Add(currentPos);
                currentLine.positionCount = points.Count;
                currentLine.SetPositions(points.ToArray());
            }
        }
    }

    public void StartDrawing()
    {
        isDrawing = true;
        points.Clear();
        currentLine = Instantiate(linePrefab);
        currentLine.positionCount = 0;
    }

    public void StopDrawing()
    {
        isDrawing = false;
        currentLine = null;
    }
}
