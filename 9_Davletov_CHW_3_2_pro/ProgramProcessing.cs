using InOut;
using JSONObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_Davletov_CHW_3_2_pro
{
    /// <summary>
    /// Static class for working with program.
    /// </summary>
    public static class ProgramProcessing
    {
        /// <summary>
        /// Outputs tables with data.
        /// </summary>
        /// <param name="movies">The list of movies.</param>
        public static void OutputTables(List<Movie> movies) 
        {
            Application.Run(new MovieTable(movies));
            if (Input.GetChoiceForActorVariants() == 1)
            {
                int ind = Input.ObjectVariantsForEditing(movies);
                Application.Run(new ActorTable(movies[ind]));
            }
        }
    }
}
