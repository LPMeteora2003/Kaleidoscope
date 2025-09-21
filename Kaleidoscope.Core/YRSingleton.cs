using Kaleidoscope.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core
{
    public class YRSingleton<T> : IYRSingleton<T> where T : YRSingleton<T>
    {
        private static readonly Lazy<T> _instance = new(Create);

        public static T Instance => _instance.Value;

        protected YRSingleton() { }

        private static T Create()
        {
            var type = typeof(T);
            var created = Activator.CreateInstance(type, nonPublic: true);
            if (created is not T instance)
                throw new InvalidOperationException($"{type.FullName} must have a non-public parameterless constructor.");
            return instance;
        }
    }
}
