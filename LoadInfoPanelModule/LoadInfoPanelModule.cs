using LoadInfoPanelModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadInfoPanelModule
{
    public class LoadInfoPanelModuleModule : IModule
    {
        public LoadInfoPanelModuleModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("loadInfoPanelRegion", typeof(LoadInfoPanelView));
        }

        IRegionManager regionManager;
    }
}
