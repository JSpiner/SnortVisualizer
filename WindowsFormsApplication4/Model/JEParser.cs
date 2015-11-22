using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Net.Json;
using System.Collections.Generic;

namespace WindowsFormsApplication4
{
	public class JEParser
	{
		public Type c;

		public static JEParser getInstance(Type c){
			JEParser parser = new JEParser ();
			parser.setType (c);

			return parser;
		}

		private void setType(Type c){
			this.c = c;
		}

		public Object parse(String json){

			BindingFlags bindingFlags = BindingFlags.Public |
				BindingFlags.Instance;

			var instance = Activator.CreateInstance (c);

			JsonTextParser parser = new JsonTextParser ();
			JsonObjectCollection jObject = (JsonObjectCollection)parser.Parse (json);

			foreach (FieldInfo field in c.GetFields(bindingFlags))
			{

				String fieldName = removeTag (field.ToString ());

				object value = null;

				var oValue = jObject [field.Name].GetValue ();
				switch (fieldName) {
				case "System.String":
					value = Convert.ToString (oValue);
					break;
				case "System.Double":
					value = Convert.ToDouble (oValue);
					break;
				case "System.Int32":
					value = Convert.ToInt32 (oValue);
					break;
				case "System.Int64":
					value = Convert.ToInt64 (oValue);
					break;
				case "System.Boolean":
					value = Convert.ToInt64 (oValue);
					break;
				case "System.Collections.Generic.List":
					value = oValue;
					break;
				default:
					//value = parse (varToList(oValue)[0].ToString());
					break;
				}

				field.SetValue (instance, value);

				Console.WriteLine(field.Name+","+field.ToString()+","+jObject [field.Name].GetValue());
			}


			return instance;


		}

		private string removeTag(String fieldName){

			Match str = Regex.Match (fieldName, "([a-zA-Z_$][a-zA-Z\\d_$]*\\.)*[a-zA-Z_$][a-zA-Z\\d_$]*");

			return str.Value;
		}

		/*
		private List<Object> varToList(Object obj){
			return obj.;
		}*/
	}

}

