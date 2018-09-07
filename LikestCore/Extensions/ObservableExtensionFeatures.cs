using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.LikestCore
{
    public static class ObservableExtensionFeatures
    {
        public static IObservable<T1> TimerFunc<T1>(TimeSpan period, Func<T1> func)
        {
            return Observable.Create<T1>(o =>
            {
                var subscription = Observable.Interval(period).Subscribe(
                    (t) =>
                    {
                        try
                        {
                            var result = func();
                            o.OnNext(result);
                        }
                        catch (Exception ex)
                        {
                            o.OnError(ex);
                        }
                    },
                    (ex) => o.OnError(ex),
                    () => o.OnCompleted());

                return Disposable.Create(() => subscription.Dispose());
            });
        }
    }
}
