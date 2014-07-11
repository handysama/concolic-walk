/*
 * Automatically converted from Java to C# using Sharpen.
 */

using System;
using Tsafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework;

namespace Tsafe
{
    [TestClass]
    public partial class TurnLogic
	{
		private static double twoPi = Math.PI * 2;

		private static double deg = Math.PI / 180;

		private static double gacc = 32.0;

		// Calc only 1st component: phi: the heading change
        [PexMethod(MaxConstraintSolverTime = 5, MaxRunsWithoutNewTests = 500)]
		public static double Snippet(double x0, double y0, double gspeed, double x1, double
			 y1, double x2, double y2, double dt)
		{
			double dx = x0 - x1;
			double dy = y0 - y1;
			if (dx == 0 && dy == 0)
			{
				return 0.0;
			}
			double instHdg = 90 * deg - Math.Atan2(dy, dx);
			if (instHdg < 0)
			{
				instHdg += 360 * deg;
			}
			if (instHdg > 2 * Math.PI)
			{
				instHdg -= 360 * deg;
			}
			dx = x1 - x2;
			dy = y1 - y2;
			if (dx == 0 && dy == 0)
			{
				return 0.0;
			}
			double instHdg0 = 90 * deg - Math.Atan2(dy, dx);
			if (instHdg0 < 0)
			{
				instHdg0 += 360 * deg;
			}
			if (instHdg0 > 2 * Math.PI)
			{
				instHdg0 -= 360 * deg;
			}
			double hdg_diff = NormAngle(instHdg - instHdg0);
			double phi = Math.Atan2(hdg_diff * gspeed, gacc * dt);
			return phi / deg;
		}

		private static double NormAngle(double angle)
		{
			if (angle < -Math.PI)
			{
				return angle + twoPi;
			}
			if (angle > Math.PI)
			{
				return angle - twoPi;
			}
			return angle;
		}

		public static void Main(string[] args)
		{
			// double x0 = SymbolicRealVars.getSymbolicReal(-1000.0, 1000.0, "x0");
			// double y0 = SymbolicRealVars.getSymbolicReal(-1000.0, 1000.0, "y0");
			// double x1 = SymbolicRealVars.getSymbolicReal(-1000.0, 1000.0, "x1");
			// double y1 = SymbolicRealVars.getSymbolicReal(-1000.0, 1000.0, "y1");
			// double x2 = SymbolicRealVars.getSymbolicReal(-1000.0, 1000.0, "x2");
			// double y2 = SymbolicRealVars.getSymbolicReal(-1000.0, 1000.0, "y2");
			// double gspeed = SymbolicRealVars.getSymbolicReal(-1000.0, 1000.0, "gspeed");
			// double dt = SymbolicRealVars.getSymbolicReal(-1000.0, 1000.0, "dt");
			// double x0 = 0;
			// double y0 = 1;
			// double x1 = 2;
			// double y1 = 3;
			// double x2 = 4;
			// double y2 = 5;
			// double gspeed = 6;
			// double dt = 7;
			double result = Snippet(0, 0, 0, 0, 0, 0, 0, 0);
		}
		//		SymbolicRealVars.notePathFunction("result");
	}
}
