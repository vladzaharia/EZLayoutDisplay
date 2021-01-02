using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Core.Models;
using InvvardDev.EZLayoutDisplay.Core.Services.Interface;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Design
{
    public class LayoutService : ILayoutService
    {
        public async Task<ZsaLayout> GetLayoutInfo(string layoutHashId, string layoutRevisionId)
        {
            Debug.WriteLine("Layout retrieved.");

            var layoutInfo = new ZsaLayout {
                                               Title = "Layout title v1.0"
                                           };

            return await new Task<ZsaLayout>(() => layoutInfo);
        }

        /// <inheritdoc />
        public async Task<ZsaLayout> GetZsaLayout(string layoutHashId, string layoutRevisionId)
        {
            Debug.WriteLine("Layout retrieved.");

            return await new Task<ZsaLayout>(() => new ZsaLayout());
        }

        /// <inheritdoc />
        public EZLayout PrepareEZLayout(ZsaLayout ergodoxLayouts)
        {
            Debug.WriteLine("Layout prepared");

            return new EZLayout();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<KeyTemplate>> GetLayoutTemplate()
        {
            var layoutTemplate = new Task<IEnumerable<KeyTemplate>>(() => new List<KeyTemplate>());

            return await layoutTemplate;
        }
    }
}