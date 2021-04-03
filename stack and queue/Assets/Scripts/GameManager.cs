using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private Queue<string> colors = new Queue<string>();

    public Text display;

    private float timer = 0;
    private float timePerTurn = 5;

    private float offsetX = -8;

    public Rigidbody2D redBall;
    public Rigidbody2D greenBall;
    public Rigidbody2D blueBall;

    // Update is called once per frame
    void Update()
    {
        // if time is up, don't do anything below
        if (timer > timePerTurn) return;

        timer += Time.deltaTime;

        // push the data into the stack
        if (Input.GetKeyDown(KeyCode.R))
        {
            colors.Enqueue("r");
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            colors.Enqueue("g");
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            colors.Enqueue("b");
        }

        if (timer >= timePerTurn)
        {
            display.text = "Time is up!";
            
            Debug.Log(colors);
            
            ShowStackColors();
        }
        else
        {
            display.text = "Press r, g, or b\n" 
                           + (timePerTurn - timer).ToString("F2");
        }
    }

    private void ShowStackColors()
    {
        int i = 0;
        
        while (colors.Count > 0)
        {
            string currentColor = colors.Dequeue();

            if (currentColor == "r")
            {
                Instantiate(redBall, new Vector3(i * 2.0F + offsetX, 0, 0), Quaternion.identity);
            }
            
            if (currentColor == "g")
            {
                Instantiate(greenBall, new Vector3(i * 2.0F + offsetX, 0, 0), Quaternion.identity);
            }
            
            if (currentColor == "b")
            {
                Instantiate(blueBall, new Vector3(i * 2.0F + offsetX, 0, 0), Quaternion.identity);
            }

            i++;

        }
        
        /*for (int i = 0; i < colors.Count; i++)
        {
            string currentColor = colors.Pop();
            Debug.Log(currentColor);
            
            if (currentColor == "r")
            {
                Instantiate(redBall, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
            }
            
            if (currentColor == "g")
            {
                Instantiate(greenBall, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
            }
            
            if (currentColor == "b")
            {
                Instantiate(blueBall, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
            }
        }*/
    }
}
