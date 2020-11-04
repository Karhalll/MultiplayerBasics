using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
	public override void OnClientConnect(NetworkConnection conn)
	{
		base.OnClientConnect(conn);

		Debug.Log("I connected to a server!");
	}

	public override void OnServerAddPlayer(NetworkConnection conn)
	{
		base.OnServerAddPlayer(conn);

		Debug.Log("New Player conected to a server. (" + numPlayers + " players)");
	}
}
