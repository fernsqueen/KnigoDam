using System;
using System.Collections.Generic;
using System.Text;

namespace Knigodam.Services
{
    public static class Service<T>
    {
        private static T _instance;

        public static void RegisterService(T instance)
        {
            _instance = instance;
        }

        public static T GetInstance()
        {
            return _instance;
        }
    }
}
