using System;
using UnityEngine;

public interface State
{
	void OnEnter(GameObject entity);
	void Execute(GameObject entity);
	void OnExit(GameObject entity);
}

