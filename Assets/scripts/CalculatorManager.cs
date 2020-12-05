using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorManager : MonoBehaviour
{
   [SerializeField] private ElementContainerController _elementContainer;

   private void Awake()
   {
      PlayerController.onPlayerHit.AddListener(DestroyNearestItems);
   }

   private void DestroyNearestItems(Vector3 vec)
   {
      var transforms = _elementContainer.GetNearestTwoTransforms(vec);

      foreach (var item in transforms)
      {
         Destroy(item.GetChild(0).gameObject);
      }
   }
}
