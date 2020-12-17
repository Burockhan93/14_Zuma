using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgebraOperator :MonoBehaviour
{
    
    [SerializeField] public List<GameObject> _operators;
    private GameObject islem;
    
    public enum operations
    {
        ADD,
        SUBTRACT,
        DIVIDE,
        MULTIPLY,
        Sqrt
    }
    public operations _Operator;

    public void generateOperator(int i)  //construct gibi dusunelim
    {
        
        
        switch (i)
        {
            case 0: _Operator = operations.ADD;
               
                break;

            case 1:
                _Operator = operations.SUBTRACT;
                
                break;

            case 2:
                _Operator = operations.MULTIPLY;
                
                break;

            case 3:
                _Operator = operations.DIVIDE;
               
                break;

            case 4:
                _Operator = operations.Sqrt;
                
                break;

            default: 
                break;

        }
       
    }

    public GameObject getIslem()
    {
        return islem;
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public static int add(int a, int b)
    {
        return a + b;
    }

    public static int subtract(int a, int b)
    {
        return a - b > 0 ? (a - b) : (b - a);
    }

    public static int divide(int a, int b)
    {

        return a % b > 0 ?  (a/b) : (b/a);
    }

    public static int multiply(int a, int b)
    {
        return a * b;
    }

    public static int sqrt(int a)
    {
        return (int)Mathf.Sqrt(a);
    }





}
