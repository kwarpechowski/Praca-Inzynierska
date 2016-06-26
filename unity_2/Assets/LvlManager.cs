using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LvlManager {
	private static string PATH = Application.dataPath + "/config.xml";
	private XmlDocument xmlDoc = new XmlDocument ();

	public LvlManager () {
		xmlDoc.Load(PATH);
	}

	private XmlNode getXmlNode () {
		return xmlDoc.SelectNodes ("/levels/level[@name='" + Application.loadedLevelName + "']") [0];
	}

	public string getLevelName() {
		return "test";
	//	return this.getXmlNode().Attributes["fullName"].InnerText;
	}

	public void nextLevel() {
		try {
			var lvlName = this.getXmlNode().Attributes["nextLevel"].InnerText;
			Application.LoadLevel(lvlName);
		}catch(System.Exception) {
			Application.LoadLevel("end");
		}
	}
	
	public List<OpponentModel> getOpponents() {
		List<OpponentModel> list = new List<OpponentModel> ();


		XmlNodeList xnList = this.getXmlNode().SelectNodes("opponents/opponent");
		foreach (XmlNode opponent in xnList)
		{
			OpponentModel model = new OpponentModel();
			model.Health = System.Int32.Parse(opponent["health"].InnerText);

			int x = System.Int32.Parse(opponent["x"].InnerText);
			int y = System.Int32.Parse(opponent["y"].InnerText);
			int z = System.Int32.Parse(opponent["z"].InnerText);

			model.Pos = new Vector3(x, y, z);

			XmlNodeList steps = opponent["path"].ChildNodes;

			foreach(XmlNode step in steps) {
				int x2 = System.Int32.Parse(step.Attributes["x"].InnerText);
				int y2 = System.Int32.Parse(step.Attributes["y"].InnerText);
				int z2 = System.Int32.Parse(step.Attributes["z"].InnerText);

				model.MovePath.Add (new Vector3(x2, y2, z2));
			}


			list.Add(model);
		}
		
		
		return list;
	}
}
