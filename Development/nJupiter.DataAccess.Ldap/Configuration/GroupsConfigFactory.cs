#region Copyright & License
// 
// 	Copyright (c) 2005-2012 nJupiter
// 
// 	Permission is hereby granted, free of charge, to any person obtaining a copy
// 	of this software and associated documentation files (the "Software"), to deal
// 	in the Software without restriction, including without limitation the rights
// 	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// 	copies of the Software, and to permit persons to whom the Software is
// 	furnished to do so, subject to the following conditions:
// 
// 	The above copyright notice and this permission notice shall be included in
// 	all copies or substantial portions of the Software.
// 
// 	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// 	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// 	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// 	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// 	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// 	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// 	THE SOFTWARE.
// 
#endregion

using System;
using System.Collections.Generic;

using nJupiter.Configuration;
using nJupiter.DataAccess.Ldap.DistinguishedNames;

namespace nJupiter.DataAccess.Ldap.Configuration {
	internal class GroupsConfigFactory : IGroupConfigFactory {
		public IGroupsConfig Create(IConfig configSection) {
			if(configSection == null) {
				throw new ArgumentNullException("configSection");
			}
			var groups = new GroupsConfig();
			SetFilter(configSection, groups);
			SetBase(configSection, groups);
			SetRdnAttribute(configSection, groups);
			SetRdnInPath(configSection, groups);
			SetMembershipAttribute(configSection, groups);
			SetNameType(configSection, groups);
			SetPath(configSection, groups);
			SetAttributeDefinitionList(configSection, groups);
			return groups;
		}

		private static void SetFilter(IConfig configSection, GroupsConfig groups) {
			if(configSection.ContainsKey("groups", "filter")) {
				groups.Filter = configSection.GetValue("groups", "filter");
			}
		}

		private static void SetBase(IConfig configSection, GroupsConfig groups) {
			if(configSection.ContainsKey("groups", "base")) {
				groups.Base = configSection.GetValue("groups", "base");
			}
		}

		private static void SetRdnAttribute(IConfig configSection, GroupsConfig groups) {
			if(configSection.ContainsKey("groups", "rdnAttribute")) {
				groups.RdnAttribute = configSection.GetValue("groups", "rdnAttribute");
			}
		}

		private void SetRdnInPath(IConfig configSection, GroupsConfig groups) {
			if(configSection.ContainsKey("groups", "rdnInPath")) {
				groups.RdnInPath = configSection.GetValue<bool>("groups", "rdnInPath");
			}
		}

		private static void SetMembershipAttribute(IConfig configSection, GroupsConfig groups) {
			if(configSection.ContainsKey("groups", "membershipAttribute")) {
				groups.MembershipAttribute = configSection.GetValue("groups", "membershipAttribute");
			}
		}

		private static void SetNameType(IConfig configSection, GroupsConfig groups) {
			if(configSection.ContainsKey("groups", "nameType")) {
				var nameType = configSection.GetValue("groups", "nameType");
				groups.NameType = (NameType)Enum.Parse(typeof(NameType), nameType, true);
			}
		}

		private static void SetPath(IConfig configSection, GroupsConfig groups) {
			var groupUri = new Uri(configSection.GetValue("url"));
			if(!String.IsNullOrEmpty(groups.Base)) {
				groupUri = new Uri(groupUri, groups.Base);
			}
			groups.Path = groupUri.OriginalString;
		}

		private static void SetAttributeDefinitionList(IConfig configSection, GroupsConfig groups) {
			var containsCustomAttributes = configSection.ContainsKey("groups", "attributes");
			var attributes = new List<IAttributeDefinition>(groups.Attributes);
			if(containsCustomAttributes) {
				attributes.Clear();
			}
			attributes.Attach(groups.MembershipAttribute, true);
			if(containsCustomAttributes) {
				var attributeValues = configSection.GetValueArray("groups/attributes", "attribute");
				foreach(var attribute in attributeValues) {
					var excludeFromNameSearch = false;
					var attributeKey = String.Format("groups/attributes/attribute[@value='{0}']", attribute);
					if(configSection.ContainsAttribute(attributeKey, "excludeFromNameSearch")) {
						excludeFromNameSearch = configSection.GetAttribute<bool>(attributeKey, "excludeFromNameSearch");
					}
					attributes.Attach(attribute, excludeFromNameSearch);
				}
			}
			groups.Attributes = attributes;
		}
	}
}