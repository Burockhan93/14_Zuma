using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorManager : MonoBehaviour
{
   [SerializeField] private ElementContainerController _elementContainer;
   [SerializeField] private AlgebraAdder _algebraAdder;
    private AlgebraDestroyer _algebraDestroyer;

    public static AlgebraOperator.operations islem; //Player controllun icinde degistirioz bunu

    
    private void Start()
    {
        _algebraDestroyer = GetComponent<AlgebraDestroyer>();
    }

    private void Awake()
   {
      PlayerController.onPlayerHit.AddListener(DestroyNearestItems);
        
   }

   private void DestroyNearestItems(Vector3 vec) 
   {
      var transforms = _elementContainer.GetNearestTwoTransforms(vec);
        if (transforms.Count == 2)//test
        {
            int index = 0;

            Debug.Log(transforms[0].GetChild(0).gameObject.GetComponent<AlgebraModel>().getValue() +
                " " + islem + "  " + transforms[1].GetChild(0).gameObject.GetComponent<AlgebraModel>().getValue());
                


            int score = Calculate(transforms, islem);
            if (score < 100 )
            {
                index =_algebraDestroyer.DestroyNearestItems(transforms);
                _algebraAdder.AddAlgebraOnGame(score, index);

            }
            if (score == 0)
            {
                _algebraDestroyer.OneElementDestroyer(index);               
                
            }

        }
    }
      
    
    private int Calculate(List<Transform> transform,AlgebraOperator.operations islem)
    {
        int CalculatedValue = 0;
        int firstValue = transform[0].GetChild(0).GetComponent<AlgebraModel>().getValue();
        int secondValue = transform[1].GetChild(0).GetComponent<AlgebraModel>().getValue();

        Debug.Log(firstValue + " islem  " + secondValue);
       
        if (islem == AlgebraOperator.operations.ADD)
        {
            CalculatedValue = add(firstValue, secondValue);
        }
        if (islem == AlgebraOperator.operations.DIVIDE)
        {
            CalculatedValue =divide(firstValue, secondValue);
        }
        if (islem == AlgebraOperator.operations.MULTIPLY)
        {
            CalculatedValue = multiply(firstValue, secondValue);
        }
        if (islem == AlgebraOperator.operations.SUBTRACT)
        {
            CalculatedValue = subtract(firstValue, secondValue);
        }

        //Debug.Log(firstValue + " " + islem + "\t: " + secondValue + " :" + CalculatedValue);

        return CalculatedValue;
    }


    private int add(int a, int b)
    {
        return a + b;
    }

    private int subtract(int a, int b)
    {
        return a - b >= 0 ? (a - b) : (b - a);

    }

    private int divide(int a, int b)
    {
        if (a == 0 || b == 0)
        {
            return 0;
        }

        return a >= b ? (a / b) : (b / a);


    }

    private int multiply(int a, int b)
    {
        return a * b;
    }

    private int sqrt(int a)
    {
        return (int)Mathf.Sqrt(a);
    }

    
}
