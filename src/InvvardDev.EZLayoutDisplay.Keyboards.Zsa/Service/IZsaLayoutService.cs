using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Model;
using InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Model;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Service
{
    public interface IZsaLayoutService
    {
        /// <summary>
        /// Gets the <see cref="ZsaLayout"/> basic info.
        /// </summary>
        /// <param name="layoutHashId">The layout hash ID to get.</param>
        /// <param name="layoutRevisionId">The layout zsaRevision ID to get.</param>
        /// <returns>The <see cref="ZsaLayout"/>.</returns>
        Task<ZsaLayout> GetLayoutInfo(string layoutHashId, string layoutRevisionId);

        /// <summary>
        /// Gets the <see cref="ZsaLayout"/>.
        /// </summary>
        /// <param name="layoutHashId">The layout hash ID to get.</param>
        /// <param name="layoutRevisionId">The layout zsaRevision ID to get.</param>
        /// <returns>The <see cref="ZsaLayout"/>.</returns>
        Task<ZsaLayout> GetErgodoxLayout(string layoutHashId, string layoutRevisionId);

        /// <summary>
        /// Transforms an <see cref="ZsaLayout"/> into a <see cref="EZLayout"/>.
        /// </summary>
        /// <param name="zsaLayout">The <see cref="ZsaLayout"/> to be transformed.</param>
        /// <returns>The <see cref="EZLayout"/> transformed into.</returns>
        EZLayout PrepareEZLayout(ZsaLayout zsaLayout);
    }
}