using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{
	[SerializeField] private TMP_Text displayNameText = null;
	[SerializeField] private Renderer displayColorRendere = null;

    [SyncVar(hook = nameof(HandleDisplayNameUpdate))]
	[SerializeField]
	private string displayName = "Missing Name";

	[SyncVar(hook = nameof(HandleDisplayColorUpdate))]
	[SerializeField]
	private Color displayColor = Color.black;

	#region Server

	[Server]
	public void SetDisplayName(string newDisplayName)
	{
		displayName = newDisplayName;
	}

	[Server]
	public void SetDisplayColor(Color newDisplayColor)
	{
		displayColor = newDisplayColor;
	}

	[Command]
	private void CmdSetDisplayName(string newDisplayName)
	{
		if(newDisplayName.Length < 2 || newDisplayName.Length > 20) { return; }

		RpcLogNewName(newDisplayName);

		SetDisplayName(newDisplayName);
	}

	#endregion

	#region Client

	private void HandleDisplayNameUpdate(string oldName, string newName)
	{
		displayNameText.text = newName;
	}

	private void HandleDisplayColorUpdate(Color oldColor, Color newColor)
	{
		displayColorRendere.material.SetColor("_BaseColor", newColor);
	}

	[ContextMenu("Set My Name")]
	private void SetMyName()
	{
		CmdSetDisplayName("M");
	}

	[ClientRpc]
	private void RpcLogNewName(string newDisplayName)
	{
		Debug.Log(newDisplayName);
	}

	#endregion
}
