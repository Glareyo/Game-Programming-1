using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk3HW_InterestingMovement
{
    public class PacManRepo
    {
        List<PacMan> pacManList;

        public List<PacMan> GetList { get { return this.pacManList; } }

        public PacManRepo()
        {
            pacManList = new List<PacMan>();
        }

        public string AddPacMan(PacMan pacMan)
        {
            if (pacManList.Contains(pacMan))
            {
                return "PacMan already in list";
            }
            else
            {
                pacManList.Add(pacMan);
                return "PacMan added to list";
            }
        }
        public string RemovePacMan(PacMan pacMan)
        {
            if (pacManList.Contains(pacMan))
            {
                pacManList.Remove(pacMan);
                return "PacMan removed from list";
            }
            else
            {
                return "PacMan not in list";
            }
        }
    }
}
