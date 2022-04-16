﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
  void Start()
  {
    Cursor.visible = false; 
  }

  void Update()
  {
    Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = cursorPos;

    if (PlayerHealth.dead) { Destroy(gameObject); }
  }
}
