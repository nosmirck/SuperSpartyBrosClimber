using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

	public enum CollectType
	{
		COIN = 1,
		DIAMOND,
		HEART
	}
	public int coinValue = 1;
	public bool taken = false;
	public GameObject explosion;
	public CollectType Type = CollectType.COIN;

	// if the player touches the coin, it has not already been taken, and the player can move (not dead or victory)
	// then take the coin
	void OnTriggerEnter2D(Collider2D other)
	{
		if ((other.tag == "Player") && (!taken) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
		{
			// mark as taken so doesn't get taken multiple times
			taken = true;

			// if explosion prefab is provide, then instantiate it
			if (explosion)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}

			// do the player collect coin thing

			switch (Type)
			{
				case CollectType.COIN:
					other.gameObject.GetComponent<CharacterController2D>().CollectCoin(coinValue);
					break;
				case CollectType.DIAMOND:
					other.gameObject.GetComponent<CharacterController2D>().CollectDiamond(coinValue);
					break;
				case CollectType.HEART:
					other.gameObject.GetComponent<CharacterController2D>().CollectHeart(coinValue);
					break;
			}

			// destroy the coin
			DestroyObject(this.gameObject);
		}
	}

}
