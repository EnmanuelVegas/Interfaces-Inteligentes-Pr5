//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectControllerSafe : MonoBehaviour
{
  /// <summary>
  /// The material to use when this object is inactive (not being gazed at).
  /// </summary>
  public GameObject containerObj;
  public float speed = 5f;
  public float destroyDistance = 0.5f;

  private Transform tr;
  private bool pursueTarget;
  private Transform[] children;

  /// <summary>
  /// Start is called before the first frame update.
  /// </summary>
  public void Start()
  {
    pursueTarget = false;
    tr = transform;

    int count = containerObj.GetComponent<Transform>().childCount;
    children = new Transform[count];
    for (int i = 0; i < count; i++)
    {
      children[i] = containerObj.GetComponent<Transform>().GetChild(i);
    }
  }

  public void OnPointerEnter()
  {
    pursueTarget = true;
  }

  public void OnPointerExit()
  {
  }

  public void Update()
  {
    if (pursueTarget && children != null)
    {
      for (int i = 0; i < children.Length; i++)
      {
        Transform child = children[i];
        if (child == null) continue;
        Vector3 direction = (tr.position - child.position);
        float dist = direction.magnitude;
        if (dist <= destroyDistance)
        {
          Destroy(child.gameObject);
          continue;
        }
        child.position += direction.normalized * speed * Time.deltaTime;
      }
    }
  }

}
