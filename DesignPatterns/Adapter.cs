using Newtonsoft.Json.Linq;
using System;

namespace ResxTest
{
    public struct SubscriptionAdaptor
    {
        public object Adapt<TTarget>(object requestSource)
        {
            return Get<TTarget>(requestSource);
        }

        private object Get<TTarget>(object source)
        {
            if (source is JToken && typeof(TTarget) == typeof(Subscriber1))
            {
                return ConvertToSubscriber1Model(source as JToken);
            }
            else if (source is JToken && typeof(TTarget) == typeof(Subscriber2))
            {
                return ConvertToSubscriber2Model(source as JToken);
            }
            else
            {
                return null;
            }
        }

        static Func<JToken, Subscriber1> ConvertToSubscriber1Model
             => results
             =>
             {

                 return new Subscriber1()
                 {

                 };
             };

        static Func<JToken, Subscriber2> ConvertToSubscriber2Model
            => results
            =>
            {

                return new Subscriber2()
                {

                };
            };
    }

    internal class Subscriber1
    {
    }

    internal class Subscriber2
    {
    }
}
