using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    public float red;
    public float green;
    public float blue;

    public void SetRandomColor(float r, float g, float b)
    {
        red = r;
        green = g;
        blue = b;
        Color col = new Color(red, green, blue);
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", col);
    }

    public float getRed()
    {
        return gameObject.GetComponent<Renderer>().material.GetColor("_Color").r;
    }

    public float getGreen()
    {
        return gameObject.GetComponent<Renderer>().material.GetColor("_Color").g;
    }

    public float getBlue()
    {
        return gameObject.GetComponent<Renderer>().material.GetColor("_Color").b;
    }


}
