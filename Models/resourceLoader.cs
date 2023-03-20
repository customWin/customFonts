using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customFonts.Models
{
    public static class resourceLoader
    {
        public static string WaitString()
        {
            var rnd = new Random();

            switch (rnd.Next(1, 3))
            {
                case 1:
                    return Resources.customFonts.waitString1;
                case 2:
                    return Resources.customFonts.waitString2;
                case 3:
                    return Resources.customFonts.waitString3;
            }

            return Resources.customFonts.waitString1;
        }

        public static string ConfLogoff()
        {
            var rnd = new Random();

            switch (rnd.Next(1, 3))
            {
                case 1:
                    return Resources.customFonts.confLogoff1;
                case 2:
                    return Resources.customFonts.confLogoff2;
                case 3:
                    return Resources.customFonts.confLogoff3;
            }

            return Resources.customFonts.confLogoff1;
        }

        public static string Problem()
        {
            var rnd = new Random();

            switch (rnd.Next(1, 2))
            {
                case 1:
                    return Resources.customFonts.problem1;
                case 2:
                    return Resources.customFonts.problem2;
            }

            return Resources.customFonts.problem1;
        }

        public static string ProbString()
        {
            var rnd = new Random();

            switch (rnd.Next(1, 3))
            {
                case 1:
                    return Resources.customFonts.probString1;
                case 2:
                    return Resources.customFonts.probString2;
                case 3:
                    return Resources.customFonts.probString3;
            }

            return Resources.customFonts.problem1;
        }

        public static string Requires11()
        {
            var rnd = new Random();

            switch (rnd.Next(1, 3))
            {
                case 1:
                    return Resources.customFonts.requires220001;
                case 2:
                    return Resources.customFonts.requires220002;
                case 3:
                    return Resources.customFonts.requires220003;
            }

            return Resources.customFonts.requires220001;
        }
    }
}
