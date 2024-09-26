using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Content_Car : MonoBehaviour
{
    [SerializeField]private Car car;
    public Car Get_Car() => car;
}
