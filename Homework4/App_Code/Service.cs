using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

public class Service : IService
{
	public string verification(string xml, string xmls)
	{
		string verificationStr = "No Error";
		try
        {
			XmlReaderSettings hotelsSettings = new XmlReaderSettings();
			hotelsSettings.Schemas.Add(null, xmls);
			hotelsSettings.ValidationType = ValidationType.Schema;
			hotelsSettings.ValidationEventHandler += new ValidationEventHandler(hotelsSettingsValidation);

			XmlReader hotels = XmlReader.Create(xml, hotelsSettings);

			while (hotels.Read()) { }
		}
		catch(Exception error)
        {
			return error.Message;
        }
		return verificationStr;
	}

	void hotelsSettingsValidation(object sender, ValidationEventArgs e)
	{
		if (e.Severity == XmlSeverityType.Warning)
		{
			Console.Write("WARNING: ");
			Console.WriteLine(e.Message);
		}
		else if (e.Severity == XmlSeverityType.Error)
		{
			Console.Write("ERROR: ");
			Console.WriteLine(e.Message);
		}
	}

	public string xPathSearch(string xml, string pathExpression)
	{
		int idx = pathExpression.LastIndexOf('/');
		string select;
		string pathValue = "";
		if (idx != -1)
        {
			select = pathExpression.Substring(idx+1);
        }
        else
        {
			select = "Name";
        }
		try
        {
			XPathDocument dx = new XPathDocument(xml);
			XPathNavigator nav = dx.CreateNavigator();
			XPathNodeIterator iterator = nav.Select(pathExpression.Substring(0, idx));

			while (iterator.MoveNext())
			{
				XPathNodeIterator it = iterator.Current.Select(select);
				it.MoveNext();
				string data = it.Current.Value;
				pathValue = pathValue + data + ", ";
			}
			return pathValue.Substring(0, pathValue.Length - 2);
		}
		catch (Exception error)
        {
			return error.Message;
        }
	}
}
