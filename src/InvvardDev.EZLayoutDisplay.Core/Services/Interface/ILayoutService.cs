using System.Collections.Generic;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Core.Models;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Interface
{
    public interface ILayoutService
    {
        /// <summary>
        /// Gets the <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ZsaLayout"/> basic info.
        /// </summary>
        /// <param name="layoutHashId">The layout hash ID to get.</param>
        /// <param name="layoutRevisionId">The layout revision ID to get.</param>
        /// <returns>The <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ZsaLayout"/>.</returns>
        Task<ZsaLayout> GetLayoutInfo(string layoutHashId, string layoutRevisionId);

        /// <summary>
        /// Gets the <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ZsaLayout"/>.
        /// </summary>
        /// <param name="layoutHashId">The layout hash ID to get.</param>
        /// <param name="layoutRevisionId">The layout revision ID to get.</param>
        /// <returns>The <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ZsaLayout"/>.</returns>
        Task<ZsaLayout> GetZsaLayout(string layoutHashId, string layoutRevisionId);

        /// <summary>
        /// Transforms an <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ZsaLayout"/> into a <see cref="InvvardDev.EZLayoutDisplay.Core.Model.EZLayout"/>.
        /// </summary>
        /// <param name="zsaLayout">The <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ZsaLayout"/> to be transformed.</param>
        /// <returns>The <see cref="InvvardDev.EZLayoutDisplay.Core.Model.EZLayout"/> transformed into.</returns>
        EZLayout PrepareEZLayout(ZsaLayout zsaLayout);

        /// <summary>
        /// Gets the list of <see cref="InvvardDev.EZLayoutDisplay.Core.Model.KeyTemplate"/> from the local repository.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{KeyTemplate}"/></returns>
        Task<IEnumerable<KeyTemplate>> GetLayoutTemplate();
    }
}