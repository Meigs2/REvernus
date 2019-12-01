using System;

namespace EVEStandard.Utilities
{
    public static class Formulas
    {
        public static double SkillsPerMinute(short primaryAttribute, short secondaryAttribute)
        {
            if (primaryAttribute < 1 || primaryAttribute > 20 || secondaryAttribute < 1 || secondaryAttribute > 20)
            {
                throw new ArgumentOutOfRangeException();
            }
            return primaryAttribute + secondaryAttribute / 2d;
        }

        public static int SkillpointsPerLevel(short skillLevel, short skillRank)
        {
            if (skillLevel < 1 || skillLevel > 5 || skillRank < 1 || skillRank > 16)
            {
                throw new ArgumentOutOfRangeException();
            }
            return (int)Math.Pow(2, 2.5 * (skillLevel - 1d)) * 250 * skillRank;
        }

        public static double TargetLockTime(double scanResolution, double signatureRadius)
        {
            return 40000 / (scanResolution * Math.Pow(ASinH(signatureRadius), 2));
        }

        public static double AlignmentTime(double inertiaModifier, double shipMass)
        {
            return (Math.Log(2) * inertiaModifier * shipMass) / 500000;
        }

        private static double ASinH(double x)
        {
            return (Math.Log(x + Math.Sqrt(x * x + 1.0)));
        }
    }
}
