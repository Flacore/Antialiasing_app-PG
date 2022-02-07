using System.Drawing;

namespace Antialiasing_app.Tools
{

	public static class SelectionBox
	{
		private static Point startingMouseLocation;
		private static Rectangle trackerRectangleFromPreviousStep;
		private static Rectangle trackerRectangleFromCurrentStep;
		private static readonly SolidBrush fillBrush;
		private static bool isActive;

		public static bool IsActive { get { return isActive; } }
		public static Rectangle TrackedRectangle { get { return trackerRectangleFromPreviousStep; } }

		/// <summary>
		/// Konstruktor
		/// </summary>
		static SelectionBox()
		{
			fillBrush = new SolidBrush(Color.FromArgb(120, 0, 116, 231));
		}

		/// <summary>
		/// Vrati obdlznik selektora
		/// </summary>
		/// <param name="endPoint"></param>
		/// <returns></returns>
		private static Rectangle GetRect(Point endPoint)
		{
			// vupocitanie obdlznika selektora podla zaciatocneho bodu
			// a sucasneho bodu, kde sa selektor nachadza
			Rectangle outRect = new Rectangle(
				startingMouseLocation.X,
				startingMouseLocation.Y, 
				endPoint.X - startingMouseLocation.X, 
				endPoint.Y - startingMouseLocation.Y);

			// uprava pre rozne kvadranty, moze vychadzat zaporna suradnica
			if (outRect.Width < 0)
				outRect = new Rectangle(endPoint.X, outRect.Y, -outRect.Width, outRect.Height);

			if (outRect.Height < 0)
				outRect = new Rectangle(outRect.X, endPoint.Y, outRect.Width, -outRect.Height);

			return outRect; 
		}

		/// <summary>
		/// Inicializacia selection boxu
		/// </summary>
		/// <param name="pointStart"></param>
		public static void InitSelectionBox(Point currentMouseLocation)
		{
			startingMouseLocation = currentMouseLocation;
			isActive = true;
			//trackerRectangleFromPreviousStep = new Rectangle(currentMouseLocation.X, currentMouseLocation.Y, 0, 0);
		}

		/// <summary>
		/// Deaktivacia selection boxu
		/// </summary>
		public static void DisableSelectionBox()
		{
			isActive = false;
		}

		/// <summary>
		/// Vykreslenie selektoru
		/// </summary>
		/// <param name="graphics"></param>
		public static void Draw(Graphics g)
		{
			if (!isActive)
				return;

			g.FillRectangle(fillBrush, trackerRectangleFromCurrentStep);

			//if (rrr != null) 
			//		g.FillRegion(Brushes.Black, rrr);
		}

		/// <summary>
		/// Vrati zaciatocny bod
		/// </summary>
		/// <param name="graphics"></param>
		public static Point StartPoint()
		{
			return startingMouseLocation;
		}

		/// <summary>
		/// Vrati region pre prekreslenie
		/// </summary>
		/// <param name="nowPoint"></param>
		/// <returns></returns>
		public static Region Track(Point nowPoint)
		{
			trackerRectangleFromCurrentStep = GetRect(nowPoint);

			// region povodneho obdlznika
			Region a = new Region(trackerRectangleFromPreviousStep);
			a.Xor(trackerRectangleFromCurrentStep);
			trackerRectangleFromPreviousStep = trackerRectangleFromCurrentStep;

			return a; 
		}
	}
}
