using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    
    public void textHandler(TextMesh text, Queue<GameObject> operators)
    {
        string islem = "";
        text.text = "";

        foreach (GameObject g in operators)
        {

            switch (g.GetComponent<AlgebraOperator>()._Operator)
            {
                case AlgebraOperator.operations.ADD: islem = "+"; break;
                case AlgebraOperator.operations.DIVIDE: islem = "/"; break;
                case AlgebraOperator.operations.MULTIPLY: islem = "x"; break;
                case AlgebraOperator.operations.SUBTRACT: islem = "-"; break;
            }

            text.text += islem + System.Environment.NewLine;
            
        }
    }
}
