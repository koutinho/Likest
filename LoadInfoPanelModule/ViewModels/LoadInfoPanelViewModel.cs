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

            curSeq.Subscribe(x => CurrentLoad = x);
            maxSeq.Subscribe(x => MaxLoad = x);
        }

        private ILikestApi likestApi;

        [Reactive]
        public double CurrentLoad { get; set; }

        [Reactive]
        public double MaxLoad { get; set; }
    }
}
