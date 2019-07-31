using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Desktop.Model;
using InvvardDev.EZLayoutDisplay.Desktop.Service.Interface;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Desktop.Service.Design
{
    public class LayoutService : ILayoutService
    {
        public async Task<ErgodoxLayout> GetLayoutInfo(string layoutHashId)
        {
            Debug.WriteLine("Layout retrieved.");

            var layoutInfo = new ErgodoxLayout();
            layoutInfo.Title = "Layout title v1.0";

            return await new Task<ErgodoxLayout>(() => layoutInfo);
        }

        /// <inheritdoc />
        public async Task<ErgodoxLayout> GetErgodoxLayout(string layoutHashId)
        {
            Debug.WriteLine("Layout retrieved.");

            return await new Task<ErgodoxLayout>(() => new ErgodoxLayout());
        }

        /// <inheritdoc />
        public EZLayout PrepareEZLayout(ErgodoxLayout ergodoxLayout, string layoutRevisionIds)
        {
            Debug.WriteLine("Layout prepared");

            return new EZLayout();
        }
    }
}