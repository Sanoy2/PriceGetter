﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Cache
{
    public class CacheFacade : ICacheFacade
    {
        private static Dictionary<int, object> dictionary = new Dictionary<int, object>();

        public TItem Get<TItem>(object key)
        {
            int keyHashCode = this.ConvertObjectToKey(key);

            if(dictionary.TryGetValue(keyHashCode, out object @object))
            {
                return (TItem)@object;
            }

            return default;
        }

        public void Save<TItem>(TItem obj, object key)
        {
            int keyHashCode = this.ConvertObjectToKey(key);
            if (dictionary.ContainsKey(keyHashCode))
            {
                dictionary.Remove(keyHashCode);
            }

            dictionary.Add(keyHashCode, obj);
        }

        private int ConvertObjectToKey(object key)
        {
            try
            {
                int keyHashCode = key.GetHashCode();
                return keyHashCode;
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch (Exception) 
            {
                throw new ArgumentException();
            }
        }
    }
}
