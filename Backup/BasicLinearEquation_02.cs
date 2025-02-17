using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicLinearEquation_02 : MonoBehaviour
{
    //private float constant_Y;    //Maybe later.
    private float slope_b;
    private float constant_M;

    [SerializeField] Text equation;
    private string currentEquation;     //For adding equation with changed variable values to text box without further modification.

    private float equationChoice;
    private float equationVarVals;

    private float health = 1;
    [SerializeField] public Slider healthbar;

    [SerializeField] Text slope_Enemy;
    [SerializeField] Text Mx_Enemy;
    [SerializeField] Text constantX_Enemy;
    //[SerializeField] Text constantY_Enemy;

    bool slope_Enemy_Killed = false;
    bool Mx_Enemy_Killed = false;
    bool constantX_Enemy_Killed = false;
    //bool constantY_Enemy_Killed = false;

    void Start()
    {
        pickEquation();
        variableEnemyUI();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            damagePlayer();
        }
    }

    public void variableEnemyUI()
    {
        slope_Enemy.text = slope_b.ToString();
        Mx_Enemy.text = constant_M.ToString() + "x";
        constantX_Enemy.text = constant_M.ToString();
    }

    public void OnTriggerStay(Collider other)     
    {
        Debug.Log("Collision");

        if(other.gameObject.CompareTag("Slope_Enemy"))      //If attacking Slope Enemy.
        {
            Debug.Log("Slope Enemy Collision");

            if (Input.GetKeyDown(KeyCode.Minus))
            {
                Debug.Log("Minus Key, Slope Enemy");

                if (equationChoice <= 1)
                {
                    Debug.Log("equationChoice 1");

                    equation.text += "\n" + "y = " + constant_M + "x" + " - " + slope_b;    //Show slope on other side
                }
                else
                    damagePlayer();
            }
            else if(Input.GetKeyDown(KeyCode.Plus))
            {
                Debug.Log("KeyCode.Plus, Slope Enemy");

                if (equationChoice == 3)
                {
                    Debug.Log("equationChoice == 3");

                    equation.text += "\n" + "y = " + constant_M + "x" + " + " + slope_b;    //Show slope on other side
                }
                else
                {
                    damagePlayer();
                }
            }
            else
            {
                damagePlayer();
            }
        }

        if (other.gameObject.CompareTag("Constant_Enemy"))      //If attacking Constant Enemy.
        {
            Debug.Log("Constant_Enemy Collision");

            if (Input.GetKeyDown(KeyCode.Slash))
            {
                Debug.Log("KeyCode.Slash, Constant_Enemy");

                slope_b = slope_b / constant_M;
                //Divide Y_Constant also, whenever you add it.
                equation.text += "\n" + currentEquation;    //Adds equation with changed variable values to text box without further modification.
            }
            else
            {
                damagePlayer();
            }
        }

        //Add Y_Constant condition, when time comes.

        if (other.gameObject.CompareTag("Mx_Enemy"))        //If attacking Mx Enemy.
        {
            Debug.Log("Mx_Enemy Collision");

            if (Input.GetKeyDown(KeyCode.Minus))
            {
                Debug.Log("KeyCode.Minus, Mx_Enemy");

                if (equationChoice == 2)
                {
                    Debug.Log("equationChoice == 2");

                    equation.text += "\n" + "y = " + slope_b + " - " + constant_M + "x";    //Show Mx on other side
                }
                else
                    damagePlayer();
            }
            else if (Input.GetKeyDown(KeyCode.Plus))
            {
                Debug.Log("KeyCode.Plus, Mx_Enemy");

                if (equationChoice > 3)     //Equation choice 4
                {
                    Debug.Log("equationChoice > 3");

                    equation.text += "\n" + "y = " + slope_b + " + " + constant_M + "x";    //Show Mx on other side
                }
                else
                {
                    damagePlayer();
                }
            }
            else
            {
                damagePlayer();
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Collision");

            if ((Input.GetKeyDown(KeyCode.Plus)) || (Input.GetKeyDown(KeyCode.Minus)) || (Input.GetKeyDown(KeyCode.Slash)))      //Not working.
            {
                Debug.Log("damagePlayer, Enemy, KeyCode.Plus, Minus, or Slash");
                damagePlayer();
            }
        }
    }


    public void pickEquation()
    {
        equationVarValues();

        equationChoice = Random.Range(0, 5);
        Mathf.Round(equationChoice);

        if (equationChoice <= 1)
        {
            equation.text = "y + " + slope_b + " = " + constant_M + "x";
            currentEquation = "y + " + slope_b + " = " + constant_M + "x";
        }

        else if (equationChoice == 2)
        {
            equation.text = "y + " + constant_M + "x" + " = " + slope_b;
            currentEquation = "y + " + constant_M + "x" + " = " + slope_b;
        }

        else if (equationChoice == 3)
        {
            equation.text = "y - " + slope_b + " = " + constant_M + "x";
            currentEquation = "y - " + slope_b + " = " + constant_M + "x";
        }

        else if (equationChoice > 3)
        {
            equation.text = "y - " + constant_M + "x" + " = " + slope_b;
            currentEquation = "y - " + constant_M + "x" + " = " + slope_b;
        }
    }

    public void equationVarValues()
    {
        equationVarVals = Random.Range(1, 4);
        Mathf.Round(equationVarVals);

        if (equationVarVals == 1)
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

    public void damagePlayer()
    {
        health -= 0.1f;
        healthbar.value = health;

        if (health <=0)
        {
            //Kill player.
        }
    }
}
