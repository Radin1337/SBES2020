﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Formatter
    {
		public static string ParseName(string winLogonName)
		{
			string[] parts = new string[] { };

			if (winLogonName.Contains("@")) //username@domain_name
			{
				///UPN format
				parts = winLogonName.Split('@');
				return parts[0];
			}
			else if (winLogonName.Contains("\\"))// domain_name\username
			{
				/// SPN format
				parts = winLogonName.Split('\\');
				return parts[1];
			}
			else
			{
				return winLogonName;
			}
		}
	}
}
