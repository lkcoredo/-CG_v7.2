using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlayer : MonoBehaviour
{

    public Vector3 position1 = new Vector3(0, 0, 0);
    public Vector3 position2 = new Vector3(732, -227, 739);
    public Color newColor = new Color(0.3f, 0.4f, 0.6f, 0.3f);

    void Start()
    {
        DrawLine(position1, position2, newColor);
    }

    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
