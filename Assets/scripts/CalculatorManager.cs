using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorManager : MonoBehaviour
{
   [SerializeField] private ElementContainerController _elementContainer;
   public static AlgebraOperator.operations islem; //Player controllun icinde degistirioz bunu

    

   private void Awake()
   {
      PlayerController.onPlayerHit.AddListener(DestroyNearestItems);
        
   }

   private void DestroyNearestItems(Vector3 vec)
   {
      var transforms = _elementContainer.GetNearestTwoTransforms(vec);
      int index = _elementContainer.getIndextoReturn();
      
      int score = Calculate(transforms,islem);
        if (score < 10)
        {
            _elementContainer.AddAlgebraOnGame(score, index);

            foreach (var item in transforms)
            {
                //if (item.GetChild(0).GetComponent<AlgebraModel>()) test
                //{
                //    Debug.Log("null degil: "+ item.GetChild(0).GetComponent<AlgebraModel>().getValue());
                //}
                //Debug.Log(item.GetChild(0).GetComponent<AlgebraModel>().Value);
                Destroy(item.GetChild(0).gameObject);

            }
        }

        _elementContainer.Itemregulator();



       

        

    }
    
    private int Calculate(List<Transform> transform,AlgebraOperator.operations islem)
    {
        int CalculatedValue = 0;
        int firstValue = transform[0].GetChild(0).GetComponent<AlgebraModel>().getValue();
        int secondValue = transform[1].GetChild(0).GetComponent<AlgebraModel>().getValue();

        
        
        if (islem == AlgebraOperator.operations.ADD)
        {
            CalculatedValue = AlgebraOperator.add(firstValue, secondValue);
        }
        if (islem == AlgebraOperator.operations.DIVIDE)
        {
            CalculatedValue = AlgebraOperator.divide(firstValue, secondValue);
        }
        if (islem == AlgebraOperator.operations.MULTIPLY)
        {
            CalculatedValue = AlgebraOperator.multiply(firstValue, secondValue);
        }
        if (islem == AlgebraOperator.operations.SUBTRACT)
        {
            CalculatedValue = AlgebraOperator.subtract(firstValue, secondValue);
        }

        Debug.Log(firstValue + " " + islem + "\t: " + secondValue + " :" + CalculatedValue);

        return CalculatedValue;

        //if (CalculatedValue == 40) // kendi metodunu yapmamiz gerekecek
        //{
        //    AlgebraModel algebra = new AlgebraModel(CalculatedValue, test);
        //    model=Instantiate(algebra._holdable,_elementContainer.items[_elementContainer.getIndextoReturn()].transform.position,Quaternion.identity);
            
        //    model.GetComponent<AlgebraModel>().setValue(CalculatedValue);
        //}

        Debug.Log("Elementcontainerda su kadar eleman var: " +_elementContainer.items.Count);
        
    } 
}
