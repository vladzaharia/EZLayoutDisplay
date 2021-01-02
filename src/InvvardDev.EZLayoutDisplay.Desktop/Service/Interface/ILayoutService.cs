using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvvardDev.EZLayoutDisplay.Desktop.Service.Interface
{
    public interface ILayoutService
    {
        /// <summary>
        /// Gets the <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ErgodoxLayout"/> basic info.
        /// </summary>
        /// <param name="layoutHashId">The layout hash ID to get.</param>
        /// <param name="layoutRevisionId">The layout revision ID to get.</param>
        /// <returns>The <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ErgodoxLayout"/>.</returns>
        Task<ErgodoxLayout> GetLayoutInfo(string layoutHashId, string layoutRevisionId);

        /// <summary>
        /// Gets the <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ErgodoxLayout"/>.
        /// </summary>
        /// <param name="layoutHashId">The layout hash ID to get.</param>
        /// <param name="layoutRevisionId">The layout revision ID to get.</param>
        /// <returns>The <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ErgodoxLayout"/>.</returns>
        Task<ErgodoxLayout> GetErgodoxLayout(string layoutHashId, string layoutRevisionId);

        /// <summary>
        /// Transforms an <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ErgodoxLayout"/> into a <see cref="InvvardDev.EZLayoutDisplay.Core.Model.EZLayout"/>.
        /// </summary>
        /// <param name="ergodoxLayout">The <see cref="InvvardDev.EZLayoutDisplay.Core.Model.ErgodoxLayout"/> to be transformed.</param>
        /// <returns>The <see cref="InvvardDev.EZLayoutDisplay.Core.Model.EZLayout"/> transformed into.</returns>
        EZLayout PrepareEZLayout(ErgodoxLayout ergodoxLayout);

        /// <summary>
        /// Gets the list of <see cref="InvvardDev.EZLayoutDisplay.Core.Model.KeyTemplate"/> from the local repository.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{KeyTemplate}"/></returns>
        Task<IEnumerable<KeyTemplate>> GetLayoutTemplate();
    }
}