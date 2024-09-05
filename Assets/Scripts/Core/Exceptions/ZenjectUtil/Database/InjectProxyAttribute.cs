using System;
using Zenject;

namespace Core.Exceptions.ZenjectUtil.Database
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
    public class InjectProxyAttribute : InjectAttributeBase
    {
        public const string PROXY_ID = "Proxy";

        public InjectProxyAttribute() => Id = PROXY_ID;
    }
}