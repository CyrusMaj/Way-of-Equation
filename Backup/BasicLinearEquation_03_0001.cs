using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BasicLinearEquation_03_0001 : MonoBehaviour
{

    //private float constant_Y;    //Maybe later.
    private float intercept_b;
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

    [SerializeField] GameObject WinText;

    bool slope_Enemy_Killed = false;
    bool Mx_Enemy_Killed = false;
    bool constantX_Enemy_Killed = false;
    //bool constantY_Enemy_Killed = false;
    bool divisionHappened = false;

    //Stance UI variables
    public GameObject DivButton_Selection;
    public GameObject SubButton_Selection;
    public GameObject AddButton_Selection;
    int stance = 1;

    public GameObject EnemyModel;
    public GameObject Enemy;
    private Animator Enem;
    public GameObject EnemySword;
    private NavMeshAgent Agent;

    int AnimVal;

    void Start()
    {
        pickEquation();
        variableEnemyUI();

        Enem = EnemyModel.GetComponent<Animator>();
        Agent = Enemy.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        winState();

        SelectStance();

        EnemyMovement();
    }

    public void variableEnemyUI()
    {
        slope_Enemy.text = intercept_b.ToString();
        Mx_Enemy.text = constant_M.ToString() + "x";
        constantX_Enemy.text = constant_M.ToString();
    }

    void Punishment()
    {
        Enem.SetBool("Punishment", true);
        enemySwordActivate();
    }

    //void EnemyAnimation()
    //{
    //    if (AnimVal == 1)
    //    {
    //        //Idle
    //    }
    //    else if (AnimVal == 2)
    //    {
    //        //Pursuit
    //    }
    //    else if (AnimVal == 3)
    //    {
    //        //Attack
    //    }
    //    else if (AnimVal == 4)
    //    {
    //        //Punishment
    //    }
    //}

    void EnemyMovement()    //Pursue player or idle?    //////
    {
        if (Vector3.Distance(EnemyModel.transform.position, Agent.destination) <= 2.4f)
        {
            Enem.SetBool("EnemyIdle", true);
            Enem.SetBool("EnemyPursuit", false);
        }
        else
        {
            Enem.SetBool("EnemyPursuit", true);
            Enem.SetBool("EnemyIdle", false);
        }
    }

    //Activating enemy sword
    void enemySwordActivate()
    {
        EnemySword.SetActive(true);
    }

    //Colliding with Enemy sword
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemySword")
        {
            damagePlayer();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.CompareTag("Slope_Enemy"))      //If attacking Slope Enemy.
        if (other.gameObject.name == "Slope_Enemy")
        {
            Debug.Log("Slope Enemy Collision");

            //if (Input.GetKeyDown(KeyCode.Minus))        //Change to Mouse 1 && stance == 2
            if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 2)
            {
                Debug.Log("Minus Key, Slope Enemy");

                if (equationChoice <= 1)
                {
                    Debug.Log("equationChoice 1");

                    equation.text += "\n" + "y = " + constant_M + "x" + " - " + intercept_b;    //Show slope on other side
                    currentEquation = "y = " + constant_M + "x" + " - " + intercept_b;

                    slope_Enemy_Killed = true;
                    Destroy(other.gameObject);

                }
                else
                {
                    Punishment();
                }
            }
            //else if (Input.GetKeyDown(KeyCode.Equals))        //Plus key.        //Change to Mouse 1 && stance == 3
            else if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 3)
            {
                Debug.Log("KeyCode.Plus, Slope Enemy");

                if (equationChoice == 3)
                {
                    Debug.Log("equationChoice == 3");

                    equation.text += "\n" + "y = " + constant_M + "x" + " + " + intercept_b;    //Show slope on other side
                    currentEquation = "y = " + constant_M + "x" + " + " + intercept_b;

                    slope_Enemy_Killed = true;
                    Destroy(other.gameObject);

                }
                else
                {
                    Punishment();
                }
            }
            //else
            //{
            //    damagePlayer();
            //}
        }

        //if (other.gameObject.CompareTag("Constant_Enemy"))      //If attacking Constant Enemy.
        if (other.gameObject.name == "Constant_Enemy")
        {
            Debug.Log("Constant_Enemy Collision");

            //if (Input.GetKeyDown(KeyCode.Slash))        //Change to Mouse 1 && stance == 1
            if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 1)
            {
                Debug.Log("KeyCode.Slash, Constant_Enemy");

                intercept_b = intercept_b / constant_M;
                constant_M = 1;
                //Divide Y_Constant also, whenever you add it.
                variableEnemyUI();
                divisionHappened = true;

                if (equationChoice <= 1)
                {
                    if (slope_Enemy_Killed == true)
                    {
                        equation.text += "\n" + "y = " + constant_M + "x" + " - " + intercept_b;    //Show slope on other side
                        currentEquation = "y = " + constant_M + "x" + " - " + intercept_b;
                    }
                    else
                    {
                        equation.text = "y + " + intercept_b + " = " + constant_M + "x";
                        currentEquation = "y + " + intercept_b + " = " + constant_M + "x";
                    }

                }

                else if (equationChoice == 2)
                {
                    if (Mx_Enemy_Killed == true)
                    {
                        equation.text += "\n" + "y = " + intercept_b + " - " + constant_M + "x";    //Show Mx on other side
                        currentEquation = "y = " + intercept_b + " - " + constant_M + "x";
                    }
                    else
                    {
                        equation.text = "y + " + constant_M + "x" + " = " + intercept_b;
                        currentEquation = "y + " + constant_M + "x" + " = " + intercept_b;
                    }
                }

                else if (equationChoice == 3)
                {
                    if (slope_Enemy_Killed == true)
                    {
                        equation.text += "\n" + "y = " + constant_M + "x" + " + " + intercept_b;    //Show slope on other side
                        currentEquation = "y = " + constant_M + "x" + " + " + intercept_b;
                    }
                    else
                    {
                        equation.text = "y - " + intercept_b + " = " + constant_M + "x";
                        currentEquation = "y - " + intercept_b + " = " + constant_M + "x";
                    }
                }

                else if (equationChoice > 3)
                {
                    if (Mx_Enemy_Killed == true)
                    {
                        equation.text += "\n" + "y = " + intercept_b + " + " + constant_M + "x";    //Show Mx on other side
                        currentEquation = "y = " + intercept_b + " + " + constant_M + "x";
                    }
                    else
                    {
                        equation.text = "y - " + constant_M + "x" + " = " + intercept_b;
                        currentEquation = "y - " + constant_M + "x" + " = " + intercept_b;
                    }
                }

                //equation.text += "\n" + currentEquation;    //Adds equation with changed variable values to text box without further modification.
            }
            //else
            //{
            // Punishment();
            //}
        }

        //Add Y_Constant condition, when time comes.

        //if (other.gameObject.CompareTag("Mx_Enemy"))        //If attacking Mx Enemy.
        if (other.gameObject.name == "Constant_X_Enemy")
        {
            Debug.Log("Mx_Enemy Collision");

            //if (Input.GetKeyDown(KeyCode.Minus))        //Change to Mouse 1 && stance == 2
            if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 2)
            {
                Debug.Log("KeyCode.Minus, Mx_Enemy");

                if (equationChoice == 2)
                {
                    Debug.Log("equationChoice == 2");

                    equation.text += "\n" + "y = " + intercept_b + " - " + constant_M + "x";    //Show Mx on other side
                    currentEquation = "y = " + intercept_b + " - " + constant_M + "x";

                    constantX_Enemy_Killed = true;
                    Destroy(other.gameObject);

                }
                else
                {
                    Punishment();
                }
            }
            //else if (Input.GetKeyDown(KeyCode.Equals))      //Plus key.        //Change to Mouse 1 && stance == 3
            else if (Input.GetKeyDown(KeyCode.Mouse0) && stance == 3)
            {
                Debug.Log("KeyCode.Plus, Mx_Enemy");

                if (equationChoice > 3)     //Equation choice 4
                {
                    Debug.Log("equationChoice > 3");

                    equation.text += "\n" + "y = " + intercept_b + " + " + constant_M + "x";    //Show Mx on other side
                    currentEquation = "y = " + intercept_b + " + " + constant_M + "x";

                    constantX_Enemy_Killed = true;
                    Destroy(other.gameObject);

                }
                else
                {
                    Punishment();
                }
            }
            //else
            //{
            //    damagePlayer();
            //}
        }

        //if (other.gameObject.CompareTag("Enemy"))
        if (other.gameObject.name == "Enemy")       //If attacking Enemy
        {
            Debug.Log("Enemy Collision");

            //if ((Input.GetKeyDown(KeyCode.Equals)) || (Input.GetKeyDown(KeyCode.Minus)) || (Input.GetKeyDown(KeyCode.Slash)))        //Change to Mouse 1 && stance == 1 || stance == 2 || stance == 3
            if (Input.GetKeyDown(KeyCode.Mouse0) && (stance == 1 || stance == 2 || stance == 3))
            {
                Debug.Log("damagePlayer, Enemy, KeyCode.Plus, Minus, or Slash");
                Punishment();
            }
        }

        //Trigger enemy to attack
        if (other.gameObject.name == "Enemy")
        {
            enemySwordActivate();
            Enem.SetBool("EnemyAttack", true);
        }

        //if (other.gameObject.tag == "Enemy")
        //{
        //    Destroy(other.gameObject);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Enemy")
        {
            if (Enem.GetCurrentAnimatorStateInfo(0).IsName("Attack_02"))    //Check if animation is at end of clip before terminating.
            {
                return;
            }
            else
            {
                EnemySword.SetActive(false);
                Enem.SetBool("EnemyAttack", false);
            }
        }
        else
            return;

        if (other.gameObject.name == "Enemy")
        {
            if (Enem.GetCurrentAnimatorStateInfo(0).IsName("Punishment"))    //Check if animation is at end of clip before terminating.
            {
                return;
            }
            else
            {
                EnemySword.SetActive(false);
                Enem.SetBool("Punishment", false);
            }
        }
        else
            return;
    }

    public void pickEquation()
    {
        equationVarValues();

        equationChoice = Random.Range(0, 5);
        Mathf.Round(equationChoice);

        if (equationChoice <= 1)
        {
            equation.text = "y + " + intercept_b + " = " + constant_M + "x";
            currentEquation = "y + " + intercept_b + " = " + constant_M + "x";
        }

        else if (equationChoice == 2)
        {
            equation.text = "y + " + constant_M + "x" + " = " + intercept_b;
            currentEquation = "y + " + constant_M + "x" + " = " + intercept_b;
        }

        else if (equationChoice == 3)
        {
            equation.text = "y - " + intercept_b + " = " + constant_M + "x";
            currentEquation = "y - " + intercept_b + " = " + constant_M + "x";
        }

        else if (equationChoice > 3)
        {
            equation.text = "y - " + constant_M + "x" + " = " + intercept_b;
            currentEquation = "y - " + constant_M + "x" + " = " + intercept_b;
        }
    }

    public void equationVarValues()
    {
        equationVarVals = Random.Range(1, 4);
        Mathf.Round(equationVarVals);

        if (equationVarVals == 1)
        {
            intercept_b = 12;
            constant_M = 4;
        }

        if (equationVarVals == 2)
        {
            intercept_b = 9;
            constant_M = 3;
        }

        if (equationVarVals == 3)
        {
            intercept_b = 4;
            constant_M = 2;
        }

        if (equationVarVals == 4)
        {
            intercept_b = 5;
            constant_M = 5;
        }
    }

    public void damagePlayer()
    {
        health -= 0.1f;
        healthbar.value = health;

        if (health <= 0)
        {
            //Kill player.
        }
    }

    public void winState()
    {
        if (((slope_Enemy_Killed == true) || (constantX_Enemy_Killed == true)) && (divisionHappened == true))
        {
            WinText.SetActive(true);
        }
    }

    void SelectStance()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            stance++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stance--;
        }

        if (stance > 3)
        {
            stance = 1;
        }
        if (stance < 1)
        {
            stance = 3;
        }

        if (stance == 1)
        {
            DivButton_Selection.SetActive(true);
        }
        else
            DivButton_Selection.SetActive(false);

        if (stance == 2)
        {
            SubButton_Selection.SetActive(true);
        }
        else
            SubButton_Selection.SetActive(false);

        if (stance == 3)
        {
            AddButton_Selection.SetActive(true);
        }
        else
            AddButton_Selection.SetActive(false);
    }
}
