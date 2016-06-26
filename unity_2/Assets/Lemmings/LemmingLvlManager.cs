using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LemmingLvlManager {
	private static string PATH = Application.dataPath + "/Lemmings/config.xml";
	private XmlDocument xmlDoc = new XmlDocument ();

	public LemmingLvlManager () {
		xmlDoc.Load(PATH);
		this.DisplayLevelName ();
	}

	private XmlNode getXmlNode () {
		return xmlDoc.SelectNodes ("/levels/level[@name='" + Application.loadedLevelName + "']") [0];
	}

	private void DisplayLevelName() {
		var lvlName = this.getXmlNode().Attributes["fullName"].InnerText;
		GameObject.Find("LvlName").GetComponent<UnityEngine.UI.Text>().text = lvlName;
	}
}
