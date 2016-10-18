using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class MasterTableBase<T> where T: MasterBase,new(){

	//
	protected List<T> masters;
	//
	public List<T> All
	{
		get{ 
			return masters;
		}
	}
	public void Load(string filePath)
	{
		//
		var text = ((TextAsset)Resources.Load (filePath, typeof(TextAsset))).text;
		//
		text =text.Trim().Replace("/r","")+"\n";

		var lines=text.Split('\n').ToList();

		//header
		var headElements=lines[0].Split(',');
		lines.RemoveAt(0);
		///header

		//body
		masters=new List<T>();
		//
		foreach(var line in lines) 
		{
			ParseLine(line,headElements);
		}
	}

	//
	private void ParseLine(string line,string[] headElements)
	{
		var elements = line.Split (',');
		if (elements.Length == 1) {
			return;
		}

		if (elements.Length != headElements.Length) {
			Debug.LogWarning (string.Format ("can't Load:{0}" , line));
			return;
		}

		var Param = new Dictionary<string,string> ();
		for (int i = 0; i < elements.Length; i++) {
			Param.Add (headElements [i], elements[i]);
		}

		var master = new T();
		master.Load (Param);
		masters.Add (master);
	}
}



public class MasterBase
{
	public void Load(Dictionary<string,string> param)
	{
		foreach (string key in param.Keys) {
			SetField (key, param [key]);	
		}
	}

	private void SetField(string key ,string value)
	{
		PropertyInfo propertyinfo = this.GetType ().GetProperty (key, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);


		//読み込むであろう型の種類
		if (propertyinfo.PropertyType == typeof(int)) {
			propertyinfo.SetValue (this, int.Parse (value), null);
		} else if (propertyinfo.PropertyType == typeof(string)) {
			propertyinfo.SetValue (this, value, null);
		} else if (propertyinfo.PropertyType == typeof(double)) {
			propertyinfo.SetValue (this, double.Parse (value), null);
		}
	}


}

