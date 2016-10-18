using UnityEngine;
using System.Collections;

public class testCSV : MasterTableBase<testcsv>
{
	private static readonly string filepath="test";
	public void Load()
	{
		Load(filepath);
	}
}

public class testcsv : MasterBase
{
	public string ID { get; private set; }
	public string Name { get; private set; }
	public int Hp { get; private set; }
	public int Power { get; private set; }
}
