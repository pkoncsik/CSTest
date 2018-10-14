using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Dynamic;

namespace CSTest.Shared.Config
{
    public class ConfigStore: DynamicObject
    {
        private readonly Dictionary<string, object> _dictionary
            = new Dictionary<string, object>();

        public ConfigStore(string configurationName)
        {
            LoadConfigurationFromConfigFile(configurationName);
        }
        public int Count => _dictionary.Count;

        private void LoadConfigurationFromConfigFile(string configurationName)
        {
            if (!(ConfigurationManager.GetSection(configurationName) is NameValueCollection section)) return;
            foreach (var key  in section.AllKeys)
            {
                _dictionary[key] = section[key];
            }

        }
        // If you try to get a value of a property  
        // not defined in the class, this method is called. 
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {

            var name = binder.Name;

            // If the property name is found in a dictionary, 
            // set the result parameter to the property value and return true. 
            // Otherwise, return false. 
            return _dictionary.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is 
        // not defined in the class, this method is called. 
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {

            _dictionary[binder.Name] = value;

            // You can always add a value to a dictionary, 
            // so this method always returns true. 
            return true;
        }
    }


}