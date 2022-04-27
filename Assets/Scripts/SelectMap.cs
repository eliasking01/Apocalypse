using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMap : MonoBehaviour
{

    public void Select() {
        MapChange.selectedMap = gameObject.name;
    }
}
