using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
	public override void OnServerAddPlayer(NetworkConnection conn)
	{
		base.OnServerAddPlayer(conn);

		MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();

		player.SetDisplayName($"Player {numPlayers}");
		player.SetDisplayColor(RandomColor());
	}

	private Color RandomColor()
	{
		return new Color(
			Random.Range(0f, 1f),
			Random.Range(0f, 1f),
			Random.Range(0f, 1f)
		);
	}
}
