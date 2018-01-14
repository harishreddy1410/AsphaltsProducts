using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsphaltsProducts.Presentation.Layer.Helpers.Session
{
    public interface ISessionFactory
    {
        T Get<T>(SessionKey sessionKey,Func<T> func);
        T Get<T>(SessionKey sessionKey);
        T Set<T>(SessionKey sessionKey,T value);
        void Clear();
        void RemoveSesssion(SessionKey session);
    }

    public enum SessionKey
    {
        SESSION_ID,
        SESSION_OBJ
    }
}
