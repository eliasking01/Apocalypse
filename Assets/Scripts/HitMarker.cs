using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
    void Awake() {
        Shooting.hit = true;
    }
}
