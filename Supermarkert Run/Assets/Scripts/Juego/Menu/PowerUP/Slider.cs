using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public void Slider_Value(float value)
    {
        int value_new = (int)value;
        transform.position = new Vector3(value_new, 0, 0);
    }
}
