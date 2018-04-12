﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFunctions : MonoBehaviour
{
    //public GameObject s;
    //public GameObject end;
    //public void Start()
    //{
    //    UtilityFunctions.lineConnect(s, end, 0.07f);
    //}
    //public void Update()
    //{
    //    UtilityFunctions.lineConnect(s, end, 0.07f);
    //}

    public static void lineConnect(GameObject start, GameObject end, float size)
    {
        if (start.GetComponent<CableScript>() == null)
            start.AddComponent<CableScript>();


        LineRenderer wire = start.GetComponent<LineRenderer>();
        wire.startWidth = size;
        wire.endWidth = size;

        Material yourMaterial = (Material)Resources.Load("Black", typeof(Material));
        if (yourMaterial == null)
            print("can't find line renderer material");
        wire.material = yourMaterial;

        start.GetComponent<CableScript>().setEndPoint(end);
    }

    public static void lineConnect(GameObject start, GameObject end, float size, int numPoint)
    {
        lineConnect(start, end, size);
        start.GetComponent<CableScript>().setPointInLine(numPoint);
    }

    public static void lineConnect(GameObject start, GameObject end, float size, int numPoint, float sagNum)
    {
        lineConnect(start, end, size);
        start.GetComponent<CableScript>().setPointInLine(numPoint);
        start.GetComponent<CableScript>().setSagAmplitude(sagNum);
    }

    public static Transform findInChild(Transform parent, string name)
    {
        if (parent.childCount == 0)
        {
            return ((parent.name.Equals(name)) ? parent : null);
        }

        Transform ret;
        foreach (Transform t in parent)
        {
            ret = UtilityFunctions.findInChild(t, name);
            if (ret != null)
                return ret;
        }

        return null;
    }


    public static GameObject extendPoint(GameObject point, string newPointName, string moveDirection, float distance)
    {
        float d = Mathf.Abs(distance);

        //copy old point
        GameObject ret = new GameObject();
        ret.transform.position = point.transform.position;
        ret.transform.parent = point.transform.parent;

        if (Mathf.Sign(distance) == 1)
        {
            //move point to left
            if (moveDirection == "x")
                point.transform.position += new Vector3(d, 0.0f, 0.0f);
            else if (moveDirection == "z")
                point.transform.position += new Vector3(0.0f, 0.0f, d);
        }
        else
        {
            //move point to right
            if (moveDirection == "x")
                point.transform.position += new Vector3(-d, 0.0f, 0.0f);
            else if (moveDirection == "z")
                point.transform.position += new Vector3(0.0f, 0.0f, -d);
        }


        //change name
        ret.name = newPointName;

        return ret;
    }
}