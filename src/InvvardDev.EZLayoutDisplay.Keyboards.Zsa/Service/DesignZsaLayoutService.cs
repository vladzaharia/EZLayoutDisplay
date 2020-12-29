using System.Diagnostics;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Model;
using InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Model;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Service
{
    public class DesignZsaLayoutService : IZsaLayoutService

    {
        public async Task<ZsaLayout> GetLayoutInfo(string layoutHashId, string layoutRevisionId)
        {
            Debug.WriteLine("Layout retrieved.");

            var layoutInfo = new ZsaLayout
                             {
                                 Title = "Layout title v1.0"
                             };

            return await new Task<ZsaLayout>(() => layoutInfo);
        }

        /// <inheritdoc />
        public async Task<ZsaLayout> GetErgodoxLayout(string layoutHashId, string layoutRevisionId)
        {
            Debug.WriteLine("Layout retrieved.");

            return await new Task<ZsaLayout>(() => new ZsaLayout());
        }

        /// <inheritdoc />
        public EZLayout PrepareEZLayout(ZsaLayout zsaLayouts)
        {
            Debug.WriteLine("Layout prepared");

            return new EZLayout();
        }
    }
}