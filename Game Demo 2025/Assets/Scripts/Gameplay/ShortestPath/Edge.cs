using UnityEngine;
using System.Collections;

public class Edge : MonoBehaviour
{
    [SerializeField] Transform _start;
    [SerializeField] Transform _end;

    [SerializeField] LineRenderer line;

	// Use this for initialization
	void Start () 
    {
        // Add a Line Renderer to the GameObject
        line = this.gameObject.GetComponent<LineRenderer>();
        // Set the width of the Line Renderer
        line.startWidth = 0.05F;
        line.endWidth = 0.05F;
        // Set the number of vertex fo the Line Renderer
        line.positionCount = 2;
        DrawLine();
	}

    void DrawLine()
    {
        line.SetPosition(0, _start.position);
        line.SetPosition(1, _end.position);

        this.transform.position = (_start.position + _end.position) / 2;
    }
}
