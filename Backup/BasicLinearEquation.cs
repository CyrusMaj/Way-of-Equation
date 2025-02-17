using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicLinearEquation : MonoBehaviour
{
    //[SerializeField] float slope_b;
    //[SerializeField] float constant_M;
    //[SerializeField] float constant_Y;    //Maybe later.
    private float x;

    private float slope_b;
    private float constant_M;

    [SerializeField] Text equation;

    private float equationChoice;
    private float equationVarVals;

    // Start is called before the first frame update
    void Start()
    {
        //slope_b = Random.Range(1, 9);
        //constant_M = Random.Range(1, 9);

        pickEquation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    void pickEquation()
    {
        equationVarValues();

        equationChoice = Random.Range(0, 5);
        Mathf.Round(equationChoice);

        if (equationChoice <=1)
        {
            equation.text = "y + " + slope_b + " = " + constant_M + "x";

        }

        else if (equationChoice == 2)
        {
            equation.text = "y + " + constant_M + "x" + " = " + slope_b;
        }

        else if (equationChoice == 3)
        {
            equation.text = "y - " + slope_b + " = " + constant_M + "x";

        }

        else        //if (equationChoice >= 4)
        {
            equation.text = "y - " + constant_M + "x" + " = " + slope_b;
        }
    }

    void equationVarValues()
    {
        equationVarVals = Random.Range(1, 4);
        Mathf.Round(equationVarVals);

        if(equationVarVals == 1)
        {
            slope_b = 12;
            constant_M = 4;
        }

        if (equationVarVals == 2)
        {
            slope_b = 9;
            constant_M = 3;
        }

        if (equationVarVals == 3)
        {
            slope_b = 4;
            constant_M = 2;
        }

        if (equationVarVals == 4)
        {
            slope_b = 5;
            constant_M = 5;
        }
    }

    void equationUIUpdate()
    {

    }
}
