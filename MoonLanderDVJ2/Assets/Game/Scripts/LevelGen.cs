using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public int points;
    public Vector2[] pointsPositions;
    public float minRangeX; //  1.5
    public float maxRangeX; //  6.0
    public float minRangeY; //  0.0
    public float maxRangeY; // 16.0
    public float rndRate;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private float rndPosX;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();

        

        lineRenderer.positionCount = points;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            if (i != 0)
            {
                rndPosX = lineRenderer.GetPosition(i - 1).x + Random.Range(minRangeX, maxRangeX);
                if ((Random.Range(0f, 1f)) <= rndRate)
                {
                    lineRenderer.SetPosition(i, new Vector3(rndPosX, lineRenderer.GetPosition(i - 1).y, 0));
                }
                else
                {
                    lineRenderer.SetPosition(i, new Vector3(rndPosX, Random.Range(minRangeY, maxRangeY), 0));
                }
            }
            else
            {
                lineRenderer.SetPosition(i, new Vector3(0, Random.Range(minRangeY, maxRangeY), 0));
            }


        }

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            pointsPositions[i] = new Vector2(lineRenderer.GetPosition(i).x, lineRenderer.GetPosition(i).y);
        }


        edgeCollider.points = pointsPositions;
    }
}