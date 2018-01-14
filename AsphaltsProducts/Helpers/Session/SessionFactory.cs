using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace AsphaltsProducts.Presentation.Layer.Helpers.Session
{
    public class SessionFactory : ISessionFactory
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public SessionFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public T Get<T>(SessionKey sessionKey, Func<T> func)
        {
            var value = _httpContextAccessor.HttpContext.Session.GetString(sessionKey.ToString());
            if (value == null)
            {
                value = Newtonsoft.Json.JsonConvert.SerializeObject(func());
                _httpContextAccessor.HttpContext.Session.SetString(sessionKey.ToString(), value);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(_httpContextAccessor.HttpContext.Session.GetString(sessionKey.ToString()).ToString());
        }
        public T Get<T>(SessionKey sessionKey)
        {
            var value = _httpContextAccessor.HttpContext.Session.GetString(sessionKey.ToString());
            if(value != null)
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(_httpContextAccessor.HttpContext.Session.GetString(sessionKey.ToString()));
            return default(T);
        }

        public void RemoveSesssion(SessionKey sessionKey)
        {
            _httpContextAccessor.HttpContext.Session.Remove(sessionKey.ToString());
        }

        public T Set<T>(SessionKey sessionKey, T value)
        {

            _httpContextAccessor.HttpContext.Session.SetString(sessionKey.ToString(), Newtonsoft.Json.JsonConvert.SerializeObject(value));
            return value;
        }


    }
}
