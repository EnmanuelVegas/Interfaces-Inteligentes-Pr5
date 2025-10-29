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
public class ObjectControllerFood : MonoBehaviour
{
  /// <summary>
  /// The material to use when this object is inactive (not being gazed at).
  /// </summary>
  public GameObject targetObj;
  public float speed = 5f;
  public float destroyDistance = 0.5f;  

  private Transform tr;
  private Transform targetTr;
  private bool pursueTarget;
  public string smokeResourcePath = "materials/smoke"; // ruta en Resources (sin "Resources/")

  /// <summary>
  /// Start is called before the first frame update.
  /// </summary>
  public void Start()
  {
    tr = transform;
    if (targetObj != null) {
      targetTr = targetObj.GetComponent<Transform>();
    }
    pursueTarget = false;
  }

  public void OnPointerEnter()
  {
    pursueTarget = true;
    Debug.Log("hola");

  }

  public void OnPointerExit()
  {
  }

  public void Update()
  {
    if (pursueTarget && targetTr != null)
    {
      Vector3 direction = (targetTr.position - tr.position);
      float dist = direction.magnitude;
      if (dist <= destroyDistance)
      {
        SpawnSmoke();
        Destroy(gameObject);
        return;
      }
      tr.position += direction.normalized * speed * Time.deltaTime;
    }
  }

  private void SpawnSmoke()
  {
    GameObject smokePrefab = Resources.Load<GameObject>(smokeResourcePath);
    if (smokePrefab != null)
    {
      Instantiate(smokePrefab, tr.position, Quaternion.identity);
    }
    else
    {
      Debug.LogWarning($"Smoke prefab not found at Resources/{smokeResourcePath}");
    }
  }
}
