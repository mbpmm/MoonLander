using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public int points;
    public Vector2[] pointPos;
    public float minX; 
    public float maxX; 
    public float minY; 
    public float maxY; 
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
                rndPosX = lineRenderer.GetPosition(i - 1).x + Random.Range(minX, maxX);
                if ((Random.Range(0f, 1f)) <= rndRate)
                {
                    lineRenderer.SetPosition(i, new Vector3(rndPosX, lineRenderer.GetPosition(i - 1).y, 0));
                }
                else
                {
                    lineRenderer.SetPosition(i, new Vector3(rndPosX, Random.Range(minY, maxY), 0));
                }
            }
            else
            {
                lineRenderer.SetPosition(i, new Vector3(0, Random.Range(minY, maxY), 0));
            }


        }

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            pointPos[i] = new Vector2(lineRenderer.GetPosition(i).x, lineRenderer.GetPosition(i).y);
        }


        edgeCollider.points = pointPos;
    }
}