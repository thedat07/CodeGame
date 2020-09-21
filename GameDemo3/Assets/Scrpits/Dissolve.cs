using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
	Material material;
    public Player2 player;
    bool isDissolving = false;
	public float fade = 1f;
    public float start = 0f;
    public bool startPlayer;

    void Start()
	{
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        material = GetComponent<SpriteRenderer>().material;
	}

	void Update()
    {
        if (player.ourHealth > 0)
        {
            isDissolving = false;
        }

        if (player.ourHealth<=0)
		{
			isDissolving = true;
		}

		if (isDissolving)
		{
			fade -= Time.deltaTime*2;
			if (fade <= 0f)
			{
				fade = 0f;
                start = 0f;
                isDissolving = false;
			}
			material.SetFloat("_Fade", fade);
		}
        if (!isDissolving)
        {
            start += Time.deltaTime*2;
            if (start >= 1f)
            {
                start = 1f;
                isDissolving = false;
                startPlayer = true;
            }
            material.SetFloat("_Fade", start);
        }
    }
}
