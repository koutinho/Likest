using LikestCore.Abstract;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using ReactiveUI.Fody.Helpers;

namespace LoadInfoPanelModule.ViewModels
{
    public class LoadInfoPanelViewModel : ReactiveObject
    {
        public LoadInfoPanelViewModel(ILikestApi likestApi)
        {
            this.likestApi = likestApi;

            var loadSeq = likestApi.Load;
            var curSeq = loadSeq.Select(x => x.current).DistinctUntilChanged();
            var maxSeq = loadSeq.Select(x => x.slowdown).DistinctUntilChanged();

            currentLoad = curSeq.ToProperty(this, x => x.CurrentLoad);
            maxLoad = maxSeq.ToProperty(this, x => x.MaxLoad);
        }

        private ILikestApi likestApi;

        private readonly ObservableAsPropertyHelper<double> currentLoad;
        public double CurrentLoad => currentLoad.Value;

        private readonly ObservableAsPropertyHelper<double> maxLoad;
        public double MaxLoad => maxLoad.Value;
    }
}
