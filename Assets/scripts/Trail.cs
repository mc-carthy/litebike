﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent (typeof (LineRenderer))]
public class Trail : MonoBehaviour {

    [SerializeField]
    private float pointSpacing;

	private LineRenderer line;
    private List<Vector2> points;

    private void Awake ()
    {
        line = GetComponent<LineRenderer> ();
        points = new List<Vector2> ();
    }

    private void Start ()
    {
        SetPoint ();
    }

    private void Update ()
    {
        if (Vector3.Distance (points.Last (), transform.position) > pointSpacing)
        {
            SetPoint ();
        }
    }

    private void SetPoint ()
    {
        points.Add (transform.position);

        line.numPositions = points.Count;
        line.SetPosition (points.Count - 1, transform.position);
    }

}