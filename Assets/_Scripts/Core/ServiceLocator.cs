using System;
using System.Collections.Generic;
using _Scripts.APICalls;

namespace _Scripts.Core
{
    public class ServiceLocator
    {
        private static ServiceLocator _locator = null;

        public static ServiceLocator Instance
        {
            get
            {
                if (_locator == null)
                {
                    _locator = new ServiceLocator();
                }
                return _locator;
            }
        }
        private ServiceLocator() { }
        
        private Dictionary<Type, object> registry = new Dictionary<Type, object>();
        
        public void Register<T>(T serviceInstance)
        {
            registry[typeof(T)] = serviceInstance;
        }
        public T GetService<T>()
        {
            T serviceInstance = (T)registry[typeof(T)];
            return serviceInstance;
        }
    }
}